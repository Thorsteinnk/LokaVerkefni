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
                z => z.ZipCode, new Zip(101, "Reykjavík"),
                new Zip(103, "Reykjavík"),
                new Zip(104, "Reykjavík"),
                new Zip(105, "Reykjavík"),
                new Zip(107, "Reykjavík"),
                new Zip(108, "Reykjavík"),
                new Zip(109, "Reykjavík"),
                new Zip(110, "Reykjavík"),
                new Zip(111, "Reykjavík"),
                new Zip(112, "Reykjavík"),
                new Zip(113, "Reykjavík"),
                new Zip(116, "Reykjavík"),
                new Zip(121, "Reykjavík"),
                new Zip(123, "Reykjavík"),
                new Zip(124, "Reykjavík"),
                new Zip(125, "Reykjavík"),
                new Zip(127, "Reykjavík"),
                new Zip(128, "Reykjavík"),
                new Zip(129, "Reykjavík"),
                new Zip(130, "Reykjavík"),
                new Zip(132, "Reykjavík"),
                new Zip(150, "Reykjavík"),
                new Zip(155, "Reykjavík"),
                new Zip(170, "Seltjarnarnesi"),
                new Zip(172, "Seltjarnarnesi"),
                new Zip(190, "Vogum"),
                new Zip(200, "Kópavogi"),
                new Zip(201, "Kópavogi"),
                new Zip(202, "Kópavogi"),
                new Zip(203, "Kópavogi"),
                new Zip(210, "Garðabæ"),
                new Zip(212, "Garðabæ"),
                new Zip(220, "Hafnarfirði"),
                new Zip(221, "Hafnarfirði"),
                new Zip(222, "Hafnarfirði"),
                new Zip(225, "Álftanesi"),
                new Zip(230, "Reykjanesbæ"),
                new Zip(232, "Reykjanesbæ"),
                new Zip(233, "Reykjanesbæ"),
                new Zip(235, "Reykjanesbæ"),
                new Zip(240, "Grindavík"),
                new Zip(245, "Sandgerði"),
                new Zip(250, "Garði"),
                new Zip(260, "Reykjanesbæ"),
                new Zip(270, "Mosfellsbæ"),
                new Zip(271, "Mosfellsbæ"),
                new Zip(276, "Mosfellsbæ"),
                new Zip(300, "Akranesi"),
                new Zip(301, "Akranesi"),
                new Zip(302, "Akranesi"),
                new Zip(310, "Borgarnesi"),
                new Zip(311, "Borgarnesi"),
                new Zip(320, "Reykholt í Borgarfirði"),
                new Zip(340, "Stykkishólmi"),
                new Zip(345, "Flatey á Breiðafirði"),
                new Zip(350, "Grundarfirði"),
                new Zip(355, "Ólafsvík"),
                new Zip(356, "Snæfellsbæ"),
                new Zip(360, "Hellissandi"),
                new Zip(370, "Búðardal"),
                new Zip(371, "Búðardal"),
                new Zip(380, "Reykhólahreppi"),
                new Zip(400, "Ísafirði"),
                new Zip(401, "Ísafirði"),
                new Zip(410, "Hnífsdal"),
                new Zip(415, "Bolungarvík"),
                new Zip(420, "Súðavík"),
                new Zip(425, "Flateyri"),
                new Zip(430, "Suðureyri"),
                new Zip(450, "Patreksfirði"),
                new Zip(451, "Patreksfirði"),
                new Zip(460, "Tálknafirði"),
                new Zip(465, "Bíldudal"),
                new Zip(470, "Þingeyri"),
                new Zip(471, "Þingeyri"),
                new Zip(500, "Stað"),
                new Zip(510, "Hólmavík"),
                new Zip(512, "Hólmavík"),
                new Zip(520, "Drangsnesi"),
                new Zip(524, "Árneshreppi"),
                new Zip(530, "Hvammstanga"),
                new Zip(531, "Hvammstanga"),
                new Zip(540, "Blönduósi"),
                new Zip(541, "Blönduósi"),
                new Zip(545, "Skagaströnd"),
                new Zip(550, "Sauðárkróki"),
                new Zip(551, "Sauðárkróki"),
                new Zip(560, "Varmahlíð"),
                new Zip(565, "Hofsós"),
                new Zip(566, "Hofsós"),
                new Zip(570, "Fljótum"),
                new Zip(580, "Siglufirði"),
                new Zip(600, "Akureyri"),
                new Zip(601, "Akureyri"),
                new Zip(602, "Akureyri"),
                new Zip(603, "Akureyri"),
                new Zip(610, "Grenivík"),
                new Zip(611, "Grímsey"),
                new Zip(620, "Dalvík"),
                new Zip(621, "Dalvík"),
                new Zip(625, "Ólafsfirði"),
                new Zip(630, "Hrísey"),
                new Zip(640, "Húsavík"),
                new Zip(641, "Húsavík"),
                new Zip(645, "Fosshólli"),
                new Zip(650, "Laugum"),
                new Zip(660, "Mývatni"),
                new Zip(670, "Kópaskeri"),
                new Zip(671, "Kópaskeri"),
                new Zip(675, "Raufarhöfn"),
                new Zip(680, "Þórshöfn"),
                new Zip(681, "Þórshöfn"),
                new Zip(685, "Bakkafirði"),
                new Zip(690, "Vopnafirði"),
                new Zip(700, "Egilsstöðum"),
                new Zip(701, "Egilsstöðum"),
                new Zip(710, "Seyðisfirði"),
                new Zip(715, "Mjóafirði"),
                new Zip(720, "Borgarfirði(eystri)"),
                new Zip(730, "Reyðarfirði"),
                new Zip(735, "Eskifirði"),
                new Zip(740, "Neskaupstað"),
                new Zip(750, "Fáskrúðsfirði"),
                new Zip(755, "Stöðvarfirði"),
                new Zip(760, "Breiðdalsvík"),
                new Zip(765, "Djúpavogi"),
                new Zip(780, "Höfn í Hornafirði"),
                new Zip(781, "Höfn í Hornafirði"),
                new Zip(785, "Öræfum"),
                new Zip(800, "Selfossi"),
                new Zip(801, "Selfossi"),
                new Zip(802, "Selfossi"),
                new Zip(810, "Hveragerði"),
                new Zip(815, "Þorlákshöfn"),
                new Zip(816, "Ölfus"),
                new Zip(820, "Eyrarbakka"),
                new Zip(825, "Stokkseyri"),
                new Zip(840, "Laugarvatni"),
                new Zip(845, "Flúðum"),
                new Zip(850, "Hellu"),
                new Zip(851, "Hellu"),
                new Zip(860, "Hvolsvelli"),
                new Zip(861, "Hvolsvelli"),
                new Zip(870, "Vík"),
                new Zip(871, "Vík"),
                new Zip(880, "Kirkjubæjarklaustri"),
                new Zip(900, "Vestmannaeyjum"),
                new Zip(902, "Vestmannaeyjum")
               );
            context.SaveChanges();
            context.Adresses.AddOrUpdate(a => a.AdressKey, new Address("Móabarð", "34", 33));
            context.SaveChanges();
            context.Adresses.AddOrUpdate(a => a.AdressKey, new Address("Þrúðvangur", 33));
            context.SaveChanges();
            context.Apartments.AddOrUpdate(a => a.AddressID, new Apartment()
            {
                Price = 160000,
                Size = 63.5,
                NumberOfRooms = 2,
                Description = "Góð og vel skipulögð 63,5 fm íbúð á annarri hæð í litlu fjölbýlishúsi við Móabarð 34 með góðu útsýni til suðurs.",
                AddressID = 1
            });
            context.SaveChanges();
            context.Apartments.AddOrUpdate(a => a.AddressID, new Apartment()
            {
                Price = 285000,
                Size = 233,
                NumberOfRooms = 8,
                Description = "Til leigu gott einbýlishús, 192m² ásamt 42m² bílskúr. Forstofa, gestasnyrting, stofa og borðstofa með parketi. eldhús með borðkrók og ísskáp. Fimm herbergi og baðherbergi með innréttingu. Húsið er laust til leigu strax",
                AddressID = 2
            });

            context.Tenants.AddOrUpdate(a => a.SocialSecurity, new Tenant()
            {
                Name = "Þorsteinn Kristjánsson",
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
                Description = "Bilaður Ofn",
                Solved = false,
                Action = "Hringja á Pípara",
                ApartmentID = 1
                },
                new Incident()
                {
                    Description = "Brotinn Gluggi",
                    Action = "Skipta Út",
                    Solved = true,
                    ApartmentID = 1
                }
                );


            //  This method will be called after migrating to the latest version.

        }
    }
}
