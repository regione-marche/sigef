using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class AssociazioneDecertificazioniCertificazioneSpesaFittizieCollectionProvider : IAssociazioneDecertificazioniCertificazioneSpesaFittizieProvider
    {
        public CertspDettaglioCollection GetDettagliFittiziDaEliminare(IntNT idCert)
        {
            CertspDettaglioCollection cD = new CertspDettaglioCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDettagliFittiziDaEliminare";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CERT", idCert.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CertspDettaglio c = CertspDettaglioDAL.GetFromDatareader(DbProviderObj);
                cD.Add(c);
            }
            DbProviderObj.Close();
            return cD;
        }

        public CertDecertificazioneCollection GetDecertificazioniSuFittizi(IntNT idCert)
        {
            CertDecertificazioneCollection cD = new CertDecertificazioneCollection();
            IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDecertificazioniSuFittizi";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_CERT", idCert.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                CertDecertificazione c = CertDecertificazioneDAL.GetFromDatareader(DbProviderObj);
                cD.Add(c);
            }
            DbProviderObj.Close();
            return cD;
        }
    }
}
