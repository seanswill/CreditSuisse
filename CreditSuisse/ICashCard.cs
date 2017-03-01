using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse
{
    interface ICashCard
    {
        bool Withdraw(int pPin,double pAmount);

        double Balance(int pPin);

        bool Topup(int pPin, double pAmount);

        string CardNumber { get; }
    }
}
