using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per RequisitiPagamento
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRequisitiPagamentoProvider
	{
		int Save(RequisitiPagamento RequisitiPagamentoObj);
		int SaveCollection(RequisitiPagamentoCollection collectionObj);
		int Delete(RequisitiPagamento RequisitiPagamentoObj);
		int DeleteCollection(RequisitiPagamentoCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RequisitiPagamento
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class RequisitiPagamento: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdRequisito;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.BoolNT _Plurivalore;
		private NullTypes.BoolNT _Numerico;
		private NullTypes.BoolNT _Datetime;
		private NullTypes.BoolNT _TestoSemplice;
		private NullTypes.BoolNT _TestoArea;
		private NullTypes.StringNT _Url;
		private NullTypes.StringNT _QueryEval;
		private NullTypes.StringNT _QueryInsert;
		private NullTypes.StringNT _Misura;
		[NonSerialized] private IRequisitiPagamentoProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRequisitiPagamentoProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RequisitiPagamento()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_REQUISITO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdRequisito
		{
			get { return _IdRequisito; }
			set {
				if (IdRequisito != value)
				{
					_IdRequisito = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(500)
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
		/// Corrisponde al campo:PLURIVALORE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Plurivalore
		{
			get { return _Plurivalore; }
			set {
				if (Plurivalore != value)
				{
					_Plurivalore = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:NUMERICO
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Numerico
		{
			get { return _Numerico; }
			set {
				if (Numerico != value)
				{
					_Numerico = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DATETIME
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT Datetime
		{
			get { return _Datetime; }
			set {
				if (Datetime != value)
				{
					_Datetime = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_SEMPLICE
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT TestoSemplice
		{
			get { return _TestoSemplice; }
			set {
				if (TestoSemplice != value)
				{
					_TestoSemplice = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:TESTO_AREA
		/// Tipo sul db:BIT
		/// Default:((0))
		/// </summary>
		public NullTypes.BoolNT TestoArea
		{
			get { return _TestoArea; }
			set {
				if (TestoArea != value)
				{
					_TestoArea = value;
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
			set {
				if (Url != value)
				{
					_Url = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_EVAL
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QueryEval
		{
			get { return _QueryEval; }
			set {
				if (QueryEval != value)
				{
					_QueryEval = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:QUERY_INSERT
		/// Tipo sul db:VARCHAR(3000)
		/// </summary>
		public NullTypes.StringNT QueryInsert
		{
			get { return _QueryInsert; }
			set {
				if (QueryInsert != value)
				{
					_QueryInsert = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MISURA
		/// Tipo sul db:VARCHAR(10)
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
<REQUISITI_PAGAMENTO>
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
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <MISURA>Like</MISURA>
    </Find>
  </Finds>
  <Filters>
    <FiltroTipo>
      <PLURIVALORE>Equal</PLURIVALORE>
      <NUMERICO>Equal</NUMERICO>
      <DATETIME>Equal</DATETIME>
      <TESTO_SEMPLICE>Equal</TESTO_SEMPLICE>
      <TESTO_AREA>Equal</TESTO_AREA>
      <URL>IsNull</URL>
    </FiltroTipo>
  </Filters>
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO>
*/