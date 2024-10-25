using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VprogettoComunicazioniMassive
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VprogettoComunicazioniMassive: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdBando;
		private NullTypes.StringNT _DescrizioneBando;
		private NullTypes.IntNT _IdRup;
		private NullTypes.StringNT _Rup;
		private NullTypes.StringNT _CfRup;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.StringNT _CodStatoProgetto;
		private NullTypes.StringNT _StatoProgetto;
		private NullTypes.StringNT _SegnaturaProgetto;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.StringNT _Impresa;
		private NullTypes.StringNT _CfImpresa;
		private NullTypes.StringNT _CuaaImpresa;
		private NullTypes.IntNT _IdIstruttoreProgetto;
		private NullTypes.StringNT _IstruttoreProgetto;


		//Costruttore
		public VprogettoComunicazioniMassive()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_BANDO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdBando
		{
			get { return _IdBando; }
			set {
				if (IdBando != value)
				{
					_IdBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE_BANDO
		/// Tipo sul db:VARCHAR(2000)
		/// </summary>
		public NullTypes.StringNT DescrizioneBando
		{
			get { return _DescrizioneBando; }
			set {
				if (DescrizioneBando != value)
				{
					_DescrizioneBando = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_RUP
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRup
		{
			get { return _IdRup; }
			set {
				if (IdRup != value)
				{
					_IdRup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RUP
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT Rup
		{
			get { return _Rup; }
			set {
				if (Rup != value)
				{
					_Rup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_RUP
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfRup
		{
			get { return _CfRup; }
			set {
				if (CfRup != value)
				{
					_CfRup = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProgetto
		{
			get { return _IdProgetto; }
			set {
				if (IdProgetto != value)
				{
					_IdProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_STATO_PROGETTO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStatoProgetto
		{
			get { return _CodStatoProgetto; }
			set {
				if (CodStatoProgetto != value)
				{
					_CodStatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO_PROGETTO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT StatoProgetto
		{
			get { return _StatoProgetto; }
			set {
				if (StatoProgetto != value)
				{
					_StatoProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA_PROGETTO
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT SegnaturaProgetto
		{
			get { return _SegnaturaProgetto; }
			set {
				if (SegnaturaProgetto != value)
				{
					_SegnaturaProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_IMPRESA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdImpresa
		{
			get { return _IdImpresa; }
			set {
				if (IdImpresa != value)
				{
					_IdImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPRESA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Impresa
		{
			get { return _Impresa; }
			set {
				if (Impresa != value)
				{
					_Impresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CF_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CfImpresa
		{
			get { return _CfImpresa; }
			set {
				if (CfImpresa != value)
				{
					_CfImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CUAA_IMPRESA
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT CuaaImpresa
		{
			get { return _CuaaImpresa; }
			set {
				if (CuaaImpresa != value)
				{
					_CuaaImpresa = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ID_ISTRUTTORE_PROGETTO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdIstruttoreProgetto
		{
			get { return _IdIstruttoreProgetto; }
			set {
				if (IdIstruttoreProgetto != value)
				{
					_IdIstruttoreProgetto = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ISTRUTTORE_PROGETTO
		/// Tipo sul db:VARCHAR(511)
		/// </summary>
		public NullTypes.StringNT IstruttoreProgetto
		{
			get { return _IstruttoreProgetto; }
			set {
				if (IstruttoreProgetto != value)
				{
					_IstruttoreProgetto = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VprogettoComunicazioniMassiveCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VprogettoComunicazioniMassiveCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VprogettoComunicazioniMassiveCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VprogettoComunicazioniMassive) info.GetValue(i.ToString(),typeof(VprogettoComunicazioniMassive)));
			}
		}

		//Costruttore
		public VprogettoComunicazioniMassiveCollection()
		{
			this.ItemType = typeof(VprogettoComunicazioniMassive);
		}

		//Get e Set
		public new VprogettoComunicazioniMassive this[int index]
		{
			get { return (VprogettoComunicazioniMassive)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VprogettoComunicazioniMassiveCollection GetChanges()
		{
			return (VprogettoComunicazioniMassiveCollection) base.GetChanges();
		}

		//Add
		public int Add(VprogettoComunicazioniMassive VprogettoComunicazioniMassiveObj)
		{
			return base.Add(VprogettoComunicazioniMassiveObj);
		}

		//AddCollection
		public void AddCollection(VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionObj)
		{
			foreach (VprogettoComunicazioniMassive VprogettoComunicazioniMassiveObj in VprogettoComunicazioniMassiveCollectionObj)
				this.Add(VprogettoComunicazioniMassiveObj);
		}

		//Insert
		public void Insert(int index, VprogettoComunicazioniMassive VprogettoComunicazioniMassiveObj)
		{
			base.Insert(index, VprogettoComunicazioniMassiveObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VprogettoComunicazioniMassiveCollection SubSelect(NullTypes.IntNT IdBandoEqualThis, NullTypes.StringNT DescrizioneBandoEqualThis, NullTypes.IntNT IdRupEqualThis, 
NullTypes.StringNT RupEqualThis, NullTypes.StringNT CfRupEqualThis, NullTypes.IntNT IdProgettoEqualThis, 
NullTypes.StringNT CodStatoProgettoEqualThis, NullTypes.StringNT StatoProgettoEqualThis, NullTypes.StringNT SegnaturaProgettoEqualThis, 
NullTypes.IntNT IdImpresaEqualThis, NullTypes.StringNT ImpresaEqualThis, NullTypes.StringNT CfImpresaEqualThis, 
NullTypes.StringNT CuaaImpresaEqualThis, NullTypes.IntNT IdIstruttoreProgettoEqualThis, NullTypes.StringNT IstruttoreProgettoEqualThis)
		{
			VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionTemp = new VprogettoComunicazioniMassiveCollection();
			foreach (VprogettoComunicazioniMassive VprogettoComunicazioniMassiveItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdBando != null) && (VprogettoComunicazioniMassiveItem.IdBando.Value == IdBandoEqualThis.Value))) && ((DescrizioneBandoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.DescrizioneBando != null) && (VprogettoComunicazioniMassiveItem.DescrizioneBando.Value == DescrizioneBandoEqualThis.Value))) && ((IdRupEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdRup != null) && (VprogettoComunicazioniMassiveItem.IdRup.Value == IdRupEqualThis.Value))) && 
((RupEqualThis == null) || ((VprogettoComunicazioniMassiveItem.Rup != null) && (VprogettoComunicazioniMassiveItem.Rup.Value == RupEqualThis.Value))) && ((CfRupEqualThis == null) || ((VprogettoComunicazioniMassiveItem.CfRup != null) && (VprogettoComunicazioniMassiveItem.CfRup.Value == CfRupEqualThis.Value))) && ((IdProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdProgetto != null) && (VprogettoComunicazioniMassiveItem.IdProgetto.Value == IdProgettoEqualThis.Value))) && 
((CodStatoProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.CodStatoProgetto != null) && (VprogettoComunicazioniMassiveItem.CodStatoProgetto.Value == CodStatoProgettoEqualThis.Value))) && ((StatoProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.StatoProgetto != null) && (VprogettoComunicazioniMassiveItem.StatoProgetto.Value == StatoProgettoEqualThis.Value))) && ((SegnaturaProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.SegnaturaProgetto != null) && (VprogettoComunicazioniMassiveItem.SegnaturaProgetto.Value == SegnaturaProgettoEqualThis.Value))) && 
((IdImpresaEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdImpresa != null) && (VprogettoComunicazioniMassiveItem.IdImpresa.Value == IdImpresaEqualThis.Value))) && ((ImpresaEqualThis == null) || ((VprogettoComunicazioniMassiveItem.Impresa != null) && (VprogettoComunicazioniMassiveItem.Impresa.Value == ImpresaEqualThis.Value))) && ((CfImpresaEqualThis == null) || ((VprogettoComunicazioniMassiveItem.CfImpresa != null) && (VprogettoComunicazioniMassiveItem.CfImpresa.Value == CfImpresaEqualThis.Value))) && 
((CuaaImpresaEqualThis == null) || ((VprogettoComunicazioniMassiveItem.CuaaImpresa != null) && (VprogettoComunicazioniMassiveItem.CuaaImpresa.Value == CuaaImpresaEqualThis.Value))) && ((IdIstruttoreProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdIstruttoreProgetto != null) && (VprogettoComunicazioniMassiveItem.IdIstruttoreProgetto.Value == IdIstruttoreProgettoEqualThis.Value))) && ((IstruttoreProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IstruttoreProgetto != null) && (VprogettoComunicazioniMassiveItem.IstruttoreProgetto.Value == IstruttoreProgettoEqualThis.Value))))
				{
					VprogettoComunicazioniMassiveCollectionTemp.Add(VprogettoComunicazioniMassiveItem);
				}
			}
			return VprogettoComunicazioniMassiveCollectionTemp;
		}


		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VprogettoComunicazioniMassiveCollection Filter(NullTypes.IntNT IdBandoEqualThis, NullTypes.IntNT IdRupEqualThis, NullTypes.StringNT IstruttoreProgettoEqualThis)
		{
			VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionTemp = new VprogettoComunicazioniMassiveCollection();
			foreach (VprogettoComunicazioniMassive VprogettoComunicazioniMassiveItem in this)
			{
				if (((IdBandoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdBando != null) && (VprogettoComunicazioniMassiveItem.IdBando.Value == IdBandoEqualThis.Value))) && ((IdRupEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IdRup != null) && (VprogettoComunicazioniMassiveItem.IdRup.Value == IdRupEqualThis.Value))) && ((IstruttoreProgettoEqualThis == null) || ((VprogettoComunicazioniMassiveItem.IstruttoreProgetto != null) && (VprogettoComunicazioniMassiveItem.IstruttoreProgetto.Value == IstruttoreProgettoEqualThis.Value))))
				{
					VprogettoComunicazioniMassiveCollectionTemp.Add(VprogettoComunicazioniMassiveItem);
				}
			}
			return VprogettoComunicazioniMassiveCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VprogettoComunicazioniMassiveDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VprogettoComunicazioniMassiveDAL
	{

		//Operazioni

		//getFromDatareader
		public static VprogettoComunicazioniMassive GetFromDatareader(DbProvider db)
		{
			VprogettoComunicazioniMassive VprogettoComunicazioniMassiveObj = new VprogettoComunicazioniMassive();
			VprogettoComunicazioniMassiveObj.IdBando = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_BANDO"]);
			VprogettoComunicazioniMassiveObj.DescrizioneBando = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE_BANDO"]);
			VprogettoComunicazioniMassiveObj.IdRup = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RUP"]);
			VprogettoComunicazioniMassiveObj.Rup = new SiarLibrary.NullTypes.StringNT(db.DataReader["RUP"]);
			VprogettoComunicazioniMassiveObj.CfRup = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_RUP"]);
			VprogettoComunicazioniMassiveObj.IdProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_PROGETTO"]);
			VprogettoComunicazioniMassiveObj.CodStatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO_PROGETTO"]);
			VprogettoComunicazioniMassiveObj.StatoProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO_PROGETTO"]);
			VprogettoComunicazioniMassiveObj.SegnaturaProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["SEGNATURA_PROGETTO"]);
			VprogettoComunicazioniMassiveObj.IdImpresa = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_IMPRESA"]);
			VprogettoComunicazioniMassiveObj.Impresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["IMPRESA"]);
			VprogettoComunicazioniMassiveObj.CfImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CF_IMPRESA"]);
			VprogettoComunicazioniMassiveObj.CuaaImpresa = new SiarLibrary.NullTypes.StringNT(db.DataReader["CUAA_IMPRESA"]);
			VprogettoComunicazioniMassiveObj.IdIstruttoreProgetto = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_ISTRUTTORE_PROGETTO"]);
			VprogettoComunicazioniMassiveObj.IstruttoreProgetto = new SiarLibrary.NullTypes.StringNT(db.DataReader["ISTRUTTORE_PROGETTO"]);
			VprogettoComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VprogettoComunicazioniMassiveObj.IsDirty = false;
			VprogettoComunicazioniMassiveObj.IsPersistent = true;
			return VprogettoComunicazioniMassiveObj;
		}

		//Find Select

		public static VprogettoComunicazioniMassiveCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneBandoEqualThis, SiarLibrary.NullTypes.IntNT IdRupEqualThis, 
SiarLibrary.NullTypes.StringNT RupEqualThis, SiarLibrary.NullTypes.StringNT CfRupEqualThis, SiarLibrary.NullTypes.IntNT IdProgettoEqualThis, 
SiarLibrary.NullTypes.StringNT CodStatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT StatoProgettoEqualThis, SiarLibrary.NullTypes.StringNT SegnaturaProgettoEqualThis, 
SiarLibrary.NullTypes.IntNT IdImpresaEqualThis, SiarLibrary.NullTypes.StringNT ImpresaEqualThis, SiarLibrary.NullTypes.StringNT CfImpresaEqualThis, 
SiarLibrary.NullTypes.StringNT CuaaImpresaEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreProgettoEqualThis, SiarLibrary.NullTypes.StringNT IstruttoreProgettoEqualThis)

		{

			VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionObj = new VprogettoComunicazioniMassiveCollection();

			IDbCommand findCmd = db.InitCmd("Zvprogettocomunicazionimassivefindselect", new string[] {"IdBandoequalthis", "DescrizioneBandoequalthis", "IdRupequalthis", 
"Rupequalthis", "CfRupequalthis", "IdProgettoequalthis", 
"CodStatoProgettoequalthis", "StatoProgettoequalthis", "SegnaturaProgettoequalthis", 
"IdImpresaequalthis", "Impresaequalthis", "CfImpresaequalthis", 
"CuaaImpresaequalthis", "IdIstruttoreProgettoequalthis", "IstruttoreProgettoequalthis"}, new string[] {"int", "string", "int", 
"string", "string", "int", 
"string", "string", "string", 
"int", "string", "string", 
"string", "int", "string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "DescrizioneBandoequalthis", DescrizioneBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRupequalthis", IdRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Rupequalthis", RupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfRupequalthis", CfRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdProgettoequalthis", IdProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoProgettoequalthis", CodStatoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "StatoProgettoequalthis", StatoProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "SegnaturaProgettoequalthis", SegnaturaProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdImpresaequalthis", IdImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Impresaequalthis", ImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CfImpresaequalthis", CfImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CuaaImpresaequalthis", CuaaImpresaEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreProgettoequalthis", IdIstruttoreProgettoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IstruttoreProgettoequalthis", IstruttoreProgettoEqualThis);
			VprogettoComunicazioniMassive VprogettoComunicazioniMassiveObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VprogettoComunicazioniMassiveObj = GetFromDatareader(db);
				VprogettoComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VprogettoComunicazioniMassiveObj.IsDirty = false;
				VprogettoComunicazioniMassiveObj.IsPersistent = true;
				VprogettoComunicazioniMassiveCollectionObj.Add(VprogettoComunicazioniMassiveObj);
			}
			db.Close();
			return VprogettoComunicazioniMassiveCollectionObj;
		}

		//Find Find

		public static VprogettoComunicazioniMassiveCollection Find(DbProvider db, SiarLibrary.NullTypes.IntNT IdBandoEqualThis, SiarLibrary.NullTypes.IntNT IdRupEqualThis, SiarLibrary.NullTypes.IntNT IdIstruttoreProgettoEqualThis)

		{

			VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionObj = new VprogettoComunicazioniMassiveCollection();

			IDbCommand findCmd = db.InitCmd("Zvprogettocomunicazionimassivefindfind", new string[] {"IdBandoequalthis", "IdRupequalthis", "IdIstruttoreProgettoequalthis"}, new string[] {"int", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdBandoequalthis", IdBandoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRupequalthis", IdRupEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdIstruttoreProgettoequalthis", IdIstruttoreProgettoEqualThis);
			VprogettoComunicazioniMassive VprogettoComunicazioniMassiveObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VprogettoComunicazioniMassiveObj = GetFromDatareader(db);
				VprogettoComunicazioniMassiveObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VprogettoComunicazioniMassiveObj.IsDirty = false;
				VprogettoComunicazioniMassiveObj.IsPersistent = true;
				VprogettoComunicazioniMassiveCollectionObj.Add(VprogettoComunicazioniMassiveObj);
			}
			db.Close();
			return VprogettoComunicazioniMassiveCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VprogettoComunicazioniMassiveCollectionProvider:IVprogettoComunicazioniMassiveProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VprogettoComunicazioniMassiveCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VprogettoComunicazioniMassive
		protected VprogettoComunicazioniMassiveCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VprogettoComunicazioniMassiveCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VprogettoComunicazioniMassiveCollection();
		}

		//Costruttore 2: popola la collection
		public VprogettoComunicazioniMassiveCollectionProvider(IntNT IdbandoEqualThis, IntNT IdrupEqualThis, IntNT IdistruttoreprogettoEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdbandoEqualThis, IdrupEqualThis, IdistruttoreprogettoEqualThis);
		}

		//Costruttore3: ha in input vprogettocomunicazionimassiveCollectionObj - non popola la collection
		public VprogettoComunicazioniMassiveCollectionProvider(VprogettoComunicazioniMassiveCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VprogettoComunicazioniMassiveCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VprogettoComunicazioniMassiveCollection();
		}

		//Get e Set
		public VprogettoComunicazioniMassiveCollection CollectionObj
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

		//Select: popola la collection
		public VprogettoComunicazioniMassiveCollection Select(IntNT IdbandoEqualThis, StringNT DescrizionebandoEqualThis, IntNT IdrupEqualThis, 
StringNT RupEqualThis, StringNT CfrupEqualThis, IntNT IdprogettoEqualThis, 
StringNT CodstatoprogettoEqualThis, StringNT StatoprogettoEqualThis, StringNT SegnaturaprogettoEqualThis, 
IntNT IdimpresaEqualThis, StringNT ImpresaEqualThis, StringNT CfimpresaEqualThis, 
StringNT CuaaimpresaEqualThis, IntNT IdistruttoreprogettoEqualThis, StringNT IstruttoreprogettoEqualThis)
		{
			VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionTemp = VprogettoComunicazioniMassiveDAL.Select(_dbProviderObj, IdbandoEqualThis, DescrizionebandoEqualThis, IdrupEqualThis, 
RupEqualThis, CfrupEqualThis, IdprogettoEqualThis, 
CodstatoprogettoEqualThis, StatoprogettoEqualThis, SegnaturaprogettoEqualThis, 
IdimpresaEqualThis, ImpresaEqualThis, CfimpresaEqualThis, 
CuaaimpresaEqualThis, IdistruttoreprogettoEqualThis, IstruttoreprogettoEqualThis);
			return VprogettoComunicazioniMassiveCollectionTemp;
		}

		//Find: popola la collection
		public VprogettoComunicazioniMassiveCollection Find(IntNT IdbandoEqualThis, IntNT IdrupEqualThis, IntNT IdistruttoreprogettoEqualThis)
		{
			VprogettoComunicazioniMassiveCollection VprogettoComunicazioniMassiveCollectionTemp = VprogettoComunicazioniMassiveDAL.Find(_dbProviderObj, IdbandoEqualThis, IdrupEqualThis, IdistruttoreprogettoEqualThis);
			return VprogettoComunicazioniMassiveCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vPROGETTO_COMUNICAZIONI_MASSIVE>
  <ViewName>vPROGETTO_COMUNICAZIONI_MASSIVE</ViewName>
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
    <Find OrderBy="ORDER BY ID_BANDO, ID_PROGETTO">
      <ID_BANDO>Equal</ID_BANDO>
      <ID_RUP>Equal</ID_RUP>
      <ID_ISTRUTTORE_PROGETTO>Equal</ID_ISTRUTTORE_PROGETTO>
    </Find>
  </Finds>
  <Filters>
    <Filter>
      <ID_BANDO>Equal</ID_BANDO>
      <ID_RUP>Equal</ID_RUP>
      <ISTRUTTORE_PROGETTO>Equal</ISTRUTTORE_PROGETTO>
    </Filter>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vPROGETTO_COMUNICAZIONI_MASSIVE>
*/
