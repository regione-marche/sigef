using System;

namespace SiarLibrary
{

    /// <summary>
    /// Summary description for RequisitiVarianteCollection
    /// Class Autogenerata
    /// Inserire eventuali operazioni aggiuntive
    /// </summary>

    [Serializable]

    public class RequisitiVarianteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
    {

        //Serializzazione xml
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("_count", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue(i.ToString(), this[i]);
            }
        }
        private RequisitiVarianteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : this()
        {
            int c = info.GetInt32("_count");
            for (int i = 0; i < c; i++)
            {
                this.Add((RequisitiVariante)info.GetValue(i.ToString(), typeof(RequisitiVariante)));
            }
        }

        //Costruttore
        public RequisitiVarianteCollection()
        {
            this.ItemType = typeof(RequisitiVariante);
        }

        //Costruttore con provider
        public RequisitiVarianteCollection(IRequisitiVarianteProvider providerObj)
        {
            this.ItemType = typeof(RequisitiVariante);
            this.Provider = providerObj;
        }

        //Get e Set
        public new RequisitiVariante this[int index]
        {
            get { return (RequisitiVariante)(base[index]); }
            set
            {
                base[index] = value;
            }
        }

        public new RequisitiVarianteCollection GetChanges()
        {
            return (RequisitiVarianteCollection)base.GetChanges();
        }

        [NonSerialized]
        private IRequisitiVarianteProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public IRequisitiVarianteProvider Provider
        {
            get { return _provider; }
            set
            {
                _provider = value;
                for (int i = 0; i < this.Count; i++)
                {
                    this[i].Provider = value;
                }
            }
        }

        public int SaveCollection()
        {
            return _provider.SaveCollection(this);
        }
        public int DeleteCollection()
        {
            return _provider.DeleteCollection(this);
        }
        //Add
        public int Add(RequisitiVariante RequisitiVarianteObj)
        {
            if (RequisitiVarianteObj.Provider == null) RequisitiVarianteObj.Provider = this.Provider;
            return base.Add(RequisitiVarianteObj);
        }

        //AddCollection
        public void AddCollection(RequisitiVarianteCollection RequisitiVarianteCollectionObj)
        {
            foreach (RequisitiVariante RequisitiVarianteObj in RequisitiVarianteCollectionObj)
                this.Add(RequisitiVarianteObj);
        }

        //Insert
        public void Insert(int index, RequisitiVariante RequisitiVarianteObj)
        {
            if (RequisitiVarianteObj.Provider == null) RequisitiVarianteObj.Provider = this.Provider;
            base.Insert(index, RequisitiVarianteObj);
        }

        //CollectionGetById
        public RequisitiVariante CollectionGetById(NullTypes.IntNT IdRequisitoValue)
        {
            int i = 0;
            bool find = false;
            while ((i < this.Count) && (!find))
            {
                if ((this[i].IdRequisito == IdRequisitoValue))
                    find = true;
                else
                    i++;
            }
            if (find)
                return this[i];
            else
                return null;
        }
        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public RequisitiVarianteCollection SubSelect(NullTypes.IntNT IdRequisitoEqualThis, NullTypes.BoolNT AutomaticoEqualThis, NullTypes.StringNT DescrizioneEqualThis,
NullTypes.StringNT QueryEvalEqualThis, NullTypes.StringNT QueryInsertEqualThis, NullTypes.DecimalNT ValMinimoEqualThis,
NullTypes.DecimalNT ValMassimoEqualThis, NullTypes.StringNT MisuraEqualThis)
        {
            RequisitiVarianteCollection RequisitiVarianteCollectionTemp = new RequisitiVarianteCollection();
            foreach (RequisitiVariante RequisitiVarianteItem in this)
            {
                if (((IdRequisitoEqualThis == null) || ((RequisitiVarianteItem.IdRequisito != null) && (RequisitiVarianteItem.IdRequisito.Value == IdRequisitoEqualThis.Value))) && ((AutomaticoEqualThis == null) || ((RequisitiVarianteItem.Automatico != null) && (RequisitiVarianteItem.Automatico.Value == AutomaticoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((RequisitiVarianteItem.Descrizione != null) && (RequisitiVarianteItem.Descrizione.Value == DescrizioneEqualThis.Value))) &&
((QueryEvalEqualThis == null) || ((RequisitiVarianteItem.QueryEval != null) && (RequisitiVarianteItem.QueryEval.Value == QueryEvalEqualThis.Value))) && ((QueryInsertEqualThis == null) || ((RequisitiVarianteItem.QueryInsert != null) && (RequisitiVarianteItem.QueryInsert.Value == QueryInsertEqualThis.Value))) && ((ValMinimoEqualThis == null) || ((RequisitiVarianteItem.ValMinimo != null) && (RequisitiVarianteItem.ValMinimo.Value == ValMinimoEqualThis.Value))) &&
((ValMassimoEqualThis == null) || ((RequisitiVarianteItem.ValMassimo != null) && (RequisitiVarianteItem.ValMassimo.Value == ValMassimoEqualThis.Value))) && ((MisuraEqualThis == null) || ((RequisitiVarianteItem.Misura != null) && (RequisitiVarianteItem.Misura.Value == MisuraEqualThis.Value))))
                {
                    RequisitiVarianteCollectionTemp.Add(RequisitiVarianteItem);
                }
            }
            return RequisitiVarianteCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public RequisitiVarianteCollection FiltroAutomatico(NullTypes.BoolNT AutomaticoEqualThis)
        {
            RequisitiVarianteCollection RequisitiVarianteCollectionTemp = new RequisitiVarianteCollection();
            foreach (RequisitiVariante RequisitiVarianteItem in this)
            {
                if (((AutomaticoEqualThis == null) || ((RequisitiVarianteItem.Automatico != null) && (RequisitiVarianteItem.Automatico.Value == AutomaticoEqualThis.Value))))
                {
                    RequisitiVarianteCollectionTemp.Add(RequisitiVarianteItem);
                }
            }
            return RequisitiVarianteCollectionTemp;
        }


        //filter: effettua una ricerca all'interno della collection
        // se il parametro di ricerca è null, prende tutto,
        // anche i record che hanno quel campo null
        // altrimenti scarta i record che hanno quel campo null ...
        // ...e confronta gli altri
        public RequisitiVarianteCollection FiltroMisura(NullTypes.StringNT MisuraEqualThis)
        {
            RequisitiVarianteCollection RequisitiVarianteCollectionTemp = new RequisitiVarianteCollection();
            foreach (RequisitiVariante RequisitiVarianteItem in this)
            {
                if (((MisuraEqualThis == null) || ((RequisitiVarianteItem.Misura != null) && (RequisitiVarianteItem.Misura.Value == MisuraEqualThis.Value))))
                {
                    RequisitiVarianteCollectionTemp.Add(RequisitiVarianteItem);
                }
            }
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