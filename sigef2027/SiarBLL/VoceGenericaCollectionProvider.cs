using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per VoceGenerica
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVoceGenericaProvider
	{
		int Save(VoceGenerica VoceGenericaObj);
		int SaveCollection(VoceGenericaCollection collectionObj);
		int Delete(VoceGenerica VoceGenericaObj);
		int DeleteCollection(VoceGenericaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VoceGenerica
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VoceGenerica : BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVoceGenerica;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Automatico;
		private NullTypes.StringNT _QuerySql;
		private NullTypes.StringNT _QuerySqlPost;
		private NullTypes.StringNT _CodeMethod;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _ValMinimo;
		private NullTypes.StringNT _ValMassimo;
		private NullTypes.DatetimeNT _DataInserimento;
		private NullTypes.StringNT _CfInserimento;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.StringNT _CfModifica;
		private NullTypes.BoolNT _ValEsitoNegativo;
		private NullTypes.StringNT _IdFiltro;
		private NullTypes.BoolNT _Titolo;
		private NullTypes.StringNT _Commento;
		private NullTypes.StringNT _DescrizioneFiltro;
		private NullTypes.IntNT _OrdineFiltro;
		[NonSerialized] private IVoceGenericaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IVoceGenericaProvider Provider
		{
			get { return _provider; }
			set { _provider = value; }
		}


		//Costruttore
		public VoceGenerica()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VOCE_GENERICA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVoceGenerica
		{
			get { return _IdVoceGenerica; }
			set
			{
				if (IdVoceGenerica != value)
				{
					_IdVoceGenerica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(8000)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set
			{
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:AUTOMATICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Automatico
		{
			get { return _Automatico; }
			set
			{
				if (Automatico != value)
				{
					_Automatico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL
		/// Tipo sul db:VARCHAR(8000)
		/// </summary>
		public NullTypes.StringNT QuerySql
		{
			get { return _QuerySql; }
			set
			{
				if (QuerySql != value)
				{
					_QuerySql = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_SQL_POST
		/// Tipo sul db:VARCHAR(300)
		/// </summary>
		public NullTypes.StringNT QuerySqlPost
		{
			get { return _QuerySqlPost; }
			set
			{
				if (QuerySqlPost != value)
				{
					_QuerySqlPost = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CODE_METHOD
		/// Tipo sul db:VARCHAR(30)
		/// </summary>
		public NullTypes.StringNT CodeMethod
		{
			get { return _CodeMethod; }
			set
			{
				if (CodeMethod != value)
				{
					_CodeMethod = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:URL
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Url
		{
			get { return _Url; }
			set
			{
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MINIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMinimo
		{
			get { return _ValMinimo; }
			set
			{
				if (ValMinimo != value)
				{
					_ValMinimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_MASSIMO
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT ValMassimo
		{
			get { return _ValMassimo; }
			set
			{
				if (ValMassimo != value)
				{
					_ValMassimo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_INSERIMENTO
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataInserimento
		{
			get { return _DataInserimento; }
			set
			{
				if (DataInserimento != value)
				{
					_DataInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_INSERIMENTO
		/// Tipo sul db:CHAR(16)
		/// </summary>
		public NullTypes.StringNT CfInserimento
		{
			get { return _CfInserimento; }
			set
			{
				if (CfInserimento != value)
				{
					_CfInserimento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// Default:(getdate())
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set
			{
				if (DataModifica != value)
				{
					_DataModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_MODIFICA
		/// Tipo sul db:CHAR(16)
		/// </summary>
		public NullTypes.StringNT CfModifica
		{
			get { return _CfModifica; }
			set
			{
				if (CfModifica != value)
				{
					_CfModifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VAL_ESITO_NEGATIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT ValEsitoNegativo
		{
			get { return _ValEsitoNegativo; }
			set
			{
				if (ValEsitoNegativo != value)
				{
					_ValEsitoNegativo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_FILTRO
		/// Tipo sul db:VARCHAR(200)
		/// </summary>
		public NullTypes.StringNT IdFiltro
		{
			get { return _IdFiltro; }
			set
			{
				if (IdFiltro != value)
				{
					_IdFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TITOLO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Titolo
		{
			get { return _Titolo; }
			set
			{
				if (Titolo != value)
				{
					_Titolo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COMMENTO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT Commento
		{
			get { return _Commento; }
			set
			{
				if (Commento != value)
				{
					_Commento = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_FILTRO
		/// Tipo sul db:VARCHAR(-1)
		/// </summary>
		public NullTypes.StringNT DescrizioneFiltro
		{
			get { return _DescrizioneFiltro; }
			set
			{
				if (DescrizioneFiltro != value)
				{
					_DescrizioneFiltro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FILTRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFiltro
		{
			get { return _OrdineFiltro; }
			set
			{
				if (OrdineFiltro != value)
				{
					_OrdineFiltro = value;
					SetDirtyFlag();
				}
			}
		}


		//Get e Set dei campi 'ForeignKey'

		public int Save()
		{
			if (this.IsDirty)
			{
				return _provider.Save(this);
			}
			else
			{
				return 0;
			}
		}

		public int Delete()
		{
			return _provider.Delete(this);
		}

		//Get e Set dei campi 'aggiuntivi'

	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VoceGenericaCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VoceGenericaCollection : CustomCollection, System.Runtime.Serialization.ISerializable
	{

		//Serializzazione xml
		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			info.AddValue("_count", this.Count);
			for (int i = 0; i < this.Count; i++)
			{
				info.AddValue(i.ToString(), this[i]);
			}
		}
		private VoceGenericaCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : this()
		{
			int c = info.GetInt32("_count");
			for (int i = 0; i < c; i++)
			{
				this.Add((VoceGenerica)info.GetValue(i.ToString(), typeof(VoceGenerica)));
			}
		}

		//Costruttore
		public VoceGenericaCollection()
		{
			this.ItemType = typeof(VoceGenerica);
		}

		//Costruttore con provider
		public VoceGenericaCollection(IVoceGenericaProvider providerObj)
		{
			this.ItemType = typeof(VoceGenerica);
			this.Provider = providerObj;
		}

		//Get e Set
		public new VoceGenerica this[int index]
		{
			get { return (VoceGenerica)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VoceGenericaCollection GetChanges()
		{
			return (VoceGenericaCollection)base.GetChanges();
		}

		[NonSerialized] private IVoceGenericaProvider _provider;
		[System.Xml.Serialization.XmlIgnore]
		public IVoceGenericaProvider Provider
		{
			get { return _provider; }
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
		public int Add(VoceGenerica VoceGenericaObj)
		{
			if (VoceGenericaObj.Provider == null) VoceGenericaObj.Provider = this.Provider;
			return base.Add(VoceGenericaObj);
		}

		//AddCollection
		public void AddCollection(VoceGenericaCollection VoceGenericaCollectionObj)
		{
			foreach (VoceGenerica VoceGenericaObj in VoceGenericaCollectionObj)
				this.Add(VoceGenericaObj);
		}

		//Insert
		public void Insert(int index, VoceGenerica VoceGenericaObj)
		{
			if (VoceGenericaObj.Provider == null) VoceGenericaObj.Provider = this.Provider;
			base.Insert(index, VoceGenericaObj);
		}

		//CollectionGetById
		public VoceGenerica CollectionGetById(NullTypes.IntNT IdVoceGenericaValue)
		{
			int i = 0;
			bool find = false;
			while ((i < this.Count) && (!find))
			{
				if ((this[i].IdVoceGenerica == IdVoceGenericaValue))
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
		public VoceGenericaCollection SubSelect(NullTypes.IntNT IdVoceGenericaEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT AutomaticoEqualThis,
NullTypes.StringNT QuerySqlEqualThis, NullTypes.StringNT QuerySqlPostEqualThis, NullTypes.StringNT CodeMethodEqualThis,
NullTypes.StringNT UrlEqualThis, NullTypes.StringNT ValMinimoEqualThis, NullTypes.StringNT ValMassimoEqualThis,
NullTypes.DatetimeNT DataInserimentoEqualThis, NullTypes.StringNT CfInserimentoEqualThis, NullTypes.DatetimeNT DataModificaEqualThis,
NullTypes.StringNT CfModificaEqualThis, NullTypes.BoolNT ValEsitoNegativoEqualThis, NullTypes.StringNT IdFiltroEqualThis,
NullTypes.BoolNT TitoloEqualThis, NullTypes.StringNT CommentoEqualThis)
		{
			VoceGenericaCollection VoceGenericaCollectionTemp = new VoceGenericaCollection();
			foreach (VoceGenerica VoceGenericaItem in this)
			{
				if (((IdVoceGenericaEqualThis == null) || ((VoceGenericaItem.IdVoceGenerica != null) && (VoceGenericaItem.IdVoceGenerica.Value == IdVoceGenericaEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VoceGenericaItem.Descrizione != null) && (VoceGenericaItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AutomaticoEqualThis == null) || ((VoceGenericaItem.Automatico != null) && (VoceGenericaItem.Automatico.Value == AutomaticoEqualThis.Value))) &&
((QuerySqlEqualThis == null) || ((VoceGenericaItem.QuerySql != null) && (VoceGenericaItem.QuerySql.Value == QuerySqlEqualThis.Value))) && ((QuerySqlPostEqualThis == null) || ((VoceGenericaItem.QuerySqlPost != null) && (VoceGenericaItem.QuerySqlPost.Value == QuerySqlPostEqualThis.Value))) && ((CodeMethodEqualThis == null) || ((VoceGenericaItem.CodeMethod != null) && (VoceGenericaItem.CodeMethod.Value == CodeMethodEqualThis.Value))) &&
((UrlEqualThis == null) || ((VoceGenericaItem.Url != null) && (VoceGenericaItem.Url.Value == UrlEqualThis.Value))) && ((ValMinimoEqualThis == null) || ((VoceGenericaItem.ValMinimo != null) && (VoceGenericaItem.ValMinimo.Value == ValMinimoEqualThis.Value))) && ((ValMassimoEqualThis == null) || ((VoceGenericaItem.ValMassimo != null) && (VoceGenericaItem.ValMassimo.Value == ValMassimoEqualThis.Value))) &&
((DataInserimentoEqualThis == null) || ((VoceGenericaItem.DataInserimento != null) && (VoceGenericaItem.DataInserimento.Value == DataInserimentoEqualThis.Value))) && ((CfInserimentoEqualThis == null) || ((VoceGenericaItem.CfInserimento != null) && (VoceGenericaItem.CfInserimento.Value == CfInserimentoEqualThis.Value))) && ((DataModificaEqualThis == null) || ((VoceGenericaItem.DataModifica != null) && (VoceGenericaItem.DataModifica.Value == DataModificaEqualThis.Value))) &&
((CfModificaEqualThis == null) || ((VoceGenericaItem.CfModifica != null) && (VoceGenericaItem.CfModifica.Value == CfModificaEqualThis.Value))) && ((ValEsitoNegativoEqualThis == null) || ((VoceGenericaItem.ValEsitoNegativo != null) && (VoceGenericaItem.ValEsitoNegativo.Value == ValEsitoNegativoEqualThis.Value))) && ((IdFiltroEqualThis == null) || ((VoceGenericaItem.IdFiltro != null) && (VoceGenericaItem.IdFiltro.Value == IdFiltroEqualThis.Value))) &&
((TitoloEqualThis == null) || ((VoceGenericaItem.Titolo != null) && (VoceGenericaItem.Titolo.Value == TitoloEqualThis.Value))) && ((CommentoEqualThis == null) || ((VoceGenericaItem.Commento != null) && (VoceGenericaItem.Commento.Value == CommentoEqualThis.Value))))
				{
					VoceGenericaCollectionTemp.Add(VoceGenericaItem);
				}
			}
			return VoceGenericaCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VoceGenericaDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VoceGenericaDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, VoceGenerica VoceGenericaObj, string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd, firstChar + "IdVoceGenerica", VoceGenericaObj.IdVoceGenerica);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd, firstChar + "Descrizione", VoceGenericaObj.Descrizione);
			DbProvider.SetCmdParam(cmd, firstChar + "Automatico", VoceGenericaObj.Automatico);
			DbProvider.SetCmdParam(cmd, firstChar + "QuerySql", VoceGenericaObj.QuerySql);
			DbProvider.SetCmdParam(cmd, firstChar + "QuerySqlPost", VoceGenericaObj.QuerySqlPost);
			DbProvider.SetCmdParam(cmd, firstChar + "CodeMethod", VoceGenericaObj.CodeMethod);
			DbProvider.SetCmdParam(cmd, firstChar + "Url", VoceGenericaObj.Url);
			DbProvider.SetCmdParam(cmd, firstChar + "ValMinimo", VoceGenericaObj.ValMinimo);
			DbProvider.SetCmdParam(cmd, firstChar + "ValMassimo", VoceGenericaObj.ValMassimo);
			DbProvider.SetCmdParam(cmd, firstChar + "DataInserimento", VoceGenericaObj.DataInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "CfInserimento", VoceGenericaObj.CfInserimento);
			DbProvider.SetCmdParam(cmd, firstChar + "DataModifica", VoceGenericaObj.DataModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "CfModifica", VoceGenericaObj.CfModifica);
			DbProvider.SetCmdParam(cmd, firstChar + "ValEsitoNegativo", VoceGenericaObj.ValEsitoNegativo);
			DbProvider.SetCmdParam(cmd, firstChar + "IdFiltro", VoceGenericaObj.IdFiltro);
			DbProvider.SetCmdParam(cmd, firstChar + "Titolo", VoceGenericaObj.Titolo);
			DbProvider.SetCmdParam(cmd, firstChar + "Commento", VoceGenericaObj.Commento);
		}
		//Insert
		private static int Insert(DbProvider db, VoceGenerica VoceGenericaObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd("ZVoceGenericaInsert", new string[] {"Descrizione", "Automatico",
"QuerySql", "QuerySqlPost", "CodeMethod",
"Url", "ValMinimo", "ValMassimo",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "ValEsitoNegativo", "IdFiltro",
"Titolo", "Commento", }, new string[] {"string", "bool",
"string", "string", "string",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "bool", "string",
"bool", "string", }, "");
				CompileIUCmd(false, insertCmd, VoceGenericaObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
				{
					VoceGenericaObj.IdVoceGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_GENERICA"]);
					VoceGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
					VoceGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
					VoceGenericaObj.ValEsitoNegativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VAL_ESITO_NEGATIVO"]);
					VoceGenericaObj.Titolo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TITOLO"]);
				}
				VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceGenericaObj.IsDirty = false;
				VoceGenericaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, VoceGenerica VoceGenericaObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZVoceGenericaUpdate", new string[] {"IdVoceGenerica", "Descrizione", "Automatico",
"QuerySql", "QuerySqlPost", "CodeMethod",
"Url", "ValMinimo", "ValMassimo",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "ValEsitoNegativo", "IdFiltro",
"Titolo", "Commento", }, new string[] {"int", "string", "bool",
"string", "string", "string",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "bool", "string",
"bool", "string", }, "");
				CompileIUCmd(true, updateCmd, VoceGenericaObj, db.CommandFirstChar);
				SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
				if (d != null)
				{
					i = 1;
					VoceGenericaObj.DataModifica = d;
				}
				VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceGenericaObj.IsDirty = false;
				VoceGenericaObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, VoceGenerica VoceGenericaObj)
		{
			switch (VoceGenericaObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added: return Insert(db, VoceGenericaObj);
				case BaseObject.ObjectStateType.Changed: return Update(db, VoceGenericaObj);
				case BaseObject.ObjectStateType.Deleted: return Delete(db, VoceGenericaObj);
				default: return 0;
			}
		}

		public static int SaveCollection(DbProvider db, VoceGenericaCollection VoceGenericaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd("ZVoceGenericaUpdate", new string[] {"IdVoceGenerica", "Descrizione", "Automatico",
"QuerySql", "QuerySqlPost", "CodeMethod",
"Url", "ValMinimo", "ValMassimo",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "ValEsitoNegativo", "IdFiltro",
"Titolo", "Commento", }, new string[] {"int", "string", "bool",
"string", "string", "string",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "bool", "string",
"bool", "string", }, "");
				IDbCommand insertCmd = db.InitCmd("ZVoceGenericaInsert", new string[] {"Descrizione", "Automatico",
"QuerySql", "QuerySqlPost", "CodeMethod",
"Url", "ValMinimo", "ValMassimo",
"DataInserimento", "CfInserimento", "DataModifica",
"CfModifica", "ValEsitoNegativo", "IdFiltro",
"Titolo", "Commento", }, new string[] {"string", "bool",
"string", "string", "string",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "bool", "string",
"bool", "string", }, "");
				IDbCommand deleteCmd = db.InitCmd("ZVoceGenericaDelete", new string[] { "IdVoceGenerica" }, new string[] { "int" }, "");
				for (int i = 0; i < VoceGenericaCollectionObj.Count; i++)
				{
					switch (VoceGenericaCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added:
							{
								CompileIUCmd(false, insertCmd, VoceGenericaCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									VoceGenericaCollectionObj[i].IdVoceGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_GENERICA"]);
									VoceGenericaCollectionObj[i].DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
									VoceGenericaCollectionObj[i].DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
									VoceGenericaCollectionObj[i].ValEsitoNegativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VAL_ESITO_NEGATIVO"]);
									VoceGenericaCollectionObj[i].Titolo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TITOLO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed:
							{
								CompileIUCmd(true, updateCmd, VoceGenericaCollectionObj[i], db.CommandFirstChar);
								SiarLibrary.NullTypes.DatetimeNT d = new SiarLibrary.NullTypes.DatetimeNT(db.ExecuteScalar(updateCmd));
								if (d != null)
								{
									returnValue++;
									VoceGenericaCollectionObj[i].DataModifica = d;
								}
							}
							break;
						case BaseObject.ObjectStateType.Deleted:
							{
								if (VoceGenericaCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVoceGenerica", (SiarLibrary.NullTypes.IntNT)VoceGenericaCollectionObj[i].IdVoceGenerica);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < VoceGenericaCollectionObj.Count; i++)
				{
					if ((VoceGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VoceGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VoceGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						VoceGenericaCollectionObj[i].IsDirty = false;
						VoceGenericaCollectionObj[i].IsPersistent = true;
					}
					if ((VoceGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						VoceGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VoceGenericaCollectionObj[i].IsDirty = false;
						VoceGenericaCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//Delete
		public static int Delete(DbProvider db, VoceGenerica VoceGenericaObj)
		{
			int returnValue = 0;
			if (VoceGenericaObj.IsPersistent)
			{
				returnValue = Delete(db, VoceGenericaObj.IdVoceGenerica);
			}
			VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			VoceGenericaObj.IsDirty = false;
			VoceGenericaObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdVoceGenericaValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZVoceGenericaDelete", new string[] { "IdVoceGenerica" }, new string[] { "int" }, "");
				DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVoceGenerica", (SiarLibrary.NullTypes.IntNT)IdVoceGenericaValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, VoceGenericaCollection VoceGenericaCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd("ZVoceGenericaDelete", new string[] { "IdVoceGenerica" }, new string[] { "int" }, "");
				for (int i = 0; i < VoceGenericaCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd, db.CommandFirstChar + "IdVoceGenerica", VoceGenericaCollectionObj[i].IdVoceGenerica);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < VoceGenericaCollectionObj.Count; i++)
				{
					if ((VoceGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (VoceGenericaCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						VoceGenericaCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						VoceGenericaCollectionObj[i].IsDirty = false;
						VoceGenericaCollectionObj[i].IsPersistent = false;
					}
				}
			}
			catch
			{
				db.Rollback();
				throw;
			}
			finally
			{
				db.Close();
			}
			return returnValue;
		}

		//getById
		public static VoceGenerica GetById(DbProvider db, int IdVoceGenericaValue)
		{
			VoceGenerica VoceGenericaObj = null;
			IDbCommand readCmd = db.InitCmd("ZVoceGenericaGetById", new string[] { "IdVoceGenerica" }, new string[] { "int" }, "");
			DbProvider.SetCmdParam(readCmd, db.CommandFirstChar + "IdVoceGenerica", (SiarLibrary.NullTypes.IntNT)IdVoceGenericaValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				VoceGenericaObj = GetFromDatareader(db);
				VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceGenericaObj.IsDirty = false;
				VoceGenericaObj.IsPersistent = true;
			}
			db.Close();
			return VoceGenericaObj;
		}

		//getFromDatareader
		public static VoceGenerica GetFromDatareader(DbProvider db)
		{
			VoceGenerica VoceGenericaObj = new VoceGenerica();
			VoceGenericaObj.IdVoceGenerica = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_VOCE_GENERICA"]);
			VoceGenericaObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VoceGenericaObj.Automatico = new SiarLibrary.NullTypes.BoolNT(db.DataReader["AUTOMATICO"]);
			VoceGenericaObj.QuerySql = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL"]);
			VoceGenericaObj.QuerySqlPost = new SiarLibrary.NullTypes.StringNT(db.DataReader["QUERY_SQL_POST"]);
			VoceGenericaObj.CodeMethod = new SiarLibrary.NullTypes.StringNT(db.DataReader["CODE_METHOD"]);
			VoceGenericaObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			VoceGenericaObj.ValMinimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MINIMO"]);
			VoceGenericaObj.ValMassimo = new SiarLibrary.NullTypes.StringNT(db.DataReader["VAL_MASSIMO"]);
			VoceGenericaObj.DataInserimento = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_INSERIMENTO"]);
			VoceGenericaObj.CfInserimento = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_INSERIMENTO"]);
			VoceGenericaObj.DataModifica = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_MODIFICA"]);
			VoceGenericaObj.CfModifica = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_MODIFICA"]);
			VoceGenericaObj.ValEsitoNegativo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["VAL_ESITO_NEGATIVO"]);
			VoceGenericaObj.IdFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["ID_FILTRO"]);
			VoceGenericaObj.Titolo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["TITOLO"]);
			VoceGenericaObj.Commento = new SiarLibrary.NullTypes.StringNT(db.DataReader["COMMENTO"]);
			VoceGenericaObj.DescrizioneFiltro = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_FILTRO"]);
			VoceGenericaObj.OrdineFiltro = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FILTRO"]);
			VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VoceGenericaObj.IsDirty = false;
			VoceGenericaObj.IsPersistent = true;
			return VoceGenericaObj;
		}

		//Find Select

		public static VoceGenericaCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis,
SiarLibrary.NullTypes.StringNT QuerySqlEqualThis, SiarLibrary.NullTypes.StringNT QuerySqlPostEqualThis, SiarLibrary.NullTypes.StringNT CodeMethodEqualThis,
SiarLibrary.NullTypes.StringNT UrlEqualThis, SiarLibrary.NullTypes.StringNT ValMinimoEqualThis, SiarLibrary.NullTypes.StringNT ValMassimoEqualThis,
SiarLibrary.NullTypes.DatetimeNT DataInserimentoEqualThis, SiarLibrary.NullTypes.StringNT CfInserimentoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataModificaEqualThis,
SiarLibrary.NullTypes.StringNT CfModificaEqualThis, SiarLibrary.NullTypes.BoolNT ValEsitoNegativoEqualThis, SiarLibrary.NullTypes.StringNT IdFiltroEqualThis,
SiarLibrary.NullTypes.BoolNT TitoloEqualThis, SiarLibrary.NullTypes.StringNT CommentoEqualThis)

		{

			VoceGenericaCollection VoceGenericaCollectionObj = new VoceGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zvocegenericafindselect", new string[] {"IdVoceGenericaequalthis", "Descrizioneequalthis", "Automaticoequalthis",
"QuerySqlequalthis", "QuerySqlPostequalthis", "CodeMethodequalthis",
"Urlequalthis", "ValMinimoequalthis", "ValMassimoequalthis",
"DataInserimentoequalthis", "CfInserimentoequalthis", "DataModificaequalthis",
"CfModificaequalthis", "ValEsitoNegativoequalthis", "IdFiltroequalthis",
"Titoloequalthis", "Commentoequalthis"}, new string[] {"int", "string", "bool",
"string", "string", "string",
"string", "string", "string",
"DateTime", "string", "DateTime",
"string", "bool", "string",
"bool", "string"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuerySqlequalthis", QuerySqlEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "QuerySqlPostequalthis", QuerySqlPostEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CodeMethodequalthis", CodeMethodEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataInserimentoequalthis", DataInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfInserimentoequalthis", CfInserimentoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DataModificaequalthis", DataModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "CfModificaequalthis", CfModificaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValEsitoNegativoequalthis", ValEsitoNegativoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Commentoequalthis", CommentoEqualThis);
			VoceGenerica VoceGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VoceGenericaObj = GetFromDatareader(db);
				VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceGenericaObj.IsDirty = false;
				VoceGenericaObj.IsPersistent = true;
				VoceGenericaCollectionObj.Add(VoceGenericaObj);
			}
			db.Close();
			return VoceGenericaCollectionObj;
		}

		//Find FindVoce

		public static VoceGenericaCollection FindVoce(DbProvider db, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis, SiarLibrary.NullTypes.StringNT IdFiltroEqualThis,
SiarLibrary.NullTypes.StringNT DescrizioneFiltroEqualThis, SiarLibrary.NullTypes.IntNT OrdineFiltroEqualThis, SiarLibrary.NullTypes.BoolNT TitoloEqualThis)

		{

			VoceGenericaCollection VoceGenericaCollectionObj = new VoceGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zvocegenericafindfindvoce", new string[] {"IdVoceGenericaequalthis", "Automaticoequalthis", "IdFiltroequalthis",
"DescrizioneFiltroequalthis", "OrdineFiltroequalthis", "Titoloequalthis"}, new string[] {"int", "bool", "string",
"string", "int", "bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdFiltroequalthis", IdFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneFiltroequalthis", DescrizioneFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "OrdineFiltroequalthis", OrdineFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			VoceGenerica VoceGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VoceGenericaObj = GetFromDatareader(db);
				VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceGenericaObj.IsDirty = false;
				VoceGenericaObj.IsPersistent = true;
				VoceGenericaCollectionObj.Add(VoceGenericaObj);
			}
			db.Close();
			return VoceGenericaCollectionObj;
		}

		//Find RicercaVoci

		public static VoceGenericaCollection RicercaVoci(DbProvider db, SiarLibrary.NullTypes.IntNT IdVoceGenericaEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneFiltroEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneLikeThis,
SiarLibrary.NullTypes.StringNT ValMinimoEqualThis, SiarLibrary.NullTypes.StringNT ValMassimoEqualThis, SiarLibrary.NullTypes.BoolNT AutomaticoEqualThis,
SiarLibrary.NullTypes.BoolNT TitoloEqualThis)

		{

			VoceGenericaCollection VoceGenericaCollectionObj = new VoceGenericaCollection();

			IDbCommand findCmd = db.InitCmd("Zvocegenericafindricercavoci", new string[] {"IdVoceGenericaequalthis", "DescrizioneFiltroequalthis", "Descrizionelikethis",
"ValMinimoequalthis", "ValMassimoequalthis", "Automaticoequalthis",
"Titoloequalthis"}, new string[] {"int", "string", "string",
"string", "string", "bool",
"bool"}, "");

			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "IdVoceGenericaequalthis", IdVoceGenericaEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "DescrizioneFiltroequalthis", DescrizioneFiltroEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValMinimoequalthis", ValMinimoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "ValMassimoequalthis", ValMassimoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Automaticoequalthis", AutomaticoEqualThis);
			DbProvider.SetCmdParam(findCmd, db.CommandFirstChar + "Titoloequalthis", TitoloEqualThis);
			VoceGenerica VoceGenericaObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VoceGenericaObj = GetFromDatareader(db);
				VoceGenericaObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VoceGenericaObj.IsDirty = false;
				VoceGenericaObj.IsPersistent = true;
				VoceGenericaCollectionObj.Add(VoceGenericaObj);
			}
			db.Close();
			return VoceGenericaCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VoceGenericaCollectionProvider:IVoceGenericaProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VoceGenericaCollectionProvider : IVoceGenericaProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VoceGenerica
		protected VoceGenericaCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VoceGenericaCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VoceGenericaCollection(this);
		}

		//Costruttore 2: popola la collection
		public VoceGenericaCollectionProvider(IntNT IdvocegenericaEqualThis, BoolNT AutomaticoEqualThis, StringNT IdfiltroEqualThis,
StringNT DescrizionefiltroEqualThis, IntNT OrdinefiltroEqualThis, BoolNT TitoloEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = FindVoce(IdvocegenericaEqualThis, AutomaticoEqualThis, IdfiltroEqualThis,
DescrizionefiltroEqualThis, OrdinefiltroEqualThis, TitoloEqualThis);
		}

		//Costruttore3: ha in input vocegenericaCollectionObj - non popola la collection
		public VoceGenericaCollectionProvider(VoceGenericaCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VoceGenericaCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VoceGenericaCollection(this);
		}

		//Get e Set
		public VoceGenericaCollection CollectionObj
		{
			get
			{
				return _CollectionObj;
			}
			set
			{
				_CollectionObj = value;
			}
		}

		public DbProvider DbProviderObj
		{
			get
			{
				return _dbProviderObj;
			}
			set
			{
				_dbProviderObj = value;
			}
		}

		//Operazioni

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(VoceGenericaCollection collectionObj)
		{
			return VoceGenericaDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(VoceGenerica vocegenericaObj)
		{
			return VoceGenericaDAL.Save(_dbProviderObj, vocegenericaObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(VoceGenericaCollection collectionObj)
		{
			return VoceGenericaDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(VoceGenerica vocegenericaObj)
		{
			return VoceGenericaDAL.Delete(_dbProviderObj, vocegenericaObj);
		}

		//getById
		public VoceGenerica GetById(IntNT IdVoceGenericaValue)
		{
			VoceGenerica VoceGenericaTemp = VoceGenericaDAL.GetById(_dbProviderObj, IdVoceGenericaValue);
			if (VoceGenericaTemp != null) VoceGenericaTemp.Provider = this;
			return VoceGenericaTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public VoceGenericaCollection Select(IntNT IdvocegenericaEqualThis, StringNT DescrizioneEqualThis, BoolNT AutomaticoEqualThis,
StringNT QuerysqlEqualThis, StringNT QuerysqlpostEqualThis, StringNT CodemethodEqualThis,
StringNT UrlEqualThis, StringNT ValminimoEqualThis, StringNT ValmassimoEqualThis,
DatetimeNT DatainserimentoEqualThis, StringNT CfinserimentoEqualThis, DatetimeNT DatamodificaEqualThis,
StringNT CfmodificaEqualThis, BoolNT ValesitonegativoEqualThis, StringNT IdfiltroEqualThis,
BoolNT TitoloEqualThis, StringNT CommentoEqualThis)
		{
			VoceGenericaCollection VoceGenericaCollectionTemp = VoceGenericaDAL.Select(_dbProviderObj, IdvocegenericaEqualThis, DescrizioneEqualThis, AutomaticoEqualThis,
QuerysqlEqualThis, QuerysqlpostEqualThis, CodemethodEqualThis,
UrlEqualThis, ValminimoEqualThis, ValmassimoEqualThis,
DatainserimentoEqualThis, CfinserimentoEqualThis, DatamodificaEqualThis,
CfmodificaEqualThis, ValesitonegativoEqualThis, IdfiltroEqualThis,
TitoloEqualThis, CommentoEqualThis);
			VoceGenericaCollectionTemp.Provider = this;
			return VoceGenericaCollectionTemp;
		}

		//FindVoce: popola la collection
		public VoceGenericaCollection FindVoce(IntNT IdvocegenericaEqualThis, BoolNT AutomaticoEqualThis, StringNT IdfiltroEqualThis,
StringNT DescrizionefiltroEqualThis, IntNT OrdinefiltroEqualThis, BoolNT TitoloEqualThis)
		{
			VoceGenericaCollection VoceGenericaCollectionTemp = VoceGenericaDAL.FindVoce(_dbProviderObj, IdvocegenericaEqualThis, AutomaticoEqualThis, IdfiltroEqualThis,
DescrizionefiltroEqualThis, OrdinefiltroEqualThis, TitoloEqualThis);
			VoceGenericaCollectionTemp.Provider = this;
			return VoceGenericaCollectionTemp;
		}

		//RicercaVoci: popola la collection
		public VoceGenericaCollection RicercaVoci(IntNT IdvocegenericaEqualThis, StringNT DescrizionefiltroEqualThis, StringNT DescrizioneLikeThis,
StringNT ValminimoEqualThis, StringNT ValmassimoEqualThis, BoolNT AutomaticoEqualThis,
BoolNT TitoloEqualThis)
		{
			VoceGenericaCollection VoceGenericaCollectionTemp = VoceGenericaDAL.RicercaVoci(_dbProviderObj, IdvocegenericaEqualThis, DescrizionefiltroEqualThis, DescrizioneLikeThis,
ValminimoEqualThis, ValmassimoEqualThis, AutomaticoEqualThis,
TitoloEqualThis);
			VoceGenericaCollectionTemp.Provider = this;
			return VoceGenericaCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<VOCE_GENERICA>
  <ViewName>VVOCE_GENERICA</ViewName>
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
    <FindVoce OrderBy="ORDER BY ">
      <ID_VOCE_GENERICA>Equal</ID_VOCE_GENERICA>
      <AUTOMATICO>Equal</AUTOMATICO>
      <ID_FILTRO>Equal</ID_FILTRO>
      <DESCRIZIONE_FILTRO>Equal</DESCRIZIONE_FILTRO>
      <ORDINE_FILTRO>Equal</ORDINE_FILTRO>
      <TITOLO>Equal</TITOLO>
    </FindVoce>
    <RicercaVoci OrderBy="ORDER BY ">
      <ID_VOCE_GENERICA>Equal</ID_VOCE_GENERICA>
      <DESCRIZIONE_FILTRO>Equal</DESCRIZIONE_FILTRO>
      <DESCRIZIONE>Like</DESCRIZIONE>
      <VAL_MINIMO>Equal</VAL_MINIMO>
      <VAL_MASSIMO>Equal</VAL_MASSIMO>
      <AUTOMATICO>Equal</AUTOMATICO>
      <TITOLO>Equal</TITOLO>
    </RicercaVoci>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</VOCE_GENERICA>
*/
