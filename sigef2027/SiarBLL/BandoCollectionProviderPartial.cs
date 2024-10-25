using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class BandoCollectionProvider : IBandoProvider
    {
        //public BandoCollection GetDisposizioniAttuative(IntNT IdBando)
        //{
        //    BandoCollection disposizioni_attuative = new BandoCollection();
        //    System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
        //    cmd.CommandType = System.Data.CommandType.Text;
        //    cmd.CommandText = @"SELECT DISTINCT B.* FROM BANDO_PROGRAMMAZIONE P INNER JOIN VBANDO B ON P.ID_DISPOSIZIONI_ATTUATIVE=B.ID_BANDO WHERE MISURA_PREVALENTE=0 AND P.ID_BANDO=" + IdBando;
        //    DbProviderObj.InitDatareader(cmd);
        //    while (DbProviderObj.DataReader.Read())
        //        disposizioni_attuative.Add(SiarDAL.BandoDAL.GetFromDatareader(DbProviderObj));
        //    DbProviderObj.Close();
        //    return disposizioni_attuative;
        //}

        public BandoCollection RicercaBando(string cod_ente, IntNT IdProgrammazione, DatetimeNT DataScadenzaLeq,
            string numero_atto, DatetimeNT DataAtto, /*string parole_chiave,*/ bool nascondi_bandi_scaduti, bool bandi_pubblici, string order_by)
        {
            //string condizione_ricerca_parole_chiave = "";
            //if (parole_chiave != null)
            //    foreach (string s in parole_chiave.Split(' ')) condizione_ricerca_parole_chiave += " AND PAROLE_CHIAVE LIKE '%" + s + "%'";

            BandoCollection bandi = new BandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaBandi";
            if (!string.IsNullOrEmpty(cod_ente)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE", cod_ente));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (DataScadenzaLeq != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_SCADENZA_LEQ", DataScadenzaLeq.Value));
            if (!string.IsNullOrEmpty(numero_atto)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_ATTO", numero_atto));
            if (DataAtto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_ATTO", DataAtto.Value));
            if (!string.IsNullOrEmpty(order_by)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ORDER_BY", order_by));

            //cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAROLE_CHIAVE", parole_chiave));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NASCONDI_SCADUTI", nascondi_bandi_scaduti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MOSTRA_PUBBLICATI", bandi_pubblici));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.Bando b = SiarDAL.BandoDAL.GetFromDatareader(DbProviderObj);
                b.AdditionalAttributes.Add("NumeroAtto", new StringNT(DbProviderObj.DataReader["NUMERO_ATTO"]));
                b.AdditionalAttributes.Add("DataAtto", new DatetimeNT(DbProviderObj.DataReader["DATA_ATTO"]));
                bandi.Add(b);
            }
            DbProviderObj.Close();
            return bandi;
        }

        public BandoCollection RicercaBandoCovid(string cod_ente, IntNT IdProgrammazione, DatetimeNT DataScadenzaLeq,
            string numero_atto, DatetimeNT DataAtto, /*string parole_chiave,*/ bool nascondi_bandi_scaduti, bool bandi_pubblici)
        {
            //string condizione_ricerca_parole_chiave = "";
            //if (parole_chiave != null)
            //    foreach (string s in parole_chiave.Split(' ')) condizione_ricerca_parole_chiave += " AND PAROLE_CHIAVE LIKE '%" + s + "%'";

            BandoCollection bandi = new BandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaBandiCovid";
            if (!string.IsNullOrEmpty(cod_ente)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE", cod_ente));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (DataScadenzaLeq != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_SCADENZA_LEQ", DataScadenzaLeq.Value));
            if (!string.IsNullOrEmpty(numero_atto)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_ATTO", numero_atto));
            if (DataAtto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_ATTO", DataAtto.Value));

            //cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAROLE_CHIAVE", parole_chiave));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NASCONDI_SCADUTI", nascondi_bandi_scaduti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MOSTRA_PUBBLICATI", bandi_pubblici));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.Bando b = SiarDAL.BandoDAL.GetFromDatareader(DbProviderObj);
                b.AdditionalAttributes.Add("NumeroAtto", new StringNT(DbProviderObj.DataReader["NUMERO_ATTO"]));
                b.AdditionalAttributes.Add("DataAtto", new DatetimeNT(DbProviderObj.DataReader["DATA_ATTO"]));
                bandi.Add(b);
            }
            DbProviderObj.Close();
            return bandi;
        }


        public BandoCollection RicercaBandoCovidPreDomanda(string cod_ente, IntNT IdProgrammazione, DatetimeNT DataScadenzaLeq,
            string numero_atto, DatetimeNT DataAtto, /*string parole_chiave,*/ bool nascondi_bandi_scaduti, bool bandi_pubblici)
        {
            //string condizione_ricerca_parole_chiave = "";
            //if (parole_chiave != null)
            //    foreach (string s in parole_chiave.Split(' ')) condizione_ricerca_parole_chiave += " AND PAROLE_CHIAVE LIKE '%" + s + "%'";

            BandoCollection bandi = new BandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaBandiCovidPreDomanda";
            if (!string.IsNullOrEmpty(cod_ente)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE", cod_ente));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (DataScadenzaLeq != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_SCADENZA_LEQ", DataScadenzaLeq.Value));
            if (!string.IsNullOrEmpty(numero_atto)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_ATTO", numero_atto));
            if (DataAtto != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_ATTO", DataAtto.Value));

            //cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PAROLE_CHIAVE", parole_chiave));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NASCONDI_SCADUTI", nascondi_bandi_scaduti));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MOSTRA_PUBBLICATI", bandi_pubblici));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.Bando b = SiarDAL.BandoDAL.GetFromDatareader(DbProviderObj);
                b.AdditionalAttributes.Add("NumeroAtto", new StringNT(DbProviderObj.DataReader["NUMERO_ATTO"]));
                b.AdditionalAttributes.Add("DataAtto", new DatetimeNT(DbProviderObj.DataReader["DATA_ATTO"]));
                bandi.Add(b);
            }
            DbProviderObj.Close();
            return bandi;
        }


        public bool HasCovidNoCalcoloPredomanda(IntNT id_bando)
        {
            string sSql;
            bool ris = false;

            sSql = string.Format(@"SELECT Count(B.ID_BANDO) AS cont
                                    FROM 
                                    BANDO B
                                    INNER JOIN
                                    BANDO_CONFIG BC ON
                                    B.ID_BANDO = BC.ID_BANDO
                                    WHERE 
                                    B.ID_BANDO = {0}
                                    AND
                                    BC.COD_TIPO = 'BCOVID_NOCALCOLO' 
                                    AND
                                    BC.ATTIVO = 1
                                    AND
                                    BC.VALORE = 'True'", id_bando);
                                     


            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sSql;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                int cont = new IntNT(DbProviderObj.DataReader["cont"]);
                if (cont > 0)
                {
                    ris = true;
                }
            }
            DbProviderObj.Close();
            return ris;
        }

        public bool HasCovidNoLocalizazione(IntNT id_bando)
        {
            string sSql;
            bool ris = false;

            sSql = string.Format(@"SELECT Count(B.ID_BANDO) AS cont
                                    FROM 
                                    BANDO B
                                    INNER JOIN
                                    BANDO_CONFIG BC ON
                                    B.ID_BANDO = BC.ID_BANDO
                                    WHERE 
                                    B.ID_BANDO = {0}
                                    AND
                                    BC.COD_TIPO = 'BCOVID_NOLOCALIZZAZIONE' 
                                    AND
                                    BC.ATTIVO = 1
                                    AND
                                    BC.VALORE = 'True'", id_bando);



            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sSql;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                int cont = new IntNT(DbProviderObj.DataReader["cont"]);
                if (cont > 0)
                {
                    ris = true;
                }
            }
            DbProviderObj.Close();
            return ris;
        }

        public BandoCollection ElencoBandiCovid(IntNT id_utente_rup)
        {
            BandoCollection bandi = new BandoCollection();
            string sSql;
            bool ris = false;

            sSql = string.Format(@"SELECT B.*
                                    FROM  VBANDO B                                    
                                    INNER JOIN BANDO_CONFIG BC ON B.ID_BANDO = BC.ID_BANDO
                                    LEFT OUTER JOIN  BANDO_RESPONSABILI BR ON BR.ID_BANDO = B.ID_BANDO AND BR.PROVINCIA IS NULL AND BR.ATTIVO = 1
                                    WHERE 
                                    BC.COD_TIPO = 'BANDOCOVID' 
                                    AND
                                    BC.ATTIVO = 1
                                    AND
                                    BC.VALORE = 'True'
                                    AND 
                                    ( 0 = {0} OR BR.ID_UTENTE =  {0} )", id_utente_rup);

            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sSql;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Bando b = BandoDAL.GetFromDatareader(DbProviderObj);
                bandi.Add(b);
            }
            DbProviderObj.Close();
            return bandi;
        }

        public BandoCollection RicercaBandiImpresa(int id_impresa, string cod_ente, IntNT IdProgrammazione, DatetimeNT DataScadenzaLeq, bool adesioni)
        {
            BandoCollection bandi = new BandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRicercaBandiImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", id_impresa));
            if (!string.IsNullOrEmpty(cod_ente)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_ENTE", cod_ente));
            if (IdProgrammazione != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGRAMMAZIONE", IdProgrammazione.Value));
            if (DataScadenzaLeq != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_SCADENZA_LEQ", DataScadenzaLeq.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ADESIONI", adesioni));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Bando b = BandoDAL.GetFromDatareader(DbProviderObj);
                b.AdditionalAttributes.Add("NR_PROGETTI", new IntNT(DbProviderObj.DataReader["NR_PROGETTI"]));
                b.AdditionalAttributes.Add("ID_PROGETTO", new IntNT(DbProviderObj.DataReader["ID_PROGETTO"]));
                b.AdditionalAttributes.Add("COD_STATO_PROGETTO", new StringNT(DbProviderObj.DataReader["COD_STATO_PROGETTO"]));
                b.AdditionalAttributes.Add("STATO_PROGETTO", new StringNT(DbProviderObj.DataReader["STATO_PROGETTO"]));
                b.AdditionalAttributes.Add("ORDINE_FASE_PROGETTO", new IntNT(DbProviderObj.DataReader["ORDINE_FASE_PROGETTO"]));
                b.AdditionalAttributes.Add("ORDINE_STATO_PROGETTO", new IntNT(DbProviderObj.DataReader["ORDINE_STATO_PROGETTO"]));
                b.AdditionalAttributes.Add("FLAG_PREADESIONE", new BoolNT(DbProviderObj.DataReader["FLAG_PREADESIONE"]));
                bandi.Add(b);
            }
            DbProviderObj.Close();
            return bandi;
        }

        public BandoStoricoCollection GetStoricoDocumentale(int id_bando)
        {
            BandoStoricoCollection cc = new BandoStoricoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDocumentiBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                cc.Add(SiarDAL.BandoStoricoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }

        public int GetDomandePresentate(SiarLibrary.NullTypes.IntNT idBando)
        {
            int numero_domande = 0;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoBandi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", idBando.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "DOMANDE_PRESENTATE"));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int.TryParse(result.ToString(), out numero_domande);
            return numero_domande;
        }

        public int GetDomandeNonAssegnate(SiarLibrary.NullTypes.IntNT idBando)
        {
            int numero_domande = 0;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoBandi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", idBando.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "DOMANDE_NON_ASSEGNATE"));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int.TryParse(result.ToString(), out numero_domande);
            return numero_domande;
        }

        public int GetManifestazioniPresentate(SiarLibrary.NullTypes.IntNT idBando)
        {
            int numero_domande = 0;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpRiepilogoBandi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", idBando.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_QUERY", "MANIFESTAZIONI_PRESENTATE"));
            object result = DbProviderObj.ExecuteScalar(cmd);
            DbProviderObj.Close();
            int.TryParse(result.ToString(), out numero_domande);
            return numero_domande;
        }

        public string[] GetDatiXProtocollazione(int id_bando, string provincia)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDatiBandoXProtocollazione";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            if (!string.IsNullOrEmpty(provincia)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PROVINCIA", provincia));
            DbProviderObj.InitDatareader(cmd);
            string[] ss = null;
            if (DbProviderObj.DataReader.Read())
            {
                ss = new string[5];
                ss[0] = new IntNT(DbProviderObj.DataReader["NUMERO"]);
                ss[1] = new DatetimeNT(DbProviderObj.DataReader["DATA"]);
                ss[2] = new DatetimeNT(DbProviderObj.DataReader["DATA_SCADENZA"]);
                ss[3] = new StringNT(DbProviderObj.DataReader["PROGRAMMAZIONE"]);
                ss[4] = new StringNT(DbProviderObj.DataReader["FASCICOLO"]);
            }
            else throw new Exception("Non sono presenti i riferimenti necessari alla protocollazione del documento, impossibile continuare.");
            return ss;
        }

        public string[] GetFascicolo(int id_bando)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetFascicolo";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            string[] ss = null;
            if (DbProviderObj.DataReader.Read())
            {
                ss = new string[2];
                ss[0] = new IntNT(DbProviderObj.DataReader["ID"]);
                ss[1] = new StringNT(DbProviderObj.DataReader["FASCICOLO"]);
            }
            else
            {
                ss = new string[2];
                 ss[0] = null;
                 ss[1] = null;
            }
            DbProviderObj.Close();
            return ss;
        }


        public string VerificaCondizioniPubblicazioneBando(IntNT IdBando)
        {
            int cod_risultato = 0;
            string messaggio = null;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrVerificaCondizioniPubblicazioneBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", IdBando.Value));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                cod_risultato = new IntNT(DbProviderObj.DataReader["RETVAL"]);
                messaggio = new StringNT(DbProviderObj.DataReader["ERRORE"]);
            }
            DbProviderObj.Close();  
            if (cod_risultato == 2) throw new Exception(messaggio);
            return messaggio;
        }

        public Bando RiapriBando(int idBando, int id_utente)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrRiapriBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", idBando));   
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_UTENTE", id_utente));

            System.Data.SqlClient.SqlParameter id_Bando_new_out = new System.Data.SqlClient.SqlParameter("ID_BANDO_NEW_OUT", System.Data.SqlDbType.Int);
            id_Bando_new_out.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(id_Bando_new_out);
            System.Data.SqlClient.SqlParameter mess_out = new System.Data.SqlClient.SqlParameter("MESS_OUT", System.Data.SqlDbType.VarChar);
            mess_out.Size = 200;
            mess_out.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(mess_out);
            DbProviderObj.Execute(cmd);
            DbProviderObj.Close();
            if (mess_out.Value != null && mess_out.Value.ToString() != "") throw new Exception(mess_out.Value.ToString());
            int id_bando_new;
            Bando b = null;
            if (id_Bando_new_out.Value != null && int.TryParse(id_Bando_new_out.Value.ToString(), out id_bando_new ))
                b = GetById(id_bando_new);
            if (b == null) throw new Exception("Non è stato possibile riaprire il bando, si prega riprovare.");
            return b;
        }

        public ProgettoCollection GetStatisticheProgetti(int id_bando)
        {
            ProgettoCollection cc=new ProgettoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetStatisticheProgetti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                Progetto p = new Progetto();
                p.IdProgetto = new IntNT(DbProviderObj.DataReader["NR_DOMANDE"]);
                p.CodStato = new StringNT(DbProviderObj.DataReader["COD_STATO"]);
                p.Stato = new StringNT(DbProviderObj.DataReader["STATO"]);
                p.CodFase = new StringNT(DbProviderObj.DataReader["COD_FASE"]);
                p.Fase = new StringNT(DbProviderObj.DataReader["FASE"]);
                cc.Add(p);
            }
            return cc;
        }

        public bool IsFesr(int id_bando)
        {
            string sSql;
            bool ris = false;

            sSql = string.Format(@"SELECT Count(1) AS cont
                                   FROM Bando_Programmazione bnd
                                        INNER JOIN
                                        zProgrammazione prg ON bnd.Id_Programmazione = prg.Id
                                        INNER JOIN
                                        zPsr_Albero alb ON prg.Cod_Tipo = alb.Codice
                                   WHERE (alb.cod_Psr = 'POR20142020' OR alb.cod_Psr = 'PORFESR20212027') 
                                     AND bnd.Id_Bando = {0}", id_bando);


            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sSql;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                int cont = new IntNT(DbProviderObj.DataReader["cont"]);
                if (cont > 0)
                {
                    ris = true;
                }
            }
            DbProviderObj.Close();
            return ris;
        }

        public bool HasCodiceAttivazione(int id_bando, string cod_programma)
        {
            string sSql;
            bool ris = false;

            sSql = string.Format(@"SELECT Count(1) AS cont
                                   FROM Bando_Programmazione bnd
                                        INNER JOIN
                                        zProgrammazione prg ON bnd.Id_Programmazione = prg.Id
                                        INNER JOIN
                                        zPsr_Albero alb ON prg.Cod_Tipo = alb.Codice
                                   WHERE alb.cod_Psr = '{0}'
                                     AND bnd.Id_Bando = {1}", cod_programma, id_bando);


            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sSql;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                int cont = new IntNT(DbProviderObj.DataReader["cont"]);
                if (cont > 0)
                {
                    ris = true;
                }
            }
            DbProviderObj.Close();
            return ris;
        }

        public BandoCollection RicercaBandoFiltraDescrizione(string Descrizione, DatetimeNT DataScadenzaMinore,
            DatetimeNT DataScadenzaMaggiore,string ParolaChiave, string  Idbando)
        {
            BandoCollection bandi = new BandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM vBANDO WHERE 1=1 ";
            if (!string.IsNullOrEmpty(Descrizione)) cmd.CommandText += " AND DESCRIZIONE LIKE '%" + Descrizione + "%' ";
            if (!string.IsNullOrEmpty(Idbando)) cmd.CommandText += " AND ID_BANDO = " + Idbando;
            if (!string.IsNullOrEmpty(ParolaChiave)) cmd.CommandText += " AND PAROLE_CHIAVE LIKE '%" + ParolaChiave + "%' ";
            if (DataScadenzaMinore != null) cmd.CommandText += " AND DATA_SCADENZA <=CONVERT(DATE , '" + DataScadenzaMinore.ToString() + "',103) ";
            if (DataScadenzaMaggiore != null) cmd.CommandText += " AND DATA_SCADENZA >= CONVERT(DATE , '" + DataScadenzaMaggiore.ToString() + "',103) ";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SiarLibrary.Bando b = SiarDAL.BandoDAL.GetFromDatareader(DbProviderObj);
                b.IdBando = new IntNT(DbProviderObj.DataReader["ID_BANDO"]);
                b.Descrizione = new StringNT(DbProviderObj.DataReader["DESCRIZIONE"]);
                b.CodEnte = new StringNT(DbProviderObj.DataReader["COD_ENTE"]);
                b.ParoleChiave = new StringNT(DbProviderObj.DataReader["PAROLE_CHIAVE"]);
                b.DataScadenza = new DatetimeNT(DbProviderObj.DataReader["DATA_SCADENZA"]);
                bandi.Add(b);
            }
            DbProviderObj.Close();
            return bandi;

        }

        public StringNT GetCodAttivazioneBando(int idBando) 
        {
            string sSql;
            StringNT ris = null;
            sSql = string.Format(@"SELECT COD_PROCEDURA_ATTIVAZIONE FROM BANDO_CODICI_ATTIVAZIONE WHERE ID_BANDO = {0}", idBando);

            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sSql;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ris = new StringNT(DbProviderObj.DataReader["COD_PROCEDURA_ATTIVAZIONE"]);
            }
            DbProviderObj.Close();
            return ris;
        }

        public BandoCollection getBandiDefinitiviSenzaDecreto(int id_utente)
        {
            BandoCollection bandi = new BandoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT DISTINCT BAN.*
                                FROM VBANDO BAN 
	                                JOIN GRADUATORIA_PROGETTI GRAD ON GRAD.ID_BANDO = BAN.ID_BANDO 
	                                JOIN GRADUATORIA_PROGETTI_ATTI ATT ON BAN.ID_BANDO = ATT.ID_BANDO  
                                    JOIN vBANDO_RESPONSABILI RESP ON BAN.ID_BANDO = RESP.ID_BANDO 
                                WHERE 1 = 1 
	                                AND BAN.COD_STATO = 'G' 
	                                AND ATT.ID_ATTO IS NULL 
	                                AND ((SELECT COUNT(*) 
		                                FROM BANDO_CONFIG CONF  
		                                WHERE 1 = 1 
			                                AND CONF.ID_BANDO = GRAD.ID_BANDO 
			                                AND CONF.COD_TIPO = 'ATTGRADBLOCCHI' 
			                                AND CONF.ATTIVO = 1) = 0 
		                                OR (SELECT CONF.VALORE 
			                                FROM BANDO_CONFIG CONF  
			                                WHERE 1 = 1 
				                                AND CONF.ID_BANDO = GRAD.ID_BANDO 
				                                AND CONF.COD_TIPO = 'ATTGRADBLOCCHI' 
				                                AND CONF.ATTIVO = 1) = 'false') 
                                    AND RESP.ATTIVO = 1 
	                                AND RESP.PROVINCIA IS NULL 
                                    AND RESP.ID_UTENTE = @IdUtente ";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdUtente", id_utente));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                bandi.Add(BandoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return bandi;
        }

        public Utenti GetResponsabileDiMisuraBando(int idBando)
        {
            Utenti responsabileDiMisura = null;

            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT UT.*
                                FROM vBANDO_RESPONSABILI RESP 
                                    JOIN VUTENTI UT ON UT.ID_UTENTE = RESP.ID_UTENTE 
                                WHERE 1 = 1 
                                    AND RESP.ATTIVO = 1 
	                                AND RESP.PROVINCIA IS NULL 
                                    AND RESP.ID_BANDO = @IdBando ";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdBando", idBando));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                responsabileDiMisura = UtentiDAL.GetFromDatareader(DbProviderObj);
            DbProviderObj.Close();

            return responsabileDiMisura;
        }

        public int VerificaAtecoBando(int id_bando, string ateco)
        {
            int val_return = 0;
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpVerificaAtecoBando";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdBando", id_bando));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Ateco", ateco));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                val_return = new IntNT(DbProviderObj.DataReader["RETVAL"]);
            }
            return val_return;
        }

        public BandoCollection BandoRicercaGenerale(StringNT CodenteEqualThis, StringNT CodstatoEqualThis, IntNT OrdinestatoEqGreaterThanThis,
           DatetimeNT DatascadenzaEqLessThanThis, IntNT IdprogrammazioneEqualThis, BoolNT MultiprogettoEqualThis,
           BoolNT MultimisuraEqualThis, BoolNT DisposizioniattuativeEqualThis, StringNT ParolechiaveLikeThis,
           IntNT IdbandoEqualThis, StringNT CodPsrEqualThis)
        {
            BandoCollection bandiRicerca = new BandoCollection();

            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpBandoRicercaGenerale";

            if (!string.IsNullOrEmpty(CodenteEqualThis))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodEnteequalthis", CodenteEqualThis.ToString()));
            if (!string.IsNullOrEmpty(CodstatoEqualThis))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodStatoequalthis", CodstatoEqualThis.ToString()));
            if (OrdinestatoEqGreaterThanThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrdineStatoeqgreaterthanthis", OrdinestatoEqGreaterThanThis.Value));
            if (DatascadenzaEqLessThanThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DataScadenzaeqlessthanthis", DatascadenzaEqLessThanThis.Value));
            if (IdprogrammazioneEqualThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdProgrammazioneequalthis", IdprogrammazioneEqualThis.Value));
            if (MultiprogettoEqualThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Multiprogettoequalthis", MultiprogettoEqualThis.Value));
            if (MultimisuraEqualThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Multimisuraequalthis", MultimisuraEqualThis.Value));
            if (DisposizioniattuativeEqualThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DisposizioniAttuativeequalthis", DisposizioniattuativeEqualThis.Value));
            if (!string.IsNullOrEmpty(ParolechiaveLikeThis))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ParoleChiavelikethis", ParolechiaveLikeThis.ToString()));
            if (IdbandoEqualThis != null)
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IdBandoequalthis", IdbandoEqualThis.Value));
            if (!string.IsNullOrEmpty(CodPsrEqualThis))
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodPsrequalthis", CodPsrEqualThis.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                var bando = BandoDAL.GetFromDatareader(DbProviderObj);
                bandiRicerca.Add(bando);
            }

            return bandiRicerca;
        }
    }
}

namespace SiarLibrary
{
    public partial class Bando : BaseObject
    {
        public bool InviaMessaggioTelegram
        {
            get
            {
                bool messaggio_telegram = false;

                if (this != null && this.IdBando != null)
                {
                    string invio_messaggio = new SiarBLL.BandoConfigCollectionProvider().GetBandoConfig_MessTelegram(this.IdBando);
                    if (invio_messaggio != null && invio_messaggio == "True")
                        messaggio_telegram = true;
                }

                return messaggio_telegram;
            }
        }
    }
}