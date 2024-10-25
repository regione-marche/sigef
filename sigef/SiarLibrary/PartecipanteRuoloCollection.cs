using System;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for PartecipanteRuoloCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class PartecipanteRuoloCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private PartecipanteRuoloCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((PartecipanteRuolo) info.GetValue(i.ToString(),typeof(PartecipanteRuolo)));
			}
		}

		//Costruttore
		public PartecipanteRuoloCollection()
		{
			this.ItemType = typeof(PartecipanteRuolo);
		}

		//Costruttore con provider
		public PartecipanteRuoloCollection(IPartecipanteRuoloProvider providerObj)
		{
			this.ItemType = typeof(PartecipanteRuolo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new PartecipanteRuolo this[int index]
		{
			get { return (PartecipanteRuolo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new PartecipanteRuoloCollection GetChanges()
		{
			return (PartecipanteRuoloCollection) base.GetChanges();
		}

		[NonSerialized] private IPartecipanteRuoloProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IPartecipanteRuoloProvider Provider
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
		public int Add(PartecipanteRuolo PartecipanteRuoloObj)
		{
			if (PartecipanteRuoloObj.Provider == null) PartecipanteRuoloObj.Provider = this.Provider;
			return base.Add(PartecipanteRuoloObj);
		}

		//AddCollection
		public void AddCollection(PartecipanteRuoloCollection PartecipanteRuoloCollectionObj)
		{
			foreach (PartecipanteRuolo PartecipanteRuoloObj in PartecipanteRuoloCollectionObj)
				this.Add(PartecipanteRuoloObj);
		}

		//Insert
		public void Insert(int index, PartecipanteRuolo PartecipanteRuoloObj)
		{
			if (PartecipanteRuoloObj.Provider == null) PartecipanteRuoloObj.Provider = this.Provider;
			base.Insert(index, PartecipanteRuoloObj);
		}

		//CollectionGetById
		public PartecipanteRuolo CollectionGetById(NullTypes.IntNT IdPartcipanteRuoloValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdPartcipanteRuolo == IdPartcipanteRuoloValue))
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
		public PartecipanteRuoloCollection SubSelect(NullTypes.IntNT IdPartcipanteRuoloEqualThis, NullTypes.IntNT IdProgettoPifEqualThis, NullTypes.StringNT CodFilieraEqualThis, 
NullTypes.StringNT CuaaEqualThis, NullTypes.BoolNT FlagPartecipanteEqualThis, NullTypes.StringNT CodRuoloSitraEqualThis, 
NullTypes.StringNT CodRuoloPartecipanteEqualThis, NullTypes.StringNT CodSistemaQualitaEqualThis, NullTypes.StringNT OperatoreInserimentoEqualThis, 
NullTypes.DatetimeNT DataModificaEqualThis)
		{
			PartecipanteRuoloCollection PartecipanteRuoloCollectionTemp = new PartecipanteRuoloCollection();
			foreach (PartecipanteRuolo PartecipanteRuoloItem in this)
			{
				if (((IdPartcipanteRuoloEqualThis == null) || ((PartecipanteRuoloItem.IdPartcipanteRuolo != null) && (PartecipanteRuoloItem.IdPartcipanteRuolo.Value == IdPartcipanteRuoloEqualThis.Value))) && ((IdProgettoPifEqualThis == null) || ((PartecipanteRuoloItem.IdProgettoPif != null) && (PartecipanteRuoloItem.IdProgettoPif.Value == IdProgettoPifEqualThis.Value))) && ((CodFilieraEqualThis == null) || ((PartecipanteRuoloItem.CodFiliera != null) && (PartecipanteRuoloItem.CodFiliera.Value == CodFilieraEqualThis.Value))) && 
((CuaaEqualThis == null) || ((PartecipanteRuoloItem.Cuaa != null) && (PartecipanteRuoloItem.Cuaa.Value == CuaaEqualThis.Value))) && ((FlagPartecipanteEqualThis == null) || ((PartecipanteRuoloItem.FlagPartecipante != null) && (PartecipanteRuoloItem.FlagPartecipante.Value == FlagPartecipanteEqualThis.Value))) && ((CodRuoloSitraEqualThis == null) || ((PartecipanteRuoloItem.CodRuoloSitra != null) && (PartecipanteRuoloItem.CodRuoloSitra.Value == CodRuoloSitraEqualThis.Value))) && 
((CodRuoloPartecipanteEqualThis == null) || ((PartecipanteRuoloItem.CodRuoloPartecipante != null) && (PartecipanteRuoloItem.CodRuoloPartecipante.Value == CodRuoloPartecipanteEqualThis.Value))) && ((CodSistemaQualitaEqualThis == null) || ((PartecipanteRuoloItem.CodSistemaQualita != null) && (PartecipanteRuoloItem.CodSistemaQualita.Value == CodSistemaQualitaEqualThis.Value))) && ((OperatoreInserimentoEqualThis == null) || ((PartecipanteRuoloItem.OperatoreInserimento != null) && (PartecipanteRuoloItem.OperatoreInserimento.Value == OperatoreInserimentoEqualThis.Value))) && 
((DataModificaEqualThis == null) || ((PartecipanteRuoloItem.DataModifica != null) && (PartecipanteRuoloItem.DataModifica.Value == DataModificaEqualThis.Value))))
				{
					PartecipanteRuoloCollectionTemp.Add(PartecipanteRuoloItem);
				}
			}
			return PartecipanteRuoloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PartecipanteRuoloCollection FiltroSitra(NullTypes.StringNT CodRuoloSitraEqualThis)
		{
			PartecipanteRuoloCollection PartecipanteRuoloCollectionTemp = new PartecipanteRuoloCollection();
			foreach (PartecipanteRuolo PartecipanteRuoloItem in this)
			{
				if (((CodRuoloSitraEqualThis == null) || ((PartecipanteRuoloItem.CodRuoloSitra != null) && (PartecipanteRuoloItem.CodRuoloSitra.Value == CodRuoloSitraEqualThis.Value))))
				{
					PartecipanteRuoloCollectionTemp.Add(PartecipanteRuoloItem);
				}
			}
			return PartecipanteRuoloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PartecipanteRuoloCollection FiltroRuoloOperativo(NullTypes.StringNT CodRuoloPartecipanteEqualThis)
		{
			PartecipanteRuoloCollection PartecipanteRuoloCollectionTemp = new PartecipanteRuoloCollection();
			foreach (PartecipanteRuolo PartecipanteRuoloItem in this)
			{
				if (((CodRuoloPartecipanteEqualThis == null) || ((PartecipanteRuoloItem.CodRuoloPartecipante != null) && (PartecipanteRuoloItem.CodRuoloPartecipante.Value == CodRuoloPartecipanteEqualThis.Value))))
				{
					PartecipanteRuoloCollectionTemp.Add(PartecipanteRuoloItem);
				}
			}
			return PartecipanteRuoloCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public PartecipanteRuoloCollection FiltroQualita(NullTypes.StringNT CodSistemaQualitaEqualThis)
		{
			PartecipanteRuoloCollection PartecipanteRuoloCollectionTemp = new PartecipanteRuoloCollection();
			foreach (PartecipanteRuolo PartecipanteRuoloItem in this)
			{
				if (((CodSistemaQualitaEqualThis == null) || ((PartecipanteRuoloItem.CodSistemaQualita != null) && (PartecipanteRuoloItem.CodSistemaQualita.Value == CodSistemaQualitaEqualThis.Value))))
				{
					PartecipanteRuoloCollectionTemp.Add(PartecipanteRuoloItem);
				}
			}
			return PartecipanteRuoloCollectionTemp;
		}



	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<PARTECIPANTE_RUOLO>
  <ViewName>vPARTECIPANTE_RUOLO</ViewName>
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
      <CUAA>Equal</CUAA>
      <ID_PROGETTO_PIF>Equal</ID_PROGETTO_PIF>
    </Find>
  </Finds>
  <Filters>
    <FiltroSitra>
      <COD_RUOLO_SITRA>Equal</COD_RUOLO_SITRA>
    </FiltroSitra>
    <FiltroRuoloOperativo>
      <COD_RUOLO_PARTECIPANTE>Equal</COD_RUOLO_PARTECIPANTE>
    </FiltroRuoloOperativo>
    <FiltroQualita>
      <COD_SISTEMA_QUALITA>Equal</COD_SISTEMA_QUALITA>
    </FiltroQualita>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PARTECIPANTE_RUOLO>
*/