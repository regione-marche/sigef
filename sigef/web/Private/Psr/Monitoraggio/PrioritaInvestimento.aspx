<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="PrioritaInvestimento.aspx.cs" Inherits="web.Private.Psr.Programmazione.PrioritaInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) 
        {
            $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click();
        }
        function selezionaPI(id) 
        {
            $('[id$=hdnPI]').val($('[id$=hdnPI]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnPI" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>
    <table width="950px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                PRIORITA INVESTIMENTI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Gestione delle Priorità di Investimento collegate alle Azioni della Programmazione.<br />
                Tramite il combo selezionare il POR desiderato, verranno quindi visualizzate le 
                Priorità di Investimento collegate.<br />
                Selezionando una Priorità di Investimento, verrà visualizzato l&#39;elenco delle 
                Azioni ad ess associate e le Azioni non ancora associate a nessuna Priorità.<br />
                Selezionare tramite il checkbox le Azioni da collegare alla Priorità di 
                Investimento e salvare con il pulsante &quot;Salva&quot;.<br />
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
                <Siar:DataGrid ID="dgPI" runat="server" AutoGenerateColumns="false" Width="100%">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Id" LinkFormat="selezionaPI({0});">
                        </Siar:ColonnaLink>
                        <Siar:CheckColumn DataField="Id" Name="chkPISelect" OnCheckClick="return false;">
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbDettaglio" runat="server" width="100%" visible="false" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    <br />
                    <Siar:DataGrid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" Width="100%">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <Siar:NumberColumn>
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="CodProgrammazione" HeaderText="Codice">
                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LivelloProgrammazione" HeaderText="Livello">
                                <ItemStyle Width="130px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DesProgrammazione" HeaderText="Azione"></asp:BoundColumn>
                            <Siar:CheckColumn DataField="IdProgrammazione" Name="chkProgrammazioneSelect" HeaderSelectAll="true">
                                <ItemStyle Width="60px" HorizontalAlign="Center" />
                            </Siar:CheckColumn>
                        </Columns>
                    </Siar:DataGrid>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="height: 60px; padding-right: 50px" align="right">
                        <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva" Width="175px" Modifica="True" />
                    </td>
                </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
