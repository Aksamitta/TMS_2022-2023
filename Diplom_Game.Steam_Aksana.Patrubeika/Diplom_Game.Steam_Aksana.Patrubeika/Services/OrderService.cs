using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Interfaces;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Services
{   
    public class OrderService : IOrderService
	{       
        private readonly ApplicationDbContext _context;
		private readonly SteamCart _steamCart;

		public OrderService(ApplicationDbContext context, SteamCart steamCart)
		{
			_context = context;
			_steamCart = steamCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderDateTime= DateTime.Now;
			_context.Orders.Add(order);

			var items = _steamCart.listShopItems;

			foreach ( var item in items ) 
			{
				var orderDetail = new OrderDatail()
				{
					GameId = item.Game.GameId,
					OrderId = order.OrderId,
					Price= item.Price,
				};
				_context.OrderDatails.Add(orderDetail);
			}
			_context.SaveChanges();
		}

        //public void ProcessOrder(SteamCart cartItem, Order order)
        //{
        //        StringBuilder body = new StringBuilder()
        //            .AppendLine("Новый заказ обработан")
        //            .AppendLine("---")
        //            .AppendLine("Товары:");

        //        foreach (var line in cartItem.listShopItems)
        //        {
        //            var subtotal = line.Game.Price;
        //            body.AppendFormat("{0} x {1} (итого: {2:c}",
        //                line.Price, line.Game.GameName, subtotal);
        //        }              
        //}
    }
}
