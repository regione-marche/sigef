<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Public.Bandi" CodeBehind="Bandi.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                RICERCA BANDI PUBBLICI:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 199px">
                            <b>Ente emettitore del bando:<br />
                                <Siar:ComboEntiBando ID="lstEntiBando" runat="server" Width="180px">
                                </Siar:ComboEntiBando>
                            </b>
                        </td>
                        <td>
                            <b>Programmazione:<br />
                            </b>
                            <Siar:ComboGroupZProgrammazione ID="lstZProgrammazione" runat="server" Width="500px">
                            </Siar:ComboGroupZProgrammazione>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 199px">
                            &nbsp;Data di scadenza (&lt;=):<br />
                            <Siar:DateTextBox ID="txtScadenza" runat="server" Width="130px" />
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp;Numero decreto:&nbsp;<br />
                                        <Siar:IntegerTextBox ID="txtNumero" runat="server" Width="130px" NoCurrency="true" />
                                    </td>
                                    <td style="width: 180px">
                                        &nbsp;Data decreto:<br />
                                        <Siar:DateTextBox ID="txtDataAtto" runat="server" Width="130px" />
                                    </td>
                                    <td>
                                        &nbsp;Ordinamento:<br />
                                        <select runat="server" name="orderBy" id="orderBy">
                                          <option value="DATA_SCADENZA">Data Scadenza</option>
                                          <option value="DATA_APERTURA">Data Apertura</option>
                                        </select>
                                    </td>
                                    <td>
                                        <br />
                                        <asp:CheckBox ID="chkScaduti" runat="server" Checked="True" Text="Nascondi bandi scaduti" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 50px">
                <Siar:Button ID="btnCerca" Text="Avvia ricerca" runat="server" OnClick="btnCerca_Click"
                    Width="180px" />
            </td>
        </tr>
        <tr>
            <td style="padding-bottom: 10px; padding-top: 10px">
                <Siar:DataGrid ID="dgBandi" runat="server" AutoGenerateColumns="False" Width="100%"
                    AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <table style="width: 100%; margin-bottom: 10px; margin-top: 5px">
                                    <tr>
                                        <td>
                                            Ente emettitore:<b>
                                                <%# DataBinder.Eval(Container, "DataItem.Ente") %></b>
                                        </td>
                                        <td style="width: 150px">
                                            Apertura:<b>
                                                <%# DataBinder.Eval(Container, "DataItem.DataApertura.Value").ToString().Substring(0,16) %></b>
                                        </td>
                                        <td style="width: 150px">
                                            Scadenza:<b>
                                                <%# DataBinder.Eval(Container, "DataItem.DataScadenza.Value").ToString().Substring(0,16) %></b>
                                        </td>
                                        <td style="width: 132px">
                                            Importo:<b>
                                                <%# string.Format("{0:c}", DataBinder.Eval(Container, "DataItem.Importo")) %></b>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%; margin-bottom: 10px">
                                    <tr>
                                        <td style="width: 28px; border: 0; cursor: pointer;">
                                            <img src="../images/info.ico" title="Info sul bando" onclick="mostraPopupDocumentiBando(<%# DataBinder.Eval(Container, "DataItem.IdBando") %>);" />
                                        </td>
                                        <td style="border: 0" class="testo_pagina">
                                            <%# DataBinder.Eval(Container, "DataItem.Descrizione") %>
                                        </td>
                                        <td style="width: 132px; border: 0; text-align: center">
                                            <%# new SiarLibrary.NullTypes.DatetimeNT(DataBinder.Eval(Container, "DataItem.DataScadenza.Value").ToString()) > DateTime.Now ? "<input type=button value='Presenta domanda' style='width:120px' class=ButtonGrid onclick=\"location='../Private/PDomanda/SelezioneAzienda.aspx?idb=" +DataBinder.Eval(Container, "DataItem.IdBando")  + "'\" />" : "<span class=testoRosso>SCADUTO</span>"%>
                                        </td>
                                        <td style="width: 132px; border: 0; text-align: center">
                                            <%# DataBinder.Eval(Container, "DataItem.CodStato").ToString() == "G" ? "<input type=button value='Vedi graduatoria' style='width:120px' class=ButtonGrid onclick=\"visualizzaAtto(" + DataBinder.Eval(Container, "DataItem.IdAtto") + ");\" />" : ""%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    &nbsp;Elenco dei documenti relativi al bando selezionato:
                </td>
            </tr>
            <tr>
                <td id="tdGridDocumentiBando" style="padding: 5px">
                </td>
            </tr>
            <tr>
                <td style="height: 40px; padding-right: 40px;" align="right">
                    <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
