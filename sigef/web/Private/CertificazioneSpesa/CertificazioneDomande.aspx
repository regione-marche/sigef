<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="CertificazioneDomande.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneDomande" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaDomanda(id) 
        {
            $('[id$=hdnIdDomanda').val(id);
            $('[id$=btnSelezionaDomanda]').click();
        }
        function ctrlCampiRicercaNormeMarche(ev) 
        {
            if ($('[id$=txtAttoNumero_text]').val() == "" ||
                $('[id$=txtAttoData_text]').val() == "" ||
                $('[id$=lstAttoRegistro]').val() == "") 
            {
                alert('Per la ricerca degli atti è necessario specificare numero, data e registro.');
                return stopEvent(ev);
            }
        }
        function ctrlTipoAtto(ev) 
        {
            if ($('[id$=hdnIdAttoNew]').val() == "") 
            {
                alert('Per proseguire è necessario specificare un atto.');
                return stopEvent(ev);
            }
            else if ($('[id$=lstAttoTipo]').val() == "") 
            {
                alert('Per proseguire è necessario specificare la tipologia dell`atto.');
                return stopEvent(ev);
            }
        }
        function chiudiPopup() 
        {
            $('[id$=hdnIdAttoNew]').val('');
            $('[id$=lstAttoOrgIstituzionale]').val('');
            $('[id$=lstAttoTipo]').val('');
            chiudiPopupTemplate();
        }
    </script>

    <div id="divHidden" style="display: none">       
        <asp:HiddenField ID="hdnIdDomanda" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnIdAttoNew" runat="server" />
        <asp:Button ID="btnSelezionaDomanda" runat="server" OnClick="btnSelezionaDomanda_Click" CausesValidation="false" />
    </div>
    
    <div id="divElenco" runat="server">
        <table class="tableTab" id="tblElencoH" runat="server" width="1000px">
        <tr class="separatore_big">
            <td style="width:40%">
                Selezionare la domanda da modificare
            </td>
            <td>
                <Siar:Button ID="btnNuovo" runat="server" Text="Nuova" OnClick="btnNuovo_OnClick" Width="150px" />
            </td>
        </tr>
        </table>
        <table class="tableTab" id="tblElencoR" runat="server" width="1000px">
        <tr>
            <td>
                <Siar:DataGrid ID="dgDomande" runat="server" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="IdDomanda" HeaderText="Id Domanda"></asp:BoundColumn>
                        <%-- <asp:BoundColumn DataField="IdProgetto" HeaderText="Progetto"></asp:BoundColumn> --%>
                        <asp:BoundColumn DataField="IdAtto" HeaderText="Atto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataPres" HeaderText="Data Presentazione"></asp:BoundColumn>
                        <Siar:ColonnaLink DataField="SpeseAmm" HeaderText="Spese Ammissibili" IsJavascript="true" LinkFields="IdDomanda" 
                                          LinkFormat="selezionaDomanda({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="SpesaPubb" HeaderText="Spesa Pubblica"></asp:BoundColumn>                    
                        <asp:BoundColumn DataField="SfTot" HeaderText="Stru.Finan.Compl."></asp:BoundColumn>
                        <asp:BoundColumn DataField="SfSpesaPubb" HeaderText="Stru.Fin. Spesa Pubb."></asp:BoundColumn>
                        <asp:BoundColumn DataField="SfSpeseAmm" HeaderText="Stru.Fin. Spese Amm."></asp:BoundColumn>
                        <asp:BoundColumn DataField="SfSpesaPubbAmm" HeaderText="Stru.Fin. Spesa Pubb. Amm."></asp:BoundColumn>
                        <asp:BoundColumn DataField="AsTot" HeaderText="Aiuti Stato"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AsCoperto" HeaderText="Aiuti Stato Coperto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="AsNonCoperto" HeaderText="Aiuti Stato Non Coperto"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        </table>
    </div>
    
    <div id="divDettaglio" runat="server">
        <table class="tableTab" id="tblDettaglioH" runat="server" width="1000px" >
        <tr class="separatore_big">
            <td style="width:40%">
                Dettaglio Domanda
            </td>
            <td>
                <Siar:Button ID="btnElenco" runat="server" Text="Ritorna all'elenco" OnClick="btnRitorna_OnClick" 
                             width="150px" CausesValidation="false"/>
            </td>
        </tr>
        </table>
        <table class="tableTab" id="tblDettaglioR" runat="server" width="1000px" cellspacing="15" >
        <tr>
            <td style="width:300px">
                Id Domanda
            </td>
            <td valign="top">
                <asp:TextBox ID="txtIdDomanda" runat="server" width="150px" Enabled="false">
                </asp:TextBox>
            </td>
        </tr>
        <%--
        <tr>
            <td>
                Id Progetto
            </td>
            <td>
                <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" Width="150px" NoCurrency="True" />
            </td>
        </tr>
        --%>
        <tr>
            <td>
                Atto
            </td>
            <td>
                <table id="tblIdAtto" >
                    <tr>
                        <td>
                            Numero
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdAttoNr" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdAttoDt" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Registro
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdAttoRe" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Siar:Button ID="btnCercaAtto" runat="server" Text="Cerca Atto" OnClick="btnCercaAtto_Click" Width="100px" 
                                         Modifica="true" CausesValidation="false" />       
                        </td>
                    </tr>
                </table>          
            </td>
        </tr>
        <tr>
            <td>
                Data presentazione
            </td>
            <td>
                <Siar:DateTextBox ID="txtDataPres" runat="server" Width="100px" Obbligatorio="true" NomeCampo="Data presentazione" />
            </td>
        </tr>
        <tr>
            <td>
                Spese ammissibili: importo complessivo delle spese sostenute dal beneficiario e pagate per l'esecuzione
                dell'operazione, incluso in ciascuna domanda di pagamento
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSpeseAmm" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Spesa pubblica: importo totale della spesa pubblica ai sensi dell'articolo 2, paragrafo 15, del regolamento (UE)
                n. 1303/2013 relativa all'operazione, incluso in ciascuna domanda di pagamento
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSpesaPubb" runat="server" Width="150px"/>
            </td>
        </tr>
        <tr>
            <td>
                Strumento finanziario - importo complessivo: Se l'operazione è uno strumento finanziario, importo complessivo dei 
                contributi del programma erogati agli strumenti finanziari, incluso in ciascuna domanda di pagamento
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSfTot" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Strumento finanziario - spesa pubblica: Se l'operazione è uno strumento finanziario, importo totale della spesa pubblica
                ai sensi dell'articolo 2, paragrafo 15, del regolamento (UE) n. 1303/2013, corrispondente all'importo complessivo dei
                contributi del programma erogati agli strumenti finanziari, incluso in ciasuna domanda di pagamento
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSfSpesaPubb" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Strumento finanziario - spese ammissibili: Se l'operazione è uno strumento finanziario, importo complessivo dei contributi 
                del programma effettivamentie pagati come spese ammissibili ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del
                regolamento (UE) n. 1303/2013, incluso in ciascuna domanda di pagamento
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSfSpeseAmm" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Strumento finanziario - spesa pubblica ammissibile: Se l'operazione è uno strumento finanziario, importo totale della spesa 
                pubblica corrispondente all'importo complessivo dei contributi del programma effettivamente pagati come spese ammissibili ai 
                sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013, incluso in ciascuna domanda
                di pagamento
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSfSpesaPubbAmm" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Aiuti di Stato: nel caso di aiuti di Stato cui si applichi l'articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013,
                importo versato al beneficiario nel quadro dell'operazione come anticipato incluso in ciascuna domanda di pagamento.
            </td>
            <td>
                <Siar:CurrencyBox ID="txtAsTot" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Aiuti di Stato coperto: nel caso di aiuti di Stato cui si applichi l'articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013,
                importo dell'anticipo incluso in ciascuna domanda di pagamento che sia stato coperto da spese sostenute dal beneficiario entro tre
                anni dal pagamento dell'anticipo
            </td>
            <td>
                <Siar:CurrencyBox ID="txtAsCoperto" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Aiuti di Stato non coperto: nel caso di aiuti di Stato cui si applichi l'articolo 131, paragrafo 5, del regolamento (UE)
                n. 1303/2013, importo versato al beneficiario nel quadro dell'operazione come anticipo incluso in una domanda di pagamento che
                non sia stato coperto da spese sostenute dal beneficiario e per il quale non sia ancora trascorso il periodo di tre anni
            </td>
            <td>
                <Siar:CurrencyBox ID="txtAsNonCoperto" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva domanda" OnClick="btnSalva_OnClick" Width="150px" />
                <Siar:Button ID="btnCancella" runat="server" Text="Cancella domanda" OnClick="btnCancella_OnClick" 
                             Width="150px" CausesValidation="false" />
                <br /> <br />
            </td>
        </tr>
        </table>
    </div>
    
    <div id="divDecreto" style="width: 850px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Caricamento Atto di Concessione/Non Finanziabilità
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 100px">
                                Definizione:<br />
                                <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True" Width="80px"></Siar:ComboDefinizioneAtto>
                            </td>
                            <td style="width: 100px">
                                Numero:<br />
                                <Siar:IntegerTextBox ID="txtAttoNumero" NoCurrency="True" runat="server" Width="80px" NomeCampo="Numero decreto" />
                            </td>
                            <td style="width: 120px">
                                Data:<br />
                                <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                            </td>
                            <td style="width: 155px">
                                Registro:<br />
                                <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="120px"></Siar:ComboRegistriAtto>
                            </td>
                            <td>
                                <br />
                                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click" Text="Ricerca" 
                                             Width="120px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                Descrizione:<br />
                                <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="650px" ReadOnly="True"
                                               Rows="4" ExpandableRows="5"></Siar:TextArea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 260px">
                                            Organo Istituzionale:<br />
                                            <Siar:ComboOrganoIstituzionale ID="lstAttoOrgIstituzionale" runat="server" Width="210px" Enabled="False">
                                            </Siar:ComboOrganoIstituzionale>
                                        </td>
                                        <td>
                                            Tipo atto:<br />
                                            <Siar:ComboTipoAtto ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto"></Siar:ComboTipoAtto>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="350px">
                                    <tr>
                                        <td class="paragrafo" colspan="2">
                                            Pubblicazione B.U.R.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px">
                                            Numero:<br />
                                            <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                        <td>
                                            Data:<br />
                                            <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trDataComunicazione" runat="server" visible="false">
                <td style="padding-left: 10px">
                    Data del CDA per i GAL / Determina per le Province:<br />
                    <Siar:DateTextBox ID="txtAttoDataXComunicazione" runat="server" Width="100px" NomeCampo="Data per Comunicazione" />
                    <br /> <br />
                </td>
            </tr>
            <tr>
                <td class="separatore_light">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 58px; padding-right: 40px" align="right">
                    &nbsp;
                    <Siar:Button ID="btnAttoSeleziona" 
                                 runat="server" 
                                 OnClick="btnAttoSeleziona_Click"
                                 OnClientClick="return ctrlTipoAtto(event);" 
                                 Enabled="false" 
                                 Text="Seleziona Atto"
                                 Width="180px" 
                                 Modifica="true"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input class="Button" 
                           onclick="chiudiPopup()" 
                           style="width: 120px; margin-left: 80px" 
                           type="button" 
                           value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
