namespace web.artimeagallery.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arvixe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artists", "Exhibition_Id", "dbo.Exhibitions");
            DropIndex("dbo.Artists", new[] { "Exhibition_Id" });
            CreateTable(
                "dbo.MailingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExhibitionArtists",
                c => new
                    {
                        Exhibition_Id = c.Int(nullable: false),
                        Artist_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exhibition_Id, t.Artist_Id })
                .ForeignKey("dbo.Exhibitions", t => t.Exhibition_Id, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .Index(t => t.Exhibition_Id)
                .Index(t => t.Artist_Id);
            
            AddColumn("dbo.Artists", "Enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artworks", "Size", c => c.String());
            AddColumn("dbo.Artworks", "Material", c => c.String());
            AddColumn("dbo.Artworks", "ForSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artworks", "WhenCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.BusinessInformations", "Name", c => c.String());
            AddColumn("dbo.BusinessInformations", "AddressLine1", c => c.String());
            AddColumn("dbo.BusinessInformations", "AddressLine2", c => c.String());
            AddColumn("dbo.BusinessInformations", "Town", c => c.String());
            AddColumn("dbo.BusinessInformations", "PostCode", c => c.String());
            AddColumn("dbo.BusinessInformations", "Email", c => c.String());
            AddColumn("dbo.BusinessInformations", "Telephone", c => c.String());
            AddColumn("dbo.BusinessInformations", "About", c => c.String());
            AddColumn("dbo.BusinessInformations", "Latitude", c => c.String());
            AddColumn("dbo.BusinessInformations", "Longitude", c => c.String());
            AddColumn("dbo.Exhibitions", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Exhibitions", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Exhibitions", "Details", c => c.String());
            AddColumn("dbo.Exhibitions", "OpeningTimes", c => c.String());
            AlterColumn("dbo.Artworks", "Bytes", c => c.Binary());
            AlterColumn("dbo.Artworks", "ResizedBytes", c => c.Binary());
            DropColumn("dbo.Artists", "Exhibition_Id");
            DropColumn("dbo.Exhibitions", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exhibitions", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Artists", "Exhibition_Id", c => c.Int());
            DropForeignKey("dbo.ExhibitionArtists", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.ExhibitionArtists", "Exhibition_Id", "dbo.Exhibitions");
            DropIndex("dbo.ExhibitionArtists", new[] { "Artist_Id" });
            DropIndex("dbo.ExhibitionArtists", new[] { "Exhibition_Id" });
            AlterColumn("dbo.Artworks", "ResizedBytes", c => c.Byte(nullable: false));
            AlterColumn("dbo.Artworks", "Bytes", c => c.Byte(nullable: false));
            DropColumn("dbo.Exhibitions", "OpeningTimes");
            DropColumn("dbo.Exhibitions", "Details");
            DropColumn("dbo.Exhibitions", "EndDate");
            DropColumn("dbo.Exhibitions", "StartDate");
            DropColumn("dbo.BusinessInformations", "Longitude");
            DropColumn("dbo.BusinessInformations", "Latitude");
            DropColumn("dbo.BusinessInformations", "About");
            DropColumn("dbo.BusinessInformations", "Telephone");
            DropColumn("dbo.BusinessInformations", "Email");
            DropColumn("dbo.BusinessInformations", "PostCode");
            DropColumn("dbo.BusinessInformations", "Town");
            DropColumn("dbo.BusinessInformations", "AddressLine2");
            DropColumn("dbo.BusinessInformations", "AddressLine1");
            DropColumn("dbo.BusinessInformations", "Name");
            DropColumn("dbo.Artworks", "WhenCreated");
            DropColumn("dbo.Artworks", "ForSale");
            DropColumn("dbo.Artworks", "Material");
            DropColumn("dbo.Artworks", "Size");
            DropColumn("dbo.Artists", "Enabled");
            DropTable("dbo.ExhibitionArtists");
            DropTable("dbo.MailingLists");
            CreateIndex("dbo.Artists", "Exhibition_Id");
            AddForeignKey("dbo.Artists", "Exhibition_Id", "dbo.Exhibitions", "Id");
        }
    }
}
