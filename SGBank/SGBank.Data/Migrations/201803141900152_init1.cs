namespace SGBank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Name", c => c.String());
        }
    }
}
