using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALMInlämning1.WebUI.Models
{
    public class Account
    {
        public int CusomterId { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public void Transfer(decimal amountToTransfer, Account recievingAccount)
        {
            if(amountToTransfer > 0 && Balance >= amountToTransfer)
            {
                var repo = new BankRepository();
                repo.Withdraw(this, amountToTransfer);
                repo.Deposit(recievingAccount, amountToTransfer);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
