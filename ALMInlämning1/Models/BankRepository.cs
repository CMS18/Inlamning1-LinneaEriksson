using ALMInlämning1.WebUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ALMInlämning1.WebUI.Models
{
    public class BankRepository
    {
        public List<Customer> customers { get; set; } = new List<Customer>();
        public List<Account> accounts { get; set; } = new List<Account>();

        public BankRepository()
        {
            customers.Add(new Customer { CusomterId = 1, FirstName = "Hans", LastName = "Svensson", Address = "Ringvägen 3" });
            customers.Add(new Customer { CusomterId = 2, FirstName = "Lars", LastName = "Lunden", Address = "Hamngatan 6" });
            customers.Add(new Customer { CusomterId = 3, FirstName = "Greta", LastName = "Kvast", Address = "Solstigen 54" });

            accounts.Add(new Account { CusomterId = 1, AccountNumber = 1, Balance = 90m });
            accounts.Add(new Account { CusomterId = 2, AccountNumber = 2, Balance = 100m });
            accounts.Add(new Account { CusomterId = 3, AccountNumber = 3, Balance = 500m });
            accounts.Add(new Account { CusomterId = 1, AccountNumber = 4, Balance = 4500m });
        }

        public void Withdraw(Account account, decimal amountToWithdraw)
        {
            if (account.Balance >= amountToWithdraw && amountToWithdraw>0)
            {
                account.Balance -= amountToWithdraw;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Deposit(Account account, decimal amountToDeposit)
        {
            if (0 < amountToDeposit)
            {
                account.Balance += amountToDeposit;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
