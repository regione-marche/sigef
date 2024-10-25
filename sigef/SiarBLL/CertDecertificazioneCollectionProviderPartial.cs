using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class CertDecertificazioneCollectionProvider : ICertDecertificazioneProvider
    {
        public CertDecertificazioneCollection GetDecertificazioniPerCertificazioneSpesa(IntNT idCert, BoolNT definitivo)
        {
            CertDecertificazioneCollection dC = new CertDecertificazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDecertificazioniPerCertificazioneSpesa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CERT", idCert.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DEFINITIVO", definitivo.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CertDecertificazione c = CertDecertificazioneDAL.GetFromDatareader(DbProviderObj);
                dC.Add(c);
            }
            DbProviderObj.Close();
            return dC;
        }
    }

    public partial class CertDecertificazioneCollectionProvider : ICertDecertificazioneProvider
    {
        public CertDecertificazioneCollection GetDecertificazioniPerCertificazioneConti(IntNT idCert, BoolNT definitivo)
        {
            CertDecertificazioneCollection dC = new CertDecertificazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDecertificazioniPerCertificazioneConti";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CERT", idCert.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DEFINITIVO", definitivo.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CertDecertificazione c = CertDecertificazioneDAL.GetFromDatareader(DbProviderObj);
                dC.Add(c);
            }
            DbProviderObj.Close();
            return dC;
        }
    }
}
