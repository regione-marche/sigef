using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;
using System.Data;
using System.Data.SqlClient;

namespace SiarBLL
{
    public partial class ZprogrammazioneSanzioniCollectionProvider : IZprogrammazioneSanzioniProvider
    {
        public ZprogrammazioneSanzioniCollection GetByIdProgrammazione_Attivo(int id_programmazione)
        {
            ZprogrammazioneSanzioniCollection snz = new ZprogrammazioneSanzioniCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProg_SanzioniByIdProgrammazione";
            cmd.Parameters.Add(new SqlParameter("@ID_PROGRAMMAZIONE", id_programmazione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                snz.Add(SiarDAL.ZprogrammazioneSanzioniDAL.GetFromDatareader(DbProviderObj));
            }
            DbProviderObj.Close();

            return snz;
        }

        public ZprogrammazioneSanzioni GetByCod_Sanzione_Ultimo(int id_programmazione, string cod_sanzione)
        {
            ZprogrammazioneSanzioni snz = new ZprogrammazioneSanzioni();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpPsrGetProg_SanzioniByCod_Sanzione";
            cmd.Parameters.Add(new SqlParameter("@ID_PROGRAMMAZIONE", id_programmazione));
            cmd.Parameters.Add(new SqlParameter("@COD_SANZIONE", cod_sanzione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                snz = SiarDAL.ZprogrammazioneSanzioniDAL.GetFromDatareader(DbProviderObj);
            }
            DbProviderObj.Close();

            return snz;
        }

        public void Sanzione_Attiva(int IdProgrammazione, string CodSanzione, int Ordine, int Operatore_Inizio)
        {
            ZprogrammazioneSanzioniCollectionProvider snzpro = new ZprogrammazioneSanzioniCollectionProvider();
            ZprogrammazioneSanzioni snzdb = new ZprogrammazioneSanzioni();

            snzdb = snzpro.GetByCod_Sanzione_Ultimo(IdProgrammazione, CodSanzione);

            if (snzdb.Id == null || !snzdb.Attiva)
            {
                snzdb.MarkAsNew();
                snzdb.Id = null;
                snzdb.OperatoreInizio = Operatore_Inizio;
                snzdb.DataInizio = DateTime.Now;
                snzdb.OperatoreFine = null;
                snzdb.DataFine = null;
                snzdb.Attiva = true;
            }
            
            snzdb.IdProgrammazione = IdProgrammazione;
            snzdb.CodSanzione = CodSanzione;
            snzdb.Ordine = Ordine;

            snzpro.Save(snzdb);
        }

        public void Sanzioni_Disattiva(int IdProgrammazione, string CodSanzione, int Operatore_Fine)
        {
            ZprogrammazioneSanzioniCollectionProvider snzpro = new ZprogrammazioneSanzioniCollectionProvider();
            ZprogrammazioneSanzioni snzdb = new ZprogrammazioneSanzioni();

            snzdb = snzpro.GetByCod_Sanzione_Ultimo(IdProgrammazione, CodSanzione);

            if (snzdb.Id != null && snzdb.Attiva)
            {
                snzdb.Attiva = false;
                snzdb.DataFine = DateTime.Now;
                snzdb.OperatoreFine = Operatore_Fine;

                snzpro.Save(snzdb);
            }
        }


    }
}
