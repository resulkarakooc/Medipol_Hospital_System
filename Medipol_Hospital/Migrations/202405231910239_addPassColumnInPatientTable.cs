namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPassColumnInPatientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patinets", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patinets", "Password");
        }
    }
}
