using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for TipoSanzioniParametriCollectionProvider:ITipoSanzioniParametriProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class TipoSanzioniParametriCollectionProvider : ITipoSanzioniParametriProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di TipoSanzioniParametri
		protected TipoSanzioniParametriCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public TipoSanzioniParametriCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new TipoSanzioniParametriCollection(this);
		}

		//Costruttore 2: popola la collection
		public TipoSanzioniParametriCollectionProvider(IntNT CodiceEqualThis, StringNT CodtiposanzioneEqualThis, BoolNT DurataEqualThis, 
BoolNT GravitaEqualThis, BoolNT EntitaEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodiceEqualThis, CodtiposanzioneEqualThis, DurataEqualThis, 
GravitaEqualThis, EntitaEqualThis);
		}

		//Costruttore3: ha in input tiposanzioniparametriCollectionObj - non popola la collection
		public TipoSanzioniParametriCollectionProvider(TipoSanzioniParametriCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public TipoSanzioniParametriCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new TipoSanzioniParametriCollection(this);
		}

		//Get e Set
		public TipoSanzioniParametriCollection CollectionObj
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
		public int SaveCollection(TipoSanzioniParametriCollection collectionObj)
		{
			return TipoSanzioniParametriDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(TipoSanzioniParametri tiposanzioniparametriObj)
		{
			return TipoSanzioniParametriDAL.Save(_dbProviderObj, tiposanzioniparametriObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(TipoSanzioniParametriCollection collectionObj)
		{
			return TipoSanzioniParametriDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(TipoSanzioniParametri tiposanzioniparametriObj)
		{
			return TipoSanzioniParametriDAL.Delete(_dbProviderObj, tiposanzioniparametriObj);
		}

		//getById
		public TipoSanzioniParametri GetById(IntNT CodiceValue)
		{
			TipoSanzioniParametri TipoSanzioniParametriTemp = TipoSanzioniParametriDAL.GetById(_dbProviderObj, CodiceValue);
			if (TipoSanzioniParametriTemp!=null) TipoSanzioniParametriTemp.Provider = this;
			return TipoSanzioniParametriTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public TipoSanzioniParametriCollection Select(IntNT CodiceEqualThis, StringNT CodtiposanzioneEqualThis, StringNT DescrizioneEqualThis, 
BoolNT NoncomportasanzioneEqualThis, BoolNT DurataEqualThis, BoolNT GravitaEqualThis, 
BoolNT EntitaEqualThis, IntNT ClasseviolazioneEqualThis, StringNT TooltipEqualThis)
		{
			TipoSanzioniParametriCollection TipoSanzioniParametriCollectionTemp = TipoSanzioniParametriDAL.Select(_dbProviderObj, CodiceEqualThis, CodtiposanzioneEqualThis, DescrizioneEqualThis, 
NoncomportasanzioneEqualThis, DurataEqualThis, GravitaEqualThis, 
EntitaEqualThis, ClasseviolazioneEqualThis, TooltipEqualThis);
			TipoSanzioniParametriCollectionTemp.Provider = this;
			return TipoSanzioniParametriCollectionTemp;
		}

		//Find: popola la collection
		public TipoSanzioniParametriCollection Find(IntNT CodiceEqualThis, StringNT CodtiposanzioneEqualThis, BoolNT DurataEqualThis, 
BoolNT GravitaEqualThis, BoolNT EntitaEqualThis)
		{
			TipoSanzioniParametriCollection TipoSanzioniParametriCollectionTemp = TipoSanzioniParametriDAL.Find(_dbProviderObj, CodiceEqualThis, CodtiposanzioneEqualThis, DurataEqualThis, 
GravitaEqualThis, EntitaEqualThis);
			TipoSanzioniParametriCollectionTemp.Provider = this;
			return TipoSanzioniParametriCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_SANZIONI_PARAMETRI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <txtNomeCampoDataModifica>DATA_MODIFICA</txtNomeCampoDataModifica>
  <chkOptimisticCouncurrency>False</chkOptimisticCouncurrency>
  <chkShortNames>False</chkShortNames>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find OrderBy="ORDER BY CLASSE_VIOLAZIONE">
      <CODICE>Equal</CODICE>
      <COD_TIPO_SANZIONE>Equal</COD_TIPO_SANZIONE>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipoParametro>
      <DURATA>Equal</DURATA>
      <GRAVITA>Equal</GRAVITA>
      <ENTITA>Equal</ENTITA>
    </FiltroTipoParametro>
  </Filters>
  <externalFields />
  <AddedFkFields />
</TIPO_SANZIONI_PARAMETRI>
*/