using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for SettoriProduttiviCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class SettoriProduttiviCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private SettoriProduttiviCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((SettoriProduttivi) info.GetValue(i.ToString(),typeof(SettoriProduttivi)));
			}
		}

		//Costruttore
		public SettoriProduttiviCollection()
		{
			this.ItemType = typeof(SettoriProduttivi);
		}

		//Costruttore con provider
		public SettoriProduttiviCollection(ISettoriProduttiviProvider providerObj)
		{
			this.ItemType = typeof(SettoriProduttivi);
			this.Provider = providerObj;
		}

		//Get e Set
		public new SettoriProduttivi this[int index]
		{
			get { return (SettoriProduttivi)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new SettoriProduttiviCollection GetChanges()
		{
			return (SettoriProduttiviCollection) base.GetChanges();
		}

		[NonSerialized] private ISettoriProduttiviProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public ISettoriProduttiviProvider Provider
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
		public int Add(SettoriProduttivi SettoriProduttiviObj)
		{
			if (SettoriProduttiviObj.Provider == null) SettoriProduttiviObj.Provider = this.Provider;
			return base.Add(SettoriProduttiviObj);
		}

		//AddCollection
		public void AddCollection(SettoriProduttiviCollection SettoriProduttiviCollectionObj)
		{
			foreach (SettoriProduttivi SettoriProduttiviObj in SettoriProduttiviCollectionObj)
				this.Add(SettoriProduttiviObj);
		}

		//Insert
		public void Insert(int index, SettoriProduttivi SettoriProduttiviObj)
		{
			if (SettoriProduttiviObj.Provider == null) SettoriProduttiviObj.Provider = this.Provider;
			base.Insert(index, SettoriProduttiviObj);
		}

		//CollectionGetById
		public SettoriProduttivi CollectionGetById(NullTypes.IntNT IdSettoreProduttivoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdSettoreProduttivo == IdSettoreProduttivoValue))
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
		public SettoriProduttiviCollection SubSelect(NullTypes.IntNT IdSettoreProduttivoEqualThis, NullTypes.StringNT DescrizioneEqualThis)
		{
			SettoriProduttiviCollection SettoriProduttiviCollectionTemp = new SettoriProduttiviCollection();
			foreach (SettoriProduttivi SettoriProduttiviItem in this)
			{
				if (((IdSettoreProduttivoEqualThis == null) || ((SettoriProduttiviItem.IdSettoreProduttivo != null) && (SettoriProduttiviItem.IdSettoreProduttivo.Value == IdSettoreProduttivoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((SettoriProduttiviItem.Descrizione != null) && (SettoriProduttiviItem.Descrizione.Value == DescrizioneEqualThis.Value))))
				{
					SettoriProduttiviCollectionTemp.Add(SettoriProduttiviItem);
				}
			}
			return SettoriProduttiviCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<SETTORI_PRODUTTIVI>
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
      <ID_SETTORE_PRODUTTIVO>Equal</ID_SETTORE_PRODUTTIVO>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</SETTORI_PRODUTTIVI>
*/