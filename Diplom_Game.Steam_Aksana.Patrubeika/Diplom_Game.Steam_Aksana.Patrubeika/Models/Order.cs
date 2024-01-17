using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
	public class Order
	{
		//для хранения данных для оплаты
		[BindNever]
        public int OrderId { get; set; }

		[Display(Name = "Enter first name")]
		[Required(ErrorMessage = "Put your name, please")]
		public string FirstName { get; set; }

		[Display(Name = "Enter second name")]
		[Required(ErrorMessage = "Put your second name, please")]
		public string SecondName { get; set; }
		
        [Required(ErrorMessage = "Put your credit card number")]
        [DataType(DataType.CreditCard)]
        [StringLength(16)]
        public string CreditCartNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Put your second name, please")]
        public DateTime CreditCartDate { get; set; }

        [Required(ErrorMessage = "Put your second name, please")]
		[StringLength(3)]
        public string CreditCartCode { get; set; }

        [BindNever]
        public DateTime OrderDateTime { get; set; }

        [BindNever]
        public List<OrderDatail> OrderDetail { get; set; }
	}
}
