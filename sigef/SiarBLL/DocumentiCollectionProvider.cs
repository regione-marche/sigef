using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for DocumentiCollectionProvider:IDocumentiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DocumentiCollectionProvider : IDocumentiProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Documenti
		protected DocumentiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public DocumentiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new DocumentiCollection(this);
		}

		//Costruttore 2: popola la collection
		public DocumentiCollectionProvider(StringNT TitoloLikeThis, StringNT DescrizioneLikeThis, DatetimeNT DatafinevaliditaEqGreaterThanThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(TitoloLikeThis, DescrizioneLikeThis, DatafinevaliditaEqGreaterThanThis);
		}

		//Costruttore3: ha in input documentiCollectionObj - non popola la collection
		public DocumentiCollectionProvider(DocumentiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public DocumentiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new DocumentiCollection(this);
		}

		//Get e Set
		public DocumentiCollection CollectionObj
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
		public int SaveCollection(DocumentiCollection collectionObj)
		{
			return DocumentiDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(Documenti documentiObj)
		{
			return DocumentiDAL.Save(_dbProviderObj, documentiObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(DocumentiCollection collectionObj)
		{
			return DocumentiDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(Documenti documentiObj)
		{
			return DocumentiDAL.Delete(_dbProviderObj, documentiObj);
		}

		//getById
		public Documenti GetById(IntNT IdDocumentoValue)
		{
			Documenti DocumentiTemp = DocumentiDAL.GetById(_dbProviderObj, IdDocumentoValue);
			if (DocumentiTemp!=null) DocumentiTemp.Provider = this;
			return DocumentiTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public DocumentiCollection Select(IntNT IddocumentoEqualThis, StringNT TitoloEqualThis, StringNT DescrizioneEqualThis, 
DatetimeNT DatamodificaEqualThis, StringNT OperatoreEqualThis, DatetimeNT DatafinevaliditaEqualThis)
		{
			DocumentiCollection DocumentiCollectionTemp = DocumentiDAL.Select(_dbProviderObj, IddocumentoEqualThis, TitoloEqualThis, DescrizioneEqualThis, 
DatamodificaEqualThis, OperatoreEqualThis, DatafinevaliditaEqualThis);
			DocumentiCollectionTemp.Provider = this;
			return DocumentiCollectionTemp;
		}

		//Find: popola la collection
		public DocumentiCollection Find(StringNT TitoloLikeThis, StringNT DescrizioneLikeThis, DatetimeNT DatafinevaliditaEqGreaterThanThis)
		{
			DocumentiCollection DocumentiCollectionTemp = DocumentiDAL.Find(_dbProviderObj, TitoloLikeThis, DescrizioneLikeThis, DatafinevaliditaEqGreaterThanThis);
			DocumentiCollectionTemp.Provider = this;
			return DocumentiCollectionTemp;
		}

        public DocumentiCollection GetDocumentiPubblici(string descrizione)
        {
            DocumentiCollection cc = new DocumentiCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SpGetDocumentiPubblici";
            if (!string.IsNullOrEmpty(descrizione)) descrizione = descrizione.Replace("%", "");
            if (!string.IsNullOrEmpty(descrizione)) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("DESCRIZIONE", descrizione));
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) cc.Add(DocumentiDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return cc;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DOCUMENTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY DATA_MODIFICA DESC">
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <DATA_FINE_VALIDITA>EqGreaterThan</DATA_FINE_VALIDITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDescrizione>
      <TITOLO>Like</TITOLO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </FiltroDescrizione>
  </Filters>
  <externalFields />
  <AddedFkFields />
</DOCUMENTI>
*/