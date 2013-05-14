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
            AddClothType_ShangZhuang(context);
           // AddClothType_XiaZhuang(context);

            if (context.ClothesTypes.Count(t => t.Name == "��װ") == 0)
            {
                context.ClothesTypes.Add(new ClothesType()
                {
                    Name = "��װ",
                    Children = new List<ClothesType>
                    {
                        new ClothesType(){ Name="ȹ��"},
                        new ClothesType(){ Name="����"}
                    }
                });
            }

            if (context.ClothesTypes.Count(t => t.Name == "ë��") == 0)
            {
                context.ClothesTypes.Add(new ClothesType() { Name = "ë��" });
            }
        }

        private void AddClothType_ShangZhuang(EPManageWeb.Entities.EPDataContext context)
        {
            if (context.ClothesTypes.Count(t => t.Name == "��װ") == 0)
            {

                ClothesType c = new ClothesType() { Name = "��װ" };
                c.ClothesParts = new List<ClothesPart>();
                var p = new ClothesPart() { Name = "Ʒ��", ClothType = c };
                p.PartTypes = new List<ClothesPartType>();
                p.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "С��", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "����/���޷�", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "Ƥ��", ClothesPart = p });
                p.PartTypes.Add(new ClothesPartType() { Name = "����ȹ", ClothesPart = p });
                c.ClothesParts.Add(p);

                var p1 = new ClothesPart() { Name = "����", ClothType = c };
                p1.Children = new List<ClothesPart>();

                var p11 = new ClothesPart() { Name = "����", Parent = p1 };
                p11.PartTypes = new List<ClothesPartType>();
                p11.PartTypes.Add(new ClothesPartType() { Name = "H", ClothesPart = p11 });
                p11.PartTypes.Add(new ClothesPartType() { Name = "X", ClothesPart = p11 });
                p11.PartTypes.Add(new ClothesPartType() { Name = "A", ClothesPart = p11 });
                p11.PartTypes.Add(new ClothesPartType() { Name = "O", ClothesPart = p11 });
                p1.Children.Add(p11);

                var p12 = new ClothesPart() { Name = "���ɷ��", Parent = p1 };
                p12.PartTypes = new List<ClothesPartType>();
                p12.PartTypes.Add(new ClothesPartType() { Name = "����(B>105)", ClothesPart = p12 });
                p12.PartTypes.Add(new ClothesPartType() { Name = "�Ͽ���(B=95~105)", ClothesPart = p12 });
                p12.PartTypes.Add(new ClothesPartType() { Name = "����(B=84~95)", ClothesPart = p12 });
                p1.Children.Add(p12);

                var p13 = new ClothesPart() { Name = "Ƭ��", Parent = p1 };
                p13.PartTypes = new List<ClothesPartType>();
                p13.PartTypes.Add(new ClothesPartType() { Name = "2����", ClothesPart = p13 });
                p13.PartTypes.Add(new ClothesPartType() { Name = "3����", ClothesPart = p13 });
                p13.PartTypes.Add(new ClothesPartType() { Name = "4����", ClothesPart = p13 });
                p13.PartTypes.Add(new ClothesPartType() { Name = "�࿪��", ClothesPart = p13 });
                p1.Children.Add(p13);

                var p14 = new ClothesPart() { Name = "��������", Parent = p1 };
                p14.PartTypes = new List<ClothesPartType>();
                p14.PartTypes.Add(new ClothesPartType() { Name = "�ָ�", ClothesPart = p14 });
                p14.PartTypes.Add(new ClothesPartType() { Name = "ʡ��", ClothesPart = p14 });
                p14.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p14 });
                p14.PartTypes.Add(new ClothesPartType() { Name = "��ߡ", ClothesPart = p14 });
                p14.PartTypes.Add(new ClothesPartType() { Name = "Լ��", ClothesPart = p14 });
                p1.Children.Add(p14);

                c.ClothesParts.Add(p1);

                var p2 = new ClothesPart() { Name = "����", ClothType = c };
                p2.PartTypes = new List<ClothesPartType>();
                p2.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p2 });
                p2.PartTypes.Add(new ClothesPartType() { Name = "Բ��", ClothesPart = p2 });
                p2.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p2 });
                p2.PartTypes.Add(new ClothesPartType() { Name = "��ñ��", ClothesPart = p2 });
                p2.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p2 });
                c.ClothesParts.Add(p2);

                var p3 = new ClothesPart() { Name = "����", ClothType = c };
                p3.Children = new List<ClothesPart>();

                var p31 = new ClothesPart() { Name = "����", Parent = p3 };
                p31.PartTypes = new List<ClothesPartType>();
                p31.PartTypes.Add(new ClothesPartType() { Name = "װ��", ClothesPart = p31 });
                p31.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p31 });
                p31.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p31 });
                p31.PartTypes.Add(new ClothesPartType() { Name = "�����", ClothesPart = p31 });
                p3.Children.Add(p31);

                var p32 = new ClothesPart() { Name = "Ƭ��", Parent = p3 };
                p32.PartTypes = new List<ClothesPartType>();
                p32.PartTypes.Add(new ClothesPartType() { Name = "һƬ", ClothesPart = p32 });
                p32.PartTypes.Add(new ClothesPartType() { Name = "��Ƭ", ClothesPart = p32 });
                p32.PartTypes.Add(new ClothesPartType() { Name = "��Ƭ", ClothesPart = p32 });
                p3.Children.Add(p32);

                var p33 = new ClothesPart() { Name = "����", Parent = p3 };
                p33.PartTypes = new List<ClothesPartType>();
                p33.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p33 });
                p33.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p33 });
                p33.PartTypes.Add(new ClothesPartType() { Name = "�����", ClothesPart = p33 });
                p33.PartTypes.Add(new ClothesPartType() { Name = "�߷���", ClothesPart = p33 });
                p33.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p33 });
                p3.Children.Add(p33);

                var p34 = new ClothesPart() { Name = "��������", Parent = p3 };
                p34.PartTypes = new List<ClothesPartType>();
                p34.PartTypes.Add(new ClothesPartType() { Name = "ֱ����", ClothesPart = p34 });
                p34.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p34 });
                p34.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p34 });
                p34.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p34 });
                p34.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p34 });
                p34.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p34 });
                p34.PartTypes.Add(new ClothesPartType() { Name = "������", ClothesPart = p34 });
                p3.Children.Add(p34);

                c.ClothesParts.Add(p3);
                context.ClothesTypes.Add(c);

            }
        }

        //private void AddClothType_XiaZhuang(EPManageWeb.Entities.EPDataContext context)
        //{
        //    if (context.ClothesTypes.Count(t => t.Name == "��װ") == 0)
        //    {
        //        ClothesType c = new ClothesType() { Name = "��װ" };
        //        ClothesType d = new ClothesType() { Name = "ȹ��", Parent = c};

        //        d.ClothesParts = new List<ClothesPart>();
        //        var p1 = new ClothesPart() { Name = "ȹ��", ClothType = d };
        //        p1.Children = new List<ClothesPart>();


        //        var p11 = new ClothesPart() { Name = "����", Parent = p1 };
        //        p11.PartTypes = new List<ClothesPartType>();

        //        p11.PartTypes.Add(new ClothesPartType() { Name = "ֱ��ȹ", ClothesPart = p11 });
        //        p11.PartTypes.Add(new ClothesPartType() { Name = "A��ȹ", ClothesPart = p11 });
        //        p11.PartTypes.Add(new ClothesPartType() { Name = "����", ClothesPart = p11 });
        //        p11.Children = new List<ClothesPart>();
        //        p1.Children.Add(p11);

        //        d.ClothesParts.Add(p1);
        //        context.ClothesTypes.Add(c);

        //    }
        //}
    }
}
