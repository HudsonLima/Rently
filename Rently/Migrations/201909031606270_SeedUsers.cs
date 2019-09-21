namespace Rently.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'643c9ce7-2ae8-400b-bb5c-8359346c0321', N'hudsonlima.ti+admin@gmail.com', 0, N'AEsJUu0GcnoVJEFXf2ZEZCGqXc/UVS+DpdPczj5eOgdx+hgIccgY+4Tx3AoaGAXbYg==', N'b2434c06-41ac-48b8-ad7f-f7a9c932af9b', NULL, 0, 0, NULL, 1, 0, N'hudsonlima.ti+admin@gmail.com')
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'9bf7150c-fd02-4af4-ac83-b83d57864a69', N'hudsonlima.ti@gmail.com', 0, N'APGnqFW52wawKWoMLsMRkvVUS1giZOpTkYUda2JMuBmCMDwRPWXHz6IhnVwPqHyp7Q==', N'7e4a11da-d2cd-478f-8809-117512a56e87', NULL, 0, 0, NULL, 1, 0, N'hudsonlima.ti@gmail.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2f182ce1-685c-4666-96b6-3f51a7f799bd', N'CanManageMovie')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'643c9ce7-2ae8-400b-bb5c-8359346c0321', N'2f182ce1-685c-4666-96b6-3f51a7f799bd')       
                ");
        }
        
        public override void Down()
        {
        }
    }
}
