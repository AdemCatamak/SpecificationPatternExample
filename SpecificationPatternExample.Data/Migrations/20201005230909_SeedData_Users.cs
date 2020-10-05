using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecificationPatternExample.Data.Migrations
{
    public partial class SeedData_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {1, "Savage Bentley", 149, 18});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {2, "Krista Hurst", 151, 65});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {3, "Atkins Moon", 154, 23});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {4, "Carpenter Schneider", 153, 44});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {5, "Melendez Patterson", 155, 56});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {6, "Mason Bryan", 157, 33});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {7, "Carney Clemons", 158, 25});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {8, "Whitfield Mcmahon", 160, 56});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {9, "Shelton Mclaughlin", 161, 59});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {10, "Cleveland Mckay", 163, 89});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {11, "Solis Nichols", 169, 21});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {12, "Karen Atkinson", 169, 38});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {13, "Jane Owen", 173, 44});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {14, "Lucinda Puckett", 177, 43});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {15, "Bonita Alston", 183, 32});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {16, "Jordan Stark", 186, 46});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {17, "Faulkner Ward", 188, 63});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {18, "Sheila Petersen", 191, 57});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {19, "Brown Larsen", 194, 45});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {20, "Conner Hart", 198, 87});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {21, "Carole Page", 200, 53});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {22, "Cassandra Wiggins", 201, 39});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {23, "Joanna Larson", 202, 76});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {24, "Beth Whitehead", 202, 57});
            migrationBuilder.InsertData("Users", new[] {"Id", "Name", "Height", "Age"}, new object[] {25, "Genevieve Burris", 205, 37});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Users", "Id", 1);
            migrationBuilder.DeleteData("Users", "Id", 2);
            migrationBuilder.DeleteData("Users", "Id", 3);
            migrationBuilder.DeleteData("Users", "Id", 4);
            migrationBuilder.DeleteData("Users", "Id", 5);
            migrationBuilder.DeleteData("Users", "Id", 6);
            migrationBuilder.DeleteData("Users", "Id", 7);
            migrationBuilder.DeleteData("Users", "Id", 8);
            migrationBuilder.DeleteData("Users", "Id", 9);
            migrationBuilder.DeleteData("Users", "Id", 10);
            migrationBuilder.DeleteData("Users", "Id", 11);
            migrationBuilder.DeleteData("Users", "Id", 12);
            migrationBuilder.DeleteData("Users", "Id", 13);
            migrationBuilder.DeleteData("Users", "Id", 14);
            migrationBuilder.DeleteData("Users", "Id", 15);
            migrationBuilder.DeleteData("Users", "Id", 16);
            migrationBuilder.DeleteData("Users", "Id", 17);
            migrationBuilder.DeleteData("Users", "Id", 18);
            migrationBuilder.DeleteData("Users", "Id", 19);
            migrationBuilder.DeleteData("Users", "Id", 20);
            migrationBuilder.DeleteData("Users", "Id", 21);
            migrationBuilder.DeleteData("Users", "Id", 22);
            migrationBuilder.DeleteData("Users", "Id", 23);
            migrationBuilder.DeleteData("Users", "Id", 24);
            migrationBuilder.DeleteData("Users", "Id", 25);
        }
    }
}