using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for CollaboratoriXManifestazioneCollectionProvider:ICollaboratoriXManifestazioneProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CollaboratoriXManifestazioneCollectionProvider : ICollaboratoriXManifestazioneProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CollaboratoriXManifestazione
		protected CollaboratoriXManifestazioneCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CollaboratoriXManifestazioneCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CollaboratoriXManifestazioneCollection(this);
		}

		//Costruttore 2: popola la collection
		public CollaboratoriXManifestazioneCollectionProvider(IntNT IdbandoEqualThis, IntNT IdmanifestazioneEqualThis, StringNT CfutenteEqualThis, 
StringNT CuaaLikeThis, StringNT RagionesocialeLikeThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdmanifestazioneEqualThis, CfutenteEqualThis, 
CuaaLikeThis, RagionesocialeLikeThis);
		}

		//Costruttore3: ha in input collaboratorixmanifestazioneCollectionObj - non popola la collection
		public CollaboratoriXManifestazioneCollectionProvider(CollaboratoriXManifestazioneCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CollaboratoriXManifestazioneCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CollaboratoriXManifestazioneCollection(this);
		}

		//Get e Set
		public CollaboratoriXManifestazioneCollection CollectionObj
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
		public int SaveCollection(CollaboratoriXManifestazioneCollection collectionObj)
		{
			return CollaboratoriXManifestazioneDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CollaboratoriXManifestazione collaboratorixmanifestazioneObj)
		{
			return CollaboratoriXManifestazioneDAL.Save(_dbProviderObj, collaboratorixmanifestazioneObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CollaboratoriXManifestazioneCollection collectionObj)
		{
			return CollaboratoriXManifestazioneDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CollaboratoriXManifestazione collaboratorixmanifestazioneObj)
		{
			return CollaboratoriXManifestazioneDAL.Delete(_dbProviderObj, collaboratorixmanifestazioneObj);
		}

		//getById
		public CollaboratoriXManifestazione GetById(IntNT IdCollaboratoreValue)
		{
			CollaboratoriXManifestazione CollaboratoriXManifestazioneTemp = CollaboratoriXManifestazioneDAL.GetById(_dbProviderObj, IdCollaboratoreValue);
			if (CollaboratoriXManifestazioneTemp!=null) CollaboratoriXManifestazioneTemp.Provider = this;
			return CollaboratoriXManifestazioneTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CollaboratoriXManifestazioneCollection Select(IntNT IdcollaboratoreEqualThis, IntNT IdbandoEqualThis, IntNT IdmanifestazioneEqualThis, 
StringNT CfutenteEqualThis, StringNT OperatoreEqualThis, DatetimeNT DatainserimentoEqualThis)
		{
			CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionTemp = CollaboratoriXManifestazioneDAL.Select(_dbProviderObj, IdcollaboratoreEqualThis, IdbandoEqualThis, IdmanifestazioneEqualThis, 
CfutenteEqualThis, OperatoreEqualThis, DatainserimentoEqualThis);
			CollaboratoriXManifestazioneCollectionTemp.Provider = this;
			return CollaboratoriXManifestazioneCollectionTemp;
		}

		//Find: popola la collection
		public CollaboratoriXManifestazioneCollection Find(IntNT IdbandoEqualThis, IntNT IdmanifestazioneEqualThis, StringNT CfutenteEqualThis, 
StringNT CuaaLikeThis, StringNT RagionesocialeLikeThis)
		{
			CollaboratoriXManifestazioneCollection CollaboratoriXManifestazioneCollectionTemp = CollaboratoriXManifestazioneDAL.Find(_dbProviderObj, IdbandoEqualThis, IdmanifestazioneEqualThis, CfutenteEqualThis, 
CuaaLikeThis, RagionesocialeLikeThis);
			CollaboratoriXManifestazioneCollectionTemp.Provider = this;
			return CollaboratoriXManifestazioneCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<COLLABORATORI_X_MANIFESTAZIONE>
  <ViewName>vCOLLABORATORI_X_MANIFESTAZIONE</ViewName>
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
      <ID_BANDO>Equal</ID_BANDO>
      <ID_MANIFESTAZIONE>Equal</ID_MANIFESTAZIONE>
      <CF_UTENTE>Equal</CF_UTENTE>
      <CUAA>Like</CUAA>
      <RAGIONE_SOCIALE>Like</RAGIONE_SOCIALE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</COLLABORATORI_X_MANIFESTAZIONE>
*/