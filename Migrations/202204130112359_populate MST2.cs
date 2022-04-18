namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMST2 : DbMigration
    {
        public override void Up()
        {
            
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you Go' WHERE MembershipTypeId=1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE MembershipTypeId=2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE MembershipTypeId=3");
            Sql("UPDATE MembershipTypes SET Name = 'Annualy' WHERE MembershipTypeId=4");
        }
        
        public override void Down()
        {
        }
    }
}
