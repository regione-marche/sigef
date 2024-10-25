using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	public partial class CertspParametriXDomandaCollectionProvider : ICertspParametriXDomandaProvider
	{

        public CertspParametriXDomandaCollection GetListaParametriLotto(IntNT IdlottoEqualThis, IntNT IddomandapagamentoEqualThis)
        {
            CertspParametriXDomandaCollection lista_completa = new CertspParametriXDomandaCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT PXL.ID_LOTTO, PXL.ID_PARAMETRO, DESCRIZIONE, MANUALE,QUERY_SQL, ID_DOMANDA_PAGAMENTO, PUNTEGGIO, DATA_VALUTAZIONE, 
OPERATORE FROM CERTSP_PARAMETRI_X_LOTTO PXL INNER JOIN CERTSP_PARAMETRI_DI_RISCHIO P ON PXL.ID_PARAMETRO = P.ID_PARAMETRO                       
LEFT OUTER JOIN CERTSP_PARAMETRI_X_DOMANDA D ON D.ID_LOTTO = PXL.ID_LOTTO AND PXL.ID_PARAMETRO = D.ID_PARAMETRO
AND (ID_DOMANDA_PAGAMENTO IS NULL OR ID_DOMANDA_PAGAMENTO=" + IddomandapagamentoEqualThis + ") WHERE PXL.ID_LOTTO=" + IdlottoEqualThis;
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                lista_completa.Add(SiarDAL.CertspParametriXDomandaDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return lista_completa;
        }

	}
}