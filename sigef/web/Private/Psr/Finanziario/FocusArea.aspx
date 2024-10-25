<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="FocusArea.aspx.cs" Inherits="web.Private.Psr.Finanziario.FocusArea" %>

<%@ Register Src="../../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaFA(codice) { $('[id$=hdnCodFA]').val(codice);swapTab(2); }
        function nuovaFA() { $('[id$=hdnCodFA]').val('');$('[id$=txtCodice_text]').val('');$('[id$=txtDescrizione_text]').val('');$('[id$=lstPsr]').val('');$('[id$=chkObTrasversale]')[0].checked=false;$('[id$=btnElimina]')[0].disabled='disabled';$('[id$=trDotazioneFinanziaria]').hide(); }
        function checkDgProgInputColumnsOnLoad_handler() { $('[id*=_dglstContributoFA_]').each(function() { lstChange_handler(this); }); }
        function lstChange_handler(elem) { var id_programmazione=elem.id.substring(elem.id.lastIndexOf('_')+1);dgTxtDotFinanziariaEnable(document.getElementById('dgTxtDotFinanziaria'+id_programmazione+'_text'),elem.value=="D"); }
        function dgTxtDotFinanziariaEnable(txt,enable) { if(enable) { txt.disabled='';txt.onblur=ricalcolaTotale; } else { txt.value=0;txt.disabled='disabled';txt.onblur=null; } }
        function ricalcolaTotale() { var txts=$('[id^=dgTxtDotFinanziaria][id$=_text]'),totale=0;for(var i=0;i<txts.length;i++) { var parziale=FromCurrencyToNumber(txts[i].value);if(!isNaN(parziale)) totale+=parziale; } $('[id$=dgTotFooterDotFinanziaria_text]').val(FromNumberToCurrency(totale)); }
    </script>

    <input type="hidden" id="hdnCodFA" runat="server" />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" Width="950px" TabNames="Elenco|Dettaglio|Ricerca per Operazione" />
    <table id="tabElenco" runat="server" width="950px" class="tableTab" visible="false">
        <tr>
            <td class="testo_pagina">
                Elenco generale delle Focus Area.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgFA" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="50px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodPsr" HeaderText="Codice programma">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Codice" LinkFormat="selezionaFA('{0}');">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Trasversale" HeaderText="Obiettivo trasversale" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DotFinanziaria" HeaderText="Totale dotazione finanziaria"
                            DataFormatString="{0:c}">
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <table id="tabDettaglio" runat="server" width="950px" class="tableTab" visible="false">
        <tr>
            <td class="paragrafo">
                <br />
                Dettaglio Focus Area selezionata:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 180px">
                            Codice:<br />
                            <Siar:TextBox ID="txtCodice" runat="server" Width="130px" NomeCampo="Codice" Obbligatorio="True"
                                MaxLength="10" />
                        </td>
                        <td>
                            <br />
                            <asp:CheckBox ID="chkObTrasversale" runat="server" Text="Obiettivo trasversale" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            Programma:<br />
                            <Siar:ComboZPsr ID="lstPsr" runat="server" NomeCampo="Psr" Obbligatorio="True">
                            </Siar:ComboZPsr>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrizione:<br />
                            <Siar:TextArea ID="txtDescrizione" runat="server" Width="726px" NomeCampo="Descrizione"
                                Obbligatorio="True" MaxLength="255" Rows="7" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 55px; padding-right: 50px" align="right">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="137px"
                                OnClick="btnSalva_Click" />
                            &nbsp;&nbsp;
                            <Siar:Button ID="btnElimina" runat="server" Modifica="True" Text="Elimina" Width="137px"
                                CausesValidation="false" OnClick="btnElimina_Click" Conferma="Attenzione! Eliminare la Focus Area selezionata?" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <input class="Button" style="width: 120px" type="button" value="Nuova" onclick="nuovaFA();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="trDotazioneFinanziaria" runat="server" visible="false">
            <td>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="paragrafo">
                            Dotazione finanziaria:
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-bottom: 10px; padding-top: 10px">
                            <Siar:DataGrid ID="dgProgrammazione" runat="server" AutoGenerateColumns="False" Width="100%"
                                ShowFooter="true" FooterStyle-CssClass="TotaliFooter">
                                <ItemStyle Height="28px" />
                                <Columns>
                                    <Siar:NumberColumn>
                                        <ItemStyle Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="ProgCodice" HeaderText="Codice">
                                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ProgTipo" HeaderText="Livello">
                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="ProgDescrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Contributo">
                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <Siar:ImportoColumn DataField="IdProgrammazione" Importo="DotFinanziaria" Name="dgTxtDotFinanziaria"
                                        HeaderText="Dotazione finanziaria €" ReadOnly="true">
                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    </Siar:ImportoColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right: 50px; height: 46px;" align="right">
                            <Siar:Button ID="btnSalvaDotazione" runat="server" Modifica="True" Text="Salva" Width="150px"
                                OnClick="btnSalvaDotazione_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table id="tabOperazione" runat="server" width="950px" class="tableTab" visible="false">
        <tr>
            <td class="testo_pagina">
                <br />
                Selezionare la programmazione desiderata:
                <br />
                <Siar:ComboGroupZProgrammazione ID="lstProgrammazione" runat="server" AttivazioneBandi="true"
                    Width="670px">
                </Siar:ComboGroupZProgrammazione>
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgFAXOperazione" runat="server" AutoGenerateColumns="False" Width="100%">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle Width="50px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodFa" HeaderText="Codice">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FaDescrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Trasversale" HeaderText="Obiettivo trasversale" DataFormatString="{0:SI|NO}">
                            <ItemStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoContributo" HeaderText="Tipo contributo" DataFormatString="{0:D=Diretto|I=Indiretto}">
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DotFinanziaria" HeaderText="Totale dotazione finanziaria"
                            DataFormatString="{0:c}">
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
</asp:Content>
