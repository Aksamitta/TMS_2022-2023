﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom_Game.Steam_Aksana.Patrubeika.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

        //    migrationBuilder.CreateTable(
        //        name: "Developers",
        //        columns: table => new
        //        {
        //            DeveloperId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DeveloperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DeveloperType = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Developers", x => x.DeveloperId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserLevels",
        //        columns: table => new
        //        {
        //            UserLevelId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_UserLevels", x => x.UserLevelId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetRoleClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "AspNetRoles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Games",
        //        columns: table => new
        //        {
        //            GameId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DeveloperId = table.Column<int>(type: "int", nullable: false),
        //            ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            Reviews = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Games", x => x.GameId);
        //            table.ForeignKey(
        //                name: "FK_Games_Developers_DeveloperId",
        //                column: x => x.DeveloperId,
        //                principalTable: "Developers",
        //                principalColumn: "DeveloperId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUsers",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            SteamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //            SteamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Age = table.Column<int>(type: "int", nullable: true),
        //            Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            LevelId = table.Column<int>(type: "int", nullable: true),
        //            GameId = table.Column<int>(type: "int", nullable: true),
        //            Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UserLevelId = table.Column<int>(type: "int", nullable: false),
        //            UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
        //            EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //            PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
        //            TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
        //            LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //            LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
        //            AccessFailedCount = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUsers", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetUsers_Games_GameId",
        //                column: x => x.GameId,
        //                principalTable: "Games",
        //                principalColumn: "GameId");
        //            table.ForeignKey(
        //                name: "FK_AspNetUsers_UserLevels_UserLevelId",
        //                column: x => x.UserLevelId,
        //                principalTable: "UserLevels",
        //                principalColumn: "UserLevelId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserLogins",
        //        columns: table => new
        //        {
        //            LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserRoles",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "AspNetRoles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserTokens",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
        //            Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetRoleClaims_RoleId",
        //        table: "AspNetRoleClaims",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles",
        //        column: "NormalizedName",
        //        unique: true,
        //        filter: "[NormalizedName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserClaims_UserId",
        //        table: "AspNetUserClaims",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserLogins_UserId",
        //        table: "AspNetUserLogins",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserRoles_RoleId",
        //        table: "AspNetUserRoles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "EmailIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedEmail");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUsers_GameId",
        //        table: "AspNetUsers",
        //        column: "GameId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUsers_UserLevelId",
        //        table: "AspNetUsers",
        //        column: "UserLevelId");

        //    migrationBuilder.CreateIndex(
        //        name: "UserNameIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedUserName",
        //        unique: true,
        //        filter: "[NormalizedUserName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Games_DeveloperId",
        //        table: "Games",
        //        column: "DeveloperId");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "AspNetRoleClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserLogins");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserTokens");

        //    migrationBuilder.DropTable(
        //        name: "AspNetRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUsers");

        //    migrationBuilder.DropTable(
        //        name: "Games");

        //    migrationBuilder.DropTable(
        //        name: "UserLevels");

        //    migrationBuilder.DropTable(
        //        name: "Developers");
        }
    }
}
