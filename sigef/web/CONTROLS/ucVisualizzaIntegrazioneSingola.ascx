﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVisualizzaIntegrazioneSingola.ascx.cs" Inherits="web.CONTROLS.ucVisualizzaIntegrazioneSingola" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>

<style type="text/css">

    .first_elem_block {
        width: 200px;
        display: inline-block;
        *display: inline;
        zoom: 1;
        padding-bottom: 5px;
    }

    .elem_block {
        width: 200px;
        vertical-align: top;
        display: inline-block;
        *display: inline;
        zoom: 1;
        padding-left: 20px;
        padding-bottom: 5px;
    }

    .paragrafo_light {
        border-bottom: solid 1px #084600;
        font-size: 14px;
    }

    .hide {
        display:none;
    }

</style>

<script type="text/javascript">

    function lstCategoriaAllegato_changed() {
        var tipo_allegato = '';
        var items = $('[id$=lstCategoriaAllegato]').find('option:selected');
        if (items.length > 0)
            tipo_allegato = $(items).attr('optvalue');
        $('[id$=divUploadFileAllegato]')[0].style.display = tipo_allegato == 'D' ? '' : 'none';
        $('[id$=divDichiarazioneSostitutiva]')[0].style.display = tipo_allegato == 'S' ? '' : 'none';
    }

    function pulisciCampi() {
        $('[id$=hdnIdAllegato]').val('');
        $('[id$=lstCategoriaAllegato]').val('');
        lstCategoriaAllegato_changed();
        $('[id$=txtDescrizione]').val('');
        $('[id$=lstNATipoEnte]').val('');
        $('[id$=txtNAEnte_text]').val('');
        $('[id$=hdnCodEnte]').val('');
        $('[id$=txtNADatadoc_text]').val('');
        $('[id$=txtNANumeroDoc_text]').val('');
        $('[id$=btnNuovoAllegatoPost]').click();
    }

    function eliminaAllegato(ev) {
        if ($('[id$=hdnIdAllegato]').val() == '') {
            alert('Non è stato selezionato nessun allegato da eliminare.');
            return stopEvent(ev);
        }

        if (!confirm('Attenzione! Eliminare l`allegato selezionato?'))
            return stopEvent(ev);
    }

    function ctrlCampi(ev) {
        var lst = $('[id$=lstCategoriaAllegato]'), items = $(lst).find('option:selected');

        if ($(lst).val() == '' || items.length == 0) {
            alert('Selezionare una categoria di allegato.');
            return stopEvent(ev);
        }
        else {
            var optvalue = $(items).attr('optvalue');
            if (optvalue == "S" && ($('[id$=lstNATipoEnte]').val() == '' || $('[id$=txtNAEnte_text]').val() == '' || $('[id$=hdnCodEnte]').val() == '' || $('[id$=txtNADatadoc_text]').val() == '' || $('[id$=txtNANumeroDoc_text]').val() == '')) {
                alert('Per la categoria di allegato selezionata si richiede di specificare gli estremi del documento.');
                return stopEvent(ev);
            }
            if (optvalue == "D" && $('input[type=hidden][id*=ufcNAAllegato]').val() == '') {
                alert('Per la categoria di allegato selezionata si richiede di carica il documento digitale o di specificare se il documento sia già stato presentato in una domanda di aiuto precedente.');
                return stopEvent(ev);
            }
            if (optvalue == "C") {
                alert('L`allegato selezionato selezionato appartiene ad una tipologia non più valida, operazione annullata.');
                return stopEvent(ev);
            }
        }
    }

    function lstNATipoEnte_changed() {
        $('[id$=txtNAEnte_text]').val('');
        $('[id$=hdnCodEnte]').val('');
    }

    function SNCVZCercaAmministrazione_onprepare(elem) {
        SNCZVParams = "{'CodTipoEnte':'" + $('[id$=lstNATipoEnte]').val() + "'}";
    }

    function SNCVZCercaAmministrazione_onselect(obj) {
        $('[id$=txtNAEnte_text]').val(obj.Descrizione);
        $('[id$=hdnCodEnte]').val($('[id$=lstNATipoEnte]').val() == "CM" ? obj.IdComune : obj.CodEnte);
    }

    function SNCVZCercaFornitoriProgetto_onselect(obj) {
        stopcf = true;
        if (obj) {
            $('[id$=txtPivaFornitore_text]').val(obj.CfFornitore);
            $('[id$=txtRSFornitore_text]').val(obj.DescrizioneFornitore);
        }
        else
            alert('L`elemento selezionato non è valido.');
    }

    function selezionaFileSpese(idFile) {
        $('[id$=hdnIdFileSpesaSostenuta]').val($('[id$=hdnIdFileSpesaSostenuta]').val() == idFile ? '' : idFile);
        alert($('[id$=hdnIdFileSpesaSostenuta]').val() + " ciao");
        $('[id$=btnPostFileSpesa]').click();
    }

    function svuotaCampiFile() {
        $('[id$=hdnIdFileSpesaSostenuta]').val('');
        $('[id$=txtDescrizioneFile]').val('');
        SNCUFTipoFile = 'Documento';
        SNCUFDimensioneMassima = 0;
        SNCUFRimuoviFile('ctl00_cphContenuto_ufFileSpesaSostenuta');
    }

    function rimuoviFileSpesa(id) {
        $('[id$=hdnIdFileSpesaSostenuta]').val(id);
        $('[id$=btnRimuoviFileSpesa]').click();
    }

    function validaImporti(scrivi_importo_netto, e) {
        $('#spErroreImporti').hide();
        var netto_giustificativo = FromCurrencyToNumber($('[id$=txtImportoGiustificativo_text]').val());
        var iva_giustificativo = FromCurrencyToNumber($('[id$=txtIva_text]').val());
        var lordo_pagamento = FromCurrencyToNumber($('[id$=txtImportoLordoPagamento_text]').val());
        var netto_pagamento = FromCurrencyToNumber($('[id$=txtImportoNettoPagamento_text]').val());
        if (iva_giustificativo < 0 || netto_giustificativo < 0 || lordo_pagamento < 0) {
            alert('Attenzione! Inserire dei valori validi sugli importi richiesti.'); return stopEvent(e);
        }
        else {
            //pre modifica su importo lordo delle spese
            /*
            var lordo_giustificativo = Arrotonda(netto_giustificativo + netto_giustificativo * iva_giustificativo / 100);
            if (lordo_pagamento > lordo_giustificativo) {
                alert('Attenzione! L`importo lordo del pagamento non può superare quello del giustificativo.');
                $('#spErroreImporti').show(); return stopEvent(e); 
            */

            //post modifica su importo lordo delle spese
            var lordo_giustificativo = Arrotonda(netto_giustificativo + netto_giustificativo * iva_giustificativo / 100);
            if (lordo_pagamento > lordo_giustificativo) {
                if (!confirm('Attenzione! L`importo lordo del pagamento è maggiore a quello del giustificativo.\nSi desidera procedere comunque con la procedura di salvataggio?')) {
                    $('[id$=txtImportoNettoPagamento_text]').val($('[id$=txtImportoGiustificativo_text]').val());
                    $('[id$=txtImportoLordoPagamento_text]').val(FromNumberToCurrency(lordo_giustificativo));
                    return stopEvent(e);
                } else {
                    if (scrivi_importo_netto) {
                        var scorporo_iva = 1 + iva_giustificativo / 100;
                        $('[id$=txtImportoNettoPagamento_text]').val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                    }
                }
                //alert('Attenzione! L`importo lordo del pagamento non può superare quello del giustificativo.'); 
                //$('#spErroreImporti').show(); return stopEvent(e); 
            }
            else if (netto_pagamento > lordo_pagamento) {
                //pre modifica su importo lordo delle spese
                //alert('Attenzione! L`importo netto del pagamento non può superare quello lordo.'); 

                //post modifica su importo lordo delle spese
                alert('Attenzione! L`importo netto del pagamento non può superare quello lordo. Se necessario correggere l\'importo lordo.');

                $('#spErroreImporti').show(); return stopEvent(e);
            }
            else {
                if (scrivi_importo_netto) {
                    var scorporo_iva = 1 + iva_giustificativo / 100;
                    $('[id$=txtImportoNettoPagamento_text]').val(FromNumberToCurrency(Arrotonda(lordo_pagamento / scorporo_iva)));
                }
            }
        }
        var ok = true;
        if ($('[id$=lstTipoGiustificativo]').val() == "") { ok = false; }
        if ($('[id$=txtDataGiustificativo_text]').val() == "") { ok = false; }
        if ($('[id$=txtImportoGiustificativo_text]').val() == "") { ok = false; }
        if ($('[id$=txtIva_text]').val() == "") { ok = false; }
        if ($('[id$=txtDescGiustificativo_text]').val() == "") { ok = false; }
        if ($('[id$=txtPivaFornitore_text]').val() == "") { ok = false; }
        if ($('[id$=lstPagamento]').val() == "") { ok = false; }
        if ($('[id$=txtDataPagamento_text]').val() == "") { ok = false; }
        if ($('[id$=txtImportoLordoPagamento_text]').val() == "") { ok = false; }
        if ($('[id$=txtImportoNettoPagamento_text]').val() == "") { ok = false; }
        if ($('[id$=txtEstremi_text]').val() == "") { ok = false; }
        if (ok == false) { alert('Tutti i campi con * sono obbligatori.'); return stopEvent(e) }
    } 

</script>

<div id="divContenitore" runat="server">

    <div style="display: none">
        <input type="hidden" id="hdnIdIntegrazioneSingola" runat="server" />
        <input type="hidden" id="hdnPerBeneficiario" runat="server" />

        <input type="hidden" id="hdnIdAllegato" runat="server" />
        <input type="hidden" id="hdnCodEnte" runat="server" />

        <asp:HiddenField ID="hdnIdGiustificativo" runat="server" />
        <asp:HiddenField ID="hdnIdImpresaFornitoreCercato" runat="server" />

        <asp:HiddenField ID="hdnIdSpesaSostenuta" runat="server" />
        <asp:HiddenField ID="hdnIdFileSpesaSostenuta" runat="server" />
        <asp:Button ID="btnRimuoviFileSpesa" runat="server" CausesValidation="False" OnClick="btnRimuoviFileSpesa_Click" />
        <asp:Button ID="btnPostFileSpesa" CausesValidation="false" runat="server" OnClick="btnPostFileSpesa_Click" />
    </div>

    <div class="separatore">
        Dettaglio singola integrazione selezionata:
    </div>
    <br />

    <div class="paragrafo_light">
        Dati di competenza dell'istruttore:
    </div>
    <br />
                
    <div class="first_elem_block">
        Data richiesta:<br />
        <Siar:DateTextBox ID="txtDataRichiesta" runat="server" Width="120px" ReadOnly="true" />
    </div>

    <div class="elem_block">
        Tipo integrazione:<br />
        <Siar:TextBox ID="txtTipoIntegrazione" runat="server" Width="180px" ReadOnly="true" />
    </div>

    <div id="divDataConclusioneRichiesta" runat="server" class="elem_block">
        Data conclusione richiesta:<br />
        <Siar:DateTextBox ID="txtDataConclusioneRichiesta" runat="server" Width="120px" />
    </div>

    <div class="elem_block">
        Integrazione completata:<br />
        <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaIstruttore" runat="server">
            <asp:ListItem Text="No" Value="false"></asp:ListItem>
            <asp:ListItem Text="Si" Value="true"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />

    <div class="first_elem_block">
        Note integrazione:<br />
        <Siar:TextArea ID="txtNoteSingolaIntegrazioneIstruttore" runat="server" NomeCampo="Note singola integrazione"
            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5" MaxLength="10000" />
    </div>
    <br />
    <br />


    <div class="paragrafo_light">
        Dati di competenza del beneficiario:
    </div>
    <br />

    <div class="first_elem_block">
        Data rilascio:<br />
        <Siar:DateTextBox ID="txtDataRilascio" runat="server" Width="120px" />
    </div>
    <div class="elem_block">
        Integrazione completata beneficiario:<br />
        <asp:DropDownList ID="comboCompletataSingolaIntegrazioneDomandaBeneficiario" runat="server">
            <asp:ListItem Text="No" Value="false"></asp:ListItem>
            <asp:ListItem Text="Si" Value="true"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <br />

    <div class="first_elem_block">
        Note beneficiario:<br />
        <Siar:TextArea ID="txtNoteSingolaIntegrazioneBeneficiario" runat="server" NomeCampo="Note singola integrazione beneficiario"
            Obbligatorio="false" Width="600px" Rows="4" ExpandableRows="5"
            MaxLength="10000" />
    </div>
    <br />
    <br />

    <div class="elem_block">
        <Siar:Button ID="btnSalvaSingolaIntegrazione" runat="server" OnClick="btnSalvaSingolaIntegrazione_Click"
            Text="Salva dati singola integrazione" />
    </div>
    <div class="elem_block">
        <Siar:Button ID="btnEliminaSingolaIntegrazione" runat="server" OnClick="btnEliminaSingolaIntegrazione_Click"
            Text="Elimina singola integrazione" />
    </div>
    <div class="first_elem_block">
        <Siar:Button ID="btnVisualizzaIntegrazione" runat="server" OnClick="btnVisualizzaIntegrazione_Click" 
            Text="Visualizza integrazione"  />
    </div>
    <br />
    <br />

    <div runat="server" id="divInformazioniAggiuntiveAllegati" visible="false">
        <div class="separatore">
            Informazioni aggiuntive:
        </div>
        <br />

        <div class="paragrafo_light">
            Nuovo allegato:
        </div>
        <br />

        <div id="divCategoriaAllegato" runat="server" class="first_elem_block">
            Selezionare la categoria del documento:<br />
            <Siar:ComboSql ID="lstCategoriaAllegato" runat="server" OptionalValue="FORMATO" DataTextField="DESCRIZIONE"
                DataValueField="CODICE" Width="600px">
            </Siar:ComboSql>
        </div>
        <br />
        <br />

        <div id="divDichiarazioneSostitutiva" runat="server" style="display: none">
            <div class="first_elem_block">
	            Specificare l'ente:<br />
	            <Siar:Combo ID="lstNATipoEnte" runat="server">
		            <asp:ListItem></asp:ListItem>
		            <asp:ListItem Value="CM">Comune</asp:ListItem>
		            <asp:ListItem Value="PR">Provincia</asp:ListItem>
	            </Siar:Combo>
            </div>

            <div class="elem_block">
                Denominazione ente:<br />
                <Siar:TextBox ID="txtNAEnte" runat="server" Width="400px" />
            </div>
            <br />

            <div class="first_elem_block">
	            Data di emissione:<br />
	            <Siar:DateTextBox ID="txtNADatadoc" runat="server" Width="130px" />
            </div>

            <div class="elem_block">
                Numero documento:<br />
				<Siar:TextBox ID="txtNANumeroDoc" runat="server" Width="150px" />
            </div>
            <br />
            <br />
        </div>

        <div id="divUploadFileAllegato" runat="server" style="display: none">
            <div class="first_elem_block">
                <uc4:SNCUploadFileControl ID="ufcNAAllegato" runat="server" Width="600" Text="Selezionare un documento da caricare" />
            </div>
            <br />
        </div>

        <div class="first_elem_block">
            Breve descrizione: (facoltativa, max 250 caratteri) :<br />
            <Siar:TextArea ID="txtDescrizione" runat="server" NomeCampo="Descrizione"
                Width="600px" Rows="4" ExpandableRows="5" MaxLength="250" />
        </div>
        <br />
        <br />

        <div class="first_elem_block">
            <Siar:Button ID="btnSalvaAllegato" Text="Salva" runat="server" CausesValidation="false" Modifica="true"
                Width="150px" OnClick="btnSalvaAllegato_Click" OnClientClick="return ctrlCampi(event);" />
        </div>
        
        <div class="elem_block">
            <Siar:Button ID="btnEliminaAllegato" Text="Elimina" runat="server" CausesValidation="false"
                Modifica="true" Width="150px" OnClick="btnEliminaAllegato_Click" OnClientClick="return eliminaAllegato(event);" />
        </div> 
    </div>

    <div runat="server" id="divInformazioniAggiuntiveAllegatiIstruttore" visible="false">
        <div class="separatore">
            Informazioni aggiuntive:
        </div>
        <br />

        <Siar:DataGrid ID="dgAllegati" runat="server" AutoGenerateColumns="False" CssClass="tabella"
            Width="100%">
            <PagerStyle Mode="NumericPages" CssClass="coda"></PagerStyle>
            <AlternatingItemStyle BackColor="#FFF0D2" CssClass="DataGridRow"></AlternatingItemStyle>
            <ItemStyle CssClass="DataGridRow" Height="18px"></ItemStyle>
            <Columns>
                <Siar:NumberColumn HeaderText="Nr.">
                    <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                </Siar:NumberColumn>
                <asp:BoundColumn DataField="Formato" HeaderText="Formato">
                    <ItemStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Dettaglio documento"></asp:BoundColumn>
                <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonText="Visualizza"
                    ButtonType="ImageButton" JsFunction="SNCUFVisualizzaFile">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </Siar:JsButtonColumn>
                <asp:BoundColumn HeaderText="Esito">
                    <ItemStyle HorizontalAlign="Center" Width="130px" />
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="Note">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundColumn>
                <Siar:CheckColumn Name="chkSelezionaPerRichiedeIntegrazione" HeaderSelectAll="true"
                    DataField="IdAllegato">
                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                </Siar:CheckColumn>
            </Columns>
        </Siar:DataGrid>
        <br />

        <div class="first_elem_block">
			<Siar:Button ID="btnAmmettiAllegato" runat="server" Modifica="true" OnClick="btnAmmettiAllegato_Click"
				Text="Ammetti" Width="200px"></Siar:Button>
		</div>
    </div>

    <div runat="server" id="divInformazioniAggiuntiveGiustificativiSpese" visible="false">
        <div class="separatore">
            Informazioni aggiuntive:
        </div>
        <br />

        <div class="paragrafo_light">
			Dati del giustificativo:
		</div>
		<br />

        <div class="first_elem_block">
			Tipo giustificativo:<br />
			<Siar:ComboSql ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
				DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" Obbligatorio="True" NomeCampo="Tipo giustificativo"
				Width="280px">
			</Siar:ComboSql>
		</div>
        <br />

        <div class="first_elem_block">
			Numero:<br />
			<Siar:TextBox ID="txtNumGiustificativo" runat="server" Width="120px" MaxLength="30" />
		</div>
			
		<div class="elem_block">
			Data:<br />
			<Siar:DateTextBox ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo"
				Obbligatorio="True" Width="100px" />
		</div>
		<br />

        <div class="first_elem_block">
			Imponibile €:<br />
			<Siar:CurrencyBox ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo"
				Obbligatorio="True" Width="110px" />
		</div>
			
		<div class="elem_block">
			Iva %:<br />
			<Siar:QuotaBox ID="txtIva" runat="server" NomeCampo="Iva" Obbligatorio="True" Width="70px" />
		</div>
			
		<div class="elem_block">
			<br />
			<asp:CheckBox ID="chkNonRecuperabile" runat="server" Text="Iva non recuperabile" />
		</div>
		<br />

        <div class="first_elem_block">
			Oggetto della spesa:<br />
			<Siar:TextArea ID="txtDescGiustificativo" runat="server" NomeCampo="Oggetto della spesa"
				Obbligatorio="True" Width="578px" />
		</div>
        <br />

        <div class="first_elem_block">
			Fornitore (P.Iva):<br />
			<Siar:TextBox ID="txtPivaFornitore" runat="server" Width="190px" NomeCampo="Partita iva del fornitore"
				Obbligatorio="True" MaxLength="16" />
		</div>
			
		<div class="elem_block">
			<br />
			<Siar:Button ID="btnScaricaFornitore" runat="server" CausesValidation="false" Modifica="True"
				OnClick="btnScaricaFornitore_Click" Text="Cerca" Width="120px" ToolTip="Inserire la partita iva del fornitore (nel caso di p.iva straniera mettere 12 zeri). Se la ricerca non produce risultati si potrà compilare la ragione sociale in autonomia" />
		</div>
        <br />

        <div class="first_elem_block">
			Ragione sociale:<br />
			<Siar:TextBox ID="txtRSFornitore" runat="server" Width="576px" ReadOnly="True" />
		</div>
        <br />

        <div class="first_elem_block">
			Specificare il file digitale relativo al giustificativo:<br />
			<uc4:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="DocumentoFE" />
		</div>
        <br />
        <br />

            
        <div id="divInformazioniAggiuntiveSpese" runat="server" visible="false">
            <div class="paragrafo_light">
				Estremi del pagamento:
			</div>
			<br />

            <div class="first_elem_block">
				Tipo pagamento:<br />
				<Siar:ComboSql ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
					DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" Obbligatorio="True" NomeCampo="Tipo pagamento">
				</Siar:ComboSql>
			</div>
            <br />

            <div class="first_elem_block">
				Data:<br />
				<Siar:DateTextBox ID="txtDataPagamento" runat="server" NomeCampo="Data pagamento"
					Obbligatorio="True" Width="90px" />
			</div>
				
			<div class="elem_block">
				Importo Lordo €:<br />
				<Siar:CurrencyBox ID="txtImportoLordoPagamento" runat="server" NomeCampo="Importo lordo del pagamento"
					Obbligatorio="True" Width="110px" />
			</div>
				
			<div class="elem_block">
				Importo Netto €:<br />
				<Siar:CurrencyBox ID="txtImportoNettoPagamento" runat="server" Width="110px" NomeCampo="Importo netto del pagamento"
					Obbligatorio="True" />
			</div>
			<br />

            <div class="first_elem_block">
				Estremi:<br />
				<Siar:TextBox ID="txtEstremi" runat="server" Width="488px" NomeCampo="Estremi del pagamento"
					Obbligatorio="True" />
			</div>
            <br />

            <div class="first_elem_block">
				Specificare il file digitale relativo al pagamento:<br />
				<uc4:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" />
			</div>
            <br />

            <div id="divFileSpesaSostenuta" runat="server" visible="false">
                <div class="paragrafo">
				    Ulteriori file digitali a sostegno del pagamento
			    </div>
			    <br />

                <Siar:DataGrid ID="dgFileSpeseSostenute" runat="server" AutoGenerateColumns="false" Visible="true" AllowPaging="true" PageSize="20" Width="90%">
                    <Columns>
                        <Siar:ColonnaLink DataField="IdFileSpeseSostenute" HeaderText="Id." IsJavascript="true"
                            LinkFields="IdFileSpeseSostenute" LinkFormat="selezionaFileSpese({0});">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="NomeFile" HeaderText="Nome file"></asp:BoundColumn>
                        <Siar:JsButtonColumn Arguments="IdFileSpeseSostenute" ButtonType="TextButton" ButtonText="Rimuovi" JsFunction="rimuoviFileSpesa">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                        <Siar:JsButtonColumn Arguments="IdFile" ButtonType="TextButton" ButtonText="Visualizza" JsFunction="SNCUFVisualizzaFile">
                            <ItemStyle Width="90px" HorizontalAlign="Center" />
                        </Siar:JsButtonColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />

                <div id="divInserimentoFileSpese" runat="server">
                    <div class="paragrafo">
				    Dettaglio file
			        </div>
			        <br />

                    <div class="first_elem_block">
					    Descrizione file:<br />
					    <Siar:TextBox ID="txtDescrizioneFile" runat="server" Width="488px" />
				    </div>
                    <br />

                    <div class="first_elem_block">
					    Specificare il file digitale relativo al pagamento:<br />
					    <uc4:SNCUploadFileControl ID="ufFileSpesaSostenuta" runat="server" TipoFile="Documento" />
				    </div>
                    <br />

                    <div class="first_elem_block">
					    <Siar:Button ID="btnAssociaFileSpesa" runat="server" CausesValidation="False"
						    OnClick="btnAssociaFileSpesa_Click" Text="Associa file al pagamento" />
				    </div>
				
				    <div class="elem_block">
					    <input type="button" class="Button" value="Svuota campi file" style="width: 140px" onclick="return svuotaCampiFile();" />
				    </div>
                </div>
                
                <br />
                <br />
                <br />
            </div>
        </div>
          
        <div class="first_elem_block">
            <Siar:Button ID="btnSalvaGiustificativiSpesa" runat="server" CausesValidation="True" Modifica="True"
                OnClick="btnSalvaGiustificativiSpesa_Click" Text="Salva" Width="160px" OnClientClick="return validaImporti(false,event);" />
        </div>
        <br />
    </div>
</div>