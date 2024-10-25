using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    /// <summary>
    /// Summary description for AttiCollectionProvider:IAttiProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>


    public partial class AttiCollectionProvider : IAttiProvider
    {
        public AttiCollection ImportaAtto(IntNT numero, DatetimeNT data, string definizione_atto, string registro)
        {
            if (numero == null || data == null || string.IsNullOrEmpty(definizione_atto))
                throw new Exception("Specificare numero, data e definizione dell'atto.");
            AttiCollection retval = new AttiCollection();
            if (definizione_atto == "E")
            {
                DbProvider db = new DbProvider();
                System.Data.IDbCommand cmd = db.GetCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT TOP 1 DATA_AVVIO_OPEN_ACT_DELIBERE as 'DATA_DELIBERE' FROM ATTI_REGISTRI";
                db.InitDatareader(cmd);
                DateTime data_avvio_delibere = DateTime.Now;
                if (db.DataReader.Read())
                {
                    data_avvio_delibere = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_DELIBERE"]);
                }
                if(data_avvio_delibere <= data)
                    RicercaDelibereInOpenAct(ref retval, numero, data);
                else
                    RicercaDelibere(ref retval, numero, data);
            }
            
            else if (definizione_atto == "D")
            {
                if (string.IsNullOrEmpty(registro)) throw new Exception("La ricerca dei decreti richiede obbligatoriamente di specificare il registro.");
                string[] cod_registro = registro.Split('|');
                DateTime data_avvio_open_act_x_registro = DateTime.Now;
                if (cod_registro.Length > 1) DateTime.TryParse(cod_registro[1], out data_avvio_open_act_x_registro);
                if (data >= data_avvio_open_act_x_registro) RicercaInOpenAct(ref retval, numero, data, cod_registro[0]);
                else RicercaInAttiweb(ref retval, numero, data, cod_registro[0]);
            }
            return retval;
        }

        private void RicercaDelibere(ref AttiCollection atti_trovati, IntNT numero, DatetimeNT data)
        {
            DbProvider db = new DbProvider(DbProvider.DbNames.NORMEMARCHE);
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_ATTO", numero.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_ATTO", data.Value));

            #region MODIFICA 22 GIUGNO -- CAMBIO DataBase
            //int idAnno = 0;
            //switch (dataAtto.Value.Year)
            //{
            //    case 2005:
            //        idAnno = 105;
            //        break;
            //    case 2006:
            //        idAnno = 143;
            //        break;
            //    case 2007:
            //        idAnno = 196;
            //        break;
            //    default:
            //        break;
            //}
            //string testo = "SELECT Oggetto,Cod_padre, Des_classificazione, Testo_sintetico,  Nome_documento FROM Classificazione "
            //+ "LEFT JOIN Doc_Classif_web ON Classificazione.Cod_classificazione = Doc_Classif_web.Cod_classificazione"
            //+ " LEFT  JOIN Documento ON Documento.Id_documento = Doc_Classif_web.Id_documento where Classificazione.id_web='02'"
            //+ "and Documento.Tipo_doc='01' and Oggetto like 'dgr " + numeroAtto + "' and cod_padre=" + idAnno;
            #endregion

            //                cmd.CommandText = @"SELECT  Documento.NumeroAtto, Documento.DataAtto, Documento.Oggetto, Documento.NomeFile,  
            //                      Documento.DataBUR, Documento.NumBUR, Servizio.servizio, Servizio.codServizio ,  classificazione. Des_classificazione
            //                      FROM Classificazione INNER JOIN
            //                      DocumentiClassificati INNER JOIN
            //                      Documento ON DocumentiClassificati.idDocumento = Documento.idDocumento ON 
            //                      Classificazione.id_classificazione = DocumentiClassificati.idClassificazione INNER JOIN
            //                      Servizio ON Documento.idServizio = Servizio.idServizio
            //                      WHERE Documento.TipoDoc=1 AND Documento.NumeroAtto=" + numero + " AND Documento.DataAtto=CONVERT(DATETIME,'" + data + "',103)";

            cmd.CommandText = @"SELECT D.NumeroAtto,D.DataAtto,D.NomeFile,D.DataBUR,D.NumBUR,DESCRIZIONE=ISNULL(D.Oggetto,C.Des_classificazione),S.servizio,S.codServizio
                      FROM Classificazione C INNER JOIN DocumentiClassificati DC ON C.id_classificazione=DC.idClassificazione
                      INNER JOIN Documento D ON DC.idDocumento=D.idDocumento INNER JOIN Servizio S ON D.idServizio=S.idServizio
                      WHERE D.TipoDoc=1 AND D.NumeroAtto=@NUMERO_ATTO AND D.DataAtto=/*CONVERT(DATETIME,*/@DATA_ATTO/*,103)*/";

            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                Atti a = new Atti();
                a.Numero = new IntNT(db.DataReader["NumeroAtto"]);
                a.Data = new DatetimeNT(db.DataReader["DataAtto"]);
                a.AwDocnumber = new StringNT(db.DataReader["NomeFile"]);
                a.Descrizione = new StringNT(db.DataReader["DESCRIZIONE"]);
                //a.Descrizione = new SiarLibrary.NullTypes.StringNT((db.DataReader["Oggetto"] != System.DBNull.Value ?
                //    db.DataReader["Oggetto"] : db.DataReader["Des_classificazione"]));
                //a.Servizio = new SiarLibrary.NullTypes.StringNT(db.DataReader["servizio"]);
                //a.Registro = new SiarLibrary.NullTypes.StringNT(db.DataReader["codServizio"]);
                a.CodDefinizione = "E";
                a.CodOrganoIstituzionale = "GR";
                atti_trovati.Add(a);
            }
            db.Close();
        }

        private void RicercaDelibereInOpenAct(ref AttiCollection atti_trovati, IntNT numero, DatetimeNT data)
        {
            SiarLibrary.Xconfig xc = new SiarBLL.XconfigCollectionProvider().GetById("WSOpenAct");
            if (!xc.Attivo) throw new Exception("La ricerca dei decreti su OpenAct è stata disabilitata.");
            AttiwebService.AttiwebServiceClient ws = new SiarBLL.AttiwebService.AttiwebServiceClient(xc.WsBinding);
            AttiwebService.SearchDelibereReq req = new AttiwebService.SearchDelibereReq();
            //req. = registro;
            req.NumeroRep = numero.Value;
            req.DataRepA = req.DataRepDa = data.Value;
            AttiwebService.BEBaseOfArrayOfDeliberaInfoR4ik9mXKc ret = ws.SearchDelibere(req);
            if (ret == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
            if (ret.ResultInfo.Tipo == AttiwebService.TipoRisultato.Error) throw new Exception(ret.ResultInfo.Descrizione);
            AttiwebService.DecretoInfoR[] di = ret.Result;
            ws.Close();

            foreach (AttiwebService.DecretoInfoR d in di)
            {
                Atti a = new Atti();
                a.Numero = d.NumRepertorio;
                a.Data = d.DataRepertorio;
                a.CodDefinizione = "E";
                a.DefinizioneAtto = "Delibere";
                a.CodOrganoIstituzionale = "GR";
                //a.OrganoIstituzionale = "Dirigente del Servizio Regionale";
                a.Descrizione = d.Oggetto;
                a.AwDocnumberNuovo = d.IdDecreto;
                //a.DataBur = d.DataPubblicazioneBur;
                //a.NumeroBur = d.NumeroBur;
                //a.Servizio = d.DescrizioneRepertorio;
                //a.Registro = d.CodiceRepertorio;
                atti_trovati.Add(a);
            }
        }

        private void RicercaInOpenAct(ref AttiCollection atti_trovati, IntNT numero, DatetimeNT data, string registro)
        {
            SiarLibrary.Xconfig xc = new SiarBLL.XconfigCollectionProvider().GetById("WSOpenAct");
            if (!xc.Attivo) throw new Exception("La ricerca dei decreti su OpenAct è stata disabilitata.");
            AttiwebService.AttiwebServiceClient ws = new SiarBLL.AttiwebService.AttiwebServiceClient(xc.WsBinding);
            AttiwebService.SearchAttiReq req = new AttiwebService.SearchAttiReq();
            req.CodiceRepertorio = registro;
            req.NumeroRep = numero.Value;
            req.DataRepA = req.DataRepDa = data.Value;
            AttiwebService.BEBaseOfArrayOfDecretoInfoR4ik9mXKc ret = ws.SearchAtti(req);
            if (ret == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
            if (ret.ResultInfo.Tipo == AttiwebService.TipoRisultato.Error) throw new Exception(ret.ResultInfo.Descrizione);
            AttiwebService.DecretoInfoR[] di = ret.Result;
            ws.Close();

            foreach (AttiwebService.DecretoInfoR d in di)
            {
                Atti a = new Atti();
                a.Numero = d.NumRepertorio;
                a.Data = d.DataRepertorio;
                a.CodDefinizione = "D";
                a.DefinizioneAtto = "Decreto";
                a.CodOrganoIstituzionale = "DR";
                a.OrganoIstituzionale = "Dirigente del Servizio Regionale";
                a.Descrizione = d.Oggetto;
                a.AwDocnumberNuovo = d.IdDecreto;
                a.DataBur = d.DataPubblicazioneBur;
                a.NumeroBur = d.NumeroBur;
                a.Servizio = d.DescrizioneRepertorio;
                a.Registro = d.CodiceRepertorio;
                atti_trovati.Add(a);
            }
        }

        private void RicercaInAttiweb(ref AttiCollection atti_trovati, IntNT numero, DatetimeNT data, string registro)
        {
            DbProvider db = new DbProvider(DbProvider.DbNames.ATTIWEB);
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "FindDocNumberSigef";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO", numero.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATADOC", data.ToFullYearString()));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                Atti a = new Atti();
                a.Numero = new IntNT(db.DataReader["NUMERO"]);
                a.Data = new DatetimeNT(db.DataReader["DATADOC"]);
                a.AwDocnumber = new StringNT(db.DataReader["DOCNUMBER"]);
                a.Descrizione = new StringNT(db.DataReader["DOCNAME"]);
                a.NumeroBur = new IntNT(db.DataReader["NUM_BOLL"]);
                a.DataBur = new DatetimeNT(db.DataReader["DATAPUBB"]);
                a.CodDefinizione = "D";
                a.DefinizioneAtto = "Decreto";
                a.CodOrganoIstituzionale = "DR";
                a.OrganoIstituzionale = "Dirigente del Servizio Regionale";
                a.Registro = new StringNT(db.DataReader["REGISTRO"]);
                a.Servizio = new StringNT(db.DataReader["SERVIZIO"]);
                if (a.Registro == registro) atti_trovati.Add(a);
            }
            db.Close();
        }

        public ArchivioFileCollection GetDocumentoFromOpenAct(int id_awnuovo)
        {
            SiarLibrary.Xconfig xc = new SiarBLL.XconfigCollectionProvider().GetById("WSOpenAct");
            if (!xc.Attivo) throw new Exception("La ricerca dei decreti su OpenAct è stata disabilitata.");
            AttiwebService.AttiwebServiceClient ws = new SiarBLL.AttiwebService.AttiwebServiceClient(xc.WsBinding);
            AttiwebService.BEBaseOfAttoBc_P2sb70 ret = ws.GetAtto(id_awnuovo, null, true);
            ws.Close();
            if (ret == null) throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink);
            if (ret.ResultInfo.Tipo == AttiwebService.TipoRisultato.Error) throw new Exception(ret.ResultInfo.Descrizione);
            ArchivioFileCollection docs = new ArchivioFileCollection();
            ArchivioFile doc_principale = new ArchivioFile();
            doc_principale.NomeFile = doc_principale.NomeCompleto = ret.Result.DocumentoPrincipaleIntegrale.NomeFile;
            doc_principale.Contenuto = ret.Result.DocumentoPrincipaleIntegrale.Content;
            doc_principale.Tipo = ret.Result.DocumentoPrincipaleIntegrale.MediaType;
            docs.Add(doc_principale);
            foreach (SiarBLL.AttiwebService.Allegato a in ret.Result.DocumentiAllegati)
            {
                ArchivioFile da = new ArchivioFile();
                da.NomeFile = da.NomeCompleto = a.File.NomeFile;
                da.Contenuto = a.File.Content;
                da.Tipo = a.File.MediaType;
                docs.Add(da);
            }
            return docs;
        }

        public AttiCollection SpPsrGetDocumentiBandoOrganismiInter(int id_bando)
        {
            AttiCollection cc = new AttiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetDocumentiBandoOrganismiInter";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                cc.Add(SiarDAL.AttiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }
    }
}
