using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
	public class Order
	{
		//для хранения данных для оплаты
		[Key]
		[BindNever]
        public int OrderId { get; set; }

		[Display(Name = "Enter first name")]
		[Required(ErrorMessage = "Put your name, please")]
		public string FirstName { get; set; }

		[Display(Name = "Enter second name")]
		[Required(ErrorMessage = "Put your second name, please")]
		public string SecondName { get; set; }

		[DataType(DataType.CreditCard)]
        [Required(ErrorMessage = "Put your credit card number")]
        //[StringLength(16)]
        public string CreditCartNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Put your second name, please")]
        //[DisplayFormat(DataFormatString = "{MM.YY}", ApplyFormatInEditMode = true)]
        public DateTime CreditCartDate { get; set; }

        [Required(ErrorMessage = "Put your second name, please")]
		//[StringLength(3)]
        public int CreditCartCode { get; set; }

        [BindNever]
        public DateTime OrderDateTime { get; set; }

        [BindNever]
        public List<OrderDatail> OrderDetail { get; set; }
	}
}
