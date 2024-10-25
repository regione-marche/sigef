<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Nuovo.aspx.cs" Inherits="web.Private.Psr.Bandi.Nuovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function SNCVZCercaUtenti_onselect(obj) { if(obj) { $('[id$=hdnIdUtenteResponsabile]').val(obj.IdUtente);$('[id$=txtResponsabile_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtente]').val(''); } 
    //--></script>

    <table class="tableNoTab" width="950px">
        <tr>
            <td class="separatore_big">
                INSERIMENTO DI UN NUOVO BANDO
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 220px">
                                        Ente emettitore:<br />
                                        <Siar:ComboEntiBando ID="lstEnte" runat="server" NomeCampo="Ente emettitore" Obbligatorio="True"
                                            Width="200px">
                                        </Siar:ComboEntiBando>
                                    </td>
                                    <td>
                                        Responsabile del bando:<br />
                                        <Siar:TextBox ID="txtResponsabile" runat="server" Width="345px" />
                                        &nbsp;
                                        <Siar:Hidden ID="hdnIdUtenteResponsabile" runat="server" Obbligatorio="true" NomeCampo="Responsabile del bando" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td style="width: 180px">
                                        Importo €:<br />
                                        <Siar:CurrencyBox ID="txtImporto" Obbligatorio="True" runat="server" Width="130px"
                                            NomeCampo="Importo"></Siar:CurrencyBox>
                                    </td>
                                    <td style="width: 130px; vertical-align: top;">
                                        Data scadenza:
                                        <br />
                                        <Siar:DateTextBox ID="txtDataScadenza" runat="server" Width="110px" NomeCampo="Data scadenza"
                                            Obbligatorio="True"></Siar:DateTextBox>
                                    </td>
                                    <td>
                                        Ora scadenza:
                                        <br />
                                        <Siar:ClockBox ID="txtOraScadenza" runat="server" Width="110px" NomeCampo="Ora scadenza"
                                            Obbligatorio="True" />
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td style="width: 296px">
                                        Descrizione:<br />
                                        <Siar:TextArea ID="txtDescrizione" runat="server" Obbligatorio="True" NomeCampo="Descrizione"
                                            Width="570px" Rows="6"></Siar:TextArea>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="separatore_light" style="height: 33px">
                PROGRAMMAZIONE
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                Selezionare il Programma di riferimento:
                <br />
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true">
                </Siar:ComboZPsr>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="0" id="tbMisura" runat="server"
                    visible="false">
                    <tr>
                        <td style="padding: 10px">
                            Selezionare la
                            <asp:Label ID="lblDefinizioneProgrammazione" runat="server"></asp:Label>
                            :<br />
                            <Siar:ComboZProgrammazione ID="lstProgrammazione" runat="server" AutoPostBack="True"
                                Width="600px">
                            </Siar:ComboZProgrammazione>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" id="tbInterventi" runat="server"
                                visible="false">
                                <tr>
                                    <td>
                                        <Siar:DataGrid ID="dgInterventi" runat="server" Width="100%" AutoGenerateColumns="False">
                                            <ItemStyle Height="30px" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                                    <ItemStyle HorizontalAlign="Center" Width="110px" Font-Bold="True" Font-Size="14px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                                                    <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                                <Siar:CheckColumn DataField="Id" Name="chkIdProgrammazione" HeaderSelectAll="true">
                                                    <ItemStyle Width="50px" />
                                                </Siar:CheckColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 60px; padding-right: 50px">
                                        <Siar:Button ID="btnSalva" runat="server" Width="158px" Text="Salva" OnClick="btnSalva_Click"
                                            Modifica="true"></Siar:Button>&nbsp;&nbsp;&nbsp;<Siar:Button Visible="false" ID="btnDisposizioniAttuative"
                                                runat="server" Width="233px" Text="Salva come disposizioni attuative" OnClick="btnDisposizioniAttuative_Click"
                                                Modifica="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
