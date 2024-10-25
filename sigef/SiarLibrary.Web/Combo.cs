using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiarLibrary.NullTypes;

namespace SiarLibrary.Web
{
    #region base

    [System.Web.UI.ValidationProperty("SelectedValue")]
    public class ComboBase : System.Web.UI.WebControls.ListControl
    {
        public ComboBase()
            : base()
        {
            base.EnableViewState = false;
        }

        public override bool EnableViewState
        {
            get { return false; }
        }

        private string _dataColumn;
        [System.ComponentModel.DefaultValue("")]
        public string DataColumn
        {
            get { return _dataColumn; }
            set { _dataColumn = value; }
        }

        private string _nomeCampo;
        [System.ComponentModel.DefaultValue("")]
        public string NomeCampo
        {
            get { return _nomeCampo; }
            set { _nomeCampo = value; }
        }

        private bool _obbligatorio = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool Obbligatorio
        {
            get { return _obbligatorio; }
            set { _obbligatorio = value; }
        }

        private bool _bloccato = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool Bloccato
        {
            get { return _bloccato; }
            set { _bloccato = value; }
        }

        protected bool _noBlankItem;
        [System.ComponentModel.DefaultValue(false)]
        public bool NoBlankItem
        {
            get { return _noBlankItem; }
            set { _noBlankItem = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_obbligatorio && Enabled)
            {
                System.Web.UI.WebControls.RequiredFieldValidator rfv = new System.Web.UI.WebControls.RequiredFieldValidator();
                rfv.EnableViewState = false;
                rfv.ControlToValidate = this.ID;
                rfv.ErrorMessage = _nomeCampo + " obbligatorio";
                rfv.ID = this.ID + "_req";
                rfv.Text = "*";
                base.Controls.Add(rfv);
            }
        }

        private bool _selectionCleaned = false;
        public override void ClearSelection()
        {
            _selectionCleaned = true;
            base.ClearSelection();
        }

        private string _selectedValue;
        public override string SelectedValue
        {
            get
            {
                if (_selectionCleaned) return null;
                string s = _selectedValue;
                if (string.IsNullOrEmpty(s) && SelectedItem != null) s = SelectedItem.Value;
                if (string.IsNullOrEmpty(s)) s = base.SelectedValue;
                if (Page != null && string.IsNullOrEmpty(s)) s = Page.Request.Form[UniqueID];
                return (s == "" ? null : s);
            }
            set
            {
                _selectedValue = value;
                foreach (ListItem li in Items)
                    li.Selected = li.Value == value;
            }
        }
        //void _select()
        //{
        //    ListItem li = Items.FindByValue(_valore);
        //    if (li != null) li.Selected = true;
        //}

        protected virtual object[] BindSelectedValue()
        {
            throw new NotImplementedException();
        }

        //private string _valore;
        //protected bool _isDataBinding = false,             isBinded = false;

        //public override void DataBind()
        //{
        //    //_isDataBinding = true;
        //    base.DataBind();
        //    if (!_noBlankItem) Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));
        //}

        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {
            int itemNumber = this.Items.Count;
            if (itemNumber > 0)
            {
                for (int i = 0; i < itemNumber; i++)
                {
                    System.Web.UI.WebControls.ListItem elemento = this.Items[i];
                    writer.WriteBeginTag("option");
                    if (elemento.Selected)
                    {
                        writer.WriteAttribute("selected", "selected", false);
                    }
                    elemento.Attributes.Render(writer);

                    writer.WriteAttribute("value", elemento.Value, true);
                    writer.Write('>');
                    if (Page != null) Page.Server.HtmlEncode(elemento.Text, writer);
                    else HttpContext.Current.Server.HtmlEncode(elemento.Text, writer);
                    writer.WriteEndTag("option");
                    writer.WriteLine();
                }
            }
        }

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            if (this.Page != null)
            {
                this.Page.VerifyRenderingInServerForm(this);
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            string testoOC = "";
            if (this.AutoPostBack && (this.Page != null))
            {
                testoOC += this.Page.ClientScript.GetPostBackEventReference(this, "");
                string text2 = base.Attributes["onchange"];
                if (text2 != null)
                {
                    testoOC = text2 + testoOC;
                    base.Attributes.Remove("onchange");
                }
            }

            if (testoOC != "")
            {
                writer.AddAttribute(System.Web.UI.HtmlTextWriterAttribute.Onchange, testoOC);
                writer.AddAttribute("language", "javascript");
            }
            base.AddAttributesToRender(writer);
        }

        /* protected override void Render(System.Web.UI.HtmlTextWriter writer)
         {
             if (Bloccato) Enabled = false;

 #if(DEBUG)
             if ((Site != null) && (Site.DesignMode))
             {
                 writer.Write("<SELECT disabled><OPTION selected>Combo base</OPTION></SELECT>");
                 //return;
             }
 #endif
             base.Render(writer);
             foreach (System.Web.UI.Control c in Controls)
                 c.RenderControl(writer);
             //}
         }*/


        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
#if(DEBUG)
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("<SELECT disabled><OPTION selected>" + this.GetType().ToString().Replace("SiarLibrary.Web.", "") + "</OPTION></SELECT>");
                return;
            }
#endif
            base.Render(writer);
            foreach (System.Web.UI.Control c in Controls)
                c.RenderControl(writer);
        }
    }

    public class Combo : ComboBase
    {
        protected string selezionato = null;
        protected override void OnDataBinding(EventArgs e)
        {
            bool annullaSelezione = false;
            if (DataSource == null) DataSource = DataFill();
            SiarLibrary.CustomCollection cc = (SiarLibrary.CustomCollection)DataSource;
            if (cc != null && cc.Count > 0)
            {
                if (DataColumn != "" && DataColumn != null)
                {
                    object obj = null;
                    if (NamingContainer is DataGridItem)
                    {
                        obj = ((CustomCollection)((SiarLibrary.Web.DataGrid)NamingContainer.Parent.Parent).DataSource)[((DataGridItem)NamingContainer).ItemIndex];
                    }
                    else obj = ((SiarLibrary.Web.Page)Page).DataSource;
                    if (obj != null)
                    {
                        System.Type t = obj.GetType();
                        object o = t.GetProperty(DataColumn).GetValue(obj, null);
                        if (o != null) selezionato = o.ToString();
                        else annullaSelezione = true;
                    }
                }
                string valore_selezionato = SelectedValue; //memorizzo il valore per risparmio istruzioni eseguite
                foreach (object o in cc)
                {
                    System.Type tipo = o.GetType();
                    ListItem li = new ListItem(tipo.GetProperty(DataTextField).GetValue(o, null).ToString(), tipo.GetProperty(DataValueField).GetValue(o, null).ToString());
                    if (!annullaSelezione)
                    {
                        if (valore_selezionato != null && li.Value == valore_selezionato) li.Selected = true;
                        if (selezionato != null && li.Value == selezionato) li.Selected = true;
                    }
                    Items.Add(li);
                }
                if (!NoBlankItem) Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));
            }
            else
            {
                Items.Add(new ListItem("Nessun elemento presente.", "", false));
                NoBlankItem = true;
            }
            //if (annullaSelezione)
            //{
            //    ClearSelection();
            //    SelectedValue = null;
            //}
        }
        protected virtual SiarLibrary.CustomCollection DataFill()
        {
            return null;
        }
    }

    public class ComboSql : ComboBase
    {
        protected System.Data.IDbCommand cmd;
        protected SiarLibrary.DbProvider db;
        public SiarLibrary.DbProvider DbProvider { set { db = value; } }
        protected ListItem DefaultNoRecordValue;
        private string _commandText;
        [System.ComponentModel.DefaultValue("")]
        public string CommandText
        {
            set { _commandText = value; }
            get { return _commandText; }
        }
        /// <summary>
        /// valore opzionale della classe aggiunto come attributo dell'item
        /// </summary>
        private string _optionalValue;
        [System.ComponentModel.DefaultValue("")]
        public string OptionalValue
        {
            set { _optionalValue = value; }
            get { return _optionalValue; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            string selezionato = null;
            bool annullaSelezione = false;
            if (DataColumn != "" && DataColumn != null)
            {
                object obj = null;
                if (NamingContainer is DataGridItem)
                {
                    obj = ((CustomCollection)((SiarLibrary.Web.DataGrid)NamingContainer.Parent.Parent).DataSource)[
                        ((DataGridItem)NamingContainer).ItemIndex];
                }
                else obj = ((SiarLibrary.Web.Page)Page).DataSource;
                if (obj != null)
                {
                    System.Type t = obj.GetType();
                    object o = t.GetProperty(DataColumn).GetValue(obj, null);
                    if (o != null) selezionato = o.ToString();
                    else annullaSelezione = true;
                }
            }

            if (db == null) db = new DbProvider();
            cmd = db.GetCommand();
            cmd.CommandText = _commandText;
            db.InitDatareader(cmd);
            string valore_selezionato = SelectedValue; //memorizzo il valore per risparmio istruzioni eseguite
            while (db.DataReader.Read())
            {
                ListItem li = new ListItem(db.DataReader[DataTextField].ToString(), db.DataReader[DataValueField].ToString());
                if (!annullaSelezione)
                {
                    if (valore_selezionato != null && li.Value == valore_selezionato) li.Selected = true;
                    if (selezionato != null && li.Value == selezionato) li.Selected = true;
                }
                if (!string.IsNullOrEmpty(_optionalValue))
                    li.Attributes.Add("optvalue", new SiarLibrary.NullTypes.StringNT(db.DataReader[_optionalValue]));
                Items.Add(li);
            }
            db.Close();

            if (Items.Count == 0)
            {
                Items.Clear();
                if (DefaultNoRecordValue == null) DefaultNoRecordValue = new ListItem("Nessun elemento presente.", "", false);
                Items.Add(DefaultNoRecordValue);
                NoBlankItem = true;
            }
            else
            {
                if (!NoBlankItem) Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));
            }
        }
    }

    public class ComboInteger : ComboBase
    {
        private int _initValue = 0;
        public int InitValue
        {
            set { _initValue = value; }
        }
        private int _endValue = 0;
        public int EndValue
        {
            set { _endValue = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            string selezionato = null;
            bool annullaSelezione = false;
            if (DataColumn != "" && DataColumn != null)
            {
                object obj = null;
                if (NamingContainer is DataGridItem)
                {
                    obj = ((CustomCollection)((SiarLibrary.Web.DataGrid)NamingContainer.Parent.Parent).DataSource)[
                        ((DataGridItem)NamingContainer).ItemIndex];
                }
                else obj = ((SiarLibrary.Web.Page)Page).DataSource;
                if (obj != null)
                {
                    System.Type t = obj.GetType();
                    object o = t.GetProperty(DataColumn).GetValue(obj, null);
                    if (o != null) selezionato = o.ToString();
                    else annullaSelezione = true;
                }
            }
            string valore_selezionato = SelectedValue; //memorizzo il valore per risparmio istruzioni eseguite
            for (int i = _initValue; i <= _endValue; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                if (!annullaSelezione)
                {
                    if (valore_selezionato != null && li.Value == valore_selezionato) li.Selected = true;
                    if (selezionato != null && li.Value == selezionato) li.Selected = true;
                }
                Items.Add(li);
            }
            if (Items.Count == 0)
            {
                Items.Clear();
                Items.Add(new ListItem("Nessun elemento presente.", "", false));
                NoBlankItem = true;
            }
            else
            {
                if (!NoBlankItem) Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));
            }
        }

#if(DEBUG)
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("<SELECT disabled><OPTION selected>ComboInteger</OPTION></SELECT>");
                return;
            }
            base.Render(writer);
        }
#endif

    }

    #endregion

    #region combo

    public class ComboFunzionalita : Combo
    {
        [System.ComponentModel.DefaultValue("Descrizione")]
        public override string DataTextField
        {
            get
            {
                return "Descrizione";
            }
        }

        [System.ComponentModel.DefaultValue("CodFunzione")]
        public override string DataValueField
        {
            get
            {
                return "CodFunzione";
            }
        }

        protected override CustomCollection DataFill()
        {
            SiarBLL.FunzionalitaCollectionProvider p = new SiarBLL.FunzionalitaCollectionProvider();
            //funzionalità di primo livello
            FunzionalitaCollection lev0 = p.Find(null, null, 0, null, null, true);
            FunzionalitaCollection results = new FunzionalitaCollection();
            foreach (Funzionalita f in lev0)
            {
                orderFunzionalita(f, ref results);
            }
            return (CustomCollection)results;
            //return (CustomCollection)new SiarBLL.FunzionalitaCollectionProvider().Find(null, null, null, null, null, true);
        }

        private void orderFunzionalita(Funzionalita f, ref FunzionalitaCollection results)
        {
            results.Add(f);
            FunzionalitaCollection fc = getChildes(f);
            if (fc.Count > 0)
            {
                foreach (Funzionalita f1 in fc)
                {
                    // solo le Funzionalità con livello sotto a 3 possono diventare padri
                    if (f1.Livello < 3)
                    {
                        orderFunzionalita(f1, ref results);
                    }
                }
            }
        }

        private FunzionalitaCollection getChildes(Funzionalita f)
        {
            FunzionalitaCollection fc = new SiarBLL.FunzionalitaCollectionProvider().Find(null, null, null, f.CodFunzione, null, true);
            foreach (Funzionalita appo in fc)
            {
                if (appo.Livello > 0)
                {
                    string l = "---";
                    for (int i = 1; i < appo.Livello; i++)
                    {
                        l = l + l;
                    }

                    appo.Descrizione = l + " " + appo.Descrizione;
                }
            }
            return fc;
        }


#if(DEBUG)
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("<SELECT disabled><OPTION selected>Funzionalità</OPTION></SELECT>");
                return;
            }
            base.Render(writer);
        }

#endif
    }

    public class ComboCheckList : Combo
    {
        private bool _template;
        public bool Template
        {
            set { _template = value; }
        }
        [System.ComponentModel.DefaultValue("Descrizione")]
        public override string DataTextField
        {
            get
            {
                return "Descrizione";
            }
        }

        [System.ComponentModel.DefaultValue("IdCheckList")]
        public override string DataValueField
        {
            get
            {
                return "IdCheckList";
            }
        }

        protected override CustomCollection DataFill()
        {
            SiarLibrary.CheckListCollection chcoll = new SiarBLL.CheckListCollectionProvider().Find(null, _template);
            return (CustomCollection)chcoll;
        }
#if(DEBUG)
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("<SELECT disabled><OPTION selected>CheckList</OPTION></SELECT>");
                return;
            }
            base.Render(writer);
        }

#endif
    }

    public class ComboUtenti : Combo
    {
        private NullTypes.IntNT _idProfilo;
        public NullTypes.IntNT IdProfilo
        {
            set { _idProfilo = value; }
        }
        private string _codEnte;
        public string CodEnte
        {
            set { _codEnte = value; }
        }
        private string _provinciaEqualThis;
        public string ProvinciaEqualThis
        {
            set { _provinciaEqualThis = value; }
        }
        private bool _provinciaIsNull = false;
        public bool ProvinciaIsNull
        {
            set { _provinciaIsNull = value; }
        }
        private string _provinciaNotEqualThis;
        public string ProvinciaNotEqualThis
        {
            set { _provinciaNotEqualThis = value; }
        }
        [System.ComponentModel.DefaultValue("Nominativo")]
        public override string DataTextField
        {
            get
            {
                return "Nominativo";
            }
        }

        [System.ComponentModel.DefaultValue("CfUtente")]
        public override string DataValueField
        {
            get
            {
                return "CfUtente";
            }
        }

        protected override CustomCollection DataFill()
        {
            UtentiCollection utenti_totali = new SiarBLL.UtentiCollectionProvider().Find(null, null, null, _codEnte, _idProfilo, null, true);
            UtentiCollection utenti_finali = new UtentiCollection();
            if (_provinciaEqualThis != null)
                utenti_finali.AddCollection(utenti_totali.FiltroProvincia(_provinciaEqualThis, null, null));
            if (_provinciaIsNull)
                utenti_finali.AddCollection(utenti_totali.FiltroProvincia(null, _provinciaIsNull, null));
            if (_provinciaNotEqualThis != null)
                utenti_finali.AddCollection(utenti_totali.FiltroProvincia(null, null, _provinciaNotEqualThis));
            return (CustomCollection)(utenti_finali.Count > 0 ? utenti_finali : utenti_totali);
        }
    }

    public class ComboZOBMisura : Combo
    {
        private int _idProgrammazione;
        public int IdProgrammazione
        {
            get { return _idProgrammazione; }
            set { _idProgrammazione = value; }
        }

        public override string DataTextField
        {
            get
            {
                return "Descrizione";
            }
        }

        public override string DataValueField
        {
            get
            {
                return "Id";
            }
        }

        protected override CustomCollection DataFill()
        {
            return new SiarBLL.ZobMisuraCollectionProvider().Find(_idProgrammazione, null);
        }
    }

    #endregion

    #region combosql

    public class ComboTipoEnte : ComboSql
    {
        protected override void OnInit(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_ENTE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO_ENTE";
            base.OnInit(e);
        }
    }

    public class ComboDefinizioneAtto : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM TIPO_DEFINIZIONE_ATTO WHERE ATTIVO=1";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboRuolo : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_RUOLO AS CODICE, CASE WHEN POTERE_DI_FIRMA = 1 THEN DESCRIZIONE +' | Potere di firma: si' ELSE DESCRIZIONE +' | Potere di firma: no' END AS DESCRIZIONE FROM RUOLO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboOrganoIstituzionale : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM ORGANO_ISTITUZIONALE WHERE ATTIVO=1";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoAtto : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM TIPO_ATTO WHERE ATTIVO=1";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboRegistriAtto : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT VALORE=CODICE+CASE WHEN OPEN_ACT=1 THEN '|'+CONVERT(CHAR(10),DATA_AVVIO_OPEN_ACT,103) ELSE '' END,TESTO=CODICE+ ' - ' + DESCRIZIONE+CASE WHEN ATTIVO=0 THEN ' (non attivo)' ELSE '' END FROM ATTI_REGISTRI ORDER BY ORDINE";
            DataTextField = "TESTO";
            DataValueField = "VALORE";
            base.OnDataBinding(e);
        }
    }

    public class ComboFasiProcedurali : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_FASE,DESCRIZIONE FROM FASI_PROCEDURALI ORDER BY ORDINE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_FASE";
            base.OnDataBinding(e);
        }
    }

    public class ComboFiltroChecklistVoce : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID_FILTRO, DESCRIZIONE FROM FILTRO_CHECKLIST_VOCE ORDER BY ORDINE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_FILTRO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoChecklist : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID_TIPO, DESCRIZIONE FROM TIPO_CHECKLIST";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_TIPO";
            base.OnDataBinding(e);
        }
    }

    public class ComboFiltroVociChecklist : ComboSql

    {

        protected override void OnDataBinding(EventArgs e)

        {

            CommandText = "SELECT ID_FILTRO, DESCRIZIONE FROM VFILTRO_CHECKLIST_VOCE ORDER BY ORDINE, DESCRIZIONE";

            DataTextField = "DESCRIZIONE";

            DataValueField = "ID_FILTRO";

            base.OnDataBinding(e);

        }

    }

    public class ComboStatoProgetto : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT S.COD_STATO,S.DESCRIZIONE FROM STATO_PROGETTO S LEFT JOIN FASI_PROCEDURALI F ON S.COD_FASE = F.COD_FASE ORDER BY F.ORDINE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_STATO";
            base.OnDataBinding(e);
        }
    }

    public class ComboProvince : ComboSql
    {
        private string _codRegione;
        public string CodRegione
        {
            get { return _codRegione; }
            set { _codRegione = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT SIGLA,DENOMINAZIONE FROM PROVINCE WHERE CODICE NOT IN ('EE','XX')" + (_codRegione == null ? "" : " AND COD_REGIONE='"
                + _codRegione + "'") + " ORDER BY DENOMINAZIONE";
            DataTextField = "DENOMINAZIONE";
            DataValueField = "SIGLA";
            base.OnDataBinding(e);
        }
    }

    public class ComboProvinceMarche : ComboProvince
    {
        public ComboProvinceMarche() { CodRegione = "11"; }
    }

    public class ComboProvinceMarchePlus : ComboProvince
    {
        public ComboProvinceMarchePlus() { CodRegione = "11"; }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            ListItem li = new ListItem("Province fuori regione", "XR");
            li.Selected = SelectedValue == li.Value;
            Items.Add(li);
        }
    }

    public class ComboComuni : ComboSql
    {
        private string _codRegione;
        public string CodRegione
        {
            get { return _codRegione; }
            set { _codRegione = value; }
        }
        private string _siglaProvincia;
        public string SiglaProvincia
        {
            get { return _siglaProvincia; }
            set { _siglaProvincia = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID_COMUNE,DENOMINAZIONE FROM vCOMUNI WHERE ATTIVO=1" + (string.IsNullOrEmpty(_codRegione) ? "" : " AND COD_REGIONE='" + _codRegione + "'")
                + (string.IsNullOrEmpty(_siglaProvincia) ? "" : " AND SIGLA='" + _siglaProvincia + "'") + " ORDER BY DENOMINAZIONE";
            DataTextField = "DENOMINAZIONE";
            DataValueField = "ID_COMUNE";
            base.OnDataBinding(e);
        }
    }

    public class ComboComuniMarche : ComboComuni
    {
        public ComboComuniMarche() { CodRegione = "11"; }
    }

    public class ComboComuniProgetto : ComboSql
    {
        private int _idProgetto;
        public int IdProgetto
        {
            get { return _idProgetto; }
            set { _idProgetto = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "EXEC SpRicercaComuneXInvestimenti " + _idProgetto;
            DataTextField = "COMUNE";
            DataValueField = "COD_BELFIORE";
            base.OnDataBinding(e);
        }
    }

    public class ComboCittadinanza : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM CITTADINANZA";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_CITTADINANZA";
            base.OnDataBinding(e);
        }
    }

    public class ComboProfilo : ComboSql
    {
        private string _codEnte = null;
        public string CodEnte
        {
            set { _codEnte = value; }
            get { return _codEnte; }
        }

        private string _codTipoEnte = null;
        public string CodTipoEnte
        {
            set { _codTipoEnte = value; }
            get { return _codTipoEnte; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            string where_condition = "COD_TIPO_ENTE IS NULL";
            if (!string.IsNullOrEmpty(_codTipoEnte)) where_condition = "COD_TIPO_ENTE='" + _codTipoEnte + "'";
            else if (!string.IsNullOrEmpty(_codEnte)) where_condition = "COD_TIPO_ENTE IN (SELECT COD_TIPO_ENTE FROM ENTE WHERE COD_ENTE='" + _codEnte + "')";
            CommandText = "SELECT ID_PROFILO,DESCRIZIONE FROM PROFILI WHERE " + where_condition;
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_PROFILO";
            base.OnDataBinding(e);
        }
    }

    public class ComboEnte : ComboSql
    {
        private string _codTipoEnte = "";
        public string CodTipoEnte
        {
            set { _codTipoEnte = value; }
            get
            {
                return _codTipoEnte;
            }
        }

        // se impostato true filtra gli enti attivi
        private bool _abilitaModifica = false;
        public bool AbilitaModifica
        {
            get { return _abilitaModifica; }
            set { _abilitaModifica = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_ENTE,DESCRIZIONE FROM ENTE WHERE 1=1" + (_abilitaModifica ? " AND ATTIVO=1" : "")
                + (!string.IsNullOrEmpty(_codTipoEnte) ? " AND COD_TIPO_ENTE='" + _codTipoEnte + "'" : "") + " ORDER BY COD_TIPO_ENTE,DESCRIZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_ENTE";
            base.OnDataBinding(e);
        }
    }

    public class ComboUnitaMisura : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID_UNITA_MISURA,DESCRIZIONE FROM UNITA_DI_MISURA ORDER BY DESCRIZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_UNITA_MISURA";
            base.OnDataBinding(e);
        }
    }

    public class ComboLivelloPriorita : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_LIVELLO ,DESCRIZIONE FROM LIVELLO_PRIORITA";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_LIVELLO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoInvestimentoBando : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_INVESTIMENTO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO_INVESTIMENTO";
            base.OnDataBinding(e);
        }
    }

    public class ComboEsitoStep : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_ESITO ,DESCRIZIONE FROM ESITI_STEP";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_ESITO";
            base.OnDataBinding(e);
        }
    }

    public class ComboSchedaValutazione : ComboSql
    {
        private string _idBando;
        public string IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        private bool _flagTemplate = false;
        public bool FlagTemplate
        {
            get { return _flagTemplate; }
            set { _flagTemplate = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT DESCRIZIONE,ID_SCHEDA_VALUTAZIONE FROM SCHEDA_VALUTAZIONE WHERE 1=1 " + (_idBando == null ? "" : " AND ID_BANDO =" + _idBando + " ") + " AND FLAG_TEMPLATE =  " + (_flagTemplate ? "1" : "0 ");
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_SCHEDA_VALUTAZIONE";
            base.OnDataBinding(e);
        }
    }

    public class ComboMiglioramentoAziendale : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM MIGLIORAMENTO_AZIENDALE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_MIGLIORAMENTO_AZIENDALE";
            base.OnDataBinding(e);
        }
    }

    public class ComboInterventiBando : ComboSql
    {
        private NullTypes.IntNT _idBando;
        public NullTypes.IntNT IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID_PROGRAMMAZIONE,CODICE + ' - ' + DESCRIZIONE AS DESCRIZIONE  FROM [dbo].[vBANDO_PROGRAMMAZIONE] WHERE ID_BANDO=" + _idBando + " ORDER BY ID_PROGRAMMAZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_PROGRAMMAZIONE";
            base.OnDataBinding(e);
        }
    }

    public class ComboCodificaInvestimenti : ComboSql
    {
        private NullTypes.IntNT _idBando;
        public NullTypes.IntNT IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        private NullTypes.IntNT _idIntervento;
        public NullTypes.IntNT IdIntervento
        {
            get { return _idIntervento; }
            set { _idIntervento = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT C.ID_CODIFICA_INVESTIMENTO, P.CODICE + ' - ' + C.CODICE + ' ' + C.DESCRIZIONE AS DESCRIZIONE FROM CODIFICA_INVESTIMENTO C" + (_idBando == null ? "" : " INNER JOIN vBANDO_PROGRAMMAZIONE P ON C.ID_INTERVENTO = P.ID_PROGRAMMAZIONE AND C.ID_BANDO = P.ID_BANDO WHERE C.ID_BANDO=" + _idBando + (_idIntervento == null ? "" : " AND C.ID_INTERVENTO=" + _idIntervento.ToString()))
                + " ORDER BY C.ID_CODIFICA_INVESTIMENTO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_CODIFICA_INVESTIMENTO";
            base.OnDataBinding(e);
        }
    }

    public class ComboBandiQuotaFissa : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT B.ID_BANDO, B.DESCRIZIONE FROM BANDO B INNER JOIN BANDO_CONFIG C ON B.ID_BANDO = C.ID_BANDO AND C.COD_TIPO = 'QUOTAFISSA' AND C.ATTIVO = 1 AND C.VALORE = 'True'"
                + "ORDER BY B.ID_BANDO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoVariante : ComboSql
    {
        private string _codTipo;
        public string CodTipo
        {
            get { return _codTipo; }
            set { _codTipo = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_VARIANTE " + (_codTipo == null ? "" : "WHERE COD_TIPO = '" + _codTipo + "'");
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO";
            base.OnDataBinding(e);
        }
    }

    public class ComboDettaglioInvestimenti : ComboSql
    {
        private int _idCodifica;
        public string IdCodifica
        {
            get { return _idCodifica.ToString(); }
            set { int.TryParse(value, out _idCodifica); }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID_DETTAGLIO_INVESTIMENTO,DESCRIZIONE+CASE WHEN RICHIEDI_PARTICELLA=1 THEN ' (R)' ELSE '' END AS TESTO FROM DETTAGLIO_INVESTIMENTI"
                + (_idCodifica > 0 ? " WHERE ID_CODIFICA_INVESTIMENTO=" + _idCodifica : "");
            DataTextField = "TESTO";
            DataValueField = "ID_DETTAGLIO_INVESTIMENTO";
            base.OnDataBinding(e);
        }
    }

    public class ComboSpecificaInvestimenti : ComboSql
    {

        private string _idDettaglio;
        public string IdDettaglio
        {
            get { return _idDettaglio; }
            set { _idDettaglio = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM SPECIFICA_INVESTIMENTI " + (_idDettaglio == null ? "" : " WHERE ID_DETTAGLIO_INVESTIMENTO=" + _idDettaglio);
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_SPECIFICA_INVESTIMENTO";
            base.OnDataBinding(e);
        }
    }

    public class ComboDimensioneImpresa : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM DIMENSIONE_IMPRESA";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_DIMENSIONE";
            base.OnDataBinding(e);
        }
    }

    public class ComboOTE : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM OTE_TIPI";
            DataTextField = "DESCRIZIONE";
            DataValueField = "OTE";
            base.OnDataBinding(e);
        }
    }

    public class ComboMateriePrime : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {

            CommandText = "SELECT ID, DENOMINAZIONE = case when substring(DENOMINAZIONE,150,3)!='' then substring(DENOMINAZIONE,0,150)+'...' else DENOMINAZIONE end FROM MATERIE_PRIME";
            DataTextField = "DENOMINAZIONE";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }

    public class ComboProdottiTrattato : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID,DENOMINAZIONE = CASE WHEN substring(LTRIM (CAPITOLO) +' - '+ DENOMINAZIONE,120,3)!='' then substring(rTRIM (CAPITOLO) + ' - '+ DENOMINAZIONE,0,120)+'...' else  rtrim(CAPITOLO)  +'  - '+ DENOMINAZIONE end from PRODOTTI_DEL_TRATTATO";
            DataTextField = "DENOMINAZIONE";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }

    public class ComboRuoloBando : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM RUOLO_BANDO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_RUOLO_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboClassificazioneAllevamenti : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM CLASSIFICAZIONE_ALLEVAMENTI";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_CLASSE";
            base.OnDataBinding(e);
        }
    }

    public class ComboAllevamentiEroa : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT DISTINCT CONVERT(VARCHAR(3), dbo.CLASSIFICAZIONE_ALLEVAMENTI.ID_CLASSE) + '|' + CONVERT(VARCHAR(3), "
                + "dbo.EROA_ATTIVITA_AGRICOLE_COEFF_ALLEV.ID) AS ID, "
                + "dbo.CLASSIFICAZIONE_ALLEVAMENTI.DESCRIZIONE + CASE WHEN(dbo.EROA_ATTIVITA_AGRICOLE_CONDIZIONI.DESCRIZIONE IS NULL) "
                + "THEN '' ELSE ' (' + dbo.EROA_ATTIVITA_AGRICOLE_CONDIZIONI.DESCRIZIONE + ')' END AS DESCRIZIONE FROM "
                + "dbo.EROA_ATTIVITA_AGRICOLE_ALLEV INNER JOIN dbo.CLASSIFICAZIONE_ALLEVAMENTI ON "
                + "dbo.EROA_ATTIVITA_AGRICOLE_ALLEV.COD_AGEA = dbo.CLASSIFICAZIONE_ALLEVAMENTI.ID_CLASSE INNER JOIN "
                + "dbo.EROA_ATTIVITA_AGRICOLE_COEFF_ALLEV ON  dbo.EROA_ATTIVITA_AGRICOLE_ALLEV.COD_EROA = "
                + "dbo.EROA_ATTIVITA_AGRICOLE_COEFF_ALLEV.ID LEFT OUTER JOIN dbo.EROA_ATTIVITA_AGRICOLE_CONDIZIONI ON "
                + "dbo.EROA_ATTIVITA_AGRICOLE_COEFF_ALLEV.COD_CONDIZIONE = dbo.EROA_ATTIVITA_AGRICOLE_CONDIZIONI.CODICE "
                + "ORDER BY dbo.CLASSIFICAZIONE_ALLEVAMENTI.DESCRIZIONE + "
                + "CASE WHEN(dbo.EROA_ATTIVITA_AGRICOLE_CONDIZIONI.DESCRIZIONE IS NULL) THEN '' ELSE "
                + "' (' + dbo.EROA_ATTIVITA_AGRICOLE_CONDIZIONI.DESCRIZIONE + ')' END";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }


    public class ComboEroaAllevamento : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT DISTINCT ID_CLASSE, cla.DESCRIZIONE FROM EROA_ATTIVITA_AGRICOLE_ALLEV allev 
                            INNER JOIN CLASSIFICAZIONE_ALLEVAMENTI cla on cla.ID_CLASSE = allev.COD_AGEA 
                            ORDER BY ID_CLASSE ";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_CLASSE";
            base.OnDataBinding(e);
        }
    }


    public class ComboIstruttoriXBando : ComboSql
    {
        private int idBando = 0;
        public int IdBando
        {
            get { return idBando; }
            set { idBando = value; }
        }

        private string provincia;
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT DISTINCT U.ID_UTENTE,U.NOMINATIVO FROM COLLABORATORI_X_BANDO C INNER JOIN vUTENTI U ON C.ID_UTENTE=U.ID_UTENTE WHERE C.ATTIVO=1 AND ID_BANDO=" + idBando.ToString() + (!string.IsNullOrEmpty(provincia) ? " AND C.PROVINCIA='" + provincia + "'" : "");
            DataTextField = "NOMINATIVO";
            DataValueField = "ID_UTENTE";
            base.OnDataBinding(e);
        }
    }

    public class ComboIstruttoriXManifestazione : ComboSql
    {
        private int idBando = 0;
        public int IdBando
        {
            get { return idBando; }
            set { idBando = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT DISTINCT C.CF_UTENTE,NOMINATIVO FROM COLLABORATORI_X_MANIFESTAZIONE C INNER JOIN vUTENTI U ON C.CF_UTENTE=U.CF_UTENTE WHERE ID_BANDO=" + idBando.ToString();
            DataTextField = "NOMINATIVO";
            DataValueField = "CF_UTENTE";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoNotificheBio : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_NOTIFICA_BIO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO_NOTIFICA";
            base.OnDataBinding(e);
        }
    }

    public class ComboOdC : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM ORGANISMO_DI_CONTROLLO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_ODC";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoDomandaPagamento : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_TIPO, DESCRIZIONE FROM TIPO_DOMANDA_PAGAMENTO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO";
            base.OnDataBinding(e);
        }
    }

    public class ComboMacrouso : ComboSql
    {
        private string _idFascicolo;
        public string IdFascicolo
        {
            get { return _idFascicolo; }
            set { _idFascicolo = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT distinct COD_MACROUSO, MACROUSO = case when substring(MACROUSO, 80,3)!='' then substring(MACROUSO,0, 80)+'...' else MACROUSO end from vpiano_colturale " + (_idFascicolo == null ? " " : " WHERE ID_FASCICOLO = " + _idFascicolo);
            DataTextField = "MACROUSO";
            DataValueField = "COD_MACROUSO";
            base.OnDataBinding(e); ;
        }
    }

    public class ComboIndirizzoProduttivo : ComboSql
    {

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM INDIRIZZO_PRODUTTIVO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_INDIRIZZO";
            base.OnDataBinding(e);
        }
    }

    public class ComboDettaglioProduttivo : ComboSql
    {
        private string _idIndirizzo;
        public string IdIndirizzo
        {
            get { return _idIndirizzo; }
            set { _idIndirizzo = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM DETTAGLIO_INDIRIZZO_PRODUTTIVO" + (_idIndirizzo == null ? "" : " WHERE COD_INDIRIZZO_PRODUTTIVO=" + _idIndirizzo);
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_DETTAGLIO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoMandatoImpresa : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM TIPO_MANDATI_IMPRESA WHERE ATTIVO=1 ORDER BY CODICE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboRuoloFiliera : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_RUOLO_FILIERA WHERE ATTIVO = 1";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_RUOLO";
            base.OnDataBinding(e);
        }
    }

    public class ComboRuoloPartecipanteFiliera : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_RUOLO_PARTECIPANTE_FILIERA WHERE ATTIVO = 1";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_RUOLO_PARTECIPANTE";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoFiliera : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_FILIERA";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO";
            base.OnDataBinding(e);
        }
    }

    public class ComboDataEstrazioneMonitoraggioMisura : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT ID_ESTRAZIONE,CONVERT(VARCHAR, PDATA_ESTRAZIONE, 103) + ' - ' + LEFT(NOTE, 50) AS DATA_ESTRAZIONE 
                            FROM MONIT_ESTRAZIONI_DATI WHERE TIPO_ESTRAZIONE = 'PAG' ORDER BY PDATA_ESTRAZIONE DESC";
            DataTextField = "DATA_ESTRAZIONE";
            DataValueField = "ID_ESTRAZIONE";
            base.OnDataBinding(e);
        }
    }

    public class ComboDataEstrazioneMonitoraggioBando : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT ID_ESTRAZIONE,CONVERT(VARCHAR, PDATA_ESTRAZIONE, 103) + ' - ' + LEFT(NOTE, 50) AS DATA_ESTRAZIONE 
                            FROM MONIT_ESTRAZIONI_DATI WHERE TIPO_ESTRAZIONE = 'BAN' ORDER BY PDATA_ESTRAZIONE DESC";
            DataTextField = "DATA_ESTRAZIONE";
            DataValueField = "ID_ESTRAZIONE";
            base.OnDataBinding(e);
        }
    }

    public class ComboGiustificativiDiSpesa : ComboSql
    {
        protected override void OnInit(EventArgs e)
        {
            DataValueField = "COD_TIPO";
            DataTextField = "DESCRIZIONE";
            CommandText = "SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1";
            base.OnInit(e);
        }
    }

    public class ComboGiustificativiDiPagamento : ComboSql
    {
        protected override void OnInit(EventArgs e)
        {
            DataValueField = "COD_TIPO";
            DataTextField = "DESCRIZIONE";
            CommandText = "SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1";
            base.OnInit(e);
        }
    }

    public class ComboTipoPolizza : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT * FROM TIPO_POLIZZA ORDER BY COD_TIPO_POLIZZA";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO_POLIZZA";
            base.OnDataBinding(e);
        }
    }

    public class ComboZPsr : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,TITOLO=DESCRIZIONE +' '+CAST(ANNO_DA AS CHAR(4))+'-'+CAST(ANNO_A AS CHAR(4)) FROM zPSR ORDER BY ANNO_DA";
            DataTextField = "TITOLO";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboZProgrammazione : ComboSql
    {
        private string _codicePsr;
        public string CodicePsr { set { _codicePsr = value; } }

        private bool _attivazione_bandi;
        public bool AttivazioneBandi { set { _attivazione_bandi = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID,TITOLO=CODICE+' - '+SUBSTRING(DESCRIZIONE,0,100) FROM VZPROGRAMMAZIONE WHERE COD_PSR='" + _codicePsr + "'"
                + (_attivazione_bandi ? " AND ATTIVAZIONE_BANDI=1" : "") + " ORDER BY CODICE";
            DataTextField = "TITOLO";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }

    public class ComboZProgrammazioneAsseAzInt : ComboSql
    {
        private string _codiceTipo;
        public string CodiceTipo { set { _codiceTipo = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT ID,TITOLO=CODICE+' - '+SUBSTRING(DESCRIZIONE,0,100) FROM VZPROGRAMMAZIONE WHERE COD_TIPO='" + _codiceTipo + "'  ORDER BY CODICE";
            DataTextField = "TITOLO";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }

    public class ComboZTp : ComboSql
    {
        private string _idProgrammazione;
        public string idProgrammazione { set { _idProgrammazione = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM zTP WHERE ID_PROGRAMMAZIONE= " + _idProgrammazione;
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboZStp : ComboSql
    {
        private string _idProgrammazione;
        public string idProgrammazione { set { _idProgrammazione = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM zSTP WHERE ID_PROGRAMMAZIONE= " + _idProgrammazione;
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
            // aggiungo il codice standard
            if (Items.Count == 1 && string.IsNullOrEmpty(Items[0].Value))
            {
                Items.Clear();
                Items.Add("");
                Items.Add(new ListItem("Nessuna sottotipologia prevista", "00"));
            }
        }
    }

    public class ComboPrioritaSettoriale : ComboSql
    {
        private int _idBando;
        public int IdBando { set { _idBando = value; } }

        private int _idSettoreProduttivo;
        public int IdSettoreProduttivo { set { _idSettoreProduttivo = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT DISTINCT P.ID_PRIORITA_SETTORIALE,P.DESCRIZIONE FROM BANDO_X_SETTORE_PRODUTTIVO X 
                            INNER JOIN PRIORITA_SETTORIALI P ON X.ID_PRIORITA_SETTORIALE=P.ID_PRIORITA_SETTORIALE WHERE ID_BANDO=" + _idBando
                            + " AND (X.ID_SETTORE_PRODUTTIVO IS NULL OR X.ID_SETTORE_PRODUTTIVO=" + _idSettoreProduttivo + ")";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_PRIORITA_SETTORIALE";
            base.OnDataBinding(e);
        }
    }

    public class ComboSettoreProduttivo : ComboSql
    {
        private int _idBando;
        public int IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT DISTINCT ID_SETTORE_PRODUTTIVO,SETTORE_PRODUTTIVO FROM vBANDO_X_SETTORE_PRODUTTIVO WHERE ID_BANDO="
                + _idBando + " ORDER BY SETTORE_PRODUTTIVO";
            DataTextField = "SETTORE_PRODUTTIVO";
            DataValueField = "ID_SETTORE_PRODUTTIVO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoSegnatura : ComboSql
    {
        private bool _flagAiuto = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool FlagAiuto
        {
            get { return _flagAiuto; }
            set { _flagAiuto = value; }
        }

        private bool _flagPagamento = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool FlagPagamento
        {
            get { return _flagPagamento; }
            set { _flagPagamento = value; }
        }

        private bool _flagVariante = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool FlagVariante
        {
            get { return _flagVariante; }
            set { _flagVariante = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT COD_TIPO,DESCRIZIONE FROM TIPO_SEGNATURA WHERE FLAG_DOMANDA_AIUTO=" + (_flagAiuto ? "1" : "0 ")
                + " AND FLAG_DOMANDA_PAGAMENTO=" + (_flagPagamento ? "1" : "0 ") + " AND FLAG_VARIANTE=" + (_flagVariante ? "1" : "0 ");
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoSocioImpresa : ComboSql
    {
        protected override void OnInit(EventArgs e)
        {
            CommandText = "SELECT CODICE, DESCRIZIONE FROM TIPO_SOCIO";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnInit(e);
        }
    }


    // : inizio combo aggiunte per DatiMonitoraggioFESR

    public class ComboCUPCategoria : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT COD_CUP_CATEGORIE, Categoria + ' - ' + Descrizione as Descrizione FROM TIPO_CUP_CATEGORIE WHERE Categoria is not null and Categoria <> '' and Eliminato=0 ORDER BY Settore, SottoSettore, Categoria";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_CATEGORIE";
            base.OnDataBinding(e);
        }
    }

    public class ComboCUPCategoriaSettore : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT COD_CUP_CATEGORIE, Settore + ' - ' + Descrizione as Descrizione FROM TIPO_CUP_CATEGORIE WHERE SottoSettore is null and Eliminato=0 ORDER BY Settore";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_CATEGORIE";
            base.OnDataBinding(e);
        }
    }

    public class ComboCUPCategoriaSottoSettore : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT COD_CUP_CATEGORIE, SottoSettore + ' - ' + Descrizione as Descrizione FROM TIPO_CUP_CATEGORIE WHERE SottoSettore is not null and Categoria is null and Eliminato=0 ORDER BY Settore, SottoSettore";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_CATEGORIE";
            base.OnDataBinding(e);
        }
    }

    public class ComboCUPCategoriaSoggetto : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT COD_CUP_CATEGORIE_SOGGETTI, CodiceCategoria + ' - ' + Descrizione as Descrizione FROM TIPO_CUP_CATEGORIE_SOGGETTI WHERE CodiceSottocategoria is null and Eliminato=0 ORDER BY COD_CUP_CATEGORIE_SOGGETTI";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_CATEGORIE_SOGGETTI";
            base.OnDataBinding(e);
        }
    }

    public class ComboCUPCategoriaSoggettoSub : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT COD_CUP_CATEGORIE_SOGGETTI, CodiceSottocategoria + ' - ' + Descrizione as Descrizione FROM TIPO_CUP_CATEGORIE_SOGGETTI WHERE CodiceSottocategoria is not null and Eliminato=0 ORDER BY COD_CUP_CATEGORIE_SOGGETTI";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_CATEGORIE_SOGGETTI";
            base.OnDataBinding(e);
        }
    }

    public class ComboCUPCategoriaTipoOper : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"
                select tipiOp.COD_CUP_CATEGORIE_TIPIOPERAZIONI, nat.Descrizione + ' - ' +  tipiOp.Descrizione as Descrizione, Eliminato 
                FROM
                (
	                SELECT COD_CUP_CATEGORIE_TIPIOPERAZIONI, Descrizione, Natura, Eliminato
	                FROM TIPO_CUP_CATEGORIE_TIPIOPERAZIONI
	                WHERE Tipologia is not null
                ) tipiOp
                inner join (
	                SELECT COD_CUP_CATEGORIE_TIPIOPERAZIONI, Descrizione
	                FROM TIPO_CUP_CATEGORIE_TIPIOPERAZIONI
	                WHERE Tipologia is null
                ) nat 
                on tipiOp.Natura + 'XX' = nat.[COD_CUP_CATEGORIE_TIPIOPERAZIONI]
                where tipiOp.Eliminato=0 order by tipiOp.COD_CUP_CATEGORIE_TIPIOPERAZIONI";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_CATEGORIE_TIPIOPERAZIONI";
            base.OnDataBinding(e);
        }
    }

    public class ComboTemaPrioritario : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"
                select COD_TEMA_PRIORITARIO, Descrizione 
                FROM TIPO_TEMA_PRIORITARIO  order by COD_TEMA_PRIORITARIO";
            DataTextField = "Descrizione";
            DataValueField = "COD_TEMA_PRIORITARIO";
            base.OnDataBinding(e);
        }
    }

    public class ComboAttivitaEcon : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"
                select COD_ATTIVITA_ECON, Descrizione 
                FROM TIPO_ATTIVITA_ECON  order by COD_ATTIVITA_ECON";
            DataTextField = "Descrizione";
            DataValueField = "COD_ATTIVITA_ECON";
            base.OnDataBinding(e);
        }
    }

    public class ComboCPTSettore : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"
                select COD_CPT_SETTORE, Descrizione 
                FROM TIPO_CPT_SETTORE  order by COD_CPT_SETTORE";
            DataTextField = "Descrizione";
            DataValueField = "COD_CPT_SETTORE";
            base.OnDataBinding(e);
        }
    }

    public class ComboCUPDimensioneTerr : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"
                select COD_CUP_DIMENSIONE_TERR, Descrizione 
                FROM TIPO_CUP_DIMENSIONE_TERR  order by COD_CUP_DIMENSIONE_TERR";
            DataTextField = "Descrizione";
            DataValueField = "COD_CUP_DIMENSIONE_TERR";
            base.OnDataBinding(e);
        }
    }

    //    public class ComboCUPNatura : ComboSql
    //    {
    //        protected override void OnDataBinding(EventArgs e)
    //        {
    //            CommandText = @"
    //                select COD_CUP_NATURA, Descrizione 
    //                FROM TIPO_CUP_NATURA  order by COD_CUP_NATURA";
    //            DataTextField = "Descrizione";
    //            DataValueField = "COD_CUP_NATURA";
    //            base.OnDataBinding(e);
    //        }
    //    }

    // : Fine combo aggiunte per DatiMonitoraggioFESR

    // : combo aggiunta per indirizzi
    public class ComboDUG : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"
                select ID_DUG, Descrizione 
                FROM TIPO_DUG  
                WHERE ATTIVO=1 
                ORDER BY Ordine";
            DataTextField = "Descrizione";
            DataValueField = "ID_DUG";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipologiaAggregazioni : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM TIPO_AGGREGAZIONE ORDER BY DESCRIZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipologiaImpreseAggregazioni : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT CODICE,DESCRIZIONE FROM TIPO_AGGREGAZIONE_RUOLO ORDER BY DESCRIZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "CODICE";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipologiaComunicazione : ComboSql
    {
        public BoolNT inEntrata { get; set; }
        public BoolNT inUscita { get; set; }

        protected override void OnDataBinding(EventArgs e)
        {
            string commandText = "";
            if (inEntrata != null && inEntrata)
                commandText = "SELECT COD_TIPO,DESCRIZIONE FROM TIPO_COMUNICAZIONE WHERE IN_ENTRATA = 1 ORDER BY DESCRIZIONE";
            else if (inUscita != null && inUscita)
                commandText = "SELECT COD_TIPO,DESCRIZIONE FROM TIPO_COMUNICAZIONE WHERE IN_USCITA = 1 ORDER BY DESCRIZIONE";
            else
                commandText = "SELECT COD_TIPO,DESCRIZIONE FROM TIPO_COMUNICAZIONE ORDER BY DESCRIZIONE";
            CommandText = commandText;
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_TIPO";
            base.OnDataBinding(e);
        }
    }

    public class ComboZTipoDimensioni : ComboSql
    {
        public int idOperatore { get; set; }
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_DIM, DESCRIZIONE FROM zTIPO_DIMENSIONE ORDER BY DESCRIZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_DIM";
            base.OnDataBinding(e);
        }
    }

    public class ComboBandiRup : ComboSql
    {
        private int _idRup;
        public string IdRup
        {
            get { return _idRup.ToString(); }
            set { int.TryParse(value, out _idRup); }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT B.ID_BANDO, B.DESCRIZIONE FROM BANDO B INNER JOIN BANDO_RESPONSABILI R ON B.ID_BANDO = R.ID_BANDO WHERE R.ID_UTENTE = " + IdRup + @" AND R.ATTIVO = 1 AND R.PROVINCIA IS NULL
                            AND B.ID_BANDO NOT IN (SELECT DISTINCT B.ID_BANDO FROM BANDO B INNER JOIN 
            vBando_Config BG ON B.ID_BANDO = BG.ID_BANDO AND BG.Cod_Tipo = 'TPAPPALTO' AND BG.VALORE_DESCRIZIONE = 'Strumenti finanziari' )";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboBandiRupFem : ComboSql
    {
        private int _idRup;
        public string IdRup
        {
            get { return _idRup.ToString(); }
            set { int.TryParse(value, out _idRup); }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = @"SELECT DISTINCT B.ID_BANDO, B.DESCRIZIONE FROM BANDO B INNER JOIN 
                            vBando_Config BG ON B.ID_BANDO = BG.ID_BANDO AND BG.Cod_Tipo = 'TPAPPALTO' AND BG.VALORE_DESCRIZIONE = 'Strumenti finanziari' INNER JOIN
                            BANDO_RESPONSABILI R ON B.ID_BANDO = R.ID_BANDO WHERE R.ID_UTENTE = " + IdRup + @" AND R.ATTIVO = 1 AND R.PROVINCIA IS NULL";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboBandiValidatoriRup : ComboSql
    {
        private int _idBando;
        public string IdBando
        {
            get { return _idBando.ToString(); }
            set { int.TryParse(value, out _idBando); }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT DISTINCT U.CF_UTENTE, U.NOMINATIVO FROM BANDO B INNER JOIN BANDO_RESPONSABILI R ON B.ID_BANDO = R.ID_BANDO AND R.ATTIVO = 1 AND R.PROVINCIA IS NULL INNER JOIN BANDO_VALIDATORI V ON B.ID_BANDO = V.ID_BANDO AND V.ATTIVO = 1 INNER JOIN vUTENTI U ON V.ID_UTENTE = U.ID_UTENTE WHERE B.ID_BANDO = " + IdBando;
            DataTextField = "NOMINATIVO";
            DataValueField = "CF_UTENTE";
            base.OnDataBinding(e);
        }
    }

    public class ComboBandiOrganismiIntermedi : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "select B.ID_BANDO,B.DESCRIZIONE from BANDO B inner join BANDO_CONFIG on B.ID_BANDO = BANDO_CONFIG.ID_BANDO and BANDO_CONFIG.ATTIVO = 1 AND BANDO_CONFIG.COD_TIPO = 'ORGINTER'";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoPistaControlloFem : ComboSql
    {
        private int _idPadre;
        public int IdPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }

        private int _livello;
        public int Livello
        {
            get { return _livello; }
            set { _livello = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT DESCRIZIONE,ID_TIPO_PISTA_CONTROLLO FROM TIPO_PISTA_CONTROLLO WHERE LIVELLO = " + _livello + " AND ID_PADRE = " + _idPadre + " ORDER BY ORDINE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_TIPO_PISTA_CONTROLLO";
            base.OnDataBinding(e);
        }
    }

    public class ComboCovidAutocertificazione : ComboSql
    {
        private int _idUtente;
        public int IdUtente
        {
            get { return _idUtente; }
            set { _idUtente = value; }
        }

        private int _idBando;
        public int IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT RAGIONE_SOCIALE + ' - ' + PARTITA_IVA AS DESCRIZIONE, ID FROM COVID_AUTODICHIARAZIONE inner join vPROGETTO P on P.ID_PROGETTO = COVID_AUTODICHIARAZIONE.ID_PROGETTO  WHERE COVID_AUTODICHIARAZIONE.OPERATORE_INSERIMENTO = " + _idUtente + " AND COVID_AUTODICHIARAZIONE.ID_BANDO = " + _idBando + " AND P.COD_STATO = 'P'  AND DEFINITIVA = 1 ORDER BY RAGIONE_SOCIALE";
            //CommandText = "SELECT RAGIONE_SOCIALE + ' - ' + PARTITA_IVA AS DESCRIZIONE, ID FROM COVID_AUTODICHIARAZIONE WHERE OPERATORE_INSERIMENTO = " + _idUtente + " AND ID_BANDO= " + _idBando + " AND DEFINITIVA = 1 ORDER BY RAGIONE_SOCIALE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }

    public class ComboBandiCovid : ComboSql
    {
        private int _idRup;
        public int IdRup
        {
            get { return _idRup; }
            set { _idRup = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT B.ID_BANDO, B.DESCRIZIONE FROM BANDO B INNER JOIN COVID_BANDO_RUP_PAGAMENTO R ON B.ID_BANDO = R.ID_BANDO INNER JOIN BANDO_CONFIG C ON B.ID_BANDO = C.ID_BANDO AND C.COD_TIPO = 'BANDOCOVID' AND C.ATTIVO = 1 WHERE R.ID_OPERATORE = " + IdRup;
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboAtecoBando : ComboSql
    {
        private int _idBando;
        public int IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            //CommandText = "SELECT a.COD_TIPO_ATECO2007 as CODICE_ATECO , " +
            //    "case	when Sottocategoria = ''	then case when Categoria = ''	then case when Classe = '' then case when Gruppo = '' then Divisione else Gruppo end	else Classe end else Categoria end	else	Sottocategoria end +' - '+Descrizione as TESTO " +
            //    " FROM TIPO_ATECO2007 a " +
            //    " inner join BANDO_ATECO2007 b on b.ID_ATECO2007 = a.COD_TIPO_ATECO2007 "+
            //    " WHERE ID_BANDO=" + _idBando + "  order by Sezione, Divisione,Gruppo,Classe,Categoria,Sottocategoria"; 

            //Se non sono ci sono righe su bando_ateco2007 per quel bando carico tutti gli ateco
            CommandText = "EXEC SpComboAteco " + _idBando;
            DataTextField = "TESTO";
            DataValueField = "CODICE_ATECO";
            base.OnDataBinding(e);
        }
    }

    public class ComboCertSpProgetto : ComboSql
    {
        private int _idProgetto;
        public int IdProgetto
        {
            get { return _idProgetto; }
            set { _idProgetto = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "EXEC SpCertSpProgetto " + _idProgetto;
            DataTextField = "LOTTO_CERT";
            DataValueField = "IdCertSp";
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoAssistenza : ComboSql
    {
        protected override void OnInit(EventArgs e)
        {
            CommandText = "SELECT * FROM ASSISTENZA_UTENTI_TIPOLOGIA_RICHIESTA";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_TIPOLOGIA";
            base.OnInit(e);
        }
    }

    public class ComboOperatoriAssistenza : ComboSql
    {
        protected override void OnInit(EventArgs e)
        {
            CommandText = "SELECT DISTINCT NOMINATIVO_OPERATORE_GESTIONE, ID_OPERATORE_GESTIONE FROM vASSISTENZA_UTENTI WHERE GESTITA = 1 ";
            DataTextField = "NOMINATIVO_OPERATORE_GESTIONE";
            DataValueField = "ID_OPERATORE_GESTIONE";
            base.OnInit(e);
        }
    }

    #endregion

    #region combogroup

    public class ComboFormaGiuridica : ComboBase
    {
        protected string selezionato = null;
        public override string SelectedValue
        {
            get { return base.SelectedValue; }
            set { base.SelectedValue = value; }
            // set { selezionato = value; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            selezionato = base.SelectedValue;
            Items.Clear();
            if (DataSource == null) DataSource = DataFill();
            SiarLibrary.FormaGiuridicaCollection cc = (SiarLibrary.FormaGiuridicaCollection)DataSource;

            if (cc != null && cc.Count > 0)
            {
                string str = "", codP = "";
                foreach (SiarLibrary.FormaGiuridica fg in cc)
                {
                    if (!fg.Foglia)
                    {
                        if (codP != "") str += "</optgroup>";
                        if (fg.CodIstat.ToString().Length < 2) str += "<optgroup label='" + fg.CodIstat + "  " + fg.Descrizione + "' class='lstgrp_lvl1'>";
                        else str += "<optgroup label='" + "   " + fg.CodIstat + "  " + fg.Descrizione + "' class='lstgrp_lvl2'>";
                        codP = fg.CodIstat;
                    }
                    else
                    {
                        string cella_selezionata = "<option class='lstgrp_lvl3' value='" + fg.CodIstat + "'>" + fg.CodIstat + "  "
                                + fg.Descrizione + " </option>";
                        if (selezionato != null && fg.CodIstat == selezionato)
                            cella_selezionata = "<option class='lstgrp_lvl3' value='" + fg.CodIstat + "' selected='true'>" + fg.CodIstat + "  " + fg.Descrizione
                            + " </option>";
                        str += cella_selezionata;
                    }
                }

                ListItem lt = new ListItem();
                lt.Attributes.Add("value=''></option>" + str, "");
                Items.Add(lt);
            }
            else
            {
                Items.Clear();
                Items.Add(new ListItem("Nessun elemento presente.", "", false));
                NoBlankItem = true;
                return;
            }
        }


        protected CustomCollection DataFill()
        {
            return (CustomCollection)new SiarBLL.FormaGiuridicaCollectionProvider().Find(null);

        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("<SELECT disabled><OPTION selected>Forma giuridica</OPTION> </SELECT>");
                return;
            }
            base.Render(writer);
        }
    }

    public class ComboGroupSpecificaInvestimenti : ComboBase
    {
        //protected string selezionato = null;

        private SiarLibrary.NullTypes.IntNT _idBando;
        public SiarLibrary.NullTypes.IntNT IdBando
        {
            get { return _idBando; }
            set { _idBando = value; }
        }

        private bool _postBackOnChange = false;
        public bool PostBackOnChange
        {
            set
            {
                _postBackOnChange = value;
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"SELECT ID_DETTAGLIO_INVESTIMENTO,D.ID_CODIFICA_INVESTIMENTO,COD_DETTAGLIO+' - ' +D.DESCRIZIONE AS DETTAGLIO,
                                CODICE+' - ' +C.DESCRIZIONE AS CODIFICA FROM DETTAGLIO_INVESTIMENTI D INNER JOIN CODIFICA_INVESTIMENTO C 
                                ON D.ID_CODIFICA_INVESTIMENTO=C.ID_CODIFICA_INVESTIMENTO WHERE ID_BANDO=" + _idBando + " ORDER BY C.CODICE,D.COD_DETTAGLIO";
            db.InitDatareader(cmd);
            string id_codifica_precedente = "", html = "";
            while (db.DataReader.Read())
            {
                string id_dettaglio = db.DataReader["ID_DETTAGLIO_INVESTIMENTO"].ToString();
                string id_codifica = db.DataReader["ID_CODIFICA_INVESTIMENTO"].ToString();
                string dettaglio = db.DataReader["DETTAGLIO"].ToString();
                string codifica = db.DataReader["CODIFICA"].ToString();
                if (id_codifica != id_codifica_precedente)
                {
                    if (!string.IsNullOrEmpty(id_codifica_precedente)) html += "</optgroup>";
                    html += "<optgroup label='" + codifica + "'>";
                }
                html += "<option value='" + id_dettaglio + "'" + (SelectedValue == id_dettaglio ? " selected" : "") + ">" + dettaglio + "</option>";
                id_codifica_precedente = id_codifica;
            }
            db.Close();
            if (!string.IsNullOrEmpty(html)) html += "</optgroup";

            ListItem li = new ListItem();
            li.Attributes.Add("value =''></option>" + html, "");
            Items.Add(li);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if ((Site != null) && (Site.DesignMode))
            {
                writer.Write("<SELECT disabled><OPTION selected>Codifica/dettaglio di investimento</OPTION> </SELECT>");
                return;
            }

            if (_postBackOnChange)
            {
                System.Web.UI.WebControls.Button btnPost = new System.Web.UI.WebControls.Button();
                btnPost.ID = "btnPostOnChange" + this.ID;
                btnPost.UseSubmitBehavior = true;
                btnPost.Style.Add("display", "none");
                //this.Attributes.Add("onchange", "$('#btnPostOnChange" + this.ID+"').click();");
                string onchangeIstrutctionsAssigned = this.Attributes["onchange"];
                this.Attributes.Add("onchange", onchangeIstrutctionsAssigned + "$('#btnPostOnChange" + this.ID + "').click();");
                base.Render(writer);
                btnPost.RenderControl(writer);
            }
            else base.Render(writer);
        }
    }

    public class ComboEroaAttivitaAgriturismo : ComboBase
    {
        private bool _attivitaMinima;
        public bool AttivitaMinima { set { _attivitaMinima = value; } }

        public override void DataBind()
        {
            Items.Clear();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT CODICE,DESCRIZIONE FROM EROA_ATTIVITA_AGRITURISMO WHERE ATTIVO=1" +
                (_attivitaMinima ? " AND RAPPORTO_PRESUNTO=1" : "") + " ORDER BY CODICE";
            db.InitDatareader(cmd);
            while (db.DataReader.Read()) Items.Add(new ListItem(db.DataReader["DESCRIZIONE"].ToString(), db.DataReader["CODICE"].ToString()));
            db.Close();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Items.Count == 0)
            {
                Items.Add(new ListItem("Nessun elemento trovato.", ""));
                base.RenderContents(writer);
            }
            else
            {
                writer.Write("<option value=''></option>");
                ListItem li_group = null;
                foreach (ListItem li in Items)
                {
                    if (li.Value.EndsWith("0"))
                    {
                        if (li_group != null) writer.Write("</optgroup>");
                        writer.Write("<optgroup label='" + li.Text + "'>");
                        li_group = li;
                    }
                    else
                    {
                        writer.Write("<option value=\"" + li.Value + "\"" + (li.Value == SelectedValue ? " selected='selected'" : "") + ">" + li.Text + "</option>");
                    }
                }
                if (li_group != null) writer.Write("</optgroup>");
            }
        }
    }

    public class ComboPreparazioneLavorazioni : ComboBase
    {
        public override void DataBind()
        {
            Items.Clear();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT CODICE,DESCRIZIONE FROM BIO_PREPARAZIONE_LAVORAZIONE WHERE ATTIVO=1 ORDER BY CODICE";
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
                Items.Add(new ListItem(db.DataReader["DESCRIZIONE"].ToString(), db.DataReader["CODICE"].ToString()));
            db.Close();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Items.Count == 0)
            {
                Items.Add(new ListItem("Nessun elemento trovato.", ""));
                base.RenderContents(writer);
            }
            else
            {
                writer.Write("<option value=''></option>");
                ListItem li_group = null;
                foreach (ListItem li in Items)
                {
                    if (li.Value.EndsWith("0"))
                    {
                        if (li_group != null) writer.Write("</optgroup>");
                        writer.Write("<optgroup label='" + li.Text + "'>");
                        li_group = li;
                    }
                    else
                    {
                        writer.Write("<option value=\"" + li.Value + "\"" + (li.Value == SelectedValue ? " selected='selected'" : "") + ">" + li.Text + "</option>");
                    }
                }
                if (li_group != null) writer.Write("</optgroup>");
            }
        }
    }

    public class ComboTipoImpiantoAcquacoltura : ComboBase
    {
        public override void DataBind()
        {
            Items.Clear();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT CODICE,DESCRIZIONE,FOGLIA FROM BIO_TIPO_IMPIANTO_ACQUACOLTURA WHERE ATTIVO=1 ORDER BY CODICE";
            db.InitDatareader(cmd);
            while (db.DataReader.Read())
                Items.Add(new ListItem(db.DataReader["DESCRIZIONE"].ToString(), db.DataReader["CODICE"].ToString(),
                    // MEMORIZZO IN "ENABLED" IL VALORE DI "FOGLIA" PER COMODITA'
                    new NullTypes.BoolNT(db.DataReader["FOGLIA"])));
            db.Close();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Items.Count == 0)
            {
                Items.Add(new ListItem("Nessun elemento trovato.", ""));
                base.RenderContents(writer);
            }
            else
            {
                writer.Write("<option value=''></option>");
                ListItem li_group = null;
                foreach (ListItem li in Items)
                {
                    if (li.Enabled) //foglia
                        writer.Write("<option value=\"" + li.Value + "\"" + (li.Value == SelectedValue ? " selected='selected'" : "") + ">"
                            + li.Text + "</option>");
                    else
                    {
                        if (li_group != null) writer.Write("</optgroup>");
                        writer.Write("<optgroup label='" + li.Text + "'>");
                        li_group = li;
                    }
                }
                if (li_group != null) writer.Write("</optgroup>");
            }
        }
    }

    public class ComboGroupZProgrammazione : ComboBase
    {
        private bool _attivazioneBandi = false;
        public bool AttivazioneBandi { set { _attivazioneBandi = value; } }
        public override void DataBind()
        {
            Items.Clear();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT P.ID,SUBSTRING(P.TIPO+' '+P.CODICE+' - '+P.DESCRIZIONE,0,140) AS PROGRAMMAZIONE,P.COD_PSR,R.DESCRIZIONE+' '+CAST(ANNO_DA AS CHAR(4))+' - '+CAST(ANNO_A AS CHAR(4)) AS PSR FROM VZPROGRAMMAZIONE P INNER JOIN zPSR R ON P.COD_PSR=R.CODICE"
                + (_attivazioneBandi ? " WHERE ATTIVAZIONE_BANDI=1" : "") + " ORDER BY ANNO_DA+ANNO_A DESC,COD_PSR+CAST(LIVELLO AS VARCHAR(5))+P.CODICE";
            db.InitDatareader(cmd);
            string cod_psr = "";
            while (db.DataReader.Read())
            {
                string psr_temp = db.DataReader["COD_PSR"].ToString();
                if (psr_temp != cod_psr)
                {
                    cod_psr = psr_temp;
                    Items.Add(new ListItem(db.DataReader["PSR"].ToString().ToUpper(), psr_temp, false));
                }
                Items.Add(new ListItem(db.DataReader["PROGRAMMAZIONE"].ToString(), db.DataReader["ID"].ToString(),
                    // MEMORIZZO IN "ENABLED" IL VALORE DI "FOGLIA" PER COMODITA'
                    true));
            }
            db.Close();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Items.Count == 0)
            {
                Items.Add(new ListItem("Nessun elemento trovato.", ""));
                base.RenderContents(writer);
            }
            else
            {
                writer.Write("<option value=''></option>");
                ListItem li_group = null;
                foreach (ListItem li in Items)
                {
                    if (li.Enabled) //foglia
                        writer.Write("<option value=\"" + li.Value + "\"" + (li.Value == SelectedValue ? " selected='selected'" : "") + ">"
                            + li.Text + "</option>");
                    else
                    {
                        if (li_group != null) writer.Write("</optgroup>");
                        writer.Write("<optgroup label='" + li.Text + "'>");
                        li_group = li;
                    }
                }
                if (li_group != null) writer.Write("</optgroup>");
            }
        }
    }

    public class ComboGroupZProgrammazioneShort : ComboBase
    {
        private bool _attivazioneBandi = false;
        public bool AttivazioneBandi { set { _attivazioneBandi = value; } }
        public override void DataBind()
        {
            Items.Clear();
            DbProvider db = new DbProvider();
            System.Data.IDbCommand cmd = db.GetCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT P.ID,P.TIPO+' '+P.CODICE AS PROGRAMMAZIONE,P.COD_PSR,/*R.DESCRIZIONE+' '+CAST(ANNO_DA AS CHAR(4))+' - '+CAST(ANNO_A AS CHAR(4))*/R.CODICE AS PSR FROM VZPROGRAMMAZIONE P INNER JOIN zPSR R ON P.COD_PSR=R.CODICE"
                + (_attivazioneBandi ? " WHERE ATTIVAZIONE_BANDI=1" : "") + " ORDER BY ANNO_DA+ANNO_A DESC,COD_PSR+CAST(LIVELLO AS VARCHAR(5))+P.CODICE";
            db.InitDatareader(cmd);
            string cod_psr = "";
            while (db.DataReader.Read())
            {
                string psr_temp = db.DataReader["COD_PSR"].ToString();
                if (psr_temp != cod_psr)
                {
                    cod_psr = psr_temp;
                    Items.Add(new ListItem(db.DataReader["PSR"].ToString().ToUpper(), psr_temp, false));
                }
                Items.Add(new ListItem(db.DataReader["PROGRAMMAZIONE"].ToString(), db.DataReader["ID"].ToString(),
                    // MEMORIZZO IN "ENABLED" IL VALORE DI "FOGLIA" PER COMODITA'
                    true));
            }
            db.Close();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Items.Count == 0)
            {
                Items.Add(new ListItem("Nessun elemento trovato.", ""));
                base.RenderContents(writer);
            }
            else
            {
                writer.Write("<option value=''></option>");
                ListItem li_group = null;
                foreach (ListItem li in Items)
                {
                    if (li.Enabled) //foglia
                        writer.Write("<option value=\"" + li.Value + "\"" + (li.Value == SelectedValue ? " selected='selected'" : "") + ">"
                            + li.Text + "</option>");
                    else
                    {
                        if (li_group != null) writer.Write("</optgroup>");
                        writer.Write("<optgroup label='" + li.Text + "'>");
                        li_group = li;
                    }
                }
                if (li_group != null) writer.Write("</optgroup>");
            }
        }
    }

    #endregion

    #region custom

    public class ComboSiNo : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("NO", "NO"));
            Items.Add(new ListItem("NON DOVUTO", "ND"));
            Items.Add(new ListItem("SI", "SI"));
            base.OnDataBinding(e);
        }
    }

    public class ComboYesNo : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("NO", "NO"));
            Items.Add(new ListItem("SI", "SI"));
            base.OnDataBinding(e);
        }
    }

    public class ComboEsiti : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("NO", "NO"));
            Items.Add(new ListItem("NON DOVUTO", "ND"));
            Items.Add(new ListItem("DA INTEGRARE", "DA"));
            Items.Add(new ListItem("PARZIALE", "PA"));
            Items.Add(new ListItem("SI", "SI"));
            base.OnDataBinding(e);
        }
    }

    public class ComboUtilizzo : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("DEDICATO", "D"));
            Items.Add(new ListItem("MISTO", "M"));

            base.OnDataBinding(e);
        }
    }

    public class ComboAliquota : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("4%", "4"));
            Items.Add(new ListItem("10%", "10"));
            Items.Add(new ListItem("20%", "20"));
            Items.Add(new ListItem("21%", "21"));
            Items.Add(new ListItem("22%", "22"));
            Items.Add(new ListItem("Esente iva", "0"));
            base.OnDataBinding(e);
        }
    }

    public class ComboRuoloOperatoreCaa : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("Collaboratore", "C"));
            Items.Add(new ListItem("Responsabile di sportello", "R"));
            base.OnDataBinding(e);
        }
    }

    public class ComboEntiBando : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            db = new DbProvider();
            CommandText = "SELECT COD_ENTE,DESCRIZIONE FROM ENTE WHERE EMISSIONE_BANDI=1 ORDER BY COD_TIPO_ENTE DESC";
            DataTextField = "DESCRIZIONE";
            DataValueField = "COD_ENTE";
            base.OnDataBinding(e);
        }
    }


    public class ComboBandiProcura : ComboSql
    {
        private int _IdImpresa;
        public int IdImpresa { set { _IdImpresa = value; } }
        protected override void OnDataBinding(EventArgs e)
        {
            db = new DbProvider();
            CommandText = @"SELECT DISTINCT ID_BANDO, DESCRIZIONE FROM vBANDO WHERE 
                            (DATA_APERTURA < GETDATE() AND DATA_SCADENZA > GETDATE()) 
                             OR (COD_STATO = 'L' and GETDATE()<= DATA_APERTURA ) OR ID_BANDO IN 
                            (SELECT DISTINCT ID_BANDO FROM vPROGETTO WHERE ID_IMPRESA = " + _IdImpresa.ToString() + @")  ORDER BY DESCRIZIONE";
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_BANDO";
            base.OnDataBinding(e);
        }
    }

    public class ComboConsulentiAzienda : ComboSql
    {
        private int _IdImpresa;
        public int IdImpresa { set { _IdImpresa = value; } }
        protected override void OnDataBinding(EventArgs e)
        {
            db = new DbProvider();
            CommandText = @"SELECT U.NOMINATIVO, U.ID_PERSONA_FISICA FROM vMANDATI_IMPRESA I
                            INNER JOIN vUTENTI U ON I.ID_UTENTE_ABILITATO = U.ID_UTENTE
                            WHERE I.ID_IMPRESA = " + _IdImpresa.ToString() + @" AND I.TIPO_MANDATO = 'PSR' AND I.ATTIVO = 1";
            DataTextField = "NOMINATIVO";
            DataValueField = "ID_PERSONA_FISICA";
            base.OnDataBinding(e);
        }
    }

    public class ComboAggregazione : ComboSql
    {
        private int _IdImpresa;
        public int IdImpresa { set { _IdImpresa = value; } }
        protected override void OnDataBinding(EventArgs e)
        {
            db = new DbProvider();
            CommandText = "select ID, DENOMINAZIONE from vAGGREGAZIONE WHERE  ATTIVO = 1 and IMPRESA_AGGREGAZIONE_ATTIVA = 1 and ID_IMPRESA = " + _IdImpresa.ToString();
            DataTextField = "DENOMINAZIONE";
            DataValueField = "ID";
            base.OnDataBinding(e);
        }
    }

    public class ComboImpreseAggregazione : ComboSql
    {
        private int _IdAggregazione;
        public int IdAggregazione { set { _IdAggregazione = value; } }
        protected override void OnDataBinding(EventArgs e)
        {
            db = new DbProvider();
            CommandText = "SELECT ID_IMPRESA, CODICE_FISCALE +' - '+RAGIONE_SOCIALE AS DESCRIZIONE_IMPRESA FROM vIMPRESA_AGGREGAZIONE where ATTIVO= 1 AND ID_AGGREGAZIONE = " + _IdAggregazione.ToString();
            DataTextField = "DESCRIZIONE_IMPRESA";
            DataValueField = "ID_IMPRESA";
            base.OnDataBinding(e);
        }
    }


    public class ComboCostiRNA : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_TIPO_SPESA,SPESA FROM RNA_TIPO_COSTO_AMMISSIBILE";
            DataTextField = "SPESA";
            DataValueField = "COD_TIPO_SPESA";
            base.OnDataBinding(e);
        }
    }
    public class ComboStrumentiRNA : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT COD_TIPO_STRUMENTO_AIUTO, STRUMENTO FROM RNA_STRUMENTI_DI_AIUTO";
            DataTextField = "STRUMENTO";
            DataValueField = "COD_TIPO_STRUMENTO_AIUTO";
            base.OnDataBinding(e);
        }
    }

    public class ComboAnno : ComboBase
    {
        private int _annoDa, _annoA;
        public int AnnoDa { set { _annoDa = value; } }
        public int AnnoA { set { _annoA = value; } }
        private SortDirection _sortDirection;
        public SortDirection SortDirection { set { _sortDirection = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            if (!this._noBlankItem) Items.Add(new ListItem("", ""));
            if (_sortDirection == SortDirection.Asc)
            {
                if (_annoDa <= 0) _annoDa = 2008;
                if (_annoA <= 0) _annoA = DateTime.Now.Year;
                for (int i = _annoDa; i < _annoA + 1; i++)
                    Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            else
            {
                if (_annoDa <= 0) _annoDa = DateTime.Now.Year;
                if (_annoA <= 0) _annoA = 2008;
                for (int i = _annoDa; i > _annoA - 1; i--)
                    Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            foreach (ListItem li in Items) if (li.Value == SelectedValue) { li.Selected = true; break; }
            base.OnDataBinding(e);
        }
    }

    public class ComboProgettiImpresa : ComboSql
    {
        private int _IdImpresa;
        public int IdImpresa { set { _IdImpresa = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT 'PROGETTO: ' + CAST(ID_PROGETTO AS varchar) AS DESCRIZIONE, ID_PROGETTO FROM PROGETTO WHERE ID_IMPRESA = " + _IdImpresa;
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_PROGETTO";
            base.OnDataBinding(e);
        }
    }

    public class ComboDomandePagamentoImpresa : ComboSql
    {
        private int _IdImpresa;

        public int IdImpresa { set { _IdImpresa = value; } }

        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "SELECT 'PROGETTO: ' + CAST(D.ID_PROGETTO AS varchar) + ' DOMANDA DI PAGAMENTO: ' + CAST(D.ID_DOMANDA_PAGAMENTO AS varchar) AS DESCRIZIONE, ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO D INNER JOIN PROGETTO P ON D.ID_PROGETTO = P.ID_PROGETTO WHERE P.ID_IMPRESA = " + _IdImpresa;
            DataTextField = "DESCRIZIONE";
            DataValueField = "ID_DOMANDA_PAGAMENTO";
            base.OnDataBinding(e);
        }
    }

    public enum SortDirection { Asc = 1, Desc = 2 }

    #region Registro_ritiri_recuperi

    public class ComboTipoOrigine : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("Irregolarità", "Irregolarità"));
            Items.Add(new ListItem("Errore", "Errore"));
            Items.Add(new ListItem("Rinuncia", "Rinuncia"));
            base.OnDataBinding(e);
        }
    }

    public class ComboTipoDetrazione : ComboBase
    {
        protected override void OnDataBinding(EventArgs e)
        {
            Items.Clear();
            Items.Add(new ListItem("", ""));
            Items.Add(new ListItem("NON ASSEGNATA", "NON ASSEGNATA"));
            Items.Add(new ListItem("CERTIFICAZIONE", "CERTIFICAZIONE"));
            Items.Add(new ListItem("CONTI", "CONTI"));
            base.OnDataBinding(e);
        }
    }

    public class ComboPeriodoContabile : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "select distinct  periodo_contabile from vregistro_ritiri_recuperi where PERIODO_CONTABILE is not null";
            DataTextField = "periodo_contabile";
            DataValueField = "periodo_contabile";
            base.OnDataBinding(e);
        }
    }

    public class ComboSoggettoRilevatore : ComboSql
    {
        protected override void OnDataBinding(EventArgs e)
        {
            CommandText = "select distinct  SOGGETTO_RILEVATORE from vregistro_ritiri_recuperi where SOGGETTO_RILEVATORE is not null";
            DataTextField = "SOGGETTO_RILEVATORE";
            DataValueField = "SOGGETTO_RILEVATORE";
            base.OnDataBinding(e);
        }
    }

    #endregion
    //FINE REGISTRO RITIRI RECUPERI

    #endregion
}






