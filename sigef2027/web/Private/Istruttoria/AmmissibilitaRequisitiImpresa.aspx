<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AmmissibilitaRequisitiImpresa" CodeBehind="AmmissibilitaRequisitiImpresa.aspx.cs" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaPlurivalore(jobj) {
            $('#labelValoriPriorita' + jobj.IdPriorita).val(jobj.Descrizione);
            $('#labelValoriPriorita' + jobj.IdPriorita + '_text').html(jobj.Descrizione);
            $('#hdnPriorita' + jobj.IdPriorita).val(jobj.IdPriorita);
            $('#hdnValoriPriorita' + jobj.IdPriorita).val(jobj.IdValore); 
            chiudiPopupPlurivalori(); 
        }
        function deselezionaPlurivalore(idpriorita) {
            $('#labelValoriPriorita' + idpriorita).val('');
            $('#labelValoriPriorita' + idpriorita + '_text').html('');
            $('#hdnPriorita' + idpriorita).val(''); 
            $('#hdnValoriPriorita' + idpriorita).val(''); 
        }
        function chiudiPopupPlurivalori() {
            $('#divValoriPriorita').html(''); 
            chiudiPopupTemplate(); 
        }
        function selezionaPlurivaloreSql(jobj) {
            $('#labelValoriPrioritaSql' + jobj.IdPriorita).val(jobj.Descrizione);
            $('#labelValoriPrioritaSql' + jobj.IdPriorita + '_text').html(jobj.Descrizione);
            $('#hdnPrioritaSql' + jobj.IdPriorita).val(jobj.IdPriorita);
            $('#hdnValoriPrioritaSql' + jobj.IdPriorita).val(jobj.Codice);
            chiudiPopupPlurivalori(); 
        }
        function deselezionaPlurivaloreSql(idpriorita) {
            $('#labelValoriPrioritaSql' + idpriorita).val('');
            $('#labelValoriPrioritaSql' + idpriorita + '_text').html('');
            $('#hdnPrioritaSql' + idpriorita).val('');
            $('#hdnValoriPrioritaSql' + idpriorita).val(''); 
        }

        function selezionaImpresa(id) { $('[id$=hdnIdImpresaAggregazione').val(id); $('[id$=btnPostImpresaAggregazione]').click(); }
    </script>
    <div style="display: none">
        <asp:HiddenField ID="hdnFormaNaturaSoggetto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoNaturaSoggetto" runat="server" />        
        <asp:HiddenField ID="hdnIdAggregazione" runat="server" />
        <asp:HiddenField ID="hdnIdImpresaAggregazione" runat="server" />
        <asp:Button ID="btnPostImpresaAggregazione" runat="server" CausesValidation="false" OnClick="btnPostImpresaAggregazione_Click" />
        
    </div>
    <br />
    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />
    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEI REQUISITI DI IMPRESA/AGGREGAZIONE DI IMPRESA
            </td>
        </tr>
        <tr>
            <td style="padding-left:30px;">
                La domanda è presentata in forma:
                <asp:DropDownList ID="ddlFormaNaturaSoggetto"  runat="server">
                    <asp:ListItem Text="" Value="" Selected="true"></asp:ListItem>
                    <asp:ListItem Text="SINGOLA" Value="Singola"></asp:ListItem>
                    <asp:ListItem Text="AGGREGATA" Value="Aggregata"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr> 
        <tr>
            <td align="right" style="padding-right: 50px; height: 60px;">
                <input id="btnBack" runat="server" class="Button" style="width: 160px" type="button"
                    value="Indietro" />
            </td>
        </tr>
        <tr >
            <td>
                <div id="DivAggregazione" runat="server" visible ="false">
                    <table width ="100%">
                        <tr>
                            <td class="separatore">
                                &nbsp;Aggregazione:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:30px;padding-top:20px;">
                                Selezionare l'aggregazione dall'elenco:
                                <siar:ComboAggregazione ID="ddlAggregazione" Width="200px"  runat="server" >
                                </siar:ComboAggregazione>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="DivImprese" runat="server" visible ="false">
                    <table width ="100%">
                        <tr>
                            <td class="separatore">
                                &nbsp;Imprese Dell'aggregazione:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:10px;padding-top:20px;">
                                Selezionare ogni singola impresa della tabella per inserire i requisiti d'imrpesa<br />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <Siar:DataGrid ID="dgImpreseAggregazione" runat="server" Width="100%" PageSize="20"
                                AllowPaging="True" AutoGenerateColumns="False">
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <ItemStyle Width="35px" HorizontalAlign="center" />
                                        </Siar:NumberColumn>
                                        <Siar:ColonnaLink DataField="RagioneSociale" HeaderText="Ragione Sociale" LinkFields="IdImpresa"
                                            LinkFormat='javascript:selezionaImpresa({0})'>
                                        </Siar:ColonnaLink>
                                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Partita Iva">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Ruolo">
                                        </asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px">
                <div id="divPriorita" runat="server" visible ="false">
                    <table width='100%'>
                        <tr>
                            <td class="separatore">
                                &nbsp;Requisiti impresa:
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:20px;padding-top:20px;">
                                CF/P.Iva:&nbsp;<br />
                                <Siar:TextBox  ID="txtCFPIVA" runat="server" ReadOnly="True" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:20px;" >
                                Ragione Sociale:&nbsp;<br />
                                <Siar:TextBox  ID="txtRagSociale" runat="server" ReadOnly="True" Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="testo_pagina">
                                Elenco dei requisiti soggettivi per impresa definiti dal bando di gara.<br />
                                Si richiedere di specificare tali requisiti per l'impresa/tutte le imprese dell'aggregazione
                                che presentano la domanda di aiuto.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <Siar:DataGrid ID="dgPriorita" runat="server" Width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <ItemStyle HorizontalAlign="center" Width="35px" />
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="Priorita" HeaderText="Descrizione">
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:BoundColumn>
                                        <Siar:CheckColumn Name="chkPriorita" DataField="IdPriorita" HeaderText=" ">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                        </Siar:CheckColumn>
                                        <asp:TemplateColumn>
                                            <ItemStyle HorizontalAlign="Left" Width="320px" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                </Siar:DataGrid>
                                <br />

                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-right: 50px; height: 60px;">
                                <Siar:Button ID="btnSalvaPriorita" Text="Ammetti" runat="server" Modifica="True"
                                    OnClick="btnSalvaPriorita_Click" Width="196px" />
                            </td>
                        </tr>
                    </table>
                    <table width='100%'> 
                        <tr>
                            <td>
                                <uc4:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="True"
                                    ContoCorrenteVisibile="False" AbilitaModifica="False" Visible ="false" />
                            </td>
                        </tr> 
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
