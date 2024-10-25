<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Impresa.ImpresaAnagrafe" CodeBehind="ImpresaAnagrafe.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" Width="800px" TabNames="Situazione anagrafica attuale|Archivio storico" />
    <table id="tbSituazioneAttuale" runat="server" width="800px" class="tableTab">
        <tr>
            <td>
                <uc4:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="True"
                    ContoCorrenteVisibile="True" />
            </td>
        </tr>
    </table>
    <table id="tbStorico" runat="server" width="800px" class="tableTab">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Dati generali:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgStoricoImpresa" runat="server" Width="100%" EnableViewState="False"
                    AutoGenerateColumns="False" PageSize="15" AllowPaging="true">
                    <Columns>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione Sociale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="FormaGiuridica" HeaderText="Forma Giuridica"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DimensioneImpresa" HeaderText="Dimensione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;
                <br />
                &nbsp;Sedi legali:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSedeLegale" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
                    AllowPaging="true">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Via" HeaderText="Via"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Comune">
                            <ItemTemplate>
                                <asp:Label ID="comuneSede" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Comune") %>'></asp:Label>
                                (<asp:Label ID="provinciaSede" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sigla") %>'></asp:Label>)
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="180px"></ItemStyle>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Cap" HeaderText="Cap"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Telefono" HeaderText="Telefono"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                            <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità">
                            <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                &nbsp;
                <br />
                &nbsp;Altre sedi:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgDomicilio" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
                    AllowPaging="true">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Via" HeaderText="Via"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Comune">
                            <ItemTemplate>
                                <asp:Label ID="comune" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Comune") %>'></asp:Label>
                                (<asp:Label ID="provincia" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sigla") %>'></asp:Label>)
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="180px"></ItemStyle>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Cap" HeaderText="Cap">
                            <ItemStyle HorizontalAlign="center" Width="90px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                            <ItemStyle HorizontalAlign="center" Width="90px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità">
                            <ItemStyle HorizontalAlign="center" Width="90px"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Rappresentanti legali:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgPersonale" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="25px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Cognome" HeaderText="Cognome"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Nome" HeaderText="Nome"></asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Codice Fiscale">
                            <ItemStyle Width="110px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="dataNascita" HeaderText="Data di Nascita">
                            <ItemStyle Width="90px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Comune di Nascita">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Comune") %>'></asp:Label>
                                (<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sigla") %>'></asp:Label>)
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="180px"></ItemStyle>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="cap" HeaderText="CAP"></asp:BoundColumn>
                        <asp:BoundColumn DataField="dataFine" HeaderText="Data Fine">
                            <ItemStyle Width="90px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                &nbsp;Conti correnti:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgConto" runat="server" Width="100%" PageSize="15" AllowPaging="true"
                    EnableViewState="False" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <HeaderStyle Width="35px"></HeaderStyle>
                            <ItemStyle HorizontalAlign="center"></ItemStyle>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodPaese" HeaderText="Cod. Paese">
                            <ItemStyle HorizontalAlign="Right" Width="40px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CinEuro" HeaderText="CIN Euro">
                            <ItemStyle HorizontalAlign="Right" Width="40px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cin" HeaderText="CIN">
                            <ItemStyle HorizontalAlign="Right" Width="40px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Abi" HeaderText="ABI">
                            <ItemStyle HorizontalAlign="Right" Width="40px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cab" HeaderText="CAB">
                            <ItemStyle HorizontalAlign="Right" Width="40px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Numero" HeaderText="Numero">
                            <ItemStyle HorizontalAlign="Right" Width="80px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Istituto" HeaderText="Istituto">
                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Agenzia" HeaderText="Agenzia">
                            <ItemStyle HorizontalAlign="left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataInizioValidita" HeaderText="Data Inizio Validità">
                            <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataFineValidita" HeaderText="Data Fine Validità">
                            <ItemStyle HorizontalAlign="center" Width="70px"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
