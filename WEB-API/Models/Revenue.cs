using System;

namespace BangazonFinancialReportsAPI

{
    // Class: Revenue
    //Author: Liz Sanger
    public class Revenue
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int ProductCost { get; set; }

        public int ProductRevenue { get; set; }

        public string ProductSupplierState { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerAddress { get; set; }

        public int CustomerZipCode { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int TimesPurchased { get; set; }

        public int TotalRevenueGenerated { get; set; }
    }
}