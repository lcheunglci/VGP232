using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Week2
{
    [TestFixture]
    class AccountTest
    {
        Account account;

        [SetUp]
        public void Initialization()
        {
            account = new Account(100);
            // create a file
        }

        [TearDown]
        public void CleanUp()
        {
            account = new Account(100);
            // delete the file
        }


        [Test]
        public void CreatedAccount()
        {
            account = new Account(100);
            int expected = 100;
            
            int balance = account.GetBalance();

            Assert.AreEqual(expected, balance);
        }

        [TestCase(50, 50)]
        [TestCase(1000, 0)]
        [TestCase(100, 0)]
        public void WithdrawAccount(int withDrawAmount, int expected)
        {
            account = new Account(100);

            account.Withdraw(withDrawAmount);

            int balance = account.GetBalance();

            Assert.AreEqual(expected, balance);
        }

    }
}
