using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolloBatchManager
{
    internal partial class Logger
    {
        private DALClass _dal { get; set; }

        internal Logger(DALClass dal)
        {
            _dal = dal;
        }

        internal void InsertLogProtocollo(ProtocolloLog protocolloLog)
        {
            try
            {
                _dal.InserLogProtocollo(protocolloLog);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
