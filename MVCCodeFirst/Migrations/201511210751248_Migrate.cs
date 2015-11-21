namespace MVCCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriNo = c.String(),
                        BaslangicTarih = c.DateTime(nullable: false),
                        BitisTarih = c.DateTime(nullable: false),
                        Neden = c.String(),
                        Enlem = c.String(),
                        Boylam = c.String(),
                        Aciklama = c.String(),
                        EtkiledigiAlanlar = c.String(),
                        Kaynak = c.String(),
                        AfetTuru_Id = c.Int(),
                        Ilce_Id = c.Int(),
                        Sehir_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AfetTurs", t => t.AfetTuru_Id)
                .ForeignKey("dbo.Ilces", t => t.Ilce_Id)
                .ForeignKey("dbo.Sehirs", t => t.Sehir_Id)
                .Index(t => t.AfetTuru_Id)
                .Index(t => t.Ilce_Id)
                .Index(t => t.Sehir_Id);
            
            CreateTable(
                "dbo.AfetResims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.Binary(),
                        Afet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Afets", t => t.Afet_Id)
                .Index(t => t.Afet_Id);
            
            CreateTable(
                "dbo.AfetTurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ilces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sehir_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sehirs", t => t.Sehir_Id)
                .Index(t => t.Sehir_Id);
            
            CreateTable(
                "dbo.Sehirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Afets", "Sehir_Id", "dbo.Sehirs");
            DropForeignKey("dbo.Afets", "Ilce_Id", "dbo.Ilces");
            DropForeignKey("dbo.Ilces", "Sehir_Id", "dbo.Sehirs");
            DropForeignKey("dbo.Afets", "AfetTuru_Id", "dbo.AfetTurs");
            DropForeignKey("dbo.AfetResims", "Afet_Id", "dbo.Afets");
            DropIndex("dbo.Ilces", new[] { "Sehir_Id" });
            DropIndex("dbo.AfetResims", new[] { "Afet_Id" });
            DropIndex("dbo.Afets", new[] { "Sehir_Id" });
            DropIndex("dbo.Afets", new[] { "Ilce_Id" });
            DropIndex("dbo.Afets", new[] { "AfetTuru_Id" });
            DropTable("dbo.Sehirs");
            DropTable("dbo.Ilces");
            DropTable("dbo.AfetTurs");
            DropTable("dbo.AfetResims");
            DropTable("dbo.Afets");
        }
    }
}
