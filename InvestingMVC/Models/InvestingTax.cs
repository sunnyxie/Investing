﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestingMVC.Models
{
    // The property Tax;
    [System.ComponentModel.DataAnnotations.Schema.Table("records")]
    public class InvestingTax
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }

        [Required]
        [StringLength(64)]
        public string name { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Schema.Column("commission", TypeName = "decimal")]
        public decimal commissionFee { get; set; }

        public int count { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime settleDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime tradeDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string comments { get; set; }

        //[NotMapped]
        [ForeignKey("Type")]
        public virtual TranType _type { get; set;}

        public InvestingTax ShallowCopy()
        {
            return (InvestingTax)this.MemberwiseClone();
        }

        public InvestingTax()
        {
        }

    }
}