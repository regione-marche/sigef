using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class ImpresaCertificazioneAntimafiaCollectionProvider : IImpresaCertificazioneAntimafiaProvider
    {
        public ImpresaCertificazioneAntimafia GetCertificazioneAntimafiaXImpresa(IntNT id_impresa, DateTime data)
        {
            ImpresaCertificazioneAntimafia cert = new ImpresaCertificazioneAntimafia();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetCertificazioneAntimafiaXImpresa";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_IMPRESA", id_impresa.Value));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA", data));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cert = SiarDAL.ImpresaCertificazioneAntimafiaDAL.GetFromDatareader(DbProviderObj);
            DbProviderObj.Close();
            return cert;
        }
    }
}
