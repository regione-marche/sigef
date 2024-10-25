using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnaManager
{
    internal partial class Logger
    {
        private DALClass _dal { get; set; }

        internal Logger(DALClass dal)
        {
            _dal = dal;
        }

        internal void InsertLogVisura(RnaLogVisura logVisura)
        {
            try
            {
                _dal.InsertRnaLogVisura(logVisura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal void InsertLogVisura(ProjectInfo projectInfo, ResultInfoVisura resultInfo)
        {
            var logVisura = new RnaLogVisura();
            try
            {
                logVisura.ID_PROGETTO = projectInfo.IdProgetto;
                logVisura.ID_IMPRESA = projectInfo.IdImpresa;
                logVisura.ID_FISCALE_IMPRESA = projectInfo.IdFiscaleImpresa;
                logVisura.ID_RICHIESTA = resultInfo.IdRichiesta;
                logVisura.TIPO_VISURA = resultInfo.TipoVisura;
                logVisura.CODICE_ESITO = resultInfo.CodiceEsito;
                logVisura.DESCRIZIONE_ESITO = resultInfo.DescrizioneEsito;
                logVisura.DATA_RICHIESTA = System.DateTime.Now;
                logVisura.ID_OPERATORE = projectInfo.IdOperatore;

                _dal.InsertRnaLogVisura(logVisura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        internal void UpdateLogVisura(RnaLogVisura logVisura)
        {
            try
            {
                _dal.UpdateRnaLogVisura(logVisura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal void UpdateLogVisura(ResultInfo resultInfo)
        {
            var logVisura = new RnaLogVisura();

            try
            {
                logVisura = _dal.GetRnaLogVisuraByIdRichiesta(resultInfo.IdRichiesta);

                logVisura.CODICE_STATO_RICHIESTA = resultInfo.CodiceEsito;
                logVisura.DESCRIZIONE_STATO_RICHIESTA = resultInfo.DescrizioneEsito;
                logVisura.DATA_STATO_RICHIESTA = System.DateTime.Now;
                _dal.UpdateRnaLogVisura(logVisura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void UpdateLogVisura(int idRnaLogVisura, ResultInfo resultInfo)
        {
            var logVisura = new RnaLogVisura();
            try
            {
                logVisura = _dal.GetRnaLogVisuraById(idRnaLogVisura);

                logVisura.CODICE_STATO_RICHIESTA = resultInfo.CodiceEsito;
                logVisura.DESCRIZIONE_STATO_RICHIESTA = resultInfo.DescrizioneEsito;
                logVisura.DATA_STATO_RICHIESTA = System.DateTime.Now;

                _dal.UpdateRnaLogVisura(logVisura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void InsertLogConcessione(ProjectInfo projectInfo, ResultInfoConcessione resultInfo, bool produzione)
        {
            var logConcessione = new RnaLogConcessione();
            try
            {
                logConcessione.ID_PROGETTO = projectInfo.IdProgetto;
                logConcessione.ID_PROGETTO_RNA = projectInfo.IdProgettoRna;
                logConcessione.ID_OPERATORE_REG_AIUTO = projectInfo.IdOperatore;
                logConcessione.ID_RICHIESTA = resultInfo.IdRichiesta;
                logConcessione.ID_IMPRESA = projectInfo.IdImpresa;
                logConcessione.ID_FISCALE_IMPRESA = projectInfo.IdFiscaleImpresa;
                logConcessione.ISTANZA_RICHIESTA = resultInfo.IstanzaRichiesta;
                logConcessione.ISTANZA_RISPOSTA = null;
                //logConcessione.METODO = "registraAiuto";
                //logConcessione.TIPO_RISPOSTA = "xml";
                logConcessione.DATA_RICHIESTA = System.DateTime.Now;
                logConcessione.CODICE_ESITO = resultInfo.CodiceEsito;
                logConcessione.DESCRIZIONE_ESITO = resultInfo.DescrizioneEsito;
                logConcessione.PRODUZIONE = produzione;
                _dal.InsertRnaLogConcessione(logConcessione);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void UpdateLogConcessione(RnaLogConcessione logConcessione)
        {
            try
            {
                _dal.UpdateRnaLogConcessione(logConcessione);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        internal void UpdateLogConcessione(string IdRichiesta, ProjectInfo projectInfo, ResultInfoConcessione resultInfoConcessione, bool produzione)
        {
            var logConcessione = _dal.GetRnaLogConcessioneByIdRichiesta(IdRichiesta, true, true);

            try
            {
                logConcessione.ISTANZA_RISPOSTA = resultInfoConcessione.IstanzaRisposta;
                logConcessione.ID_OPERATORE_STATO_RICHIESTA = projectInfo.IdOperatore;
                logConcessione.CODICE_ESITO_STATO_RICHIESTA = resultInfoConcessione.CodiceEsitoRichiesta;
                logConcessione.DESCRIZIONE_ESITO_STATO_RICHIESTA = resultInfoConcessione.DescrizioneEsitoRichiesta;
                logConcessione.DATA_STATO_RICHIESTA = System.DateTime.Now;
                logConcessione.COR = resultInfoConcessione.COR;
                logConcessione.PRODUZIONE = produzione;
                _dal.UpdateRnaLogConcessione(logConcessione);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal void UpdateLogConcessione(string IdRichiesta, string istanzaEsitoRichiesta)
        {
            var logConcessione = _dal.GetRnaLogConcessioneByIdRichiesta(IdRichiesta, true, false);
            logConcessione.ISTANZA_RISPOSTA = istanzaEsitoRichiesta;
            try
            {
                //logConcessione = _dal.
                _dal.UpdateRnaLogConcessione(logConcessione);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
