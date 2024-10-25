using System;

/* STORIA
 * Data: 2016-05-24; Statoo: Creazione; Autore: 
*/

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for BilancioAgricoloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class DatiMonitoraggioFESRCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count",this.Count);
			for(int i=0;i<this.Count;i++)
			{
				info.AddValue(i.ToString(),this[i]);
			}
		}
		private DatiMonitoraggioFESRCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((DatiMonitoraggioFESR) info.GetValue(i.ToString(),typeof(DatiMonitoraggioFESR)));
			}
		}

		//Costruttore
		public DatiMonitoraggioFESRCollection()
		{
			this.ItemType = typeof(DatiMonitoraggioFESR);
		}

		//Costruttore con provider
        public DatiMonitoraggioFESRCollection(IDatiMonitoraggioFESRProvider providerObj)
		{
            this.ItemType = typeof(DatiMonitoraggioFESR);
			this.Provider = providerObj;
		}

		//Get e Set
        public new DatiMonitoraggioFESR this[int index]
		{
            get { return (DatiMonitoraggioFESR)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

        public new DatiMonitoraggioFESRCollection GetChanges()
		{
            return (DatiMonitoraggioFESRCollection)base.GetChanges();
		}

        [NonSerialized] private IDatiMonitoraggioFESRProvider _provider;
        [System.Xml.Serialization.XmlIgnore] public IDatiMonitoraggioFESRProvider Provider
		{
			get {return _provider;}
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
        public int Add(DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
            if (DatiMonitoraggioFESRObj.Provider == null) DatiMonitoraggioFESRObj.Provider = this.Provider;
            return base.Add(DatiMonitoraggioFESRObj);
		}

		//AddCollection
        public void AddCollection(DatiMonitoraggioFESRCollection DatiMonitoraggioFESRCollectionObj)
		{
            foreach (DatiMonitoraggioFESR DatiMonitoraggioFESRObj in DatiMonitoraggioFESRCollectionObj)
                this.Add(DatiMonitoraggioFESRObj);
		}

		//Insert
        public void Insert(int index, DatiMonitoraggioFESR DatiMonitoraggioFESRObj)
		{
            if (DatiMonitoraggioFESRObj.Provider == null) DatiMonitoraggioFESRObj.Provider = this.Provider;
            base.Insert(index, DatiMonitoraggioFESRObj);
		}

		//CollectionGetById
        public DatiMonitoraggioFESR CollectionGetById(NullTypes.IntNT IdDatiMonitoraggioFESRValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
                if ((this[i].IdDatiMonitoraggioFESR == IdDatiMonitoraggioFESRValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}

	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<DATI_MONITORAGGIO_FESR>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
      <ID_DATI_MONIT>Equal</ID_DATI_MONIT>
      <ID_PROGETTO>Equal</ID_PROGETTO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</BILANCIO_AGRICOLO>
*/