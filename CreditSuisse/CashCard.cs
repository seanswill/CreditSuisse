using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse
{
    public class CashCard : ICashCard
    {
        static double _Balance = 0;
        readonly int _Pin = 1234;
        static  string _CardNumber = "";

        public CashCard(int pInitialBalance, String pCardNumber)
        {
            _Balance = pInitialBalance;
            _CardNumber = pCardNumber;
        }

        public CashCard()
        {
        }
        public  double Balance(int pPin)
        {
            // returns the balance if the pin is correct
            if (LogIn(pPin)) {
                return _Balance;
                    }
            else
            {
                return 0;
            }
        }

        static readonly  Object l = new object();
        public bool Topup(int pPin, double pAmount)
        {
            // tops up the balance if the pin is correct
            if (!LogIn(pPin))
            {
                return false; // pin is incorrect
            }

            if (pAmount < 0)
            {
                return false; // negative amounts are not allowed
            }
            
            lock (l)
            {
                _Balance += pAmount;
            }
            return true;
            
        }

       public  bool Withdraw(int pPin, double pAmount)
        {
            // withdraws from the balance if the pin is correct

            if (!LogIn(pPin))
            {
                return false; // pin is incorrect
            }


            if (_Balance - pAmount < 0)
            {
                return false; // insufficent funds
            }

            if (pAmount < 0)
            {
                return false; // negative amounts are not allowed
            }

            lock (l)
            {
               _Balance -= pAmount;
            }
            return true;
            
        }

        bool LogIn(int pPin)
        {
            return (pPin == _Pin);  // this example has a hard coded pin, normally it would be stored on a database
            
        }

        public string CardNumber
        {
            get
            {
                return _CardNumber;
            }
        }
    }
}
