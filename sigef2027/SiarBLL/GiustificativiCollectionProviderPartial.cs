using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class GiustificativiCollectionProvider : IGiustificativiProvider
    {

        public System.Collections.Hashtable CalcoloAmmontareRichiestoXGiustificativo(IntNT idDomandaPagamento)
        {
            System.Collections.Hashtable returnTable = new System.Collections.Hashtable();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            /*cmd.CommandText = @"SELECT Q1.ID_GIUSTIFICATIVO,SUM(ISNULL(Q1.IMPORTO_RICHIESTO,0)) AS IMPORTO_RICHIESTO, 
SUM(ISNULL(Q1.IMPORTO_AMMESSO,0)) AS IMPORTO_AMMESSO FROM PAGAMENTI_RICHIESTI PR
INNER JOIN (SELECT ID_PAGAMENTO_RICHIESTO,ID_GIUSTIFICATIVO,SUM(ISNULL(IMPORTO_RICHIESTO,0)) AS IMPORTO_RICHIESTO, 
SUM(ISNULL(IMPORTO_AMMESSO,0)) AS IMPORTO_AMMESSO FROM PAGAMENTI_BENEFICIARIO GROUP BY ID_PAGAMENTO_RICHIESTO,ID_GIUSTIFICATIVO) Q1
ON PR.ID_PAGAMENTO_RICHIESTO=Q1.ID_PAGAMENTO_RICHIESTO
WHERE PR.ID_DOMANDA_PAGAMENTO=" + idDomandaPagamento + "GROUP BY Q1.ID_GIUSTIFICATIVO";*/

            cmd.CommandText = @"SELECT ID_GIUSTIFICATIVO,SUM(ISNULL(B.IMPORTO_RICHIESTO,0)) AS IMPORTO_RICHIESTO, 
SUM(ISNULL(B.IMPORTO_AMMESSO,0)) AS IMPORTO_AMMESSO FROM PAGAMENTI_RICHIESTI R
INNER JOIN PAGAMENTI_BENEFICIARIO B ON R.ID_PAGAMENTO_RICHIESTO=B.ID_PAGAMENTO_RICHIESTO
WHERE R.ID_DOMANDA_PAGAMENTO=" + idDomandaPagamento + " GROUP BY B.ID_GIUSTIFICATIVO";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                returnTable[DbProviderObj.DataReader[0].ToString()] =
                    DbProviderObj.DataReader[1].ToString() + "|" + DbProviderObj.DataReader[2].ToString();
            }
            DbProviderObj.Close();
            return returnTable;
        }

        public GiustificativiCollection GetGiustificativiDomandaPagamento(IntNT id_domanda_pagamento, StringNT numero, DatetimeNT data)
        {
            GiustificativiCollection giustificativi = new GiustificativiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetGiustificativiDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            if (numero != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO", numero.Value));
            if (data != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA", data.Value));

            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                giustificativi.Add(SiarDAL.GiustificativiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return giustificativi;
        }

        public Boolean GiustificativoEsistente(IntNT id_giustificativo, IntNT id_Progetto, StringNT cod_tipo, StringNT numero,
            DatetimeNT data, StringNT cf_fornitore)
        {
            Boolean Esistente = false;
            SpeseSostenuteCollection spese = new SpeseSostenuteCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGiustificativoEsistente";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_GIUSTIFICATIVO", id_giustificativo.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", id_Progetto.Value));
            if (cod_tipo != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COD_TIPO", cod_tipo.Value));
            if (numero != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO", numero.Value));
            if (data != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA", data.Value));
            if (cf_fornitore != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CF_FORNITORE", cf_fornitore.Value));
            DbProviderObj.InitDatareader(cmd);
            if (DbProviderObj.DataReader.Read())
            {
                Esistente = new BoolNT(DbProviderObj.DataReader["ESISTENTE"]);
            }
            DbProviderObj.Close();
            return Esistente;

        }
    }
}
