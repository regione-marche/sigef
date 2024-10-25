using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for BandoRequisitiVarianteCollectionProvider:IBandoRequisitiVarianteProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class BandoRequisitiVarianteCollectionProvider : IBandoRequisitiVarianteProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di BandoRequisitiVariante
		protected BandoRequisitiVarianteCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public BandoRequisitiVarianteCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new BandoRequisitiVarianteCollection(this);
		}

		//Costruttore 2: popola la collection
		public BandoRequisitiVarianteCollectionProvider(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, CodtipoEqualThis);
		}

		//Costruttore3: ha in input bandorequisitivarianteCollectionObj - non popola la collection
		public BandoRequisitiVarianteCollectionProvider(BandoRequisitiVarianteCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public BandoRequisitiVarianteCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new BandoRequisitiVarianteCollection(this);
		}

		//Get e Set
		public BandoRequisitiVarianteCollection CollectionObj
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
		public int SaveCollection(BandoRequisitiVarianteCollection collectionObj)
		{
			return BandoRequisitiVarianteDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(BandoRequisitiVariante bandorequisitivarianteObj)
		{
			return BandoRequisitiVarianteDAL.Save(_dbProviderObj, bandorequisitivarianteObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(BandoRequisitiVarianteCollection collectionObj)
		{
			return BandoRequisitiVarianteDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(BandoRequisitiVariante bandorequisitivarianteObj)
		{
			return BandoRequisitiVarianteDAL.Delete(_dbProviderObj, bandorequisitivarianteObj);
		}

		//getById
		public BandoRequisitiVariante GetById(IntNT IdBandoValue, StringNT CodTipoValue, IntNT IdRequisitoValue)
		{
			BandoRequisitiVariante BandoRequisitiVarianteTemp = BandoRequisitiVarianteDAL.GetById(_dbProviderObj, IdBandoValue, CodTipoValue, IdRequisitoValue);
			if (BandoRequisitiVarianteTemp!=null) BandoRequisitiVarianteTemp.Provider = this;
			return BandoRequisitiVarianteTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public BandoRequisitiVarianteCollection Select(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis, IntNT IdrequisitoEqualThis, 
BoolNT ObbligatorioEqualThis, BoolNT RequisitodipresentazioneEqualThis, BoolNT RequisitodiistruttoriaEqualThis, 
IntNT OrdineEqualThis)
		{
			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionTemp = BandoRequisitiVarianteDAL.Select(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis, IdrequisitoEqualThis, 
ObbligatorioEqualThis, RequisitodipresentazioneEqualThis, RequisitodiistruttoriaEqualThis, 
OrdineEqualThis);
			BandoRequisitiVarianteCollectionTemp.Provider = this;
			return BandoRequisitiVarianteCollectionTemp;
		}

		//Find: popola la collection
		public BandoRequisitiVarianteCollection Find(IntNT IdbandoEqualThis, StringNT CodtipoEqualThis)
		{
			BandoRequisitiVarianteCollection BandoRequisitiVarianteCollectionTemp = BandoRequisitiVarianteDAL.Find(_dbProviderObj, IdbandoEqualThis, CodtipoEqualThis);
			BandoRequisitiVarianteCollectionTemp.Provider = this;
			return BandoRequisitiVarianteCollectionTemp;
		}

        public BandoRequisitiVarianteCollection FindByBandoTipo(IntNT IdbandoEqualThis, string cod_tipo_variante)
        {
            BandoRequisitiVarianteCollection requisiti = new BandoRequisitiVarianteCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT R.*,ID_BANDO,COD_TIPO,OBBLIGATORIO,REQUISITO_DI_PRESENTAZIONE,REQUISITO_DI_ISTRUTTORIA,ORDINE 
                                FROM REQUISITI_VARIANTE R LEFT JOIN BANDO_REQUISITI_VARIANTE B ON R.ID_REQUISITO=B.ID_REQUISITO AND ID_BANDO=" + IdbandoEqualThis + @" 
                                AND COD_TIPO='" + cod_tipo_variante + "' ORDER BY ID_BANDO DESC,ORDINE";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read()) requisiti.Add(SiarDAL.BandoRequisitiVarianteDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return requisiti;
        }

        public BandoRequisitiVarianteCollection FindRequisitiEsistentiXMultimisura(IntNT IdBando, StringNT CodTipo)
        {
            BandoRequisitiVarianteCollection requisiti = new BandoRequisitiVarianteCollection();
            System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
            cmd.CommandText = "SELECT * FROM vBANDO_REQUISITI_VARIANTE R WHERE COD_TIPO='" + CodTipo + @"' AND ID_BANDO IN 
                               (SELECT DISTINCT ISNULL(ID_DISPOSIZIONI_ATTUATIVE,ID_BANDO) FROM BANDO_PROGRAMMAZIONE WHERE ID_BANDO IN 
                               (SELECT DISTINCT ID_BANDO FROM BANDO_PROGRAMMAZIONE WHERE ISNULL(ID_DISPOSIZIONI_ATTUATIVE,ID_BANDO)=" + IdBando + "))";
            DbProviderObj.InitDatareader(cmd);
            while (DbProviderObj.DataReader.Read())
                requisiti.Add(SiarDAL.BandoRequisitiVarianteDAL.GetFromDatareader(DbProviderObj));
            DbProviderObj.Close();
            return requisiti;
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<BANDO_REQUISITI_VARIANTE>
  <ViewName>vBANDO_REQUISITI_VARIANTE</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <ID_BANDO>Equal</ID_BANDO>
      <COD_TIPO>Equal</COD_TIPO>
    </Find>
  </Finds>
  <Filters>
    <FiltroProcedura>
      <REQUISITO_DI_PRESENTAZIONE>Equal</REQUISITO_DI_PRESENTAZIONE>
      <REQUISITO_DI_ISTRUTTORIA>Equal</REQUISITO_DI_ISTRUTTORIA>
    </FiltroProcedura>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</BANDO_REQUISITI_VARIANTE>
*/