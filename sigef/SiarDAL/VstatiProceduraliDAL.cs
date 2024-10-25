using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VstatiProceduraliDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VstatiProceduraliDAL
	{

		//Operazioni

		//getFromDatareader
		public static VstatiProcedurali GetFromDatareader(DbProvider db)
		{
			VstatiProcedurali VstatiProceduraliObj = new VstatiProcedurali();
			VstatiProceduraliObj.CodStato = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_STATO"]);
			VstatiProceduraliObj.Stato = new SiarLibrary.NullTypes.StringNT(db.DataReader["STATO"]);
			VstatiProceduraliObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			VstatiProceduraliObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			VstatiProceduraliObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
			VstatiProceduraliObj.OrdineStato = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_STATO"]);
			VstatiProceduraliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VstatiProceduraliObj.IsDirty = false;
			VstatiProceduraliObj.IsPersistent = true;
			return VstatiProceduraliObj;
		}

		//Find Select

		public static VstatiProceduraliCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.StringNT StatoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, 
SiarLibrary.NullTypes.StringNT FaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineFaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineStatoEqualThis)

		{

			VstatiProceduraliCollection VstatiProceduraliCollectionObj = new VstatiProceduraliCollection();

			IDbCommand findCmd = db.InitCmd("Zvstatiproceduralifindselect", new string[] {"CodStatoequalthis", "Statoequalthis", "CodFaseequalthis", 
"Faseequalthis", "OrdineFaseequalthis", "OrdineStatoequalthis"}, new string[] {"string", "string", "string", 
"string", "int", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Statoequalthis", StatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Faseequalthis", FaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFaseequalthis", OrdineFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineStatoequalthis", OrdineStatoEqualThis);
			VstatiProcedurali VstatiProceduraliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VstatiProceduraliObj = GetFromDatareader(db);
				VstatiProceduraliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VstatiProceduraliObj.IsDirty = false;
				VstatiProceduraliObj.IsPersistent = true;
				VstatiProceduraliCollectionObj.Add(VstatiProceduraliObj);
			}
			db.Close();
			return VstatiProceduraliCollectionObj;
		}

		//Find Find

		public static VstatiProceduraliCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodStatoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.IntNT OrdineFaseGreaterThanThis)

		{

			VstatiProceduraliCollection VstatiProceduraliCollectionObj = new VstatiProceduraliCollection();

			IDbCommand findCmd = db.InitCmd("Zvstatiproceduralifindfind", new string[] {"CodStatoequalthis", "CodFaseequalthis", "OrdineFasegreaterthanthis"}, new string[] {"string", "string", "int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodStatoequalthis", CodStatoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFasegreaterthanthis", OrdineFaseGreaterThanThis);
			VstatiProcedurali VstatiProceduraliObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VstatiProceduraliObj = GetFromDatareader(db);
				VstatiProceduraliObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VstatiProceduraliObj.IsDirty = false;
				VstatiProceduraliObj.IsPersistent = true;
				VstatiProceduraliCollectionObj.Add(VstatiProceduraliObj);
			}
			db.Close();
			return VstatiProceduraliCollectionObj;
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