using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager
{
    public class Holding
    {
        List<Position> m_positions;
        double         m_price;
        string         m_name;


        public Holding(string symbol)
        {
            Symbol      = symbol.ToUpper().Trim();
            m_positions = new List<Position>();

            m_name = Utils.GetInstance().GetSymbolName(symbol);
            RefreshPrice();
        }


        public Holding(string symbol, Position pos)
        {
            pos.Holding = this;
            Symbol      = symbol.ToUpper().Trim();
            m_positions = new List<Position>();
            m_positions.Add(pos);

            m_name = Utils.GetInstance().GetSymbolName(symbol);
            RefreshPrice();
        }


        private Holding()
        {

        }


        public string Symbol
        {
            get;
            set;
        }


        public string Name
        {
            get
            {
                return m_name;
            }
        }


        public double CurrentPrice
        {
            get
            {
                return m_price;
            }
            set
            {
                m_price = value;
            }
        }


        public double Shares
        {
            get
            {
                double retVal = 0;

                for (int i = 0; i < m_positions.Count; i++)
                {
                    retVal += m_positions[i].Shares;
                }

                return retVal;
            }
        }


        public int PositionCount
        {
            get
            {
                return m_positions.Count;
            }
        }


        public double CostBasis
        {
            get
            {
                double retVal = 0;

                for(int i=0; i<m_positions.Count; i++)
                {
                    retVal += m_positions[i].CostBasis;
                }

                return retVal;
            }
        }


        public double GainLoss
        {
            get
            {
                return CurrentValue - CostBasis;
            }
        }


        public double Commission
        {
            get
            {
                double retVal = 0;

                for(int i=0; i<m_positions.Count; i++)
                {
                    retVal += m_positions[i].Commission;
                }

                return retVal;
            }
        }


        public double CurrentValue
        {
            get
            {
                return m_price * Shares;
            }
        }


        public void AddPosition(Position pos)
        {
            if(pos.Holding.Symbol != Symbol)
            {
                throw new ArgumentException("Cannot add position with different symbol to a holding.");
            }
            
            m_positions.Add(pos);
        }


        public void RemovePosition(Position pos)
        {
            if(pos == null)
            {
                throw new ArgumentException("Cannot remove null position.");
            }

            m_positions.Remove(pos);
        }


        public Position GetPosition(int index)
        {
            if (index >= m_positions.Count)
            {
                throw new ArgumentException("Bad index.");
            } 
            return m_positions[index];
        }


        public Position GetPosition(string symbol, double shares, double buyPrice, string buyDate)
        {
            Position retVal = null;

            for (int i = 0; i < m_positions.Count; i++)
            {
                if(    m_positions[i].BuyDate        == buyDate
                    && m_positions[i].BuyPrice       == buyPrice
                    && m_positions[i].Shares         == shares
                    && m_positions[i].Holding.Symbol == symbol)
                {
                    retVal = m_positions[i];
                    break;
                }
            }

            return retVal;
        }


        public void RefreshPrice()
        {
            m_price = Utils.GetInstance().GetRealtimePrice(Symbol);
        }

    }//class
}