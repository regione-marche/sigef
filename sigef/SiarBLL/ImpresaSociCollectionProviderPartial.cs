using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ImpresaSociCollectionProvider : IImpresaSociProvider
    {
        public ImpresaSociCollection GetSociImpresa(int id_impresa, string cuaa, string codice_fiscale, string ragione_sociale)
        {
            ImpresaSociCollection cc = new ImpresaSociCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetSociImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", id_impresa));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CUAA", cuaa));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CODICE_FISCALE", codice_fiscale));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAGIONE_SOCIALE", ragione_sociale));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ImpresaSoci s = SiarDAL.ImpresaSociDAL.GetFromDatareader(DbProviderObj);
                // Dati dell'Ultimo Fascicolo
                s.AdditionalAttributes.Add("BARCODE1", new StringNT(DbProviderObj.DataReader["BARCODE1"]));
                s.AdditionalAttributes.Add("DATA_SCHEDA_VALIDAZIONE1", new DatetimeNT(DbProviderObj.DataReader["DATA_SCHEDA_VALIDAZIONE1"]));
                s.AdditionalAttributes.Add("DATA_DOWNLOAD1", new DatetimeNT(DbProviderObj.DataReader["DATA_DOWNLOAD1"]));
                s.AdditionalAttributes.Add("DATA_STORICIZZAZIONE1", new DatetimeNT(DbProviderObj.DataReader["DATA_STORICIZZAZIONE1"]));
                // Dati del Fascicolo Storicizzato
                s.AdditionalAttributes.Add("BARCODE2", new StringNT(DbProviderObj.DataReader["BARCODE2"]));
                s.AdditionalAttributes.Add("DATA_SCHEDA_VALIDAZIONE2", new DatetimeNT(DbProviderObj.DataReader["DATA_SCHEDA_VALIDAZIONE2"]));
                s.AdditionalAttributes.Add("DATA_DOWNLOAD2", new DatetimeNT(DbProviderObj.DataReader["DATA_DOWNLOAD2"]));
                s.AdditionalAttributes.Add("DATA_STORICIZZAZIONE2", new DatetimeNT(DbProviderObj.DataReader["DATA_STORICIZZAZIONE2"]));

                cc.Add(s);
            }
            DbProviderObj.Close();
            return cc;
        }

//        DECLARE @ID_IMPRESA INT=240

//SELECT S.* ,F1.BARCODE
//FROM vIMPRESA_SOCI S 
//LEFT JOIN (
//    SELECT ID_IMPRESA,MAX(ID_FASCICOLO) AS MAX_ID1 FROM FASCICOLO_AZIENDALE GROUP BY ID_IMPRESA
//) Q1 ON S.ID_SOCIO=Q1.ID_IMPRESA
//LEFT JOIN FASCICOLO_AZIENDALE F1 ON Q1.MAX_ID1=F1.ID_FASCICOLO
//LEFT JOIN (
//    SELECT ID_IMPRESA,MAX(ID_FASCICOLO) AS MAX_ID2 FROM FASCICOLO_AZIENDALE WHERE DATA_STORICIZZAZIONE IS NOT NULL GROUP BY ID_IMPRESA
//) Q2 ON S.ID_SOCIO=Q2.ID_IMPRESA
//LEFT JOIN FASCICOLO_AZIENDALE F2 ON Q2.MAX_ID2=F2.ID_FASCICOLO
//WHERE S.ID_IMPRESA=@ID_IMPRESA ORDER BY ATTIVO DESC,RAGIONE_SOCIALE
    }
}
