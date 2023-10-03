using Micro_Service.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micro_Service.Data;
using Micro_Service.Data.DTO;
using Micro_Service.Model;
using Micro_Service.Data.Grid;
using Micro_Service.Data.QueryOptions;
using Micro_Service.Data.ViewModels;
using Micro_Service.Data.Options;

namespace Micro_Service.Controllers
{
   
    public class AccountController : Controller
    {

        private MicroUnitOfWork data { get; set; }


        public AccountController(Micro_ServiceContextDb ctx) => data = new MicroUnitOfWork(ctx);
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("RetrieveOneAccount")]
        public IActionResult RetriveOneAccount(int id)
        {
            var account = data.BankAccounts.Get(new QueryOptions<BankAccount>
            {

                Where = b => b.AccounNumer == id.ToString()

            }); ;

            return Ok(account);
        }

     //   {controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{Nurse}/{ContractType}
        [HttpPost("filteraccount")]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new BankAccountGridBuilder(HttpContext.Session);

            // clear or update filter route segment values. If update, get author data
            // from database so can add author name slug to author filter value.
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var care = data.BankAccounts.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, care);
            }

            // save route data back to session and redirect to Book/List action method,
            // passing dictionary of route segment values to build URL
            builder.SaveRouteSegments();
           
            return RedirectToAction("RetrieveAccounts", builder.CurrentRoute);
        }




        [HttpPost("WithDraw")]
        public IActionResult Withdraw( int AccountNumber, double WithdrawAmount)
        {
            double amount;

            BankAccount account = data.BankAccounts.Get(new QueryOptions<BankAccount>
            {

                Where = b => b.AccounNumer == AccountNumber.ToString()

            });

            amount = account.Balance;

            if (amount>WithdrawAmount)
            {

                account.Balance = amount - WithdrawAmount;


                data.BankAccounts.Update(account);


                data.BankAccounts.Save();
            }

            else
            {
                ViewData["Message"] = "Insufficient Amount";
                return Content("Insufficient Funds");
            }

            return Ok(account);
        }




        [HttpGet("RetrieveAccounts")]
        public IActionResult RetrieveAccounts(BankAccountGridDTO vals)
        {
            string defaultSort = nameof(BankAccount.AccountType);


            var builder = new BankAccountGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(BankAccount.AccountType));
            // builder.SaveRouteSegments();

            // create options for querying authors
            var options = new BankAccountQueryOptions
            {
                //Includes = "BookAuthors.Book",

                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };

         
            options.SortFilter(builder);
          

            var vm = new BankAccountViewModel
            {
                
                BankAccounts = data.BankAccounts.List(options),

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.BankAccounts.Count)
            };

            return Ok(vm);
        }

    }
}
