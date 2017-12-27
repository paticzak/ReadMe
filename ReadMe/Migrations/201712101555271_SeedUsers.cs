namespace ReadMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'22bed428-a02e-48d3-9e3a-2f721aecd2ec', N'guest', N'ANbrJsTP79v9S4OgosHwHyjWPTdHaCY21jXXzMvJlvk0FnWtF23jBfifm2FZPfHh3w==', N'cdbb0fd4-0c7e-4933-aea6-7944c5d2f531', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'f1ea120d-3b44-4543-9bde-5d1f657c9cd2', N'admin', N'ANkmZoOOgr0msE8lNG2NhkwgyvMGPa7eq6Ecmnt1fdiluCeFHlloKKWLEMV1RYAWSA==', N'34caeefe-0c73-4123-aa85-02d5fa89e7f9', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'47ac109f-e82a-4add-aeb9-cd50ffaa7540', N'CanManageBooks')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f1ea120d-3b44-4543-9bde-5d1f657c9cd2', N'47ac109f-e82a-4add-aeb9-cd50ffaa7540')

");
        }
        
        public override void Down()
        {
            
        }
    }
}
