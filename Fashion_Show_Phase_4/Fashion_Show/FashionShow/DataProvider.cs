using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionShow.Entiteti;
using NHibernate;
using NHibernate.Linq;
using System.Runtime.Serialization;

namespace FashionShow
{
    public class DataProvider
    {
        //Agencije
        public IEnumerable<Agencija> GetAgencija()
        {
            ISession s = DataLayer.GetSession();

            IEnumerable<Agencija> agencije = s.Query<Agencija>().Where(x => x.ID > 0).Select(p => p);
            foreach (Agencija ag in agencije)
            {
                ag.AManekeni = null;
            }

            return agencije;
        }
        public Agencija GetAgencija(int id)
        {
            ISession s = DataLayer.GetSession();
            Agencija agn = s.Query<Agencija>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();
            //agn = (Agencija)s.GetSessionImplementation().PersistenceContext.Unproxy(agn);
            return agn;
        }

        public int AddAgencija(Agencija agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(agn);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveAgencija(int agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Agencija k = s.Load<Agencija>(agn);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateAgencija(Agencija agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(agn);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Domaca agencija
        public IEnumerable<Domaca_Agencija> GetDomaceAgencije()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Domaca_Agencija> dagn = s.Query<Domaca_Agencija>().Where(x => x.ID > 0).Select(p => p);
            foreach (Domaca_Agencija da in dagn)
            {
                da.AManekeni = null;

            }
            return dagn;
        }
        public Domaca_Agencija GetDomaceAgencije(int id)
        {
            ISession s = DataLayer.GetSession();
            Domaca_Agencija agn = s.Query<Domaca_Agencija>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();
            //agn = (Domaca_Agencija)s.GetSessionImplementation().PersistenceContext.Unproxy(agn);
            return agn;
        }

        public int AddDomaceAgencije(Domaca_Agencija agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(agn);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveDomaceAgencije(int agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Domaca_Agencija k = s.Load<Domaca_Agencija>(agn);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateDomaceAgencije(Domaca_Agencija agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(agn);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Internacionalna agencija
        public IEnumerable<Internacionalna_Agencija> GetInternacionalneAgencije()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Internacionalna_Agencija> dagn = s.Query<Internacionalna_Agencija>().Where(x => x.ID > 0).Select(p => p);
            foreach (Internacionalna_Agencija iag in dagn)
            {

                iag.AManekeni = null;
                iag.Zemlje = null;

            }
            return dagn;
        }
        public Internacionalna_Agencija GetInternacionalneAgencije(int id)
        {
            ISession s = DataLayer.GetSession();
            Internacionalna_Agencija agn = s.Query<Internacionalna_Agencija>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();
            //agn = (Internacionalna_Agencija)s.GetSessionImplementation().PersistenceContext.Unproxy(agn);
            return agn;
        }

        public int AddInternacionalneAgencije(Internacionalna_Agencija agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(agn);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveInternacionalneAgencije(int agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Internacionalna_Agencija k = s.Load<Internacionalna_Agencija>(agn);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateInternacionalneAgencije(Internacionalna_Agencija agn)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(agn);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        //Modna revija
        public IEnumerable<Modna_Revija> GetModneRevije()
        {
            ISession s = DataLayer.GetSession();

            IEnumerable<Modna_Revija> mrevije = s.Query<Modna_Revija>().Where(x => x.Redni_Broj > 0).Select(p => p);
            foreach (Modna_Revija mr in mrevije)
            {
                mr.NastupaManekeni = null;
                mr.Prikazuje_NaKreator = null;
            }

            return mrevije;
        }
        public Modna_Revija GetModneRevije(int id)
        {
            ISession s = DataLayer.GetSession();
            Modna_Revija mdr = s.Query<Modna_Revija>().Where(x => x.Redni_Broj == id).Select(ak => ak).FirstOrDefault();

            mdr.Prikazuje_NaKreator = null;
            mdr.NastupaManekeni = null;
            // mdr = (Modna_Revija)s.GetSessionImplementation().PersistenceContext.Unproxy(mdr);
            return mdr;
        }

        public int AddModneRevije(Modna_Revija mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(mdr);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveModneRevije(int mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija k = s.Load<Modna_Revija>(mdr);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateModneRevije(Modna_Revija mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(mdr);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Modna revija sa jednim kreatorom
        public IEnumerable<Modna_Revija_Sa_Jednim_Kreatorom> GetModneRevijeSaJednimKreatorom()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Modna_Revija_Sa_Jednim_Kreatorom> mdr = s.Query<Modna_Revija_Sa_Jednim_Kreatorom>().Where(x => x.Redni_Broj > 0).Select(p => p);
            foreach (Modna_Revija_Sa_Jednim_Kreatorom o in mdr)
            {

                o.Prikazuje_NaKreator = null;
                o.NastupaManekeni = null;
            }
            return mdr;
        }

        public Modna_Revija_Sa_Jednim_Kreatorom GetModneRevijeSaJednimKreatorom(int id)
        {
            ISession s = DataLayer.GetSession();
            Modna_Revija_Sa_Jednim_Kreatorom mdr = s.Query<Modna_Revija_Sa_Jednim_Kreatorom>().Where(x => x.Redni_Broj == id).Select(ak => ak).FirstOrDefault();

            mdr.Prikazuje_NaKreator = null;
            mdr.NastupaManekeni = null;
            //mdr = (Modna_Revija_Sa_Jednim_Kreatorom)s.GetSessionImplementation().PersistenceContext.Unproxy(mdr);
            return mdr;
        }

        public int AddModneRevijeSaJednimKreatorom(Modna_Revija_Sa_Jednim_Kreatorom mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(mdr);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveModneRevijeSaJednimKreatorom(int mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija_Sa_Jednim_Kreatorom k = s.Load<Modna_Revija_Sa_Jednim_Kreatorom>(mdr);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateModneRevijeSaJednimKreatorom(Modna_Revija_Sa_Jednim_Kreatorom mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(mdr);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Modna revija sa vise kreatora
        public IEnumerable<Modna_Revija_Sa_Vise_Kreatora> GetModneRevijeSaViseKreatora()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Modna_Revija_Sa_Vise_Kreatora> mdr = s.Query<Modna_Revija_Sa_Vise_Kreatora>().Where(x => x.Redni_Broj > 0).Select(p => p);
            foreach (Modna_Revija_Sa_Vise_Kreatora o in mdr)
            {
                o.Prikazuje_NaKreator = null;
                o.NastupaManekeni = null;
            }
            return mdr;
        }

        public Modna_Revija_Sa_Vise_Kreatora GetModneRevijeSaViseKreatora(int id)
        {
            ISession s = DataLayer.GetSession();
            Modna_Revija_Sa_Vise_Kreatora mdr = s.Query<Modna_Revija_Sa_Vise_Kreatora>().Where(x => x.Redni_Broj == id).Select(ak => ak).FirstOrDefault();
            mdr.Prikazuje_NaKreator = null;
            mdr.NastupaManekeni = null;
            // mdr = (Modna_Revija_Sa_Vise_Kreatora)s.GetSessionImplementation().PersistenceContext.Unproxy(mdr);
            return mdr;
        }

        public int AddModneRevijeSaViseKreatora(Modna_Revija_Sa_Vise_Kreatora mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(mdr);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveModneRevijeSaViseKreatora(int mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija_Sa_Vise_Kreatora k = s.Load<Modna_Revija_Sa_Vise_Kreatora>(mdr);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateModneRevijeSaViseKreatora(Modna_Revija_Sa_Vise_Kreatora mdr)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(mdr);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Osoba
        public int UpdateOsoba(Osoba osb)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(osb);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int RemoveOsoba(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Osoba osb = s.Load<Osoba>(id);
                s.Delete(osb);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public Osoba GetOsoba(int id)
        {
            ISession s = DataLayer.GetSession();
            Osoba o = s.Load<Osoba>(id);
            // o = (Osoba)s.GetSessionImplementation().PersistenceContext.Unproxy(o);
            return o;
        }

        public IEnumerable<Osoba> GetOsoba()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Osoba> a = s.Query<Osoba>().Select(ak => ak);

            return a;
        }

        public int AddOsoba(Osoba osb)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(osb);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        //Kreatori
        public IEnumerable<Kreator> GetKreatori()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Kreator> kre = s.Query<Kreator>().Where(x => x.ID > 0).Select(p => p);

            foreach (Kreator o in kre)
            {

                o.Prikazuje_NaMRevija = null;

            }
            return kre;
        }

        public Kreator GetKreatori(int id)
        {
            ISession s = DataLayer.GetSession();
            Kreator kre = s.Query<Kreator>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();
            kre.Prikazuje_NaMRevija = null;
            // kre = (Kreator)s.GetSessionImplementation().PersistenceContext.Unproxy(kre);

            return kre;
        }

        public int AddKreator(Kreator kre)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(kre);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveKreator(int kre)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kreator k = s.Load<Kreator>(kre);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateKreator(Kreator kre)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(kre);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Maneken
        public IEnumerable<Maneken> GetManekeni()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Maneken> amk = s.Query<Maneken>().Where(x => x.ID > 0).Select(p => p);

            foreach (Maneken o in amk)
            {
                o.NastupaModna_Revija = null;
                o.Casopisi = null;

            }
            return amk;
        }

        public Maneken GetManekeni(int id)
        {
            ISession s = DataLayer.GetSession();
            Maneken amk = s.Query<Maneken>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();
            amk.NastupaModna_Revija = null;
            amk.Casopisi = null;
            //  amk = (Maneken)s.GetSessionImplementation().PersistenceContext.Unproxy(amk);
            return amk;
        }

        public int AddManeken(Maneken amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(amk);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveManeken(int amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Maneken k = s.Load<Maneken>(amk);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateManeken(Maneken amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(amk);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Agencijski maneken
        public IEnumerable<Agencijski_Maneken> GetAgencijski_Manekeni()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Agencijski_Maneken> amk = s.Query<Agencijski_Maneken>().Where(x => x.ID > 0).Select(p => p);
            foreach (Agencijski_Maneken o in amk)
            {

                o.NastupaModna_Revija = null;
                o.Casopisi = null;
                o.PripadaAgeciji = null;

            }
            return amk;
        }

        public Agencijski_Maneken GetAgencijski_Manekeni(int id)
        {
            ISession s = DataLayer.GetSession();
            Agencijski_Maneken amk = s.Query<Agencijski_Maneken>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();

            amk.PripadaAgeciji = null;
            amk.NastupaModna_Revija = null;
            amk.Casopisi = null;
            //amk = (Agencijski_Maneken)s.GetSessionImplementation().PersistenceContext.Unproxy(amk);
            return amk;
        }

        public int AddAgencijski_Maneken(Agencijski_Maneken amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(amk);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveAgencijski_Maneken(int amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Agencijski_Maneken k = s.Load<Agencijski_Maneken>(amk);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateAgencijski_Maneken(Agencijski_Maneken amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(amk);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Specijalan gost
        public IEnumerable<Specijalan_Gost> GetSpecijalaniGosti()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Specijalan_Gost> amk = s.Query<Specijalan_Gost>().Where(x => x.ID > 0).Select(p => p);
            foreach (Specijalan_Gost o in amk)
            {

                o.NastupaModna_Revija = null;
                o.Casopisi = null;

            }
            return amk;
        }

        public Specijalan_Gost GetSpecijalaniGosti(int id)
        {
            ISession s = DataLayer.GetSession();
            Specijalan_Gost amk = s.Query<Specijalan_Gost>().Where(x => x.ID == id).Select(ak => ak).FirstOrDefault();
            amk.NastupaModna_Revija = null;
            amk.Casopisi = null;
            //amk = (Specijalan_Gost)s.GetSessionImplementation().PersistenceContext.Unproxy(amk);

            return amk;
        }

        public int AddSpecijalan_Gost(Specijalan_Gost amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(amk);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int RemoveSpecijalaniGost(int amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Specijalan_Gost k = s.Load<Specijalan_Gost>(amk);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }
        public int UpdateSpecijalaniGost(Specijalan_Gost amk)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(amk);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Casopisi
        public IEnumerable<Casopic> GetCasopisi()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Casopic> pm = s.Query<Casopic>().Select(p => p);
            foreach (Casopic p in pm)
            {
                p.PripadaManekenu = null;
            }
            return pm;
        }

        public Casopic GetCasopisi(int id)
        {
            ISession s = DataLayer.GetSession();
            Casopic pm = s.Query<Casopic>().Where(x => x.ID_Casopis == id).Select(p => p).FirstOrDefault();
            pm.PripadaManekenu = null;
            return pm;
        }

        public int AddCasopisi(Casopic cas)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                //cas.PripadaManekenu = null;
                s.Save(cas);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        public int RemoveCasopisi(Casopic cas)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Casopic k = s.Load<Casopic>(cas);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        public int UpdateCasopisi(Casopic cas)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(cas);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Zemlje
        public IEnumerable<Zemlja> GetZemlje()
        {
            ISession s = DataLayer.GetSession();
            IEnumerable<Zemlja> pm = s.Query<Zemlja>().Select(p => p);
            foreach (Zemlja p in pm)
            {
                p.PripadaAgenciji = null;
            }
            return pm;
        }

        public Zemlja GetZemlje(int id)
        {
            ISession s = DataLayer.GetSession();
            Zemlja pm = s.Query<Zemlja>().Where(x => x.ID_Zemlja == id).Select(p => p).FirstOrDefault();
            pm.PripadaAgenciji = null;
            return pm;
        }

        public int AddZemlje(Zemlja zem)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Save(zem);
                s.Flush();
                s.Close();

                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        public int RemoveZemlje(Zemlja zem)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zemlja k = s.Load<Zemlja>(zem);
                s.Delete(k);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception ec)
            {
                return -1;
            }
        }

        public int UpdateZemlje(Zemlja zem)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                s.Update(zem);
                s.Flush();
                s.Close();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
