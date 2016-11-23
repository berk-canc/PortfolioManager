using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PortfolioManager
{
    public partial class MainForm : Form
    {
        const string FILE_NAME = "portfolio.csv";
        const int    COL_COUNT = 11;
        enum COL_INDEX { SYMBOL, NAME, CURR_PRICE, SHARES, BUY_PRICE, COST_BASIS, CURR_VAL, GAIN_LOSS_DLR, GAIN_LOSS_PERCT, WEIGHT, DATE };

        Portfolio     m_portfolio;
        AddEditForm   m_AddEditForm;
        Thread        m_thread;
        bool          m_updatingGrid; //todo: use crit. sec. for this? No, it's on the same thread.
        bool          m_isRunning;
        bool          m_modified;
        List<string>  m_expandedRows;

        delegate void ThreadProcCallback();


        public MainForm()
        {
            InitializeComponent();

            m_portfolio    = new Portfolio();
            m_thread       = new Thread(new ThreadStart(ThreadProc));
            m_expandedRows = new List<string>();
            m_isRunning    = true;
            m_modified     = false;

            if (!Utils.GetInstance().CheckInternetConnection())
            {
                Utils.GetInstance().ShowNoInternetDialog();
            }

            //UnitTest();
            UpdateDataGridView();

            if (m_portfolio.HoldingCount == 0)
            {
                buttonEdit.Enabled               = false;
                buttonDelete.Enabled             = false;
                saveToolStripMenuItem.Enabled    = false;
                refreshToolStripMenuItem.Enabled = false;
            }

            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //m_thread.Start();
        }


        void UnitTest()
        {
            List<Holding> list = new List<Holding>();

            list.Add(new Holding("GPS", new Position(null, 1500, 18.13, new DateTime(2011, 10, 2).ToShortDateString())));
            list.Add(new Holding("GPS", new Position(null, 200, 18.24, new DateTime(2011, 10, 14).ToShortDateString())));
            list.Add(new Holding("GPS", new Position(null, 200, 19.83, new DateTime(2011, 10, 29).ToShortDateString())));
            list.Add(new Holding("GPS", new Position(null, 200, 29.94, new DateTime(2011, 11, 11).ToShortDateString())));
            list.Add(new Holding("NKE", new Position(null, 500, 60.13, new DateTime(2001, 12, 2).ToShortDateString())));
            list.Add(new Holding("NKE", new Position(null, 500, 60.13, new DateTime(2001, 12, 2).ToShortDateString())));
            list.Add(new Holding("MCD", new Position(null, 450, 99.21, new DateTime(2000, 2, 9).ToShortDateString())));
            list.Add(new Holding("F", new Position(null, 1000, 16.55, new DateTime(1999, 5, 27).ToShortDateString())));
            list.Add(new Holding("F", new Position(null, 1000, 16.55, new DateTime(1999, 5, 27).ToShortDateString())));
            list.Add(new Holding("HD", new Position(null, 500, 119.1, new DateTime(2013, 10, 13).ToShortDateString())));
            list.Add(new Holding("QQQ", new Position(null, 900, 133.11, new DateTime(2013, 1, 22).ToShortDateString())));
            list.Add(new Holding("JPM", new Position(null, 1000, 60.05, new DateTime(2016, 5, 11).ToShortDateString())));
            list.Add(new Holding("NKE", new Position(null, 400, 49.03, new DateTime(1999, 11, 22).ToShortDateString())));
            list.Add(new Holding("NKE", new Position(null, 100, 89.99, new DateTime(2015, 1, 2).ToShortDateString())));
            list.Add(new Holding("GLD", new Position(null, 477, 111.5, new DateTime(1991, 3, 13).ToShortDateString())));
            list.Add(new Holding("JPM", new Position(null, 1000, 56.05, new DateTime(2016, 6, 19).ToShortDateString())));
            list.Add(new Holding("JPM", new Position(null, 750, 50.19, new DateTime(2016, 8, 3).ToShortDateString())));
            list.Add(new Holding("GLD", new Position(null, 624, 138.9, new DateTime(1991, 6, 3).ToShortDateString())));
            list.Add(new Holding("QQQ", new Position(null, 100, 343.19, new DateTime(2013, 1, 22).ToShortDateString())));
            list.Add(new Holding("MCD", new Position(null, 250, 98.88, new DateTime(2001, 8, 8).ToShortDateString())));
            list.Add(new Holding("MCD", new Position(null, 1000, 91.92, new DateTime(2000, 10, 19).ToShortDateString())));
            list.Add(new Holding("MMM", new Position(null, 400, 97.13, new DateTime(2009, 10, 10).ToShortDateString())));
            list.Add(new Holding("COST", new Position(null, 1080, 179.09, new DateTime(1998, 8, 29).ToShortDateString())));
            list.Add(new Holding("MMM", new Position(null, 100, 127.13, new DateTime(2009, 10, 1).ToShortDateString())));
            list.Add(new Holding("MMM", new Position(null, 300, 129.1, new DateTime(2009, 11, 1).ToShortDateString())));
            list.Add(new Holding("GPS", new Position(null, 1200, 30.5, new DateTime(2011, 11, 11).ToShortDateString())));
            list.Add(new Holding("MMM", new Position(null, 440, 98.9, new DateTime(2015, 5, 12).ToShortDateString())));
            list.Add(new Holding("AZO", new Position(null, 200, 538.95, new DateTime(2014, 4, 30).ToShortDateString())));
            list.Add(new Holding("GS", new Position(null, 950, 191.17, new DateTime(2016, 1, 22).ToShortDateString())));
            list.Add(new Holding("CBS", new Position(null, 100, 61.09, new DateTime(2016, 1, 22).ToShortDateString())));
            list.Add(new Holding("CBS", new Position(null, 90, 60.01, new DateTime(2016, 1, 29).ToShortDateString())));
            list.Add(new Holding("GS", new Position(null, 100.5, 217.02, new DateTime(2016, 1, 22).ToShortDateString())));
            list.Add(new Holding("ETFC", new Position(null, 200, 30.33, new DateTime(2016, 1, 22).ToShortDateString())));
            list.Add(new Holding("CLX", new Position(null, 100, 130, new DateTime(2016, 1, 22).ToShortDateString())));
            list.Add(new Holding("BRK-B", new Position(null, 500, 101.83, new DateTime(2000, 2, 14).ToShortDateString())));
            list.Add(new Holding("BRK-B", new Position(null, 220, 103.11, new DateTime(2002, 2, 1).ToShortDateString())));
            list.Add(new Holding("BRK-B", new Position(null, 500, 109.26, new DateTime(2005, 2, 1).ToShortDateString())));
            list.Add(new Holding("EA", new Position(null, 330, 81.82, new DateTime(2006, 11, 13).ToShortDateString())));
            list.Add(new Holding("TMUS", new Position(null, 900, 51.01, new DateTime(2008, 9, 22).ToShortDateString())));
            list.Add(new Holding("CMG", new Position(null, 410, 109.26, new DateTime(2015, 12, 4).ToShortDateString())));
            list.Add(new Holding("SBUX", new Position(null, 600, 48.7, new DateTime(2005, 4, 4).ToShortDateString())));
            list.Add(new Holding("SBUX", new Position(null, 300, 50.89, new DateTime(2005, 7, 7).ToShortDateString())));
            list.Add(new Holding("LMT", new Position(null, 500, 191.33, new DateTime(2008, 5, 24).ToShortDateString())));
            list.Add(new Holding("LMT", new Position(null, 150, 188.21, new DateTime(2008, 10, 21).ToShortDateString())));
            list.Add(new Holding("PSA", new Position(null, 700, 288.3, new DateTime(2011, 5, 2).ToShortDateString())));
            list.Add(new Holding("PSA", new Position(null, 100, 196.1, new DateTime(2012, 2, 4).ToShortDateString())));
            list.Add(new Holding("PSA", new Position(null, 90, 252.12, new DateTime(2013, 11, 2).ToShortDateString())));
            list.Add(new Holding("PSA", new Position(null, 1, 279.3, new DateTime(2014, 12, 29).ToShortDateString())));

            for (int i=0; i<list.Count; i++)
            {
                m_portfolio.AddHolding(list[i]);
            }
        }


        void UpdateDataGridView()
        {
            int subPosAddIndex = 0;
            m_updatingGrid     = true;
            dataGridView.Rows.Clear();

            for (int i = 0; i < m_portfolio.HoldingCount; i++)
            {
                Holding currHolding = m_portfolio.GetHolding(i);
                string  dateStr     = currHolding.GetPosition(0).BuyDate;
                string  buyPriceStr = currHolding.GetPosition(0).BuyPrice.ToString();

                //if this holding's sub-positions are expanded
                if (m_expandedRows.LastIndexOf(currHolding.Symbol) >= 0)
                {
                    AddAllSubPosToUI(currHolding.Symbol, i + subPosAddIndex);
                    subPosAddIndex += currHolding.PositionCount - 1;
                    continue;
                }

                if (currHolding.PositionCount > 1)
                {
                    dateStr     = "Various";
                    buyPriceStr = "Various";
                }

                this.dataGridView.Rows.Add(currHolding.Symbol,
                                           currHolding.Name,
                                           currHolding.CurrentPrice,
                                           currHolding.Shares,
                                           buyPriceStr,
                                           Math.Round(currHolding.CostBasis   , 2),
                                           Math.Round(currHolding.CurrentValue, 2),
                                           Math.Round(currHolding.GainLoss    , 2),
                                           Math.Round(100 * (currHolding.GainLoss     / currHolding.CostBasis)   , 2),
                                           Math.Round(100 * (currHolding.CurrentValue / m_portfolio.CurrentValue), 2),
                                           dateStr);
                
            }//for

            AddLastRow();
            m_updatingGrid = false;
        }


        void AddLastRow()
        {
            if(m_portfolio.HoldingCount == 0)
            {
                this.dataGridView.Rows.Add("-", "-", "-", "-", "Total", "N/A", "N/A", "N/A", "N/A", "N/A", "-");
            }
            else
            {
                this.dataGridView.Rows.Add("-", "-", "-", "-", "Total", Math.Round(m_portfolio.CostBasis   , 2),
                                                                        Math.Round(m_portfolio.CurrentValue, 2),
                                                                        Math.Round(m_portfolio.GainLoss    , 2),
                                                                        Math.Round(100 * (m_portfolio.GainLoss / m_portfolio.CurrentValue), 2),
                                                                        "100",
                                                                        "-");
            }

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.Rows[dataGridView.RowCount-2].DefaultCellStyle = style;
        }


        void ThreadProc()
        {
            //todo: crit sec.
            //todo: do not run this thread after 4PM EST

            while (m_thread.IsAlive && m_isRunning)
            {               
                //sleep in small chunks so that we can respond to app closing faster
                for(int i=0; i<10; i++)
                {
                    if(!m_thread.IsAlive || !m_isRunning)
                    {
                        return;
                    }

                    Console.WriteLine("sleeping... i=" + i);
                    Thread.Sleep(1000);
                }

                //Utils.GetInstance().ClearPriceDictionary();

                //for (int i=0; i<m_portfolio.HoldingCount; i++)
                //{
                //    Holding currHolding      = m_portfolio.GetHolding(i);
                //    currHolding.CurrentPrice = Utils.GetInstance().GetRealtimePrice(currHolding.Symbol);
                //}

                ////do not update controls from another thread! Must use a delegate like this
                //if (dataGridView.InvokeRequired)
                //{
                //    ThreadProcCallback callback = new ThreadProcCallback(ThreadProc);
                //    this.Invoke(callback);
                //}
                //else
                //{
                //    UpdateDataGridView();
                //}

                Console.WriteLine("updated................................");
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            m_AddEditForm = new AddEditForm("Add Holding", AddEditForm.WINDOW_TYPE.ADD_WINDOW); //todo: leak?

            if (m_AddEditForm.ShowDialog() == DialogResult.OK)
            {
                m_portfolio.AddHolding(m_AddEditForm.Holding);
                UpdateDataGridView();
                //go to the last holding. -2 because last empty row plus the total row...
                dataGridView.Rows[dataGridView.RowCount-3].Cells[0].Selected = true;

                if (m_portfolio.HoldingCount > 0)
                {
                    buttonEdit.Enabled   = true;
                    buttonDelete.Enabled = true;
                }

                m_modified = true;
            }
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string  symbol  = dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.SYMBOL].Value.ToString();
            Holding holding = m_portfolio.GetHolding(symbol);

            if (holding == null)
            {
                throw new NullReferenceException("Null holding.");
            }

            int    rowIndex    = dataGridView.SelectedRows[0].Index;
            int    occurance   = OccuranceInDataGridView(symbol);
            double buyPrice    = Convert.ToDouble(dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.BUY_PRICE].Value);
            double shares      = Convert.ToDouble(dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.SHARES].Value);
            string buyDate     = dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.DATE].Value.ToString();
            double newBuyPrice = 0;
            double newShares   = 0;
            string newBuyDate  = "";
            string title       = "";

            //edit holding w/ 1 pos.
            if (occurance == 1 && holding.PositionCount == 1)
            {
                title = "Edit Holding";
            }
            //edit holding w/ multiple pos.
            else if (occurance == 1 && holding.PositionCount > 1)
            {
                //this should never happen because edit button is disabled
                throw new InvalidOperationException();
            }
            //edit a sub-pos
            else
            {
                title = "Edit Position";
            }

            m_AddEditForm = new AddEditForm(title, holding.GetPosition(holding.Symbol, shares, buyPrice, buyDate), AddEditForm.WINDOW_TYPE.EDIT_WINDOW);

            if (m_AddEditForm.ShowDialog() == DialogResult.OK)
            {
                newBuyPrice = m_AddEditForm.Position.BuyPrice;
                newShares   = m_AddEditForm.Position.Shares;
                newBuyDate  = m_AddEditForm.Position.BuyDate;

                holding.GetPosition(holding.Symbol, shares, buyPrice, buyDate).BuyPrice      = newBuyPrice;
                holding.GetPosition(holding.Symbol, shares, newBuyPrice, buyDate).Shares     = newShares;
                holding.GetPosition(holding.Symbol, newShares, newBuyPrice, buyDate).BuyDate = newBuyDate;

                UpdateDataGridView();

                dataGridView.Rows[rowIndex].Cells[0].Selected = true;
                m_modified = true;
            }
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string  symbol    = dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.SYMBOL].Value.ToString();
            Holding holding   = m_portfolio.GetHolding(symbol);
            int     occurance = OccuranceInDataGridView(symbol);
            bool    deleted   = false;
            int     rowIndex  = dataGridView.SelectedRows[0].Index;

            if (holding == null)
            {
                throw new NullReferenceException("Null holding.");
            }

            //delete holding w/1 pos.
            if (occurance == 1 && holding.PositionCount == 1)
            {
                DialogResult retVal = MessageBox.Show("Delele this holding?", "Portfolio Manager", MessageBoxButtons.YesNo);

                if (retVal == DialogResult.Yes)
                {
                    if (DeleteAllHolding(dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.SYMBOL].Value.ToString()))
                    {
                        UpdateDataGridView();
                        deleted = true;
                    }
                }
            }
            //delete holding w/multiple pos.
            else if (occurance == 1 && holding.PositionCount > 1)
            {
                DialogResult retVal = MessageBox.Show("Delele this holding with multiple positions?", "Portfolio Manager", MessageBoxButtons.YesNo);

                if (retVal == DialogResult.Yes)
                {
                    if(DeleteAllHolding(dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.SYMBOL].Value.ToString()))
                    {
                        UpdateDataGridView();
                        deleted = true;
                    }
                }
            }
            //delete a sub-pos
            else
            {
                DialogResult retVal = MessageBox.Show("Delele this position?", "Portfolio Manager", MessageBoxButtons.YesNo);

                if (retVal == DialogResult.Yes)
                {
                    double buyPrice = Convert.ToDouble(dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.BUY_PRICE].Value);
                    double shares   = Convert.ToDouble(dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.SHARES].Value);
                    string buyDate  = dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.DATE].Value.ToString();

                    holding.RemovePosition(holding.GetPosition(holding.Symbol, shares, buyPrice, buyDate));

                    if (holding.PositionCount == 1)
                    {
                        m_expandedRows.RemoveAll(item => item == holding.Symbol);
                    }
                    else
                    {
                        m_expandedRows.Remove(holding.Symbol);
                    }

                    UpdateDataGridView();
                    deleted = true;
                }
            }

            if(deleted)
            {
                //-1 because we now have 1 less row
                if(rowIndex != 0)
                {
                    rowIndex--;
                }

                if (m_portfolio.HoldingCount == 0)
                {
                    buttonEdit.Enabled   = false;
                    buttonDelete.Enabled = false;
                }

                dataGridView.Rows[rowIndex].Cells[0].Selected = true;
                m_modified = true;
            }
        }


        //calls UpdateDataGridView()
        bool DeleteAllHolding(string symbol)
        {
            bool retVal = false;

            for (int i = 0; i < m_portfolio.HoldingCount; i++)
            {
                if (m_portfolio.GetHolding(i).Symbol == symbol)
                {
                    m_portfolio.RemoveAllHolding(i);
                    DeleteAllSubPosFromUI(symbol);
                    retVal = true;

                    break;
                }
            }

            if (m_portfolio.HoldingCount == 0)
            {
                buttonEdit.Enabled               = false;
                buttonDelete.Enabled             = false;
                saveToolStripMenuItem.Enabled    = false;
                refreshToolStripMenuItem.Enabled = false;
            }

            return retVal;
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //don't execute this method when updating UI
            if (m_updatingGrid)
            {
                return;
            }

            bool bottomTwoRows = false;

            //bottom 2 rows
            if (   e.RowIndex == dataGridView.RowCount - 1
                || e.RowIndex == dataGridView.RowCount - 2)
            {
                bottomTwoRows        = true;
                buttonEdit.Enabled   = false;
                buttonDelete.Enabled = false;
            }
            //holding with "Various"
            else if (   dataGridView.SelectedRows.Count > 0 
                     && dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.DATE].Value.ToString() == "Various")
            {
                buttonEdit.Enabled = false;
            }
            //holding with not "Various"
            else if (    dataGridView.SelectedRows.Count > 0 
                      && dataGridView.SelectedRows[0].Cells[(int)COL_INDEX.DATE].Value.ToString() != "Various")
            {
                buttonEdit.Enabled = true;
            }

            buttonDelete.Enabled = !bottomTwoRows;
        }


        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //don't execute this method when updating UI
            if (   m_updatingGrid 
                || e.RowIndex >= m_portfolio.HoldingCount + m_expandedRows.Count)
            {
                return;
            }

            string symbol = dataGridView.Rows[e.RowIndex].Cells[(int)COL_INDEX.SYMBOL].Value.ToString();

            //expand holding //////////////////////////////////////////////////////////////////////
            if (m_expandedRows.LastIndexOf(symbol) == -1) //not found
            {
                if (dataGridView.Rows[e.RowIndex].Cells[(int)COL_INDEX.DATE].Value.ToString() != "Various")
                {
                    return;
                }

                dataGridView.Rows.RemoveAt(e.RowIndex);

                AddAllSubPosToUI(symbol, e.RowIndex);
                dataGridView.Rows[e.RowIndex].Cells[0].Selected = true;
            }
            //collapse holding ////////////////////////////////////////////////////////////////////
            else //found
            {
                if(DeleteAllSubPosFromUI(symbol))
                {
                    UpdateDataGridView();
                    dataGridView.Rows[e.RowIndex].Cells[0].Selected = true;
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////
        }


        //doesn't call UpdateDataGridView()
        void AddAllSubPosToUI(string symbol, int rowIndex)
        {
            int insertIndex = 0;

            for (int i = 0; i < m_portfolio.HoldingCount; i++)
            {
                Holding holding = m_portfolio.GetHolding(i);

                if (symbol != holding.Symbol)
                {
                    continue;
                }

                for (int j = 0; j < holding.PositionCount; j++)
                {
                    Position pos = holding.GetPosition(j);

                    dataGridView.Rows.Insert(rowIndex + insertIndex,
                                              holding.Symbol,
                                              holding.Name,
                                              holding.CurrentPrice,
                                              pos.Shares,
                                              pos.BuyPrice,
                                              pos.CostBasis,
                                              pos.CurrentValue,
                                              pos.GainLoss,
                                              Math.Round(100 * (pos.GainLoss     / pos.CostBasis)           , 2),
                                              Math.Round(100 * (pos.CurrentValue / m_portfolio.CurrentValue), 2),
                                              pos.BuyDate);
                    insertIndex++;
                    m_expandedRows.Add(symbol);
                }//for
            }//for
        }


        //doesn't call UpdateDataGridView()
        bool DeleteAllSubPosFromUI(string symbol)
        {
            bool retVal = false;

            for (int i = 0; i < m_expandedRows.Count; i++)
            {
                if (m_expandedRows[i] == symbol)
                {
                    m_expandedRows.RemoveAt(i);
                    i = -1; //restart search, list count has changed
                    retVal = true;
                }
            }

            return retVal;
        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //todo: date sort broken

            //remove last row cause it breaks the sorting
            dataGridView.Rows.RemoveAt(dataGridView.RowCount - 2);

            if (   dataGridView.SortOrder == SortOrder.None
                || dataGridView.SortOrder == SortOrder.Descending)
            {
                dataGridView.Sort(dataGridView.Columns[e.ColumnIndex], ListSortDirection.Ascending);
            }
            else
            {
                dataGridView.Sort(dataGridView.Columns[e.ColumnIndex], ListSortDirection.Descending);
            }

            AddLastRow();
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeInit();
        }


        private void SavetoFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);

            try
            {
                writer.WriteLine("Symbol,Name,Last Price,Shares,Buy Price,Cost Basis,Current Value,$ - Gain/Loss,% - Gain/Loss,% - Weight,Date Purchased");

                for (int i = 0; i < m_portfolio.HoldingCount; i++)
                {
                    Holding holding = m_portfolio.GetHolding(i);

                    for (int j = 0; j < holding.PositionCount; j++)
                    {
                        Position pos = holding.GetPosition(j);

                        writer.WriteLine(holding.Symbol + "," +
                                         holding.Name + "," +
                                         holding.CurrentPrice + "," +
                                         pos.Shares.ToString() + "," +
                                         pos.BuyPrice + "," +
                                         pos.CostBasis + "," +
                                         pos.CurrentValue + "," +
                                         pos.GainLoss + "," +
                                         Math.Round(100 * (pos.GainLoss / pos.CostBasis), 2) + "," +
                                         Math.Round(100 * (pos.CurrentValue / m_portfolio.CurrentValue), 2) + "," +
                                         pos.BuyDate);
                    }//for
                }//for

                writer.WriteLine("-,-,-,-,Total," + Math.Round(m_portfolio.CostBasis, 2) + "," +
                                                    Math.Round(m_portfolio.CurrentValue, 2) + "," +
                                                    Math.Round(m_portfolio.GainLoss, 2) + "," +
                                                    Math.Round(100 * (m_portfolio.GainLoss / m_portfolio.CurrentValue), 2) + "," +
                                                    "100" + ",-");

            }
            catch(Exception ex)
            {
                writer.Close();
                throw ex;
            }

            m_modified = false;
            writer.Close();
        }


        private void LoadFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            m_portfolio.Clear();

            int i = 0;

            while (!reader.EndOfStream)
            {
                string[] row = reader.ReadLine().Split(',');
                Holding  holding;

                if(row.Length != COL_COUNT)
                {
                    reader.Close();
                    throw new FormatException("Bad file format.");
                }

                //skip header
                if (i == 0)
                {
                    i++;
                    continue;
                }

                //done, no need load the last total line.
                if (row[0] == "-")
                {
                    break;
                }

                try
                {
                    holding = new Holding(row[(int)COL_INDEX.SYMBOL], new Position(null,
                                                                                   Convert.ToDouble(row[(int)COL_INDEX.SHARES]),
                                                                                   Convert.ToDouble(row[(int)COL_INDEX.BUY_PRICE]),
                                                                                   row[(int)COL_INDEX.DATE]));
                }
                catch(FormatException ex)
                {
                    reader.Close();
                    throw ex;
                }

                m_portfolio.AddHolding(holding);
            }//while

            bool flag = false;

            if (m_portfolio.HoldingCount == 0)
            {
                buttonEdit.Enabled               = flag;
                buttonDelete.Enabled             = flag;
                saveToolStripMenuItem.Enabled    = flag;
                refreshToolStripMenuItem.Enabled = flag;
            }
            else
            {
                buttonEdit.Enabled               = !flag;
                buttonDelete.Enabled             = !flag;
                saveToolStripMenuItem.Enabled    = !flag;
                refreshToolStripMenuItem.Enabled = !flag;
            }

            reader.Close();
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.GetInstance().ClearPriceCache();

            for (int i = 0; i < m_portfolio.HoldingCount; i++)
            {
                Holding currHolding = m_portfolio.GetHolding(i);

                try
                {
                    currHolding.CurrentPrice = Utils.GetInstance().GetRealtimePrice(currHolding.Symbol);
                }
                catch (System.Net.WebException)
                {
                    Utils.GetInstance().ShowNoInternetDialog();
                    return;
                }
            }

            UpdateDataGridView();
        }


        private void samplePortfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ShowSavePortfolioDialog() == DialogResult.Cancel)
            {
                return;
            }

            List<Holding> list = new List<Holding>();

            m_portfolio.Clear();

            try
            {
                list.Add(new Holding("V"   , new Position(null, 790, 72.21 , new DateTime(1999, 2, 9).ToShortDateString())));
                list.Add(new Holding("AAPL", new Position(null, 100, 88.83 , new DateTime(2010, 10, 29).ToShortDateString())));
                list.Add(new Holding("AAPL", new Position(null, 150, 96.00 , new DateTime(2010, 11, 11).ToShortDateString())));
                list.Add(new Holding("AAPL", new Position(null, 100, 101.24, new DateTime(2012, 4, 14).ToShortDateString())));
                list.Add(new Holding("AAPL", new Position(null, 200, 128.13, new DateTime(2014, 9, 2).ToShortDateString())));
                list.Add(new Holding("INTC", new Position(null, 700, 34.83 , new DateTime(2001, 5, 8).ToShortDateString())));
                list.Add(new Holding("INTC", new Position(null, 800, 40.19 , new DateTime(2006, 8, 22).ToShortDateString())));
                list.Add(new Holding("ROST", new Position(null, 900, 57.01 , new DateTime(2013, 10, 13).ToShortDateString())));
                list.Add(new Holding("EA"  , new Position(null, 350, 66.55 , new DateTime(2008, 5, 27).ToShortDateString())));
                list.Add(new Holding("EA"  , new Position(null, 200, 78.45 , new DateTime(2009, 9, 18).ToShortDateString())));
                list.Add(new Holding("BND" , new Position(null, 1500, 97.19, new DateTime(2009, 6, 26).ToShortDateString())));
            }
            catch (System.Net.WebException)
            {
                Utils.GetInstance().ShowNoInternetDialog();
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                m_portfolio.AddHolding(list[i]);
            }

            UpdateDataGridView();

            buttonEdit.Enabled               = true;
            buttonDelete.Enabled             = true;
            saveToolStripMenuItem.Enabled    = true;
            refreshToolStripMenuItem.Enabled = true;
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowSavePortfolioDialog() == DialogResult.Cancel)
            {
                return;
            }

            bool         exception = false;
            DialogResult retVal    = openFileDialog.ShowDialog();

            if(retVal == DialogResult.OK)
            {
                try
                {
                    LoadFromFile(openFileDialog.FileName);
                }
                catch (System.Net.WebException)
                {
                    exception = true;
                    Utils.GetInstance().ShowNoInternetDialog();
                }
                catch (System.FormatException)
                {
                    exception = true;
                    MessageBox.Show("File format is not correct.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(exception == true)
                {
                    m_portfolio.Clear();
                }

                UpdateDataGridView();
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult retVal = saveFileDialog.ShowDialog();

            if (retVal == DialogResult.OK)
            {
                SavetoFile(saveFileDialog.FileName);
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowSavePortfolioDialog() == DialogResult.Cancel)
            {
                return;
            }

            DeInit();
            this.Close();
        }


        void DeInit()
        {
            m_isRunning = false;
            m_portfolio.Clear();
            //m_thread.Join();
        }


        int OccuranceInDataGridView(string symbol)
        {
            int retVal = 0;

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                if (symbol == dataGridView.Rows[i].Cells[(int)COL_INDEX.SYMBOL].Value.ToString())
                {
                    retVal++;
                }
            }

            return retVal;
        }


        DialogResult ShowSavePortfolioDialog()
        {
            DialogResult retVal = DialogResult.No;

            if (m_modified && m_portfolio.HoldingCount > 1)
            {
                retVal = MessageBox.Show("Do you want to save changes to this portfolio?", "Portfolio Manager", MessageBoxButtons.YesNoCancel);

                if (    retVal == DialogResult.Cancel 
                     || retVal == DialogResult.No)
                {
                    //caller needs to handle this
                }
                else if (retVal == DialogResult.Yes)
                {
                    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    filePath       += "\\" + FILE_NAME;

                    SavetoFile(filePath);
                }
            }

            return retVal;
        }
    }//class
}