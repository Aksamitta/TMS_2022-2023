using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Migrations;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
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

        public IActionResult addToCart(int id)
        {
            //SteamCart cart = ShopCart();
            //cart.AddToCart(GameInCart.Where(x => x.GameId == id).FirstOrDefault());
            //SaveCart(cart);
            var item = _context.Games.FirstOrDefault(x => x.GameId == id);
            if (item != null)
            {
                _steamCart.AddToCart(item);
            }
            //переадресовка в корзину после добавления
            return View("PlaceOrder");
        }

        public IActionResult DeleteItem(int id)
        {
            _steamCart.DeleteFromCart(id);
            return RedirectToAction("Index");
        }

        //public IActionResult SaveCart(SteamCart cart)
        //{
        //    HttpContext.Session.SetJson<SteamCart>("Cart", cart);
        //    return RedirectToAction(nameof(ShopCart));
        //}

        //public SteamCart ShopCart()
        //{
        //    SteamCart cart = HttpContext.Session.GetJson<SteamCart>("Cart") ?? new SteamCart();
        //    return cart;
        //}


    }

}
