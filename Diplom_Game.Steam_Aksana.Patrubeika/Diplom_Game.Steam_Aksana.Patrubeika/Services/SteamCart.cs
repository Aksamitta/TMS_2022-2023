using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Migrations;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Microsoft.EntityFrameworkCore;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Services
{
    public class SteamCart
    {
        //класс описывает корзину
        public string SteamCartId { get; set; }

        public List<SteamCartItem> listShopItems { get; set; }

        private readonly ApplicationDbContext _context;

        public SteamCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public static SteamCart GetCart(IServiceProvider services)
        {
            //создаем новую сессию
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            //передаем индификатор сессии, если его нет, то создаем новый через гуид
            string steamCartId = session.GetString("Cart") ?? Guid.NewGuid().ToString();

            session.SetString("Cart", steamCartId);

            return new SteamCart(context) { SteamCartId = steamCartId };
        }

        public void AddToCart(Game game)
        {
            _context.SteamCartItems.Add(new SteamCartItem
            {
                SteamCartId = SteamCartId,
                Game = game,
                Price = game.Price
            });
            _context.SaveChanges();
        }

        //отображаем все товары в корзине
        public List<SteamCartItem> getSteamItem()
        {
            return _context.SteamCartItems.Where(x => x.SteamCartId == SteamCartId).Include(x => x.Game).ToList();
        }
    }
}
