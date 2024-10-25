using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for MandatiImpresaCollectionProvider:IMandatiImpresaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class MandatiImpresaCollectionProvider : IMandatiImpresaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di MandatiImpresa
		protected MandatiImpresaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public MandatiImpresaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new MandatiImpresaCollection(this);
		}

		//Costruttore 2: popola la collection
		public MandatiImpresaCollectionProvider(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, 
StringNT RagionesocialeLikeThis, IntNT IdutenteabilitatoEqualThis, StringNT CodenteEqualThis, 
StringNT CodtipoenteEqualThis, StringNT TipomandatoEqualThis, BoolNT AttivoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis, 
RagionesocialeLikeThis, IdutenteabilitatoEqualThis, CodenteEqualThis, 
CodtipoenteEqualThis, TipomandatoEqualThis, AttivoEqualThis);
		}

		//Costruttore3: ha in input mandatiimpresaCollectionObj - non popola la collection
		public MandatiImpresaCollectionProvider(MandatiImpresaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public MandatiImpresaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new MandatiImpresaCollection(this);
		}

		//Get e Set
		public MandatiImpresaCollection CollectionObj
		{
			get
			{
				return _CollectionObj;
			}
			set
			{
				_CollectionObj = value;
			}
		}

		public DbProvider DbProviderObj
		{
			get
			{
				return _dbProviderObj;
			}
			set
			{
				_dbProviderObj = value;
			}
		}

		//Operazioni

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(MandatiImpresaCollection collectionObj)
		{
			return MandatiImpresaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(MandatiImpresa mandatiimpresaObj)
		{
			return MandatiImpresaDAL.Save(_dbProviderObj, mandatiimpresaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(MandatiImpresaCollection collectionObj)
		{
			return MandatiImpresaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(MandatiImpresa mandatiimpresaObj)
		{
			return MandatiImpresaDAL.Delete(_dbProviderObj, mandatiimpresaObj);
		}

		//getById
		public MandatiImpresa GetById(IntNT IdValue)
		{
			MandatiImpresa MandatiImpresaTemp = MandatiImpresaDAL.GetById(_dbProviderObj, IdValue);
			if (MandatiImpresaTemp!=null) MandatiImpresaTemp.Provider = this;
			return MandatiImpresaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public MandatiImpresaCollection Select(IntNT IdEqualThis, IntNT IdimpresaEqualThis, IntNT IdutenteabilitatoEqualThis, 
StringNT CodenteEqualThis, StringNT CodicesportellocaaEqualThis, StringNT TipomandatoEqualThis, 
BoolNT AttivoEqualThis, DatetimeNT DatainiziovaliditaEqualThis, DatetimeNT DatafinevaliditaEqualThis, 
IntNT IdoperatoreinizioEqualThis, IntNT IdoperatorefineEqualThis, StringNT SegnaturamandatoEqualThis, 
StringNT SegnaturarevocaEqualThis)
		{
			MandatiImpresaCollection MandatiImpresaCollectionTemp = MandatiImpresaDAL.Select(_dbProviderObj, IdEqualThis, IdimpresaEqualThis, IdutenteabilitatoEqualThis, 
CodenteEqualThis, CodicesportellocaaEqualThis, TipomandatoEqualThis, 
AttivoEqualThis, DatainiziovaliditaEqualThis, DatafinevaliditaEqualThis, 
IdoperatoreinizioEqualThis, IdoperatorefineEqualThis, SegnaturamandatoEqualThis, 
SegnaturarevocaEqualThis);
			MandatiImpresaCollectionTemp.Provider = this;
			return MandatiImpresaCollectionTemp;
		}

		//Find: popola la collection
		public MandatiImpresaCollection Find(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CodicefiscaleEqualThis, 
StringNT RagionesocialeLikeThis, IntNT IdutenteabilitatoEqualThis, StringNT CodenteEqualThis, 
StringNT CodtipoenteEqualThis, StringNT TipomandatoEqualThis, BoolNT AttivoEqualThis)
		{
			MandatiImpresaCollection MandatiImpresaCollectionTemp = MandatiImpresaDAL.Find(_dbProviderObj, IdimpresaEqualThis, CuaaEqualThis, CodicefiscaleEqualThis, 
RagionesocialeLikeThis, IdutenteabilitatoEqualThis, CodenteEqualThis, 
CodtipoenteEqualThis, TipomandatoEqualThis, AttivoEqualThis);
			MandatiImpresaCollectionTemp.Provider = this;
			return MandatiImpresaCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<MANDATI_IMPRESA>
  <ViewName>vMANDATI_IMPRESA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>True</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY ATTIVO DESC, RAGIONE_SOCIALE">
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CODICE_FISCALE>Equal</CODICE_FISCALE>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
      <ID_UTENTE_ABILITATO>Equal</ID_UTENTE_ABILITATO>
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAttivoTipoMandato>
      <ATTIVO>Equal</ATTIVO>
      <TIPO_MANDATO>Equal</TIPO_MANDATO>
    </FiltroAttivoTipoMandato>
  </Filters>
  <externalFields />
  <AddedFkFields />
</MANDATI_IMPRESA>
*/