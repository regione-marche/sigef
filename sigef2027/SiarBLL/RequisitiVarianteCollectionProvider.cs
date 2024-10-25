using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

    /// <summary>
    /// Summary description for RequisitiVarianteCollectionProvider:IRequisitiVarianteProvider
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public class RequisitiVarianteCollectionProvider : IRequisitiVarianteProvider
    {

        //Definizione dell'oggetto classe DbProvider
        protected DbProvider _dbProviderObj;

        //Definizione della collection di RequisitiVariante
        protected RequisitiVarianteCollection _CollectionObj;

        //Costruttore 1: non popola la collection
        public RequisitiVarianteCollectionProvider()
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = new RequisitiVarianteCollection(this);
        }

        //Costruttore 2: popola la collection
        public RequisitiVarianteCollectionProvider(IntNT IdrequisitoEqualThis, BoolNT AutomaticoEqualThis)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = Find(IdrequisitoEqualThis, AutomaticoEqualThis);
        }

        //Costruttore3: ha in input requisitivarianteCollectionObj - non popola la collection
        public RequisitiVarianteCollectionProvider(RequisitiVarianteCollection obj)
        {
            _dbProviderObj = new DbProvider();
            _CollectionObj = obj;
        }

        //Costruttore4: ha in input il dbprovider - non popola la collection
        public RequisitiVarianteCollectionProvider(DbProvider dbProviderObj)
        {
            _dbProviderObj = dbProviderObj;
            _CollectionObj = new RequisitiVarianteCollection(this);
        }

        //Get e Set
        public RequisitiVarianteCollection CollectionObj
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
        public int SaveCollection(RequisitiVarianteCollection collectionObj)
        {
            return RequisitiVarianteDAL.SaveCollection(_dbProviderObj, collectionObj);
        }

        //Save3: registra l'elemento i-esimo della collection
        public int Save(int i)
        {
            return Save(_CollectionObj[i]);
        }

        //Save4: registra un elemento singolo
        public int Save(RequisitiVariante requisitivarianteObj)
        {
            return RequisitiVarianteDAL.Save(_dbProviderObj, requisitivarianteObj);
        }

        //delete1: elimina l'intera collection
        public int DeleteCollection()
        {
            return DeleteCollection(_CollectionObj);
        }

        //delete2: elimina una collection
        public int DeleteCollection(RequisitiVarianteCollection collectionObj)
        {
            return RequisitiVarianteDAL.DeleteCollection(_dbProviderObj, collectionObj);
        }

        //delete3: elimina l'elemento i-esimo della collection
        public int Delete(int i)
        {
            return Delete(_CollectionObj[i]);
        }

        //delete4: elimina un elemento singolo
        public int Delete(RequisitiVariante requisitivarianteObj)
        {
            return RequisitiVarianteDAL.Delete(_dbProviderObj, requisitivarianteObj);
        }

        //getById
        public RequisitiVariante GetById(IntNT IdRequisitoValue)
        {
            RequisitiVariante RequisitiVarianteTemp = RequisitiVarianteDAL.GetById(_dbProviderObj, IdRequisitoValue);
            if (RequisitiVarianteTemp != null) RequisitiVarianteTemp.Provider = this;
            return RequisitiVarianteTemp;
        }

        //Get e Set dei campi 'ForeignKey'
        //Select: popola la collection
        public RequisitiVarianteCollection Select(IntNT IdrequisitoEqualThis, BoolNT AutomaticoEqualThis, StringNT DescrizioneEqualThis,
StringNT QueryevalEqualThis, StringNT QueryinsertEqualThis, DecimalNT ValminimoEqualThis,
DecimalNT ValmassimoEqualThis, StringNT MisuraEqualThis)
        {
            RequisitiVarianteCollection RequisitiVarianteCollectionTemp = RequisitiVarianteDAL.Select(_dbProviderObj, IdrequisitoEqualThis, AutomaticoEqualThis, DescrizioneEqualThis,
QueryevalEqualThis, QueryinsertEqualThis, ValminimoEqualThis,
ValmassimoEqualThis, MisuraEqualThis);
            RequisitiVarianteCollectionTemp.Provider = this;
            return RequisitiVarianteCollectionTemp;
        }

        //Find: popola la collection
        public RequisitiVarianteCollection Find(IntNT IdrequisitoEqualThis, BoolNT AutomaticoEqualThis)
        {
            RequisitiVarianteCollection RequisitiVarianteCollectionTemp = RequisitiVarianteDAL.Find(_dbProviderObj, IdrequisitoEqualThis, AutomaticoEqualThis);
            RequisitiVarianteCollectionTemp.Provider = this;
            return RequisitiVarianteCollectionTemp;
        }


    }
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<REQUISITI_VARIANTE>
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
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <AUTOMATICO>Equal</AUTOMATICO>
    </Find>
  </Finds>
  <Filters>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</REQUISITI_VARIANTE>
*/