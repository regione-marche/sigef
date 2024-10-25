<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="ValidazioneDomandePagamentoNew.aspx.cs" Inherits="web.Private.IPagamento.ValidazioneDomandePagamentoNew" %>

<%@ Register Src="~/CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<%@ Register Src="~/CONTROLS/ucSceltaChecklistValidazione.ascx" TagName="ucSceltaChecklist" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function SNCVZCercaUtenti_onselect(obj) { if (obj) { $('[id$=hdnIdUtenteSelezionato]').val(obj.IdUtente); $('[id$=txtValidatore_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtenteSelezionato]').val('');/*$('[id$=txtValidatore_text]').val('');*/ }
        function ctrlUtente(ev) { if ($('[id$=hdnIdUtenteSelezionato]').val() == '') { alert('E` necessario specificare un`operatore.'); return stopEvent(ev); } return true; }
        function disabilitaValidatore(id_validatore) { if (confirm('Attenzione! Disabilitare l`operatore selezionato?')) { $('[id$=hdnIdValidatore]').val(id_validatore); $('[id$=btnDisabilitaValidatore]').click(); } }
        function selezionaDomanda(id) { $('[id$=hdnIdDomanda]').val(id); $('[id$=btnPost]').click(); }

        function MostraModale(id_domanda) {
            $('[id$=hdnIdDomandaPagamento]').val(id_domanda);
            $('[id$=btnMostraModale_Click]').click();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdDomandaPagamento" Value="false" runat="server" />
        <asp:Button ID="btnMostraModale_Click" runat="server" OnClick="btnMostraModaleScelta_Click" CausesValidation="false" />
    </div>

    <div class="container-fluid mb-5 rounded-3 shadow" id="tabControlli" runat="server">
        <h2 class="pt-4">Verifiche amministrative dei tuoi bandi</h2>

        <div style="display: none">
            <asp:HiddenField ID="hdnIdUtenteSelezionato" runat="server" />
            <asp:HiddenField ID="hdnIdValidatore" runat="server" />
            <asp:Button ID="btnDisabilitaValidatore" runat="server" OnClick="btnDisabilitaValidatore_Click" />
        </div>

     
            <p class="fw-semibold pt-4">
                In questa pagina viene mostrato un breve riepilogo dello stato avanzamento delle 
        verifiche amministrativedomande di pagamento
        con il numero delle  pervenute, istruite e validate, e 
        l&#39;elenco degli operatori di validazione.
            </p>
            <div class="d-flex flex-row align-items-center py-3 bd-form rounded-3">
                <div class="col-sm-2">
                    <h5 class="active fw-semibold ps-3">Domande di pagamento</h5>
                </div>
                <div class="flex-column ps-3">
                    <label class="active fw-semibold" for="txtNrPagPervenute">Pervenute</label>
                    <Siar:IntegerTextBox ID="txtNrPagPervenute" runat="server" ReadOnly="True" />
                </div>
                <div class="flex-column px-3">
                    <label class="active fw-semibold" for="txtNrPagIstruite">Istruite</label>
                    <Siar:IntegerTextBox ID="txtNrPagIstruite" runat="server" ReadOnly="True" />
                </div>
                <div class="flex-column px-3">
                    <label class="active fw-semibold" for="txtNrPagValidate">Validate</label>
                    <Siar:IntegerTextBox ID="txtNrPagValidate" runat="server" ReadOnly="True" />
                </div>
            </div>
            <div id="trLotti" visible="false" class="d-flex flex-row align-items-center py-3 bd-form rounded-3">
                <div class="col-sm-2">
                    <h5 class="active fw-semibold ps-3">Lotti di controllo</h5>
                </div>
                <div class="flex-column px-3">
                    <label class="active fw-semibold" for="txtNrLottiTotali">Totale</label>
                    <Siar:IntegerTextBox ID="txtNrLottiTotali" runat="server" ReadOnly="True" />
                </div>
                <div class="flex-column px-3">
                    <label class="active fw-semibold" for="txtNrLottiEstratti">Campione estratto</label>
                    <Siar:IntegerTextBox ID="txtNrLottiEstratti" runat="server" ReadOnly="True" />
                </div>
                <div class="flex-column px-3">
                    <label class="active fw-semibold" for="txtNrLottiConclusi">Controllo concluso</label>
                    <Siar:IntegerTextBox ID="txtNrLottiConclusi" runat="server" ReadOnly="True" />
                </div>
            </div>
    
        <h4 class="fw-semibold pt-5">Nomina degli operatori di validazione</h4>

        <p class="fw-semibold pt-3">Selezionare il bando dalla lista e cercare l'operatore nella text box</p>
          <div class="d-flex flex-row rounded-3 align-items-center py-4 px-2 bd-form">
          <div class="col-sm-3">
                <label class="active fw-semibold" for="lstBandiRup">Selezionare il bando</label>
                <Siar:ComboBandiRup ID="lstBandiRup"  runat="server"></Siar:ComboBandiRup>
            </div>
             <div class="col-sm-3 px-3">
                <label class="active fw-semibold" for="txtValidatore">Digitare un nominativo</label>
                <Siar:TextBox  ID="txtValidatore"  runat="server" />
            </div>
           <div class="col-sm-1 px-3 pt-4">
                <asp:CheckBox ID="chkResponsabile" runat="server" CssClass="fw-semibold pt-4" Text="Responsabile" />
            </div>
         <div class="col-sm-2 px-3 pt-4">
                <Siar:Button ID="btnSalvaValidatore" runat="server" OnClick="btnSalvaValidatore_Click"
                    Text="Nomina" Modifica="True" OnClientClick="return ctrlUtente(event);" />
            </div>
        </div>


        <h4 class="fw-semibold pt-5">Elenco operatori assegnati</h4>
        <div class="d-flex flex-row align-items-center bf-form">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgOperatoriValidazione" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdBando" HeaderText="Bando"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Nominativo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInizio" HeaderText="Data nomina">
                            <ItemStyle Width="110px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Responsabile" HeaderText="Responsabile" DataFormatString="{0:SI|NO}">
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    
    
        <h4 class="fw-semibold pt-5">Selezione delle domande </h4>
        <p class="fw-semibold">Selezionare le domande dalla griglia per assegnarle all'operatore selezionato</p>

      <div class="d-flex flex-row align-items-center py-4 px-2 bg-100">
            <div class="col-sm-3">
                <label class="active fw-semibold" for="lstBandiRupValidatore">Selezionare il bando</label>
                <Siar:ComboBandiRup ID="lstBandiRupValidatore" AutoPostBack="true" runat="server"></Siar:ComboBandiRup>
            </div>
            <div class="col-sm-3 px-3">
                <label class="active fw-semibold" for="lstValidatoriBandoRup">Selezionare il validatore</label>
                <Siar:ComboBandiValidatoriRup ID="lstValidatoriBandoRup" runat="server"></Siar:ComboBandiValidatoriRup>
            </div>
            <div class="col-sm-2 px-3 pt-4">
                <Siar:Button ID="btnAssegnaDomande" runat="server" OnClick="btnAssegnaDomande_Click" Text="Assegna domande" Modifica="True" />
            </div>
        </div>

        <h5 class="fw-semibold pt-5 pb-3">Elenco Domande da Assegnare</h5>
        <div class="d-flex flex-row align-items-center">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgDomandeDaAssegnare" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="10">                   
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:CheckColumn DataField="IdDomandaPagamento" Name="chkAssocia" HeaderText="Associa al validatore">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:CheckColumn>
                        <Siar:NumberColumn>
                            <ItemStyle Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Bando"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Progetto">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Domanda pagamento">
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione domanda di pagamento"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CfIstruttore" HeaderText="Istruttore">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
             <div class="row"></div>
        </div>

    </div>
       

    
    
    <div class="container-fluid shadow rounded-3 py-4">
        <h3 class="fw-semibold py-2">Ricerca</h3>
       
        <asp:Label ID="lblInfoDomandeAssegnate" class="fw-semibold- pt-3" runat="server" />
      
        <div class="d-flex flex-row align-items-center py-4 px-2 bd-form">
            <div class="col-sm-2">
                <label class="active fw-semibold" for="txtIdProgetto">Digitare l'id del progetto</label>
                <Siar:TextBox ID="txtIdProgetto" runat="server" />
            </div>
            <div class="flex-column ps-3">
                <label class="active fw-semibold" for="lstValidatoriBandoRup">Digitare l'id della domanda di pagamento</label>
                <Siar:TextBox ID="txtIdDomanda" runat="server" />
            </div>
            <div class="col-sm-2 px-3 pt-4">
                <Siar:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click"
                    Text="Filtra" />
            </div>
        </div>
    </div>
    <div class="row row-no-margin pt-5">
        <div class="table-responsive">
            <Siar:DataGridAgid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                <HeaderStyle CssClass="headerStyle" />
                <ItemStyle CssClass="DataGridRow itemStyle" />
                <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                <Columns>
                    <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero domanda di aiuto">
                        <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Numero domanda di pagamento">
                        <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalit&#224; della richiesta">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--                        <asp:BoundColumn DataField="SelezionataXRevisione" DataFormatString="{0:SI|NO}" HeaderText="Estratta a campione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="NominativoValidatore" HeaderText="Validatore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Approvata" DataFormatString="{0:SI|NO}" HeaderText="Controllo positivo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--                        <asp:BoundColumn DataField="NumeroEstrazione" HeaderText="Numero estrazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="SegnaturaRevisione" HeaderText="Protocollo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Vai alla checklist di controllo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>

    <uc1:ucSceltaChecklist ID="modaleSceltaChecklist" runat="server" />
</asp:Content>
