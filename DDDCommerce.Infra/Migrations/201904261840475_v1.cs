namespace DDDCommerce.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(maxLength: 50),
                        Name_LastName = c.String(maxLength: 50),
                        Document = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Email_MailAddress = c.String(maxLength: 60),
                        Phone = c.String(maxLength: 14),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Customer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Product_Id = c.Guid(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 80),
                        Description = c.String(nullable: false, maxLength: 180),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        QuantityOnHand = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.OrderItem", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "Product_Id" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
