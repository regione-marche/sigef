using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ControlliParametriXLottoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ControlliParametriXLottoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ControlliParametriXLottoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ControlliParametriXLotto) info.GetValue(i.ToString(),typeof(ControlliParametriXLotto)));
			}
		}

		//Costruttore
		public ControlliParametriXLottoCollection()
		{
			this.ItemType = typeof(ControlliParametriXLotto);
		}

		//Costruttore con provider
		public ControlliParametriXLottoCollection(IControlliParametriXLottoProvider providerObj)
		{
			this.ItemType = typeof(ControlliParametriXLotto);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ControlliParametriXLotto this[int index]
		{
			get { return (ControlliParametriXLotto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ControlliParametriXLottoCollection GetChanges()
		{
			return (ControlliParametriXLottoCollection) base.GetChanges();
		}

		[NonSerialized] private IControlliParametriXLottoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IControlliParametriXLottoProvider Provider
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
		public int Add(ControlliParametriXLotto ControlliParametriXLottoObj)
		{
			if (ControlliParametriXLottoObj.Provider == null) ControlliParametriXLottoObj.Provider = this.Provider;
			return base.Add(ControlliParametriXLottoObj);
		}

		//AddCollection
		public void AddCollection(ControlliParametriXLottoCollection ControlliParametriXLottoCollectionObj)
		{
			foreach (ControlliParametriXLotto ControlliParametriXLottoObj in ControlliParametriXLottoCollectionObj)
				this.Add(ControlliParametriXLottoObj);
		}

		//Insert
		public void Insert(int index, ControlliParametriXLotto ControlliParametriXLottoObj)
		{
			if (ControlliParametriXLottoObj.Provider == null) ControlliParametriXLottoObj.Provider = this.Provider;
			base.Insert(index, ControlliParametriXLottoObj);
		}

		//CollectionGetById
		public ControlliParametriXLotto CollectionGetById(NullTypes.IntNT IdLottoValue, NullTypes.IntNT IdParametroValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdLotto == IdLottoValue) && (this[i].IdParametro == IdParametroValue))
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
		public ControlliParametriXLottoCollection SubSelect(NullTypes.IntNT IdLottoEqualThis, NullTypes.IntNT IdParametroEqualThis, NullTypes.IntNT PesoRealeEqualThis)
		{
			ControlliParametriXLottoCollection ControlliParametriXLottoCollectionTemp = new ControlliParametriXLottoCollection();
			foreach (ControlliParametriXLotto ControlliParametriXLottoItem in this)
			{
				if (((IdLottoEqualThis == null) || ((ControlliParametriXLottoItem.IdLotto != null) && (ControlliParametriXLottoItem.IdLotto.Value == IdLottoEqualThis.Value))) && ((IdParametroEqualThis == null) || ((ControlliParametriXLottoItem.IdParametro != null) && (ControlliParametriXLottoItem.IdParametro.Value == IdParametroEqualThis.Value))) && ((PesoRealeEqualThis == null) || ((ControlliParametriXLottoItem.PesoReale != null) && (ControlliParametriXLottoItem.PesoReale.Value == PesoRealeEqualThis.Value))))
				{
					ControlliParametriXLottoCollectionTemp.Add(ControlliParametriXLottoItem);
				}
			}
			return ControlliParametriXLottoCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<CONTROLLI_PARAMETRI_X_LOTTO>
  <ViewName>vCONTROLLI_PARAMETRI_X_LOTTO</ViewName>
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
      <ID_LOTTO>Equal</ID_LOTTO>
      <ID_PARAMETRO>Equal</ID_PARAMETRO>
      <MANUALE>Equal</MANUALE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</CONTROLLI_PARAMETRI_X_LOTTO>
*/