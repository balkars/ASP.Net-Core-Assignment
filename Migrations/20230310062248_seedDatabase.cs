using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSales.Migrations
{
    /// <inheritdoc />
    public partial class seedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT into Makes (Name) VALUES ('make1')");
            migrationBuilder.Sql("INSERT into Makes (Name) VALUES ('make2')");
            migrationBuilder.Sql("INSERT into Makes (Name) VALUES ('make3')");

            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make1-ModelA'," +
                " (SELECT ID FROM Makes WHERE Name = 'make1'))");
            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make1-ModelB', " +
                "(SELECT ID FROM Makes WHERE Name = 'make1'))");
            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make1-ModelC', " +
                "(SELECT ID FROM Makes WHERE Name = 'make1'))");

            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make2-ModelA', " +
                "(SELECT ID FROM Makes WHERE Name = 'make2'))");
            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make2-ModelB'," +
                " (SELECT ID FROM Makes WHERE Name = 'make2'))");
            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make2-ModelC'," +
                " (SELECT ID FROM Makes WHERE Name = 'make2'))");

            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make3-ModelA', " +
                "(SELECT ID FROM Makes WHERE Name = 'make3'))");
            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make3-ModelB'," +
                " (SELECT ID FROM Makes WHERE Name = 'make3'))");
            migrationBuilder.Sql("INSERT into Models(Name, MakeId) VALUES('Make3-ModelC'," +
                " (SELECT ID FROM Makes WHERE Name = 'make3'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
            migrationBuilder.Sql("DELETE FROM Models");
        }
    }
}
