using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airbnbfinal.Models;
using Airbnbfinal.Data;
using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Airbnbfinal.ViewModel.Payment
{
    public class PayViewModel
    {

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$",ErrorMessage ="Credit Card number must have 16 digits")]
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Cvc { get; set; }
        public long Value { get; set; }

    }
}
