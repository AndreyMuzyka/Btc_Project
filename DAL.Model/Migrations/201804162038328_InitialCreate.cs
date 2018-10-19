namespace DAL.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bittrexes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarketName = c.String(),
                        BaseVolume = c.Single(nullable: false),
                        Bid = c.Single(nullable: false),
                        Ask = c.Single(nullable: false),
                        Created = c.DateTime(nullable: false),
                        MarketType_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MarketTypes", t => t.MarketType_Id)
                .Index(t => t.MarketType_Id);
            
            CreateTable(
                "dbo.MarketTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bittrexes", "MarketType_Id", "dbo.MarketTypes");
            DropIndex("dbo.Bittrexes", new[] { "MarketType_Id" });
            DropTable("dbo.MarketTypes");
            DropTable("dbo.Bittrexes");
        }
    }
}
