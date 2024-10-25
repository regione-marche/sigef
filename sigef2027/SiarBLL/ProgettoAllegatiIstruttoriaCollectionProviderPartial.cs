using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Collections.Generic;

namespace SiarBLL
{
    public partial class ProgettoAllegatiIstruttoriaCollectionProvider : IProgettoAllegatiIstruttoriaProvider
    {
        public List<ProgettoAllegatiIstruttoria> GetProgettiConAllegatiInIdProgetti(List<IntNT> id_progetti_list)
        {
            var prog_all = new ProgettoAllegatiIstruttoria();
            var lista_progetti = new List<ProgettoAllegatiIstruttoria>();

            string strSql =
                String.Format(@"SELECT *
                                FROM PROGETTO_ALLEGATI_ISTRUTTORIA
                                WHERE ID_PROGETTO IN (" + string.Join(",", id_progetti_list) + ")");

            DbProvider dbPro = new DbProvider();
            IDbCommand cmd = dbPro.GetCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            dbPro.InitDatareader(cmd);
            
            while (dbPro.DataReader.Read())
            {
                prog_all = new ProgettoAllegatiIstruttoria();
                prog_all.IdProgettoAllegatiIstruttoria = new IntNT(dbPro.DataReader["ID_PROGETTO_ALLEGATI_ISTRUTTORIA"]);
                prog_all.IdProgetto = new IntNT(dbPro.DataReader["ID_PROGETTO"]);
                prog_all.IdFile = new IntNT(dbPro.DataReader["ID_FILE"]);
                prog_all.DescrizioneBreve = new StringNT(dbPro.DataReader["DESCRIZIONE_BREVE"]);
                prog_all.OperatoreInserimento = new IntNT(dbPro.DataReader["OPERATORE_INSERIMENTO"]);
                prog_all.DataInserimento = new DatetimeNT(dbPro.DataReader["DATA_INSERIMENTO"]);
                prog_all.OperatoreModifica = new IntNT(dbPro.DataReader["OPERATORE_MODIFICA"]);
                prog_all.DataModifica = new DatetimeNT(dbPro.DataReader["DATA_MODIFICA"]);

                lista_progetti.Add(prog_all);
            }
            dbPro.Close();

            return lista_progetti;
        }
    }
}
