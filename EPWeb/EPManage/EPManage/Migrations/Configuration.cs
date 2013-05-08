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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EPManageWeb.Entities.EPDataContext context)
        {
            context.ClothesTypes.AddOrUpdate(
                new ClothesType()
                {
                    Id = 1,
                    Name = "上衣",
                    ClothesParts = new List<ClothesPart>
                    {
                        new ClothesPart(){ Id=1, Name="品类",
                            PartTypes=new List<ClothesPartType>
                            {
                                new ClothesPartType(){Id=1, Name="外套", Order=1},
                                new ClothesPartType(){Id=2, Name="衬衫", Order=2},
                                new ClothesPartType(){Id=3, Name="小衫", Order=3},
                                new ClothesPartType(){Id=4, Name="风衣", Order=4},
                                new ClothesPartType(){Id=5, Name="大衣", Order=5},
                                new ClothesPartType(){Id=6, Name="棉衣/羽绒服", Order=6},
                            },
                             CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                        new ClothesPart(){Id=2, Name="衣身",
                             Children=new List<ClothesPart>
                             {
                                new ClothesPart(){Id=5, Name="廓型", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=6, Name="宽松风格", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=7, Name="片数", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=8, Name="造型特征", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now}
                             },
                            CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                        new ClothesPart(){Id=3, Name="领型",
                            Children=new List<ClothesPart>
                             {
                                new ClothesPart(){Id=9, Name="袖型", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=10, Name="片数", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=11, Name="长度", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=12, Name="造型特征", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now}
                             },
                             CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                        new ClothesPart(){Id=4, Name="衣袖", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now}
                    },
                    CreateDT = DateTime.Now,
                    ModifiedDT = DateTime.Now
                },
                new ClothesType()
                {
                    Id = 2,
                    Name = "下装",
                    Children = new List<ClothesType>()
                        {
                            new ClothesType() {Id=4, Name = "裤子", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now },
                            new ClothesType() {Id=5, Name = "裙子", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now }
                        },
                    CreateDT = DateTime.Now,
                    ModifiedDT = DateTime.Now
                },
                new ClothesType() { Id = 3, Name = "毛衫", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now }
            );

            context.Users.AddOrUpdate(new User() { Id = 1, UserName = "admin", Password = "admin", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now });
        }
    }
}
