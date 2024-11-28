namespace surfs_up_project.Models
{
    public class Board : Product
    {
        public double Length { get; set; }

        public double Width { get; set; }

        public double Thickness { get; set; }

        public double Volume { get; set; }

        public string Type { get; set; }


        public Board(string name, string imagePath, double length, double width, double thickness, double volume, string type, double price) : base(name, imagePath, price)
        {
            Length = length;
            Width = width;
            Thickness = thickness;
            Volume = volume;
            Type = type;
        }
    }



    /*
     dotnet ef migrations insert InitialCreate ??????
     dotnet ef migrations add InitialCreate
     dotnet ef database update

     */
    /*
     
     
                        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "Products",
           columns: new[] { "ProductId", "Name", "ImagePath", "Length", "Width", "Thickness", "Volume", "Type", "Price" },
           values: new object[,]
           {
                    { 100, "Surfboard A", "path/to/imageA.jpg", 6.0, 20.5, 2.75, 35.0, "Shortboard", 599.99 },
                    { 200, "Surfboard B", "path/to/imageB.jpg", 7.0, 21.0, 2.85, 40.0, "Funboard", 649.99 },

           });
        }

                STANDARD TIL AT INDSÆTTE DATA
                    
                 migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "ImagePath", "Length", "Width", "Thickness", "Volume", "Type", "Price" },
                values: new object[,]
                {
                    { 1, "Surfboard A", "path/to/imageA.jpg", 6.0, 20.5, 2.75, 35.0, "Shortboard", 599.99 },
                    { 2, "Surfboard B", "path/to/imageB.jpg", 7.0, 21.0, 2.85, 40.0, "Funboard", 649.99 },
                    
                });

                          migrationBuilder.CreateTable(
                          name: "Customer",
                          columns: table => new
                          {
                              CustomerId = table.Column<int>(type: "int", nullable: false)
                                  .Annotation("SqlServer:Identity", "1, 1"),
                              FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                              LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                              Email = table.Column<double>(type: "nvarchar(max)", nullable: false),
                              PhoneNumber = table.Column<double>(type: "float", nullable: false),
                              Adress = table.Column<double>(type: "nvarchar(max)", nullable: false),
                              Zipcode = table.Column<double>(type: "float", nullable: false),
                              City = table.Column<string>(type: "nvarchar(max)", nullable: false),

                          },
                          constraints: table =>
                          {
                              table.PrimaryKey("PK_Customer", x => x.CustomerId);
                          });
     */

}