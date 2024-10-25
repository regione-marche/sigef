using System;

/* STORIA
 * Data: 2016-05-24; Stato: Creazione; Autore: 
*/

namespace SiarLibrary
{

	/// <summary>
    /// Summary description for CUPCategoriaSoggettoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class CUPCategoriaSoggettoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private CUPCategoriaSoggettoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
                this.Add((CUPCategoriaSoggetto)info.GetValue(i.ToString(), typeof(CUPCategoriaSoggetto)));
			}
		}

		//Costruttore
		public CUPCategoriaSoggettoCollection()
		{
			this.ItemType = typeof(CUPCategoriaSoggetto);
		}

		//Costruttore con provider
        public CUPCategoriaSoggettoCollection(ICUPCategoriaSoggettoProvider providerObj)
		{
            this.ItemType = typeof(CUPCategoriaSoggetto);
			this.Provider = providerObj;
		}

		//Get e Set
        public new CUPCategoriaSoggetto this[int index]
		{
            get { return (CUPCategoriaSoggetto)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

        public new CUPCategoriaSoggettoCollection GetChanges()
		{
            return (CUPCategoriaSoggettoCollection)base.GetChanges();
		}

        [NonSerialized]
        private ICUPCategoriaSoggettoProvider _provider;
        [System.Xml.Serialization.XmlIgnore]
        public ICUPCategoriaSoggettoProvider Provider
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
        public int Add(CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
            if (CUPCategoriaSoggettoObj.Provider == null) CUPCategoriaSoggettoObj.Provider = this.Provider;
            return base.Add(CUPCategoriaSoggettoObj);
		}

		//AddCollection
        public void AddCollection(CUPCategoriaSoggettoCollection ClassificazioneCUPCollectionObj)
		{
            foreach (CUPCategoriaSoggetto ClassificazioneCUPObj in ClassificazioneCUPCollectionObj)
                this.Add(ClassificazioneCUPObj);
		}

		//Insert
        public void Insert(int index, CUPCategoriaSoggetto CUPCategoriaSoggettoObj)
		{
            if (CUPCategoriaSoggettoObj.Provider == null) CUPCategoriaSoggettoObj.Provider = this.Provider;
            base.Insert(index, CUPCategoriaSoggettoObj);
		}

		//CollectionGetById
        public CUPCategoriaSoggetto CollectionGetById(NullTypes.StringNT IdCUPCategoriaSoggettoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
                if ((this[i].IdCategoria == IdCUPCategoriaSoggettoValue))
					find = true;
				else
					i++;
			}
			if (find)
				return this[i];
			else
				return null;
		}
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<TIPO_CUP_CATEGORIE_SOGGETTI>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <COD_CUP_CATEGORIE_SOGGETTI>Equal</COD_CUP_CATEGORIE_SOGGETTI>
      <Descrizione>Like</Descrizione>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</TIPO_CUP_CATEGORIE_SOGGETTI>
*/