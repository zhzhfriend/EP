namespace EPManageWeb.Migrations
{

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EPManageWeb.Entities.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<EPManageWeb.Entities.EPDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EPManageWeb.Entities.EPDataContext context)
        {
            AddClothesTypes(context);
            AddUsers(context);
        }

        private void AddUsers(EPManageWeb.Entities.EPDataContext context)
        {
            if (context.Users.SingleOrDefault(t => t.UserName == "admin") == null)
            {
                context.Users.AddOrUpdate(new User() { Id = 1, UserName = "admin", Password = "admin", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now });
            }
        }

        private void AddClothesTypes(EPManageWeb.Entities.EPDataContext context)
        {
            if (context.ClothesTypes.Count(t => t.Name == "上装") == 0)
            {
                ClothesType c = new ClothesType() { Name = "上装" };

                List<ClothesPart> parts = new List<ClothesPart>();

                ClothesPart p = new ClothesPart() { Name = "品类", ClothType = c };
                List<ClothesPartType> partTypes = new List<ClothesPartType>();
                partTypes.Add(new ClothesPartType() { Name = "外套", ClothesPart = p });
                partTypes.Add(new ClothesPartType() { Name = "衬衫", ClothesPart = p });
                partTypes.Add(new ClothesPartType() { Name = "小衫", ClothesPart = p });
                partTypes.Add(new ClothesPartType() { Name = "风衣", ClothesPart = p });
                partTypes.Add(new ClothesPartType() { Name = "大衣", ClothesPart = p });
                partTypes.Add(new ClothesPartType() { Name = "棉衣/羽绒服", ClothesPart = p });
                p.PartTypes = partTypes;
                parts.Add(p);
                c.ClothesParts = parts;

                context.ClothesTypes.Add(c);
                
            }
        }
    }
}
