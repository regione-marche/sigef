using System;
using System.Data;
using SiarLibrary;
using SiarDAL;
using System.Data.SqlClient;

namespace SiarBLL
{
    public class VcertrendicontazioneCollectionProviderPartial
    {
        DatiRiassuntiviRendicontazione datiRiassunti = new DatiRiassuntiviRendicontazione();
        public enum TipoDomande
        {
            Tutte, SelezionateSi, SelezionateNo, ChecklistSi, ChecklistNo,
            Asse1, Asse2, Asse3, Asse4, Asse5, Asse6, Asse7
        }
        public enum TipoSomma {
            SpesaAmmessa, ContributoUE, ContributoStato, ContributoRegione, ImportoPrivato
        }
        public decimal SommaImporti_PerAsse(TipoSomma tlSomm, TipoDomande tpDmn,  string progr)
        {
            decimal ret = 0;
            string strSql;
            object result;
            Vcertrendicontazione det = null;
            VcertrendicontazioneCollection dets = new VcertrendicontazioneCollection();
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            strSql = String.Format(@"SELECT" + SelectTipoSomma(tlSomm) + "FROM vCertRendicontazione as VC WHERE Cod_Psr = '" + progr +"'"+ WhereTipoDomande(tpDmn));
        
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            result = dbPro.ExecuteScalar(cmd);
            dbPro.Close();
            if (result != null)
            {
                decimal.TryParse(result.ToString(), out ret);
            }
            return ret;
        }

        public DatiRiassuntiviRendicontazioneCollection SommaImporti(string progr, string asse, string azione, string intervento)
        {
           
            string strSql="";
            DatiRiassuntiviRendicontazione det = null;
            DatiRiassuntiviRendicontazioneCollection dets = new DatiRiassuntiviRendicontazioneCollection();
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd;

            if (string.IsNullOrEmpty(asse) && string.IsNullOrEmpty(azione) && string.IsNullOrEmpty(intervento))
            {
                // casistica elenco iniziale, raggruppamento per assi
                // la query determina anche se il dettaglio è presente e per quali assi . Il campo dettaglio serve a visualizzare l'icona che indica la presenza di dettaglio
                strSql = String.Format(@"select k.Dettaglio, null as Azione, null as Intervento, null as bando, null as RUP, g.codice as asse_codice,
                    isnull(h.Importo_Ammesso,0) as Importo_Ammesso ,
                    isnull(h.contributo_regione,0) as contributo_regione ,
                    isnull(h.contributo_stato,0) as contributo_stato ,
                    isnull(h.contributo_ue,0) as contributo_ue,
                    isnull(h.Importo_Privato,0) as Importo_Privato
                     from (select prog.CODICE from zProgrammazione prog
                        inner join zPSR_ALBERO alb
                        on prog.COD_TIPO = alb.CODICE 
                        inner join zPsr 
                        on alb.COD_PSR = zPSR.CODICE
                        where prog.id_padre = 0 and alb.LIVELLO = 1 and zPSR.CODICE ='" + progr + "' ) g " +
                    "left join" +
                    " (SELECT   asse_codice, SUM(isnull(VC.Spesa_Ammessa, 0)) as Importo_Ammesso, " +
                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*50 as contributo_ue, " +
                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*30 as contributo_stato, " +
                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*20 as contributo_regione," +
                    " SUM(isnull(VC.Importo_privato,0)) AS Importo_Privato " +
                    " FROM vCertRendicontazione as VC " +
                    " WHERE Cod_Psr = '" + progr + "' group by Asse_Codice) h on g.codice = h.Asse_Codice " +
                    " left join "+
                           " (select 1 as Dettaglio," +
                        "  g.asse_codice"+
                                " from "+
                                " (SELECT asse_codice "+
                                " FROM vCertRendicontazione as VC "+
                                " WHERE Cod_Psr = '" + progr + "'  group by asse_codice) g) k " +
                                " on k.Asse_Codice = h.Asse_Codice ");
            }
            // casistica dettaglio per azione singolo asse
            // la query determina anche se il dettaglio è presente e per quali azioni. Il campo dettaglio serve a visualizzare l'icona che indica la presenza di dettaglio
            else if (!string.IsNullOrEmpty(asse)  && string.IsNullOrEmpty(azione)  && string.IsNullOrEmpty(intervento))
            strSql = String.Format(@"select K.Dettaglio, l.* from ( select '" + asse + "' as asse_codice, " +
                                    " null as Intervento, null as Bando,  null as RUP, g.* from (SELECT Azione, "+
                                    " SUM(isnull(VC.Spesa_Ammessa,0)) as Importo_Ammesso, " + 
                                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*50 as contributo_ue, " +
                                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*30 as contributo_stato, " +
                                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*20 as contributo_regione, " +
                                    " SUM(isnull(Importo_Privato,0)) AS Importo_Privato " +
                                    " FROM vCertRendicontazione as VC " +
                                    " WHERE Cod_Psr = '" + progr +"' AND Asse_Codice = '" + asse + "' group by Azione) g)  l" +
                                    " LEFT JOIN ( " +
                                    " select 1 as Dettaglio, '" + asse + "' as asse_codice, Azione from vCertRendicontazione " +
                                    " where Cod_Psr = '" + progr + "' AND Asse_Codice = '" + asse + "'  group by Azione) k " +
                                    " on  l.asse_codice = k.asse_codice and l.Azione = k.Azione "); 
            // casistica dettaglio per intervento  singola azione
            // la query determina anche se presente il dettaglio e per quali interventi. Il campo dettaglio serve a visualizzare l'icona che indica la presenza di dettaglio
            else if (!string.IsNullOrEmpty(asse) && !string.IsNullOrEmpty(azione) && string.IsNullOrEmpty(intervento))
                strSql = String.Format(@" select k.Dettaglio, m.* from (select '" + asse + "' as Asse_Codice,  null as Bando , " +
                                    " null as RUP, g.* from ( SELECT azione as Azione, intervento as Intervento, "+
                                    " SUM(isnull(VC.Spesa_Ammessa,0)) as Importo_Ammesso, "+
                                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*50 as contributo_ue, "+
                                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*30 as contributo_stato, "+
                                    " (SUM(isnull(VC.Contributo_Concesso,0))/100)*20 as contributo_regione, "+
                                    " SUM(isnull(Importo_Privato,0)) AS Importo_Privato"+
                                    " FROM vCertRendicontazione as VC "+
                                    " WHERE Cod_Psr = '" + progr + "' AND Asse_Codice = '" + asse + "' AND Azione = '" + azione + "' group by Azione, Intervento) g) m " +
                                    " left  join "+
                                    " (select  1 as dettaglio, azione, intervento, asse_codice from vCertRendicontazione group by Asse_Codice, Azione, intervento) k "+
                                    " on k.Asse_Codice = m.Asse_Codice and k.Azione = m.Azione  and k.Intervento = m.Intervento ");
            // casistica  dettaglio per bando   singolo intervento
            // Poichè non è èrevisto dettaglio per il bando, il campo è impostato a null in modo da non visualizzare l'icona che indica la presenza di dettaglio.
            else if (!string.IsNullOrEmpty(azione) && !string.IsNullOrEmpty(asse) && !string.IsNullOrEmpty(intervento))
                strSql = String.Format(@"SELECT null as Dettaglio, Azione as Azione, intervento as Intervento, id_bando as Bando, 
                                    SUM(isnull(VC.Spesa_Ammessa,0)) as Importo_Ammesso, 
                                    (SUM(isnull(VC.Contributo_Concesso,0))/100)*50 as contributo_ue, 
                                    (SUM(isnull(VC.Contributo_Concesso,0))/100)*30 as contributo_stato,
                                    (SUM(isnull(VC.Contributo_Concesso,0))/100)*20 as contributo_regione,
                                    SUM(isnull(Importo_Privato,0)) AS Importo_Privato, RUP
                                    FROM vCertRendicontazione as VC 
                                    WHERE Cod_Psr = '" + progr + "' AND Asse_Codice = '" + asse + "' AND Azione = '" + azione + "' AND Intervento  = '" + intervento  + "' group by Azione, Intervento, id_bando, RUP order by id_bando");
            cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);
            if (dbPro != null)
            {
                while (dbPro.DataReader.Read())
                {
                    det = (DatiRiassuntiviRendicontazione.GetFromDatareader(dbPro));
                    dets.Add(det);
                }
            }
            else {
                dets = null;
            }
            dbPro.Close();
            return dets;
        }

        private string WhereTipoDomande(TipoDomande tdDmn)
        {
            string strWhere = String.Empty;

            switch (tdDmn)
            {
                case TipoDomande.Tutte:
                    // Nessun filtro
                    break;
                case TipoDomande.SelezionateSi:
                    strWhere = " AND Selezionata = 'TRUE' ";
                    break;
                case TipoDomande.SelezionateNo:
                    strWhere = " AND Selezionata = 'FALSE' ";
                    break;
                case TipoDomande.ChecklistSi:
                    strWhere = " AND Id_File IS NOT NULL ";
                    break;
                case TipoDomande.ChecklistNo:
                    strWhere = " AND Id_File IS NULL ";
                    break;
                case TipoDomande.Asse1:
                    strWhere = " AND Asse_Codice = '1' ";
                    break;
                case TipoDomande.Asse2:
                    strWhere = " AND Asse_Codice = '2' ";
                    break;
                case TipoDomande.Asse3:
                    strWhere = " AND Asse_Codice = '3' ";
                    break;
                case TipoDomande.Asse4:
                    strWhere = " AND Asse_Codice = '4' ";
                    break;
                case TipoDomande.Asse5:
                    strWhere = " AND Asse_Codice = '5' ";
                    break;
                case TipoDomande.Asse6:
                    strWhere = " AND Asse_Codice = '6' ";
                    break;
                case TipoDomande.Asse7:
                    strWhere = " AND Asse_Codice = '7' ";
                    break;
            }
            return strWhere;
        }
        private string SelectTipoSomma(TipoSomma tdSmm)
        {
            string strWhere = String.Empty;

            switch (tdSmm)
            {

                case TipoSomma.SpesaAmmessa:
                    strWhere = " SUM(VC.Spesa_Ammessa) as Importo_ammesso ";
                    break;
                case TipoSomma.ContributoUE:
                    strWhere = " (SUM(VC.Contributo_Concesso)/100)*50 as contributo_ue ";
                    break;
                case TipoSomma.ContributoStato:
                    strWhere = " (SUM(VC.Contributo_Concesso)/100)*30 as contributo_stato ";
                    break;
                case TipoSomma.ContributoRegione:
                    strWhere = " (SUM(VC.Contributo_Concesso)/100)*20 as contributo_regione ";
                    break;
                case TipoSomma.ImportoPrivato:
                    strWhere = " SUM(CASE WHEN Importo_Privato IS NULL THEN 0 END) AS Importo_Privato ";
                    break;               
            }
            return strWhere;
        }
    } 
}
