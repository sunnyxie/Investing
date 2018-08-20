using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestingMVC.Models
{
	[System.ComponentModel.DataAnnotations.Schema.Table("investing.trantype")]
    public class TranType
    {
        public int id { get; set; }

        public string name { get; set; }

        //public double Score { get; set; }
    }
}