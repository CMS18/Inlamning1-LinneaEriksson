using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMInlämning1.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALMInlämning1.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankRepository _repo;

        public AccountController(BankRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(int accountNumber, decimal amount)
        {
            var account = _repo.accounts.Where(c => c.AccountNumber == accountNumber).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Withdraw(account, amount);
                    TempData["info"] = "The new balance on the account is " + account.Balance + " sek";
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["info"] = "You cant withdraw a higher amount than is available, try a smaller amount.";
                }
            }
            else
            {
                TempData["info"] = "The account dont exist.";

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deposit(int accountNumber, decimal amount)
        {
            var account = _repo.accounts.Where(c => c.AccountNumber == accountNumber).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Deposit(account, amount);
                    TempData["info"] = "The new balance on the account is " + account.Balance + " sek.";
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["info"] = "The deposit must be higher than zero.";
                }
            }
            else
            {
                TempData["info"] = "The account dont exist.";

            }
            return RedirectToAction("Index");

        }

        //När man skriver i ett korrekt kontonummer och belopp och trycker på knappen ska respektive 
        //metod för insättning eller uttag på Bank-klassen anropas.
        //Om något blir fel ska ett relevant felmeddelande visas, annars ska det nya saldot efter insättning eller uttag visas.
    }
}
