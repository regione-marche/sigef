﻿<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="BandiCovid.aspx.cs" Inherits="web.Private.COVID.BandiCovid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function SelezionaBAndoCovid(id) {
            $('[id$=hdnIdBando]').val(id);
            $('[id$=btnSelectIdBandoCovid]').click();
        }
    </script>

    <div style="display:none;">
        <asp:HiddenField runat="server" ID="hdnIdBando" />
        <asp:Button ID="btnSelectIdBandoCovid" runat="server" OnClick="btnSelectIdBandoCovid_Click" CausesValidation="false" />
    </div>

    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">PROCEDIMENTI ATTIVI:
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
                                        <td>Ente emettitore:<b>
                                            <%# DataBinder.Eval(Container, "DataItem.Ente") %></b>
                                        </td>
                                        <td style="width: 150px">Apertura:<b>
                                            <%# DataBinder.Eval(Container, "DataItem.DataApertura.Value").ToString().Substring(0,16) %></b>
                                        </td>
                                        <td style="width: 150px">Scadenza:<b>
                                            <%# DataBinder.Eval(Container, "DataItem.DataScadenza.Value").ToString().Substring(0,16) %></b>
                                        </td>
                                        <td style="width: 132px">Importo:<b>
                                            <%# string.Format("{0:c}", DataBinder.Eval(Container, "DataItem.Importo")) %></b>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%; margin-bottom: 10px">
                                    <tr>
                                        <td style="width: 28px; border: 0; cursor: pointer;">
                                            <img src="../../images/info.ico" title="Info sul bando" onclick="mostraPopupDocumentiBando(<%# DataBinder.Eval(Container, "DataItem.IdBando") %>);" />
                                        </td>
                                        <td style="border: 0" class="testo_pagina">
                                            <%# DataBinder.Eval(Container, "DataItem.Descrizione") %>
                                        </td>
                                        <td style="width: 132px; border: 0; text-align: center">
                                            <%--<%# new SiarLibrary.NullTypes.DatetimeNT(DataBinder.Eval(Container, "DataItem.DataScadenza.Value").ToString()) > DateTime.Now ? "<input type=button value='Presenta domanda' style='width:120px' class=ButtonGrid onclick=\"location='../COVID/SelezionaAutocertificazione.aspx?idb=" +DataBinder.Eval(Container, "DataItem.IdBando")  + "'\" />" : "<span class=testoRosso>SCADUTO</span>"%>--%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <Siar:JsButtonColumn Arguments="IdBando" ButtonType="TextButton" ButtonText="Continua" JsFunction="SelezionaBAndoCovid">
                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <div id="divDocumentiBando" style="width: 700px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">&nbsp;Elenco dei documenti relativi al bando selezionato:
                </td>
            </tr>
            <tr>
                <td id="tdGridDocumentiBando" style="padding: 5px"></td>
            </tr>
            <tr>
                <td style="height: 40px; padding-right: 40px;" align="right">
                    <input style="width: 155px" type="button" value="Chiudi" class="Button" onclick="chiudiPopupTemplate()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>