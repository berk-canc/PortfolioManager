using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager
{
    public class Position
    {
        public Position(Holding holding, double shares, double buyPrice, string buyDate)
        {
            Holding    = holding;
            Shares     = shares;
            BuyDate    = buyDate;
            BuyPrice   = buyPrice;
            IsLong     = true;
            IsOpen     = true;
            Commission = 0;
        }


        private Position()
        {

        }

        public Holding Holding
        {
            get;
            set;
        }


        public double Shares
        {
            get;
            set;
        }


        public double CostBasis
        {
            get
            {
                return BuyPrice * Shares; 
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
            get;
            set;
        }


        public double CurrentValue
        {
            get
            {
                return Shares * Holding.CurrentPrice;
            }
        }


        public double BuyPrice
        {
            get;
            set;
        }


        public double SellPrice
        {
            get;
            set;
        }


        public string BuyDate
        {
            get;
            set;
        }


        public string SellDate
        {
            get;
            set;
        }


        public bool IsLong
        {
            get;
            set;
        }


        public bool IsOpen
        {
            get;
            set;
        }

    }//class
}