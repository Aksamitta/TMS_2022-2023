using Diplom_Game.Steam_Aksana.Patrubeika.Migrations;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Diplom_Game.Steam_Aksana.Patrubeika.Services;
using Diplom_Game.Steam_Aksana.Patrubeika.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace Diplom_Game.Steam_Aksana.Patrubeika.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<UserLevel> UserLevels { get; set; }

        public virtual DbSet<Developer> Developers { get; set; }

        public virtual DbSet<SteamCartItem> SteamCartItems { get; set; }

		public virtual DbSet<Order> Orders { get; set; }

		public virtual DbSet<OrderDatail> OrderDatails { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Developer>().HasData(
                new Developer() { DeveloperId = 1, DeveloperName = "Nomada Studio", DeveloperSummary = "Devolver Digital recommends only the most exquisite video games for the distinguished gamer and their refined taste. Voted 'Best Video Game Label Ever' 2016, 2017, 2021.." },
                new Developer() { DeveloperId = 2, DeveloperName = "Quantic Dream", DeveloperSummary = "Quantic Dream is an award-winning French video game developer and publisher founded to create AAA games with a focus on emotional, interactive storytelling and innovation in narrative." },
                new Developer() { DeveloperId = 3, DeveloperName = "Playdead", DeveloperSummary = "Playdead is an independent game developer and publisher based in Copenhagen, Denmark. We are hard at work on bringing LIMBO and INSIDE to more players - and on making new games." },
                new Developer() { DeveloperId = 4, DeveloperName = "Annapurna Interactive", DeveloperSummary = "Established in 2016, Annapurna Interactive works with game creators from around the world, helping them create and release personal experiences for everyone." }
                );
           
           builder.Entity<Game>().HasData(
                new Game() 
                { 
                    GameId = 1,                    
                    GameName = "INSIDE", DeveloperId = 3, 
                    Img = "/img/INSIDE.jpg",
                    ReleaseDate = new DateTime(2016, 07, 07), 
                    Summary = "Hunted and alone, a boy finds himself drawn into the center of a dark project. INSIDE is a dark, narrative-driven platformer combining intense action with challenging puzzles. It has been critically acclaimed for its moody art style, ambient soundtrack and unsettling atmosphere.",
                    Genre = "Platformer", 
                    Reviews = "Overwhelmingly Positive", 
                    Price = 10.49 },
                new Game()
                {
                    GameId = 2,
                    GameName = "LIMBO",
                    Img = "/img/LIMBO.jpg",
                    DeveloperId = 3,
                    ReleaseDate = new DateTime(2011, 08, 02),
                    Summary = "Uncertain of his sister's fate, a boy enters LIMBO",
                    Genre = "Platformer",
                    Reviews = "Very Positive",
                    Price = 6.29 },
                new Game()
                {
                    GameId = 3,
                    GameName = "Detroit: Become Human",
                    Img = "/img/DETROIT.jpg",
                    DeveloperId = 2,
                    ReleaseDate = new DateTime(2020, 06, 18),
                    Summary = "Detroit: Become Human puts the destiny of both mankind and androids in your hands, taking you to a near future where machines have become more intelligent than humans. Every choice you make affects the outcome of the game, with one of the most intricately branching narratives ever created.",
                    Genre = "Adventure",
                    Reviews = "Overwhelmingly Positive",
                    Price = 19.99 },
                new Game()
                {
                    GameId = 4,
                    GameName = "Stray",
                    Img = "/img/STRAY.png",
                    DeveloperId = 4,
                    ReleaseDate = new DateTime(2022, 07, 19),
                    Summary = "Lost, alone and separated from family, a stray cat must untangle an ancient mystery to escape a long-forgotten cybercity and find their way home.",
                    Genre = "Adventure",
                    Reviews = "Overwhelmingly Positive",
                    Price = 15.99},
                new Game()
                {
                    GameId = 5,
                    GameName = "Gris",
                    Img = "/img/Gris.jpg",
                    DeveloperId = 1,
                    ReleaseDate = new DateTime(2018, 12, 13),
                    Summary = "Gris is a hopeful young girl lost in her own world, dealing with a painful experience in her life. Her journey through sorrow is manifested in her dress, which grants new abilities to better navigate her faded reality.",
                    Genre = "Adventure",
                    Reviews = "Overwhelmingly Positive",
                    Price = 9.49}

                );

            builder.Entity<UserLevel>().HasData(
                new UserLevel() { UserLevelId = 1, LevelName = "Admin" },
                new UserLevel() { UserLevelId = 2, LevelName = "Advanced" },
                new UserLevel() { UserLevelId = 3, LevelName = "Middle" },
                new UserLevel() { UserLevelId = 4, LevelName = "Junior" }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=USER-PC;Initial Catalog=Game_Steam;Integrated Security=True;TrustServerCertificate=True");
    }
}