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
                    Name = "����",
                    ClothesParts = new List<ClothesPart>
                    {
                        new ClothesPart(){ Id=1, Name="Ʒ��",
                            PartTypes=new List<ClothesPartType>
                            {
                                new ClothesPartType(){Id=1, Name="����", Order=1},
                                new ClothesPartType(){Id=2, Name="����", Order=2},
                                new ClothesPartType(){Id=3, Name="С��", Order=3},
                                new ClothesPartType(){Id=4, Name="����", Order=4},
                                new ClothesPartType(){Id=5, Name="����", Order=5},
                                new ClothesPartType(){Id=6, Name="����/���޷�", Order=6},
                            },
                             CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                        new ClothesPart(){Id=2, Name="����",
                             Children=new List<ClothesPart>
                             {
                                new ClothesPart(){Id=5, Name="����", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=6, Name="���ɷ��", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=7, Name="Ƭ��", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=8, Name="��������", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now}
                             },
                            CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                        new ClothesPart(){Id=3, Name="����",
                            Children=new List<ClothesPart>
                             {
                                new ClothesPart(){Id=9, Name="����", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=10, Name="Ƭ��", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=11, Name="����", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                                new ClothesPart(){Id=12, Name="��������", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now}
                             },
                             CreateDT=DateTime.Now, ModifiedDT=DateTime.Now},
                        new ClothesPart(){Id=4, Name="����", CreateDT=DateTime.Now, ModifiedDT=DateTime.Now}
                    },
                    CreateDT = DateTime.Now,
                    ModifiedDT = DateTime.Now
                },
                new ClothesType()
                {
                    Id = 2,
                    Name = "��װ",
                    Children = new List<ClothesType>()
                        {
                            new ClothesType() {Id=4, Name = "����", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now },
                            new ClothesType() {Id=5, Name = "ȹ��", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now }
                        },
                    CreateDT = DateTime.Now,
                    ModifiedDT = DateTime.Now
                },
                new ClothesType() { Id = 3, Name = "ë��", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now }
            );

            context.Users.AddOrUpdate(new User() { Id = 1, UserName = "admin", Password = "admin", CreateDT = DateTime.Now, ModifiedDT = DateTime.Now });
        }
    }
}
