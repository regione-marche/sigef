using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for ProfiloXFunzioniCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class ProfiloXFunzioniCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ProfiloXFunzioniCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ProfiloXFunzioni) info.GetValue(i.ToString(),typeof(ProfiloXFunzioni)));
			}
		}

		//Costruttore
		public ProfiloXFunzioniCollection()
		{
			this.ItemType = typeof(ProfiloXFunzioni);
		}

		//Costruttore con provider
		public ProfiloXFunzioniCollection(IProfiloXFunzioniProvider providerObj)
		{
			this.ItemType = typeof(ProfiloXFunzioni);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ProfiloXFunzioni this[int index]
		{
			get { return (ProfiloXFunzioni)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ProfiloXFunzioniCollection GetChanges()
		{
			return (ProfiloXFunzioniCollection) base.GetChanges();
		}

		[NonSerialized] private IProfiloXFunzioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProfiloXFunzioniProvider Provider
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
		public int Add(ProfiloXFunzioni ProfiloXFunzioniObj)
		{
			if (ProfiloXFunzioniObj.Provider == null) ProfiloXFunzioniObj.Provider = this.Provider;
			return base.Add(ProfiloXFunzioniObj);
		}

		//AddCollection
		public void AddCollection(ProfiloXFunzioniCollection ProfiloXFunzioniCollectionObj)
		{
			foreach (ProfiloXFunzioni ProfiloXFunzioniObj in ProfiloXFunzioniCollectionObj)
				this.Add(ProfiloXFunzioniObj);
		}

		//Insert
		public void Insert(int index, ProfiloXFunzioni ProfiloXFunzioniObj)
		{
			if (ProfiloXFunzioniObj.Provider == null) ProfiloXFunzioniObj.Provider = this.Provider;
			base.Insert(index, ProfiloXFunzioniObj);
		}

		//CollectionGetById
		public ProfiloXFunzioni CollectionGetById(NullTypes.IntNT IdProfiloValue, NullTypes.IntNT CodFunzioneValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdProfilo == IdProfiloValue) && (this[i].CodFunzione == CodFunzioneValue))
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
		public ProfiloXFunzioniCollection SubSelect(NullTypes.IntNT IdProfiloEqualThis, NullTypes.IntNT CodFunzioneEqualThis, NullTypes.BoolNT ModificaEqualThis)
		{
			ProfiloXFunzioniCollection ProfiloXFunzioniCollectionTemp = new ProfiloXFunzioniCollection();
			foreach (ProfiloXFunzioni ProfiloXFunzioniItem in this)
			{
				if (((IdProfiloEqualThis == null) || ((ProfiloXFunzioniItem.IdProfilo != null) && (ProfiloXFunzioniItem.IdProfilo.Value == IdProfiloEqualThis.Value))) && ((CodFunzioneEqualThis == null) || ((ProfiloXFunzioniItem.CodFunzione != null) && (ProfiloXFunzioniItem.CodFunzione.Value == CodFunzioneEqualThis.Value))) && ((ModificaEqualThis == null) || ((ProfiloXFunzioniItem.Modifica != null) && (ProfiloXFunzioniItem.Modifica.Value == ModificaEqualThis.Value))))
				{
					ProfiloXFunzioniCollectionTemp.Add(ProfiloXFunzioniItem);
				}
			}
			return ProfiloXFunzioniCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public ProfiloXFunzioniCollection FiltroModifica(NullTypes.BoolNT ModificaEqualThis)
		{
			ProfiloXFunzioniCollection ProfiloXFunzioniCollectionTemp = new ProfiloXFunzioniCollection();
			foreach (ProfiloXFunzioni ProfiloXFunzioniItem in this)
			{
				if (((ModificaEqualThis == null) || ((ProfiloXFunzioniItem.Modifica != null) && (ProfiloXFunzioniItem.Modifica.Value == ModificaEqualThis.Value))))
				{
					ProfiloXFunzioniCollectionTemp.Add(ProfiloXFunzioniItem);
				}
			}
			return ProfiloXFunzioniCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PROFILO_X_FUNZIONI>
  <ViewName>vPROFILO_X_FUNZIONI</ViewName>
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
      <ID_PROFILO>Equal</ID_PROFILO>
      <COD_FUNZIONE>Equal</COD_FUNZIONE>
      <FLAG_MENU>Equal</FLAG_MENU>
      <DESC_MENU>Equal</DESC_MENU>
      <LIVELLO>Equal</LIVELLO>
      <PADRE>Equal</PADRE>
      <ORDINE>Equal</ORDINE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroModifica>
      <MODIFICA>Equal</MODIFICA>
    </FiltroModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROFILO_X_FUNZIONI>
*/