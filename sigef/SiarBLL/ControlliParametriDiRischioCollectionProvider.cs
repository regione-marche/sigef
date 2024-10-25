using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for ControlliParametriDiRischioCollectionProvider:IControlliParametriDiRischioProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliParametriDiRischioCollectionProvider : IControlliParametriDiRischioProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ControlliParametriDiRischio
		protected ControlliParametriDiRischioCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ControlliParametriDiRischioCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ControlliParametriDiRischioCollection(this);
		}

		//Costruttore 2: popola la collection
		public ControlliParametriDiRischioCollectionProvider(IntNT IdparametroEqualThis, BoolNT ManualeEqualThis, StringNT DescrizioneLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdparametroEqualThis, ManualeEqualThis, DescrizioneLikeThis);
		}

		//Costruttore3: ha in input controlliparametridirischioCollectionObj - non popola la collection
		public ControlliParametriDiRischioCollectionProvider(ControlliParametriDiRischioCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ControlliParametriDiRischioCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ControlliParametriDiRischioCollection(this);
		}

		//Get e Set
		public ControlliParametriDiRischioCollection CollectionObj
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
		public int SaveCollection(ControlliParametriDiRischioCollection collectionObj)
		{
			return ControlliParametriDiRischioDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ControlliParametriDiRischio controlliparametridirischioObj)
		{
			return ControlliParametriDiRischioDAL.Save(_dbProviderObj, controlliparametridirischioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ControlliParametriDiRischioCollection collectionObj)
		{
			return ControlliParametriDiRischioDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ControlliParametriDiRischio controlliparametridirischioObj)
		{
			return ControlliParametriDiRischioDAL.Delete(_dbProviderObj, controlliparametridirischioObj);
		}

		//getById
		public ControlliParametriDiRischio GetById(IntNT IdParametroValue)
		{
			ControlliParametriDiRischio ControlliParametriDiRischioTemp = ControlliParametriDiRischioDAL.GetById(_dbProviderObj, IdParametroValue);
			if (ControlliParametriDiRischioTemp!=null) ControlliParametriDiRischioTemp.Provider = this;
			return ControlliParametriDiRischioTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ControlliParametriDiRischioCollection Select(IntNT IdparametroEqualThis, StringNT DescrizioneEqualThis, BoolNT ManualeEqualThis, 
StringNT QuerysqlEqualThis, IntNT PesoEqualThis)
		{
			ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionTemp = ControlliParametriDiRischioDAL.Select(_dbProviderObj, IdparametroEqualThis, DescrizioneEqualThis, ManualeEqualThis, 
QuerysqlEqualThis, PesoEqualThis);
			ControlliParametriDiRischioCollectionTemp.Provider = this;
			return ControlliParametriDiRischioCollectionTemp;
		}

		//Find: popola la collection
		public ControlliParametriDiRischioCollection Find(IntNT IdparametroEqualThis, BoolNT ManualeEqualThis, StringNT DescrizioneLikeThis)
		{
			ControlliParametriDiRischioCollection ControlliParametriDiRischioCollectionTemp = ControlliParametriDiRischioDAL.Find(_dbProviderObj, IdparametroEqualThis, ManualeEqualThis, DescrizioneLikeThis);
			ControlliParametriDiRischioCollectionTemp.Provider = this;
			return ControlliParametriDiRischioCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_DI_RISCHIO>
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
    <Find OrderBy="ORDER BY ">
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_DI_RISCHIO>
*/