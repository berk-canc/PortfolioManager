using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace PortfolioManager
{
    public partial class AddEditForm : Form
    {
        Holding     m_holding;
        Position    m_position;
        public enum WINDOW_TYPE { ADD_WINDOW, EDIT_WINDOW };


        public AddEditForm(string title, WINDOW_TYPE type)
        {
            InitializeComponent();
            this.Text = title;

            if(type == WINDOW_TYPE.EDIT_WINDOW)
            {
                textBoxSymbol.Enabled = false;
            }
        }


        public AddEditForm(string title, Position position, WINDOW_TYPE type)
        {
            InitializeComponent();

            this.Text                = title;
            this.m_position          = position;
            this.textBoxSymbol.Text  = m_position.Holding.Symbol.ToString();
            this.textBoxPrice.Text   = m_position.BuyPrice.ToString();
            this.textBoxShares.Text  = m_position.Shares.ToString();
            this.dateTimePicker.Text = m_position.BuyDate;

            if (type == WINDOW_TYPE.EDIT_WINDOW)
            {
                textBoxSymbol.Enabled = false;
            }
        }


        private AddEditForm()
        {
        }


        private void buttonSaveClose_Click(object sender, EventArgs e)
        {
            bool error = false;

            try
            {
                if (textBoxSymbol.Text.Trim() == "")
                {
                    error = true;
                    MessageBox.Show("Invalid symbol input", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxPrice.Text.Trim() == "" || Convert.ToDouble(textBoxPrice.Text) <= 0)
                {
                    error = true;
                    MessageBox.Show("Invalid price input.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBoxShares.Text.Trim() == "" || Convert.ToDouble(textBoxShares.Text) <= 0)
                {
                    error = true;
                    MessageBox.Show("Invalid shares input.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToDateTime(dateTimePicker.Text) > DateTime.Today || Convert.ToDateTime(dateTimePicker.Text) < new DateTime(1900, 1, 1))
                {
                    error = true;
                    MessageBox.Show("Invalid date input.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(FormatException)
            {
                error = true;
                MessageBox.Show("Invalid price/shares input.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!error)
            {
                try
                {
                    m_holding  = new Holding(textBoxSymbol.Text);
                    m_position = new Position(m_holding,
                                              Convert.ToDouble(textBoxShares.Text),
                                              Convert.ToDouble(textBoxPrice.Text),
                                              Convert.ToDateTime(dateTimePicker.Text).ToShortDateString());
                }
                catch (WebException)
                {
                    error = true;
                    Utils.GetInstance().ShowNoInternetDialog();
                }
                catch (ArgumentException)
                {
                    error = true;
                    MessageBox.Show("Invalid stock symbol.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!error)
                {
                    DialogResult = DialogResult.OK;

                    m_holding.AddPosition(m_position);
                    this.Close();
                }
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public Holding Holding
        {
            get
            {
                return m_holding;
            }
        }


        public Position Position
        {
            get
            {
                return m_position;
            }
        }
    }//class
}