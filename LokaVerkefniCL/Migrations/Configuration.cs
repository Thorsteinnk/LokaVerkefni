namespace LokaVerkefniCL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LokaVerkefniCL.LokaverkefniDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LokaVerkefniCL.LokaverkefniDBContext context)
        {
            context.Zip.AddOrUpdate(
                z => z.ZipCode, new Zip(101, "Reykjav�k"),
                new Zip(103, "Reykjav�k"),
                new Zip(104, "Reykjav�k"),
                new Zip(105, "Reykjav�k"),
                new Zip(107, "Reykjav�k"),
                new Zip(108, "Reykjav�k"),
                new Zip(109, "Reykjav�k"),
                new Zip(110, "Reykjav�k"),
                new Zip(111, "Reykjav�k"),
                new Zip(112, "Reykjav�k"),
                new Zip(113, "Reykjav�k"),
                new Zip(116, "Reykjav�k"),
                new Zip(121, "Reykjav�k"),
                new Zip(123, "Reykjav�k"),
                new Zip(124, "Reykjav�k"),
                new Zip(125, "Reykjav�k"),
                new Zip(127, "Reykjav�k"),
                new Zip(128, "Reykjav�k"),
                new Zip(129, "Reykjav�k"),
                new Zip(130, "Reykjav�k"),
                new Zip(132, "Reykjav�k"),
                new Zip(150, "Reykjav�k"),
                new Zip(155, "Reykjav�k"),
                new Zip(170, "Seltjarnarnesi"),
                new Zip(172, "Seltjarnarnesi"),
                new Zip(190, "Vogum"),
                new Zip(200, "K�pavogi"),
                new Zip(201, "K�pavogi"),
                new Zip(202, "K�pavogi"),
                new Zip(203, "K�pavogi"),
                new Zip(210, "Gar�ab�"),
                new Zip(212, "Gar�ab�"),
                new Zip(220, "Hafnarfir�i"),
                new Zip(221, "Hafnarfir�i"),
                new Zip(222, "Hafnarfir�i"),
                new Zip(225, "�lftanesi"),
                new Zip(230, "Reykjanesb�"),
                new Zip(232, "Reykjanesb�"),
                new Zip(233, "Reykjanesb�"),
                new Zip(235, "Reykjanesb�"),
                new Zip(240, "Grindav�k"),
                new Zip(245, "Sandger�i"),
                new Zip(250, "Gar�i"),
                new Zip(260, "Reykjanesb�"),
                new Zip(270, "Mosfellsb�"),
                new Zip(271, "Mosfellsb�"),
                new Zip(276, "Mosfellsb�"),
                new Zip(300, "Akranesi"),
                new Zip(301, "Akranesi"),
                new Zip(302, "Akranesi"),
                new Zip(310, "Borgarnesi"),
                new Zip(311, "Borgarnesi"),
                new Zip(320, "Reykholt � Borgarfir�i"),
                new Zip(340, "Stykkish�lmi"),
                new Zip(345, "Flatey � Brei�afir�i"),
                new Zip(350, "Grundarfir�i"),
                new Zip(355, "�lafsv�k"),
                new Zip(356, "Sn�fellsb�"),
                new Zip(360, "Hellissandi"),
                new Zip(370, "B��ardal"),
                new Zip(371, "B��ardal"),
                new Zip(380, "Reykh�lahreppi"),
                new Zip(400, "�safir�i"),
                new Zip(401, "�safir�i"),
                new Zip(410, "Hn�fsdal"),
                new Zip(415, "Bolungarv�k"),
                new Zip(420, "S��av�k"),
                new Zip(425, "Flateyri"),
                new Zip(430, "Su�ureyri"),
                new Zip(450, "Patreksfir�i"),
                new Zip(451, "Patreksfir�i"),
                new Zip(460, "T�lknafir�i"),
                new Zip(465, "B�ldudal"),
                new Zip(470, "�ingeyri"),
                new Zip(471, "�ingeyri"),
                new Zip(500, "Sta�"),
                new Zip(510, "H�lmav�k"),
                new Zip(512, "H�lmav�k"),
                new Zip(520, "Drangsnesi"),
                new Zip(524, "�rneshreppi"),
                new Zip(530, "Hvammstanga"),
                new Zip(531, "Hvammstanga"),
                new Zip(540, "Bl�ndu�si"),
                new Zip(541, "Bl�ndu�si"),
                new Zip(545, "Skagastr�nd"),
                new Zip(550, "Sau��rkr�ki"),
                new Zip(551, "Sau��rkr�ki"),
                new Zip(560, "Varmahl��"),
                new Zip(565, "Hofs�s"),
                new Zip(566, "Hofs�s"),
                new Zip(570, "Flj�tum"),
                new Zip(580, "Siglufir�i"),
                new Zip(600, "Akureyri"),
                new Zip(601, "Akureyri"),
                new Zip(602, "Akureyri"),
                new Zip(603, "Akureyri"),
                new Zip(610, "Greniv�k"),
                new Zip(611, "Gr�msey"),
                new Zip(620, "Dalv�k"),
                new Zip(621, "Dalv�k"),
                new Zip(625, "�lafsfir�i"),
                new Zip(630, "Hr�sey"),
                new Zip(640, "H�sav�k"),
                new Zip(641, "H�sav�k"),
                new Zip(645, "Fossh�lli"),
                new Zip(650, "Laugum"),
                new Zip(660, "M�vatni"),
                new Zip(670, "K�paskeri"),
                new Zip(671, "K�paskeri"),
                new Zip(675, "Raufarh�fn"),
                new Zip(680, "��rsh�fn"),
                new Zip(681, "��rsh�fn"),
                new Zip(685, "Bakkafir�i"),
                new Zip(690, "Vopnafir�i"),
                new Zip(700, "Egilsst��um"),
                new Zip(701, "Egilsst��um"),
                new Zip(710, "Sey�isfir�i"),
                new Zip(715, "Mj�afir�i"),
                new Zip(720, "Borgarfir�i(eystri)"),
                new Zip(730, "Rey�arfir�i"),
                new Zip(735, "Eskifir�i"),
                new Zip(740, "Neskaupsta�"),
                new Zip(750, "F�skr��sfir�i"),
                new Zip(755, "St��varfir�i"),
                new Zip(760, "Brei�dalsv�k"),
                new Zip(765, "Dj�pavogi"),
                new Zip(780, "H�fn � Hornafir�i"),
                new Zip(781, "H�fn � Hornafir�i"),
                new Zip(785, "�r�fum"),
                new Zip(800, "Selfossi"),
                new Zip(801, "Selfossi"),
                new Zip(802, "Selfossi"),
                new Zip(810, "Hverager�i"),
                new Zip(815, "�orl�ksh�fn"),
                new Zip(816, "�lfus"),
                new Zip(820, "Eyrarbakka"),
                new Zip(825, "Stokkseyri"),
                new Zip(840, "Laugarvatni"),
                new Zip(845, "Fl��um"),
                new Zip(850, "Hellu"),
                new Zip(851, "Hellu"),
                new Zip(860, "Hvolsvelli"),
                new Zip(861, "Hvolsvelli"),
                new Zip(870, "V�k"),
                new Zip(871, "V�k"),
                new Zip(880, "Kirkjub�jarklaustri"),
                new Zip(900, "Vestmannaeyjum"),
                new Zip(902, "Vestmannaeyjum")
               );
            context.SaveChanges();
            context.Adresses.AddOrUpdate(a => a.AdressKey, new Address("M�abar�", "34", 33));
            context.SaveChanges();
            context.Adresses.AddOrUpdate(a => a.AdressKey, new Address("�r��vangur", 33));
            context.SaveChanges();
            context.Apartments.AddOrUpdate(a => a.AddressID, new Apartment()
            {
                Price = 160000,
                Size = 63.5,
                NumberOfRooms = 2,
                Description = "G�� og vel skipul�g� 63,5 fm �b�� � annarri h�� � litlu fj�lb�lish�si vi� M�abar� 34 me� g��u �ts�ni til su�urs.",
                AddressID = 1
            });
            context.SaveChanges();
            context.Apartments.AddOrUpdate(a => a.AddressID, new Apartment()
            {
                Price = 285000,
                Size = 233,
                NumberOfRooms = 8,
                Description = "Til leigu gott einb�lish�s, 192m� �samt 42m� b�lsk�r. Forstofa, gestasnyrting, stofa og bor�stofa me� parketi. eldh�s me� bor�kr�k og �ssk�p. Fimm herbergi og ba�herbergi me� innr�ttingu. H�si� er laust til leigu strax",
                AddressID = 2
            });

            context.Tenants.AddOrUpdate(a => a.SocialSecurity, new Tenant()
            {
                Name = "�orsteinn Kristj�nsson",
                SocialSecurity = "0210852519",
                AddressID = 1,
            });
            context.SaveChanges();
            context.Contracts.AddOrUpdate(a => a.ApartmentID, new Contract()
            {
                ApartmentID = 1,
                PersonID = 1,
                Price = 180000,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddYears(2)
            });

            context.Incidents.AddOrUpdate(a => a.Description, 
                new Incident()
                {
                Description = "Bila�ur Ofn",
                Solved = false,
                Action = "Hringja � P�para",
                ApartmentID = 1
                },
                new Incident()
                {
                    Description = "Brotinn Gluggi",
                    Action = "Skipta �t",
                    Solved = true,
                    ApartmentID = 1
                }
                );


            //  This method will be called after migrating to the latest version.

        }
    }
}
