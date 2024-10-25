using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for StepParametriCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class StepParametriCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private StepParametriCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((StepParametri) info.GetValue(i.ToString(),typeof(StepParametri)));
			}
		}

		//Costruttore
		public StepParametriCollection()
		{
			this.ItemType = typeof(StepParametri);
		}

		//Costruttore con provider
		public StepParametriCollection(IStepParametriProvider providerObj)
		{
			this.ItemType = typeof(StepParametri);
			this.Provider = providerObj;
		}

		//Get e Set
		public new StepParametri this[int index]
		{
			get { return (StepParametri)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new StepParametriCollection GetChanges()
		{
			return (StepParametriCollection) base.GetChanges();
		}

		[NonSerialized] private IStepParametriProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IStepParametriProvider Provider
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
		public int Add(StepParametri StepParametriObj)
		{
			if (StepParametriObj.Provider == null) StepParametriObj.Provider = this.Provider;
			return base.Add(StepParametriObj);
		}

		//AddCollection
		public void AddCollection(StepParametriCollection StepParametriCollectionObj)
		{
			foreach (StepParametri StepParametriObj in StepParametriCollectionObj)
				this.Add(StepParametriObj);
		}

		//Insert
		public void Insert(int index, StepParametri StepParametriObj)
		{
			if (StepParametriObj.Provider == null) StepParametriObj.Provider = this.Provider;
			base.Insert(index, StepParametriObj);
		}

		//CollectionGetById
		public StepParametri CollectionGetById(NullTypes.IntNT IdParametroValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdParametro == IdParametroValue))
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
		public StepParametriCollection SubSelect(NullTypes.IntNT IdParametroEqualThis, NullTypes.IntNT IdStepEqualThis, NullTypes.StringNT NomeEqualThis, 
NullTypes.StringNT TipoEqualThis)
		{
			StepParametriCollection StepParametriCollectionTemp = new StepParametriCollection();
			foreach (StepParametri StepParametriItem in this)
			{
				if (((IdParametroEqualThis == null) || ((StepParametriItem.IdParametro != null) && (StepParametriItem.IdParametro.Value == IdParametroEqualThis.Value))) && ((IdStepEqualThis == null) || ((StepParametriItem.IdStep != null) && (StepParametriItem.IdStep.Value == IdStepEqualThis.Value))) && ((NomeEqualThis == null) || ((StepParametriItem.Nome != null) && (StepParametriItem.Nome.Value == NomeEqualThis.Value))) && 
((TipoEqualThis == null) || ((StepParametriItem.Tipo != null) && (StepParametriItem.Tipo.Value == TipoEqualThis.Value))))
				{
					StepParametriCollectionTemp.Add(StepParametriItem);
				}
			}
			return StepParametriCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<STEP_PARAMETRI>
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
    <Find>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <ID_STEP>Equal</ID_STEP>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</STEP_PARAMETRI>
*/