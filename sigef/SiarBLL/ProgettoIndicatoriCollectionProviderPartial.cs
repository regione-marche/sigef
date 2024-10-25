using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data.SqlClient;
using SiarBLL.AttiwebService;
using static SiarBLL.ImpresaCollectionProvider;

namespace SiarBLL
{
    public partial class ProgettoIndicatoriCollectionProvider : IProgettoIndicatoriProvider
    {
        public enum tipoIndicatore { manuale, calcolato, tutti };
        public enum isIstruttoria { si, no };

        public ProgettoIndicatoriCollection GetNew_ByIdProgetto(int idProgetto)
        {
            return GetNew_ByIdProgetto(idProgetto, tipoIndicatore.tutti);
        }

        public ProgettoIndicatoriCollection GetNew_ByIdProgetto(int idProgetto, tipoIndicatore tipoInd)
        {
            const string cManuale = "S";
            const string cCalcolato = "N";
            const string cComuni = "IOC";
            const string cSpecifici = "IOS";

            ProgettoIndicatoriCollection pgtInds = new ProgettoIndicatoriCollection();

            //decimal _valoreCalcolato;
            ProgettoIndicatori pgtInd;
            Progetto pgt;
            BandoProgrammazioneCollection bndPgms;
            ZdimensioniXProgrammazioneCollection dxps;
            Zdimensioni dim;
            Zprogrammazione pgm;

            ProgettoCollectionProvider pgtPrv = new ProgettoCollectionProvider();
            BandoProgrammazioneCollectionProvider bndPgmPrv = new BandoProgrammazioneCollectionProvider();
            ZdimensioniXProgrammazioneCollectionProvider dxpPrv = new ZdimensioniXProgrammazioneCollectionProvider();
            ZdimensioniCollectionProvider dimPrv = new ZdimensioniCollectionProvider();
            ZprogrammazioneCollectionProvider pgmPrv = new ZprogrammazioneCollectionProvider();

            pgt = pgtPrv.GetById(idProgetto);
            bndPgms = bndPgmPrv.Find(pgt.IdBando, null, null, null);
            foreach (BandoProgrammazione bndPgm in bndPgms)
            {
                dxps = dxpPrv.Select(bndPgm.IdProgrammazione, null, null);

                foreach (ZdimensioniXProgrammazione dxp in dxps)
                {
                    pgtInd = new ProgettoIndicatori();

                    dim = dimPrv.GetById(dxp.IdDimensione);
                    pgm = pgmPrv.GetById(dxp.IdProgrammazione);
                    if (tipoInd == tipoIndicatore.calcolato && dim.Richiedibile != cCalcolato)
                    {
                        continue;
                    }
                    if (tipoInd == tipoIndicatore.manuale && dim.Richiedibile != cManuale)
                    {
                        continue;
                    }
                    if (dim.CodDim != cComuni && dim.CodDim != cSpecifici)
                    {
                        continue;
                    }

                    pgtInd.IdDimXProgrammazione = dxp.IdDimXProgrammazione;
                    pgtInd.IdProgetto = idProgetto;
                    pgtInd.DimCodice = dim.Codice;
                    pgtInd.DimDescrizione = dim.Descrizione;
                    pgtInd.DimUm = dim.Um;
                    pgtInd.Richiedibile = dim.Richiedibile;
                    pgtInd.ProceduraCalcolo = dim.ProceduraCalcolo;
                    pgtInd.IdProgrammazione = pgm.Id;
                    pgtInd.ProgrammazioneCodice = pgm.Codice;
                    pgtInd.ProgrammazioneDescrizione = pgm.Descrizione;
                    // Indicatori Calcolati: assegno il valore esternamente
                    //if (dim.Richiedibile == cCalcolato)
                    //{
                    //    _valoreCalcolato = GetValoriCalcolati(pgtInd);
                    //    pgtInd.ValoreProgrammatoAmmesso = _valoreCalcolato;
                    //    pgtInd.ValoreRealizzatoAmmesso = _valoreCalcolato;
                    //}

                    pgtInds.Add(pgtInd);
                }
            }

            pgtInds.Sort("Richiedibile DESC, ProgrammazioneCodice, DimCodice");

            return pgtInds;
        }

        public decimal GetValoriCalcolati(ProgettoIndicatori progettoIndicatore, isIstruttoria istr)
        {
            const int colValore = 0;
            decimal valoreCalcolato = 0;
            int _idProgetto = progettoIndicatore.IdProgetto;
            int _idVariante = 0;
            bool _istruttoria = false;

            if (progettoIndicatore.IdVariante != null)
                _idVariante = progettoIndicatore.IdVariante;

            // Valorizzazione Istruttoria
            if (istr == isIstruttoria.no)
                _istruttoria = false;
            if (istr == isIstruttoria.si)
                _istruttoria = true;

            // Lettura dal db
            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = progettoIndicatore.ProceduraCalcolo;
            cmd.Parameters.Add(new SqlParameter("@ID_PROGETTO", _idProgetto));
            if (progettoIndicatore.ProceduraCalcolo == "calcoloIndicatoriInvestPrivati")
            {
                cmd.Parameters.Add(new SqlParameter("@FASE_ISTRUTTORIA", _istruttoria));
                if (_idVariante != 0)
                    cmd.Parameters.Add(new SqlParameter("@ID_VARIANTE", _idVariante));
            }

            dbPro.InitDatareader(cmd);
            if (dbPro.DataReader.Read())
                decimal.TryParse(dbPro.DataReader.GetValue(colValore).ToString(), out valoreCalcolato);
            dbPro.Close();

            return valoreCalcolato;
        }

        public SiarLibrary.ProgettoIndicatori GetStatoPrecedente(SiarLibrary.ProgettoIndicatori pind)
        {
            SiarLibrary.ProgettoIndicatori retu = null;
            int _idProgetto = pind.IdProgetto;
            int _idDimProgrammazione = pind.IdDimXProgrammazione;

            //Modificata per prendere l'ultima modifica istruita in base alla domanda o alla variante, non alla domanda istruttoria su progetto indicatori
            string sqlCode = @"SELECT TOP 1 
	                                ID_PROGETTO_INDICATORI, ID_DIM_X_PROGRAMMAZIONE, ID_PROGETTO, ID_DOMANDA_PAGAMENTO, ID_VARIANTE, COD_TIPO,
	                                VALORE_PROGRAMMATO_RICHIESTO, VALORE_REALIZZATO_RICHIESTO, DATA_REGISTRAZIONE, OPERATORE, 
	                                VALORE_PROGRAMMATO_AMMESSO, VALORE_REALIZZATO_AMMESSO, DATA_ISTRUTTORIA, ISTRUTTORE,
	                                Dim_Descrizione, Dim_Um, RICHIEDIBILE, PROCEDURA_CALCOLO, Dim_Codice, Id_Programmazione, Programmazione_Codice,
	                                Programmazione_Descrizione
                                FROM (
	                                SELECT IND.*,
		                                CASE
			                                WHEN VR.ID_VARIANTE IS NOT NULL 
				                                AND VR.SEGNATURA_APPROVAZIONE IS NOT NULL
				                                AND VR.APPROVATA = 1
				                                AND VR.ANNULLATA = 0
				                                THEN VR.DATA_APPROVAZIONE
			                                WHEN DOM.ID_DOMANDA_PAGAMENTO IS NOT NULL
				                                AND DOM.SEGNATURA_APPROVAZIONE IS NOT NULL
				                                AND DOM.APPROVATA = 1
				                                AND DOM.ANNULLATA = 0
				                                THEN DOM.DATA_APPROVAZIONE
			                                WHEN DOM.ID_DOMANDA_PAGAMENTO IS NULL
				                                AND  VR.ID_VARIANTE IS NULL
				                                THEN IND.DATA_REGISTRAZIONE
			                                ELSE NULL
		                                END AS DATA_ISTRUTTORIA_ISTRUITI
	                                FROM vProgetto_Indicatori IND
		                                LEFT JOIN VARIANTI VR ON IND.ID_VARIANTE = VR.ID_VARIANTE
		                                LEFT JOIN DOMANDA_DI_PAGAMENTO DOM ON IND.ID_DOMANDA_PAGAMENTO = DOM.ID_DOMANDA_PAGAMENTO
	                                WHERE 1 = 1
		                                AND IND.Id_Progetto = @IdProgetto
		                                AND IND.Id_Dim_X_Programmazione = @IdDimProgrammazione
	                                ) X
                                ORDER BY DATA_ISTRUTTORIA_ISTRUITI DESC";

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", _idProgetto));
            cmd.Parameters.Add(new SqlParameter("@IdDimProgrammazione", _idDimProgrammazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                retu = (SiarDAL.ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return retu;
        }

        public string GetRichiedibile_ByIdDimXProgrammazione(int idDimXProgrammazione)
        {
            string richiedibile = string.Empty;
            string sqlCode = @"SELECT dim.Richiedibile
                              FROM zDIMENSIONI dim
                                   INNER JOIN
                                   zDIMENSIONI_X_PROGRAMMAZIONE dxp ON dim.ID = dxp.ID_DIMENSIONE
                              WHERE dxp.ID_DIM_X_PROGRAMMAZIONE = @IdDimProgrammazione ";

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdDimProgrammazione", idDimXProgrammazione));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                richiedibile = DbProviderObj.DataReader.GetValue(0).ToString();
            }
            DbProviderObj.Close();

            return richiedibile;
        }

        public ProgettoIndicatoriCollection GetDomanda(int idProgetto)
        {
            ProgettoIndicatoriCollection pinds = new ProgettoIndicatoriCollection();

            string sqlCode = @"SELECT *
                               FROM vProgetto_Indicatori
                               WHERE Id_Progetto          =  @IdProgetto
                                 AND Id_Domanda_Pagamento IS NULL
                                 AND Id_Variante          IS NULL";

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                pinds.Add(SiarDAL.ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return pinds;
        }

        public ProgettoIndicatoriCollection GetBy_IdDimXProgrammazione(int IdDimXProgrammazione)
        {
            ProgettoIndicatoriCollection pinds = new ProgettoIndicatoriCollection();

            string sqlCode = @"SELECT *
                               FROM vProgetto_Indicatori
                               WHERE ID_DIM_X_PROGRAMMAZIONE = @ID_DIM_X_PROGRAMMAZIONE";

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new SqlParameter("@ID_DIM_X_PROGRAMMAZIONE", IdDimXProgrammazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                pinds.Add(SiarDAL.ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return pinds;
        }

        public ProgettoIndicatoriCollection GetPagamento(int idProgetto, int idDomanda)
        {
            ProgettoIndicatoriCollection pinds = new ProgettoIndicatoriCollection();

            string sqlCode = @"SELECT *
                               FROM vProgetto_Indicatori
                               WHERE Id_Progetto          = @IdProgetto
                                 AND Id_Domanda_Pagamento = @IdDomanda
                                 AND Id_Variante          IS NULL";

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@IdDomanda", idDomanda));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                pinds.Add(SiarDAL.ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return pinds;
        }

        public ProgettoIndicatoriCollection GetVariante(int idProgetto, int idVariante)
        {
            ProgettoIndicatoriCollection pinds = new ProgettoIndicatoriCollection();

            string sqlCode = @"SELECT *
                               FROM vProgetto_Indicatori
                               WHERE Id_Progetto          = @IdProgetto
                                 AND Id_Domanda_Pagamento IS NULL
                                 AND Id_Variante          = @IdVariante";

            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlCode;
            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            cmd.Parameters.Add(new SqlParameter("@IdVariante", idVariante));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                pinds.Add(SiarDAL.ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return pinds;
        }

        public ProgettoIndicatoriCollection GetIndicatoriAggiuntiSuccessivamente(int idProgetto, IntNT idDomandaPagamento, IntNT idVariante)
        {
            ProgettoIndicatoriCollection pinds = new ProgettoIndicatoriCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.CommandText = "spGetIndicatoriAggiuntiSuccessivamente";

            cmd.Parameters.Add(new SqlParameter("@IdProgetto", idProgetto));
            if (idDomandaPagamento != null)
                cmd.Parameters.Add(new SqlParameter("@IdDomandaPagamento", idDomandaPagamento.Value));
            if (idVariante != null)
                cmd.Parameters.Add(new SqlParameter("@IdVariante", idVariante.Value));
            
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                pinds.Add(SiarDAL.ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();

            return pinds;
        }

        public ProgettoIndicatoriCollection GetUltimiIndicatoriValidi(int idProgetto)
        {
            ProgettoIndicatoriCollection pc = new ProgettoIndicatoriCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetUltimiIndicatoriValidi";
            cmd.Parameters.Add(new SqlParameter("IdProgetto", idProgetto));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                pc.Add(ProgettoIndicatoriDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return pc;
        }
    }
}
