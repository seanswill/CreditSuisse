using System;
using CreditSuisse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCreditSuisse
{
    [TestClass]
    public class UnitTest_CashCard
    {
        [TestMethod]
        public void WithdrawMoney_FundsAvailable_Success()
        {
            CashCard card = new CashCard(100, "12345678");

            bool Success = card.Withdraw(1234,50);

            Assert.AreEqual(card.Balance(1234), 50);
        }

        [TestMethod]
        public void WithdrawMoney_NegativeAmount_Success()
        {
            CashCard card = new CashCard(100, "12345678");

            bool Success = card.Withdraw(1234, -50);

            Assert.AreEqual(card.Balance(1234), 100);
        }

        [TestMethod]
        public void WithdrawMoney_InvalidPin_Success()
        {
            CashCard card = new CashCard(100, "12345678");


            bool Success = card.Withdraw(1111, 50);

            Assert.AreEqual(card.Balance(1234), 100);
        }

        [TestMethod]
        public void WithdrawMoney_MultipleInstances_Success()
        {
            CashCard card1 = new CashCard(100, "12345678");
            CashCard card2 = new CashCard();

            bool Success = card1.Withdraw(1234, 20);
            Success = card2.Withdraw(1234, 10);

            Assert.AreEqual(card1.Balance(1234), 70);
            Assert.AreEqual(card2.Balance(1234), 70);
        }

        [TestMethod]
        public void WithdrawMoney_FundsNotAvailable_Failure()
        {
            CashCard card = new CashCard(100, "12345678");

            bool Success = card.Withdraw(1234, 150);

            Assert.AreEqual(card.Balance(1234), 100);
        }

        [TestMethod]
        public void TopupMoney_SingleTopUp_Success()
        {
            CashCard card = new CashCard(100, "12345678");

            bool Success = card.Topup(1234, 50);

            Assert.AreEqual(card.Balance(1234), 150);
        }

        [TestMethod]
        public void TopupMoney_DoubleTopUp_Success()
        {
            CashCard card = new CashCard(100, "12345678");

            bool Success = card.Topup(1234, 50);
            Success = card.Topup(1234, 25);

            Assert.AreEqual(card.Balance(1234), 175);
        }

        [TestMethod]
        public void TopupMoney_InvalidPin_Success()
        {
            CashCard card = new CashCard(100, "12345678");


            bool Success = card.Topup(1111, 50);

            Assert.AreEqual(card.Balance(1234), 100);
        }

        [TestMethod]
        public void TopupMoney_NegativeAmount_Success()
        {
            CashCard card = new CashCard(100, "12345678");


            bool Success = card.Topup(1234, -50);

            Assert.AreEqual(card.Balance(1234), 100);
        }

        [TestMethod]
        public void CardNumber_Get_Success()
        {
            CashCard card = new CashCard(100, "12345678");

            
            Assert.AreEqual(card.CardNumber, "12345678");
        }
    }
}
