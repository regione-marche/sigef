using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaEnti
	/// Class Autogenerata
	/// ***IMPORTANTE*** Per Inserire eventuali operazioni aggiuntive creare un file a parte 
	/// con delle partial class contenenti i metodi aggiunti, in questo modo 
	/// non verranno sovrascritti quando si rigenera la classe 
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public partial class VrnaEnti: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRnaEnte;
		private NullTypes.StringNT _CodEnte;
		private NullTypes.StringNT _Username;
		private NullTypes.BoolNT _Abilitato;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Attivo;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.BoolNT _CredenzialiProduzione;


		//Costruttore
		public VrnaEnti()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_RNA_ENTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRnaEnte
		{
			get { return _IdRnaEnte; }
			set {
				if (IdRnaEnte != value)
				{
					_IdRnaEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodEnte
		{
			get { return _CodEnte; }
			set {
				if (CodEnte != value)
				{
					_CodEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:USERNAME
		/// Tipo sul db:NVARCHAR(250)
		/// </summary>
		public NullTypes.StringNT Username
		{
			get { return _Username; }
			set {
				if (Username != value)
				{
					_Username = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ABILITATO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Abilitato
		{
			get { return _Abilitato; }
			set {
				if (Abilitato != value)
				{
					_Abilitato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Descrizione
		{
			get { return _Descrizione; }
			set {
				if (Descrizione != value)
				{
					_Descrizione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ATTIVO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Attivo
		{
			get { return _Attivo; }
			set {
				if (Attivo != value)
				{
					_Attivo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:CREDENZIALI_PRODUZIONE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT CredenzialiProduzione
		{
			get { return _CredenzialiProduzione; }
			set {
				if (CredenzialiProduzione != value)
				{
					_CredenzialiProduzione = value;
					SetDirtyFlag();
				}
			}
		}




	}
}

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VrnaEntiCollection
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaEntiCollection : CustomCollection, System.Runtime.Serialization.ISerializable
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
		private VrnaEntiCollection(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context):this()
		{
			int c=info.GetInt32("_count");
			for(int i=0;i<c;i++)
			{
				this.Add((VrnaEnti) info.GetValue(i.ToString(),typeof(VrnaEnti)));
			}
		}

		//Costruttore
		public VrnaEntiCollection()
		{
			this.ItemType = typeof(VrnaEnti);
		}

		//Get e Set
		public new VrnaEnti this[int index]
		{
			get { return (VrnaEnti)(base[index]); }
			set
			{
				base[index] = value;
			}
		}

		public new VrnaEntiCollection GetChanges()
		{
			return (VrnaEntiCollection) base.GetChanges();
		}

		//Add
		public int Add(VrnaEnti VrnaEntiObj)
		{
			return base.Add(VrnaEntiObj);
		}

		//AddCollection
		public void AddCollection(VrnaEntiCollection VrnaEntiCollectionObj)
		{
			foreach (VrnaEnti VrnaEntiObj in VrnaEntiCollectionObj)
				this.Add(VrnaEntiObj);
		}

		//Insert
		public void Insert(int index, VrnaEnti VrnaEntiObj)
		{
			base.Insert(index, VrnaEntiObj);
		}

		//filter: effettua una ricerca all'interno della collection
		// se il parametro di ricerca è null, prende tutto,
		// anche i record che hanno quel campo null
		// altrimenti scarta i record che hanno quel campo null ...
		// ...e confronta gli altri
		public VrnaEntiCollection SubSelect(NullTypes.IntNT IdRnaEnteEqualThis, NullTypes.StringNT CodEnteEqualThis, NullTypes.StringNT UsernameEqualThis, 
NullTypes.BoolNT AbilitatoEqualThis, NullTypes.StringNT DescrizioneEqualThis, NullTypes.BoolNT AttivoEqualThis, 
NullTypes.StringNT CodTipoEnteEqualThis, NullTypes.BoolNT CredenzialiProduzioneEqualThis)
		{
			VrnaEntiCollection VrnaEntiCollectionTemp = new VrnaEntiCollection();
			foreach (VrnaEnti VrnaEntiItem in this)
			{
				if (((IdRnaEnteEqualThis == null) || ((VrnaEntiItem.IdRnaEnte != null) && (VrnaEntiItem.IdRnaEnte.Value == IdRnaEnteEqualThis.Value))) && ((CodEnteEqualThis == null) || ((VrnaEntiItem.CodEnte != null) && (VrnaEntiItem.CodEnte.Value == CodEnteEqualThis.Value))) && ((UsernameEqualThis == null) || ((VrnaEntiItem.Username != null) && (VrnaEntiItem.Username.Value == UsernameEqualThis.Value))) && 
((AbilitatoEqualThis == null) || ((VrnaEntiItem.Abilitato != null) && (VrnaEntiItem.Abilitato.Value == AbilitatoEqualThis.Value))) && ((DescrizioneEqualThis == null) || ((VrnaEntiItem.Descrizione != null) && (VrnaEntiItem.Descrizione.Value == DescrizioneEqualThis.Value))) && ((AttivoEqualThis == null) || ((VrnaEntiItem.Attivo != null) && (VrnaEntiItem.Attivo.Value == AttivoEqualThis.Value))) && 
((CodTipoEnteEqualThis == null) || ((VrnaEntiItem.CodTipoEnte != null) && (VrnaEntiItem.CodTipoEnte.Value == CodTipoEnteEqualThis.Value))) && ((CredenzialiProduzioneEqualThis == null) || ((VrnaEntiItem.CredenzialiProduzione != null) && (VrnaEntiItem.CredenzialiProduzione.Value == CredenzialiProduzioneEqualThis.Value))))
				{
					VrnaEntiCollectionTemp.Add(VrnaEntiItem);
				}
			}
			return VrnaEntiCollectionTemp;
		}



	}
}

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VrnaEntiDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	internal class VrnaEntiDAL
	{

		//Operazioni

		//getFromDatareader
		public static VrnaEnti GetFromDatareader(DbProvider db)
		{
			VrnaEnti VrnaEntiObj = new VrnaEnti();
			VrnaEntiObj.IdRnaEnte = new SiarLibrary.NullTypes.IntNT(db.DataReader["ID_RNA_ENTE"]);
			VrnaEntiObj.CodEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_ENTE"]);
			VrnaEntiObj.Username = new SiarLibrary.NullTypes.StringNT(db.DataReader["USERNAME"]);
			VrnaEntiObj.Abilitato = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ABILITATO"]);
			VrnaEntiObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VrnaEntiObj.Attivo = new SiarLibrary.NullTypes.BoolNT(db.DataReader["ATTIVO"]);
			VrnaEntiObj.CodTipoEnte = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO_ENTE"]);
			VrnaEntiObj.CredenzialiProduzione = new SiarLibrary.NullTypes.BoolNT(db.DataReader["CREDENZIALI_PRODUZIONE"]);
			VrnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VrnaEntiObj.IsDirty = false;
			VrnaEntiObj.IsPersistent = true;
			return VrnaEntiObj;
		}

		//Find Select

		public static VrnaEntiCollection Select(DbProvider db, SiarLibrary.NullTypes.IntNT IdRnaEnteEqualThis, SiarLibrary.NullTypes.StringNT CodEnteEqualThis, SiarLibrary.NullTypes.StringNT UsernameEqualThis, 
SiarLibrary.NullTypes.BoolNT AbilitatoEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.BoolNT AttivoEqualThis, 
SiarLibrary.NullTypes.StringNT CodTipoEnteEqualThis, SiarLibrary.NullTypes.BoolNT CredenzialiProduzioneEqualThis)

		{

			VrnaEntiCollection VrnaEntiCollectionObj = new VrnaEntiCollection();

			IDbCommand findCmd = db.InitCmd("Zvrnaentifindselect", new string[] {"IdRnaEnteequalthis", "CodEnteequalthis", "Usernameequalthis", 
"Abilitatoequalthis", "Descrizioneequalthis", "Attivoequalthis", 
"CodTipoEnteequalthis", "CredenzialiProduzioneequalthis"}, new string[] {"int", "string", "string", 
"bool", "string", "bool", 
"string", "bool"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "IdRnaEnteequalthis", IdRnaEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodEnteequalthis", CodEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Usernameequalthis", UsernameEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Abilitatoequalthis", AbilitatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Attivoequalthis", AttivoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoEnteequalthis", CodTipoEnteEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CredenzialiProduzioneequalthis", CredenzialiProduzioneEqualThis);
			VrnaEnti VrnaEntiObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VrnaEntiObj = GetFromDatareader(db);
				VrnaEntiObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VrnaEntiObj.IsDirty = false;
				VrnaEntiObj.IsPersistent = true;
				VrnaEntiCollectionObj.Add(VrnaEntiObj);
			}
			db.Close();
			return VrnaEntiCollectionObj;
		}

	}
}


namespace SiarBLL
{

	/// <summary>
	/// Summary description for VrnaEntiCollectionProvider:IVrnaEntiProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public partial class VrnaEntiCollectionProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di VrnaEnti
		protected VrnaEntiCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public VrnaEntiCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new VrnaEntiCollection();
		}

		//Costruttore3: ha in input vrnaentiCollectionObj - non popola la collection
		public VrnaEntiCollectionProvider(VrnaEntiCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public VrnaEntiCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new VrnaEntiCollection();
		}

		//Get e Set
		public VrnaEntiCollection CollectionObj
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
		public VrnaEntiCollection Select(IntNT IdrnaenteEqualThis, StringNT CodenteEqualThis, StringNT UsernameEqualThis, 
BoolNT AbilitatoEqualThis, StringNT DescrizioneEqualThis, BoolNT AttivoEqualThis, 
StringNT CodtipoenteEqualThis, BoolNT CredenzialiproduzioneEqualThis)
		{
			VrnaEntiCollection VrnaEntiCollectionTemp = VrnaEntiDAL.Select(_dbProviderObj, IdrnaenteEqualThis, CodenteEqualThis, UsernameEqualThis, 
AbilitatoEqualThis, DescrizioneEqualThis, AttivoEqualThis, 
CodtipoenteEqualThis, CredenzialiproduzioneEqualThis);
			return VrnaEntiCollectionTemp;
		}


	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vRNA_ENTI>
  <ViewName>vRNA_ENTI</ViewName>
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
  <Finds />
  <Filters />
  <externalFields />
  <AddedFkFields />
</vRNA_ENTI>
*/
