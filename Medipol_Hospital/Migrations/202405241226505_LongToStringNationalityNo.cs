namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongToStringNationalityNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "nationalityNo", c => c.String());
            AlterColumn("dbo.Patinets", "nationalityNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patinets", "nationalityNo", c => c.Long(nullable: false));
            AlterColumn("dbo.Doctors", "nationalityNo", c => c.Long(nullable: false));
        }
    }
}
