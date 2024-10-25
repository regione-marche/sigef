using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per QuadroDomanda
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IQuadroDomandaProvider
	{
		int Save(QuadroDomanda QuadroDomandaObj);
		int SaveCollection(QuadroDomandaCollection collectionObj);
		int Delete(QuadroDomanda QuadroDomandaObj);
		int DeleteCollection(QuadroDomandaCollection collectionObj);
	}
	/// <summary>
	/// Summary description for QuadroDomanda
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class QuadroDomanda: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdQuadro;
		private NullTypes.StringNT _Denominazione;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _MetodoReport;
		[NonSerialized] private IQuadroDomandaProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IQuadroDomandaProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public QuadroDomanda()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_QUADRO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdQuadro
		{
			get { return _IdQuadro; }
			set {
				if (IdQuadro != value)
				{
					_IdQuadro = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DENOMINAZIONE
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT Denominazione
		{
			get { return _Denominazione; }
			set {
				if (Denominazione != value)
				{
					_Denominazione = value;
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
		/// Corrisponde al campo:METODO_REPORT
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT MetodoReport
		{
			get { return _MetodoReport; }
			set {
				if (MetodoReport != value)
				{
					_MetodoReport = value;
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
<QUADRO_DOMANDA>
  <ViewName>
  </ViewName>
  <chkAutoGenKey>False</chkAutoGenKey>
  <chkDataModifica>True</chkDataModifica>
  <chkCase>False</chkCase>
  <chkCache>False</chkCache>
  <PLName>SiarPLL</PLName>
  <DALName>SiarDAL</DALName>
  <BLLName>SiarBLL</BLLName>
  <TypeNameSpaceName>SiarLibrary</TypeNameSpaceName>
  <Finds>
    <Find>
      <ID_QUADRO>Equal</ID_QUADRO>
    </Find>
  </Finds>
  <Filters />
  <externalFields />
  <AddedFkFields />
</QUADRO_DOMANDA>
*/