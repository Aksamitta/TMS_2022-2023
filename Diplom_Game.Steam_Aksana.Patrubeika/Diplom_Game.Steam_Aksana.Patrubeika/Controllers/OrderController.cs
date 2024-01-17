using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Interfaces;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Diplom_Game.Steam_Aksana.Patrubeika.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Controllers
{
	public class OrderController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly SteamCart _steamCart;
		private readonly IOrderService _orderService;

        public OrderController(ApplicationDbContext context, SteamCart steamCart, IOrderService orderService)
		{
			_context = context;
			_steamCart = steamCart;
			_orderService = orderService;
		}

		
		public IActionResult Checkout()
		{            
            return View();
        }

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			_steamCart.listShopItems = _steamCart.getSteamItem();
			
			if (_steamCart.listShopItems.Count() == 0)
			{
				ModelState.AddModelError("", "Your cart is empty!");
			}

			////не работает нормально
			if (ModelState.IsValid)
			{
				_orderService.CreateOrder(order);
				//_orderService.ProcessOrder(cartItem, order);
				////_steamCart.Clear();
				return RedirectToAction("Completed");
			}
            
            return View(order);
        }		

	}
}
