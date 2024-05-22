namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnTcNoInPatientsTablo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patinets", "nationalityNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patinets", "nationalityNo");
        }
    }
}
