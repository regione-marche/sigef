<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master" CodeBehind="Definizione.aspx.cs" Inherits="web.Private.Gantt.Definizione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <link href="gantt.css" rel="stylesheet" type="text/css">
    <div class ="Titolo2" style="padding:10px; margin-left:20px;">
        <br />
        <asp:Label  ID="lblAsse" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="lblAzione" runat="server"></asp:Label>
        <br /><br />
        <asp:Label ID="lblIntervento" runat="server"></asp:Label>
        <br /><br />
        <asp:Label  ID="lblBando" runat="server"></asp:Label>
        <br /><br />
        <asp:Label  ID="lblTipoOp" runat="server"></asp:Label>
        <br /><br />        
        <span>Importo complessivo: </span><asp:Label ID="lblImportoComplessivo" runat="server"></asp:Label>
        <span> &nbsp; &nbsp; &nbsp; &nbsp; IMPORTO FONDO FESR: </span><asp:Label ID="lblImporto" runat="server"></asp:Label>
        <br />
        <span>Importo già Certificato: </span><asp:Label ID="lblImportoCertificato" runat="server"></asp:Label>
        <span> &nbsp; &nbsp; &nbsp; &nbsp; Importo Finanziato: </span><asp:Label ID="lblImportoFinanziato" runat="server"></asp:Label>
    </div>
    
    <%--<br />
    <asp:Label ID="lblUO" runat="server"></asp:Label>--%>
    <asp:GridView CssClass="tabella" ID="grvPassi" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID_STEP" Visible="false" />
            <asp:BoundField HeaderText="Tipo" DataField="ID_TIPO_PASSO" Visible="false" />
            <asp:BoundField HeaderText="Tipo step" DataField="DESCRIZIONE" />
            <asp:BoundField HeaderText="UO/Ente di riferimento" DataField="UO_NOME" />
            <asp:BoundField HeaderText="Data inizio" HtmlEncode="false" DataField="DATA_INIZIO_PREVISTA" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="n.gg standard" DataField="NUM_GG_STANDARD" />
            <asp:BoundField HeaderText="Data fine" HtmlEncode="false" DataField="DATA_FINE_PREVISTA" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField HeaderText="Valore">
                <ItemTemplate>
                    <asp:Label ID="valorePrev" runat="server" Text='<%# String.Format("{0:" + Eval("VALORE_FORMATO") + "}", Eval("VALORE_PREVISTO")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Tipo valore" DataField="VALORE_NOME" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate> 
                    <a href='<%# "Definizione.aspx?deleteIDS=" + Eval("ID_STEP") + "" + "&idg=" + _idg %>' onclick="return confirm('Eliminare il passo?');">Elimina</a>
                    <a href='#' onclick="apriModalModifica({IdStep:<%# Eval("ID_STEP")%>, TipoPasso:<%# Eval("ID_TIPO_PASSO")%>, UO:<%# Eval("UO_PASSO")%>, NGGStandard:'<%# Eval("NUM_GG_STANDARD")%>', DtInizioPrev:'<%# String.Format("{0:yyyy-MM-dd}", Eval("DATA_INIZIO_PREVISTA")) %>', DtFinePrev:'<%# String.Format("{0:yyyy-MM-dd}", Eval("DATA_FINE_PREVISTA")) %>', ValorePrev:'<%# Eval("VALORE_PREVISTO")%>', ValorePattern:'<%# Eval("VALORE_PATTERN").ToString().Replace("\\", "\\\\") %>', valoreFormato:'<%# Eval("VALORE_FORMATO").ToString().Replace("\\", "\\\\") %>',NotaPrev:'<%# Eval("NOTA_PREVISTO").ToString().Replace("\\", "\\\\").Replace("'", "\\'") %>'})">Modifica</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <div class="rowFooter" style="width: 90%">
        <a id="goBack" class="bottone bottoneCancel" href="ElencoBandi.aspx" style="float: left">Indietro (Elenco Bandi)</a>
        <button type="button" class="bottone bottoneOK" id="btAddStep" style="float: left">Aggiungi Passo</button>
        <a id="salvaDefinitivo" class="bottone bottoneOK" onClick="return confirm('Rendere definitivo? Non sarà più modificabile')" href="<%= "Definizione.aspx?salvaDefIDG=" + _idg + "&idg=" + _idg %>">Salva come Definitivo</a>
        <a id="delGand" class="bottone bottoneCancel" onClick="return confirm('Eliminare?')" href="<%= "Definizione.aspx?eliminaIDG=" + _idg + "&idg=" + _idg %>">ELIMINA PIANIFICAZIONE</a>
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
    window.addEventListener("click", function(event){
        if (event.target == modal) {
            impostaValoriModal(null, null);
            modal.style.display = "none";
        }
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

</script>
    
</asp:Content>