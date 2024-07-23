using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("a242e957-9877-497f-8887-33796b9588fe"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("af49c082-6ea1-4f4a-b35c-51a662b3a04e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0a5b553-c4ca-45cc-b5d9-73aaa2d84f28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edfd1244-77e2-4cdd-8ec5-ee17c60a73f3");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("097949a7-87a3-4a7b-8fd3-a6e2c25a87bd"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ce8cd6f7-018f-484e-ba91-6bdbec56c7df"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "056986f9-4bab-40cd-bca2-043daf263071", 0, "754d6509-f92e-4be4-8f3e-182703fd3a63", "user1@example.com", false, "User1", "User1", false, null, null, null, null, null, false, "a26c5988-414f-45eb-9da9-b53e0b70a0ac", false, "User1" },
                    { "bd650ad3-e6f5-4819-ac8b-a81375930a9e", 0, "c539c063-66b4-495a-b0d2-d397385ed5f6", "user2@example.com", false, "User2", "User2", false, null, null, null, null, null, false, "cc5a4de5-2110-4595-99d0-48e9182c463f", false, "User2" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Url" },
                values: new object[,]
                {
                    { new Guid("dea0e1fe-8ada-496e-bd68-5e96576039c1"), new DateTime(2024, 7, 24, 3, 0, 19, 197, DateTimeKind.Local).AddTicks(5287), null, null, false, null, null, "https://example.com/image2.jpg" },
                    { new Guid("e7f8c002-2933-433e-8a1b-1e3bbe0c7649"), new DateTime(2024, 7, 24, 3, 0, 19, 197, DateTimeKind.Local).AddTicks(5271), null, null, false, null, null, "https://example.com/image1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("49936ddf-1e3b-414b-b175-cc68b6d7ac68"), "This is the content of the first blog post.", "User1", new DateTime(2024, 7, 24, 3, 0, 19, 197, DateTimeKind.Local).AddTicks(5541), null, null, new Guid("e7f8c002-2933-433e-8a1b-1e3bbe0c7649"), false, null, null, "First Blog Post", "056986f9-4bab-40cd-bca2-043daf263071" },
                    { new Guid("59ad0216-c6a5-4860-a311-b6c841300857"), "This is the content of the second blog post.", "User2", new DateTime(2024, 7, 24, 3, 0, 19, 197, DateTimeKind.Local).AddTicks(5550), null, null, new Guid("dea0e1fe-8ada-496e-bd68-5e96576039c1"), false, null, null, "Second Blog Post", "bd650ad3-e6f5-4819-ac8b-a81375930a9e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("49936ddf-1e3b-414b-b175-cc68b6d7ac68"));

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("59ad0216-c6a5-4860-a311-b6c841300857"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "056986f9-4bab-40cd-bca2-043daf263071");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd650ad3-e6f5-4819-ac8b-a81375930a9e");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("dea0e1fe-8ada-496e-bd68-5e96576039c1"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e7f8c002-2933-433e-8a1b-1e3bbe0c7649"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a0a5b553-c4ca-45cc-b5d9-73aaa2d84f28", 0, "cb59f1a4-cfaa-4a91-a90b-e57a02db5cdb", "user1@example.com", false, "User1", "User1", false, null, null, null, null, null, false, "6efc4780-9cc0-477d-aa94-1a582d28ce9e", false, "User1" },
                    { "edfd1244-77e2-4cdd-8ec5-ee17c60a73f3", 0, "3c4f4338-ff68-451c-8776-59f8a1fc2482", "user2@example.com", false, "User2", "User2", false, null, null, null, null, null, false, "05fb3e9b-c1f5-477a-b8e1-a644680f7c39", false, "User2" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Url" },
                values: new object[,]
                {
                    { new Guid("097949a7-87a3-4a7b-8fd3-a6e2c25a87bd"), new DateTime(2024, 7, 24, 2, 56, 4, 658, DateTimeKind.Local).AddTicks(1674), null, null, false, null, null, "https://example.com/image1.jpg" },
                    { new Guid("ce8cd6f7-018f-484e-ba91-6bdbec56c7df"), new DateTime(2024, 7, 24, 2, 56, 4, 658, DateTimeKind.Local).AddTicks(1692), null, null, false, null, null, "https://example.com/image2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("a242e957-9877-497f-8887-33796b9588fe"), "This is the content of the second blog post.", "User2", new DateTime(2024, 7, 24, 2, 56, 4, 658, DateTimeKind.Local).AddTicks(1981), null, null, new Guid("ce8cd6f7-018f-484e-ba91-6bdbec56c7df"), false, null, null, "Second Blog Post", "edfd1244-77e2-4cdd-8ec5-ee17c60a73f3" },
                    { new Guid("af49c082-6ea1-4f4a-b35c-51a662b3a04e"), "This is the content of the first blog post.", "User1", new DateTime(2024, 7, 24, 2, 56, 4, 658, DateTimeKind.Local).AddTicks(1976), null, null, new Guid("097949a7-87a3-4a7b-8fd3-a6e2c25a87bd"), false, null, null, "First Blog Post", "a0a5b553-c4ca-45cc-b5d9-73aaa2d84f28" }
                });
        }
    }
}
