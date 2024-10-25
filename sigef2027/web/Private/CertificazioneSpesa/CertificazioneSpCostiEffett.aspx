<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master"
    CodeBehind="CertificazioneSpCostiEffett.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneSpCostiEffett" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableNoTab" width="1000">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 400px">
                            Programmazione:<br />
                            <Siar:ComboZPsr ID="lstPsr" runat="server" Obbligatorio="true" NomeCampo="Psr" Width="350px"></Siar:ComboZPsr>
                        </td>
                        <td style="width: 130px">
                            Data inizio:<br />
                            <Siar:DateTextBox ID="txtDataInizio" runat="server" Width="104px" />
                        </td>
                        <td style="width: 130px">
                            Data fine:<br />
                            <Siar:DateTextBox ID="txtDataFine" runat="server" Width="104px" />
                        </td>
                        <td style="width: 140px">
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="150px" />
                        </td>
                        <td style="width: 140px">
                            <Siar:Button ID="btnEstraiSpese" runat="server" OnClick="btnEstrai_Click" Text="Estrai" Width="150px" />
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
        <tr>
            <td class="separatore_big">
                Dati relativi alle spese nella richiesta di pagamento del beneficiario sulla base
                dei costi effettivi (nella valuta applicabile all'operazione)
            </td>
        </tr>

        <tr>
            <td>
                <Siar:DataGridAgid ID="dgCostiEff" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Azione">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Progetto">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo domanda pagamento">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Spese ammissibili dichiarate alla Commissione, stabilite sulla base dei costi effettivamente sostenuti e pagati unitamente, se del caso, a contributi in natura e ammortamenti">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Spesa pubblica ai sensi dell'articolo 2, paragrafo 15, del regolamento (UE) n. 1303/2013 corrispondente alle spese ammissibili dichiarate alla Commissione stabilite sulla base dei costi effettivamente rimborsati e pagati unitamente, se del caso, a contributi in natura e ammortamenti">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Tipo di appalto se l'aggiudicazione è disciplinata dalle disposizioni della direttiva 2004/17/CE (4) o della direttiva 2004/18/CE (5) (appalto di lavori/di forniture/di servizi) o della direttiva 2014/23/UE del Parlamento europeo e del Consiglio (6)">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo dell'appalto, se l'aggiudicazione è disciplinata dalle disposizioni della direttiva 2004/17/CE o della direttiva 2004/18/CE o della direttiva 2014/23/UE">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Spese ammissibili sostenute e pagate in base a un contratto di appalto, se quest'ultimo è disciplinato dalle Spese disposizioni della direttiva 2004/17/CE o della direttiva 2004/18/CE o della direttiva 2014/23/UE">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Procedura di aggiudicazione seguita qualora l'aggiudicazione sia disciplinata dalle disposizioni della direttiva 2004/17/CE o della direttiva 2004/18/CE o della direttiva 2014/23/UE">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cod.Fiscale/Partita Iva del contraente qualora l'aggiudicazione sia disciplinata dalle disposizioni della direttiva 2004/17/CE o della direttiva 2004/18/CE o della direttiva 2014/23/UE">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </td>
        </tr>
   </table>
</asp:Content>
