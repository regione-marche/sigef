using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for CorrettivaRendicontazioneSpostamentiCollectionProvider:ICorrettivaRendicontazioneSpostamentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CorrettivaRendicontazioneSpostamentiCollectionProvider : ICorrettivaRendicontazioneSpostamentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di CorrettivaRendicontazioneSpostamenti
		protected CorrettivaRendicontazioneSpostamentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public CorrettivaRendicontazioneSpostamentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new CorrettivaRendicontazioneSpostamentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public CorrettivaRendicontazioneSpostamentiCollectionProvider(IntNT IdcorrettivaEqualThis, IntNT IdinvestimentodaEqualThis, IntNT IdinvestimentoaEqualThis, 
BoolNT ConclusoEqualThis, BoolNT AnnullatoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdcorrettivaEqualThis, IdinvestimentodaEqualThis, IdinvestimentoaEqualThis, 
ConclusoEqualThis, AnnullatoEqualThis);
		}

		//Costruttore3: ha in input correttivarendicontazionespostamentiCollectionObj - non popola la collection
		public CorrettivaRendicontazioneSpostamentiCollectionProvider(CorrettivaRendicontazioneSpostamentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public CorrettivaRendicontazioneSpostamentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new CorrettivaRendicontazioneSpostamentiCollection(this);
		}

		//Get e Set
		public CorrettivaRendicontazioneSpostamentiCollection CollectionObj
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
		public int SaveCollection(CorrettivaRendicontazioneSpostamentiCollection collectionObj)
		{
			return CorrettivaRendicontazioneSpostamentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(CorrettivaRendicontazioneSpostamenti correttivarendicontazionespostamentiObj)
		{
			return CorrettivaRendicontazioneSpostamentiDAL.Save(_dbProviderObj, correttivarendicontazionespostamentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(CorrettivaRendicontazioneSpostamentiCollection collectionObj)
		{
			return CorrettivaRendicontazioneSpostamentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(CorrettivaRendicontazioneSpostamenti correttivarendicontazionespostamentiObj)
		{
			return CorrettivaRendicontazioneSpostamentiDAL.Delete(_dbProviderObj, correttivarendicontazionespostamentiObj);
		}

		//getById
		public CorrettivaRendicontazioneSpostamenti GetById(IntNT IdValue)
		{
			CorrettivaRendicontazioneSpostamenti CorrettivaRendicontazioneSpostamentiTemp = CorrettivaRendicontazioneSpostamentiDAL.GetById(_dbProviderObj, IdValue);
			if (CorrettivaRendicontazioneSpostamentiTemp!=null) CorrettivaRendicontazioneSpostamentiTemp.Provider = this;
			return CorrettivaRendicontazioneSpostamentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public CorrettivaRendicontazioneSpostamentiCollection Select(IntNT IdEqualThis, IntNT IdcorrettivaEqualThis, IntNT IdinvestimentodaEqualThis, 
IntNT IdinvestimentoaEqualThis, DecimalNT ImportospostatoEqualThis, BoolNT ConclusoEqualThis, 
BoolNT AnnullatoEqualThis, IntNT IdutenteEqualThis, DatetimeNT DataEqualThis, 
StringNT DescrizioneEqualThis, IntNT IdjsonlogEqualThis)
		{
			CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionTemp = CorrettivaRendicontazioneSpostamentiDAL.Select(_dbProviderObj, IdEqualThis, IdcorrettivaEqualThis, IdinvestimentodaEqualThis, 
IdinvestimentoaEqualThis, ImportospostatoEqualThis, ConclusoEqualThis, 
AnnullatoEqualThis, IdutenteEqualThis, DataEqualThis, 
DescrizioneEqualThis, IdjsonlogEqualThis);
			CorrettivaRendicontazioneSpostamentiCollectionTemp.Provider = this;
			return CorrettivaRendicontazioneSpostamentiCollectionTemp;
		}

		//Find: popola la collection
		public CorrettivaRendicontazioneSpostamentiCollection Find(IntNT IdcorrettivaEqualThis, IntNT IdinvestimentodaEqualThis, IntNT IdinvestimentoaEqualThis, 
BoolNT ConclusoEqualThis, BoolNT AnnullatoEqualThis)
		{
			CorrettivaRendicontazioneSpostamentiCollection CorrettivaRendicontazioneSpostamentiCollectionTemp = CorrettivaRendicontazioneSpostamentiDAL.Find(_dbProviderObj, IdcorrettivaEqualThis, IdinvestimentodaEqualThis, IdinvestimentoaEqualThis, 
ConclusoEqualThis, AnnullatoEqualThis);
			CorrettivaRendicontazioneSpostamentiCollectionTemp.Provider = this;
			return CorrettivaRendicontazioneSpostamentiCollectionTemp;
		}


	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
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
    <Find OrderBy="ORDER BY ID">
      <ID_CORRETTIVA>Equal</ID_CORRETTIVA>
      <ID_INVESTIMENTO_DA>Equal</ID_INVESTIMENTO_DA>
      <ID_INVESTIMENTO_A>Equal</ID_INVESTIMENTO_A>
      <CONCLUSO>Equal</CONCLUSO>
      <ANNULLATO>Equal</ANNULLATO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI>
*/