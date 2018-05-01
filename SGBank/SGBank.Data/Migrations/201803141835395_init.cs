namespace SGBank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        Customer_CustomerID = c.Int(nullable: false),
                        Account_AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerID, t.Account_AccountID })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountID, cascadeDelete: true)
                .Index(t => t.Customer_CustomerID)
                .Index(t => t.Account_AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAccounts", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.CustomerAccounts", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerAccounts", new[] { "Account_AccountID" });
            DropIndex("dbo.CustomerAccounts", new[] { "Customer_CustomerID" });
            DropTable("dbo.CustomerAccounts");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
