using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuckySpin.ViewModels
{
    public class IndexViewModel
    {
        public string FirstName { get; set; }

        [Display(Prompt = " Starting Balance $3 to $10")]
        public Decimal StartingBalance { get; set; }
        [Range(1, 9, ErrorMessage = "Choose a number")]
        public int Luck { get; set; }
    }
}
