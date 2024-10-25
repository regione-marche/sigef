using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class GraduatoriaProgettiCollectionProvider : IGraduatoriaProgettiProvider
    {
        public GraduatoriaProgettiCollection CalcolaGraduatoriaBando(IntNT id_bando, StringNT operatore, bool graduatoria_parziale)
        {
            GraduatoriaProgettiCollection graduatoria = new GraduatoriaProgettiCollection();
            try
            {
                DbProviderObj.CommandTimeout = 120;
                DbProviderObj.BeginTran();
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpGraduatoriaProgetti";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando.Value));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", operatore.Value));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ATTGRADPARZ", graduatoria_parziale));
                DbProviderObj.InitDatareader(cmd);
                while (DbProviderObj.DataReader.Read())
                {
                    GraduatoriaProgetti progetto = SiarDAL.GraduatoriaProgettiDAL.GetFromDatareader(DbProviderObj);
                    progetto.ObjectState = BaseObject.ObjectStateType.Changed;
                    graduatoria.Add(progetto);
                }
                DbProviderObj.DataReader.Close();
                SaveCollection(graduatoria);
                DbProviderObj.Commit();
                return graduatoria;
            }
            catch { DbProviderObj.Rollback(); throw; }
            finally { DbProviderObj.Close(); }
        }

        public DecimalNT[] CalcoloImportiFondoRiservaBando(IntNT IdBando, IntNT IdProgetto)
        {
            try
            {
                DecimalNT[] retval = new DecimalNT[3];
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpPsrCalcoloImportiFondoRiservaBando";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", IdBando.Value));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_PROGETTO", IdProgetto.Value));
                DbProviderObj.InitDatareader(cmd);
                if (DbProviderObj.DataReader.Read())
                {
                    retval[0] = new DecimalNT(DbProviderObj.DataReader["IMPORTO_RISERVA_BANDO"]);
                    retval[1] = new DecimalNT(DbProviderObj.DataReader["IMPORTO_RISERVA_UTILIZZATO"]);
                    retval[2] = new DecimalNT(DbProviderObj.DataReader["CONTRIBUTO_PROGETTO"]);
                }
                DbProviderObj.Close();
                return retval;
            }
            catch { throw; }
        }

        public GraduatoriaProgettiCollection GetListaProgettiInGraduatoria(int idBando)
        {
            GraduatoriaProgettiCollection graduatoria = new GraduatoriaProgettiCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetListaProgettiInGraduatoria";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", idBando));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                SiarLibrary.GraduatoriaProgetti g = SiarDAL.GraduatoriaProgettiDAL.GetFromDatareader(db);
                g.AdditionalAttributes.Add("SEGNATURA", new StringNT(db.DataReader["SEGNATURA"]));
                g.AdditionalAttributes.Add("ID_ATTO", new IntNT(db.DataReader["ID_ATTO"]));
                g.AdditionalAttributes.Add("NUMERO", new IntNT(db.DataReader["NUMERO"]));
                g.AdditionalAttributes.Add("DATA", new DatetimeNT(db.DataReader["DATA"]));
                g.AdditionalAttributes.Add("REGISTRO", new StringNT(db.DataReader["REGISTRO"]));
                g.AdditionalAttributes.Add("COD_DEFINIZIONE", new StringNT(db.DataReader["COD_DEFINIZIONE"]));
                g.AdditionalAttributes.Add("AW_DOCNUMBER", new StringNT(db.DataReader["AW_DOCNUMBER"]));
                g.AdditionalAttributes.Add("AW_DOCNUMBER_NUOVO", new IntNT(db.DataReader["AW_DOCNUMBER_NUOVO"]));
                graduatoria.Add(g);
            }
            db.Close();
            return graduatoria;
        }

        public GraduatoriaProgettiFinanziabilitaCollection GetRiepilogoSpeseXMisura(SiarLibrary.NullTypes.IntNT idBando)
        {
            GraduatoriaProgettiFinanziabilitaCollection misure = new GraduatoriaProgettiFinanziabilitaCollection();
            DbProvider db = DbProviderObj;
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGraduatoriaRiepilogoSpesaXMisura";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_BANDO", idBando.Value));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                GraduatoriaProgettiFinanziabilita misura = new GraduatoriaProgettiFinanziabilita();
                misura.Misura = new SiarLibrary.NullTypes.StringNT(db.DataReader["MISURA"]);
                misura.MisuraPrevalente = new SiarLibrary.NullTypes.BoolNT(db.DataReader["MISURA_PREVALENTE"]);
                misura.CostoTotale = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["COSTO"]);
                misura.ContributoDiMisura = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["CONTRIBUTO"]);
                misure.Add(misura);
            }
            db.Close();
            return misure;
        }

        public int OrdinamentoGraduatoriaIndividuale(int id_bando, string cf_operatore)
        {
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpOrdinamentoGraduatoriaIndividuale";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_BANDO", id_bando));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("CF_OPERATORE", cf_operatore));
            object o = DbProviderObj.ExecuteScalar(cmd);
            int result = 0;
            if (o != null) int.TryParse(o.ToString(), out result);
            return result;
        }

        public GraduatoriaProgetti GetRigaProgettoUpdateCostoContributo(int idProgetto)
        {
            DbProvider db = DbProviderObj;
            SiarLibrary.GraduatoriaProgetti g = new SiarLibrary.GraduatoriaProgetti();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpUpdateGraduatoriaProgetto";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", idProgetto));
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
            {
                g = SiarDAL.GraduatoriaProgettiDAL.GetFromDatareader(db);
            }
            db.Close();
            return g;
        }
    }
}
