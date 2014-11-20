namespace Case518.Demo.House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mod201411200959 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "City_Id", c => c.Int());
            CreateIndex("dbo.Houses", "City_Id");
            AddForeignKey("dbo.Houses", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "City_Id", "dbo.Cities");
            DropIndex("dbo.Houses", new[] { "City_Id" });
            DropColumn("dbo.Houses", "City_Id");
        }
    }
}
