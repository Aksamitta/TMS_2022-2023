using System.ComponentModel.DataAnnotations;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
	public class OrderDatail
	{
		//для хранения данных заказа
		[Key]
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int GameId { get; set; }
		public double Price { get; set; }

		//public virtual OrderViewModel Order { get; set; }
		public virtual Game Game { get; set; }
		public virtual Order Order { get; set; }
	}
}
