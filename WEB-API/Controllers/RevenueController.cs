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


        public RevenueController(BangazonContext ctx)
        {
            context = ctx;
        }


        [HttpGet]

        public IActionResult Index()
        {
            IQueryable<Revenue> AllRevenue = from revenue in context.Revenue select revenue;

            if (AllRevenue == null)
            {
                return NotFound(); //produces a 404 response
            }
// 
            return Ok(AllRevenue); //http response of status 200 and return to client

        }


        [HttpGet]
        public IActionResult ProductRevenue()
        {

            Revenue testRevenue = new Revenue {
                ProductName = "Tough Luck",
                ProductCost = 5,
            };

            var BangazonRevenue = context.Revenue;

            try
            {
                var ProdsRevenue =
                from revenue in BangazonRevenue
                
                select new {revenue.ProductCost, revenue.ProductName};

            
        
                // orderby t.ProductCost
                // orderby ProductNames
                

          
// from Revenue
    
//             group by Revenue.ProductName
//             order by sum(Revenue.ProductRevenue) desc",  
    
                // IQueryable<string> ProductNames = from revenue in context.Revenue select revenue.ProductName;
                // IQueryable<int>ProductCosts = from revenue in context.Revenue select revenue.ProductCost;
            // .Include(x => x.ProductRevenue)
            //     .OrderBy(x => x.ProductRevenue)
                
                // Dictionary <string, int> ProdsRevenue = new Dictionary<string, int>();
                // ProdsRevenue.Add(ProductNames.ToString(), Convert.ToInt32(ProductCosts));

                if (ProdsRevenue == null)
                {
                    return NotFound();
                }

                return Ok(ProdsRevenue);
            }

            catch (System.InvalidOperationException ex)
            {
                return NotFound();

            }
        }
          
      [HttpGet("{id}", Name = "GetIndividualRevenue")]
        public IActionResult Index([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Revenue revenue = context.Revenue.Single(m => m.Id == id);

                if (revenue == null)
                {
                    return NotFound();
                }
                
                return Ok(revenue);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }
    }
}
