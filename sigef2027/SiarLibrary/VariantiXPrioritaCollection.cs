using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VariantiXPrioritaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class VariantiXPrioritaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VariantiXPrioritaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VariantiXPriorita) info.GetValue(i.ToString(),typeof(VariantiXPriorita)));
			}
		}

		//Costruttore
		public VariantiXPrioritaCollection()
		{
			this.ItemType = typeof(VariantiXPriorita);
		}

		//Costruttore con provider
		public VariantiXPrioritaCollection(IVariantiXPrioritaProvider providerObj)
		{
			this.ItemType = typeof(VariantiXPriorita);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VariantiXPriorita this[int index]
		{
			get { return (VariantiXPriorita)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VariantiXPrioritaCollection GetChanges()
		{
			return (VariantiXPrioritaCollection) base.GetChanges();
		}

		[NonSerialized] private IVariantiXPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiXPrioritaProvider Provider
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
		public int Add(VariantiXPriorita VariantiXPrioritaObj)
		{
			if (VariantiXPrioritaObj.Provider == null) VariantiXPrioritaObj.Provider = this.Provider;
			return base.Add(VariantiXPrioritaObj);
		}

		//AddCollection
		public void AddCollection(VariantiXPrioritaCollection VariantiXPrioritaCollectionObj)
		{
			foreach (VariantiXPriorita VariantiXPrioritaObj in VariantiXPrioritaCollectionObj)
				this.Add(VariantiXPrioritaObj);
		}

		//Insert
		public void Insert(int index, VariantiXPriorita VariantiXPrioritaObj)
		{
			if (VariantiXPrioritaObj.Provider == null) VariantiXPrioritaObj.Provider = this.Provider;
			base.Insert(index, VariantiXPrioritaObj);
		}

		//CollectionGetById
		public VariantiXPriorita CollectionGetById(NullTypes.IntNT IdVarianteValue, NullTypes.IntNT IdPrioritaValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdVariante == IdVarianteValue) && (this[i].IdPriorita == IdPrioritaValue))
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
		public VariantiXPrioritaCollection SubSelect(NullTypes.IntNT IdVarianteEqualThis, NullTypes.IntNT IdPrioritaEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.DecimalNT PunteggioEqualThis, NullTypes.DatetimeNT DataValutazioneEqualThis, NullTypes.StringNT OperatoreEqualThis, 
NullTypes.BoolNT FlagDefinitivoEqualThis)
		{
			VariantiXPrioritaCollection VariantiXPrioritaCollectionTemp = new VariantiXPrioritaCollection();
			foreach (VariantiXPriorita VariantiXPrioritaItem in this)
			{
				if (((IdVarianteEqualThis == null) || ((VariantiXPrioritaItem.IdVariante != null) && (VariantiXPrioritaItem.IdVariante.Value == IdVarianteEqualThis.Value))) && ((IdPrioritaEqualThis == null) || ((VariantiXPrioritaItem.IdPriorita != null) && (VariantiXPrioritaItem.IdPriorita.Value == IdPrioritaEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VariantiXPrioritaItem.IdProgetto != null) && (VariantiXPrioritaItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((PunteggioEqualThis == null) || ((VariantiXPrioritaItem.Punteggio != null) && (VariantiXPrioritaItem.Punteggio.Value == PunteggioEqualThis.Value))) && ((DataValutazioneEqualThis == null) || ((VariantiXPrioritaItem.DataValutazione != null) && (VariantiXPrioritaItem.DataValutazione.Value == DataValutazioneEqualThis.Value))) && ((OperatoreEqualThis == null) || ((VariantiXPrioritaItem.Operatore != null) && (VariantiXPrioritaItem.Operatore.Value == OperatoreEqualThis.Value))) && 
((FlagDefinitivoEqualThis == null) || ((VariantiXPrioritaItem.FlagDefinitivo != null) && (VariantiXPrioritaItem.FlagDefinitivo.Value == FlagDefinitivoEqualThis.Value))))
				{
					VariantiXPrioritaCollectionTemp.Add(VariantiXPrioritaItem);
				}
			}
			return VariantiXPrioritaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VariantiXPrioritaCollection FiltroDefinitivo(NullTypes.BoolNT FlagDefinitivoEqualThis)
		{
			VariantiXPrioritaCollection VariantiXPrioritaCollectionTemp = new VariantiXPrioritaCollection();
			foreach (VariantiXPriorita VariantiXPrioritaItem in this)
			{
				if (((FlagDefinitivoEqualThis == null) || ((VariantiXPrioritaItem.FlagDefinitivo != null) && (VariantiXPrioritaItem.FlagDefinitivo.Value == FlagDefinitivoEqualThis.Value))))
				{
					VariantiXPrioritaCollectionTemp.Add(VariantiXPrioritaItem);
				}
			}
			return VariantiXPrioritaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_X_PRIORITA>
  <ViewName>vVARIANTI_X_PRIORITA</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
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
    <Find OrderBy="ORDER BY ">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDefinitivo>
      <FLAG_DEFINITIVO>Equal</FLAG_DEFINITIVO>
    </FiltroDefinitivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_X_PRIORITA>
*/