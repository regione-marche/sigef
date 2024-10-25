<%@ Page Language="C#" MasterPageFile="~/SiarPage.master"  AutoEventWireup="true" CodeBehind="ElencoBandi.aspx.cs" Inherits="web.Private.Gantt.ElencoBandi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
<link href="gantt.css" rel="stylesheet" type="text/css" />
<div id="ricerca" style="margin-bottom: 40px;">
    <div class="row">
      <div class="col-25">
        <label for="selBando" visible="false">Cerca Bando</label>
      </div>
      <div class="col-75">
        <asp:TextBox CssClass="rounded" runat="server" id="srcBando" name="srcBando" style="width: 95%"></asp:TextBox>
      </div>
    </div>    
    <div class="row">
      <div class="col-25">
        <label for="selBando" visible="false">Asse:</label>
      </div>
      <div class="col-75">
        <asp:DropDownList runat="server" ID="srcAsse" name="srcAsse" style="width: 95%">
            <asp:ListItem Text="" Value=""></asp:ListItem>
            <asp:ListItem Value="1" Text="1. Rafforzare la ricerca, lo sviluppo tecnologico e l`innovazione"></asp:ListItem>
            <asp:ListItem Value="2" Text="2. Migliorare l'accesso alle tecnologie dell'informazione"></asp:ListItem>
            <asp:ListItem Value="3" Text="3. Promuovere la competitività delle piccole e medie imprese"></asp:ListItem>
            <asp:ListItem Value="41" Text="4. Sostenere la transizione verso un'economia a basse emissioni di carbonio in tutti i settori"></asp:ListItem>
            <asp:ListItem Value="42" Text="5. Promuovere l'adattamento al cambiamento climatico, la prevenzione e gestione dei rischi"></asp:ListItem>
            <asp:ListItem Value="43" Text="6. Tutelare l'ambiente e promuovere l'uso efficiente delle risorse"></asp:ListItem>
            <asp:ListItem Value="44" Text="7. Assistenza Tecnica"></asp:ListItem>
            <asp:ListItem Value="217" Text="8. ASSE 8"></asp:ListItem>
            <asp:ListItem Value="161" Text="1. FSE - Occupazione"></asp:ListItem>
            <asp:ListItem Value="162" Text="2. FSE - Inclusione sociale e lotta alla povertà"></asp:ListItem>
            <asp:ListItem Value="163" Text="3. FSE - Istruzione e formazione"></asp:ListItem>
            <asp:ListItem Value="164" Text="4. FSE - Capacità istituzionale e amministrativa"></asp:ListItem>
            <asp:ListItem Value="165" Text="5. FSE - Assistenza Tecnica"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </div>        
    <div style="padding:10px 20px">
        <asp:LinkButton runat="server" ID="btCerca" cssclass="bottone bottoneOK" Text="Esegui Ricerca" onclick="btCerca_Click"></asp:LinkButton>
    </div>    
</div>
<div id="elencoBandi">
    <asp:GridView ID="grvBandi" CssClass="tabella" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID Bando" DataField = "ID_BANDO" />
            <asp:BoundField HeaderText="Intervento" DataField = "CODICE_INTERVENTO" />
            <asp:BoundField HeaderText="Descrizione" DataField="DESCRIZIONE" />
            <asp:BoundField HeaderText="Stato" DataField="NOME" />
            <asp:TemplateField HeaderText="ACT">
                <ItemTemplate>
                    <a ID="cmdCrea" href='#' onclick='apriModalCrea(<%# Eval("ID_BANDO")%>); return false' style='<%# ((int)(Eval("ID_STATO")) < 0) ? "" : "display: none" %>'>Crea</a>
                    <asp:HyperLink ID="cmdDefinisci" runat="server" NavigateUrl='<%# Eval("ID_GANTT", "Definizione.aspx?idg={0}") %>' Text="Definisci" Visible='<%# (int)(Eval("ID_STATO")) == 0 %>'></asp:HyperLink>
                    <asp:HyperLink ID="cmdCompila" runat="server" NavigateUrl='<%# Eval("ID_GANTT", "Compilazione.aspx?idg={0}") %>' Text="Compila" Visible='<%# (int)(Eval("ID_STATO")) == 1 %>'></asp:HyperLink>
                    <asp:HyperLink ID="cmdConsulta" runat="server" NavigateUrl='<%# Eval("ID_GANTT", "Lettura.aspx?idg={0}") %>' Text="Consulta" Visible='<%# (int)(Eval("ID_STATO")) >= 2 %>'></asp:HyperLink>
                    <asp:HyperLink ID="cmdModifica" runat="server" NavigateUrl='<%# Eval("ID_BANDO", "ModificaBando.aspx?idbandogantt={0}") %>' Text="Modifica" Visible='<%# (int)(Eval("ID_STATO")) == 0 || (int)(Eval("ID_STATO")) == 1 %>'></asp:HyperLink>
                    <asp:HyperLink ID="cmdElimina" runat="server" NavigateUrl='<%# Eval("ID_BANDO", "ModificaBando.aspx?idbandogantt={0}&del=1") %>' Text="Elimina" Visible='<%# ((int)(Eval("ID_STATO")) + (int)(Eval("ESISTONO_STEPS"))) <= 0 %>' onclick="return confirm('Sei sicuro di eliminare il bando e la relativa pianificazione?')"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>   
    <div class="rowFooter" style="padding:20px;">
        <a id="btnEstraiXls" runat="server" class="bottone bottoneRpt" >Certificabile e Consuntivo FESR Excel</a>
        <!--<a id="viewCertPerAnno" class="bottone bottoneRpt" href="StampaReportGantt.aspx?rpt=1">Certificabile per Anno FESR</a>-->
        <a id="viewSteps" class="bottone bottoneRpt" href="StampaReportGantt.aspx?rpt=2&nomeBandoLike=<%=m_srcBando%>&asseID=<%=m_srcAsse%>">Step con Ritardi</a>
        <a id="viewAggBimestrale" class="bottone bottoneRpt" href="StampaReportGantt.aspx?rpt=3">Aggiornamenti Bimestrali</a>
        <a id="goBack" class="bottone bottoneOK" href="CreaBando.aspx">Crea nuovo Intervento</a>
    </div>
</div>

<div id="modalCrea" class="modal">
    <div id="modalEditContent" class="modal-content">
        <input type="hidden" id="HedIDBando" />
        <div class="row">
          <div class="col-25">
            <label for="edTipoPasso">Tipo Operazione:</label>
          </div>
          <div class="col-75">
              <asp:DropDownList ID="edTipoOperazione" DataValueField="ID_TIPOOP" DataTextField="NOME_TIPOOP" EnableViewState="false" runat="server" name="edTipoOperazione"></asp:DropDownList>
          </div>        
        </div>        
        <div class="rowFooter">
            <a id="cancelModal" href="#" class="bottone bottoneCancel">Annulla</a>
            <a class="bottone bottoneOK" href=""  id="btSalvaModal" onClick="creaGanttDaModal(); return false;">Salva</a>
        </div>        
    </div>
</div>

<script  type="text/jscript">

    function apriModalCrea(idBando) {
        //var id = event.target;
        //if(event) event.preventDefault();
        var modal = document.getElementById('modalCrea');
        document.getElementById('HedIDBando').value = idBando;
        modal.style.display = "block";
    }

function creaGanttDaModal(){
    //if (event) event.preventDefault();
    if (document.getElementById('<%=edTipoOperazione.ClientID%>').selectedIndex < 0) {
        alert("Selezionare il Tipo Operazione");
        return false;
    }
    var idTipoOp = document.getElementById('<%=edTipoOperazione.ClientID%>').value;
    var idB = document.getElementById('HedIDBando').value;
    window.location = "ElencoBandi.aspx?creaIDB="+idB+"&tipoOp="+idTipoOp;
}


(function() {
    var modal = document.getElementById('modalCrea');
    var chiudiModale = document.getElementById('cancelModal');
    chiudiModale.addEventListener("click", function(event){
        event.preventDefault()
        document.getElementById('HedIDBando').value = "";
        modal.style.display = "none";
    });
    window.addEventListener("click", function(event){
        if (event.target == modal) {
            document.getElementById('HedIDBando').value = "";
            modal.style.display = "none";
        }
    });
})();

</script>

</asp:Content>