using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Diplom_Game.Steam_Aksana.Patrubeika.Services;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Interfaces
{
	public interface IOrderService
	{
		public void CreateOrder(Order order);

		//public void ProcessOrder(SteamCart cartItem, Order order);

    }
}
