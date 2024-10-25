using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per VariantiSegnature
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVariantiSegnatureProvider
	{
		int Save(VariantiSegnature VariantiSegnatureObj);
		int SaveCollection(VariantiSegnatureCollection collectionObj);
		int Delete(VariantiSegnature VariantiSegnatureObj);
		int DeleteCollection(VariantiSegnatureCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VariantiSegnature
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class VariantiSegnature: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVariante;
		private NullTypes.StringNT _CodTipo;
		private NullTypes.StringNT _Segnatura;
		private NullTypes.DatetimeNT _Data;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Motivazione;
		private NullTypes.BoolNT _RiapriVariante;
		[NonSerialized] private IVariantiSegnatureProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiSegnatureProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VariantiSegnature()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VARIANTE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdVariante
		{
			get { return _IdVariante; }
			set {
				if (IdVariante != value)
				{
					_IdVariante = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_TIPO
		/// Tipo sul db:CHAR(3)
		/// </summary>
		public NullTypes.StringNT CodTipo
		{
			get { return _CodTipo; }
			set {
				if (CodTipo != value)
				{
					_CodTipo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:SEGNATURA
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Segnatura
		{
			get { return _Segnatura; }
			set {
				if (Segnatura != value)
				{
					_Segnatura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT Data
		{
			get { return _Data; }
			set {
				if (Data != value)
				{
					_Data = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:OPERATORE
		/// Tipo sul db:VARCHAR(16)
		/// </summary>
		public NullTypes.StringNT Operatore
		{
			get { return _Operatore; }
			set {
				if (Operatore != value)
				{
					_Operatore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MOTIVAZIONE
		/// Tipo sul db:NTEXT
		/// </summary>
		public NullTypes.StringNT Motivazione
		{
			get { return _Motivazione; }
			set {
				if (Motivazione != value)
				{
					_Motivazione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:RIAPRI_VARIANTE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT RiapriVariante
		{
			get { return _RiapriVariante; }
			set {
				if (RiapriVariante != value)
				{
					_RiapriVariante = value;
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
/*Config
<?xml version="1.0" encoding="utf-16"?>
<VARIANTI_SEGNATURE>
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
    <Find OrderBy="ORDER BY DATA DESC">
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <COD_TIPO>Equal</COD_TIPO>
      <RIAPRI_VARIANTE>Equal</RIAPRI_VARIANTE>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_SEGNATURE>
*/