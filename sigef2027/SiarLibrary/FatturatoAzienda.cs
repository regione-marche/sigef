using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per FatturatoAzienda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IFatturatoAziendaProvider
	{
		int Save(FatturatoAzienda FatturatoAziendaObj);
		int SaveCollection(FatturatoAziendaCollection collectionObj);
		int Delete(FatturatoAzienda FatturatoAziendaObj);
		int DeleteCollection(FatturatoAziendaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for FatturatoAzienda
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class FatturatoAzienda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdFatturato;
		private NullTypes.IntNT _IdImpresa;
		private NullTypes.DatetimeNT _DataModifica;
		private NullTypes.IntNT _Anno;
		private NullTypes.DecimalNT _Aliquota;
		private NullTypes.DecimalNT _Importo;
		[NonSerialized] private IFatturatoAziendaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IFatturatoAziendaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public FatturatoAzienda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_FATTURATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdFatturato
		{
			get { return _IdFatturato; }
			set {
				if (IdFatturato != value)
				{
					_IdFatturato = value;
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
		/// Corrisponde al campo:DATA_MODIFICA
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataModifica
		{
			get { return _DataModifica; }
			set {
				if (DataModifica != value)
				{
					_DataModifica = value;
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

		/// <summary>
		/// Corrisponde al campo:ALIQUOTA
		/// Tipo sul db:DECIMAL(10,2)
		/// </summary>
		public NullTypes.DecimalNT Aliquota
		{
			get { return _Aliquota; }
			set {
				if (Aliquota != value)
				{
					_Aliquota = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:IMPORTO
		/// Tipo sul db:DECIMAL(18,2)
		/// </summary>
		public NullTypes.DecimalNT Importo
		{
			get { return _Importo; }
			set {
				if (Importo != value)
				{
					_Importo = value;
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