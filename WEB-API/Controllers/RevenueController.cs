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
    [Route("[controller]")]
    public class RevenueController : Controller
    {

        private BangazonContext context;


        public RevenueController(BangazonContext ctx)
        {
            context = ctx;
        }


        [HttpGet]

        public IActionResult Get()
        {
            IQueryable<Revenue> AllRevenue = from revenue in context.Revenue select revenue;

            if (AllRevenue == null)
            {
                return NotFound(); //produces a 404 response
            }
// 
            return Ok(AllRevenue); //http response of status 200 and return to client

        }

        // [HttpGet]
        // public IActionResult GetRevenueByProduct()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
      

        //     try
        //     {
        //         IQueryable<object> ProductRevenue = from revenue in context.Revenue.Include(x =>x.ProductCost).Include(x => x.ProductRevenue)
        //         .OrderBy(x => x.ProductRevenue) select revenue;
            

        //         if (ProductRevenue == null)
        //         {
        //             return NotFound();
        //         }

        //         return Ok(ProductRevenue);
        //     }
        //     catch (System.InvalidOperationException ex)
        //     {
        //         return NotFound();
        //     }
        // }

    //         [HttpGet]
    //     public IActionResult GetRevenueByCustomer()
    //     {
    //         if (!ModelState.IsValid)
    //         {
    //             return BadRequest(ModelState);
    //         }

    //         try
    //         {
    //             Revenue revenue = context.Revenue.Single(m => m.ProductId == id);

    //             if (revenue == null)
    //             {
    //                 return NotFound();
    //             }

    //             return Ok(revenue);
    //         }
    //         catch (System.InvalidOperationException ex)
    //         {
    //             return NotFound();
    //         }
    //     }
    }
}
