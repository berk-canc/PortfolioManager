using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PortfolioManager
{
    class Portfolio
    {
        List<Holding> m_list;
        double        m_currVal;
        double        m_costBasis;


        public Portfolio()
        {
            m_list      = new List<Holding>();
            m_currVal   = 0;
            m_costBasis = 0;
        }


        public void AddHolding(Holding holding)
        {
            if (m_list.Count == 0)
            {
                m_list.Add(holding);

                m_currVal   += holding.CurrentValue;
                m_costBasis += holding.CostBasis;
                return;
            }

            bool dup          = false;
            int  holdingCount = m_list.Count;

            for (int i = 0; i < holdingCount; i++)
            {
                if (holding.Symbol == m_list[i].Symbol)
                {
                    int posCount = holding.PositionCount;

                    for (int j = 0; j < posCount; j++)
                    {
                        m_list[i].AddPosition(holding.GetPosition(j));
                        m_currVal   += holding.GetPosition(j).CurrentValue;
                        m_costBasis += holding.GetPosition(j).CostBasis;

                        dup = true;
                    }
                }
            }//for

            if(!dup)
            {
                m_list.Add(holding);
                m_currVal   += holding.CurrentValue;
                m_costBasis += holding.CostBasis;
            }
        }


        public void RemoveHolding(int index)
        {
            if (index >= m_list.Count)
            {
                throw new ArgumentException("Bad index.");
            }

            m_currVal   -= m_list[index].CurrentValue;
            m_costBasis -= m_list[index].CostBasis;
            m_list.RemoveAt(index);
        }


        public void RemoveAllHolding(int index)
        {
            if (index >= m_list.Count)
            {
                throw new ArgumentException("Bad index.");
            }

            string holdingSymbol = m_list[index].Symbol;

            for (int i = 0; i < m_list.Count; i++)
            {
                if (m_list[i].Symbol == holdingSymbol)
                {
                    m_currVal   -= m_list[i].CurrentValue;
                    m_costBasis -= m_list[i].CostBasis;
                    m_list.RemoveAt(i);
                    i--; //start search again from where we left of
                    continue;
                }
            }
        }


        public void Clear()
        {
            m_list.Clear();
            m_currVal   = 0;
            m_costBasis = 0;
        }


        public Holding GetHolding(int index)
        {
            if(index >= m_list.Count)
            {
                throw new ArgumentException("Bad index.");
            }

            return m_list[index];
        }


        //todo: any other place I can use this?
        public Holding GetHolding(string symbol)
        {
            Holding holding = null;

            for (int i = 0; i < m_list.Count; i++)
            {
                if (m_list[i].Symbol == symbol)
                {
                    holding = m_list[i];
                    break;
                }
            }

            return holding;
        }


        public double GetHoldingWeight(int index)
        {
            if (index >= m_list.Count)
            {
                throw new ArgumentException("Bad index.");
            }

            return m_list[index].CurrentValue / CurrentValue;
        }


        public double CurrentValue
        {
            get
            {
                return m_currVal;
            }
        }


        public double CostBasis
        {
            get
            {
                return m_costBasis;
            }
        }


        public double GainLoss
        {
            get
            {
                return CurrentValue - CostBasis;
            }
        }


        public int HoldingCount
        {
            get
            {
                return m_list.Count;
            }
        }

    }//class
}