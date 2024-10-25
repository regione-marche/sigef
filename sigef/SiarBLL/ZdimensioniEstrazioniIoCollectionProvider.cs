using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	// interfaccia provider per ZdimensioniEstrazioniIo
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IZdimensioniEstrazioniIoProvider
	{
		int Save(ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj);
		int SaveCollection(ZdimensioniEstrazioniIoCollection collectionObj);
		int Delete(ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj);
		int DeleteCollection(ZdimensioniEstrazioniIoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ZdimensioniEstrazioniIo
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class ZdimensioniEstrazioniIo: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodPsr;
		private NullTypes.IntNT _IdDimPriorita;
		private NullTypes.StringNT _Codpriorita;
		private NullTypes.StringNT _Despriorita;
		private NullTypes.IntNT _Ordpriorita;
		private NullTypes.IntNT _IdDimIndicatore;
		private NullTypes.StringNT _Codindicatore;
		private NullTypes.StringNT _Desindicatore;
		private NullTypes.IntNT _Ordindicatore;
		private NullTypes.DecimalNT _ValoreRtot;
		private NullTypes.DecimalNT _ValorePf;
		private NullTypes.DatetimeNT _DataPf;
		private NullTypes.DecimalNT _ValoreF;
		private NullTypes.DatetimeNT _DataF;
		private NullTypes.IntNT _IdEstrazione;
		private NullTypes.DatetimeNT _DataEstrazione;
		private NullTypes.StringNT _Um;
		private NullTypes.IntNT _IdEstrazioneIo;
		private NullTypes.BoolNT _Bloccato;
		private NullTypes.IntNT _Anno;
		[NonSerialized] private IZdimensioniEstrazioniIoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZdimensioniEstrazioniIoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ZdimensioniEstrazioniIo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_PSR
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT CodPsr
		{
			get { return _CodPsr; }
			set {
				if (CodPsr != value)
				{
					_CodPsr = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIM_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimPriorita
		{
			get { return _IdDimPriorita; }
			set {
				if (IdDimPriorita != value)
				{
					_IdDimPriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CodPriorita
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Codpriorita
		{
			get { return _Codpriorita; }
			set {
				if (Codpriorita != value)
				{
					_Codpriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DesPriorita
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Despriorita
		{
			get { return _Despriorita; }
			set {
				if (Despriorita != value)
				{
					_Despriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OrdPriorita
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordpriorita
		{
			get { return _Ordpriorita; }
			set {
				if (Ordpriorita != value)
				{
					_Ordpriorita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_DIM_INDICATORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdDimIndicatore
		{
			get { return _IdDimIndicatore; }
			set {
				if (IdDimIndicatore != value)
				{
					_IdDimIndicatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CodIndicatore
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Codindicatore
		{
			get { return _Codindicatore; }
			set {
				if (Codindicatore != value)
				{
					_Codindicatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DesIndicatore
		/// Tipo sul db:VARCHAR(1000)
		/// </summary>
		public NullTypes.StringNT Desindicatore
		{
			get { return _Desindicatore; }
			set {
				if (Desindicatore != value)
				{
					_Desindicatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OrdIndicatore
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordindicatore
		{
			get { return _Ordindicatore; }
			set {
				if (Ordindicatore != value)
				{
					_Ordindicatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_RTOT
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreRtot
		{
			get { return _ValoreRtot; }
			set {
				if (ValoreRtot != value)
				{
					_ValoreRtot = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_PF
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValorePf
		{
			get { return _ValorePf; }
			set {
				if (ValorePf != value)
				{
					_ValorePf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_PF
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataPf
		{
			get { return _DataPf; }
			set {
				if (DataPf != value)
				{
					_DataPf = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:VALORE_F
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT ValoreF
		{
			get { return _ValoreF; }
			set {
				if (ValoreF != value)
				{
					_ValoreF = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_F
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataF
		{
			get { return _DataF; }
			set {
				if (DataF != value)
				{
					_DataF = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ESTRAZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdEstrazione
		{
			get { return _IdEstrazione; }
			set {
				if (IdEstrazione != value)
				{
					_IdEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_ESTRAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataEstrazione
		{
			get { return _DataEstrazione; }
			set {
				if (DataEstrazione != value)
				{
					_DataEstrazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:UM
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Um
		{
			get { return _Um; }
			set {
				if (Um != value)
				{
					_Um = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ESTRAZIONE_IO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdEstrazioneIo
		{
			get { return _IdEstrazioneIo; }
			set {
				if (IdEstrazioneIo != value)
				{
					_IdEstrazioneIo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:BLOCCATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Bloccato
		{
			get { return _Bloccato; }
			set {
				if (Bloccato != value)
				{
					_Bloccato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ANNO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Anno
		{
			get { return _Anno; }
			set {
				if (Anno != value)
				{
					_Anno = value;
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
	/// Summary description for ZdimensioniEstrazioniIoCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZdimensioniEstrazioniIoCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private ZdimensioniEstrazioniIoCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((ZdimensioniEstrazioniIo) info.GetValue(i.ToString(),typeof(ZdimensioniEstrazioniIo)));
			}
		}

		//Costruttore
		public ZdimensioniEstrazioniIoCollection()
		{
			this.ItemType = typeof(ZdimensioniEstrazioniIo);
		}

		//Costruttore con provider
		public ZdimensioniEstrazioniIoCollection(IZdimensioniEstrazioniIoProvider providerObj)
		{
			this.ItemType = typeof(ZdimensioniEstrazioniIo);
			this.Provider = providerObj;
		}

		//Get e Set
		public new ZdimensioniEstrazioniIo this[int index]
		{
			get { return (ZdimensioniEstrazioniIo)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new ZdimensioniEstrazioniIoCollection GetChanges()
		{
			return (ZdimensioniEstrazioniIoCollection) base.GetChanges();
		}

		[NonSerialized] private IZdimensioniEstrazioniIoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IZdimensioniEstrazioniIoProvider Provider
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
		public int Add(ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj)
		{
			if (ZdimensioniEstrazioniIoObj.Provider == null) ZdimensioniEstrazioniIoObj.Provider = this.Provider;
			return base.Add(ZdimensioniEstrazioniIoObj);
		}

		//AddCollection
		public void AddCollection(ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionObj)
		{
			foreach (ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj in ZdimensioniEstrazioniIoCollectionObj)
				this.Add(ZdimensioniEstrazioniIoObj);
		}

		//Insert
		public void Insert(int index, ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj)
		{
			if (ZdimensioniEstrazioniIoObj.Provider == null) ZdimensioniEstrazioniIoObj.Provider = this.Provider;
			base.Insert(index, ZdimensioniEstrazioniIoObj);
		}

		//CollectionGetById
		public ZdimensioniEstrazioniIo CollectionGetById(NullTypes.IntNT IdEstrazioneIoValue)
		{
			int i = 0;
			bool find = false;
			while ((i<this.Count) && (!find))
			{
				if ((this[i].IdEstrazioneIo == IdEstrazioneIoValue))
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
		public ZdimensioniEstrazioniIoCollection SubSelect(NullTypes.IntNT IdEstrazioneIoEqualThis, NullTypes.DatetimeNT DataEstrazioneEqualThis, NullTypes.StringNT CodPsrEqualThis, 
NullTypes.IntNT IdDimPrioritaEqualThis, NullTypes.IntNT IdDimIndicatoreEqualThis, NullTypes.DecimalNT ValoreRtotEqualThis, 
NullTypes.DecimalNT ValorePfEqualThis, NullTypes.DatetimeNT DataPfEqualThis, NullTypes.DecimalNT ValoreFEqualThis, 
NullTypes.DatetimeNT DataFEqualThis, NullTypes.IntNT IdEstrazioneEqualThis)
		{
			ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionTemp = new ZdimensioniEstrazioniIoCollection();
			foreach (ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoItem in this)
			{
				if (((IdEstrazioneIoEqualThis == null) || ((ZdimensioniEstrazioniIoItem.IdEstrazioneIo != null) && (ZdimensioniEstrazioniIoItem.IdEstrazioneIo.Value == IdEstrazioneIoEqualThis.Value))) && ((DataEstrazioneEqualThis == null) || ((ZdimensioniEstrazioniIoItem.DataEstrazione != null) && (ZdimensioniEstrazioniIoItem.DataEstrazione.Value == DataEstrazioneEqualThis.Value))) && ((CodPsrEqualThis == null) || ((ZdimensioniEstrazioniIoItem.CodPsr != null) && (ZdimensioniEstrazioniIoItem.CodPsr.Value == CodPsrEqualThis.Value))) && 
((IdDimPrioritaEqualThis == null) || ((ZdimensioniEstrazioniIoItem.IdDimPriorita != null) && (ZdimensioniEstrazioniIoItem.IdDimPriorita.Value == IdDimPrioritaEqualThis.Value))) && ((IdDimIndicatoreEqualThis == null) || ((ZdimensioniEstrazioniIoItem.IdDimIndicatore != null) && (ZdimensioniEstrazioniIoItem.IdDimIndicatore.Value == IdDimIndicatoreEqualThis.Value))) && ((ValoreRtotEqualThis == null) || ((ZdimensioniEstrazioniIoItem.ValoreRtot != null) && (ZdimensioniEstrazioniIoItem.ValoreRtot.Value == ValoreRtotEqualThis.Value))) && 
((ValorePfEqualThis == null) || ((ZdimensioniEstrazioniIoItem.ValorePf != null) && (ZdimensioniEstrazioniIoItem.ValorePf.Value == ValorePfEqualThis.Value))) && ((DataPfEqualThis == null) || ((ZdimensioniEstrazioniIoItem.DataPf != null) && (ZdimensioniEstrazioniIoItem.DataPf.Value == DataPfEqualThis.Value))) && ((ValoreFEqualThis == null) || ((ZdimensioniEstrazioniIoItem.ValoreF != null) && (ZdimensioniEstrazioniIoItem.ValoreF.Value == ValoreFEqualThis.Value))) && 
((DataFEqualThis == null) || ((ZdimensioniEstrazioniIoItem.DataF != null) && (ZdimensioniEstrazioniIoItem.DataF.Value == DataFEqualThis.Value))) && ((IdEstrazioneEqualThis == null) || ((ZdimensioniEstrazioniIoItem.IdEstrazione != null) && (ZdimensioniEstrazioniIoItem.IdEstrazione.Value == IdEstrazioneEqualThis.Value))))
				{
					ZdimensioniEstrazioniIoCollectionTemp.Add(ZdimensioniEstrazioniIoItem);
				}
			}
			return ZdimensioniEstrazioniIoCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for ZdimensioniEstrazioniIoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class ZdimensioniEstrazioniIoDAL
	{

		//Operazioni

		//internal CompileIUCmd compila un command con i parametri per l'insert o l'update
		protected internal static void CompileIUCmd(bool forUpdate, IDbCommand cmd, ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj,string firstChar)
		{
			if (forUpdate)
			{
				// campi identity valorizzati solo per l'update
				DbProvider.SetCmdParam(cmd,firstChar + "IdEstrazioneIo", ZdimensioniEstrazioniIoObj.IdEstrazioneIo);
				// altri campi sempre valorizzati
			}
			DbProvider.SetCmdParam(cmd,firstChar + "CodPsr", ZdimensioniEstrazioniIoObj.CodPsr);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDimPriorita", ZdimensioniEstrazioniIoObj.IdDimPriorita);
			DbProvider.SetCmdParam(cmd,firstChar + "IdDimIndicatore", ZdimensioniEstrazioniIoObj.IdDimIndicatore);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreRtot", ZdimensioniEstrazioniIoObj.ValoreRtot);
			DbProvider.SetCmdParam(cmd,firstChar + "ValorePf", ZdimensioniEstrazioniIoObj.ValorePf);
			DbProvider.SetCmdParam(cmd,firstChar + "DataPf", ZdimensioniEstrazioniIoObj.DataPf);
			DbProvider.SetCmdParam(cmd,firstChar + "ValoreF", ZdimensioniEstrazioniIoObj.ValoreF);
			DbProvider.SetCmdParam(cmd,firstChar + "DataF", ZdimensioniEstrazioniIoObj.DataF);
			DbProvider.SetCmdParam(cmd,firstChar + "IdEstrazione", ZdimensioniEstrazioniIoObj.IdEstrazione);
			DbProvider.SetCmdParam(cmd,firstChar + "DataEstrazione", ZdimensioniEstrazioniIoObj.DataEstrazione);
		}
		//Insert
		private static int Insert(DbProvider db, ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj)
		{
			int i = 1;
			try
			{
				IDbCommand insertCmd = db.InitCmd( "ZZdimensioniEstrazioniIoInsert", new string[] {"CodPsr", "IdDimPriorita", 
"IdDimIndicatore", 

"ValoreRtot", "ValorePf", "DataPf", 
"ValoreF", "DataF", "IdEstrazione", 
"DataEstrazione", }, new string[] {"string", "int", 
"int", 

"decimal", "decimal", "DateTime", 
"decimal", "DateTime", "int", 
"DateTime", },"");
				CompileIUCmd(false, insertCmd,ZdimensioniEstrazioniIoObj, db.CommandFirstChar);
				db.InitDatareader(insertCmd);
				if (db.DataReader.Read())
			{
				ZdimensioniEstrazioniIoObj.IdEstrazioneIo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE_IO"]);
				}
				ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniIoObj.IsDirty = false;
				ZdimensioniEstrazioniIoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//update
		private static int Update(DbProvider db, ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj)
		{
			int i = 1;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZdimensioniEstrazioniIoUpdate", new string[] {"CodPsr", "IdDimPriorita", 
"IdDimIndicatore", 

"ValoreRtot", "ValorePf", "DataPf", 
"ValoreF", "DataF", "IdEstrazione", 
"DataEstrazione", "IdEstrazioneIo", }, new string[] {"string", "int", 
"int", 

"decimal", "decimal", "DateTime", 
"decimal", "DateTime", "int", 
"DateTime", "int", },"");
				CompileIUCmd(true, updateCmd,ZdimensioniEstrazioniIoObj, db.CommandFirstChar);
			i = db.Execute(updateCmd);
				ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniIoObj.IsDirty = false;
				ZdimensioniEstrazioniIoObj.IsPersistent = true;
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		//Save
		public static int Save(DbProvider db, ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj)
		{
			switch (ZdimensioniEstrazioniIoObj.ObjectState)
			{
				case BaseObject.ObjectStateType.Added : return Insert(db, ZdimensioniEstrazioniIoObj);
				case BaseObject.ObjectStateType.Changed : return Update(db, ZdimensioniEstrazioniIoObj);
				case BaseObject.ObjectStateType.Deleted : return Delete(db,ZdimensioniEstrazioniIoObj);
				default : return 0;
			}
		}

		public static int SaveCollection(DbProvider db, ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand updateCmd = db.InitCmd( "ZZdimensioniEstrazioniIoUpdate", new string[] {"CodPsr", "IdDimPriorita", 
"IdDimIndicatore", 

"ValoreRtot", "ValorePf", "DataPf", 
"ValoreF", "DataF", "IdEstrazione", 
"DataEstrazione", "IdEstrazioneIo", }, new string[] {"string", "int", 
"int", 

"decimal", "decimal", "DateTime", 
"decimal", "DateTime", "int", 
"DateTime", "int", },"");
				IDbCommand insertCmd = db.InitCmd( "ZZdimensioniEstrazioniIoInsert", new string[] {"CodPsr", "IdDimPriorita", 
"IdDimIndicatore", 

"ValoreRtot", "ValorePf", "DataPf", 
"ValoreF", "DataF", "IdEstrazione", 
"DataEstrazione", }, new string[] {"string", "int", 
"int", 

"decimal", "decimal", "DateTime", 
"decimal", "DateTime", "int", 
"DateTime", },"");
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniEstrazioniIoDelete", new string[] {"IdEstrazioneIo"}, new string[] {"int"},"");
				for (int i = 0; i < ZdimensioniEstrazioniIoCollectionObj.Count; i++)
				{
					switch (ZdimensioniEstrazioniIoCollectionObj[i].ObjectState)
					{
						case BaseObject.ObjectStateType.Added : 
							{
								CompileIUCmd(false, insertCmd,ZdimensioniEstrazioniIoCollectionObj[i], db.CommandFirstChar);
								db.InitDatareader(insertCmd);
								if (db.DataReader.Read())
								{
									ZdimensioniEstrazioniIoCollectionObj[i].IdEstrazioneIo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE_IO"]);
								}
								db.DataReader.Close();
								returnValue++;
							}
							break;
						case BaseObject.ObjectStateType.Changed : 
							{
								CompileIUCmd(true, updateCmd,ZdimensioniEstrazioniIoCollectionObj[i], db.CommandFirstChar);
								returnValue = returnValue + db.Execute(updateCmd);
							}
							break;
						case BaseObject.ObjectStateType.Deleted : 
							{
								if (ZdimensioniEstrazioniIoCollectionObj[i].IsPersistent)
								{
									DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazioneIo", (SiarLibrary.NullTypes.IntNT)ZdimensioniEstrazioniIoCollectionObj[i].IdEstrazioneIo);
									returnValue = returnValue + db.Execute(deleteCmd);
								}
							}
							break;
					}
				}
				db.Commit();
				for (int i = 0; i < ZdimensioniEstrazioniIoCollectionObj.Count; i++)
				{
					if ((ZdimensioniEstrazioniIoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniEstrazioniIoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZdimensioniEstrazioniIoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Unchanged;
						ZdimensioniEstrazioniIoCollectionObj[i].IsDirty = false;
						ZdimensioniEstrazioniIoCollectionObj[i].IsPersistent = true;
					}
					if ((ZdimensioniEstrazioniIoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Deleted))
					{
						ZdimensioniEstrazioniIoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZdimensioniEstrazioniIoCollectionObj[i].IsDirty = false;
						ZdimensioniEstrazioniIoCollectionObj[i].IsPersistent = false;
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
		public static int Delete(DbProvider db, ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj)
		{
			int returnValue = 0;
			if (ZdimensioniEstrazioniIoObj.IsPersistent) 
			{
				returnValue = Delete(db, ZdimensioniEstrazioniIoObj.IdEstrazioneIo);
			}
			ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Deleted;
			ZdimensioniEstrazioniIoObj.IsDirty = false;
			ZdimensioniEstrazioniIoObj.IsPersistent = false;
			return returnValue;
		}

		//Delete
		private static int Delete(DbProvider db, int IdEstrazioneIoValue)
		{
			int i = 1;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniEstrazioniIoDelete", new string[] {"IdEstrazioneIo"}, new string[] {"int"},"");
				DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazioneIo", (SiarLibrary.NullTypes.IntNT)IdEstrazioneIoValue);
				i = db.Execute(deleteCmd);
			}
			finally
			{
				db.Close();
			}
			return i;
		}

		public static int DeleteCollection(DbProvider db, ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionObj)
		{
			db.BeginTran();
			int returnValue = 0;
			try
			{
				IDbCommand deleteCmd = db.InitCmd( "ZZdimensioniEstrazioniIoDelete", new string[] {"IdEstrazioneIo"}, new string[] {"int"},"");
				for (int i = 0; i < ZdimensioniEstrazioniIoCollectionObj.Count; i++)
				{
					DbProvider.SetCmdParam(deleteCmd,db.CommandFirstChar + "IdEstrazioneIo", ZdimensioniEstrazioniIoCollectionObj[i].IdEstrazioneIo);
					returnValue = returnValue + db.Execute(deleteCmd);
				}
				db.Commit();
				for (int i = 0; i < ZdimensioniEstrazioniIoCollectionObj.Count; i++)
				{
					if ((ZdimensioniEstrazioniIoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Added) || (ZdimensioniEstrazioniIoCollectionObj[i].ObjectState == BaseObject.ObjectStateType.Changed))
					{
						ZdimensioniEstrazioniIoCollectionObj[i].ObjectState = BaseObject.ObjectStateType.Deleted;
						ZdimensioniEstrazioniIoCollectionObj[i].IsDirty = false;
						ZdimensioniEstrazioniIoCollectionObj[i].IsPersistent = false;
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
		public static ZdimensioniEstrazioniIo GetById(DbProvider db, int IdEstrazioneIoValue)
		{
			ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj = null;
			IDbCommand readCmd = db.InitCmd( "ZZdimensioniEstrazioniIoGetById", new string[] {"IdEstrazioneIo"}, new string[] {"int"},"");
			DbProvider.SetCmdParam(readCmd,db.CommandFirstChar + "IdEstrazioneIo", (SiarLibrary.NullTypes.IntNT)IdEstrazioneIoValue);
			db.InitDatareader(readCmd);
			if (db.DataReader.Read())
			{
				ZdimensioniEstrazioniIoObj = GetFromDatareader(db);
				ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniIoObj.IsDirty = false;
				ZdimensioniEstrazioniIoObj.IsPersistent = true;
			}
			db.Close();
			return ZdimensioniEstrazioniIoObj;
		}

		//getFromDatareader
		public static ZdimensioniEstrazioniIo GetFromDatareader(DbProvider db)
		{
			ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj = new ZdimensioniEstrazioniIo();
			ZdimensioniEstrazioniIoObj.CodPsr = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_PSR"]);
			ZdimensioniEstrazioniIoObj.IdDimPriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIM_PRIORITA"]);
			ZdimensioniEstrazioniIoObj.Codpriorita = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodPriorita"]);
			ZdimensioniEstrazioniIoObj.Despriorita = new SiarLibrary.NullTypes.StringNT(db.DataReader["DesPriorita"]);
			ZdimensioniEstrazioniIoObj.Ordpriorita = new SiarLibrary.NullTypes.IntNT(db.DataReader["OrdPriorita"]);
			ZdimensioniEstrazioniIoObj.IdDimIndicatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_DIM_INDICATORE"]);
			ZdimensioniEstrazioniIoObj.Codindicatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["CodIndicatore"]);
			ZdimensioniEstrazioniIoObj.Desindicatore = new SiarLibrary.NullTypes.StringNT(db.DataReader["DesIndicatore"]);
			ZdimensioniEstrazioniIoObj.Ordindicatore = new SiarLibrary.NullTypes.IntNT(db.DataReader["OrdIndicatore"]);
			ZdimensioniEstrazioniIoObj.ValoreRtot = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_RTOT"]);
			ZdimensioniEstrazioniIoObj.ValorePf = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_PF"]);
			ZdimensioniEstrazioniIoObj.DataPf = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_PF"]);
			ZdimensioniEstrazioniIoObj.ValoreF = new SiarLibrary.NullTypes.DecimalNT(db.DataReader["VALORE_F"]);
			ZdimensioniEstrazioniIoObj.DataF = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_F"]);
			ZdimensioniEstrazioniIoObj.IdEstrazione = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE"]);
			ZdimensioniEstrazioniIoObj.DataEstrazione = new SiarLibrary.NullTypes.DatetimeNT(db.DataReader["DATA_ESTRAZIONE"]);
			ZdimensioniEstrazioniIoObj.Um = new SiarLibrary.NullTypes.StringNT(db.DataReader["UM"]);
			ZdimensioniEstrazioniIoObj.IdEstrazioneIo = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ESTRAZIONE_IO"]);
			ZdimensioniEstrazioniIoObj.Bloccato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["BLOCCATO"]);
			ZdimensioniEstrazioniIoObj.Anno = new SiarLibrary.NullTypes.IntNT(db.DataReader["ANNO"]);
			ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			ZdimensioniEstrazioniIoObj.IsDirty = false;
			ZdimensioniEstrazioniIoObj.IsPersistent = true;
			return ZdimensioniEstrazioniIoObj;
		}

		//Find Select

		public static ZdimensioniEstrazioniIoCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdEstrazioneIoEqualThis, SiarLibrary.NullTypes.DatetimeNT DataEstrazioneEqualThis, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, 
SiarLibrary.NullTypes.IntNT IdDimPrioritaEqualThis, SiarLibrary.NullTypes.IntNT IdDimIndicatoreEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreRtotEqualThis, 
SiarLibrary.NullTypes.DecimalNT ValorePfEqualThis, SiarLibrary.NullTypes.DatetimeNT DataPfEqualThis, SiarLibrary.NullTypes.DecimalNT ValoreFEqualThis, 
SiarLibrary.NullTypes.DatetimeNT DataFEqualThis, SiarLibrary.NullTypes.IntNT IdEstrazioneEqualThis)

		{

			ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionObj = new ZdimensioniEstrazioniIoCollection();

			IDbCommand findCmd = db.InitCmd("Zzdimensioniestrazioniiofindselect", new string[] {"IdEstrazioneIoequalthis", "DataEstrazioneequalthis", "CodPsrequalthis", 
"IdDimPrioritaequalthis", "IdDimIndicatoreequalthis", "ValoreRtotequalthis", 
"ValorePfequalthis", "DataPfequalthis", "ValoreFequalthis", 
"DataFequalthis", "IdEstrazioneequalthis"}, new string[] {"int", "DateTime", "string", 
"int", "int", "decimal", 
"decimal", "DateTime", "decimal", 
"DateTime", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEstrazioneIoequalthis", IdEstrazioneIoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataEstrazioneequalthis", DataEstrazioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDimPrioritaequalthis", IdDimPrioritaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdDimIndicatoreequalthis", IdDimIndicatoreEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreRtotequalthis", ValoreRtotEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValorePfequalthis", ValorePfEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataPfequalthis", DataPfEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "ValoreFequalthis", ValoreFEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DataFequalthis", DataFEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdEstrazioneequalthis", IdEstrazioneEqualThis);
			ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZdimensioniEstrazioniIoObj = GetFromDatareader(db);
				ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniIoObj.IsDirty = false;
				ZdimensioniEstrazioniIoObj.IsPersistent = true;
				ZdimensioniEstrazioniIoCollectionObj.Add(ZdimensioniEstrazioniIoObj);
			}
			db.Close();
			return ZdimensioniEstrazioniIoCollectionObj;
		}

		//Find Find

		public static ZdimensioniEstrazioniIoCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodPsrEqualThis, SiarLibrary.NullTypes.IntNT AnnoEqualThis)

		{

			ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionObj = new ZdimensioniEstrazioniIoCollection();

			IDbCommand findCmd = db.InitCmd("Zzdimensioniestrazioniiofindfind", new string[] {"CodPsrequalthis", "Annoequalthis"}, new string[] {"string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodPsrequalthis", CodPsrEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Annoequalthis", AnnoEqualThis);
			ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				ZdimensioniEstrazioniIoObj = GetFromDatareader(db);
				ZdimensioniEstrazioniIoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				ZdimensioniEstrazioniIoObj.IsDirty = false;
				ZdimensioniEstrazioniIoObj.IsPersistent = true;
				ZdimensioniEstrazioniIoCollectionObj.Add(ZdimensioniEstrazioniIoObj);
			}
			db.Close();
			return ZdimensioniEstrazioniIoCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for ZdimensioniEstrazioniIoCollectionProvider:IZdimensioniEstrazioniIoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class ZdimensioniEstrazioniIoCollectionProvider : IZdimensioniEstrazioniIoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di ZdimensioniEstrazioniIo
		protected ZdimensioniEstrazioniIoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public ZdimensioniEstrazioniIoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new ZdimensioniEstrazioniIoCollection(this);
		}

		//Costruttore 2: popola la collection
		public ZdimensioniEstrazioniIoCollectionProvider(StringNT CodpsrEqualThis, IntNT AnnoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(CodpsrEqualThis, AnnoEqualThis);
		}

		//Costruttore3: ha in input zdimensioniestrazioniioCollectionObj - non popola la collection
		public ZdimensioniEstrazioniIoCollectionProvider(ZdimensioniEstrazioniIoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public ZdimensioniEstrazioniIoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new ZdimensioniEstrazioniIoCollection(this);
		}

		//Get e Set
		public ZdimensioniEstrazioniIoCollection CollectionObj
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
		public int SaveCollection(ZdimensioniEstrazioniIoCollection collectionObj)
		{
			return ZdimensioniEstrazioniIoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(ZdimensioniEstrazioniIo zdimensioniestrazioniioObj)
		{
			return ZdimensioniEstrazioniIoDAL.Save(_dbProviderObj, zdimensioniestrazioniioObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(ZdimensioniEstrazioniIoCollection collectionObj)
		{
			return ZdimensioniEstrazioniIoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(ZdimensioniEstrazioniIo zdimensioniestrazioniioObj)
		{
			return ZdimensioniEstrazioniIoDAL.Delete(_dbProviderObj, zdimensioniestrazioniioObj);
		}

		//getById
		public ZdimensioniEstrazioniIo GetById(IntNT IdEstrazioneIoValue)
		{
			ZdimensioniEstrazioniIo ZdimensioniEstrazioniIoTemp = ZdimensioniEstrazioniIoDAL.GetById(_dbProviderObj, IdEstrazioneIoValue);
			if (ZdimensioniEstrazioniIoTemp!=null) ZdimensioniEstrazioniIoTemp.Provider = this;
			return ZdimensioniEstrazioniIoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public ZdimensioniEstrazioniIoCollection Select(IntNT IdestrazioneioEqualThis, DatetimeNT DataestrazioneEqualThis, StringNT CodpsrEqualThis, 
IntNT IddimprioritaEqualThis, IntNT IddimindicatoreEqualThis, DecimalNT ValorertotEqualThis, 
DecimalNT ValorepfEqualThis, DatetimeNT DatapfEqualThis, DecimalNT ValorefEqualThis, 
DatetimeNT DatafEqualThis, IntNT IdestrazioneEqualThis)
		{
			ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionTemp = ZdimensioniEstrazioniIoDAL.Select(_dbProviderObj, IdestrazioneioEqualThis, DataestrazioneEqualThis, CodpsrEqualThis, 
IddimprioritaEqualThis, IddimindicatoreEqualThis, ValorertotEqualThis, 
ValorepfEqualThis, DatapfEqualThis, ValorefEqualThis, 
DatafEqualThis, IdestrazioneEqualThis);
			ZdimensioniEstrazioniIoCollectionTemp.Provider = this;
			return ZdimensioniEstrazioniIoCollectionTemp;
		}

		//Find: popola la collection
		public ZdimensioniEstrazioniIoCollection Find(StringNT CodpsrEqualThis, IntNT AnnoEqualThis)
		{
			ZdimensioniEstrazioniIoCollection ZdimensioniEstrazioniIoCollectionTemp = ZdimensioniEstrazioniIoDAL.Find(_dbProviderObj, CodpsrEqualThis, AnnoEqualThis);
			ZdimensioniEstrazioniIoCollectionTemp.Provider = this;
			return ZdimensioniEstrazioniIoCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<zDIMENSIONI_ESTRAZIONI_IO>
  <ViewName>vzDIMENSIONI_ESTRAZIONI_IO</ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>False</chkDataModifica>
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
      <COD_PSR>Equal</COD_PSR>
      <ANNO>Equal</ANNO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</zDIMENSIONI_ESTRAZIONI_IO>
*/
