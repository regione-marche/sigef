using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
	public partial class CertspParametriXLottoCollectionProvider : ICertspParametriXLottoProvider
	{

        public CertspParametriXLottoCollection FindByIdLotto(IntNT IdlottoEqualThis)
        {
            CertspParametriXLottoCollection retcoll = new CertspParametriXLottoCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT P.*, L.ID_PARAMETRO, L.ID_LOTTO, L.PESO_REALE FROM CERTSP_PARAMETRI_DI_RISCHIO P LEFT JOIN CERTSP_PARAMETRI_X_LOTTO L ON P.ID = L.ID_PARAMETRO AND (L.ID_LOTTO="
                + IdlottoEqualThis + " OR L.ID_LOTTO IS NULL)";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                retcoll.Add(CertspParametriXLottoDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return retcoll;
        }

	}
}
