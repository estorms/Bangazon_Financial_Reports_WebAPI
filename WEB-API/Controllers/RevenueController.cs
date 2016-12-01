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
            // var BangazonRevenue = context.Revenue;
            IQueryable<Revenue> AllRevenue = from revenue in context.Revenue select revenue;

            // if (AllRevenue == null)
            // {
            //     return NotFound(); //produces a 404 response
            // }
            // // 
            return Ok(AllRevenue); //http response of status 200 and return to client

        }

   

        [HttpGet]
        public async Task<IActionResult> ProductRevenue()
        {
            try
            {

                var BangazonRevenue = context.Revenue;
                List<string>AllProductNames = new List<string>();
                List<int>AllProductCosts = new List<int>();
                Dictionary<string, int> ProductRevenueDictionary = new Dictionary<string, int>();

                //group revenue items by ProductName to avoid duplicates, returns an anonymous collection of strings and ints


                var ProdsGrouper = from revenue in BangazonRevenue
                                   group revenue by revenue.ProductName into groupedProductNames
                                   where groupedProductNames.Count() >= 1
                                   select new { groupedProductNames.Key, myCount = groupedProductNames.Count() };
                
                //put all product names in anonymous collection into a list
                
                foreach(var prodName in ProdsGrouper) {
                    AllProductNames.Add(prodName.Key.ToString());
                }


                //returns each individual product cost, without duplicates
                var RevenueGrouper = from revenue in BangazonRevenue
                                     group revenue by revenue.ProductCost into groupedRevenueProductCosts
                                     where groupedRevenueProductCosts.Count() >= 1
                                     select new { groupedRevenueProductCosts.Key };

                 //put all product costs in anonymous collection into a list, converted to int

                foreach(var prodCost in RevenueGrouper) {
                    AllProductCosts.Add(Convert.ToInt32(prodCost));

                }

                //grab all revenue 
            var AllRevenue = from revenue in BangazonRevenue select revenue;
                // IQueryable<int>ProductCosts = from revenue in BangazonRevenue select revenue.ProductCost;

                // var totalRev;

           

                //now, need to iterate over each revenue item in all revenue

                // foreach (var rev in AllRevenue) {
                //     foreach(var prodCost in AllProductCosts ) {
                //         foreach(var prodName in AllProductNames) {
                //             if (rev.ProductName == prodName && rev.ProductCost == prodCost) {
                //                  var totalRev = prodCost * rev.ProductCost;
                //                  ProductRevenueDictionary.Add(rev.ProductName, totalRev);
                //             }
                //         }
                //     }
                    
                // }


                return Ok(testRevenue);
            }


            catch (Exception ex)
            {
                return NotFound();
            }
        }






        [HttpGet("{id}", Name = "GetIndividualRevenue")]
        public async Task<IActionResult> Index([FromRoute]int? id)
        {

            try {
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
        catch (Exception ex) {
            return NotFound();
        }
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
//  var ProductGrouper = from revenue in BangazonRevenue
//                       group revenue by revenue.ProductName into groupedRevenueProductNames
//                       where groupedRevenueProductNames.Count() >= 1
//                       select new { groupedRevenueProductNames.Key };

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


// Dictionary<string, int>ProductsDictionary = new Dictionary<string, int>();

                // foreach (var revenue in AllRevenue)
                // {
                //     foreach (var prodName in ProdsGrouper)
                //     {
                //         if (revenue.ProductName == prodName.Key)
                //         {
                //             AllProductNames.Add(revenue.ProductName);
                //         }
                //     }
                // }

                // foreach (var revenue in AllRevenue) 
                // {
                //     foreach (var revAmt in RevenueGrouper) {
                //         if (revenue.ProductCost == revAmt.Key) {
                //             AllProductCosts.Add(revenue.ProductCost);
                //         }
                //     }
                // }
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