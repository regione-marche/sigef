using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for PartecipantiIndirettiFatturatoCollectionProvider:IPartecipantiIndirettiFatturatoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PartecipantiIndirettiFatturatoCollectionProvider : IPartecipantiIndirettiFatturatoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di PartecipantiIndirettiFatturato
		protected PartecipantiIndirettiFatturatoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public PartecipantiIndirettiFatturatoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new PartecipantiIndirettiFatturatoCollection(this);
		}

		//Costruttore 2: popola la collection
		public PartecipantiIndirettiFatturatoCollectionProvider(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CuaatrasformatoreEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdimpresaEqualThis, CuaaEqualThis, CuaatrasformatoreEqualThis);
		}

		//Costruttore3: ha in input partecipantiindirettifatturatoCollectionObj - non popola la collection
		public PartecipantiIndirettiFatturatoCollectionProvider(PartecipantiIndirettiFatturatoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public PartecipantiIndirettiFatturatoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new PartecipantiIndirettiFatturatoCollection(this);
		}

		//Get e Set
		public PartecipantiIndirettiFatturatoCollection CollectionObj
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
		public int SaveCollection(PartecipantiIndirettiFatturatoCollection collectionObj)
		{
			return PartecipantiIndirettiFatturatoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(PartecipantiIndirettiFatturato partecipantiindirettifatturatoObj)
		{
			return PartecipantiIndirettiFatturatoDAL.Save(_dbProviderObj, partecipantiindirettifatturatoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(PartecipantiIndirettiFatturatoCollection collectionObj)
		{
			return PartecipantiIndirettiFatturatoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(PartecipantiIndirettiFatturato partecipantiindirettifatturatoObj)
		{
			return PartecipantiIndirettiFatturatoDAL.Delete(_dbProviderObj, partecipantiindirettifatturatoObj);
		}

		//getById
		public PartecipantiIndirettiFatturato GetById(IntNT IdValue)
		{
			PartecipantiIndirettiFatturato PartecipantiIndirettiFatturatoTemp = PartecipantiIndirettiFatturatoDAL.GetById(_dbProviderObj, IdValue);
			if (PartecipantiIndirettiFatturatoTemp!=null) PartecipantiIndirettiFatturatoTemp.Provider = this;
			return PartecipantiIndirettiFatturatoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public PartecipantiIndirettiFatturatoCollection Select(IntNT IdEqualThis, StringNT CuaapromotoreEqualThis, IntNT IdimpresaEqualThis, 
StringNT CuaaEqualThis, StringNT CodprodottoEqualThis, StringNT CodvarietaEqualThis, 
IntNT IdclasseallevamentoEqualThis, IntNT NumerocapiEqualThis, IntNT IdattivitaconnessaEqualThis, 
DecimalNT ProduzionetotaleEqualThis, DecimalNT ProduzioneinfilieraEqualThis, DecimalNT PrezzomedioEqualThis, 
DecimalNT FatturatoEqualThis, StringNT CuaatrasformatoreEqualThis)
		{
			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionTemp = PartecipantiIndirettiFatturatoDAL.Select(_dbProviderObj, IdEqualThis, CuaapromotoreEqualThis, IdimpresaEqualThis, 
CuaaEqualThis, CodprodottoEqualThis, CodvarietaEqualThis, 
IdclasseallevamentoEqualThis, NumerocapiEqualThis, IdattivitaconnessaEqualThis, 
ProduzionetotaleEqualThis, ProduzioneinfilieraEqualThis, PrezzomedioEqualThis, 
FatturatoEqualThis, CuaatrasformatoreEqualThis);
			PartecipantiIndirettiFatturatoCollectionTemp.Provider = this;
			return PartecipantiIndirettiFatturatoCollectionTemp;
		}

		//Find: popola la collection
		public PartecipantiIndirettiFatturatoCollection Find(IntNT IdimpresaEqualThis, StringNT CuaaEqualThis, StringNT CuaatrasformatoreEqualThis)
		{
			PartecipantiIndirettiFatturatoCollection PartecipantiIndirettiFatturatoCollectionTemp = PartecipantiIndirettiFatturatoDAL.Find(_dbProviderObj, IdimpresaEqualThis, CuaaEqualThis, CuaatrasformatoreEqualThis);
			PartecipantiIndirettiFatturatoCollectionTemp.Provider = this;
			return PartecipantiIndirettiFatturatoCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTI_INDIRETTI_FATTURATO>
  <ViewName>vPARECIPANTI_INDIRETTI_FATTURATO</ViewName>
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
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <CUAA>Equal</CUAA>
      <CUAA_TRASFORMATORE>Equal</CUAA_TRASFORMATORE>
    </Find>
  </Finds>
  <Filters>
    <FiltroProdotto>
      <COD_PRODOTTO>IsNull</COD_PRODOTTO>
    </FiltroProdotto>
    <FiltroAllevamento>
      <ID_CLASSE_ALLEVAMENTO>IsNull</ID_CLASSE_ALLEVAMENTO>
    </FiltroAllevamento>
    <FiltroAttivita>
      <ID_ATTIVITA_CONNESSA>IsNull</ID_ATTIVITA_CONNESSA>
    </FiltroAttivita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTI_INDIRETTI_FATTURATO>
*/