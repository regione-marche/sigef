using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PrioritaSettorialiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PrioritaSettorialiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PrioritaSettorialiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PrioritaSettoriali) info.GetValue(i.ToString(),typeof(PrioritaSettoriali)));
			}
		}

		//Costruttore
		public PrioritaSettorialiCollection()
		{
			this.ItemType = typeof(PrioritaSettoriali);
		}

		//Costruttore con provider
		public PrioritaSettorialiCollection(IPrioritaSettorialiProvider providerObj)
		{
			this.ItemType = typeof(PrioritaSettoriali);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PrioritaSettoriali this[int index]
		{
			get { return (PrioritaSettoriali)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PrioritaSettorialiCollection GetChanges()
		{
			return (PrioritaSettorialiCollection) base.GetChanges();
		}

		[NonSerialized] private IPrioritaSettorialiProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPrioritaSettorialiProvider Provider
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
		public int Add(PrioritaSettoriali PrioritaSettorialiObj)
		{
			if (PrioritaSettorialiObj.Provider == null) PrioritaSettorialiObj.Provider = this.Provider;
			return base.Add(PrioritaSettorialiObj);
		}

		//AddCollection
		public void AddCollection(PrioritaSettorialiCollection PrioritaSettorialiCollectionObj)
		{
			foreach (PrioritaSettoriali PrioritaSettorialiObj in PrioritaSettorialiCollectionObj)
				this.Add(PrioritaSettorialiObj);
		}

		//Insert
		public void Insert(int index, PrioritaSettoriali PrioritaSettorialiObj)
		{
			if (PrioritaSettorialiObj.Provider == null) PrioritaSettorialiObj.Provider = this.Provider;
			base.Insert(index, PrioritaSettorialiObj);
		}

		//CollectionGetById
		public PrioritaSettoriali CollectionGetById(NullTypes.IntNT IdPrioritaSettorialeValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPrioritaSettoriale == IdPrioritaSettorialeValue))
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
		public PrioritaSettorialiCollection SubSelect(NullTypes.IntNT IdPrioritaSettorialeEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			PrioritaSettorialiCollection PrioritaSettorialiCollectionTemp = new PrioritaSettorialiCollection();
			foreach (PrioritaSettoriali PrioritaSettorialiItem in this)
			{
				if (((IdPrioritaSettorialeEqualThis == null) || ((PrioritaSettorialiItem.IdPrioritaSettoriale != null) && (PrioritaSettorialiItem.IdPrioritaSettoriale.Value == IdPrioritaSettorialeEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((PrioritaSettorialiItem.Descrizione != null) && (PrioritaSettorialiItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					PrioritaSettorialiCollectionTemp.Add(PrioritaSettorialiItem);
				}
			}
			return PrioritaSettorialiCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PRIORITA_SETTORIALI>
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
    <Find OrderBy="ORDER BY DESCRIZIONE">
      <ID_PRIORITA_SETTORIALE>Equal</ID_PRIORITA_SETTORIALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</PRIORITA_SETTORIALI>
*/