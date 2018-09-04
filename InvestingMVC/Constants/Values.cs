using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestingMVC.Constants
{
    public class Values
    {

           public static Dictionary<int, string> TypeList = 
            new Dictionary<int, string> { { 1, "Buy" },
                                          { 2, "Sell" },
                                          { 3, "Divident" },
                                          { 4, "Cash Contribute" }
                };

        public const int MaxWaitingDays = 2;

        public const int DefBuyingCount = 200;

        public const double DefCommissionFee= 6.95;

        public const string AlphaAPIKey = "SNTHLFL54B25V1WX";
    }
}