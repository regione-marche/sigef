<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RequisitiCovid.aspx.cs" Inherits="web.Private.COVID.RequisitiCovid" %>

<%@ Register Src="../../CONTROLS/DatiBandoCovid.ascx" TagName="DatiBandoCovid" TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/FirmaDocumentoCovid.ascx" TagName="FirmaDocumento" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function selezionaPlurivalore(jobj) { if (jobj == null) alert('L`elemento selezionato non è valido.'); else { $('[id$=lblPlurivaloreSelezionato' + jobj.IdPriorita + ']').text(jobj.Descrizione); $('[id$=hdnPlurivaloreSelezionato' + jobj.IdPriorita + ']').val(jobj.IdValore); } }
        function deselezionaPlurivalore(id) { $('[id$=lblPlurivaloreSelezionato' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); }
        function selezionaPlurivaloreSql(jobj) { if (jobj == null) alert('L`elemento selezionato non è valido.'); else { $('[id$=lblPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').text(jobj.Descrizione); $('[id$=hdnPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').val(jobj.Codice); } }
        function deselezionaPlurivaloreSql(id) { $('[id$=lblPlurivaloreSelezionatoSql' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionatoSql' + id + ']').val(''); }
        function presentazione_warnings(messaggio) { confirm(messaggio); }
    </script>
    <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }
    </style>
    <div style="text-align: center">
        <h1>Requisiti Domanda di Contributo</h1>
    </div>
    <uc4:DatiBandoCovid ID="datibandocod" runat="server" />
    <div class="dBox" style="padding: 20px" runat="server">
        <div>
            <table width="800px">
                <tr>
                    <td id="tdControls" runat="server" style="padding-top: 10px; padding-bottom: 10px"></td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <div class="paragrafo">
                                Dichiarazioni OBBLIGATORIE
                            </div>
                            <div style="padding-top: 10px">
                                <Siar:DataGrid ID="dgObbligatorie" runat="server" AutoGenerateColumns="False" EnableViewState="False"
                                    PageSize="20" Width="100%">
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                            <ItemStyle Width="35px" HorizontalAlign="center" />
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="Descrizione" HeaderText="Dichiarazione"></asp:BoundColumn>
                                    </Columns>
                                </Siar:DataGrid><br />
                            </div>
                            <div class="paragrafo" id="divLbFac" runat="server">
                                Dichiarazioni OBBLIGATORIE CON SCELTA ALTERNATIVA per la presentazione della domanda:
                            </div>
                            <div style="padding-top: 10px" id="divDgFac" runat="server">
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
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <Siar:Button ID="btnSalva" runat="server" Width="220px" Text="Salva e accetta dichiarazioni"
                CausesValidation="true" OnClick="btnSalva_Click" />
            <%--<input id="btnGo" type="button" class="Button"
                value="Prosegui" style="width: 220px; margin-left: 40px" runat="server" />--%>
            <Siar:Button ID="btnGo" runat="server" Width="220px" Text="Prosegui"
                CausesValidation="false" OnClick="btnProsegui_Click" />
            <Siar:Button ID="btnPresenta" runat="server" Width="220px" Text="Rendi DEFINITIVA la Pre Domanda"
                CausesValidation="true" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della pre domanda di richiesta contributo. Continuare?"
                OnClick="btnPresenta_Click" Enabled="true" Visible="false"/>
            <Siar:Button ID="btnInviaRichiesta" runat="server" Text="Genera Richiesta Contributo" Width="220px" CausesValidation="true" OnClick="btnInviaRichiesta_Click" Conferma="Attenzione! Una volta resa definitiva, non sarà più possibile modificare i dati della domanda di richiesta contributo. Continuare?" />
            <input id="btnBack" type="button" class="Button"
                value="Indietro" style="width: 220px;" onClick="javascript:window.location.href='Autocertificazione.aspx'" />
            <Siar:Button ID="btnElimina" runat="server" Width="220px" Text="Elimina domanda"
                        OnClick="btnElimina_Click" Conferma="Attenzione! Una volta eliminata la domanda bisognerà ricrearla completamente. Continuare?"></Siar:Button>
        </div>
        <div runat="server" id="divButtonAmm" visible="false">
            <div>
                <br />
            </div>
            <input id="btnAvanti" type="button" class="Button"
                value="Avanti" style="width: 220px;" onClick="javascript: window.location.href = 'ProgettoCovid.aspx'" />
        </div>
    </div>
    <uc2:FirmaDocumento ID="ucFirmaDocumentoCovid" runat="server" TitoloControllo="RICHIESTA CONTRIBUTO"
        TipoDocumento="COVID_DOMANDA" />
</asp:Content>
