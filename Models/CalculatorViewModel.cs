using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LABA.Models
{
    public class CalculatorViewModel
    {
        [Required(ErrorMessage = "The first operand is required.")]
        public ushort FirstOperand { get; set; }

        public string? Operator { get; set; }

        [Range(1, 100, ErrorMessage = "The second operand must be between {1} and {2}.")]
        public ushort SecondOperand { get; set; }

        public decimal Result { get; set; }
        public string[] Operators { get; }

        public CalculatorViewModel()
        {
            Operators = new[] { "+", "-", "*", "/" };
        }
    }
}
