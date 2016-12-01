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
        // public async Task<IActionResult> ProductRevenue()
        // {
        //     try
        //     {

        //         var BangazonRevenue = context.Revenue;
        //         List<string> AllProductNames = new List<string>();
        //         List<int> AllProductCosts = new List<int>();
        //          List<int> TotalTimesPurchased = new List<int>();
        //         Dictionary<string, int> ProductRevenueDictionary = new Dictionary<string, int>();

        //         //group revenue items by ProductName to avoid duplicates, returns an anonymous collection of strings (groupedProductNames.Key) and ints (#of times product was purchased)

        //         var ProdsGrouper = from revenue in BangazonRevenue
        //                            group revenue by revenue.ProductName into groupedProductNames
        //                            where groupedProductNames.Count() > 1
        //                            select new { groupedProductNames.Key, timesPurchased = groupedProductNames.Count() };



        //         //put all product names in anonymous collection into a list

        //         foreach (var prodName in ProdsGrouper)
        //         {
        //             AllProductNames.Add(prodName.Key.ToString());
        //         }

        //         //put all product timespurchase in anonymous collection into a list

        //         foreach(var prodTimesPurchased in ProdsGrouper) {
        //             TotalTimesPurchased.Add(Convert.ToInt32(prodTimesPurchased));

        //         }

        //         //returns each individual product cost, without duplicates
        //         var RevenueGrouper = from revenue in BangazonRevenue
        //                              group revenue by revenue.ProductCost into groupedRevenueProductCosts
        //                              where groupedRevenueProductCosts.Count() >= 1
        //                              select new { groupedRevenueProductCosts.Key };

        //         //put all product costs in anonymous collection into a list, converted to int

        //         foreach (var prodCost in RevenueGrouper)
        //         {
        //             AllProductCosts.Add(Convert.ToInt32(prodCost));

        //         }

        //         List<Revenue> SortedRevenue = new List<Revenue>();
        //         //grab all revenue 
        //         var AllRevenue = from revenue in BangazonRevenue select revenue;
        //         //nested foreach, goes through an assigns the "times purchase Property to the revenue item in question if that times purchased is greater than 1
        //         foreach (var prodName in AllProductNames) 
        //         {
        //             foreach (var rev in AllRevenue) 
        //             {
        //             foreach (var times in TotalTimesPurchased)
        //             {

                    
                    
        //                     //if the product appears on the ProductNamesList and is therefore a duplicate, add it to the collection of SortedRevenue items{
        //                     if(prodName == rev.ProductName ) {
        //                         rev.TimesPurchased = times;
        //                         SortedRevenue.Add(rev);
        //                     }
        //                 }
        //             }
        //         }

               
                


        //         return Ok(SortedRevenue);
        //     }


            // catch (Exception ex)
            // {
            //     return NotFound();
            // }
        // }






        [HttpGet("{id}", Name = "GetIndividualRevenue")]
        public async Task<IActionResult> Index([FromRoute]int? id)
        {

            try
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
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}



