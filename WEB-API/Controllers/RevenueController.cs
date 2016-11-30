using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BangazonFinancialReportsAPI

{
    [Produces("application/json")]
    public class RevenueController : Controller
    {

        private BangazonContext context;

        Revenue testRevenue = new Revenue
        {
            ProductName = "Tough Luck",
            ProductCost = 5,
        };



        public RevenueController(BangazonContext ctx)
        {
            context = ctx;
        }


        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var BangazonRevenue = context.Revenue;
            IQueryable<Revenue> AllRevenue = from revenue in BangazonRevenue select revenue;

            // if (AllRevenue == null)
            // {
            //     return NotFound(); //produces a 404 response
            // }
            // // 
            return Ok(AllRevenue); //http response of status 200 and return to client

        }

        //       public IActionResult ProdRevenue()
        //         {
        //             IQueryable<object> ProdsRevenue = from revenue in context.Revenue 
        //             group revenue by revenue.ProductName;
        //             // select new {revenue.ProductName, revenue.ProductCost};

        //             if (ProdsRevenue == null)
        //             {
        //                 return NotFound(); //produces a 404 response
        //             }
        // // 
        //             return Ok(ProdsRevenue); //http response of status 200 and return to client

        //         }

        [HttpGet]
        public async Task<IActionResult> ProductRevenue()
        {


            var BangazonRevenue = context.Revenue;


            //group revenue items by ProductName to avoid duplicates
            var ProductGrouper = from revenue in BangazonRevenue
                                 group revenue by revenue.ProductName into groupedRevenueProductNames
                                 where groupedRevenueProductNames.Count() >= 1
                                 orderby groupedRevenueProductNames
                                 select new { groupedRevenueProductNames.Key };



            var RevenueGrouper = from revenue in BangazonRevenue
                                 group revenue by revenue.ProductCost into groupedRevenueProductCosts
                                 where groupedRevenueProductCosts.Count() >= 1
                                 orderby Convert.ToInt32(groupedRevenueProductCosts)
                                 select new { groupedRevenueProductCosts.Key };

            // foreach(var p in ProductGrouper) {
            //     Console.WriteLine(p);
            // }
            // Get line items grouped by product id, including count

            // Build list of Product instances for display in view
            // model.ProductTypes = await (from type in context.ProductType
            //         join a in counter on type.ProductTypeId equals a.Key 
            //         select new ProductType {
            //             ProductTypeId = type.ProductTypeId,
            //             Label = type.Label, 
            //             Quantity = a.myCount 
            //         }).ToListAsync();



            return Ok(RevenueGrouper);
        }










        [HttpGet("{id}", Name = "GetIndividualRevenue")]
            public async Task<IActionResult> Index([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

          
            // Set the `Product` property of the view model
            Revenue AllRevenue = await context.Revenue
                
                    .SingleOrDefaultAsync(prod => prod.Id == id);

            // If product not found, return 404
            if (AllRevenue == null)
            {
                return NotFound();
            }

            return Ok(AllRevenue); 
        }
    }
}




// // from Revenue

//                 // IQueryable<string> ProductNames = from revenue in context.Revenue select revenue.ProductName;
//                 // IQueryable<int>ProductCosts = from revenue in context.Revenue select revenue.ProductCost;
//             // .Include(x => x.ProductRevenue)
//             //     .OrderBy(x => x.ProductRevenue)

//                 // Dictionary <string, int> ProdsRevenue = new Dictionary<string, int>();
//                 // ProdsRevenue.Add(ProductNames.ToString(), Convert.ToInt32(ProductCosts));
// foreach (var entry in ProdsRevenue) {
//     ProductsDictionary.Add(entry.ProductName, entry.ProductCost);
// }
// @"Select Revenue.ProductName,
//             sum(Revenue.ProductRevenue) 
//             from Revenue
//             group by Revenue.ProductName
//             order by sum(Revenue.ProductRevenue) desc", 
// List<KeyValuePair<string, int>>ProductsKVPairList = new List<KeyValuePair<string, int>>();
// Dictionary<string, int>ProductsDictionary = new Dictionary<string, int>();