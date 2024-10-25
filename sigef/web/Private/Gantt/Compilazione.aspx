<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master" CodeBehind="Compilazione.aspx.cs" Inherits="web.Private.Gantt.Compilazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <link href="gantt.css" rel="stylesheet" type="text/css">
    <div class="Titolo2">
        <asp:Label ID="lblAsse" runat="server"></asp:Label><br /><br />
        <asp:Label ID="lblAzione" runat="server"></asp:Label><br /><br />
        <asp:Label ID="lblIntervento" runat="server"></asp:Label><br /><br />
        <asp:Label ID="LblBandoNome" runat="server"></asp:Label><br /><br />
        <asp:Label ID="lblTipoOp" runat="server"></asp:Label><br /><br />
        <asp:Label ID="lblUltimoAGg" runat="server"></asp:Label><br /><br />
        <span>Importo complessivo: </span><asp:Label ID="lblImportoComplessivo" runat="server"></asp:Label>
        <span> &nbsp; &nbsp; &nbsp; &nbsp; IMPORTO FONDO FESR: </span><asp:Label ID="lblImporto" runat="server"></asp:Label>
        <br />
        <span>Importo già Certificato: </span><asp:Label ID="lblImportoCertificato" runat="server"></asp:Label>
        <span> &nbsp; &nbsp; &nbsp; &nbsp; Importo Finanziato: </span><asp:Label ID="lblImportoFinanziato" runat="server"></asp:Label>
    </div>
    <asp:GridView CssClass="tabella" ID="grvPassi" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID_STEP" Visible="false" />
            <asp:BoundField HeaderText="Tipo" DataField="ID_TIPO_PASSO" Visible="false" />
            <asp:BoundField HeaderText="Tipo step" DataField="DESCRIZIONE" />
            <asp:BoundField HeaderText="UO/Ente di riferimento" DataField="UO_NOME" />
            <asp:BoundField HeaderText="Inizio previsto" HtmlEncode="false" DataField="DATA_INIZIO_PREVISTA" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Inizio effettivo">
                <ItemTemplate>
                    <input type="date" class="watchChange<%# (bool)Eval("IS_IN_DEFINIZIONE") ? " nascosto" : "" %>" data-id="<%#Eval("ID_STEP")%>" name='<%# String.Format("{0:st00000000-edDtInizio}",Eval("ID_STEP")) %>' id='<%# String.Format("{0:st00000000-edDtInizio}",Eval("ID_STEP")) %>' value='<%# String.Format("{0:yyyy-MM-dd}", Eval("DATA_INIZIO_EFFETTIVA")) %>' <%# ((bool)Eval("VALORE_AUTOMATICO") && (_ID_BANDO_BANDI > 0)) ? " disabled" : "" %> />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="n.gg" DataField="NUM_GG_STANDARD" />
            <asp:BoundField HeaderText="Fine prevista" HtmlEncode="false" DataField="DATA_FINE_PREVISTA" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Fine effettiva">
                <ItemTemplate>
                    <input type="date" class="watchChange<%# (bool)Eval("IS_IN_DEFINIZIONE") ? " nascosto" : "" %>" data-id="<%#Eval("ID_STEP")%>" name='<%# String.Format("{0:st00000000-edDtFine}",Eval("ID_STEP")) %>' id='<%# String.Format("{0:st00000000-edDtFine}",Eval("ID_STEP")) %>' value='<%# String.Format("{0:yyyy-MM-dd}", Eval("DATA_FINE_EFFETTIVA")) %>' <%# ((bool)Eval("VALORE_AUTOMATICO") && (_ID_BANDO_BANDI > 0)) ? " disabled" : "" %> />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ritardo">
                <ItemTemplate>
                    <span style="color:Red" class="<%# (bool)Eval("IS_IN_DEFINIZIONE") ? "nascosto" : "" %>"><%# CalcolaRitardo(Eval("DATA_FINE_PREVISTA"), Eval("DATA_FINE_EFFETTIVA"))%></span>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Valore previsto">
                <ItemTemplate>
                    <asp:Label ID="lblValorePrev" runat="server" Text='<%# String.Format("{0:" + Eval("VALORE_FORMATO") + "}", Eval("VALORE_PREVISTO")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valore effettivo">
                <ItemTemplate>
                    <input type="text" class="watchChange<%# (bool)Eval("IS_IN_DEFINIZIONE") || !(bool)Eval("FLAG_VALORE") ? " nascosto" : "" %>" data-id="<%#Eval("ID_STEP")%>" pattern='<%# Eval("VALORE_PATTERN")%>' name='<%# String.Format("{0:st00000000-edValore}",Eval("ID_STEP")) %>' id='<%# String.Format("{0:st00000000-edValore}",Eval("ID_STEP")) %>' value='<%# String.Format("{0:" + Eval("VALORE_FORMATO") + "}", Eval("VALORE_EFFETTIVO")) %>' <%# ((bool)Eval("VALORE_AUTOMATICO") && (_ID_BANDO_BANDI > 0)) ? " disabled" : "" %> />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nota prev.">
                <ItemTemplate>
                    <img alt="Visualizza Nota" class="<%# Eval("NOTA_PREVISTO") != DBNull.Value ? "" : "nascosto" %>" src="../../images/ifInfo24.png" onclick="javascript:alert('<%# Eval("NOTA_PREVISTO") != DBNull.Value ? ((string)Eval("NOTA_PREVISTO")).Replace("\\","\\\\").Replace("'","\\'") : "" %>')" />
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:BoundField HeaderText="Tipo valore" DataField="VALORE_NOME" Visible="false" />
            <asp:TemplateField HeaderText="Nota">
                <ItemTemplate>
                    <input type="text" class="watchChange nascosto" data-id="<%#Eval("ID_STEP")%>" id='<%# String.Format("{0:st00000000-edNota}",Eval("ID_STEP")) %>' name='<%# String.Format("{0:st00000000-edNota}",Eval("ID_STEP")) %>' value='<%# Eval("NOTA") %>' />
                    <img alt="Visualizza Nota" class="<%# (bool)Eval("IS_IN_DEFINIZIONE") ? " nascosto" : "" %>" src="../../images/<%# (Eval("NOTA") == DBNull.Value || Eval("NOTA").ToString() == "") ? "ifAdd24.png" : "ifInfo24.png" %>" onclick="javascript:apriEditNota(<%# Eval("ID_STEP") %>)" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate> 
                    <a class='<%# (bool)Eval("IS_IN_DEFINIZIONE") ? "" : "nascosto" %>' href='<%# "Compilazione.aspx?deleteIDS=" + Eval("ID_STEP") + "&idg=" + _idg %>' onclick="return confirm('Eliminare il passo?');"><img src="../../images/ifDel24.png" alt="Elimina" /></a>
                    <a class='<%# (bool)Eval("IS_IN_DEFINIZIONE") ? "" : "nascosto" %>' href='#' onclick="apriModalModifica({IdStep:<%# Eval("ID_STEP")%>, TipoPasso:<%# Eval("ID_TIPO_PASSO")%>, UO:<%# Eval("UO_PASSO")%>, NGGStandard:'<%# Eval("NUM_GG_STANDARD")%>', DtInizioPrev:'<%# String.Format("{0:yyyy-MM-dd}", Eval("DATA_INIZIO_PREVISTA")) %>', DtFinePrev:'<%# String.Format("{0:yyyy-MM-dd}", Eval("DATA_FINE_PREVISTA")) %>', ValorePrev:'<%# Eval("VALORE_PREVISTO")%>', ValorePattern:'<%# Eval("VALORE_PATTERN").ToString().Replace("\\", "\\\\") %>', valoreFormato:'<%# Eval("VALORE_FORMATO").ToString().Replace("\\", "\\\\") %>',NotaPrev:'<%# Eval("NOTA_PREVISTO").ToString().Replace("\\", "\\\\").Replace("'", "\\'") %>'})"><img src="../../images/ifEdit24.png" alt="Modifica" /></a>
                    <a class='<%# (bool)Eval("IS_IN_DEFINIZIONE") ? "" : "nascosto" %>' href='<%# "Compilazione.aspx?salvaDefIDS=" + Eval("ID_STEP") + "&idg=" + _idg %>' onclick="return confirm('Rendere il passo definitivo?');"><img src="../../images/ifCheck24.png" alt="Rendi definitivo" /></a>
                    <a class='<%# (!(bool)Eval("IS_IN_DEFINIZIONE")) && (Int32.Parse(String.Format("{0:yyyy}", Eval("DATA_FINE_PREVISTA"))) >= 2019)  ? "" : "nascosto" %>' href='<%# "Compilazione.aspx?riportaInDef=" + Eval("ID_STEP") + "&idg=" + _idg %>' onclick="return confirm('Ridefinire il passo?');"><img src="../../images/ifEdit24.png" alt="Ridefinisci" /></a>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>
    
    <div class="rowFooter" style="width: 90%">
        <a id="goBack" class="bottone bottoneCancel" href="ElencoBandi.aspx" style="float: left">Indietro (Elenco Bandi)</a>
        <button type="button" class="bottone bottoneOK" id="btAddStep" style="float: left">Aggiungi Passo</button>
        <a id="btAggiornato" class="bottone bottoneOK" href='<%= "Compilazione.aspx?idg=" + _idg.ToString() + "&agg=1" %>'>Certifica aggiornamento bimestrale</a>
        <a id="btSalva" class="bottone bottoneOK" onClick="salvaDati();">Salva Passi</a>
        <input type="hidden" id="HStepModificatiList" name="HStepModificatiList" value="" />
    </div>
  
  <div id="modalNota" class="modal">
    <div id="modalNotaContent" class="modal-content">
        <div class="row">
        <input type="hidden" id="modalNota_HedIDStep" />
        <input type="text" size="3" id="modalNota_edNotaStep" />
        </div>
        <div class="rowFooter">
            <a id="cancelModalNota" href="#" onclick="chiudiEditNota()" class="bottone bottoneCancel">Annulla</a>
            <a id="okModalNota" href="#" class="bottone bottoneOK" onclick="salvaEditNota()">Salva</a>
        </div>        
    </div>
  </div>
    
  <div id="modalEdit" class="modal">
    <div id="modalEditContent" class="modal-content">
        <asp:HiddenField runat="server" id="HedIDStep" />
        <div class="row">
          <div class="col-25">
            <label for="edTipoPasso">Tipo Passo:</label>
          </div>
          <div class="col-75">
              <asp:DropDownList ID="edTipoPasso" EnableViewState="false" runat="server"></asp:DropDownList>
          </div>        
        </div>
        <div class="row">
          <div class="col-25">
            <label for="edTipoPasso">UO/Ente di riferimento:</label>
          </div>
          <div class="col-75">
              <asp:DropDownList ID="edUO" EnableViewState="false" runat="server"></asp:DropDownList>
          </div>        
        </div>        
        <div class="row">
          <div class="col-25">
            <label for="edNGGStandard">Numero gg. standard:</label>
          </div>
          <div class="col-75">
            <asp:HiddenField runat="server" id="HedNGGStandard" />
            <input type="number" id="edNGGStandard" name="edNGGStandard" />
          </div>        
        </div>         
        <div class="row">
          <div class="col-25">
            <label for="edDtInizioPrev">Data inizio prevista:</label>
          </div>
          <div class="col-75">
             <asp:HiddenField runat="server" id="HedDtInizioPrev" />
             <input type="date" name="edDtInizioPrev" id="edDtInizioPrev" required />
          </div>        
        </div>    
        <div class="row">
          <div class="col-25">
            <label for="edDtFinePrev">Data fine prevista:</label>
          </div>
          <div class="col-75">
            <asp:HiddenField runat="server" id="HedDtFinePrev" />
            <input type="date" name="edDtFinePrev" id="edDtFinePrev" required />
          </div>        
        </div>
        <div class="row">
          <div class="col-25">
            <label for="edValorePrev">Valore previsto (<span id="edValoreUM">-</span>):</label>
          </div>
          <div class="col-75">
            <asp:HiddenField runat="server" id="HedValorePrev" />
            <input type="text"  name="edValorePrev" id="edValorePrev" />
          </div>        
        </div>    
        <div class="row">
          <div class="col-25">
            <label for="edNotaPrev">Nota:</label>
          </div>
          <div class="col-75">
            <asp:HiddenField runat="server" id="HedNotaPrev" />
            <input type="text"  name="edNotaPrev" id="edNotaPrev" />
          </div>        
        </div>               
        <div class="rowFooter">
            <a id="cancelModal" href="#" class="bottone bottoneCancel">Annulla</a>
            <asp:LinkButton CssClass="bottone bottoneOK"  ID="btSalvaModal" OnClientClick="return validaDatiModal()" runat="server" onclick="btSalvaModal_Click">Salva</asp:LinkButton>
        </div>
    </div>
    </div>    
    
    
<script type="text/jscript">

/***************************************************************************************/
/* funzioni di impostazione iniziali: EXPLORER ed eventi di window per gestione modali */
/***************************************************************************************/

(function() {
    if ( typeof window.CustomEvent === "function" ){
    }
    else{
        //  INTERNET EXPLORER
        function CustomEvent (event, params) {
            params = params || { bubbles: false, cancelable: false, detail: undefined };
            var evt = document.createEvent( 'CustomEvent' );
            evt.initCustomEvent( event, params.bubbles, params.cancelable, params.detail );
            return evt;
        }
        CustomEvent.prototype = window.Event.prototype;
        window.Event  = CustomEvent;    
    }
    
    // chiusura modali edit nota ed add. steps su click nella finestra
    window.addEventListener("click", function(event){
        var modal = document.getElementById('modalEdit');
        if (event.target == modal) {
            impostaValoriModal(null, null);
            modal.style.display = "none";
        }
        var modalNota = document.getElementById('modalNota');
        if (event.target == modalNota) {
            document.getElementById('modalNota_edNotaStep').value = "";
            modalNota.style.display = "none";
        }
    });   
    
    
})();

/*******************************************************************************/
/* JS per compilazione STEPS definitivi (passi con flag IS_IN_DEFINIZIONE = 0) */
/*******************************************************************************/

var stepModificatiList = new Array();

function salvaDati(){
    var HStepModificatiList = document.getElementById("HStepModificatiList");
    if (!stepModificatiList || stepModificatiList.length <=0){
        alert('Nessun dato modificato da salvare');
        return;
    } 
    for (i=0; i < stepModificatiList.length; i++)
        if (stepModificatiList[i] == 1){
            if (HStepModificatiList.value) HStepModificatiList.value = HStepModificatiList.value + "#";
            HStepModificatiList.value = HStepModificatiList.value + i;
        } 
    
    var formData = new FormData(document.forms[0]);
      $.ajax({
        url: "Compilazione.aspx?idg=<%=_idg %>",
        type: 'POST',
        data: formData,
        async: false,
        cache: false,
        contentType: false,
        processData: false,
        success: function (msg) {
            if (msg == "") {
                window.location = "Compilazione.aspx?idg=<%=_idg %>";
            }
            else
                alert(msg);
        }
      });    
}

function validaDati(){
    return true;
}

/* Funzioni per modale edit nota */
function apriEditNota(idStepNota){
    var modal = document.getElementById('modalNota');
    event.preventDefault();
    document.getElementById('modalNota_HedIDStep').value = idStepNota;
    var inputNotaStep = document.getElementById("st" + (("0000000" + idStepNota).slice(-8)) + "-edNota");
    if (inputNotaStep.value != "undefined") document.getElementById('modalNota_edNotaStep').value = inputNotaStep.value;
    else document.getElementById('modalNota_edNotaStep').value = "";
    modal.style.display = "block";    
}
function chiudiEditNota(){
    var modalNota = document.getElementById('modalNota');
    event.preventDefault()
    document.getElementById('modalNota_edNotaStep').value = "";
    modalNota.style.display = "none";   
}
function salvaEditNota(){
    var modalNota = document.getElementById('modalNota');
    var idStepNota = document.getElementById('modalNota_HedIDStep').value;
    var inputNotaStep = document.getElementById("st" + (("0000000" + idStepNota).slice(-8)) + "-edNota");
    inputNotaStep.value = document.getElementById('modalNota_edNotaStep').value;
    // scatena evento change in textbox di nota (nascosta) dello step idStepNota
    var event = new Event('change');
    inputNotaStep.dispatchEvent(event);
    // chiude la modale
    document.getElementById('modalNota_edNotaStep').value = "";
    modalNota.style.display = "none";       
}

(function() {
    var campiVariabili = document.getElementsByClassName('watchChange');
    for (index = 0; index < campiVariabili.length; ++index) {
        //var idSpetModString = campiVariabili[index].id.substr(2,8);
        //var idSpetMod = parseInt(idSpetModString);
        //var nomeProperty = campiVariabili[index].id.substr(11);
        //var idSpetMod = campiVariabili[index].dataset.id;
        campiVariabili[index].addEventListener("change", function(event){
            stepModificatiList[this.dataset.id] = 1;   // modificato
        }); 
    }
})();

/****************************************************************************************************************/
/* JS per definizione STEPS in fase di compilazione --> IS_IN_DEFINIZIONE = 1 finché non li si rende definitivi */
/****************************************************************************************************************/

var tipiPassiList = new Array();
<%= _arrayJSTipiPassiList %>


function formatNumber(valore, formato){
    switch(formato){
        case "#0":
            return (Number(valore.replace(",","."))).toFixed(0).replace(".",",");
            break;
        case "#0.00":
            return (Number(valore.replace(",","."))).toFixed(2).replace(".",",");
            break;
        case "#0.0":
            return (Number(valore.replace(",","."))).toFixed(1).replace(".",",");  
            break;
        default:
            return (Number(valore.replace(",","."))).toFixed(2).replace(".",",");
            break;
    }
}

/*
    oggettoValori composto dagli attirbuti: IdStep, TipoPasso, NGGStandard, DtInizioPrev, DtFinePrev, ValorePrev, valoreFormato
*/
function impostaValoriModal(oggettoValori, defaultUO){
    var event = new Event('change');
    // id
    document.getElementById('<%=HedIDStep.ClientID%>').value = (oggettoValori ? oggettoValori.IdStep : "");
    // tipo
    if (oggettoValori) document.getElementById('<%=edTipoPasso.ClientID%>').value = oggettoValori.TipoPasso;
    else document.getElementById('<%=edTipoPasso.ClientID%>').selectedIndex = -1;
    document.getElementById('<%=edTipoPasso.ClientID%>').dispatchEvent(event);
    // UO
    if (oggettoValori) document.getElementById('<%=edUO.ClientID%>').value = oggettoValori.UO;
    else {
        if (defaultUO) document.getElementById('<%=edUO.ClientID%>').value = defaultUO; 
        else  document.getElementById('<%=edUO.ClientID%>').selectedIndex = -1;    
    }
    document.getElementById('<%=edUO.ClientID%>').dispatchEvent(event);
    // altri campi
    document.getElementById('edNGGStandard').value = (oggettoValori ? oggettoValori.NGGStandard : "");
    document.getElementById('edNGGStandard').dispatchEvent(event);
    document.getElementById('edDtInizioPrev').value = (oggettoValori ? oggettoValori.DtInizioPrev : "");
    document.getElementById('edDtInizioPrev').dispatchEvent(event);
    document.getElementById('edDtFinePrev').value = (oggettoValori ? oggettoValori.DtFinePrev : "");
    document.getElementById('edDtFinePrev').dispatchEvent(event);
    document.getElementById('edValorePrev').value = ((oggettoValori && oggettoValori.ValorePrev) ? formatNumber(oggettoValori.ValorePrev, oggettoValori.valoreFormato) : "");
    document.getElementById('edValorePrev').pattern = (oggettoValori ? oggettoValori.ValorePattern : "");
    document.getElementById('edValorePrev').dispatchEvent(event);
    document.getElementById('edNotaPrev').value = (oggettoValori ? oggettoValori.NotaPrev : "");
    document.getElementById('edNotaPrev').dispatchEvent(event);
}

function apriModalModifica(oggettoValori){
    var modal = document.getElementById('modalEdit');
    event.preventDefault();
    impostaValoriModal(oggettoValori, null);
    modal.style.display = "block";
}

function validaDatiModal(){
    var nodes = document.querySelectorAll("#modalEditContent input");
    var msgErrore = "";
    if (document.getElementById('<%=edTipoPasso.ClientID%>').selectedIndex < 0) msgErrore = "Selezionare il tipo di passo";
    if (document.getElementById('<%=edUO.ClientID%>').selectedIndex < 0) msgErrore = "Selezionare la UO di riferimento per il passo";
    for (var i=0; (msgErrore == "" && i<nodes.length); i++){
        var node=nodes[i];
        if (!node.checkValidity()) {
            msgErrore = "Ci sono dati mancanti o errati";
        }
    }
    if (msgErrore != ""){
        alert(msgErrore);
        return false;
    } else
    return true;
}

(function() {

//    if ( typeof window.CustomEvent === "function" ){
//    }
//    else{
//        //  INTERNET EXPLORER
//        function CustomEvent (event, params) {
//            params = params || { bubbles: false, cancelable: false, detail: undefined };
//            var evt = document.createEvent( 'CustomEvent' );
//            evt.initCustomEvent( event, params.bubbles, params.cancelable, params.detail );
//            return evt;
//        }
//        CustomEvent.prototype = window.Event.prototype;
//        window.Event  = CustomEvent;    
//    }

    var modal = document.getElementById('modalEdit');
    var btn = document.getElementById('btAddStep');
    var chiudiModale = document.getElementById('cancelModal');
    btn.onclick = function() {
        impostaValoriModal(null, <%= _idUO_Utente %>);
        modal.style.display = "block";
    }
    chiudiModale.addEventListener("click", function(event){
        event.preventDefault()
        impostaValoriModal(null, null);
        modal.style.display = "none";
    });
    
    var modalTipoPasso = document.getElementById('<%=edTipoPasso.ClientID%>');
    var modalUO = document.getElementById('<%=edUO.ClientID%>');
    var modalNGGStandard = document.getElementById('edNGGStandard');
    var modalDtInizioPrev = document.getElementById('edDtInizioPrev');
    var modalDtFinePrev = document.getElementById('edDtFinePrev');
    var modalValorePrev = document.getElementById('edValorePrev'); 
    var modalNotaPrev = document.getElementById('edNotaPrev'); 
    var modalValoreUM = document.getElementById('edValoreUM');
    // gg standard non sono modificabili
    modalNGGStandard.readOnly = true;
    
    modalTipoPasso.addEventListener("change", function(event){
        // imposta modalNGGStandard, unità misura del valore ed attivazione valore in base a tipiPassiList[modalTipoPasso.SelectedValue]
        // tipiPassiList[10] = {'DESCRIZIONE': 'Istituzione dei capitoli', 'NUM_GG_STANDARD': '', 'VALORE_NOME' : '', 'VALORE_FORMATO' : '', 'VALORE_PATTERN' : '' };
        if (modalTipoPasso.value){
            if (tipiPassiList[modalTipoPasso.value].NUM_GG_STANDARD) {
                modalNGGStandard.disabled = false;
                modalNGGStandard.value = tipiPassiList[modalTipoPasso.value].NUM_GG_STANDARD;
            }
            else{
                modalNGGStandard.disabled = true;
                modalNGGStandard.value = "";
            }
            var event = new Event('change');
            document.getElementById('edNGGStandard').dispatchEvent(event);
            
            modalValoreUM.textContent = tipiPassiList[modalTipoPasso.value].VALORE_NOME;
            if (tipiPassiList[modalTipoPasso.value].VALORE_NOME) {
                modalValorePrev.disabled = false;
                modalValorePrev.pattern = tipiPassiList[modalTipoPasso.value].VALORE_PATTERN;
                modalValorePrev.required = "required";
            }
            else{
                modalValorePrev.value = "";
                modalValorePrev.disabled = true;
                modalValorePrev.removeAttribute("required");
            } 
            var event = new Event('change');
            document.getElementById('edValorePrev').dispatchEvent(event);
        }
    });

    
    modalNGGStandard.addEventListener("change", function(event){
        document.getElementById('<%=HedNGGStandard.ClientID%>').value = modalNGGStandard.value;
    });    
    
    modalDtInizioPrev.addEventListener("change", function(event){
        document.getElementById('<%=HedDtInizioPrev.ClientID%>').value = modalDtInizioPrev.value;
        // imposta data fine in base a tipiPassiList[modalTipoPasso.SelectedValue]
    });    

    modalDtFinePrev.addEventListener("change", function(event){
        document.getElementById('<%=HedDtFinePrev.ClientID%>').value = modalDtFinePrev.value;
    });  
    
    modalValorePrev.addEventListener("change", function(event){
        document.getElementById('<%=HedValorePrev.ClientID%>').value = modalValorePrev.value;
    });   

    modalNotaPrev.addEventListener("change", function(event){
        document.getElementById('<%=HedNotaPrev.ClientID%>').value = modalNotaPrev.value;
    });       
    
})();

</script>    
    
</asp:Content>