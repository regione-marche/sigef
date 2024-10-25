using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for StepCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class StepCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private StepCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((Step) info.GetValue(i.ToString(),typeof(Step)));
			}
		}

		//Costruttore
		public StepCollection()
		{
			this.ItemType = typeof(Step);
		}

		//Costruttore con provider
		public StepCollection(IStepProvider providerObj)
		{
			this.ItemType = typeof(Step);
			this.Provider = providerObj;
		}

		//Get e Set
		public new Step this[int index]
		{
			get { return (Step)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new StepCollection GetChanges()
		{
			return (StepCollection) base.GetChanges();
		}

		[NonSerialized] private IStepProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IStepProvider Provider
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
		public int Add(Step StepObj)
		{
			if (StepObj.Provider == null) StepObj.Provider = this.Provider;
			return base.Add(StepObj);
		}

		//AddCollection
		public void AddCollection(StepCollection StepCollectionObj)
		{
			foreach (Step StepObj in StepCollectionObj)
				this.Add(StepObj);
		}

		//Insert
		public void Insert(int index, Step StepObj)
		{
			if (StepObj.Provider == null) StepObj.Provider = this.Provider;
			base.Insert(index, StepObj);
		}

		//CollectionGetById
		public Step CollectionGetById(NullTypes.IntNT IdStepValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdStep == IdStepValue))
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
		public StepCollection SubSelect(NullTypes.IntNT IdStepEqualThis, NullTypes.StringNT CodFaseEqualThis, NullTypes.StringNT DescrizioneEqualThis, 
NullTypes.BoolNT AutomaticoEqualThis, NullTypes.StringNT QuerySqlEqualThis, NullTypes.StringNT QuerySqlPostEqualThis, 
NullTypes.StringNT CodeMethodEqualThis, NullTypes.StringNT UrlEqualThis, NullTypes.StringNT ValMinimoEqualThis, 
NullTypes.StringNT ValMassimoEqualThis, NullTypes.StringNT MisuraEqualThis)
		{
			StepCollection StepCollectionTemp = new StepCollection();
			foreach (Step StepItem in this)
			{
				if (((IdStepEqualThis == null) || ((StepItem.IdStep != null) && (StepItem.IdStep.Value == IdStepEqualThis.Value))) && ((CodFaseEqualThis == null) || ((StepItem.CodFase != null) && (StepItem.CodFase.Value == CodFaseEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((StepItem.Descrizione != null) && (StepItem.Descrizione.Value == DescrizioneEqualThis.Value))) && 
((AutomaticoEqualThis == null) || ((StepItem.Automatico != null) && (StepItem.Automatico.Value == AutomaticoEqualThis.Value))) && ((QuerySqlEqualThis == null) || ((StepItem.QuerySql != null) && (StepItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((QuerySqlPostEqualThis == null) || ((StepItem.QuerySqlPost != null) && (StepItem.QuerySqlPost.Value == QuerySqlPostEqualThis.Value))) && 
((CodeMethodEqualThis == null) || ((StepItem.CodeMethod != null) && (StepItem.CodeMethod.Value == CodeMethodEqualThis.Value))) && ((UrlEqualThis == null) || ((StepItem.Url != null) && (StepItem.Url.Value == UrlEqualThis.Value))) && ((ValMinimoEqualThis == null) || ((StepItem.ValMinimo != null) && (StepItem.ValMinimo.Value == ValMinimoEqualThis.Value))) && 
((ValMassimoEqualThis == null) || ((StepItem.ValMassimo != null) && (StepItem.ValMassimo.Value == ValMassimoEqualThis.Value))) && ((MisuraEqualThis == null) || ((StepItem.Misura != null) && (StepItem.Misura.Value == MisuraEqualThis.Value))))
				{
					StepCollectionTemp.Add(StepItem);
				}
			}
			return StepCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public StepCollection FiltroMisura(NullTypes.StringNT MisuraLike)
		{
			StepCollection StepCollectionTemp = new StepCollection();
			foreach (Step StepItem in this)
			{
				if (((MisuraLike == null) || ((StepItem.Misura !=null) &&(StepItem.Misura.Like(MisuraLike.Value)))))
				{
					StepCollectionTemp.Add(StepItem);
				}
			}
			return StepCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<STEP>
  <ViewName>vSTEP</ViewName>
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
      <ID_STEP>Equal</ID_STEP>
      <AUTOMATICO>Equal</AUTOMATICO>
      <COD_FASE>Equal</COD_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroMisura>
      <MISURA>Like</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</STEP>
*/