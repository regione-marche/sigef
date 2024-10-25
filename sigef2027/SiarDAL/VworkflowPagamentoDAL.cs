using System;
using System.ComponentModel;
using System.Data;
using SiarLibrary;

namespace SiarDAL
{

	/// <summary>
	/// Summary description for VworkflowPagamentoDAL
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>


	public class VworkflowPagamentoDAL
	{

		//Operazioni

		//getFromDatareader
		public static VworkflowPagamento GetFromDatareader(DbProvider db)
		{
			VworkflowPagamento VworkflowPagamentoObj = new VworkflowPagamento();
			VworkflowPagamentoObj.CodTipo = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_TIPO"]);
			VworkflowPagamentoObj.CodWorkflow = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_WORKFLOW"]);
			VworkflowPagamentoObj.Ordine = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE"]);
			VworkflowPagamentoObj.Obbligatorio = new SiarLibrary.NullTypes.BoolNT(db.DataReader["OBBLIGATORIO"]);
			VworkflowPagamentoObj.Descrizione = new SiarLibrary.NullTypes.StringNT(db.DataReader["DESCRIZIONE"]);
			VworkflowPagamentoObj.Url = new SiarLibrary.NullTypes.StringNT(db.DataReader["URL"]);
			VworkflowPagamentoObj.TipoPagamento = new SiarLibrary.NullTypes.StringNT(db.DataReader["TIPO_PAGAMENTO"]);
			VworkflowPagamentoObj.CodFase = new SiarLibrary.NullTypes.StringNT(db.DataReader["COD_FASE"]);
			VworkflowPagamentoObj.Fase = new SiarLibrary.NullTypes.StringNT(db.DataReader["FASE"]);
			VworkflowPagamentoObj.OrdineFase = new SiarLibrary.NullTypes.IntNT(db.DataReader["ORDINE_FASE"]);
			VworkflowPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
			VworkflowPagamentoObj.IsDirty = false;
			VworkflowPagamentoObj.IsPersistent = true;
			return VworkflowPagamentoObj;
		}

		//Find Select

		public static VworkflowPagamentoCollection Select(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodWorkflowEqualThis, SiarLibrary.NullTypes.IntNT OrdineEqualThis, 
SiarLibrary.NullTypes.BoolNT ObbligatorioEqualThis, SiarLibrary.NullTypes.StringNT DescrizioneEqualThis, SiarLibrary.NullTypes.StringNT UrlEqualThis, 
SiarLibrary.NullTypes.StringNT TipoPagamentoEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, SiarLibrary.NullTypes.StringNT FaseEqualThis, 
SiarLibrary.NullTypes.IntNT OrdineFaseEqualThis)

		{

			VworkflowPagamentoCollection VworkflowPagamentoCollectionObj = new VworkflowPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zvworkflowpagamentofindselect", new string[] {"CodTipoequalthis", "CodWorkflowequalthis", "Ordineequalthis", 
"Obbligatorioequalthis", "Descrizioneequalthis", "Urlequalthis", 
"TipoPagamentoequalthis", "CodFaseequalthis", "Faseequalthis", 
"OrdineFaseequalthis"}, new string[] {"string", "string", "int", 
"bool", "string", "string", 
"string", "string", "string", 
"int"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodWorkflowequalthis", CodWorkflowEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Ordineequalthis", OrdineEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Obbligatorioequalthis", ObbligatorioEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizioneequalthis", DescrizioneEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Urlequalthis", UrlEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "TipoPagamentoequalthis", TipoPagamentoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Faseequalthis", FaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "OrdineFaseequalthis", OrdineFaseEqualThis);
			VworkflowPagamento VworkflowPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VworkflowPagamentoObj = GetFromDatareader(db);
				VworkflowPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VworkflowPagamentoObj.IsDirty = false;
				VworkflowPagamentoObj.IsPersistent = true;
				VworkflowPagamentoCollectionObj.Add(VworkflowPagamentoObj);
			}
			db.Close();
			return VworkflowPagamentoCollectionObj;
		}

		//Find Find

		public static VworkflowPagamentoCollection Find(DbProvider db, SiarLibrary.NullTypes.StringNT CodTipoEqualThis, SiarLibrary.NullTypes.StringNT CodWorkflowEqualThis, SiarLibrary.NullTypes.StringNT CodFaseEqualThis, 
SiarLibrary.NullTypes.StringNT DescrizioneLikeThis)

		{

			VworkflowPagamentoCollection VworkflowPagamentoCollectionObj = new VworkflowPagamentoCollection();

			IDbCommand findCmd = db.InitCmd("Zvworkflowpagamentofindfind", new string[] {"CodTipoequalthis", "CodWorkflowequalthis", "CodFaseequalthis", 
"Descrizionelikethis"}, new string[] {"string", "string", "string", 
"string"},"");

			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodTipoequalthis", CodTipoEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodWorkflowequalthis", CodWorkflowEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "CodFaseequalthis", CodFaseEqualThis);
			DbProvider.SetCmdParam(findCmd,db.CommandFirstChar + "Descrizionelikethis", DescrizioneLikeThis);
			VworkflowPagamento VworkflowPagamentoObj;
			db.InitDatareader(findCmd);
			while (db.DataReader.Read())
			{
				VworkflowPagamentoObj = GetFromDatareader(db);
				VworkflowPagamentoObj.ObjectState = BaseObject.ObjectStateType.Unchanged;
				VworkflowPagamentoObj.IsDirty = false;
				VworkflowPagamentoObj.IsPersistent = true;
				VworkflowPagamentoCollectionObj.Add(VworkflowPagamentoObj);
			}
			db.Close();
			return VworkflowPagamentoCollectionObj;
		}

	}
}

/*Config
<?xml version="1.0" encoding="utf-16"?>
<vWORKFLOW_PAGAMENTO>
  <ViewName>vWORKFLOW_PAGAMENTO</ViewName>
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
    <Find OrderBy="ORDER BY ORDINE">
      <COD_TIPO>Equal</COD_TIPO>
      <COD_WORKFLOW>Equal</COD_WORKFLOW>
      <COD_FASE>Equal</COD_FASE>
      <DESCRIZIONE>Like</DESCRIZIONE>
    </Find>
  </Finds>
  <Filters>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
  </Filters>
  <externalFields />
  <AddedFkFields />
</vWORKFLOW_PAGAMENTO>
*/