using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NotificheBatch
{
    class NotificaGanttStepAutomatici : NotificatoreBase
    {
        public override int Invia(SiarLibrary.DbProvider db)
        {
            //
            //return base.Invia(db);
            int retI = 0;
            IDataReader dr = null;
            List<string[]> idStepAuto = new List<string[]>();

            try
            {
                IDbCommand cmd;
                cmd = db.GetCommand();
                cmd.CommandText = @"
                    SELECT GANTT_STEPS.ID_STEP, TIPO_GANTT_PASSI.PROCEDURA_CALCOLO
                    FROM GANTT_STEPS INNER JOIN TIPO_GANTT_PASSI ON GANTT_STEPS.ID_TIPO_PASSO = TIPO_GANTT_PASSI.ID_PASSO INNER JOIN GANTT ON GANTT_STEPS.ID_GNATT = GANTT.ID_GANTT
                    WHERE (GANTT.ID_STATO = 1) and VALORE_AUTOMATICO = 1 and PROCEDURA_CALCOLO <> '' and PROCEDURA_CALCOLO is not null
                    ORDER BY GANTT_STEPS.ID_GNATT, GANTT_STEPS.DATA_INIZIO_PREVISTA";
                db.InitDatareader(cmd);
                dr = db.DataReader;
                while (dr.Read())
                {
                    idStepAuto.Add(new string[] { dr["ID_STEP"].ToString(), dr["PROCEDURA_CALCOLO"].ToString()});
                }
            }
            catch (Exception ex)
            {
                ERRORE = "NotificaGanttStepAutomatici - " + ex.Message;
                retI = -1;
            }
            finally { if (dr != null && !dr.IsClosed) dr.Close(); }

            foreach (string[] ganttAutoP in idStepAuto)
            {
                try
                {
                    IDbCommand cmd;
                    cmd = db.GetCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = ganttAutoP[1];
                    var parameter = cmd.CreateParameter();
                    parameter.ParameterName = "@idStep";
                    parameter.Value = Convert.ToInt32(ganttAutoP[0]);
                    cmd.Parameters.Add(parameter);
                    db.Execute(cmd);
                    cmd = null;
                }
                catch (Exception ex)
                {
                    ERRORE = "NotificaGanttStepAutomatici - " + ex.Message;
                    retI = -1;
                }
            }
            return retI;
        }

    }
 

}
