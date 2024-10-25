<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ValidazioneDomandeFemNew.aspx.cs" Inherits="web.Private.Fem.ValidazioneDomandeFemNew" %>

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

    <div class="dBox" id="tabControlli" runat="server">
        <div class="separatore">
            CONTROLLI DI VALIDAZIONE DEI TUOI BANDI
                 <div style="display: none">
                     <asp:HiddenField ID="hdnIdUtenteSelezionato" runat="server" />
                     <asp:HiddenField ID="hdnIdValidatore" runat="server" />
                     <asp:Button ID="btnDisabilitaValidatore" runat="server" OnClick="btnDisabilitaValidatore_Click" />
                 </div>
            <br />
        </div>
        <div style="padding: 15px;">
            <div class="testo_pagina">
                In questa pagina viene mostrato un breve riepilogo dello stato avanzamento dei 
                controlli di validazione documentali,<br />
                con il numero delle domande di pagamento pervenute, istruite e validate, e 
                l&#39;elenco degli operatori di validazione.
            </div>
            <div>
                <div style="width: 100%; text-align: center;">
                    <div style="width: 154px; vertical-align: bottom">
                        <b>Domande di pagamento:</b>
                    </div>
                    <div style="width: 170px; display: inline-block; padding-right: 15px;">
                        <br />
                        Pervenute:<br />
                        <Siar:IntegerTextBox ID="txtNrPagPervenute" runat="server" Width="119px" ReadOnly="True" />
                    </div>
                    <div style="width: 170px; display: inline-block; padding-right: 15px;">
                        <br />
                        Istruite:<br />
                        <Siar:IntegerTextBox ID="txtNrPagIstruite" runat="server" Width="119px" ReadOnly="True" />
                    </div>
                    <div style="display: inline-block; padding-right: 15px;">
                        <br />
                        Validate:<br />
                        <Siar:IntegerTextBox ID="txtNrPagValidate" runat="server" Width="119px" ReadOnly="True" />
                    </div>
                    <div runat="server" id="trLotti" visible="false">
                        <div style="width: 154px; vertical-align: bottom">
                            <b>Lotti di controllo:</b>
                        </div>
                        <div style="width: 170px; display: inline-block; padding-right: 15px;">
                            <br />
                            Totale:<br />
                            <Siar:IntegerTextBox ID="txtNrLottiTotali" runat="server" Width="119px" ReadOnly="True" />
                        </div>
                        <div style="width: 170px; display: inline-block; padding-right: 15px;">
                            <br />
                            Campione estratto:<br />
                            <Siar:IntegerTextBox ID="txtNrLottiEstratti" runat="server" Width="119px" ReadOnly="True" />
                        </div>
                        <div style="display: inline-block; padding-right: 15px;">
                            <br />
                            Controllo concluso:<br />
                            <Siar:IntegerTextBox ID="txtNrLottiConclusi" runat="server" Width="119px" ReadOnly="True" />
                        </div>
                    </div>
                </div>
                <br />
            </div>
            <div class="separatore">
                Nomina degli operatori di validazione:
            </div>
            <div style="padding: 10px">
                <div style="width: 100%">
                    <div style="padding-bottom: 10px;">
                        <b>Selezionare il bando dalla lista e cercare l'operatore nella text box</b>
                    </div>
                    <div style="display: inline-block; padding-right: 15px;">
                        Selezionare il bando:<br />
                        <Siar:ComboBandiRupFem ID="lstBandiRup" runat="server"></Siar:ComboBandiRupFem>
                    </div>
                    <div style="display: inline-block; padding-right: 15px;">
                        Digitare un nominativo:<br />
                        <Siar:TextBox  ID="txtValidatore" runat="server" Width="335px" />
                    </div>
                    <div style="display: inline-block; padding-right: 15px;">
                        <br />
                        <asp:CheckBox ID="chkResponsabile" runat="server" Text="Responsabile" />
                    </div>
                    <div style="display: inline-block;">
                        <Siar:Button ID="btnSalvaValidatore" runat="server" OnClick="btnSalvaValidatore_Click"
                            Text="Nomina" Width="170px" Modifica="True" OnClientClick="return ctrlUtente(event);" />
                    </div>
                </div>
            </div>
            <div class="paragrafo">
                Elenco operatori assegnati:
            </div>
            <div>
                <Siar:DataGrid ID="dgOperatoriValidazione" runat="server" Width="100%" AllowPaging="true"
                    AutoGenerateColumns="false" PageSize="10">
                    <ItemStyle Height="30px" />
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
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="160px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
            </div>
            <div class="separatore" colspan="4">
                Selezionare le domande dalla griglia per assegnarle all'operatore selezionato
            </div>
            <div style="padding-top: 10px">
                <div style="width: 100%;">
                    <div style="display: inline-block; padding-right: 15px;">
                        Selezionare il bando:<br />
                        <Siar:ComboBandiRupFem ID="lstBandiRupValidatore" AutoPostBack="true" runat="server"></Siar:ComboBandiRupFem>
                    </div>
                    <div style="display: inline-block; padding-right: 15px;">
                        Selezionare il validatore:<br />
                        <Siar:ComboBandiValidatoriRup ID="lstValidatoriBandoRup" runat="server"></Siar:ComboBandiValidatoriRup>
                    </div>
                    <div style="display: inline-block;">
                        <Siar:Button ID="btnAssegnaDomande" runat="server" OnClick="btnAssegnaDomande_Click"
                            Text="Assegna domande" Width="170px" Modifica="True" />
                    </div>
                </div>
            </div>
            <div class="paragrafo">
                Elenco Domande da assegnare:
            </div>
            <div>
                <Siar:DataGrid ID="dgDomandeDaAssegnare" runat="server" Width="100%" AllowPaging="true"
                    AutoGenerateColumns="false" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Bando"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Progetto">
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Domanda pagamento">
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione domanda di pagamento"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CfIstruttore" HeaderText="Istruttore">
                            <ItemStyle HorizontalAlign="center" Width="200px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdDomandaPagamento" Name="chkAssocia" HeaderText="Associa al validatore">
                            <ItemStyle HorizontalAlign="center" Width="80px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>
    </div>

    <div class="dBox" runat="server" id="tabValidatori">
        <div class="separatore">
            <asp:Label ID="lblInfoDomandeAssegnate" runat="server"></asp:Label>
        </div>
        <div style="padding: 15px;">
            <div style="display: inline-block; padding-right: 15px;">
                Digitare l'id del progetto:<br />
                <Siar:TextBox  ID="txtIdProgetto" runat="server" Width="50px" />
            </div>
            <div style="display: inline-block; padding-right: 15px;">
                Digitare l'id della domanda di pagamento:<br />
                <Siar:TextBox  ID="txtIdDomanda" runat="server" Width="50px" />
            </div>
            <div style="display: inline-block;">
                <Siar:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click"
                    Text="Filtra" Width="170px" />
            </div>
            <div>
                <Siar:DataGrid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="20" Width="100%">
                    <ItemStyle Height="26px" />
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Numero domanda di aiuto">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Numero domanda di pagamento">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoDomandaPagamento" HeaderText="Modalit&#224; della richiesta">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataPresentazioneDomandaPagamento" HeaderText="Data di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <%--                        <asp:BoundColumn DataField="SelezionataXRevisione" DataFormatString="{0:SI|NO}" HeaderText="Estratta a campione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn DataField="NominativoValidatore" HeaderText="Validatore">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Approvata" DataFormatString="{0:SI|NO}" HeaderText="Controllo positivo">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <%--                        <asp:BoundColumn DataField="NumeroEstrazione" HeaderText="Numero estrazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn DataField="SegnaturaRevisione" HeaderText="Protocollo">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Vai alla checklist di controllo">
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
        </div>
    </div>

    <uc1:ucSceltaChecklist ID="modaleSceltaChecklist" runat="server" />
</asp:Content>
