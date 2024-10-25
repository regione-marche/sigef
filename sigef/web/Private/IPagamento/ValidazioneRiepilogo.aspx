<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="ValidazioneRiepilogo.aspx.cs" Inherits="web.Private.IPagamento.ValidazioneRiepilogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function SNCVZCercaUtenti_onselect(obj) { if(obj) { $('[id$=hdnIdUtenteSelezionato]').val(obj.IdUtente);$('[id$=txtValidatore_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtenteSelezionato]').val('');/*$('[id$=txtValidatore_text]').val('');*/ }
        function ctrlUtente(ev) { if($('[id$=hdnIdUtenteSelezionato]').val()=='') { alert('E` necessario specificare un`operatore.');return stopEvent(ev); } return true; }
        function disabilitaValidatore(id_validatore) { if(confirm('Attenzione! Disabilitare l`operatore selezionato?')) { $('[id$=hdnIdValidatore]').val(id_validatore);$('[id$=btnDisabilitaValidatore]').click(); } }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdUtenteSelezionato" runat="server" />
        <asp:HiddenField ID="hdnIdValidatore" runat="server" />
        <asp:Button ID="btnDisabilitaValidatore" runat="server" OnClick="btnDisabilitaValidatore_Click" /></div>
    <br />
    <table class="tableNoTab" width="950">
        <tr>
            <td class="separatore_big">
                CONTROLLI DI VALIDAZIONE
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                In questa pagina viene mostrato un breve riepilogo dello stato avanzamento dei 
                controlli di validazione documentali,<br />
                con il numero delle domande di pagamento pervenute, istruite e validate, e 
                l&#39;elenco degli operatori di validazione.</td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Situazione dei controlli:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 154px; vertical-align: bottom">
                            <b>Domande di pagamento:</b>
                        </td>
                        <td style="width: 170px">
                            <br />
                            Pervenute:<br />
                            <Siar:IntegerTextBox ID="txtNrPagPervenute" runat="server" Width="119px" ReadOnly="True" />
                        </td>
                        <td style="width: 170px">
                            <br />
                            Istruite:<br />
                            <Siar:IntegerTextBox ID="txtNrPagIstruite" runat="server" Width="119px" ReadOnly="True" />
                        </td>
                        <td>
                            <br />
                            Validate:<br />
                            <Siar:IntegerTextBox ID="txtNrPagValidate" runat="server" Width="119px" ReadOnly="True" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 154px; vertical-align: bottom">
                            <b>Lotti di controllo:</b>
                        </td>
                        <td style="width: 170px">
                            <br />
                            Totale:<br />
                            <Siar:IntegerTextBox ID="txtNrLottiTotali" runat="server" Width="119px" ReadOnly="True" />
                        </td>
                        <td style="width: 170px">
                            <br />
                            Campione estratto:<br />
                            <Siar:IntegerTextBox ID="txtNrLottiEstratti" runat="server" Width="119px" ReadOnly="True" />
                        </td>
                        <td>
                            <br />
                            Controllo concluso:<br />
                            <Siar:IntegerTextBox ID="txtNrLottiConclusi" runat="server" Width="119px" ReadOnly="True" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="separatore">
                Nomina degli operatori di validazione:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td style="width: 379px">
                            Digitare un nominativo:<br />
                            <Siar:TextBox ID="txtValidatore" runat="server" Width="335px" />
                        </td>
                        <td style="width: 192px">
                            <br />
                            <asp:CheckBox ID="chkResponsabile" runat="server" Text="Responsabile" />
                        </td>
                        <td>
                            <br />
                            <Siar:Button ID="btnSalvaValidatore" runat="server" OnClick="btnSalvaValidatore_Click"
                                Text="Nomina" Width="170px" Modifica="True" OnClientClick="return ctrlUtente(event);" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Elenco operatori assegnati:
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgOperatoriValidazione" runat="server" Width="100%" AllowPaging="true"
                    AutoGenerateColumns="false" PageSize="10">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="35px" />
                        </Siar:NumberColumn>
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
            </td>
        </tr>
    </table>
</asp:Content>
