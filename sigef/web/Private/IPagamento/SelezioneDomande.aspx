<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.SelezioneDomande" CodeBehind="SelezioneDomande.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function dettaglioDomanda(id,element) {
            var coords=getElementOffsetCoords(element);$.post(getBaseUrl()+'CONTROLS/ajaxRequest.aspx',{ "type": "getDatiDomanda","iddom": id },function(msg) {
                ajaxComplete=true;$('#divPopupDomanda').html(msg.Html).fadeIn().css({ "top": coords.y,"left": coords.x,"width": 400 });
                $(document).click(function(e) { if(!$(arguments[0].target).hasClass("clickable")&&!$(arguments[0].target.offsetParent).hasClass("clickable")) $('#divPopupDomanda').hide(); });
            },'json');
        }
//--></script>

    <br />
    <table class="tableNoTab" width="950">
        <tr>
            <td class="separatore_big">
                SELEZIONE DELLE DOMANDE
            </td>
        </tr>
        <tr>
            <td align="right">
                <table cellpadding="0" cellspacing="0" style="border-left: black 1px solid; border-bottom: black 1px solid">
                    <tr>
                        <td align="left" style="height: 22px">
                        </td>
                        <td align="left" valign="bottom" style="height: 22px; width: 83px;">
                            Numero:&nbsp;
                        </td>
                        <td align="left" valign="bottom" style="height: 22px">
                            Stato domanda:
                        </td>
                        <td align="left" valign="bottom" style="height: 22px">
                            &nbsp;Operatore:
                        </td>
                        <td align="left" style="width: 166px; height: 22px;" valign="bottom">
                            Provincia:
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        </td>
                        <td align="left" valign="top" style="width: 83px">
                            <Siar:TextBox ID="txtNumero" runat="server" MaxLength="5" Width="55px" />
                            &nbsp; &nbsp; &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <Siar:ComboBase ID="lstStato" runat="server" Width="166px">
                            </Siar:ComboBase>
                            &nbsp;&nbsp; &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <Siar:ComboIstruttoriXBando ID="lstOperatore" runat="server">
                            </Siar:ComboIstruttoriXBando>
                            &nbsp; &nbsp;
                        </td>
                        <td align="left" valign="top" style="width: 166px">
                            <Siar:ComboProvince ID="lstProvince" runat="server">
                            </Siar:ComboProvince>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 22px" valign="bottom">
                        </td>
                        <td align="left" colspan="2" style="height: 22px" valign="bottom">
                            Partita iva/Codice fiscale:
                        </td>
                        <td align="left" style="height: 22px" valign="bottom">
                            Ragione sociale:
                        </td>
                        <td align="left" style="width: 166px; height: 22px" valign="bottom">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                        </td>
                        <td align="left" colspan="2" valign="top">
                            <Siar:TextBox ID="txtCuaa" runat="server" Width="169px" />
                        </td>
                        <td align="left" colspan="2" valign="top">
                            <Siar:TextBox ID="txtRagioneSociale" runat="server" Width="272px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" style="height: 58px">
                        </td>
                        <td align="left" colspan="1" style="width: 83px; height: 58px;">
                            <strong>RICERCA TRA:</strong>
                        </td>
                        <td align="left" colspan="2" style="height: 58px">
                            &nbsp;<asp:CheckBox ID="chkPagamenti" runat="server" Text="PAGAMENTI" Height="25px" />
                            &nbsp; &nbsp;&nbsp;
                            <asp:CheckBox ID="chkVarianti" runat="server" Text="VARIANTI" Height="25px" />
                            &nbsp; &nbsp;&nbsp;
                            <asp:CheckBox ID="chkAdeguamentiTecnici" runat="server" Text="ADEGUAMENTI TECNICI"
                                Height="25px" /><br />
                            <strong>&nbsp;CON ISTRUTTORIA:</strong>
                            <asp:CheckBox ID="chkIstruttoriaConclusa" runat="server" Text="CONCLUSA" />
                            <asp:CheckBox ID="chkIstruttoriaInCorso" runat="server" Text="IN CORSO" />
                            &nbsp; &nbsp; &nbsp;
                            <asp:CheckBox ID="chkAnnullati" runat="server" Text="ANNULLATI" />
                        </td>
                        <td align="center" colspan="1" style="height: 58px">
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Applica filtro"
                                Width="109px" /><br />
                            <Siar:Button ID="btnResetForm" runat="server" OnClick="btnResetForm_Click" Text="Reset ricerca"
                                Width="109px" Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 10px; padding-bottom: 10px">
                <Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="20" Width="100%" FooterText="(click sul numero di domanda per i dettagli)">
                    <FooterStyle CssClass="coda" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Istruttore" HeaderText="Istruttore assegnato">
                            <ItemStyle HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProvinciaAssegnazione" HeaderText="Provincia di assegnazione">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Vai alla gestione dei lavori della domanda">
                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Iter procedurale della domanda">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
    <div id="divPopupDomanda" class='ajaxResp'>
    </div>
</asp:Content>
