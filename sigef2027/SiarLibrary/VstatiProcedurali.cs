using System;
using System.ComponentModel;

namespace SiarLibrary
{

	/// <summary>
	/// Summary description for VstatiProcedurali
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class VstatiProcedurali: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.StringNT _CodStato;
		private NullTypes.StringNT _Stato;
		private NullTypes.StringNT _CodFase;
		private NullTypes.StringNT _Fase;
		private NullTypes.IntNT _OrdineFase;
		private NullTypes.IntNT _OrdineStato;


		//Costruttore
		public VstatiProcedurali()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:COD_STATO
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodStato
		{
			get { return _CodStato; }
			set {
				if (CodStato != value)
				{
					_CodStato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:STATO
		/// Tipo sul db:VARCHAR(80)
		/// </summary>
		public NullTypes.StringNT Stato
		{
			get { return _Stato; }
			set {
				if (Stato != value)
				{
					_Stato = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FASE
		/// Tipo sul db:CHAR(1)
		/// </summary>
		public NullTypes.StringNT CodFase
		{
			get { return _CodFase; }
			set {
				if (CodFase != value)
				{
					_CodFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FASE
		/// Tipo sul db:VARCHAR(100)
		/// </summary>
		public NullTypes.StringNT Fase
		{
			get { return _Fase; }
			set {
				if (Fase != value)
				{
					_Fase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FASE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFase
		{
			get { return _OrdineFase; }
			set {
				if (OrdineFase != value)
				{
					_OrdineFase = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_STATO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineStato
		{
			get { return _OrdineStato; }
			set {
				if (OrdineStato != value)
				{
					_OrdineStato = value;
					SetDirtyFlag();
				}
			}
		}




	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<vSTATI_PROCEDURALI>
  <ViewName>vSTATI_PROCEDURALI</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE_FASE, ORDINE_STATO">
      <COD_STATO>Equal</COD_STATO>
      <COD_FASE>Equal</COD_FASE>
      <ORDINE_FASE>GreaterThan</ORDINE_FASE>
    </Find>
  </Finds>
  <Filters>
    <FiltroOrdine>
      <ORDINE_FASE>Equal</ORDINE_FASE>
      <ORDINE_STATO>Equal</ORDINE_STATO>
      <ORDINE_FASE>GreaterThan</ORDINE_FASE>
      <ORDINE_STATO>GreaterThan</ORDINE_STATO>
      <ORDINE_FASE>LessThan</ORDINE_FASE>
      <ORDINE_STATO>LessThan</ORDINE_STATO>
    </FiltroOrdine>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vSTATI_PROCEDURALI>
*/