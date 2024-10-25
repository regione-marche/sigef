using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per VariantiXPriorita
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IVariantiXPrioritaProvider
	{
		int Save(VariantiXPriorita VariantiXPrioritaObj);
		int SaveCollection(VariantiXPrioritaCollection collectionObj);
		int Delete(VariantiXPriorita VariantiXPrioritaObj);
		int DeleteCollection(VariantiXPrioritaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for VariantiXPriorita
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class VariantiXPriorita: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdVariante;
		private NullTypes.IntNT _IdPriorita;
		private NullTypes.IntNT _IdProgetto;
		private NullTypes.DecimalNT _Punteggio;
		private NullTypes.DatetimeNT _DataValutazione;
		private NullTypes.StringNT _Operatore;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodLivello;
		private NullTypes.BoolNT _PluriValore;
		private NullTypes.StringNT _Eval;
		private NullTypes.BoolNT _FlagManuale;
		private NullTypes.BoolNT _InputNumerico;
		private NullTypes.StringNT _Misura;
		private NullTypes.BoolNT _FlagDefinitivo;
		[NonSerialized] private IVariantiXPrioritaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IVariantiXPrioritaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public VariantiXPriorita()
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
		/// Corrisponde al campo:ID_PRIORITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdPriorita
		{
			get { return _IdPriorita; }
			set {
				if (IdPriorita != value)
				{
					_IdPriorita = value;
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
		/// Corrisponde al campo:PUNTEGGIO
		/// Tipo sul db:DECIMAL(10,6)
		/// </summary>
		public NullTypes.DecimalNT Punteggio
		{
			get { return _Punteggio; }
			set {
				if (Punteggio != value)
				{
					_Punteggio = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATA_VALUTAZIONE
		/// Tipo sul db:DATETIME
		/// </summary>
		public NullTypes.DatetimeNT DataValutazione
		{
			get { return _DataValutazione; }
			set {
				if (DataValutazione != value)
				{
					_DataValutazione = value;
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
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(1000)
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
		/// Corrisponde al campo:COD_LIVELLO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodLivello
		{
			get { return _CodLivello; }
			set {
				if (CodLivello != value)
				{
					_CodLivello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PLURI_VALORE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT PluriValore
		{
			get { return _PluriValore; }
			set {
				if (PluriValore != value)
				{
					_PluriValore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:EVAL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT Eval
		{
			get { return _Eval; }
			set {
				if (Eval != value)
				{
					_Eval = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_MANUALE
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagManuale
		{
			get { return _FlagManuale; }
			set {
				if (FlagManuale != value)
				{
					_FlagManuale = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:INPUT_NUMERICO
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT InputNumerico
		{
			get { return _InputNumerico; }
			set {
				if (InputNumerico != value)
				{
					_InputNumerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(20)
		/// </summary>
		public NullTypes.StringNT Misura
		{
			get { return _Misura; }
			set {
				if (Misura != value)
				{
					_Misura = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_DEFINITIVO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT FlagDefinitivo
		{
			get { return _FlagDefinitivo; }
			set {
				if (FlagDefinitivo != value)
				{
					_FlagDefinitivo = value;
					SetDirtyFlag();
				}
			}
		}



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
<VARIANTI_X_PRIORITA>
  <ViewName>vVARIANTI_X_PRIORITA</ViewName>
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
      <ID_VARIANTE>Equal</ID_VARIANTE>
      <ID_PRIORITA>Equal</ID_PRIORITA>
    </Find>
  </Finds>
  <Filters>
    <FiltroDefinitivo>
      <FLAG_DEFINITIVO>Equal</FLAG_DEFINITIVO>
    </FiltroDefinitivo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</VARIANTI_X_PRIORITA>
*/