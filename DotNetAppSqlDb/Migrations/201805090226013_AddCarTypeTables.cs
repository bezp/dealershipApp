namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarTypeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        MSRP = c.Int(nullable: false),
                        Horsepower = c.Int(nullable: false),
                        MPG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Crossovers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        MSRP = c.Int(nullable: false),
                        Horsepower = c.Int(nullable: false),
                        MPG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sedans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        MSRP = c.Int(nullable: false),
                        Horsepower = c.Int(nullable: false),
                        MPG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sedans");
            DropTable("dbo.Crossovers");
            DropTable("dbo.Compacts");
        }
    }
}
