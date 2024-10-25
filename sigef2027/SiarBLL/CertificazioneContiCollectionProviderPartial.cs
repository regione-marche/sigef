using System;
using System.Data;
using SiarLibrary;
using SiarDAL;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace SiarBLL
{
    public partial class CertificazioneContiCollectionProvider : ICertificazioneContiProvider
    {
        #region Appendice1
        public class RigaAppendice1Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoA { get; set; }
            public decimal ImportoB { get; set; }
            public decimal ImportoC { get; set; }
            public decimal ImportoAAdA { get; set; }
            public decimal ImportoBAdA { get; set; }

            public RigaAppendice1Conti() { }

            public RigaAppendice1Conti(int idAsse)
            {
                IdAsse = idAsse;
                Asse = "Asse " + idAsse;
                ImportoA = Convert.ToDecimal(0.00);
                ImportoB = Convert.ToDecimal(0.00);
                ImportoC = Convert.ToDecimal(0.00);
                ImportoAAdA = Convert.ToDecimal(0.00);
                ImportoBAdA = Convert.ToDecimal(0.00);
            }

            public RigaAppendice1Conti(int idAsse, string asse, decimal importoA, decimal importoB, decimal importoC, decimal importoAAdA, decimal importoBAdA)
            {
                IdAsse = idAsse;
                Asse = asse;
                ImportoA = importoA;
                ImportoB = importoB;
                ImportoC = importoC;
                ImportoAAdA = importoAAdA;
                ImportoBAdA = importoBAdA;
            }

        }

        public List<RigaAppendice1Conti> GrigliaAppendice1Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice1Conti rAnt;
            List<RigaAppendice1Conti> ret = new List<RigaAppendice1Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE1";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@CodPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice1Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["ID_ASSE"].ToString());
                rAnt.Asse = dbPro.DataReader["COD_ASSE"].ToString();
                rAnt.ImportoA = Convert.ToDecimal(dbPro.DataReader["A"]);
                rAnt.ImportoB = Convert.ToDecimal(dbPro.DataReader["B"]);
                rAnt.ImportoC = Convert.ToDecimal(dbPro.DataReader["C"]);
                rAnt.ImportoAAdA = Convert.ToDecimal(dbPro.DataReader["A_ADA"]);
                rAnt.ImportoBAdA = Convert.ToDecimal(dbPro.DataReader["B_ADA"]);

                ret.Add(rAnt);
            }
            dbPro.Close();

            //ret = RiempiGrigliaAppendice1Conti(ret);
            
            return ret;
        }

        public List<RigaAppendice1Conti> RiempiGrigliaAppendice1Conti(List<RigaAppendice1Conti> lista)
        {
            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.IdAsse == i).Count() == 0)
                {
                    var nuova = new RigaAppendice1Conti(i);
                    lista.Add(nuova);
                }
            }

            return lista
                .OrderBy(a => a.Asse)
                .ToList<RigaAppendice1Conti>();
        }

        #endregion

        #region Appendice2
        //APPENDICE 2
        public class RigaAppendice2Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondenteRitiri { get; set; }
            public decimal ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondenteRecuperi { get; set; }

            public RigaAppendice2Conti() { }
            public RigaAppendice2Conti(int idAsse)
            {
                IdAsse = idAsse;
                Asse = "Asse " + idAsse;
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = Convert.ToDecimal(0.00);
                ImportoSpesaPubblicaCorrispondenteRitiri = Convert.ToDecimal(0.00);
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = Convert.ToDecimal(0.00);
                ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(0.00);
            }

            public RigaAppendice2Conti(int idAsse, string asse, decimal importoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri, decimal importoSpesaPubblicaCorrispondenteRitiri, decimal importoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi, decimal importoSpesaPubblicaCorrispondenteRecuperi)
            {
                IdAsse = idAsse;
                Asse = asse;
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = importoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri;
                ImportoSpesaPubblicaCorrispondenteRitiri = importoSpesaPubblicaCorrispondenteRitiri;
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = importoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi;
                ImportoSpesaPubblicaCorrispondenteRecuperi = importoSpesaPubblicaCorrispondenteRecuperi;
            }

        }

        public List<RigaAppendice2Conti> GrigliaAppendice2Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice2Conti rAnt;
            List<RigaAppendice2Conti> ret = new List<RigaAppendice2Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE2";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice2Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["ID_ASSE"].ToString());
                rAnt.Asse = dbPro.DataReader["COD_ASSE"].ToString();
                rAnt.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri"]);
                rAnt.ImportoSpesaPubblicaCorrispondenteRitiri = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteRitiri"]);
                rAnt.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi"]);
                rAnt.ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteRecuperi"]);
                ret.Add(rAnt);
            }
            dbPro.Close();

            ret = RiempiGrigliaAppendice2Conti(ret);

            return ret;
        }

        public List<RigaAppendice2Conti> RiempiGrigliaAppendice2Conti(List<RigaAppendice2Conti> lista)
        {

            lista = lista
                .GroupBy(a => a.Asse).Select(b => new RigaAppendice2Conti
                {
                    IdAsse = b.First().IdAsse,
                    Asse = b.First().Asse.Length==1? "Asse " + b.First().Asse: b.First().Asse,
                    ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = b.Sum(c => c.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri),
                    ImportoSpesaPubblicaCorrispondenteRitiri = b.Sum(c => c.ImportoSpesaPubblicaCorrispondenteRitiri),
                    ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = b.Sum(c => c.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi),
                    ImportoSpesaPubblicaCorrispondenteRecuperi = b.Sum(c => c.ImportoSpesaPubblicaCorrispondenteRecuperi)
                })
                .ToList<RigaAppendice2Conti>();

            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.Asse == ("Asse " + i.ToString())).Count() == 0)
                {
                    var nuova = new RigaAppendice2Conti(i);
                    lista.Add(nuova);
                }
            }
            return lista.OrderBy(x => x.Asse).ToList();
        }

        //DETTAGLIO 2
        public class RigaAppendice2ContiDettaglio : BaseObject
        {
            public int IdRecord { get; set; }
            public string Anno { get; set; }
            public bool FlagImportiRettificati { get; set; }
            public decimal ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondenteRitiri { get; set; }
            public decimal ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondenteRecuperi { get; set; }

            public RigaAppendice2ContiDettaglio()
            {
                IdRecord = 0;
                Anno = "";
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = Convert.ToDecimal(0.00);
                ImportoSpesaPubblicaCorrispondenteRitiri = Convert.ToDecimal(0.00);
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = Convert.ToDecimal(0.00);
                ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(0.00);
            }

            public RigaAppendice2ContiDettaglio(int idRecord, string anno, decimal importoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri, decimal importoSpesaPubblicaCorrispondenteRitiri, decimal importoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi, decimal importoSpesaPubblicaCorrispondenteRecuperi)
            {
                IdRecord = idRecord;
                Anno = anno;
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = importoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri;
                ImportoSpesaPubblicaCorrispondenteRitiri = importoSpesaPubblicaCorrispondenteRitiri;
                ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = importoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi;
                ImportoSpesaPubblicaCorrispondenteRecuperi = importoSpesaPubblicaCorrispondenteRecuperi;
            }

        }

        public List<RigaAppendice2ContiDettaglio> GrigliaAppendice2ContiDettaglio(DateTime dataLotto, string codPsr)
        {
            RigaAppendice2ContiDettaglio rAnt;
            List<RigaAppendice2ContiDettaglio> ret = new List<RigaAppendice2ContiDettaglio>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE2_DETTAGLIO";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice2ContiDettaglio();
                rAnt.IdRecord = Convert.ToInt32(dbPro.DataReader["IdRecord"].ToString());
                rAnt.Anno = dbPro.DataReader["Anno"].ToString();
                rAnt.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri"]);
                rAnt.ImportoSpesaPubblicaCorrispondenteRitiri = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteRitiri"]);
                rAnt.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi"]);
                rAnt.ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteRecuperi"]);
                ret.Add(rAnt);
            }
            dbPro.Close();

            return ret;
        }

        //FINE APPENDICE 2
        #endregion

        #region Appendice3
        //APPENDICE 3
        public class RigaAppendice3Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoTotaleAmmissibileSpese { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondente { get; set; }

            public RigaAppendice3Conti() { }
            public RigaAppendice3Conti(int idAsse)
            {
                IdAsse = idAsse;
                Asse = "Asse " + idAsse;
                this.ImportoTotaleAmmissibileSpese = ((decimal)(0m));
                this.ImportoSpesaPubblicaCorrispondente = ((decimal)(0m));
            }

            public RigaAppendice3Conti(int idAsse, string asse, decimal importoTotaleAmmissibileSpese, decimal importoSpesaPubblicaCorrispondente)
            {
                IdAsse = idAsse;
                Asse = asse;
                ImportoTotaleAmmissibileSpese = importoTotaleAmmissibileSpese;
                ImportoSpesaPubblicaCorrispondente = importoSpesaPubblicaCorrispondente;
            }

        }

        public List<RigaAppendice3Conti> GrigliaAppendice3Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice3Conti rAnt;
            List<RigaAppendice3Conti> ret = new List<RigaAppendice3Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE3";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice3Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["ID_ASSE"].ToString());
                rAnt.Asse = dbPro.DataReader["COD_ASSE"].ToString();
                rAnt.ImportoTotaleAmmissibileSpese = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpese"]);
                rAnt.ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondente"]);
                ret.Add(rAnt);
            }
            dbPro.Close();

            ret = RiempiGrigliaAppendice3Conti(ret);

            return ret;
        }

        public List<RigaAppendice3Conti> RiempiGrigliaAppendice3Conti(List<RigaAppendice3Conti> lista)
        {

            lista = lista
                .GroupBy(a => a.Asse).Select(b => new RigaAppendice3Conti
                {
                    IdAsse = b.First().IdAsse,
                    Asse = b.First().Asse,
                    ImportoTotaleAmmissibileSpese = b.Sum(c => c.ImportoTotaleAmmissibileSpese),
                    ImportoSpesaPubblicaCorrispondente = b.Sum(c => c.ImportoSpesaPubblicaCorrispondente),
                })
                .ToList<RigaAppendice3Conti>();

            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.IdAsse == i).Count() == 0)
                {
                    var nuova = new RigaAppendice3Conti(i);
                    lista.Add(nuova);
                }
            }
            return lista;
        }

        //DETTAGLIO 3

        public class RigaAppendice3ContiDettaglio : BaseObject
        {
            public int IdRecord { get; set; }
            public string Anno { get; set; }
            public bool FlagImportiRettificati { get; set; }
            public decimal ImportoTotaleAmmissibileSpese { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondente { get; set; }

            public RigaAppendice3ContiDettaglio()
            {
                IdRecord = 0;
                Anno = "";
                ImportoTotaleAmmissibileSpese = Convert.ToDecimal(0.00);
                ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(0.00);
            }

            public RigaAppendice3ContiDettaglio(int idRecord, string anno, decimal importoTotaleAmmissibileSpese, decimal importoSpesaPubblicaCorrispondente)
            {
                IdRecord = idRecord;
                Anno = anno;
                ImportoTotaleAmmissibileSpese = importoTotaleAmmissibileSpese;
                ImportoSpesaPubblicaCorrispondente = importoSpesaPubblicaCorrispondente;
            }

        }

        public List<RigaAppendice3ContiDettaglio> GrigliaAppendice3ContiDettaglio(DateTime dataLotto, string codPsr)
        {
            RigaAppendice3ContiDettaglio rAnt;
            List<RigaAppendice3ContiDettaglio> ret = new List<RigaAppendice3ContiDettaglio>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE3_DETTAGLIO";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice3ContiDettaglio();
                rAnt.IdRecord = Convert.ToInt32(dbPro.DataReader["IdRecord"].ToString());
                rAnt.Anno = dbPro.DataReader["Anno"].ToString();
                rAnt.ImportoTotaleAmmissibileSpese = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpese"]);
                rAnt.ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondente"]);
                ret.Add(rAnt);
            }
            dbPro.Close();

            return ret;
        }


        //FINE APPENDICE 3
        #endregion 

        #region Appendice4
        //APPENDICE 4
        public class RigaAppendice4Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoTotaleAmmissibileSpeseRecuperi { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondenteRecuperi { get; set; }

            public RigaAppendice4Conti() { }
            public RigaAppendice4Conti(int idAsse)
            {
                IdAsse = idAsse;
                Asse = "Asse " + idAsse;
                this.ImportoTotaleAmmissibileSpeseRecuperi = ((decimal)(0m));
                this.ImportoSpesaPubblicaCorrispondenteRecuperi = ((decimal)(0m));
            }

            public RigaAppendice4Conti(int idAsse, string asse, decimal importoTotaleAmmissibileSpeseRecuperi, decimal importoSpesaPubblicaCorrispondenteRecuperi)
            {
                IdAsse = idAsse;
                Asse = asse;
                ImportoTotaleAmmissibileSpeseRecuperi = ImportoTotaleAmmissibileSpeseRecuperi;
                ImportoSpesaPubblicaCorrispondenteRecuperi = importoSpesaPubblicaCorrispondenteRecuperi;
            }

        }

        public List<RigaAppendice4Conti> GrigliaAppendice4Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice4Conti rAnt;
            List<RigaAppendice4Conti> ret = new List<RigaAppendice4Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE4";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice4Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["ID_ASSE"].ToString());
                rAnt.Asse = dbPro.DataReader["COD_ASSE"].ToString();
                rAnt.ImportoTotaleAmmissibileSpeseRecuperi = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpeseRecuperi"]);
                rAnt.ImportoSpesaPubblicaCorrispondenteRecuperi = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteRecuperi"]);
                ret.Add(rAnt);
            }
            dbPro.Close();

            ret = RiempiGrigliaAppendice4Conti(ret);

            return ret;
        }

        public List<RigaAppendice4Conti> RiempiGrigliaAppendice4Conti(List<RigaAppendice4Conti> lista)
        {

            lista = lista
                .GroupBy(a => a.Asse).Select(b => new RigaAppendice4Conti
                {
                    IdAsse = b.First().IdAsse,
                    Asse = b.First().Asse,
                    ImportoTotaleAmmissibileSpeseRecuperi = b.Sum(c => c.ImportoTotaleAmmissibileSpeseRecuperi),
                    ImportoSpesaPubblicaCorrispondenteRecuperi = b.Sum(c => c.ImportoSpesaPubblicaCorrispondenteRecuperi),
                })
                .ToList<RigaAppendice4Conti>();

            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.IdAsse == i).Count() == 0)
                {
                    var nuova = new RigaAppendice4Conti(i);
                    lista.Add(nuova);
                }
            }
            return lista;
        }

        //DETTAGLIO 4

        public class RigaAppendice4ContiDettaglio : BaseObject
        {
            public int IdRecord { get; set; }
            public string Anno { get; set; }
            public bool FlagImportiRettificati { get; set; }
            public decimal ImportoTotaleAmmissibileSpese { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondente { get; set; }

            public RigaAppendice4ContiDettaglio()
            {
                IdRecord = 0;
                Anno = "";
                ImportoTotaleAmmissibileSpese = Convert.ToDecimal(0.00);
                ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(0.00);
            }

            public RigaAppendice4ContiDettaglio(int idRecord, string anno, decimal importoTotaleAmmissibileSpese, decimal importoSpesaPubblicaCorrispondente)
            {
                IdRecord = idRecord;
                Anno = anno;
                ImportoTotaleAmmissibileSpese = importoTotaleAmmissibileSpese;
                ImportoSpesaPubblicaCorrispondente = importoSpesaPubblicaCorrispondente;
            }

        }

        public List<RigaAppendice4ContiDettaglio> GrigliaAppendice4ContiDettaglio(DateTime dataLotto, string codPsr)
        {
            RigaAppendice4ContiDettaglio rAnt;
            List<RigaAppendice4ContiDettaglio> ret = new List<RigaAppendice4ContiDettaglio>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE4_DETTAGLIO";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice4ContiDettaglio();
                rAnt.IdRecord = Convert.ToInt32(dbPro.DataReader["IdRecord"].ToString());
                rAnt.Anno = dbPro.DataReader["Anno"].ToString();
                rAnt.ImportoTotaleAmmissibileSpese = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpese"]);
                rAnt.ImportoSpesaPubblicaCorrispondente = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondente"]);
                ret.Add(rAnt);
            }
            dbPro.Close();

            return ret;
        }

        //FINE APPENDICE 4
        #endregion

        #region Appendice5
        //APPENDICE 5
        public class RigaAppendice5Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoTotaleAmmissibileSpeseIrrecuperabili { get; set; }
            public decimal ImportoSpesaPubblicaCorrispondenteIrrecuperabili { get; set; }
            public string Osservazioni { get; set; }

            public RigaAppendice5Conti() { }
            public RigaAppendice5Conti(int idAsse)
            {
                IdAsse = idAsse;
                Asse = "Asse " + idAsse;
                this.ImportoTotaleAmmissibileSpeseIrrecuperabili = ((decimal)(0m));
                this.ImportoSpesaPubblicaCorrispondenteIrrecuperabili = ((decimal)(0m));
                Osservazioni = "";
            }

            public RigaAppendice5Conti(int idAsse, string asse, decimal importoTotaleAmmissibileSpeseIrrecuperabili, decimal importoSpesaPubblicaCorrispondenteIrrecuperabili, string osservazioni)
            {
                IdAsse = idAsse;
                Asse = asse;
                ImportoTotaleAmmissibileSpeseIrrecuperabili = importoTotaleAmmissibileSpeseIrrecuperabili;
                ImportoSpesaPubblicaCorrispondenteIrrecuperabili = importoSpesaPubblicaCorrispondenteIrrecuperabili;
                Osservazioni = osservazioni;
            }

        }

        public List<RigaAppendice5Conti> GrigliaAppendice5Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice5Conti rAnt;
            List<RigaAppendice5Conti> ret = new List<RigaAppendice5Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE5";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice5Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["IdAsse"].ToString());
                rAnt.Asse = dbPro.DataReader["Asse"].ToString();
                rAnt.ImportoTotaleAmmissibileSpeseIrrecuperabili = Convert.ToDecimal(dbPro.DataReader["ImportoTotaleAmmissibileSpeseIrrecuperabili"]);
                rAnt.ImportoSpesaPubblicaCorrispondenteIrrecuperabili = Convert.ToDecimal(dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteIrrecuperabili"]);
                rAnt.Osservazioni = dbPro.DataReader["ImportoSpesaPubblicaCorrispondenteRecuperi"].ToString();
                ret.Add(rAnt);
            }
            dbPro.Close();

            ret = RiempiGrigliaAppendice5Conti(ret);

            return ret;
        }

        public List<RigaAppendice5Conti> RiempiGrigliaAppendice5Conti(List<RigaAppendice5Conti> lista)
        {
            lista = lista
                .GroupBy(a => a.Asse).Select(b => new RigaAppendice5Conti
                {
                    IdAsse = b.First().IdAsse,
                    Asse = b.First().Asse,
                    ImportoTotaleAmmissibileSpeseIrrecuperabili = b.Sum(c => c.ImportoTotaleAmmissibileSpeseIrrecuperabili),
                    ImportoSpesaPubblicaCorrispondenteIrrecuperabili = b.Sum(c => c.ImportoSpesaPubblicaCorrispondenteIrrecuperabili),
                    Osservazioni = ""
                })
                .ToList<RigaAppendice5Conti>();

            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.IdAsse == i).Count() == 0)
                {
                    var nuova = new RigaAppendice5Conti(i);
                    lista.Add(nuova);
                }
            }
            return lista;
        }
        //FINE APPENDICE 5
        #endregion

        #region Appendice6
        //APPENDICE 6
        public class RigaAppendice6Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoErogatoContributiStrumentiFinanziari { get; set; }
            public decimal ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente { get; set; }
            public decimal ImportoErogatoSpesaStrumentiFinanziari { get; set; }
            public decimal ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente { get; set; }

            public RigaAppendice6Conti() { }

            public RigaAppendice6Conti(int numAsse)
            {
                IdAsse = IdAssePerNumeroAsse(numAsse);
                Asse = "Asse " + numAsse;
                ImportoErogatoContributiStrumentiFinanziari = Convert.ToDecimal(0.00);
                ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = Convert.ToDecimal(0.00);
                ImportoErogatoSpesaStrumentiFinanziari = Convert.ToDecimal(0.00);
                ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = Convert.ToDecimal(0.00);
            }

            public RigaAppendice6Conti(int numAsse, string asse, decimal importoErogatoContributiStrumentiFinanziari, decimal importoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente, decimal importoErogatoSpesaStrumentiFinanziari, decimal importoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente)
            {
                IdAsse = IdAssePerNumeroAsse(numAsse);
                Asse = "Asse " + numAsse;
                ImportoErogatoContributiStrumentiFinanziari = importoErogatoContributiStrumentiFinanziari;
                ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = importoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente;
                ImportoErogatoSpesaStrumentiFinanziari = importoErogatoSpesaStrumentiFinanziari;
                ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = importoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente;
            }

            private int IdAssePerNumeroAsse(int numAsse)
            {
                switch (numAsse)
                {
                    case 1: return numAsse;
                    case 2: return numAsse;
                    case 3: return numAsse;
                    case 4: return 41;
                    case 5: return 42;
                    case 6: return 43;
                    case 7: return 44;
                    case 8: return 217;
                    default: throw new Exception("Numero asse non valido!");
                }
            }
        }

        public List<RigaAppendice6Conti> GrigliaAppendice6Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice6Conti rAnt;
            List<RigaAppendice6Conti> ret = new List<RigaAppendice6Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE6";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice6Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["ID_ASSE"]);
                rAnt.Asse = "Asse " + dbPro.DataReader["COD_ASSE"].ToString();
                rAnt.ImportoErogatoContributiStrumentiFinanziari = Convert.ToDecimal(dbPro.DataReader["CONTRIBUTO_EROGATO_AGLI_STRUMENTI_FINANZIARI"]);
                rAnt.ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = Convert.ToDecimal(dbPro.DataReader["SPESA_PUBBLICA_CORRISPONDENTE_EROGATO"]);
                rAnt.ImportoErogatoSpesaStrumentiFinanziari = Convert.ToDecimal(dbPro.DataReader["CONTRIBUTO_EROGATO_IMPEGNATO_A_TITOLO_DI_SPESA_AMMISSIBILE"]);
                rAnt.ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = Convert.ToDecimal(dbPro.DataReader["SPESA_PUBBLICA_CORRISPONDENTE_IMPEGNATO"]);

                ret.Add(rAnt);
            }
            dbPro.Close();

            ret = RiempiGrigliaAppendice6Conti(ret);

            return ret;
        }

        public List<RigaAppendice6Conti> RiempiGrigliaAppendice6Conti(List<RigaAppendice6Conti> lista)
        {
            lista = lista
                .GroupBy(a => a.Asse).Select(b => new RigaAppendice6Conti
                {
                    IdAsse = b.First().IdAsse,
                    Asse = b.First().Asse,
                    ImportoErogatoContributiStrumentiFinanziari = b.Sum(c => c.ImportoErogatoContributiStrumentiFinanziari),
                    ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = b.Sum(c => c.ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente),
                    ImportoErogatoSpesaStrumentiFinanziari = b.Sum(c => c.ImportoErogatoSpesaStrumentiFinanziari),
                    ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = b.Sum(c => c.ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente)
                })
                .ToList<RigaAppendice6Conti>();

            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.Asse == "Asse " + i).Count() == 0)
                {
                    var nuova = new RigaAppendice6Conti(i);
                    lista.Add(nuova);
                }
            }

            return lista
                .OrderBy(a => a.IdAsse)
                .ToList<RigaAppendice6Conti>();
        }
        //FINE APPENDICE 6
        #endregion

        #region Appendice7
        //APPENDICE 7
        public class RigaAppendice7Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoComplessivoVersatoAnticipi { get; set; }
            public decimal ImportoCopertoAnticipiEntro { get; set; }
            public decimal ImportoNonCopertoAnticipiEntro { get; set; }

            public RigaAppendice7Conti() { }

            public RigaAppendice7Conti(int numAsse)
            {
                IdAsse = IdAssePerNumeroAsse(numAsse);
                Asse = "Asse " + numAsse;
                ImportoComplessivoVersatoAnticipi = Convert.ToDecimal(0.00);
                ImportoCopertoAnticipiEntro = Convert.ToDecimal(0.00);
                ImportoNonCopertoAnticipiEntro = Convert.ToDecimal(0.00);
            }

            public RigaAppendice7Conti(int numAsse, string asse, decimal importoComplessivoVersatoAnticipi, decimal importoCopertoAnticipiEntro, decimal importoNonCopertoAnticipiEntro)
            {
                IdAsse = IdAssePerNumeroAsse(numAsse);
                Asse = "Asse " + numAsse;
                ImportoComplessivoVersatoAnticipi = importoComplessivoVersatoAnticipi;
                ImportoCopertoAnticipiEntro = importoCopertoAnticipiEntro;
                ImportoNonCopertoAnticipiEntro = importoNonCopertoAnticipiEntro;
            }

            private int IdAssePerNumeroAsse(int numAsse)
            {
                switch (numAsse)
                {
                    case 1: return numAsse;
                    case 2: return numAsse;
                    case 3: return numAsse;
                    case 4: return 41;
                    case 5: return 42;
                    case 6: return 43;
                    case 7: return 44;
                    case 8: return 217;
                    default: throw new Exception("Numero asse non valido!");
                }
            }
        }

        public List<RigaAppendice7Conti> GrigliaAppendice7Conti(DateTime dataLotto, string codPsr)
        {
            RigaAppendice7Conti rAnt;
            List<RigaAppendice7Conti> ret = new List<RigaAppendice7Conti>();

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spAPPENDICE7_DETTAGLIO";
            cmd.Parameters.Add(new SqlParameter("@dataLotto", dataLotto));
            cmd.Parameters.Add(new SqlParameter("@codPsr", codPsr));
            dbPro.InitDatareader(cmd);
            while (dbPro.DataReader.Read())
            {
                rAnt = new RigaAppendice7Conti();
                rAnt.IdAsse = Convert.ToInt32(dbPro.DataReader["ID_ASSE"]);
                rAnt.Asse = "Asse " + dbPro.DataReader["COD_ASSE"].ToString();
                rAnt.ImportoComplessivoVersatoAnticipi = Convert.ToDecimal(dbPro.DataReader["IMPORTO_ANTICIPO"]);
                rAnt.ImportoCopertoAnticipiEntro = Convert.ToDecimal(dbPro.DataReader["IMPORTO_RECUPERO_ANTICIPO_ENTRO_TRE_ANNI"]);
                rAnt.ImportoNonCopertoAnticipiEntro = Convert.ToDecimal(dbPro.DataReader["IMPORTO_RECUPERO_ANTICIPO_OLTRE_TRE_ANNI"]);

                ret.Add(rAnt);
            }
            dbPro.Close();

            ret = RiempiGrigliaAppendice7Conti(ret);

            return ret;
        }

        public List<RigaAppendice7Conti> RiempiGrigliaAppendice7Conti(List<RigaAppendice7Conti> lista)
        {
            lista = lista
                .GroupBy(a => a.Asse).Select(b => new RigaAppendice7Conti
                {
                    IdAsse = b.First().IdAsse,
                    Asse = b.First().Asse,
                    ImportoComplessivoVersatoAnticipi = b.Sum(c => c.ImportoComplessivoVersatoAnticipi),
                    ImportoCopertoAnticipiEntro = b.Sum(c => c.ImportoCopertoAnticipiEntro),
                    ImportoNonCopertoAnticipiEntro = b.Sum(c => c.ImportoNonCopertoAnticipiEntro)
                })
                .ToList<RigaAppendice7Conti>();

            for (int i = 1; i < 9; i++)
            {
                if (lista.Where(p => p.Asse == "Asse " + i).Count() == 0)
                {
                    var nuova = new RigaAppendice7Conti(i);
                    lista.Add(nuova);
                }
            }

            return lista
                .OrderBy(a => a.IdAsse)
                .ToList<RigaAppendice7Conti>();
        }
        //FINE APPENDICE 7
        #endregion

        #region Appendice8
        //APPENDICE 8
        public class RigaAppendice8Conti : BaseObject
        {
            public int IdAsse { get; set; }
            public string Asse { get; set; }
            public decimal ImportoTotaleSpeseAmmissibiliBeneficiari { get; set; }
            public decimal ImportoTotaleSpesaPubblica { get; set; }
            public decimal ImportoTotaleSpeseAmmissibiliAdC { get; set; }
            public decimal ImportoTotaleSpesaPubblicaAdC { get; set; }
            public decimal DifferenzaSpesaAmmissibile { get; set; }
            public decimal DifferenzaSpesaPubblicaAdC { get; set; }
            public string Osservazioni { get; set; }
            public decimal DifferenzaSpesaAmmissibileAdA { get; set; }
            public decimal DifferenzaSpesaPubblicaAdCAdA { get; set; }

            public RigaAppendice8Conti() { }

            public RigaAppendice8Conti(int numAsse)
            {
                IdAsse = IdAssePerNumeroAsse(numAsse);
                Asse = "Asse " + numAsse;
                ImportoTotaleSpeseAmmissibiliBeneficiari = Convert.ToDecimal(0.00);
                ImportoTotaleSpesaPubblica = Convert.ToDecimal(0.00);
                ImportoTotaleSpeseAmmissibiliAdC = Convert.ToDecimal(0.00);
                ImportoTotaleSpesaPubblicaAdC = Convert.ToDecimal(0.00);
                DifferenzaSpesaAmmissibile = Convert.ToDecimal(0.00);
                DifferenzaSpesaPubblicaAdC = Convert.ToDecimal(0.00);
                Osservazioni = null;
                DifferenzaSpesaAmmissibileAdA = Convert.ToDecimal(0.00);
                DifferenzaSpesaPubblicaAdCAdA = Convert.ToDecimal(0.00);
            }

            private int IdAssePerNumeroAsse(int numAsse)
            {
                switch (numAsse)
                {
                    case 1: return numAsse;
                    case 2: return numAsse;
                    case 3: return numAsse;
                    case 4: return 41;
                    case 5: return 42;
                    case 6: return 43;
                    case 7: return 44;
                    case 8: return 217;
                    case 9: return 556;
                    default: throw new Exception("Numero asse non valido!");
                }
            }
        }

        public List<RigaAppendice8Conti> GrigliaAppendice8Conti(string codPsr, DateTime dataLotto, string istanzaCertificazioneConti)
        {
            List<RigaAppendice8Conti> ret = new List<RigaAppendice8Conti>();

            //Recupero le colonne dall'ultima certificazione presentata su SFC (fino a quella intermedia finale dell'anno contabile di riferimento)
            var soloDefinitivi = true;
            var complessivi = false;
            var datiCert = new CertspDettaglioCollectionProvider().GrigliaSpesa_Dati(codPsr, dataLotto, soloDefinitivi, complessivi);
            int assiCert = datiCert.Count();
            if (assiCert == 0)
                throw new Exception("Non ho trovato i dati della certificazione per il periodo contabile selezionato");

            //Recupero le colonne A, B, A_ADA e B_ADA dell'Appendice 1
            var datiApp1 = IstanzaCertificazioneConti.Deserialize(istanzaCertificazioneConti).TabellaAppendice1.RecordAppendice1;
            int assiContiAppendice1 = datiApp1.Count();
            if (datiApp1.Count() == 0)
                throw new Exception("Non ho trovato i dati dell'appendice 1");
            //Controllo rimosso dopo l'aggiunta dell'asse 9 e gestito sotto per evitare problemi con aggiunta di assi
            //if (assiCert != assiContiAppendice1)
            //    throw new Exception("Il numero di assi presenti in appendice 1 (" + assiContiAppendice1 + ") differisce dal numero di assi " +
            //        "presente in certificazione di spesa (" + assiCert + ")");

            //Recupero le osservazioni scritte fino ad adesso
            var datiApp8 = IstanzaCertificazioneConti.Deserialize(istanzaCertificazioneConti).TabellaAppendice8.RecordAppendice8;
            if (datiApp8.Count() == 0)
                throw new Exception("Non ho trovato i dati dell'appendice 8");

            for (int i = 1; i <= Math.Max(assiCert, assiContiAppendice1); i ++)
            {
                RigaAppendice8Conti newRiga = new RigaAppendice8Conti(i);
                CertspDettaglioCollectionProvider.RigaSpesa rigaCert = datiCert
                    .Where(c => c.Asse == i.ToString())
                    .FirstOrDefault();
                RecordAppendice1Type rigaApp1 = datiApp1
                    .Where(a => a.Asse == "Asse " + i)
                    .FirstOrDefault();

                //Colonna A
                newRiga.ImportoTotaleSpeseAmmissibiliBeneficiari = rigaCert != null 
                    ? rigaCert.ImportoContributo 
                    : 0;

                //Colonna B
                newRiga.ImportoTotaleSpesaPubblica = rigaCert != null 
                    ? rigaCert.ImportoContributo 
                    : 0;

                //Colonna C
                newRiga.ImportoTotaleSpeseAmmissibiliAdC = rigaApp1.ImportoTotaleSpeseAdCToCommissione != null
                    ? rigaApp1.ImportoTotaleSpeseAdCToCommissione
                    : 0;

                //Colonna D
                newRiga.ImportoTotaleSpesaPubblicaAdC = rigaApp1.ImportoTotaleSpesaPubblica != null
                    ? rigaApp1.ImportoTotaleSpesaPubblica
                    : 0;

                //Colonna E = A - C
                newRiga.DifferenzaSpesaAmmissibile = newRiga.ImportoTotaleSpeseAmmissibiliBeneficiari - newRiga.ImportoTotaleSpeseAmmissibiliAdC;

                //Colonna F = B - D
                newRiga.DifferenzaSpesaPubblicaAdC = newRiga.ImportoTotaleSpesaPubblica - newRiga.ImportoTotaleSpesaPubblicaAdC;

                //Colonna E AdA
                newRiga.DifferenzaSpesaAmmissibileAdA = rigaApp1.ImportoTotaleSpeseAdCToCommissioneAdA;

                //Colonna F AdA
                newRiga.DifferenzaSpesaPubblicaAdCAdA = rigaApp1.ImportoTotaleSpesaPubblicaAdA;

                //Osservazioni
                newRiga.Osservazioni = datiApp8
                    .Where(a => a.Asse == "Asse " + i)
                    .FirstOrDefault()
                    .Osservazioni;

                ret.Add(newRiga);
            }

            return ret;
        }
        //FINE APPENDICE 8
        #endregion

        public string GeneraIstanzaCalcolata(string codPsr, CertificazioneConti cert)
        {
            var xmlCert = cert.IstanzaCertificazioneConti;
            var istanza = IstanzaCertificazioneConti.Deserialize(xmlCert);
            //Faccio il clone dell'istanza che andrò a modificare per evitare modifiche sull'originale
            var istanza_clone = istanza.Clone();
            
            try
            {
                //Modifico i dati dell'appendice 1 
                var rec1_list = istanza_clone.TabellaAppendice1.RecordAppendice1;
                var rec1_list_calcolata = GrigliaAppendice1Conti(cert.AnnoContabileA, codPsr);

                for (int i = 0; i < rec1_list.Count(); i++)
                {
                    rec1_list[i].ImportoTotaleSpeseAdCToCommissione = rec1_list_calcolata[i].ImportoA;
                    rec1_list[i].ImportoTotaleSpesaPubblica = rec1_list_calcolata[i].ImportoB;
                    rec1_list[i].ImportoTotaleSpesaPubblicaErogataBeneficiari = rec1_list_calcolata[i].ImportoC;
                }

                //Modifico i dati dell'appendice 2
                var rec2_list = istanza_clone.TabellaAppendice2.RecordAppendice2;
                var rec2_list_calcolata = GrigliaAppendice2Conti(cert.AnnoContabileA, cert.CodPsr);

                for (int i = 0; i < rec2_list.Count(); i++)
                {
                    rec2_list[i].ImportoSpesaPubblicaCorrispondenteRecuperi = rec2_list_calcolata[i].ImportoSpesaPubblicaCorrispondenteRecuperi;
                    rec2_list[i].ImportoSpesaPubblicaCorrispondenteRitiri = rec2_list_calcolata[i].ImportoSpesaPubblicaCorrispondenteRitiri;
                    rec2_list[i].ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = rec2_list_calcolata[i].ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi;
                    rec2_list[i].ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = rec2_list_calcolata[i].ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri;
                }

                var rec2_dett_list = istanza_clone.TabellaDettaglioAppendice2.RecordDettaglioAppendice2;
                var rec2_dett_list_calcolata = GrigliaAppendice2ContiDettaglio(cert.AnnoContabileA, cert.CodPsr);

                if (rec2_dett_list_calcolata.Count > 0)
                {
                    foreach (var riga_istanza in rec2_dett_list)
                    {
                        riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri = 0;
                        riga_istanza.ImportoSpesaPubblicaCorrispondenteRitiri = 0;
                        riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi = 0;
                        riga_istanza.ImportoSpesaPubblicaCorrispondenteRecuperi = 0;
                    }
                    foreach (var dAppendice2_record in rec2_dett_list_calcolata)
                    {
                        foreach (var riga_istanza in rec2_dett_list)
                        {
                            if (riga_istanza.FlagImportiRettificati == false && riga_istanza.Anno == dAppendice2_record.Anno)
                            {
                                riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri += dAppendice2_record.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRitiri;
                                riga_istanza.ImportoSpesaPubblicaCorrispondenteRitiri += dAppendice2_record.ImportoSpesaPubblicaCorrispondenteRitiri;
                                riga_istanza.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi += dAppendice2_record.ImportoTotaleAmmissibileSpeseIncluseDomPagamentoRecuperi;
                                riga_istanza.ImportoSpesaPubblicaCorrispondenteRecuperi += dAppendice2_record.ImportoSpesaPubblicaCorrispondenteRecuperi;
                            }
                        }
                    }
                }

                //Modifico i dati dell'appendice 3 
                var rec3_list = istanza_clone.TabellaAppendice3.RecordAppendice3;
                var rec3_list_calcolata = GrigliaAppendice3Conti(cert.AnnoContabileA, cert.CodPsr);

                for (int i = 0; i < rec3_list.Count(); i++)
                {
                    rec3_list[i].ImportoSpesaPubblicaCorrispondente = rec3_list_calcolata[i].ImportoSpesaPubblicaCorrispondente;
                    rec3_list[i].ImportoTotaleAmmissibileSpese = rec3_list_calcolata[i].ImportoTotaleAmmissibileSpese;
                }

                var rec3_dett_list = istanza_clone.TabellaDettaglioAppendice3.RecordDettaglioAppendice3;
                var rec3_dett_list_calcolata = GrigliaAppendice3ContiDettaglio(cert.AnnoContabileA, cert.CodPsr);

                if (rec3_dett_list_calcolata.Count > 0)
                {
                    foreach (var riga_istanza in rec3_dett_list)
                    {
                        riga_istanza.ImportoTotaleAmmissibileSpese = 0;
                        riga_istanza.ImportoSpesaPubblicaCorrispondente = 0;
                    }
                    foreach (var dAppendice3_record in rec3_dett_list_calcolata)
                    {
                        foreach (var riga_istanza in rec3_dett_list)
                        {
                            if (riga_istanza.FlagImportiRettificati == false && riga_istanza.Anno == dAppendice3_record.Anno)
                            {
                                riga_istanza.ImportoTotaleAmmissibileSpese += dAppendice3_record.ImportoTotaleAmmissibileSpese;
                                riga_istanza.ImportoSpesaPubblicaCorrispondente = dAppendice3_record.ImportoSpesaPubblicaCorrispondente;
                            }
                        }
                    }
                }

                //Modifico i dati dell'appendice 4 
                var rec4_list = istanza_clone.TabellaAppendice4.RecordAppendice4;
                var rec4_list_calcolata = GrigliaAppendice4Conti(cert.AnnoContabileA, cert.CodPsr);

                for (int i = 0; i < rec3_list.Count(); i++)
                {
                    rec4_list[i].ImportoSpesaPubblicaCorrispondenteRecuperi = rec4_list_calcolata[i].ImportoSpesaPubblicaCorrispondenteRecuperi;
                    rec4_list[i].ImportoTotaleAmmissibileSpeseRecuperi = rec4_list_calcolata[i].ImportoTotaleAmmissibileSpeseRecuperi;
                }

                var rec4_dett_list = istanza_clone.TabellaDettaglioAppendice4.RecordDettaglioAppendice4;
                var rec4_dett_list_calcolata = GrigliaAppendice4ContiDettaglio(cert.AnnoContabileA, cert.CodPsr);

                if (rec4_dett_list_calcolata.Count > 0)
                {
                    foreach (var riga_istanza in rec4_dett_list)
                    {
                        riga_istanza.ImportoTotaleAmmissibileSpese = 0;
                        riga_istanza.ImportoSpesaPubblicaCorrispondente = 0;
                    }
                    foreach (var dAppendice4_record in rec4_dett_list_calcolata)
                    {
                        foreach (var riga_istanza in rec4_dett_list)
                        {
                            if (riga_istanza.FlagImportiRettificati == false && riga_istanza.Anno == dAppendice4_record.Anno)
                            {
                                riga_istanza.ImportoTotaleAmmissibileSpese += dAppendice4_record.ImportoTotaleAmmissibileSpese;
                                riga_istanza.ImportoSpesaPubblicaCorrispondente += dAppendice4_record.ImportoSpesaPubblicaCorrispondente;
                            }
                        }
                    }
                }

                //Modifico i dati dell'appendice 5 
                var rec5_list = istanza_clone.TabellaAppendice5.RecordAppendice5;
                var rec5_list_calcolata = GrigliaAppendice5Conti(cert.AnnoContabileA, cert.CodPsr);

                for (int i = 0; i < rec3_list.Count(); i++)
                {
                    rec5_list[i].ImportoSpesaPubblicaCorrispondenteIrrecuperabili = rec5_list_calcolata[i].ImportoSpesaPubblicaCorrispondenteIrrecuperabili;
                    rec5_list[i].ImportoTotaleAmmissibileSpeseIrrecuperabili = rec5_list_calcolata[i].ImportoTotaleAmmissibileSpeseIrrecuperabili;
                    rec5_list[i].Osservazioni = rec5_list_calcolata[i].Osservazioni;
                }

                //Modifico i dati dell'appendice 6
                var rec6_list = istanza_clone.TabellaAppendice6.RecordAppendice6;
                var rec6_list_calcolata = GrigliaAppendice6Conti(cert.AnnoContabileA, cert.CodPsr);

                for (int i = 0; i < rec6_list.Count(); i++)
                {
                    rec6_list[i].ImportoErogatoContributiStrumentiFinanziari = rec6_list_calcolata[i].ImportoErogatoContributiStrumentiFinanziari;
                    rec6_list[i].ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente = rec6_list_calcolata[i].ImportoErogatoContributiStrumentiFinanziariSpesaPubblicaCorrispondente;
                    rec6_list[i].ImportoErogatoSpesaStrumentiFinanziari = rec6_list_calcolata[i].ImportoErogatoSpesaStrumentiFinanziari;
                    rec6_list[i].ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente = rec6_list_calcolata[i].ImportoErogatoSpesaStrumentiFinanziariSpesaPubblicaCorrispondente;
                }

                //Modifico i dati dell'appendice 7
                var rec7_list = istanza_clone.TabellaAppendice7.RecordAppendice7;
                var rec7_list_calcolata = GrigliaAppendice7Conti(cert.AnnoContabileA, cert.CodPsr);
                for (int i = 0; i < rec7_list.Count(); i++)
                {
                    rec7_list[i].ImportoComplessivoVersatoAnticipi = rec7_list_calcolata[i].ImportoComplessivoVersatoAnticipi;
                    rec7_list[i].ImportoCopertoAnticipiEntro = rec7_list_calcolata[i].ImportoCopertoAnticipiEntro;
                    rec7_list[i].ImportoNonCopertoAnticipiEntro = rec7_list_calcolata[i].ImportoNonCopertoAnticipiEntro;
                }

                //Modifico i dati dell'appendice 8
                var rec8_list = istanza_clone.TabellaAppendice8.RecordAppendice8;
                var rec8_list_calcolata = GrigliaAppendice8Conti(codPsr, cert.AnnoContabileA, cert.IstanzaCertificazioneConti);
                for (int i = 0; i < rec8_list.Count(); i++)
                {
                    rec8_list[i].DifferenzaSpesaAmmissibile = rec8_list_calcolata[i].DifferenzaSpesaAmmissibile;
                    rec8_list[i].DifferenzaSpesaPubblicaAdC = rec8_list_calcolata[i].DifferenzaSpesaPubblicaAdC;
                    rec8_list[i].ImportoTotaleSpesaPubblica = rec8_list_calcolata[i].ImportoTotaleSpesaPubblica;
                    rec8_list[i].ImportoTotaleSpesaPubblicaAdC = rec8_list_calcolata[i].ImportoTotaleSpesaPubblicaAdC;
                    rec8_list[i].ImportoTotaleSpeseAmmissibiliAdC = rec8_list_calcolata[i].ImportoTotaleSpeseAmmissibiliAdC;
                    rec8_list[i].ImportoTotaleSpeseAmmissibiliBeneficiari = rec8_list_calcolata[i].ImportoTotaleSpeseAmmissibiliBeneficiari;
                    rec8_list[i].Osservazioni = rec8_list_calcolata[i].Osservazioni;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return istanza_clone.Serialize();
        }
    }
}

