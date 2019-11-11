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

            accounts.Add(new Account { CusomterId = 1, AccountNumber = 12345, Balance = 900000 });
            accounts.Add(new Account { CusomterId = 2, AccountNumber = 23456, Balance = 1000000 });
            accounts.Add(new Account { CusomterId = 3, AccountNumber = 34567, Balance = 500000 });
            accounts.Add(new Account { CusomterId = 1, AccountNumber = 45678, Balance = 4500000 });
        }
    }
}
