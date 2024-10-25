<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Psr.Bandi.ModelloDomanda" CodeBehind="ModelloDomanda.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                Modello di domanda associato al bando:
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 98px">
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 98px" valign="top">
                            <strong>Denominazione:</strong>
                        </td>
                        <td>
                            <Siar:TextBox ID="txtDenominazione" runat="server" NomeCampo="Denominazione" Obbligatorio="True"
                                Width="199px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 98px" valign="top">
                            <strong>Descrizione:</strong>
                        </td>
                        <td>
                            <Siar:TextArea ID="txtDescrizioneLunga" runat="server" Width="610px" NomeCampo="Descrizione"
                                Obbligatorio="True" Rows="6"></Siar:TextArea>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="border-top: black 1px solid">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <Siar:Button ID="btnStampa" runat="server" Text="Prova di stampa" OnClick="btnStampa_Click"
                                Style="width: 172px" />
                            &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<Siar:Button ID="btnSalvaReport" runat="server" OnClick="btnSalvaReport_Click"
                                Text="Salva Report" Width="174px" />
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<Siar:Button ID="btnSalva" runat="server" Width="174px"
                                Text="Salva" OnClick="btnSalva_Click" Modifica="true"></Siar:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Quadri domanda|Dichiarazioni|Allegati"
        Width="800px" />
    <table class="tableTab" id="tableQuadri" runat="server" width="800px" visible="false">
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgQuadri" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione">
                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <Siar:IntegerColumn DataField="IdQuadro" HeaderText="Ordine" Valore="Ordine" Name="OrdineQuadro">
                            <ItemStyle Width="100" HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumn DataField="IdQuadro" Name="chkQuadro" HeaderSelectAll="true">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 50px; padding-right: 50px">
                <Siar:Button ID="btnSalvaQuadri" runat="server" OnClick="btnSalvaQuadri_Click" Text="Salva"
                    Width="155px" CausesValidation="False" Modifica="true" />
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tableDichiarazioni" runat="server" width="800px" visible="false">
        <tr>
            <td style="height: 80px" align="right" valign="middle">
                <table style="width: 650px;">
                    <tr>
                        <td style="height: 31px">
                            <b>Misura</b>:&nbsp;
                            <asp:TextBox ID="txtDMisuraCerca" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;<b>Descrizione</b>:&nbsp;
                            <asp:TextBox ID="txtDescrizioneDichiarazione" runat="server" Width="300px"></asp:TextBox>
                            &nbsp;&nbsp;
                        </td>
                        <td style="height: 31px">
                            <Siar:Button ID="btnDMisuraCerca" runat="server" CausesValidation="False" OnClick="btnDMisuraCerca_Click"
                                Text="Cerca" Width="71px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgDichiarazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="40" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdDichiarazione" HeaderText="Id" ></asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdDichiarazione" Name="chkObbligatorioDichiarazione"
                            HeaderText="Obbligatorio">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </Siar:CheckColumn>
                        <Siar:IntegerColumn DataField="IdDichiarazione" HeaderText="Ordine" Valore="Ordine"
                            Name="OrdineDichiarazione">
                            <ItemStyle Width="100px" HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumn DataField="IdDichiarazione" Name="chkDInclusa" HeaderSelectAll="true">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 50px; padding-right: 50px">
                <Siar:Button ID="btnSalvaDichiarazioni" runat="server" OnClick="btnSalvaDichiarazioni_Click"
                    Text="Salva" Width="155px" CausesValidation="False" Modifica="true" />
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tableAllegati" runat="server" width="800px" visible="false">
        <tr>
            <td style="height: 80px" align="right" valign="middle">
                <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid;
                    width: 209px; border-bottom: black 1px solid">
                    <tr>
                        <td class="separatore">
                            &nbsp;Filtra per misura:
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 31px">
                            &nbsp;
                            <Siar:TextBox ID="txtAMisuraCerca" runat="server" Width="98px" />
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnAMisuraCerca" runat="server" CausesValidation="False" OnClick="btnAMisuraCerca_Click"
                                Text="Cerca" Width="71px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgAllegati" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoAllegato" HeaderText="Tipo documento">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdAllegato" Name="chkInclAllegato" HeaderSelectAll="true">
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 50px; padding-right: 50px">
                <Siar:Button ID="btnSalvaAllegati" runat="server" OnClick="btnSalvaAllegati_Click"
                    Text="Salva" Width="155px" CausesValidation="False" Modifica="true" />
            </td>
        </tr>
    </table>
</asp:Content>
