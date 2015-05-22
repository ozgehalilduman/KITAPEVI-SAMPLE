namespace WpfApp_cf_ef_kitapevi_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni_iliski : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.kitaps", "uye_uyeID", "dbo.uyes");
            DropIndex("dbo.kitaps", new[] { "uye_uyeID" });
            CreateTable(
                "dbo.uyekitaps",
                c => new
                    {
                        uye_uyeID = c.Int(nullable: false),
                        kitap_kitapID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.uye_uyeID, t.kitap_kitapID })
                .ForeignKey("dbo.uyes", t => t.uye_uyeID, cascadeDelete: true)
                .ForeignKey("dbo.kitaps", t => t.kitap_kitapID, cascadeDelete: true)
                .Index(t => t.uye_uyeID)
                .Index(t => t.kitap_kitapID);
            
            DropColumn("dbo.kitaps", "uye_uyeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.kitaps", "uye_uyeID", c => c.Int());
            DropForeignKey("dbo.uyekitaps", "kitap_kitapID", "dbo.kitaps");
            DropForeignKey("dbo.uyekitaps", "uye_uyeID", "dbo.uyes");
            DropIndex("dbo.uyekitaps", new[] { "kitap_kitapID" });
            DropIndex("dbo.uyekitaps", new[] { "uye_uyeID" });
            DropTable("dbo.uyekitaps");
            CreateIndex("dbo.kitaps", "uye_uyeID");
            AddForeignKey("dbo.kitaps", "uye_uyeID", "dbo.uyes", "uyeID");
        }
    }
}
