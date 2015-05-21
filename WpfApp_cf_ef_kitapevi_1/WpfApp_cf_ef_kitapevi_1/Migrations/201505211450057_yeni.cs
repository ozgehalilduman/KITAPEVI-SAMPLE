namespace WpfApp_cf_ef_kitapevi_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kitaps",
                c => new
                    {
                        kitapID = c.Int(nullable: false, identity: true),
                        kitapad = c.String(nullable: false),
                        kitapyazar = c.String(nullable: false),
                        kitapbasimyili = c.Int(nullable: false),
                        kitapsayfasayisi = c.Int(nullable: false),
                        kitapstok = c.Int(nullable: false),
                        kitaptur_kitapturID = c.Int(),
                        uye_uyeID = c.Int(),
                    })
                .PrimaryKey(t => t.kitapID)
                .ForeignKey("dbo.kitapturs", t => t.kitaptur_kitapturID)
                .ForeignKey("dbo.uyes", t => t.uye_uyeID)
                .Index(t => t.kitaptur_kitapturID)
                .Index(t => t.uye_uyeID);
            
            CreateTable(
                "dbo.kitapturs",
                c => new
                    {
                        kitapturID = c.Int(nullable: false, identity: true),
                        kitapturisim = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.kitapturID);
            
            CreateTable(
                "dbo.uyes",
                c => new
                    {
                        uyeID = c.Int(nullable: false, identity: true),
                        uyead = c.String(nullable: false),
                        uyesoyad = c.String(nullable: false),
                        uyemail = c.String(nullable: false),
                        uyetel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.uyeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.kitaps", "uye_uyeID", "dbo.uyes");
            DropForeignKey("dbo.kitaps", "kitaptur_kitapturID", "dbo.kitapturs");
            DropIndex("dbo.kitaps", new[] { "uye_uyeID" });
            DropIndex("dbo.kitaps", new[] { "kitaptur_kitapturID" });
            DropTable("dbo.uyes");
            DropTable("dbo.kitapturs");
            DropTable("dbo.kitaps");
        }
    }
}
