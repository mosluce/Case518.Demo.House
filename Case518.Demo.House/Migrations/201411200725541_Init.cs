namespace Case518.Demo.House.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Parking = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Ground = c.Int(nullable: false),
                        City_Id = c.Int(),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Region_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Houses", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Regions", "City_Id", "dbo.Cities");
            DropIndex("dbo.Houses", new[] { "Region_Id" });
            DropIndex("dbo.Houses", new[] { "City_Id" });
            DropIndex("dbo.Regions", new[] { "City_Id" });
            DropTable("dbo.Houses");
            DropTable("dbo.Regions");
            DropTable("dbo.Cities");
        }
    }
}
