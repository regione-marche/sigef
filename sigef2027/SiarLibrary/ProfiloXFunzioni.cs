using System;
using System.ComponentModel;

namespace SiarLibrary
{

	// interfaccia provider per ProfiloXFunzioni
	// Interfaccia Autogenerata
	// Inserire eventuali operazioni aggiuntive
	public interface IProfiloXFunzioniProvider
	{
		int Save(ProfiloXFunzioni ProfiloXFunzioniObj);
		int SaveCollection(ProfiloXFunzioniCollection collectionObj);
		int Delete(ProfiloXFunzioni ProfiloXFunzioniObj);
		int DeleteCollection(ProfiloXFunzioniCollection collectionObj);
	}
	/// <summary>
	/// Summary description for ProfiloXFunzioni
	/// Class Autogenerata
	/// Inserire eventuali operazioni aggiuntive
	/// </summary>

	[Serializable]
	[System.Xml.Serialization.XmlType(Namespace = "")]

	public class ProfiloXFunzioni: BaseObject
	{

		//Definizione dei campi 'base'
		private NullTypes.IntNT _IdProfilo;
		private NullTypes.StringNT _Descrizione;
		private NullTypes.StringNT _CodTipoEnte;
		private NullTypes.IntNT _Ordine;
		private NullTypes.IntNT _CodFunzione;
		private NullTypes.BoolNT _Modifica;
		private NullTypes.StringNT _Funzionalita;
		private NullTypes.BoolNT _FlagMenu;
		private NullTypes.StringNT _DescMenu;
		private NullTypes.IntNT _Livello;
		private NullTypes.IntNT _Padre;
		private NullTypes.StringNT _Link;
		private NullTypes.IntNT _OrdineFunzionalita;
		private NullTypes.BoolNT _AbilitaInserimentoUtenti;
		[NonSerialized] private IProfiloXFunzioniProvider _provider;
		[System.Xml.Serialization.XmlIgnore] public IProfiloXFunzioniProvider Provider
		{
			get {return _provider;}
			set {_provider = value;}
		}


		//Costruttore
		public ProfiloXFunzioni()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Get e Set dei campi 'base'
		/// <summary>
		/// Corrisponde al campo:ID_PROFILO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT IdProfilo
		{
			get { return _IdProfilo; }
			set {
				if (IdProfilo != value)
				{
					_IdProfilo = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESCRIZIONE
		/// Tipo sul db:VARCHAR(255)
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
		/// Corrisponde al campo:COD_TIPO_ENTE
		/// Tipo sul db:VARCHAR(10)
		/// </summary>
		public NullTypes.StringNT CodTipoEnte
		{
			get { return _CodTipoEnte; }
			set {
				if (CodTipoEnte != value)
				{
					_CodTipoEnte = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Ordine
		{
			get { return _Ordine; }
			set {
				if (Ordine != value)
				{
					_Ordine = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:COD_FUNZIONE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT CodFunzione
		{
			get { return _CodFunzione; }
			set {
				if (CodFunzione != value)
				{
					_CodFunzione = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:MODIFICA
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT Modifica
		{
			get { return _Modifica; }
			set {
				if (Modifica != value)
				{
					_Modifica = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FUNZIONALITA
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Funzionalita
		{
			get { return _Funzionalita; }
			set {
				if (Funzionalita != value)
				{
					_Funzionalita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:FLAG_MENU
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT FlagMenu
		{
			get { return _FlagMenu; }
			set {
				if (FlagMenu != value)
				{
					_FlagMenu = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:DESC_MENU
		/// Tipo sul db:VARCHAR(50)
		/// </summary>
		public NullTypes.StringNT DescMenu
		{
			get { return _DescMenu; }
			set {
				if (DescMenu != value)
				{
					_DescMenu = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LIVELLO
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Livello
		{
			get { return _Livello; }
			set {
				if (Livello != value)
				{
					_Livello = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:PADRE
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT Padre
		{
			get { return _Padre; }
			set {
				if (Padre != value)
				{
					_Padre = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:LINK
		/// Tipo sul db:VARCHAR(255)
		/// </summary>
		public NullTypes.StringNT Link
		{
			get { return _Link; }
			set {
				if (Link != value)
				{
					_Link = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ORDINE_FUNZIONALITA
		/// Tipo sul db:INT
		/// </summary>
		public NullTypes.IntNT OrdineFunzionalita
		{
			get { return _OrdineFunzionalita; }
			set {
				if (OrdineFunzionalita != value)
				{
					_OrdineFunzionalita = value;
					SetDirtyFlag();
				}
			}
		}

		/// <summary>
		/// Corrisponde al campo:ABILITA_INSERIMENTO_UTENTI
		/// Tipo sul db:BIT
		/// </summary>
		public NullTypes.BoolNT AbilitaInserimentoUtenti
		{
			get { return _AbilitaInserimentoUtenti; }
			set {
				if (AbilitaInserimentoUtenti != value)
				{
					_AbilitaInserimentoUtenti = value;
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
<PROFILO_X_FUNZIONI>
  <ViewName>vPROFILO_X_FUNZIONI</ViewName>
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
    <Find>
      <ID_PROFILO>Equal</ID_PROFILO>
      <COD_FUNZIONE>Equal</COD_FUNZIONE>
      <FLAG_MENU>Equal</FLAG_MENU>
      <DESC_MENU>Equal</DESC_MENU>
      <LIVELLO>Equal</LIVELLO>
      <PADRE>Equal</PADRE>
      <ORDINE>Equal</ORDINE>
      <COD_TIPO_ENTE>Equal</COD_TIPO_ENTE>
    </Find>
  </Finds>
  <Filters>
    <FiltroModifica>
      <MODIFICA>Equal</MODIFICA>
    </FiltroModifica>
  </Filters>
  <externalFields />
  <AddedFkFields />
</PROFILO_X_FUNZIONI>
*/