namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setToTcNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patinets", "birthYear", c => c.Int(nullable: false));
            DropColumn("dbo.Patinets", "birthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patinets", "birthDate", c => c.Int(nullable: false));
            DropColumn("dbo.Patinets", "birthYear");
        }
    }
}
