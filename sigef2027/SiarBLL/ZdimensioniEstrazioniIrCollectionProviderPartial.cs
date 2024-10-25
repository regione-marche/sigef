using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ZdimensioniEstrazioniIrCollectionProvider : IZdimensioniEstrazioniIrProvider
    {
        private string SqlCode()
        {
            string _sqlCode;

            _sqlCode = @"SELECT    DISTINCT
                                   NULL             AS ID_ESTRAZIONE_IR,
                                   alb.Cod_Psr      AS CODICE_PSR,
                                   dim.ID           AS ID_DIMENSIONE,
                                   NULL             AS DATA_INIZIO,
                                   NULL             AS DATA_FINE,
                                   dim.VALORE_BASE,
                                   dim.VALORE       AS VALORE_OBBIETTIVO,
                                   NULL             AS VALORE_REALIZZATO,
                                   dim.Um           AS UM,
                                   obm.Codice       AS CODICE_OBMISURA,
                                   dim.Codice       AS DIMENSIONE_CODICE,
                                   dim.Descrizione  AS DIMENSIONE_DESCRIZIONE,
                                   dim.Ordine       AS DIMENSIONE_ORDINE,
                                   NULL             AS ANNO ";

            _sqlCode += @"FROM   zDimensioni dim
                                 INNER JOIN
                                 zDimensioni_X_Programmazione dxp ON dim.ID = dxp.ID_DIMENSIONE
                                 INNER JOIN
                                 zProgrammazione prg ON dxp.ID_PROGRAMMAZIONE = prg.ID
                                    INNER JOIN 
                                    zOb_Misura obm ON prg.ID = obm.ID_PROGRAMMAZIONE
                                    INNER JOIN
                                    zPsr_Albero alb ON prg.Cod_Tipo = alb.Codice ";

            _sqlCode += @"WHERE dim.Cod_Dim = 'IR' ";

            return _sqlCode;
        }

        public ZdimensioniEstrazioniIrCollection GetNew(string CodPsr, int anno)
        {
            string _sqlCode = SqlCode();
            DateTime dtInizio = new DateTime(anno, 01, 01);
            DateTime dtFine   = new DateTime(anno, 12, 31, 23, 59, 59);

            ZdimensioniEstrazioniIr ir = new ZdimensioniEstrazioniIr();
            ZdimensioniEstrazioniIrCollection irs = new ZdimensioniEstrazioniIrCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();

            _sqlCode += @" AND alb.Cod_Psr = @CodPsr ";
            // La struttura di ZOb_Misura non va bene per gli Obbettivi Strategici: per adesso metto una pezza così:
            _sqlCode += @" AND obm.Codice LIKE 'OS%' ";
            _sqlCode += @" ORDER BY DIMENSIONE_ORDINE ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = _sqlCode;
            cmd.Parameters.Add(new SqlParameter("@CodPsr", CodPsr));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                ir = SiarDAL.ZdimensioniEstrazioniIrDAL.GetFromDatareader(DbProviderObj);
                ir.DataInizio = dtInizio;
                ir.DataFine = dtFine;
                ir.MarkAsNew();
                irs.Add(ir);
            }
            DbProviderObj.Close();

            return irs;
        }
    }
}
