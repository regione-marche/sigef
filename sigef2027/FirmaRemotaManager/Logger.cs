using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaRemotaManager
{
    public class Logger
    {
        private DALClass _dal { get; set; }

        public Logger()
        {
            _dal = new DALClass();
        }

        public void SaveLogFirma(LogInfo logInfo)
        {
            try
            {
                _dal.InsertLog(logInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountLogDocumentoScaricatoOk(string tipoDocumento, string parametriDocumento)
        {
            try
            {
                return _dal.CountLogDocumentoScaricatoOk(tipoDocumento, parametriDocumento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
