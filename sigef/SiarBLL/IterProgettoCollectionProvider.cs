using System;
using SiarLibrary;
using SiarLibrary.NullTypes;
using SiarDAL;

namespace SiarBLL
{

	/// <summary>
	/// Summary description for IterProgettoCollectionProvider:IIterProgettoProvider
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]

	public class IterProgettoCollectionProvider : IIterProgettoProvider
	{

		//Definizione dell'oggetto classe DbProvider
		protected DbProvider _dbProviderObj;

		//Definizione della collection di IterProgetto
		protected IterProgettoCollection _CollectionObj;

		//Costruttore 1: non popola la collection
		public IterProgettoCollectionProvider()
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = new IterProgettoCollection(this);
		}

		//Costruttore 2: popola la collection
		public IterProgettoCollectionProvider(IntNT IdprogettoEqualThis, IntNT IdstepEqualThis, StringNT CodesitoEqualThis, 
StringNT CodesitorevisoreEqualThis, IntNT IdbandoEqualThis, StringNT CodfaseEqualThis, 
IntNT IdchecklistEqualThis)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = Find(IdprogettoEqualThis, IdstepEqualThis, CodesitoEqualThis, 
CodesitorevisoreEqualThis, IdbandoEqualThis, CodfaseEqualThis, 
IdchecklistEqualThis);
		}

		//Costruttore3: ha in input iterprogettoCollectionObj - non popola la collection
		public IterProgettoCollectionProvider(IterProgettoCollection obj)
		{
			_dbProviderObj = new DbProvider();
			_CollectionObj = obj;
		}

		//Costruttore4: ha in input il dbprovider - non popola la collection
		public IterProgettoCollectionProvider(DbProvider dbProviderObj)
		{
			_dbProviderObj = dbProviderObj;
			_CollectionObj = new IterProgettoCollection(this);
		}

		//Get e Set
		public IterProgettoCollection CollectionObj
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

		//Save1: registra l'intera collection
		public int SaveCollection()
		{
			return SaveCollection(_CollectionObj);
		}

		//Save2: registra una collection
		public int SaveCollection(IterProgettoCollection collectionObj)
		{
			return IterProgettoDAL.SaveCollection(_dbProviderObj, collectionObj);
		}

		//Save3: registra l'elemento i-esimo della collection
		public int Save(int i)
		{
			return Save(_CollectionObj[i]);
		}

		//Save4: registra un elemento singolo
		public int Save(IterProgetto iterprogettoObj)
		{
			return IterProgettoDAL.Save(_dbProviderObj, iterprogettoObj);
		}

		//delete1: elimina l'intera collection
		public int DeleteCollection()
		{
			return DeleteCollection(_CollectionObj);
		}

		//delete2: elimina una collection
		public int DeleteCollection(IterProgettoCollection collectionObj)
		{
			return IterProgettoDAL.DeleteCollection(_dbProviderObj, collectionObj);
		}

		//delete3: elimina l'elemento i-esimo della collection
		public int Delete(int i)
		{
			return Delete(_CollectionObj[i]);
		}

		//delete4: elimina un elemento singolo
		public int Delete(IterProgetto iterprogettoObj)
		{
			return IterProgettoDAL.Delete(_dbProviderObj, iterprogettoObj);
		}

		//getById
		public IterProgetto GetById(IntNT IdProgettoValue, IntNT IdStepValue)
		{
			IterProgetto IterProgettoTemp = IterProgettoDAL.GetById(_dbProviderObj, IdProgettoValue, IdStepValue);
			if (IterProgettoTemp!=null) IterProgettoTemp.Provider = this;
			return IterProgettoTemp;
		}

		//Get e Set dei campi 'ForeignKey'
		//Select: popola la collection
		public IterProgettoCollection Select(IntNT IdprogettoEqualThis, IntNT IdstepEqualThis, StringNT CodesitoEqualThis, 
DatetimeNT DataEqualThis, StringNT CfoperatoreEqualThis, StringNT CodesitorevisoreEqualThis, 
DatetimeNT DatarevisoreEqualThis, StringNT RevisoreEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = IterProgettoDAL.Select(_dbProviderObj, IdprogettoEqualThis, IdstepEqualThis, CodesitoEqualThis, 
DataEqualThis, CfoperatoreEqualThis, CodesitorevisoreEqualThis, 
DatarevisoreEqualThis, RevisoreEqualThis);
			IterProgettoCollectionTemp.Provider = this;
			return IterProgettoCollectionTemp;
		}

		//Find: popola la collection
		public IterProgettoCollection Find(IntNT IdprogettoEqualThis, IntNT IdstepEqualThis, StringNT CodesitoEqualThis, 
StringNT CodesitorevisoreEqualThis, IntNT IdbandoEqualThis, StringNT CodfaseEqualThis, 
IntNT IdchecklistEqualThis)
		{
			IterProgettoCollection IterProgettoCollectionTemp = IterProgettoDAL.Find(_dbProviderObj, IdprogettoEqualThis, IdstepEqualThis, CodesitoEqualThis, 
CodesitorevisoreEqualThis, IdbandoEqualThis, CodfaseEqualThis, 
IdchecklistEqualThis);
			IterProgettoCollectionTemp.Provider = this;
			return IterProgettoCollectionTemp;
		}

        /// <summary>
        /// funzione che esegue gli step automatici e controlla l'esito generale della checklist
        /// della fase relativa, gli esiti degli altri step sono intesi come gia' salvati su db
        /// </summary>
        /// <param name="IdProgetto"></param>
        /// <param name="IdDomandaPagamento"></param>
        /// <param name="CodFase"></param>
        /// <param name="Operatore"></param>
        /// <returns></returns>
        public string VerificaCheckListDomandaDiAiuto(IntNT IdProgetto, IntNT IdDomandaPagamento, StringNT CodFase, StringNT Operatore)
        {
            try
            {
                System.Data.IDbCommand cmd = DbProviderObj.GetCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SpVerificaCheckListDomandaDiAiuto";
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_PROGETTO", IdProgetto.Value));
                if (IdDomandaPagamento != null) cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_DOMANDA_PAGAMENTO", IdDomandaPagamento.Value));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("COD_FASE", CodFase.Value));
                cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("OPERATORE", Operatore.Value));

                System.Data.SqlClient.SqlParameter p_out = new System.Data.SqlClient.SqlParameter();
                p_out.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p_out);

                int result = DbProviderObj.Execute(cmd);
                DbProviderObj.Close();
                // 1: verificata, altrimenti no
                int esito_checklist;
                if (p_out.Value == null || !int.TryParse(p_out.Value.ToString(), out esito_checklist)) throw new Exception("errore");
                return (esito_checklist == 1 ? "SI" : "NO");
            }
            catch { throw new SiarLibrary.SiarException(SiarLibrary.TextErrorCodes.GenericoConLink); }
        }
	}
}
/*Config
<?xml version="1.0" encoding="utf-16"?>
<ITER_PROGETTO>
  <ViewName>vITER_PROGETTO</ViewName>
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
      <ID_PROGETTO>Equal</ID_PROGETTO>
      <ID_STEP>Equal</ID_STEP>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
      <ID_BANDO>Equal</ID_BANDO>
      <COD_FASE>Equal</COD_FASE>
      <ID_CHECK_LIST>Equal</ID_CHECK_LIST>
    </Find>
  </Finds>
  <Filters>
    <FiltroEsito>
      <COD_ESITO>Equal</COD_ESITO>
      <COD_ESITO_REVISORE>Equal</COD_ESITO_REVISORE>
    </FiltroEsito>
    <FiltroEsitoPositivo>
      <ESITO_POSITIVO_ISTRUTTORE>Equal</ESITO_POSITIVO_ISTRUTTORE>
      <ESITO_POSITIVO_REVISORE>Equal</ESITO_POSITIVO_REVISORE>
    </FiltroEsitoPositivo>
    <FiltroNonInRevisione>
      <COD_ESITO_REVISORE>IsNull</COD_ESITO_REVISORE>
    </FiltroNonInRevisione>
    <FiltroAutomatico>
      <AUTOMATICO>Equal</AUTOMATICO>
    </FiltroAutomatico>
    <FiltroObbligatorio>
      <OBBLIGATORIO>Equal</OBBLIGATORIO>
    </FiltroObbligatorio>
    <FiltroMisura>
      <MISURA>Equal</MISURA>
    </FiltroMisura>
  </Filters>
  <externalFields />
  <AddedFkFields />
</ITER_PROGETTO>
*/