<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master"
    CodeBehind="StepQuery.aspx.cs" Inherits="web.Private.admin.StepQuery" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function selezionaControllo(id) { $('[id$=hdnIdControllo]').val(id); $('[id$=btnPost]').click(); }
        function nuovo() { $('[id$=hdnIdControllo]').val(''); $('[id$=txtNome_text]').val(''); $('[id$=txtQueryLungaSQL]').val(''); }
//--></script>

    <div style="display: none">
        <input id="hdnIdControllo" type="hidden" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Controlli |Dettaglio " />
    <table class="tableTab" id="tdElencoStep" runat="server" width="600px" visible="false">
        <tr>
            <td class="testo_pagina">
                In questa pagina vengono elencati tutti i controlli utilizzati per gli Step Automatici
            </td>
        </tr>
        <tr>
            <td align="right">
                <div style="width: 500px;">
                    <strong>Filtra per Nome:</strong>&nbsp;
                    <Siar:TextBox runat="server" ID="txtFiltroNome" Width="150px" />
                    &nbsp; &nbsp; &nbsp;<Siar:Button ID="btnFiltro" Width="80px" runat="server" Text="Cerca"
                        CausesValidation="false" />&nbsp;
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgControlli" runat="server" Width="100%" AllowPaging="True" PageSize="30"
                    AutoGenerateColumns="False" EnableViewState="False" ShowShadow="False" CssClass="tabella">
                    <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="DataGridRow"></ItemStyle>
                    <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Nome" HeaderText="Nome"></asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <table class="tableTab" width="890px" id="tdDettaglioStep" runat="server" visible="false">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore" colspan="2">
                MESSAGGIO DA ADMINISTRATOR:<br />
                NON MODIFICARE O INSERIRE &nbsp;NEI CAMPI QUI SOTTO A MENO CHE NON SI SAPPIA QUELLO
                CHE SI STA FACENDO
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 110px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; vertical-align: top;">
                &nbsp; <strong>Nome:</strong>
            </td>
            <td>
                <Siar:TextBox ID="txtNome" runat="server" Width="750px" Obbligatorio="true" />
            </td>
        </tr>
        <tr>
            <td style="width: 110px; vertical-align: top;">
                <br />
                &nbsp; <strong>Query SQL:</strong>
            </td>
            <td>
                <Siar:TextArea ID="txtQueryLungaSQL" runat="server" Width="750px" Rows="40" MaxLength="15000"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                &nbsp;<Siar:Button ID="btnSalva" Text="Salva" runat="server" Width="100px" OnClick="btnSalva_Click"
                    CausesValidation="true" />
                &nbsp;
                <input class="Button" onclick="javascript:nuovo()" type="button" value="Nuovo" style="width: 140px" />&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="separatore">
                &nbsp;Elenco Step associati al controllo:
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <Siar:DataGrid ID="dgStepAssociati" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableViewState="False" ShowShadow="False" CssClass="tabella" AllowPaging="true"
                    PageSize="8">
                    <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="DataGridRow"></ItemStyle>
                    <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Step" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ValMinimo" HeaderText="Minimo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ValMassimo" HeaderText="Massimo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CheckList" HeaderText="CheckList/Scheda Valutazione">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
