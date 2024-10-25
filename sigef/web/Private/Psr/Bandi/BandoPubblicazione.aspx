<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Psr.Bandi.BandoPubblicazione" CodeBehind="BandoPubblicazione.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--

        function mostraChecklist(id) { $('[id$=hdnIdChecklist]').val(id);$('[id$=btnVisualizzachecklist]').click(); }
        function chiudiPopup() { $('[id$=hdnIdChecklist]').val('');$('[id$=hdnIdscheda]').val('');chiudiPopupTemplate(); }
        function vaiChecklist() { var id=$('[id$=hdnIdChecklist]').val();self.location='../../regione/CheckList.aspx?action=visualizza&id='+id; }
        function mostraScheda() { var id=Number($('[id$=lstSchedaValutazione]').val());if(id>0) { $('[id$=hdnIdscheda]').val(id);$('[id$=btnVisualizzaScheda]').click(); } else alert('Per proseguire è necessario selezionare una scheda di valutazione.'); }
        function vaiScheda() { document.location='../../regione/schedavalutazione.aspx?ids='+$('[id$=hdnIdscheda]').val(); }
//--></script>

    <div style="display: none">
        <Siar:Button ID="btnVisualizzachecklist" runat="server" OnClick="btnVisualizzachecklist_Click"
            CausesValidation="False" />
        <Siar:Button ID="btnVisualizzaScheda" runat="server" OnClick="btnVisualizzaScheda_Click"
            CausesValidation="False" />
        <asp:HiddenField ID="hdnIdChecklist" runat="server" />
        <asp:HiddenField ID="hdnIdscheda" runat="server" />
    </div>
    <br />
    <table class="tableNoTab" width="950px">
        <tr>
            <td class="separatore">
                &nbsp;Scheda procedurale del bando
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <b>Selezionare la scheda di valutazione:</b>
                <br />
                <Siar:ComboSchedaValutazione ID="lstSchedaValutazione" runat="server" Obbligatorio="true"
                    Width="620px" NomeCampo="Scheda di valutazione" DataColumn="IdSchedaValutazione">
                </Siar:ComboSchedaValutazione>
                &nbsp; &nbsp;
                <input type="button" value="Visualizza" onclick="mostraScheda()" class="ButtonGrid"
                    style="width: 70px" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore" valign="top">
                &nbsp;Checklist operative:
            </td>
        </tr>
        <tr>
            <td valign="top" class="testo_pagina">
                &nbsp;Selezionare per ognuna delle fasi della domanda la check list operativa corrispondente:
            </td>
        </tr>
        <tr>
            <td valign="top">
                <Siar:DataGrid ID="dgChecklist" runat="server" Width="100%" AllowPaging="False" AutoGenerateColumns="False"
                    CssClass="tabella">
                    <Columns>
                        <asp:BoundColumn DataField="CodFase" HeaderText="Codice Fase">
                            <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Descrizione Fase">
                            <ItemStyle Width="160px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Checklist associata">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" class="separatore">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 64px">
                <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva" Width="190px"
                    Modifica="true" />
            </td>
        </tr>
    </table>
    <div id="divSchedaForm" style="display: none; width: 850px; position: absolute">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore" colspan="2">
                    DETTAGLIO SCHEDA DI VALUTAZIONE
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 22px;">
                </td>
                <td style="height: 25px">
                    <strong>Descrizione:</strong>
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    <Siar:TextArea ID="txtScheda" runat="server" Width="700px" ReadOnly="true"></Siar:TextArea>
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 23px;">
                </td>
                <td style="height: 23px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    <Siar:DataGrid ID="dgPriorita" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="true" PageSize="8">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn HeaderText="Descrizione" DataField="Priorita"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CodLivello" HeaderText="Livello di dettaglio" DataFormatString="{0:D=Domanda|I=Investimento|S=Settoriale|Z=Zona svantaggiata|T=Zona montanta|F=Investimento fisso|M=Investimento mobile}">
                                <ItemStyle HorizontalAlign="center" Width="90px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Peso" HeaderText="Peso %">
                                <ItemStyle Width="110px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="AiutoAddizionale" HeaderText="Aiuto Addizionale">
                                <ItemStyle Width="110px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PluriValore" HeaderText="Pluri Valore" DataFormatString="{0:SI|NO}">
                                <ItemStyle Width="110px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Selezionabile" HeaderText="Visualizza" DataFormatString="{0:SI|NO}">
                                <ItemStyle Width="110px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 22px;" colspan="2" class="paragrafo">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10px">
                    &nbsp;
                </td>
                <td align="right">
                    <br />
                    <input id="btnVaiScheda" class="Button" onclick="vaiScheda()" style="width: 120px"
                        type="button" value="Vai alla scheda" />&nbsp;&nbsp;
                    <input id="Button2" class="Button" onclick="chiudiPopup()" style="width: 120px" type="button"
                        value="Chiudi" />
                    &nbsp;<br />
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="divCheckListForm" style="display: none; width: 850px; position: absolute">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore" colspan="2">
                    DETTAGLIO CHECKLIST
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 22px;">
                </td>
                <td style="height: 25px">
                    <strong>Descrizione:</strong>
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    <Siar:TextArea ID="txtDescrizione" runat="server" Width="500px" ReadOnly="true">
                    </Siar:TextArea>
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 23px;">
                </td>
                <td style="height: 23px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    Elementi trovati:
                    <Siar:Label ID="lblNumeroStep" runat="server">
                    </Siar:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 10px">
                    &nbsp;
                </td>
                <td>
                    <Siar:DataGrid ID="dgStep" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="true" PageSize="13">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn HeaderText="Descrizione" DataField="Step"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale">
                                <ItemStyle Width="110px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Automatico" HeaderText="Automatico" DataFormatString="{0:SI|NO}">
                                <ItemStyle Width="80px" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGrid>
                </td>
            </tr>
            <tr>
                <td style="width: 10px; height: 22px;" colspan="2" class="paragrafo">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10px">
                    &nbsp;
                </td>
                <td align="right">
                    <br />
                    <input id="btnVaiChecklist" class="Button" onclick="vaiChecklist()" style="width: 120px"
                        type="button" value="Vai alla cheklist" />&nbsp;&nbsp;
                    <input id="btnChiudi" class="Button" onclick="chiudiPopup()" style="width: 120px"
                        type="button" value="Chiudi" />
                    &nbsp;<br />
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
