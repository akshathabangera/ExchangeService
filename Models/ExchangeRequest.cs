using System.ComponentModel.DataAnnotations;

namespace ExchangeService.Models
{
    public class ExchangeRequest
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "InputCurrency must be exactly 3 characters!")]
        public string InputCurrency { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "OutputCurrency must be exactly 3 characters!")]
        public string OutputCurrency { get; set; }
    }
}
