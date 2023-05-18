using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Migrations;
using Diplom_Game.Steam_Aksana.Patrubeika.Services;
using Diplom_Game.Steam_Aksana.Patrubeika.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;


namespace Diplom_Game.Steam_Aksana.Patrubeika.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SteamCart _steamCart;

        public CartController(ApplicationDbContext context, SteamCart steamCart)
        {            
            _context = context;
            _steamCart = steamCart;
        }

        public ViewResult Index()
        {
            var items = _steamCart.getSteamItem();
            _steamCart.listShopItems = items;
            var obj = new SteamCartViewModel { CartItem = _steamCart };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _context.Games.FirstOrDefault(x => x.GameId == id);
            if (item != null)
            {
                _steamCart.AddToCart(item);
            }
            //переадресовка в корзину после добавления
            return RedirectToAction("Index");
        }

    }
}
