using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for CheckListCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CheckListCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CheckListCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((CheckList) info.GetValue(i.ToString(),typeof(CheckList)));
			}
		}

		//Costruttore
		public CheckListCollection()
		{
			this.ItemType = typeof(CheckList);
		}

		//Costruttore con provider
		public CheckListCollection(ICheckListProvider providerObj)
		{
			this.ItemType = typeof(CheckList);
			this.Provider = providerObj;
		}

		//Get e Set
		public new CheckList this[int index]
		{
			get { return (CheckList)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new CheckListCollection GetChanges()
		{
			return (CheckListCollection) base.GetChanges();
		}

		[NonSerialized] private ICheckListProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ICheckListProvider Provider
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
		public int Add(CheckList CheckListObj)
		{
			if (CheckListObj.Provider == null) CheckListObj.Provider = this.Provider;
			return base.Add(CheckListObj);
		}

		//AddCollection
		public void AddCollection(CheckListCollection CheckListCollectionObj)
		{
			foreach (CheckList CheckListObj in CheckListCollectionObj)
				this.Add(CheckListObj);
		}

		//Insert
		public void Insert(int index, CheckList CheckListObj)
		{
			if (CheckListObj.Provider == null) CheckListObj.Provider = this.Provider;
			base.Insert(index, CheckListObj);
		}

		//CollectionGetById
		public CheckList CollectionGetById(NullTypes.IntNT IdCheckListValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdCheckList == IdCheckListValue))
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
		public CheckListCollection SubSelect(NullTypes.IntNT IdCheckListEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT FlagTemplateEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis, NullTypes.StringNT OperatoreEqualThis)
		{
			CheckListCollection CheckListCollectionTemp = new CheckListCollection();
			foreach (CheckList CheckListItem in this)
			{
				if (((IdCheckListEqualThis == null) || ((CheckListItem.IdCheckList != null) && (CheckListItem.IdCheckList.Value == IdCheckListEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((CheckListItem.Descrizione != null) && (CheckListItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((FlagTemplateEqualThis == null) || ((CheckListItem.FlagTemplate != null) && (CheckListItem.FlagTemplate.Value == FlagTemplateEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((CheckListItem.DataModifica != null) && (CheckListItem.DataModifica.Value == DataModificaEqualThis.Value))) && ((OperatoreEqualThis == null) || ((CheckListItem.Operatore != null) && (CheckListItem.Operatore.Value == OperatoreEqualThis.Value))))
				{
					CheckListCollectionTemp.Add(CheckListItem);
				}
			}
			return CheckListCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CHECK_LIST>
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
    <Find OrderBy="ORDER BY ID_CHECK_LIST">
      <DESCRIZIONE>Like</DESCRIZIONE>
      <FLAG_TEMPLATE>Equal</FLAG_TEMPLATE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CHECK_LIST>
*/