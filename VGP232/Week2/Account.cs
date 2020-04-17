using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    public class Account
    {
        private int balance;
        public Account(int amount)
        {
            balance = amount;
        }

        public void Withdraw(int amount)
        {
            if (balance < amount)
            {
                throw new Exception("No enough money");

            }
            else
            {
                balance -= amount;
            }
        }

        public int GetBalance()
        {
            return balance;
        }

    }
}
