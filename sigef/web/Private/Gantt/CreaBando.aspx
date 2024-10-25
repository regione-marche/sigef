<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="CreaBando.aspx.cs" Inherits="web.Private.Gantt.CreaBando" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    
    <script>
        function DropDownAsse() {
            $('[id$=hdnIdAsse]').val(document.getElementById('<%=edAsse.ClientID%>').value);
            $('[id$=hdnIdAzione]').val('0');
            $('[id$=hdnIdIntervento]').val('0');
//            $('[id$=btnDropDownAsse]').click();
        } 
        function DropDownAzione() {
            $('[id$=hdnIdAzione]').val(document.getElementById('<%=edAzione.ClientID%>').value);
            $('[id$=hdnIdIntervento]').val('0');
            //            $('[id$=btnDropDownAsse]').click();
        }
        function DropDownIntervento() {
            $('[id$=hdnIdIntervento]').val(document.getElementById('<%=edIntervento.ClientID%>').value);
            //            $('[id$=btnDropDownAsse]').click();
        }
    </script>
    <div style="display: none">
            <input type="hidden" id="hdnIdAsse" runat="server" />
            <input type="hidden" id="hdnIdAzione" runat="server" />
            <input type="hidden" id="hdnIdIntervento" runat="server" />
            
    </div>
    <link href="gantt.css" rel="stylesheet" type="text/css">
    <div>
          <div class="row">
              <div class="col-25">
                <label for="lbAsse">Asse:</label>
              </div>
          </div>
          <div class="row">
              <div class="col-75">
                  <asp:DropDownList ID="edAsse" DataValueField="ID" DataTextField="DESCRIZIONE" EnableViewState="false" runat="server" name="edAsse"
                     AutoPostBack="true"  onchange="DropDownAsse();" ></asp:DropDownList>
              </div>        
        </div>     
        <br />
          <div class="row">
              <div class="col-25">
                <label for="lbAzione">Azione:</label>
              </div>
          </div>
          <div class="row">
              <div class="col-75">
                  <asp:DropDownList ID="edAzione" DataValueField="ID" DataTextField="DESCRIZIONE" EnableViewState="false" runat="server" name="edAzione"
                  AutoPostBack="true" onchange="DropDownAzione();" ></asp:DropDownList>
              </div>        
        </div>    
        <br />
          <div class="row">
              <div class="col-25">
                <label for="lbAzione">Intervento:</label>
              </div>
          </div>
          <div class="row">
              <div class="col-75">
                  <asp:DropDownList ID="edIntervento" DataValueField="ID" DataTextField="DESCRIZIONE" EnableViewState="false" runat="server" name="edIntervento"
                  AutoPostBack="true"   onchange="DropDownIntervento();" ></asp:DropDownList>
              </div>        
        </div>             
        <br /><br />
        <div class="row">
            <div class="col-15">
                <label for="edNGGStandard">Oggetto:</label>
            </div>
            <div class="col-75">
                <asp:HiddenField runat="server" id="HedNGGStandard" />
                <textarea type="text" rows=3 id="txtOggetto" name="txtOggetto" runat="server" /></textarea>
            </div> 
            <div class="col-10">    
            </div>   
        </div><br />
        <div class="row">
              <div class="col-15">
                <label for="edValoreComplPrev">Importo Complessivo previsto:</label>
              </div>
        </div>
        <div class="row">
              <div class="col-25">
                <asp:HiddenField runat="server" id="HedValoreComplPrev" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValoreComplPrev" id="edValoreComplPrev" />
              </div>      
              <div class="col-10">    
              </div>     
         </div>   
         <br /><br />
        <div class="row">
              <div class="col-15">
                <label for="edValorePrev">Importo Fondo (FESR / FSE):</label>
              </div>
        </div>
        <div class="row">
              <div class="col-25">
                <asp:HiddenField runat="server" id="HedValorePrev" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValorePrev" id="edValorePrev" />
              </div>      
              <div class="col-10">    
              </div>     
         </div>   
         <br /><br />
        <div class="row">
              <div class="col-15">
                <label for="edValoreFinanziato">Importo Finanziato:</label>
              </div>
        </div>
        <div class="row">
              <div class="col-25">
                <asp:HiddenField runat="server" id="HedValoreFinanziato" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValoreFinanziato" id="edValoreFinanziato" />
              </div>      
              <div class="col-10">    
              </div>     
         </div>   
         <br /><br />
        <div class="row">
              <div class="col-15">
                <label for="edValoreCertificato">Importo già certificato:</label>
              </div>
        </div>
        <div class="row">
              <div class="col-25">
                <asp:HiddenField runat="server" id="HedValoreCertificato" />
                <input type="text" pattern="-?\d+(,\d{1,2})?" runat="server" name="edValoreCertificato" id="edValoreCertificato" />
              </div>      
              <div class="col-10">    
              </div>     
         </div>   
        
        
         <br /><br />
         <div class="row">
            <div class="col-25"  style="padding:5px;">
                <a id="goBack" class="bottone bottoneCancel" href="ElencoBandi.aspx" style="float: left">Indietro (Elenco Bandi)</a>
                <asp:LinkButton style="float: left" CssClass="bottone bottoneOK"  ID="bntSalvaBando"  runat="server" onclick="SalvaBando_click">Salva</asp:LinkButton>
            </div>
        </div>    
    </div>
</asp:Content>
