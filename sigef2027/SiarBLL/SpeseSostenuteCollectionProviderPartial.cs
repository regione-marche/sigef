using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{
    public partial class SpeseSostenuteCollectionProvider : ISpeseSostenuteProvider
    {
        public SpeseSostenuteCollection GetSpeseSostenuteDomandaPagamento(IntNT id_domanda_pagamento, StringNT numero_gisutificativo,
            DatetimeNT data_giustificativo)
        {
            SpeseSostenuteCollection spese = new SpeseSostenuteCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetSpeseSostenuteDomandaPagamento";
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID_DOMANDA_PAGAMENTO", id_domanda_pagamento.Value));
            if (numero_gisutificativo != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NUMERO_GIUSTIFICATIVO", numero_gisutificativo.Value));
            if (data_giustificativo != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATA_GIUSTIFICATIVO", data_giustificativo.Value));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
            {
                SpeseSostenute s = SpeseSostenuteDAL.GetFromDatareader(DbProviderObj);
                s.AdditionalAttributes.Add("ImportoRichiesto", DbProviderObj.DataReader["IMPORTO_RICHIESTO"].ToString());
                s.AdditionalAttributes.Add("ImportoAmmesso", DbProviderObj.DataReader["IMPORTO_AMMESSO"].ToString());
                spese.Add(s);
            }
            DbProviderObj.Close();
            return spese;
        }
    }

}

namespace SiarLibrary
{
    public partial class SpeseSostenuteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
    {
        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public SpeseSostenuteCollection FiltraPerDatiGiustificativoIstruttoriaSpeseSostenute(NullTypes.StringNT NumeroEqualThis, NullTypes.DatetimeNT DataGiustificativoEqualThis, NullTypes.StringNT CodTipoGiustificativoEqualThis,
    NullTypes.StringNT DescrizioneLike, NullTypes.BoolNT InIntegrazioneEqualThis)
        {
            SpeseSostenuteCollection SpeseSostenuteCollectionTemp = new SpeseSostenuteCollection();
            foreach (SpeseSostenute spesa in this)
            {
                var giustificativo = new SiarBLL.GiustificativiCollectionProvider().GetById(spesa.IdGiustificativo);

                if (((NumeroEqualThis == null) || ((spesa.Numero != null) && (spesa.Numero.Value == NumeroEqualThis.Value))) 
                    && ((DataGiustificativoEqualThis == null) || ((spesa.DataGiustificativo != null) && (spesa.DataGiustificativo.Value == DataGiustificativoEqualThis.Value))) 
                    && ((CodTipoGiustificativoEqualThis == null) || ((spesa.CodTipoGiustificativo != null) && (spesa.CodTipoGiustificativo.Value == CodTipoGiustificativoEqualThis.Value))) 
                    && ((DescrizioneLike == null) || ((spesa.Descrizione != null) && (spesa.Descrizione.Like("%" + DescrizioneLike.Value + "%")))) 
                    && ((InIntegrazioneEqualThis == null) 
                        || (((spesa.InIntegrazione != null) && (spesa.InIntegrazione.Value == InIntegrazioneEqualThis.Value)))
                            || ((giustificativo != null) && (giustificativo.InIntegrazione != null) && (giustificativo.InIntegrazione.Value == InIntegrazioneEqualThis.Value))))
                {
                    SpeseSostenuteCollectionTemp.Add(spesa);
                }
            }
            return SpeseSostenuteCollectionTemp;
        }
    }
}
