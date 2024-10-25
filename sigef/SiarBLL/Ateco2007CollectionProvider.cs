using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
    /// Summary description for Ateco2007CollectionProvider:IAteco2007Provider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class Ateco2007CollectionProvider : IAteco2007Provider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di Ateco2007
		protected Ateco2007Collection _CollectionObj;

		//Costruttore 1: non popola la collection
		public Ateco2007CollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new Ateco2007Collection(this);
		}

		//Costruttore 2: popola la collection
		public Ateco2007CollectionProvider(StringNT CodtipoEqualThis, StringNT DescrizioneLikeThis, IntNT idBandoEqualThis)
		{
			_dbProviderObj = new DbProvider();
            _CollectionObj = Find(CodtipoEqualThis, DescrizioneLikeThis, idBandoEqualThis);
		}

		//Costruttore3: ha in input Ateco2007CollectionObj - non popola la collection
		public Ateco2007CollectionProvider(Ateco2007Collection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
        public Ateco2007CollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
            _CollectionObj = new Ateco2007Collection(this);
		}

		//Get e Set
        public Ateco2007Collection CollectionObj
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
        public int SaveCollection(Ateco2007Collection collectionObj)
		{
            return Ateco2007DAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
        public int Save(Ateco2007 Ateco2007Obj)
		{
            return Ateco2007DAL.Save(_dbProviderObj, Ateco2007Obj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
        public int DeleteCollection(Ateco2007Collection collectionObj)
		{
            return Ateco2007DAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
        public int Delete(Ateco2007 Ateco2007Obj)
		{
            return Ateco2007DAL.Delete(_dbProviderObj, Ateco2007Obj);
		}

		//getById
        public Ateco2007 GetById(StringNT IdAllegatoValue)
		{
            Ateco2007 Ateco2007Temp = Ateco2007DAL.GetById(_dbProviderObj, IdAllegatoValue);
            if (Ateco2007Temp != null) Ateco2007Temp.Provider = this;
            return Ateco2007Temp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
        public Ateco2007Collection Select(StringNT IdAteco2007EqualThis, StringNT DescrizioneEqualThis, StringNT MisuraEqualThis, 
StringNT CodtipoEqualThis)
		{
            Ateco2007Collection Ateco2007CollectionTemp = Ateco2007DAL.Select(_dbProviderObj, IdAteco2007EqualThis, DescrizioneEqualThis);
            Ateco2007CollectionTemp.Provider = this;
            return Ateco2007CollectionTemp;
		}

		//Find: popola la collection
        public Ateco2007Collection Find(StringNT CodtipoStartWithThis, StringNT DescrizioneLikeThis, SiarLibrary.NullTypes.IntNT idBandoequalthis)
		{
            Ateco2007Collection Ateco2007CollectionTemp = Ateco2007DAL.Find(_dbProviderObj, CodtipoStartWithThis, DescrizioneLikeThis, idBandoequalthis);
            Ateco2007CollectionTemp.Provider = this;
            return Ateco2007CollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<ALLEGATI>
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
    <Find OrderBy="ORDER BY MISURA">
      <COD_TIPO>Equal</COD_TIPO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ALLEGATI>
*/
