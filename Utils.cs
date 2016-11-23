using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;


namespace PortfolioManager
{
    public class Utils
    {
        private static Utils               m_instance;
        private Dictionary<string, double> m_dictPrice;
        private Dictionary<string, string> m_dictName;


        private Utils()
        {
            m_dictPrice = new Dictionary<string, double>();
            m_dictName  = new Dictionary<string, string>();
        }


        public static Utils GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new Utils();
            }

            return m_instance;
        }


        public bool CheckInternetConnection()
        {
            WebClient webClient = new WebClient();
            Stream    response  = null;
            bool      retVal    = true;

            try
            {
                response = webClient.OpenRead("http://finance.yahoo.com");
            }
            catch (WebException)
            {
                retVal = false;
            }

            return retVal;
        }


        public double GetRealtimePrice(string symbol)
        {
            const string PLACE_HOLDER = "*****";

            if (   symbol.Length == 0
                || symbol        == PLACE_HOLDER
                || symbol.Trim() == "")
            {
                throw new ArgumentException("Bad param.");
            }

            //we already queried this stock's price, return it
            if (m_dictPrice.Count > 0 && m_dictPrice.ContainsKey(symbol))
            {
                return m_dictPrice[symbol];
            }

            WebClient webClient = new WebClient();

            //"*****" is where we put in the symbol
            string url = "http://finance.yahoo.com/d/quotes.csv?s=*****&f=l1";
            url = url.Replace(PLACE_HOLDER, symbol);

            Stream       response = webClient.OpenRead(url);
            StreamReader reader   = new StreamReader(response);
            string       sPrice   = reader.ReadToEnd();
            double       dPrice   =  0;

            if (sPrice == "N/A\n")
            {
                throw new ArgumentException("Bad symbol.");
            }

            dPrice = Convert.ToDouble(sPrice);
            m_dictPrice.Add(symbol, dPrice);

            reader.Close();

            return dPrice;
        }


        public string GetSymbolName(string symbol)
        {
            const string PLACE_HOLDER = "*****";

            if (   symbol.Length == 0
                || symbol        == PLACE_HOLDER
                || symbol.Trim() == "")
            {
                throw new ArgumentException("Bad param.");
            }

            //we already queried this stock's name, return it
            if (m_dictName.Count > 0 && m_dictName.ContainsKey(symbol))
            {
                return m_dictName[symbol];
            }

            WebClient webClient = new WebClient();

            //"*****" is where we put in the symbol
            string url = "http://download.finance.yahoo.com/d/quotes.csv?s=*****&f=n";
            url = url.Replace(PLACE_HOLDER, symbol);

            Stream       response = webClient.OpenRead(url);
            StreamReader reader   = new StreamReader(response);
            string       retVal   = reader.ReadToEnd();

            //name looks like this: "AAPL\n". Clean it up.
            retVal = retVal.Remove(0, 1);               //first char
            retVal = retVal.Remove(retVal.Length-2, 2); //last 2 chars

            //erase the ',' so that it doesnt break .csv file
            retVal = retVal.Replace(",", "");

            if (retVal == "N/A\n")
            {
                throw new ArgumentException("Bad symbol.");
            }

            //todo: remove "common stock" from the name

            m_dictName.Add(symbol, retVal);

            reader.Close();

            return retVal;
        }


        public void ClearPriceCache()
        {
            m_dictPrice.Clear();
        }


        public void ClearNameCache()
        {
            m_dictName.Clear();
        }


        public void ShowNoInternetDialog()
        {
            MessageBox.Show("No internet connection. Please connect to a network and try again.", "Portfolio Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}