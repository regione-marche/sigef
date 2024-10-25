using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for FatturatoAziendaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class FatturatoAziendaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private FatturatoAziendaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((FatturatoAzienda) info.GetValue(i.ToString(),typeof(FatturatoAzienda)));
			}
		}

		//Costruttore
		public FatturatoAziendaCollection()
		{
			this.ItemType = typeof(FatturatoAzienda);
		}

		//Costruttore con provider
		public FatturatoAziendaCollection(IFatturatoAziendaProvider providerObj)
		{
			this.ItemType = typeof(FatturatoAzienda);
			this.Provider = providerObj;
		}

		//Get e Set
		public new FatturatoAzienda this[int index]
		{
			get { return (FatturatoAzienda)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new FatturatoAziendaCollection GetChanges()
		{
			return (FatturatoAziendaCollection) base.GetChanges();
		}

		[NonSerialized] private IFatturatoAziendaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFatturatoAziendaProvider Provider
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
		public int Add(FatturatoAzienda FatturatoAziendaObj)
		{
			if (FatturatoAziendaObj.Provider == null) FatturatoAziendaObj.Provider = this.Provider;
			return base.Add(FatturatoAziendaObj);
		}

		//AddCollection
		public void AddCollection(FatturatoAziendaCollection FatturatoAziendaCollectionObj)
		{
			foreach (FatturatoAzienda FatturatoAziendaObj in FatturatoAziendaCollectionObj)
				this.Add(FatturatoAziendaObj);
		}

		//Insert
		public void Insert(int index, FatturatoAzienda FatturatoAziendaObj)
		{
			if (FatturatoAziendaObj.Provider == null) FatturatoAziendaObj.Provider = this.Provider;
			base.Insert(index, FatturatoAziendaObj);
		}

		//CollectionGetById
		public FatturatoAzienda CollectionGetById(NullTypes.IntNT IdFatturatoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdFatturato == IdFatturatoValue))
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
		public FatturatoAziendaCollection SubSelect(NullTypes.IntNT IdFatturatoEqualThis, NullTypes.IntNT IdImpresaEqualThis, NullTypes.DatetimeNT DataModificaEqualThis, 
NullTypes.IntNT AnnoEqualThis, NullTypes.DecimalNT AliquotaEqualThis, NullTypes.DecimalNT ImportoEqualThis)
		{
			FatturatoAziendaCollection FatturatoAziendaCollectionTemp = new FatturatoAziendaCollection();
			foreach (FatturatoAzienda FatturatoAziendaItem in this)
			{
				if (((IdFatturatoEqualThis == null) || ((FatturatoAziendaItem.IdFatturato != null) && (FatturatoAziendaItem.IdFatturato.Value == IdFatturatoEqualThis.Value))) && ((IdImpresaEqualThis == null) || ((FatturatoAziendaItem.IdImpresa != null) && (FatturatoAziendaItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((DataModificaEqualThis == null) || ((FatturatoAziendaItem.DataModifica != null) && (FatturatoAziendaItem.DataModifica.Value == DataModificaEqualThis.Value))) && 
((AnnoEqualThis == null) || ((FatturatoAziendaItem.Anno != null) && (FatturatoAziendaItem.Anno.Value == AnnoEqualThis.Value))) && ((AliquotaEqualThis == null) || ((FatturatoAziendaItem.Aliquota != null) && (FatturatoAziendaItem.Aliquota.Value == AliquotaEqualThis.Value))) && ((ImportoEqualThis == null) || ((FatturatoAziendaItem.Importo != null) && (FatturatoAziendaItem.Importo.Value == ImportoEqualThis.Value))))
				{
					FatturatoAziendaCollectionTemp.Add(FatturatoAziendaItem);
				}
			}
			return FatturatoAziendaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public FatturatoAziendaCollection FiltroDataModifica(NullTypes.DatetimeNT DataModificaEqLessThanThis)
		{
			FatturatoAziendaCollection FatturatoAziendaCollectionTemp = new FatturatoAziendaCollection();
			foreach (FatturatoAzienda FatturatoAziendaItem in this)
			{
				if (((DataModificaEqLessThanThis == null) || ((FatturatoAziendaItem.DataModifica != null) && (FatturatoAziendaItem.DataModifica.Value <= DataModificaEqLessThanThis.Value))))
				{
					FatturatoAziendaCollectionTemp.Add(FatturatoAziendaItem);
				}
			}
			return FatturatoAziendaCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public FatturatoAziendaCollection FiltroAliquota(NullTypes.DecimalNT AliquotaEqualThis)
		{
			FatturatoAziendaCollection FatturatoAziendaCollectionTemp = new FatturatoAziendaCollection();
			foreach (FatturatoAzienda FatturatoAziendaItem in this)
			{
				if (((AliquotaEqualThis == null) || ((FatturatoAziendaItem.Aliquota != null) && (FatturatoAziendaItem.Aliquota.Value == AliquotaEqualThis.Value))))
				{
					FatturatoAziendaCollectionTemp.Add(FatturatoAziendaItem);
				}
			}
			return FatturatoAziendaCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<FATTURATO_AZIENDA>
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
      <ID_FATTURATO>Equal</ID_FATTURATO>
      <ID_IMPRESA>Equal</ID_IMPRESA>
      <ANNO>Equal</ANNO>
      <ALIQUOTA>Equal</ALIQUOTA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDataModifica>
      <DATA_MODIFICA>EqLessThan</DATA_MODIFICA>
    </FiltroDataModifica>
    <FiltroAliquota>
      <ALIQUOTA>Equal</ALIQUOTA>
    </FiltroAliquota>
  </Filters>
  <externalFields />
  <AddedFkFields />
</FATTURATO_AZIENDA>
*/