using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LABA.Models
{
    public class CalculatorViewModel
    {
        // Первый операнд
        [Required(ErrorMessage = "The first operand is required.")]
        public ushort FirstOperand { get; set; }

        // Оператор
        public string? Operator { get; set; }

        // Второй операнд
        [Range(1, 100, ErrorMessage = "The second operand must be between {1} and {2}.")]
        public ushort SecondOperand { get; set; }

        // Результат операции
        public decimal Result { get; set; }

        // Массив доступных операторов
        public string[] Operators { get; }

        public CalculatorViewModel()
        {
            // Инициализация массива доступных операторов
            Operators = new[] { "+", "-", "*", "/" };
        }
    }
}
