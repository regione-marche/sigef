using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PartecipantiXFilieraCollectionProvider:IPartecipantiXFilieraProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PartecipantiXFilieraCollectionProvider : IPartecipantiXFilieraProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PartecipantiXFiliera
		protected PartecipantiXFilieraCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PartecipantiXFilieraCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PartecipantiXFilieraCollection(this);
		}

		//Costruttore 2: popola la collection
		public PartecipantiXFilieraCollectionProvider(IntNT IdpartecipanteEqualThis, StringNT CodfilieraEqualThis, StringNT CuaaEqualThis, 
IntNT IdprogettovalidatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdpartecipanteEqualThis, CodfilieraEqualThis, CuaaEqualThis, 
IdprogettovalidatoEqualThis);
		}

		//Costruttore3: ha in input partecipantixfilieraCollectionObj - non popola la collection
		public PartecipantiXFilieraCollectionProvider(PartecipantiXFilieraCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PartecipantiXFilieraCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PartecipantiXFilieraCollection(this);
		}

		//Get e Set
		public PartecipantiXFilieraCollection CollectionObj
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
		public int SaveCollection(PartecipantiXFilieraCollection collectionObj)
		{
			return PartecipantiXFilieraDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PartecipantiXFiliera partecipantixfilieraObj)
		{
			return PartecipantiXFilieraDAL.Save(_dbProviderObj, partecipantixfilieraObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PartecipantiXFilieraCollection collectionObj)
		{
			return PartecipantiXFilieraDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PartecipantiXFiliera partecipantixfilieraObj)
		{
			return PartecipantiXFilieraDAL.Delete(_dbProviderObj, partecipantixfilieraObj);
		}

		//getById
		public PartecipantiXFiliera GetById(IntNT IdPartecipanteValue)
		{
			PartecipantiXFiliera PartecipantiXFilieraTemp = PartecipantiXFilieraDAL.GetById(_dbProviderObj, IdPartecipanteValue);
			if (PartecipantiXFilieraTemp!=null) PartecipantiXFilieraTemp.Provider = this;
			return PartecipantiXFilieraTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PartecipantiXFilieraCollection Select(IntNT IdpartecipanteEqualThis, StringNT CodfilieraEqualThis, StringNT CuaaEqualThis, 
IntNT IdprogettovalidatoEqualThis, StringNT CodruolositraEqualThis, BoolNT AmmessoEqualThis, 
DatetimeNT DatavalidazioneEqualThis, StringNT CfoperatoreEqualThis)
		{
			PartecipantiXFilieraCollection PartecipantiXFilieraCollectionTemp = PartecipantiXFilieraDAL.Select(_dbProviderObj, IdpartecipanteEqualThis, CodfilieraEqualThis, CuaaEqualThis, 
IdprogettovalidatoEqualThis, CodruolositraEqualThis, AmmessoEqualThis, 
DatavalidazioneEqualThis, CfoperatoreEqualThis);
			PartecipantiXFilieraCollectionTemp.Provider = this;
			return PartecipantiXFilieraCollectionTemp;
		}

		//Find: popola la collection
		public PartecipantiXFilieraCollection Find(IntNT IdpartecipanteEqualThis, StringNT CodfilieraEqualThis, StringNT CuaaEqualThis, 
IntNT IdprogettovalidatoEqualThis)
		{
			PartecipantiXFilieraCollection PartecipantiXFilieraCollectionTemp = PartecipantiXFilieraDAL.Find(_dbProviderObj, IdpartecipanteEqualThis, CodfilieraEqualThis, CuaaEqualThis, 
IdprogettovalidatoEqualThis);
			PartecipantiXFilieraCollectionTemp.Provider = this;
			return PartecipantiXFilieraCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTI_X_FILIERA>
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
      <ID_PARTECIPANTE>Equal</ID_PARTECIPANTE>
      <COD_FILIERA>Equal</COD_FILIERA>
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_VALIDATO>Equal</ID_PROGETTO_VALIDATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_X_FILIERA>
*/