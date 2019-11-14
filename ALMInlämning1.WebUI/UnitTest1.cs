using ALMInlämning1.WebUI.Models;
using System;
using Xunit;

namespace ALMInlämning1.WebUI
{
    public class UnitTest1
    {
        [Fact]
        public void Withdraw()
        {
            //Arrange
            var account = new Account { Balance = 1000m, AccountNumber = 1};
            var amountToWithdraw = 200m;
            var repo = new BankRepository();
            var expected = 800m;

            //Act
            repo.Withdraw(account, amountToWithdraw);

            //Assert
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void Deposit()
        {
            //Arrange
            var account = new Account { Balance = 2000.25m, AccountNumber = 2 };
            var amountToDeposit = 300.25m;
            var repo = new BankRepository();
            var expected = 2300.5m;

            //Act
            repo.Deposit(account, amountToDeposit);

            //Assert
            Assert.Equal(expected, account.Balance);
        }

        [Fact]
        public void ShouldntBeAbleToWithdrawMoreThanAccountBalance()
        {
            //Arrange
            var account = new Account { Balance = 2000.25m, AccountNumber = 3 };
            var amountToWithdraw = 2500m;
            var repo = new BankRepository();

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => repo.Withdraw(account, amountToWithdraw));
        }

        [Fact]
        public void Transfer()
        {
            //Arrange
            var sendingAccount = new Account { Balance = 20m, AccountNumber = 3 };
            var recievingAccount = new Account { Balance = 0m, AccountNumber = 4 };
            var amountToTransfer = 20m;
            var expectedAmountSender = 0m;

            //Act
            sendingAccount.Transfer(amountToTransfer, recievingAccount);
            var actualAmountSender = sendingAccount.Balance;
            var actualAmountReciever = recievingAccount.Balance;

            //Assert sender balance
            Assert.Equal(expectedAmountSender, actualAmountSender);
            //Assert sender reciever
            Assert.Equal(actualAmountReciever, amountToTransfer);
        }

        [Fact]
        public void TransferExceeded()
        {
            //Arrange
            var sendingAccount = new Account { Balance = 20m, AccountNumber = 3 };
            var recievingAccount = new Account { Balance = 0m, AccountNumber = 4 };
            var amountToTransfer = 30m;

            //Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sendingAccount.Transfer(amountToTransfer, recievingAccount));
        }
    }
}
