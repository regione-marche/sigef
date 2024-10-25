<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.Dichiarazioni" CodeBehind="Dichiarazioni.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <input id="hdnAltriAllegati" type="hidden" name="hdnAltriAllegati" runat="server" />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                DICHIARAZIONI & IMPEGNI
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Elenco delle dichiarazioni e degli impegni che verranno sottoscritti digitalmente al momento
                della presentazione della domanda.</td>
        </tr>
        <tr>
            <td class="paragrafo">
                Accettazione delle dichiarazioni OBBLIGATORIE per la presentazione della domanda:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgObbligatorie" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    PageSize="20" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Dichiarazione"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Selezione delle dichiarazioni CON SCELTA OPZIONALE per la presentazione della domanda:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgFacoltative" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                    PageSize="20" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Dichiarazione"></asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdDichiarazione" Name="chkFacolt" HeaderText=" ">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 40px; height: 65px;">
                <Siar:Button ID="btnSalva" Text="Accettazione dichiarazioni" runat="server" OnClick="btnAccettazione_Click"
                    CausesValidation="false" Modifica="True" Width="190px" />
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnBack" Text="Indietro" runat="server" OnClick="btnBack_Click"
                    CausesValidation="false" Modifica="False" Width="130px" />
            </td>
        </tr>
    </table>
</asp:Content>
