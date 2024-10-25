using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for EnteCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class EnteCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private EnteCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Ente) info.GetValue(i.ToString(),typeof(Ente)));
			}
		}

		//Costruttore
		public EnteCollection()
		{
			this.ItemType = typeof(Ente);
		}

		//Costruttore con provider
		public EnteCollection(IEnteProvider providerObj)
		{
			this.ItemType = typeof(Ente);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Ente this[int index]
		{
			get { return (Ente)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new EnteCollection GetChanges()
		{
			return (EnteCollection) base.GetChanges();
		}

		[NonSerialized] private IEnteProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IEnteProvider Provider
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
		public int Add(Ente EnteObj)
		{
			if (EnteObj.Provider == null) EnteObj.Provider = this.Provider;
			return base.Add(EnteObj);
		}

		//AddCollection
		public void AddCollection(EnteCollection EnteCollectionObj)
		{
			foreach (Ente EnteObj in EnteCollectionObj)
				this.Add(EnteObj);
		}

		//Insert
		public void Insert(int index, Ente EnteObj)
		{
			if (EnteObj.Provider == null) EnteObj.Provider = this.Provider;
			base.Insert(index, EnteObj);
		}

		//CollectionGetById
		public Ente CollectionGetById(NullTypes.StringNT CodEnteValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].CodEnte == CodEnteValue))
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
		public EnteCollection SubSelect(NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT CodTipoEnteEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.StringNT CodSianEqualThis, NullTypes.BoolNT AttivoEqualThis)
		{
			EnteCollection EnteCollectionTemp = new EnteCollection();
			foreach (Ente EnteItem in this)
			{
				if (((CodEnteEqualThis == null) || ((EnteItem.CodEnte != null) && (EnteItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((CodTipoEnteEqualThis == null) || ((EnteItem.CodTipoEnte != null) && (EnteItem.CodTipoEnte.Value == CodTipoEnteEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((EnteItem.Descrizione != null) && (EnteItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((CodSianEqualThis == null) || ((EnteItem.CodSian != null) && (EnteItem.CodSian.Value == CodSianEqualThis.Value))) && ((AttivoEqualThis == null) || ((EnteItem.Attivo != null) && (EnteItem.Attivo.Value == AttivoEqualThis.Value))))
				{
					EnteCollectionTemp.Add(EnteItem);
				}
			}
			return EnteCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<ENTE>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
    <Find OrderBy="ORDER BY COD_TIPO_ENTE, ATTIVO DESC, COD_ENTE">
      <COD_ENTE>Equal</COD_ENTE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
      <ATTIVO>Equal</ATTIVO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</ENTE>
*/