using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PucManager
{
    internal static partial class LogParser
    {
        internal static string GetXmlString(string file, int IdInvio, string CodiceFondo)
        {
            try
            {
                var dal = new DALClass();
                var log = new LogRoot();
                log.IdInvio = IdInvio;
                var ticket = dal.GetInvioMonitoraggioById(IdInvio).ID_TICKET;
                log.IdTicket = ticket;
                var logen = new List<LogRecordType>();
                var reader = new System.IO.StringReader(file);
                List<string> logcoll = new List<string>();
                string line;
                while ((line = reader.ReadLine()) != null && line != string.Empty)
                {
                    logcoll.Add(line);
                }
                //rimozione dell'header
                logcoll.RemoveAt(0);
                //Creazione del dizionario degli errori
                var errcoll = logcoll[0].Split('#')[2].Split('|');
                Dictionary<string, string> dicErrori = new Dictionary<string, string>();
                for (int e = 0; e < errcoll.Length - 1; e++)
                {
                    dicErrori.Add(errcoll[e], errcoll[e + 1]);
                    e++;
                }
                //rimozione della prima riga contenente la codifica degli errori
                logcoll.RemoveAt(0);
                //rimozione del footer
                logcoll.RemoveAt(logcoll.Count - 1);

                foreach (string rec in logcoll)
                {
                    string desc;
                    var logEntry = new LogRecordType();
                    var recfields = rec.Split('#');
                    logEntry.TipoFile = recfields[0];
                    logEntry.CodiceGruppo = recfields[2];
                    logEntry.NumeroRiga = recfields[1];
                    var table = dal.GetDatiTabellaIgrue(logEntry.TipoFile, IdInvio, int.Parse(recfields[1]), CodiceFondo); 
                    var id = table.Rows[0][0].ToString();
                    if (logEntry.TipoFile.StartsWith("PA"))
                    {
                        var bandicod = dal.GetCodProceduraAttivazioneByCodProcAttivazione(id);
                        if (bandicod != null)
                        {
                            logEntry.IdBando = bandicod.ID_BANDO.ToString();
                        }
                        else
                        {
                            logEntry.IdBando = id;
                        }
                    }
                    else
                    {
                        logEntry.IdProgetto = id;
                    }
                    //Se il codice gruppo errore = 1, l'errore non è riconducibile ad uno specifico campo del tracciato
                    if (recfields[2] == "1")
                    {
                        logEntry.CodiceErrore = recfields[3];
                        if (dicErrori.TryGetValue(logEntry.CodiceErrore, out desc))
                        {
                            logEntry.DescrizioneErrore = desc;
                        }
                        logEntry.DescrizioneErrore = desc;
                        logen.Add(logEntry);
                        desc = string.Empty;
                    }
                    else
                    //Se il codice gruppo errore = 2, l'errore è associato ad uno specifico campo del tracciato (00 = nessun errore)
                    {
                        var cfields = recfields[3].Split('|');
                        for (int i = 0; i < cfields.Length - 1; i++)
                        {
                            if (cfields[i] != "00")
                            {
                                var clone = logEntry.Clone();
                                clone.CodiceErrore = cfields[i];
                                if (dicErrori.TryGetValue(clone.CodiceErrore, out desc))
                                {
                                    clone.DescrizioneErrore = desc;
                                }
                                clone.DescrizioneErrore = desc;
                                clone.CampoTracciato = GetCampoTracciato(clone.TipoFile, i);
                                logen.Add(clone);
                                desc = string.Empty;
                            }
                        }
                    }
                }
                log.LogEntry = logen;
                return log.Serialize(false);
            }
            catch (Exception ex)
            {               
                throw ex;
            }
        }


        internal static string GetCampoTracciato(string NomeTracciato, int PosizioneCampo)
        {
            try
            {
                DALClass dal = new DALClass();
                var list = dal.GetColumnNames(NomeTracciato);
                var result = list[PosizioneCampo];
                return result;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
