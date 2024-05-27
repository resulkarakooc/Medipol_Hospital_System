namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Email", c => c.String());
            AddColumn("dbo.Patinets", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patinets", "Email");
            DropColumn("dbo.Doctors", "Email");
        }
    }
}
