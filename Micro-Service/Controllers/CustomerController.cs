using Micro_Service.Data;
using Micro_Service.Data.DTO;
using Micro_Service.Data.Grid;
using Micro_Service.Data.Options;
using Micro_Service.Data.QueryOptions;
using Micro_Service.Data.Repository;
using Micro_Service.Model;
using Micro_Service.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro_Service.Controllers
{
    public class CustomerController : Controller
    {

        private MicroUnitOfWork data { get; set; }


        public CustomerController(Micro_ServiceContextDb ctx) => data = new MicroUnitOfWork(ctx);

        [HttpGet("RetrieveClients")]
        public IActionResult RetrieveClients(ClientGridDTO vals)
        {
            string defaultSort = nameof(Clients.BankAccounts);


            var builder = new ClientGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Clients.BankAccounts));
            // builder.SaveRouteSegments();

            // create options for querying authors
            var options = new ClientQueryOptions
            {
                //Includes = "BookAuthors.Book",

                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };


            options.SortFilter(builder);


            var vm = new ClientViewModel
            {

                Customers = data.Client.List(options),

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Client.Count)
            };

            return Ok(vm);
        }

        [HttpPost("RetriveOneCustomer")]
        public IActionResult RetrieveOneCustomer(int id)
        {
            var customer = data.Client.Get(new QueryOptions<Clients>
            {

                Where = b => b.CLientID == id

            }); ;

            return Ok(customer);
        }
    }
}
