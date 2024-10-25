<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="RegistroIrregolarita.aspx.cs" Inherits="web.Private.Controlli.ControlliIrregolarita" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ZoomLoader.ascx" TagName="ZoomLoader" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaDisposizione(idDisposizione) {
            $('[id$=hdnIdDisposizione]').val(idDisposizione);
            $('[id$=btnCaricaDisposizione]').click();
        }
        function caricaIrregolarita(id) {
            $('[id$=hdnIdIrregolarita]').val(id);
            $('[id$=btnPost]').click();
        }
        function caricaRecupero(id) {
            $('[id$=hdnIdRecupero]').val(id);
            $('[id$=btnCaricaRecupero]').click();
        }
        function selezionaGiustificativo(obj, b) {
            if (obj != null && confirm('Associare il giustificativo selezionato all`irregolarita?'))
                $('[id$=btnCaricaGiustificativo]').click();
        }
        function escludiGiustificativo(id) {
            $('[id$=hdnGiustXIrr]').val(id);
            $('[id$=btnEscludiGiustificativo]').click();
        }
        function changeOrigine() {
            if ($('[id$=lstControlloOrigine]').val() == '10004') {
                $('[id$=divDescrizioneOrigineEsterno]').show();
            }
            else {
                $('[id$=divDescrizioneOrigineEsterno]').hide();
                $('[id$=txtDescrizioneControlloOrigineEsterno]').val('');
            }
        }
        function changeSegnalazioneOlaf() {
            if ($('[id$=lstSegnalazioneOlaf]').val() == '1') {
                $('[id$=divRiferimentoOlaf]').show();
            }
            else {
                $('[id$=divRiferimentoOlaf]').hide();
                $('[id$=txtNumRiferimentoOLAF]').val('');
            }
        }
        function checkDataPeriodo() {
            var radiovalue = $('[id$=rblDataPeriodo]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divDataIrregolarita]').hide();
                $('[id$=txtDataIrregolaritaCommessaIl]').val('');
                $('[id$=divPeriodoIrregolaritaDa]').show();
                $('[id$=divPeriodoIrregolaritaA]').show();
            }
            else {
                $('[id$=divDataIrregolarita]').show();
                $('[id$=divPeriodoIrregolaritaDa]').hide();
                $('[id$=txtDataIrregolaritaCommessaDa]').val('');
                $('[id$=divPeriodoIrregolaritaA]').hide();
                $('[id$=txtDataIrregolaritaCommessaA]').val('');
            }
        }
        function checkCategoriaIrregolarita() {
            var oldSel = $('[id$=lstTipoIrregolarita]').get(0);
            while (oldSel.options.length > 0) {
                oldSel.remove(oldSel.options.length - 1);
            }

            var catirr = $('[id$=lstCategoriaIrregolarita]').val();
            var i = 0;
            for (i = 0; i < jsonTipoIrregolarita.length; i++) {
                if (jsonTipoIrregolarita[i].IdPadre == Number(catirr)) {
                    var opt = document.createElement('option');
                    opt.text = jsonTipoIrregolarita[i].Descrizione;
                    opt.value = jsonTipoIrregolarita[i].Id;
                    oldSel.add(opt, null);
                }
            }
        }

        String.prototype.replaceAll = function (search, replacement) {
            var target = this;
            return target.split(search).join(replacement);
        };
        function convertToNumber(value) {
            return Number(value.replaceAll(".", "").replace(",", "."));
        }
        function sumAndConvertForCurrency(value1, value2) {
            return Number(value1 + value2).toLocaleString("it-IT", { minimumFractionDigits: 2 })
        }
        function aggiornaTotali() {
            //Importo della spesa
            var importoSpesaQuotaUe = convertToNumber($('[id$=txtImportoSpesaQuotaUe]').val());
            var importoSpesaQuotaNazionale = convertToNumber($('[id$=txtImportoSpesaQuotaNazionale]').val());
            $('[id$=txtImportoSpesaContributoPubblico]').val(sumAndConvertForCurrency(importoSpesaQuotaUe, importoSpesaQuotaNazionale));
            var importoSpesaPubblica = convertToNumber($('[id$=txtImportoSpesaContributoPubblico]').val());
            var importoSpesaPrivata = convertToNumber($('[id$=txtImportoSpesaContributoPrivato]').val());
            $('[id$=txtImportoSpesaTotale]').val(sumAndConvertForCurrency(importoSpesaPubblica, importoSpesaPrivata));

            //Irregolarita
            var importoIrregolaritaQuotaUe = convertToNumber($('[id$=txtImportoIrregolaritaQuotaUe]').val());
            var importoIrregolaritaQuotaNazionale = convertToNumber($('[id$=txtImportoIrregolaritaQuotaNazionale]').val());
            $('[id$=txtImportoIrregolaritaPubblica]').val(sumAndConvertForCurrency(importoIrregolaritaQuotaUe, importoIrregolaritaQuotaNazionale));
            var importoIrregolaritaPubblica = convertToNumber($('[id$=txtImportoIrregolaritaPubblica]').val());
            var importoIrregolaritaPrivata = convertToNumber($('[id$=txtImportoIrregolaritaPrivata]').val());
            $('[id$=txtImportoIrregolaritaTotale]').val(sumAndConvertForCurrency(importoIrregolaritaPubblica, importoIrregolaritaPrivata));

            //Irregolarita NON pagata
            var importoNonPagatoQuotaUe = convertToNumber($('[id$=txtImportoIrregolaritaNonPagatoQuotaUe]').val());
            var importoNonPagatoQuotaNazionale = convertToNumber($('[id$=txtImportoIrregolaritaNonPagatoQuotaNazionale]').val());
            $('[id$=txtImportoIrregolaritaNonPagatoQuotaPubblica]').val(sumAndConvertForCurrency(importoNonPagatoQuotaUe, importoNonPagatoQuotaNazionale));
            var importoNonPagatoPubblica = convertToNumber($('[id$=txtImportoIrregolaritaNonPagatoQuotaPubblica]').val());
            var importoNonPagatoPrivata = convertToNumber($('[id$=txtImportoIrregolaritaNonPagatoQuotaPrivata]').val());
            $('[id$=txtImportoIrregolaritaNonPagatoTotale]').val(sumAndConvertForCurrency(importoNonPagatoPubblica, importoNonPagatoPrivata));

            //Irregolarita PAGATA
            var importoPagatoQuotaUe = convertToNumber($('[id$=txtImportoIrregolaritaPagatoQuotaUe]').val());
            var importoPagatoQuotaNazionale = convertToNumber($('[id$=txtImportoIrregolaritaPagatoQuotaNazionale]').val());
            $('[id$=txtImportoIrregolaritaPagatoQuotaPubblica]').val(sumAndConvertForCurrency(importoPagatoQuotaUe, importoPagatoQuotaNazionale));
            var importoPagatoPubblica = convertToNumber($('[id$=txtImportoIrregolaritaPagatoQuotaPubblica]').val());
            var importoPagatoPrivata = convertToNumber($('[id$=txtImportoIrregolaritaPagatoQuotaPrivata]').val());
            $('[id$=txtImportoIrregolaritaPagatoTotale]').val(sumAndConvertForCurrency(importoPagatoPubblica, importoPagatoPrivata));

            //Importo da recuperare
            var importoRecuperareQuotaUe = convertToNumber($('[id$=txtImportoDaRecuperareQuotaUe]').val());
            var importoRecuperareQuotaNazionale = convertToNumber($('[id$=txtImportoDaRecuperareQuotaNazionale]').val());
            $('[id$=txtImportoDaRecuperareQuotaPubblica]').val(sumAndConvertForCurrency(importoRecuperareQuotaUe, importoRecuperareQuotaNazionale));
            var importoRecuperarePubblica = convertToNumber($('[id$=txtImportoDaRecuperareQuotaPubblica]').val());
            var importoRecuperarePrivata = convertToNumber($('[id$=txtImportoDaRecuperareQuotaPrivata]').val());
            $('[id$=txtImportoDaRecuperareTotale]').val(sumAndConvertForCurrency(importoRecuperarePubblica, importoRecuperarePrivata));
        }
    </script>
    
    <style type="text/css">
        .mrw-table { display: table; table-layout: fixed; width: 100%; padding: 10px; border-style: solid;}
        .mrw-tr { display: table-row; width: 100%; }
        .mrw-header {}
        .mrw-tr > div { display: table-cell; vertical-align: middle; padding: 10px 2px; white-space: nowrap; overflow: hidden; }
        .mrw-th, .mrw-tf { font-weight: bold; }
        .mrw-td { border-bottom-width: 1px; border-bottom-style: solid; }
        .mrw-grid .mrw-td { border-left-width: 1px; border-left-style: solid; }
        .mrw-grid .mrw-td:last-child { border-right-width: 1px; border-right-style: solid; }
        .mrw-width-5 { width: 5%; }
        .mrw-width-10 { width: 10%; }
        .mrw-width-15 { width: 14%; }
        .mrw-width-15 { width: 15%; }
        .mrw-width-16 { width: 16%; }
        .mrw-width-20 { width: 20%; }
        .mrw-width-25 { width: 25%; }
        .mrw-width-30 { width: 30%; }
        .mrw-width-33 { width: 33%; }
        .mrw-width-34 { width: 34%; }
        .mrw-width-35 { width: 35%; }
        .mrw-width-40 { width: 40%; }
        .mrw-width-45 { width: 45%; }
        .mrw-width-50 { width: 50%; }
        .mrw-width-55 { width: 55%; }
        .mrw-width-60 { width: 60%; }
        .mrw-width-65 { width: 65%; }
        .mrw-width-70 { width: 70%; }
        .mrw-width-75 { width: 75%; }
        .mrw-width-80 { width: 80%; }
        .mrw-width-85 { width: 85%; }
        .mrw-width-90 { width: 90%; }
        .mrw-width-95 { width: 95%; }
        .mrw-width-100 { width: 100%; }
        .mrw-center { vertical-align: top; margin: auto !important; text-align: center; }
        .mrw-right { text-align: right; }
        .dBox-overflow 
        {
	        box-shadow: 2px 3px 10px;
	        border-radius: 5px;
	        background-color:#E6E6EE;        	
	        margin:0px 10px 20px 10px;
	        overflow:hidden;
        }
    </style>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdIrregolarita" runat="server" />
        <asp:HiddenField ID="hdnIdDisposizione" runat="server" />
        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:HiddenField ID="hdnGiustXIrr" runat="server" />
        <asp:Button ID="btnCaricaRecupero" runat="server" CausesValidation="False" OnClick="btnCaricaRecupero_Click" />
        <asp:Button ID="btnPost" runat="server" CausesValidation="False" OnClick="btnPost_Click" />
        <asp:Button ID="btnCaricaGiustificativo" runat="server" CausesValidation="False"
            OnClick="btnCaricaGiustificativo_Click" />
        <asp:Button ID="btnEscludiGiustificativo" runat="server" OnClick="btnEscludiGiustificativo_Click" />
        <asp:Button ID="btnCaricaDisposizione" runat="server" OnClick="btnCaricaDisposizione_Click" />
    </div>
    
    <div class="dBox-overflow">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <div class="separatore_big">
                        Controllo delle irregolarità
                    </div>
                </td>
            </tr>
            <tr>
                <td id="tdDomanda" runat="server" style="padding-top: 15px; padding-bottom: 15px">
                </td>
                <td align="right" style="width: 48px;" class="selectable" onclick="location='#lnkFondoPagina'">
                    <a id="lnkInizioPagina"></a>
                    <img src="../../images/arrow_down_big.png" alt="Fondo pagina" />
                </td>
            </tr>
            <tr>
                <td class="paragrafo">
                    Elenco registro irregolarità:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="divTesta" class="dContenuto" runat="server">
                        <Siar:DataGrid ID="dgIrregolarita" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="15" Width="100%" ShowFooter="true">
                            <ItemStyle Height="28px" />
                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <asp:BoundColumn DataField="IdIrregolarita" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataIrregolarita" HeaderText="Data irregolarità">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdImpresaCommessaDa" HeaderText="Commessa da">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CommessaA" HeaderText="Commessa a">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdCategoriaIrregolarita" HeaderText="Categoria">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdTipoIrregolarita" HeaderText="Tipo">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdClassificazioneIrregolarita" HeaderText="Classificazione">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <Siar:CheckColumn DataField="SegnalazioneOlaf" Name="chkSegnalazioneOlaf" HeaderText="Segnalazione Olaf"
                                    ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </Siar:CheckColumn>
                                <Siar:JsButtonColumn Arguments="IdIrregolarita" ButtonType="TextButton" ButtonText="Dettaglio"
                                    JsFunction="caricaIrregolarita">
                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    
    <div id="divTab" class="dBox-overflow" runat="server">
        <uc1:SiarNewTab ID="tabIrregolarita" runat="server" Titolo="IRREGOLARITA'"
            TabNames="Informazioni specifiche|Origine controllo|Identificazione|Informazioni sospetto|Disposizioni trasgredite|Impatto finanziario|Giustificativi" />
        <%--<div class="separatore">Informazioni specifiche sull'irregolarità</div><br />--%>
        <div id="divInformazioniSpecifiche" runat="server" visible="false" >
            <div runat="server" visible="false" id="divDomandaIrregolarita" style="padding:10px" >
                <div class="paragrafo" >Domanda di pagamento associata:</div><br /> 
                <Siar:DataGrid ID="dgDomandaIrregolarita" runat="server" Width="100%" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Richiesto">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                            <ItemStyle HorizontalAlign="center" Width="140px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" Width="190px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Domanda pagamento" >
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Istruita">
                            <ItemStyle HorizontalAlign="center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText=" ">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="right" Width="100px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </div>
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Irregolarità commessa in:<asp:RadioButtonList RepeatDirection="Horizontal" ID="rblDataPeriodo" runat="server">
                            <asp:ListItem Selected="True" Text="Data" Value="0" />
                            <asp:ListItem Text="Periodo" Value="1" />
                        </asp:RadioButtonList>

                        <script type="text/javascript">
                            $(function () {
                                $('[id$=rblDataPeriodo]').change(checkDataPeriodo);
                                $('[id$=rblDataPeriodo]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-50">
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        <div id="divDataIrregolarita" runat="server">
                            Data:<br />
                            <Siar:DateTextBox ID="txtDataIrregolaritaCommessaIl" runat="server" Width="120px" />
                        </div>
                        <div id="divPeriodoIrregolaritaDa" runat="server">
                            Periodo tra:<br />
                            <Siar:DateTextBox ID="txtDataIrregolaritaCommessaDa" runat="server" Width="120px" />
                        </div>
                    </div>
                    <div class="mrw-width-50">
                        <div id="divPeriodoIrregolaritaA" runat="server">
                            e il:<br />
                            <Siar:DateTextBox ID="txtDataIrregolaritaCommessaA" runat="server" Width="120px" />
                        </div>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Commessa da:<br />
                        <Siar:ComboBase ID="lstCommessaDa" runat="server" NomeCampo="CommessaDa"></Siar:ComboBase>
                    </div>
                    <div class="mrw-width-50">
                        Note commessa da:<br />
                        <Siar:TextArea ID="txtCommessaDa" runat="server" Width="200px" Rows="2" ExpandableRows="2"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Commessa a:<br />
                        <Siar:TextArea ID="txtCommessaA" runat="server" Width="200px" Rows="2" ExpandableRows="2"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                    <div class="mrw-width-50">
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Categoria:<br />
                        <Siar:ComboBase ID="lstCategoriaIrregolarita" runat="server" NomeCampo="Categoria"
                            Width="250px">
                        </Siar:ComboBase>

                        <script type="text/javascript">
                            $(function () {
                                $('[id$=lstCategoriaIrregolarita]').change(checkCategoriaIrregolarita);
                                if ($('[id$=lstCategoriaIrregolarita]').val() == "") {
                                    $('[id$=lstCategoriaIrregolarita]').change();
                                }
                            });
                        </script>
                    </div>
                    <div class="mrw-width-50">
                        Tipo:<br />
                        <Siar:ComboBase ID="lstTipoIrregolarita" runat="server" NomeCampo="Tipo" Width="250px">
                        </Siar:ComboBase>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Classificazione:<br />
                        <Siar:ComboBase ID="lstClassificazioneIrregolarita" runat="server" NomeCampo="Classificazione"
                            Width="250px">
                        </Siar:ComboBase>
                    </div>
                    <div class="mrw-width-50">
                    </div>
                </div>
            </div>
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        Modus Operandi:<br />
                        <Siar:TextArea ID="txtModusOperandi" runat="server" Width="600px" Rows="4" ExpandableRows="5"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        Dichiarazioni dell'operatore:<br />
                        <Siar:TextArea ID="txtDichiarazioniOperatore" runat="server" Width="600px" Rows="4"
                            ExpandableRows="5" MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        Accertamenti dell'amministrazione:<br />
                        <Siar:TextArea ID="txtAccertamentiAmministrazione" runat="server" Width="600px" Rows="4"
                            ExpandableRows="5" MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        <Siar:Button ID="btnSalvaSpecificheIrregolarita" runat="server" OnClick="btnSalvaSpecificheIrregolarita_Click"
                            Text="Salva informazioni specifiche irregolarità" />
                    </div>
                </div>
            </div>
        </div>
        
        <%--<div class="separatore">Origine del controllo</div>--%>
        <div id="divOrigineControllo" runat="server" visible="false" >
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Controllo d'origine:<br />
                        <Siar:ComboBase ID="lstControlloOrigine" runat="server" NomeCampo="ControlloOrigine"
                            Width="250px">
                        </Siar:ComboBase>

                        <script type="text/javascript">
                            $(function () {
                                $('[id$=lstControlloOrigine]').change(changeOrigine);
                                $('[id$=lstControlloOrigine]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-50">
                        <div id="divDescrizioneOrigineEsterno" runat="server">
                            Descrizione controllo origine esterno:<br />
                            <Siar:TextArea ID="txtDescrizioneControlloOrigineEsterno" runat="server" Width="450px"
                                Rows="4" ExpandableRows="5" MaxLength="8000"></Siar:TextArea>
                        </div>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Data segnalazione irregolarità:<br />
                        <Siar:DateTextBox ID="txtDataSegnalazioneIrregolarita" runat="server" Width="120px" />
                    </div>
                     <div class="mrw-width-50">
                        Trimestre segnalazione irregolarità:<br />
                        <Siar:TextBox  ID="txtTrimestreSegnalazioneIrregolarita" runat="server"></Siar:TextBox>
                     </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Sospetto frode:<br />
                        <Siar:ComboSiNo ID="lstSospettoFrode" runat="server" NomeCampo="SospettoFrode"></Siar:ComboSiNo>
                    </div>
                     <div class="mrw-width-50">
                     </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Irregolarità da segnare all'OLAF:<br />
                        <Siar:ComboBase ID="lstSegnalazioneOlaf" runat="server" NomeCampo="SegnalazioneOlaf">
                        </Siar:ComboBase>

                        <script type="text/javascript">
                            $(function () {
                                $('[id$=lstSegnalazioneOlaf]').change(changeSegnalazioneOlaf);
                                $('[id$=lstSegnalazioneOlaf]').change();
                            });
                        </script>
                    </div>
                     <div class="mrw-width-50">
                        <div id="divRiferimentoOlaf">
                            N. riferimento OLAF:<br />
                            <Siar:TextBox  ID="txtNumRiferimentoOLAF" runat="server"></Siar:TextBox>
                        </div>
                     </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Importo irregolare già certificato:<br />
                        <Siar:CurrencyBox ID="txtImportoIrregolareGiaCertificato" runat="server" NomeCampo="Importo irregolare gia certificato" />
                    </div>
                     <div class="mrw-width-50">
                        Importo irregolare da recuperare c/o il beneficiario:<br />
                        <Siar:CurrencyBox ID="txtImportoIrregolareDaRecuperare" runat="server" NomeCampo="Importo irregolare da recuperare" />
                     </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        <Siar:Button ID="btnSalvaOrigineControllo" runat="server" OnClick="btnSalvaOrigineControllo_Click"
                                        Text="Salva origine del controllo" />
                    </div>
                     <div class="mrw-width-50">
                     </div>
                </div>
            </div>
        </div>

        <%--<div class="separatore">Identificazione</div>--%>
        <div id="divIdentificazione" runat="server" visible="false" >
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-33">
                        Fondo:<br />
                        <Siar:ComboBase ID="lstFondo" runat="server" NomeCampo="Fondo" Width="250px">
                        </Siar:ComboBase>
                    </div>
                    <div class="mrw-width-33">
                        Periodo di programmazione:<br />
                        <Siar:TextBox  ID="txtPeriodoProgrammazione" runat="server"></Siar:TextBox>
                    </div>
                    <div class="mrw-width-34">
                        Numero riferimento nazionale:<br />
                        <Siar:TextBox  ID="txtNumeroRiferimentoNazionale" runat="server"></Siar:TextBox>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-33">
                        Data di creazione:<br />
                        <Siar:DateTextBox ID="txtDataCreazioneIdentificazione" runat="server" Width="120px" />
                    </div>
                    <div class="mrw-width-33">
                        Trimestre identificazione:<br />
                        <Siar:TextBox  ID="txtTrimestreIdentificazione" runat="server"></Siar:TextBox>
                    </div>
                    <div class="mrw-width-34">
                        Anno identificazione:<br />
                        <Siar:TextBox  ID="txtAnnoIdentificazione" runat="server"></Siar:TextBox>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-33">
                        Procedimenti:<br />
                        AP Procedimento ammministrativo:<asp:CheckBox ID="chkProcedimentoAmministrativo"
                            runat="server" />
                    </div>
                    <div class="mrw-width-33">
                        <br />
                        JP Azione giudiziaria:<asp:CheckBox ID="chkAzioneGiudiziaria" runat="server" />
                    </div>
                    <div class="mrw-width-34">
                        <br />
                        PP Azione penale:<asp:CheckBox ID="chkAzionePenale" runat="server" />
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-33">
                        Stato finanziario:<br />
                        <Siar:ComboBase ID="lstStatoFinanziario" runat="server" NomeCampo="StatoFinanziario"
                            Width="250px">
                        </Siar:ComboBase>
                    </div>
                    <div class="mrw-width-33">
                        Irregolarità da stabilità operazioni:<br />
                        <Siar:ComboBase ID="lstStabilitaOperazioni" runat="server" NomeCampo="StabilitaOperazioni"></Siar:ComboBase>
                    </div>
                    <div class="mrw-width-34">
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-33">
                        <Siar:Button ID="btnSalvaIdentificazione" runat="server" OnClick="btnSalvaIdentificazione_Click"
                            Text="Salva identificazione" />
                    </div>
                    <div class="mrw-width-33">
                    </div>
                    <div class="mrw-width-34">
                    </div>
                </div>
            </div>
        </div>
        
        <%--<div class="separatore">Informazioni che portano al sospetto di irregolarità</div>--%>
        <div id="divSospetto" runat="server" visible="false" >
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Data prima informazione:<br />
                        <Siar:DateTextBox ID="txtDataPrimaInformazione" runat="server" Width="120px" />
                    </div>
                    <div class="mrw-width-50">
                        Fonte prima informazione:<br>
                        <Siar:TextBox  ID="txtFontePrimaInformazione" runat="server"></Siar:TextBox>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        <Siar:Button ID="btnSalvaInformazioniSospetto" runat="server" OnClick="btnSalvaInformazioniSospetto_Click"
                            Text="Salva informazioni sospetto" />
                    </div>
                    <div class="mrw-width-50">
                    </div>
                </div>
            </div>
        </div>
        
        <%--<div class="separatore">Disposizioni trasgredite</div>--%>
        <div id="divDisposizioni" runat="server" visible="false" >
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        <Siar:DataGrid ID="dgDisposizioni" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="24px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdDisposizione" HeaderText="Id"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdTipoDisposizione" HeaderText="Tipo disposizione"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Numero" HeaderText="Numero"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Anno" HeaderText="Anno"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ArticoloParagrafo" HeaderText="Articolo e Paragrafo">
                                </asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdDisposizione" ButtonType="TextButton" ButtonText="Dettaglio"
                                    JsFunction="selezionaDisposizione">
                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Tipo disposizione:<br />
                        <Siar:ComboBase ID="lstTipoDisposizione" runat="server" NomeCampo="TipoDisposizione">
                        </Siar:ComboBase>
                    </div>
                    <div class="mrw-width-50">
                        Numero:<br />
                        <Siar:TextBox  ID="txtNumeroDisposizione" runat="server"></Siar:TextBox>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        Anno:<br />
                        <Siar:TextBox  ID="txtAnnoDisposizione" runat="server"></Siar:TextBox>
                    </div>
                    <div class="mrw-width-50">
                        Articolo e paragrafo:<br />
                        <Siar:TextBox  ID="txtArticoloParagrafoDisposizione" runat="server"></Siar:TextBox>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-50">
                        <Siar:Button ID="btnInserisciDisposizione" runat="server" Width="200px" Text="Inserisci disposizione trasgredita"
                            OnClick="btnInserisciDisposizione_Click" CausesValidation="false"></Siar:Button>
                        <Siar:Button ID="btnAggiornaDisposizione" runat="server" Width="200px" Text="Aggiorna disposizione trasgredita"
                            OnClick="btnAggiornaDisposizione_Click" CausesValidation="false" Visible="false">
                        </Siar:Button>
                    </div>
                    <div class="mrw-width-50">
                        <Siar:Button ID="btnRimuoviDisposizione" runat="server" Width="200px" Text="Rimuovi disposizione trasgredita"
                            OnClick="btnRimuoviDisposizione_Click" CausesValidation="false"></Siar:Button>
                    </div>
                </div>
            </div>
        </div>
        
        <%--<div class="separatore">Impatto finanziario</div>--%>
        <div id="divImpattoFinanziario" runat="server" visible="false" >
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-30">
                    </div>
                    <div class="mrw-width-14">
                        <b>Quota UE</b>
                    </div>
                    <div class="mrw-width-14">
                        <b>Quota nazionale</b>
                    </div>
                    <div class="mrw-width-14">
                        <b>Contributo pubblico</b>
                    </div>
                    <div class="mrw-width-14">
                        <b>Quota privata</b>
                    </div>
                    <div class="mrw-width-14">
                        <b>Totale</b>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-30">
                        Importo della spesa
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoSpesaQuotaUe" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoSpesaQuotaUe]').change(aggiornaTotali);
                                $('[id$=txtImportoSpesaQuotaUe]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoSpesaQuotaNazionale" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoSpesaQuotaNazionale]').change(aggiornaTotali);
                                $('[id$=txtImportoSpesaQuotaNazionale]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoSpesaContributoPubblico" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoSpesaContributoPrivato" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoSpesaContributoPrivato]').change(aggiornaTotali);
                                $('[id$=txtImportoSpesaContributoPrivato]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoSpesaTotale" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-14">
                        Importo dell'irregolarità (importo non ammesso irregolare)
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaQuotaUe" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaQuotaUe]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaQuotaUe]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaQuotaNazionale" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaQuotaNazionale]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaQuotaNazionale]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPubblica" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPrivata" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaPrivata]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaPrivata]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaTotale" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-30" align="right">
                        di cui NON pagato
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaNonPagatoQuotaUe" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaNonPagatoQuotaUe]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaNonPagatoQuotaUe]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaNonPagatoQuotaNazionale" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaNonPagatoQuotaNazionale]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaNonPagatoQuotaNazionale]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaNonPagatoQuotaPubblica" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaNonPagatoQuotaPrivata" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaNonPagatoQuotaPrivata]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaNonPagatoQuotaPrivata]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaNonPagatoTotale" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-30" align="right">
                        di cui PAGATO
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPagatoQuotaUe" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaPagatoQuotaUe]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaPagatoQuotaUe]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPagatoQuotaNazionale" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaPagatoQuotaNazionale]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaPagatoQuotaNazionale]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPagatoQuotaPubblica" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPagatoQuotaPrivata" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoIrregolaritaPagatoQuotaPrivata]').change(aggiornaTotali);
                                $('[id$=txtImportoIrregolaritaPagatoQuotaPrivata]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoIrregolaritaPagatoTotale" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-30">
                        Importo da recuperare (importo non concesso irregolare)
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoDaRecuperareQuotaUe" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoDaRecuperareQuotaUe]').change(aggiornaTotali);
                                $('[id$=txtImportoDaRecuperareQuotaUe]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoDaRecuperareQuotaNazionale" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoDaRecuperareQuotaNazionale]').change(aggiornaTotali);
                                $('[id$=txtImportoDaRecuperareQuotaNazionale]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoDaRecuperareQuotaPubblica" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoDaRecuperareQuotaPrivata" runat="server" Width="100px" />
                        <script type="text/javascript">
                            $(function () {
                                $('[id$=txtImportoDaRecuperareQuotaPrivata]').change(aggiornaTotali);
                                $('[id$=txtImportoDaRecuperareQuotaPrivata]').change();
                            });
                        </script>
                    </div>
                    <div class="mrw-width-14">
                        <Siar:CurrencyBox ID="txtImportoDaRecuperareTotale" runat="server" ReadOnly="true" Width="100px" />
                    </div>
                </div>
           </div>
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        Spesa decertificata:<br />
                        <Siar:ComboBase ID="lstSpesaDecertificata" runat="server" NomeCampo="SpesaDecertificata">
                        </Siar:ComboBase>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        Commenti impatto finanziario:<br />
                        <Siar:TextArea ID="txtCommentiImpattoFinanziario" runat="server" Width="600px" Rows="4"
                            ExpandableRows="5" MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        <Siar:Button ID="btnSalvaImpattoFinanziario" runat="server" OnClick="btnSalvaImpattoFinanziario_Click"
                            Text="Salva informazioni impatto finanziario" />
                    </div>
                </div>
            </div>
        </div>
        
        <%--<div class="separatore">Giustificativi legati a irregolarità</div>--%>
        <div id="divGiustificativi" runat="server" visible="false" >
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        <Siar:DataGrid ID="dgGiustificativiAssociati" runat="server" AutoGenerateColumns="false" 
                            Width="100%" ShowFooter="true" >
                            <ItemStyle Height="24px" />
                            <FooterStyle CssClass="coda" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundColumn DataField="IdGiustificativo" HeaderText="Nr."></asp:BoundColumn>
                                <asp:BoundColumn DataField="Numero" HeaderText="Numero"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Data" HeaderText="Data"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Imponibile" HeaderText="Imponibile"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                <Siar:JsButtonColumn Arguments="IdGiustificativoXIrregolarita" ButtonType="TextButton"
                                    ButtonText="Escludi" JsFunction="escludiGiustificativo">
                                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>
                <div class="mrw-tr">
                    <div class="mrw-width-100">
                        <a id="lnkNuovoGiustificativo" runat="server" href="">[ASSOCIA GIUSTIFICATIVO]</a>
                    </div>
                </div>
            </div>
        </div>
        
        <div id="divRigaPulsanti" >
            <div class="paragrafo"></div>
            <div class="mrw-table">
                <div class="mrw-tr">
                    <div class="mrw-width-25" align="right">
                        <Siar:Button ID="btnSalvaControlloIrregolarita" runat="server" OnClick="btnSalvaControlloIrregolarita_Click"
                            Text="Salva controllo irregolarità" Visible="false" />
                    </div>
                    <div class="mrw-width-25" align="center">
                        <Siar:Button ID="btnEliminaControlloIrregolarita" runat="server" OnClick="btnEliminaControlloIrregolarita_Click"
                            OnClientClick="return confirm('Sei sicuro di continuare? \r\nVerranno cancellate anche le disposizioni relative all irregolarità.');" 
                            Text="Elimina controllo irregolarità" />
                    </div>
                    <div class="mrw-width-25" align="left">
                        <Siar:Button ID="btnNuovoControlloIrregolarita" runat="server" OnClick="btnNuovoControlloIrregolarita_Click"
                            Text="Nuovo controllo irregolarità" Visible="false" />
                    </div>
                    <div class="mrw-width-25" align="right">
                        <a id="lnkFondoPagina"></a>
                        <div style="width: 48px; height: 48px" class="selectable" onclick="location='#lnkInizioPagina'">
                            <img src="../../images/arrow_up_big.png" alt="Inizio pagina" /></div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
    
    <div class="dBox-overflow">
        <div class="separatore_big">Registro dei recuperi e dei ritiri</div>
        <div class="mrw-table">
            <div class="mrw-tr">
                <div class="mrw-width-100">
                    <Siar:DataGrid ID="dgRegistroRecuperi" runat="server" AutoGenerateColumns="false"
                        Width="100%">
                        <ItemStyle Height="24px" />
                        <Columns>
                            <asp:BoundColumn DataField="IdRegistroRecupero" HeaderText="Id"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdTipoRecupero" HeaderText="Tipologia"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DataAvvio" HeaderText="Data avvio"></asp:BoundColumn>
                            <asp:BoundColumn DataField="DataConclusione" HeaderText="Data conclusione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdProcedureAvviate" HeaderText="Procedure avviate"></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdTipoProcedureAvviate" HeaderText="Tipo procedure">
                            </asp:BoundColumn>
                            <Siar:CheckColumn DataField="Recuperabile" HeaderText="Recuperabile" ReadOnly="true"></Siar:CheckColumn>
                            <Siar:JsButtonColumn Arguments="IdRegistroRecupero" ButtonType="TextButton" ButtonText="Dettaglio"
                                JsFunction="caricaRecupero">
                                <ItemStyle Width="90px" HorizontalAlign="Center" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                </div>
            </div>
            <div class="mrw-tr">
                <div class="mrw-width-100" align="center">
                    <Siar:Button ID="btnInserisciRecupero" runat="server" OnClick="btnInserisciRecupero_Click"
                        Text="Inserisci recupero o ritiro" />
                </div>
            </div>
        </div>
    </div>
    
    <uc2:ZoomLoader ID="ucZoomLoaderGiustificativiProgetto" runat="server" AutomaticSearch="True"
        NoSearch="True" SearchMethod="GetGiustificativiProgetto" KeySearch="Numero:Numero|Data:Data:d"
        ColumnsToBind="nr|Numero:Numero:d|Data:Data:d|Imponibile:Imponibile:c|Descrizione:Descrizione"
        KeyValue="IdGiustificativo" KeyText="Descrizione|Numero|CodTipo|Data|CfFornitore|DataDoctrasporto|DescrizioneFornitore|Imponibile|Iva|IvaNonRecuperabile|NumeroDoctrasporto"
        JsSelectedItemHandler="selezionaGiustificativo" Width="700px" />
</asp:Content>
