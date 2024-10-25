using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PartecipanteRuoloCollectionProvider:IPartecipanteRuoloProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PartecipanteRuoloCollectionProvider : IPartecipanteRuoloProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PartecipanteRuolo
		protected PartecipanteRuoloCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PartecipanteRuoloCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PartecipanteRuoloCollection(this);
		}

		//Costruttore 2: popola la collection
		public PartecipanteRuoloCollectionProvider(StringNT CuaaEqualThis, IntNT IdprogettopifEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CuaaEqualThis, IdprogettopifEqualThis);
		}

		//Costruttore3: ha in input partecipanteruoloCollectionObj - non popola la collection
		public PartecipanteRuoloCollectionProvider(PartecipanteRuoloCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PartecipanteRuoloCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PartecipanteRuoloCollection(this);
		}

		//Get e Set
		public PartecipanteRuoloCollection CollectionObj
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
		public int SaveCollection(PartecipanteRuoloCollection collectionObj)
		{
			return PartecipanteRuoloDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PartecipanteRuolo partecipanteruoloObj)
		{
			return PartecipanteRuoloDAL.Save(_dbProviderObj, partecipanteruoloObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PartecipanteRuoloCollection collectionObj)
		{
			return PartecipanteRuoloDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PartecipanteRuolo partecipanteruoloObj)
		{
			return PartecipanteRuoloDAL.Delete(_dbProviderObj, partecipanteruoloObj);
		}

		//getById
		public PartecipanteRuolo GetById(IntNT IdPartcipanteRuoloValue)
		{
			PartecipanteRuolo PartecipanteRuoloTemp = PartecipanteRuoloDAL.GetById(_dbProviderObj, IdPartcipanteRuoloValue);
			if (PartecipanteRuoloTemp!=null) PartecipanteRuoloTemp.Provider = this;
			return PartecipanteRuoloTemp;
		}

		//Select: popola la collection
		public PartecipanteRuoloCollection Select(IntNT IdpartcipanteruoloEqualThis, IntNT IdprogettopifEqualThis, StringNT CodfilieraEqualThis, 
StringNT CuaaEqualThis, BoolNT FlagpartecipanteEqualThis, StringNT CodruolositraEqualThis, 
StringNT CodruolopartecipanteEqualThis, StringNT CodsistemaqualitaEqualThis, StringNT OperatoreinserimentoEqualThis, 
DatetimeNT DatamodificaEqualThis)
		{
			PartecipanteRuoloCollection PartecipanteRuoloCollectionTemp = PartecipanteRuoloDAL.Select(_dbProviderObj, IdpartcipanteruoloEqualThis, IdprogettopifEqualThis, CodfilieraEqualThis, 
CuaaEqualThis, FlagpartecipanteEqualThis, CodruolositraEqualThis, 
CodruolopartecipanteEqualThis, CodsistemaqualitaEqualThis, OperatoreinserimentoEqualThis, 
DatamodificaEqualThis);
			PartecipanteRuoloCollectionTemp.Provider = this;
			return PartecipanteRuoloCollectionTemp;
		}

		//Find: popola la collection
		public PartecipanteRuoloCollection Find(StringNT CuaaEqualThis, IntNT IdprogettopifEqualThis)
		{
			PartecipanteRuoloCollection PartecipanteRuoloCollectionTemp = PartecipanteRuoloDAL.Find(_dbProviderObj, CuaaEqualThis, IdprogettopifEqualThis);
			PartecipanteRuoloCollectionTemp.Provider = this;
			return PartecipanteRuoloCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTE_RUOLO>
  <ViewName>vPARTECIPANTE_RUOLO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
    <Find OrderBy="ORDER BY ">
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_PIF>Equal</ID_PROGETTO_PIF>
    </Find>
  </Finds>
  <Filters>
    <FiltroSitra>
      <COD_RUOLO_SITRA>Equal</COD_RUOLO_SITRA>
    </FiltroSitra>
    <FiltroRuoloOperativo>
      <COD_RUOLO_PARTECIPANTE>Equal</COD_RUOLO_PARTECIPANTE>
    </FiltroRuoloOperativo>
    <FiltroQualita>
      <COD_SISTEMA_QUALITA>Equal</COD_SISTEMA_QUALITA>
    </FiltroQualita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTE_RUOLO>
*/