using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FB.Migrations
{
    /// <inheritdoc />
    public partial class secondpartv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PulishDate",
                table: "BlogPosts",
                newName: "PublishedDate");

            migrationBuilder.RenameColumn(
                name: "FeaturedTitle",
                table: "BlogPosts",
                newName: "FeaturedImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "BlogPosts",
                newName: "PulishDate");

            migrationBuilder.RenameColumn(
                name: "FeaturedImageUrl",
                table: "BlogPosts",
                newName: "FeaturedTitle");
        }
    }
}
