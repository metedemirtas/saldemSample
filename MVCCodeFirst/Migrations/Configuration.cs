namespace MVCCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVCCodeFirst.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCCodeFirst.Context.SaldemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCCodeFirst.Context.SaldemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.AfetTur.AddOrUpdate(
              p => p.Name,
              new AfetTur { Id = 1, Name = "Afet Tür 1" },
              new AfetTur { Id = 2, Name = "Afet Tür 2" },
              new AfetTur { Id = 3, Name = "Afet Tür 3" }
            );

            context.Sehir.AddOrUpdate(
              p => p.Name,
              new Sehir { Name = "Adana" },
              new Sehir { Name = "Adýyaman" },
              new Sehir { Name = "AfyonKarahisar" },
             new Sehir { Name = "Aðrý" },
              new Sehir { Name = "Amasya" },
              new Sehir { Name = "Ankara" }
            );

            context.SaveChanges();

            Sehir Adana = context.Sehir.FirstOrDefault(a=>  a.Name == "Adana");
            Sehir Adiyaman = context.Sehir.FirstOrDefault(a => a.Name == "Adýyaman");
            Sehir AfyonKarahisar = context.Sehir.FirstOrDefault(a => a.Name == "AfyonKarahisar");
            Sehir Agri = context.Sehir.FirstOrDefault(a => a.Name == "Aðrý");
            Sehir Amasya = context.Sehir.FirstOrDefault(a => a.Name == "Amasya");
            Sehir Ankara = context.Sehir.FirstOrDefault(a => a.Name == "Ankara");

            if (context.Ilce.FirstOrDefault(a => a.Sehir != null && a.Sehir.Name == "Adana") == null)
            {
                context.Ilce.AddOrUpdate(new Ilce { Name = "Merkez", Sehir = Adana });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Seyhan", Sehir = Adana });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Yüreðir", Sehir = Adana });
            }

            if (context.Ilce.FirstOrDefault(a => a.Sehir != null && a.Sehir.Name == "Adýyaman") == null)
            {

                context.Ilce.AddOrUpdate(new Ilce { Name = "Merkez", Sehir = Adiyaman });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Besni", Sehir = Adiyaman });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Çelikhan", Sehir = Adiyaman });
            }

            if (context.Ilce.FirstOrDefault(a => a.Sehir != null && a.Sehir.Name == "AfyonKarahisar") == null)
            {
                context.Ilce.AddOrUpdate(new Ilce { Name = "Merkez", Sehir = AfyonKarahisar });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Baþmakçý", Sehir = AfyonKarahisar });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Bayat", Sehir = AfyonKarahisar });
            }

            if (context.Ilce.FirstOrDefault(a => a.Sehir != null && a.Sehir.Name == "Aðrý") == null)
            {
                context.Ilce.AddOrUpdate(new Ilce { Name = "Merkez", Sehir = Agri });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Diyadin", Sehir = Agri });
                context.Ilce.AddOrUpdate(new Ilce { Name = "DoðuBeyazýt", Sehir = Agri });
            }
            if (context.Ilce.FirstOrDefault(a => a.Sehir != null && a.Sehir.Name == "Amasya") == null)
            {

                context.Ilce.AddOrUpdate(new Ilce { Name = "Merkez", Sehir = Amasya });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Göynücek", Sehir = Amasya });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Gümüþhacýköy", Sehir = Amasya });
            }

            if (context.Ilce.FirstOrDefault(a => a.Sehir != null && a.Sehir.Name == "Ankara") == null)
            {
                context.Ilce.AddOrUpdate(new Ilce { Name = "Merkez", Sehir = Ankara });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Altýndað", Sehir = Ankara });
                context.Ilce.AddOrUpdate(new Ilce { Name = "Keçiören", Sehir = Ankara });
            }

            context.SaveChanges();
            if (context.Afet.FirstOrDefault(a => a.SeriNo=="test") == null)
            {
                Afet afet = new Afet();
                afet.SeriNo = "test";
                afet.BaslangicTarih = new DateTime(2015, 11, 15);
                afet.BitisTarih = new DateTime(2015, 11, 20);
                afet.Sehir = new Sehir();
                afet.Sehir.Id = 7;
                afet.Ilce = new Ilce();
                afet.Ilce.Id = 19;
                afet.Enlem = "35.51512909615118";
                afet.Boylam = "24.016499519348145";
                afet.Aciklama = "test";
                afet.EtkiledigiAlanlar = "test";
                afet.Kaynak = "test";
                afet.AfetTuru = new AfetTur();
                afet.AfetTuru.Id = 2;
                context.Afet.Add(afet);
                context.SaveChanges();
            }
        }
    }
}
