using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for StepXBandoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class StepXBandoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private StepXBandoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((StepXBando) info.GetValue(i.ToString(),typeof(StepXBando)));
			}
		}

		//Costruttore
		public StepXBandoCollection()
		{
			this.ItemType = typeof(StepXBando);
		}

		//Costruttore con provider
		public StepXBandoCollection(IStepXBandoProvider providerObj)
		{
			this.ItemType = typeof(StepXBando);
			this.Provider = providerObj;
		}

		//Get e Set
		public new StepXBando this[int index]
		{
			get { return (StepXBando)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new StepXBandoCollection GetChanges()
		{
			return (StepXBandoCollection) base.GetChanges();
		}

		[NonSerialized] private IStepXBandoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IStepXBandoProvider Provider
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
		public int Add(StepXBando StepXBandoObj)
		{
			if (StepXBandoObj.Provider == null) StepXBandoObj.Provider = this.Provider;
			return base.Add(StepXBandoObj);
		}

		//AddCollection
		public void AddCollection(StepXBandoCollection StepXBandoCollectionObj)
		{
			foreach (StepXBando StepXBandoObj in StepXBandoCollectionObj)
				this.Add(StepXBandoObj);
		}

		//Insert
		public void Insert(int index, StepXBando StepXBandoObj)
		{
			if (StepXBandoObj.Provider == null) StepXBandoObj.Provider = this.Provider;
			base.Insert(index, StepXBandoObj);
		}

		//CollectionGetById
		public StepXBando CollectionGetById(NullTypes.IntNT IdBandoValue, NullTypes.IntNT IdCheckListValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdBando == IdBandoValue) && (this[i].IdCheckList == IdCheckListValue))
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
		public StepXBandoCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdCheckListEqualThis, NullTypes.StringNT CodFaseEqualThis)
		{
			StepXBandoCollection StepXBandoCollectionTemp = new StepXBandoCollection();
			foreach (StepXBando StepXBandoItem in this)
			{
				if (((IdBandoEqualThis == null) || ((StepXBandoItem.IdBando != null) && (StepXBandoItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdCheckListEqualThis == null) || ((StepXBandoItem.IdCheckList != null) && (StepXBandoItem.IdCheckList.Value == IdCheckListEqualThis.Value))) && ((CodFaseEqualThis == null) || ((StepXBandoItem.CodFase != null) && (StepXBandoItem.CodFase.Value == CodFaseEqualThis.Value))))
				{
					StepXBandoCollectionTemp.Add(StepXBandoItem);
				}
			}
			return StepXBandoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<STEP_X_BANDO>
  <ViewName>vSTEP_X_BANDO</ViewName>
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
    <Find>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
      <ORDINE>Equal</ORDINE>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</STEP_X_BANDO>
*/