<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiarPage.master"
    CodeBehind="CertificazioneSpesa.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneSpesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function estraiInXls() {
            var psr = $('[id$=lstPsr]').val(),
                data_inizio = $('[id$=txtDataInizio_text]').val(),
                data_fine = $('[id$=txtDataFine_text]').val();
            if (psr == '')
                alert("Specificare il Programma di sviluppo desiderato.");
            else if (data_inizio == '') 
                alert("Specificare la data di inizio del periodo.");
            else 
                SNCVisualizzaReport('rptCertificazioniRiepilogoSpesa',2,"CodPsr="+psr+"|DataInizio="+data_inizio+(data_fine==''?'':"|DataFine="+data_fine));
        }
    </script>

    <br />
    <table class="tableNoTab" width="1000">
        <tr>
            <td class="separatore">
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <table width="100%">
                    <tr>
                        <td style="width: 400px">
                            Programmazione:<br />
                            <Siar:ComboZPsr ID="lstPsr" runat="server" Obbligatorio="true" NomeCampo="Psr" Width="350px"></Siar:ComboZPsr>
                        </td>
                        <td style="width: 130px">
                            Data inizio:<br />
                            <Siar:DateTextBox ID="txtDataInizio" runat="server" Width="104px" />
                        </td>
                        <td style="width: 126px">
                            Data fine:<br />
                            <Siar:DateTextBox ID="txtDataFine" runat="server" Width="104px" />
                        </td>
                        <td style="width: 140px">
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="140px" />
                        </td>
                        <td style="width: 140px">
                            <br />
                            <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls();" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Spesa suddivisa per priorità e per categoria di regioni, come contabilizzata dall'autorità
                di certificazione
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                compresi gli importi dei contributi per programma erogati agli strumenti finanziari
                (articolo 41 del regolamento (UE) n. 1303/2013) e gli anticipi versati nel quadro
                di aiuti di Stato (articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013)
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSpese" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Base calcolo (solo contributo pubblico o spesa totale compresa quella dei privati o altro pubblico)">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo totale della spesa pubblica relativa all'attuazione delle operazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
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
            <td class="separatore_big">
                Informazioni sugli importi dei contributi per programma erogati agli strumenti finanziari
                e inclusi nelle domande di pagamento
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Come da articolo 41 del regolamento (UE) n. 1303/2013. I dati sono cumulativi dall'inizio
                del programma.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSpeseStrumentiFinanziari" ShowFooter="true" runat="server" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo dei contributi per programma erogati agli strumenti finanziari">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo della spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo della spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
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
            <td class="separatore_big">
                Anticipi versati nel quadro di aiuti di Stato
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013) e inclusi nelle domande
                di pagamento (dati cumulativi dall'inizio del programmma.
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgSpeseAnticipi" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo complessivo versato come anticipo dal programma operativo">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo che è stato coperto dalle spese sostenute dai beneficiari entro tre anni dal pagamento dell'anticipo">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
