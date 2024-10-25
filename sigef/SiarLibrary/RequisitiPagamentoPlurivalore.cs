using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per RequisitiPagamentoPlurivalore
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IRequisitiPagamentoPlurivaloreProvider
	{
		int Save(RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj);
		int SaveCollection(RequisitiPagamentoPlurivaloreCollection collectionObj);
		int Delete(RequisitiPagamentoPlurivalore RequisitiPagamentoPlurivaloreObj);
		int DeleteCollection(RequisitiPagamentoPlurivaloreCollection collectionObj);
	}
	/// <summary>
	/// Summary description for RequisitiPagamentoPlurivalore
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class RequisitiPagamentoPlurivalore: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdValore;
		private NullTypes.IntNT _IdRequisito;
		private NullTypes.StringNT _Codice;
		private NullTypes.StringNT _Descrizione;
		[NonSerialized] private IRequisitiPagamentoPlurivaloreProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IRequisitiPagamentoPlurivaloreProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public RequisitiPagamentoPlurivalore()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_VALORE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdValore
		{
			get { return _IdValore; }
			set {
				if (IdValore != value)
				{
					_IdValore = value;
					SetDirtyFlag();
				}
			}
		}

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
		/// Corrisponde al campo:CODICE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT Codice
		{
			get { return _Codice; }
			set {
				if (Codice != value)
				{
					_Codice = value;
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
<REQUISITI_PAGAMENTO_PLURIVALORE>
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
    <Find OrderBy="ORDER BY CODICE">
      <ID_VALORE>Equal</ID_VALORE>
      <ID_REQUISITO>Equal</ID_REQUISITO>
      <CODICE>Equal</CODICE>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</REQUISITI_PAGAMENTO_PLURIVALORE>
*/