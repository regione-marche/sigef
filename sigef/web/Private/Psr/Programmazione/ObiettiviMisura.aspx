<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="ObiettiviMisura.aspx.cs" Inherits="web.Private.Psr.Programmazione.ObiettiviMisura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) { $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val()==id?'':id);$('[id$=btnProgrammazionePost]').click(); }
        function selezionaObMisura(id) { $('[id$=hdnIdObMisura]').val(id);$('[id$=btnProgrammazionePost]').click(); }
        function nuovoObMisura() { $('[id$=hdnIdObMisura]').val('');$('[id$=txtObCodice]').val('');$('[id$=txtObDescrizione]').val('');$('[id$=btnObElimina]')[0].disabled='disabled'; }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnIdObMisura" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                OBIETTIVI DI MISURA & FINALITA' DEGLI INTERVENTI:
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco generale degli obiettivi di misura e delle finalità degli interventi.<br />
            </td>
        </tr>
        <tr>
            <td>
                <b>Selezionare il programma desiderato:</b><br />
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true">
                </Siar:ComboZPsr>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                            <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Id" LinkFormat="selezionaProgrammazione({0});">
                        </Siar:ColonnaLink>
                        <Siar:CheckColumn DataField="Id" Name="chkProgrammazioneSelect" OnCheckClick="return false;">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbObMisura" runat="server" width="100%" visible="false" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td style="width: 550px; padding-right: 3px; vertical-align: top; border-right: solid 1px black">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light">
                                        Elenco obiettivi associati:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <Siar:DataGrid ID="dgObMisura" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <ItemStyle Height="24px" />
                                            <Columns>
                                                <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </Siar:NumberColumn>
                                                <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                                                    LinkFields="Id" LinkFormat="selezionaObMisura({0});">
                                                </Siar:ColonnaLink>
                                            </Columns>
                                        </Siar:DataGrid>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="padding-left: 3px; vertical-align: top">
                            <table width="100%">
                                <tr>
                                    <td class="separatore_light">
                                        Dettaglio Obiettivo:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <br />
                                        Codice:<br />
                                        <Siar:TextBox ID="txtObCodice" runat="server" NomeCampo="Codice" Obbligatorio="True"
                                            Width="150px" MaxLength="10" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descrizione:<br />
                                        <Siar:TextArea ID="txtObDescrizione" runat="server" NomeCampo="Descrizione" Obbligatorio="True"
                                            Rows="5" Width="355px" MaxLength="500" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 38px">
                                        &nbsp;
                                        <Siar:Button ID="btnObSalva" runat="server" Modifica="True" OnClick="btnObSalva_Click"
                                            Text="Salva" Width="100px" />
                                        &nbsp;&nbsp;
                                        <Siar:Button ID="btnObElimina" runat="server" OnClick="btnObElimina_Click" Text="Elimina"
                                            Width="100px" Modifica="true" CausesValidation="false" Conferma="Attenzione! Eliminare l`obiettivo selezionato?" />
                                        &nbsp;
                                        <input class="Button" style="width: 100px" type="button" value="Nuovo" onclick="nuovoObMisura();" />
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
