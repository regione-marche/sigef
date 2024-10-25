<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.DatiGenerali" CodeBehind="DatiGenerali.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        var tb_riesame;
        function dettaglioRiesame(elem,accolto,motivazioni) {
            var coords=getElementOffsetCoords(elem);
            if(!tb_riesame) { tb_riesame=document.createElement("table");document.body.appendChild(tb_riesame);$(tb_riesame).addClass('tableNoTab').css({ 'position': 'absolute','width': '445px' }); }
            $(tb_riesame).css({ "top": coords.y-80,"left": coords.x+102 }).html("<tr><td class=separatore>DETTAGLIO DELLA RICHESTA DI RIESAME</td></tr><tr><td style='padding:5px'>Accolta: <b>"+(accolto?"SI":"NO")+"</b></td></tr><tr><td style='padding:5px;padding-bottom:10px'>Motivazione:<br/><textarea cols=20 rows='5' style='width:420px'>"+motivazioni+"</textarea></td></tr></table>").show();
            window.setTimeout(function() { $(document).click(function(e) { if(tb_riesame) { $(tb_riesame).hide();$(document).unbind('click'); } }); },30);
        }
//--></script>

    <table class="tableTab" width="800">
        <tr>
            <td align="center">
                <input id="btnPrev" class="ButtonProsegui BPSelect" style="visibility: hidden; width: 64px;"
                    type="button" value="<<< (0/7)" />
                <input id="btnCurrent" class="ButtonProsegui BPDisabled" style="width: 40px" disabled="disabled"
                    type="button" value="(1/7)" runat="server"/>
                <input id="btnGo" class="ButtonProsegui" onclick="location='Anagrafica.aspx'" style="width: 64px;"
                    type="button" value="(2/7) >>>" runat="server" />
            </td>
        </tr>
    </table>
    &nbsp;<br />
    <table id="Table1" class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                Dati generali della domanda di aiuto:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                &nbsp;Questa sezione illustra, in ordine cronoloogico le varie fasi procedurali
                a cui viene sottoposta la domanda. Alla conclusione
                <br />
                &nbsp;di ogni fase viene assegnato uno stato alla domanda &nbsp;che indica l'esito
                conseguito e l'operatore che ha effettuato il passaggio.<br />
                &nbsp;Al termine sarà qui indicato l'intero iter procedurale seguito dalla pratica.<br />
                &nbsp;Consultare questa sezione ogni volta si voglia sapere a che punto dell'iter
                si trovi la domanda.<br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Iter procedurale:
            </td>
        </tr>
        <tr>
            <td style="height: 31px">
                &nbsp;- Lista dei passaggi di <strong>stato</strong> e relativo operatore
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Procedura di attribuzione dello stato">
                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo">
                            <ItemStyle Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle Width="140px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
                &nbsp;- Lista delle <strong>comunicazioni</strong> effettuate ed altri documenti
                registrati per la domanda di aiuto
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSegnature" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo documento">
                            <ItemStyle Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
                &nbsp;- Lista delle <strong>domande di pagamento</strong> effettuate e relative
                comunicazioni
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgDomandePagamento" runat="server" AutoGenerateColumns="False"
                    Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo documento">
                            <ItemStyle Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 30px">
                &nbsp;- Lista delle <strong>varianti/variazioni finanziarie/a.t.</strong> effettuate e relative comunicazioni
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgVarianti" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="Data" HeaderText="Data documento">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo documento">
                            <ItemStyle Width="240px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Profilo" HeaderText="Ruolo">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Ente" HeaderText="Ente">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
        <tr>
            <td id="tdFase2" runat="server">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Annullamento della domanda di aiuto
            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;&nbsp; Questa procedura cancellerà completamente dal sistema questa domanda
                come se non fosse mai stata inserita e<br />
                &nbsp;&nbsp; l`impresa potrà inserirne una nuova. E' possibile utilizzarla quando
                la domanda non è ancora resa definitiva ed è consigliato utilizzarla quando
                <br />
                &nbsp;&nbsp; le modifiche da eseguire sulla stessa siano più onerose che inserirne
                una nuova.<br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 46px">
                <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Conferma="Attenzione! Questo eliminerà definitivamente la domanda dal sistema. Continuare?"
                    Modifica="True" OnClick="btnElimina_Click" Text="Annulla domanda" Width="200px">
                </Siar:Button>
            </td>
        </tr>
        <tr  id="trSeparPec" runat="server" visible ="false">
            <td class="separatore">
                &nbsp;Pec Ufficio Referente del progetto
            </td>
        </tr>
        <tr  id="trPec" runat="server" visible ="false">
            <td style="padding-left:15px">
                <br />
                &nbsp;&nbsp;Per i progetti presentati da enti pubblici è possibile inserire un'ulteriore indirizzo di PEC relativo all'ufficio dell'ente che gestisce il progetto per poter ricevere le comunicazioni da parte della Regione Marche<br />
                &nbsp;
                <br />
                 &nbsp;<Siar:TextBox ID="txtPecUfficio" runat="server" Width="500px" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Indirizzo pec non corretto"
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtPecUfficio"
                    ValidationGroup="vgAnagraficaImpresa">#</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr  id="trButtonPec" runat="server" visible ="false">
            <td align="center" style="height: 46px">
                <Siar:Button ID="btnAggiungiPec" runat="server" CausesValidation="False" Conferma="Questo operazione associerà al progetto la PEC inserita dove l'ufficio potrà ricevere le comunicazioni da parte della Regione Marche. Continuare?"
                    enabled ="false" OnClick="btnAggiungiPec_Click" Text="Salva PEC" Width="200px">
                </Siar:Button>
            </td>
        </tr>
    </table>
</asp:Content>
