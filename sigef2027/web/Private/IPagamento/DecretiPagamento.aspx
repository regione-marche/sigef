<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="DecretiPagamento.aspx.cs" Inherits="web.Private.IPagamento.DecretiPagamento" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function estraiInXls() {

            var IdBando = $('[id$=hdnIdBando]').val();
            var IdDomanda = $('[id$=hdnIDomandaPagamento]').val();
            var NascondiDecreti = 0;
            var NascondiLiquidati = 0;
            var dettaglioDecreti = 1;
            var dettaglioMandati = 1;

            if ($("#ctl00_cphContenuto_chkNascondiDecreti").is(':checked')) {
                NascondiDecreti = 1;
            }

            if ($("#ctl00_cphContenuto_chkNascondiLiquidati").is(':checked')) {
                NascondiLiquidati = 1;
            }
            var parametri = '';
            if (IdDomanda == '') {
                parametri = 'Idbando=' + IdBando + '|NascondiDecreti=' + NascondiDecreti + '|NascondiLiquidati=' + NascondiLiquidati + '|dettaglioDecreti=' + dettaglioDecreti + '|dettaglioMandati=' + dettaglioMandati;
            }
            else {
                parametri = 'Idbando=' + IdBando + '|IdDomanda=' + IdDomanda + '|NascondiDecreti=' + NascondiDecreti + '|NascondiLiquidati=' + NascondiLiquidati + '|dettaglioDecreti=' + dettaglioDecreti + '|dettaglioMandati=' + dettaglioMandati;
            }
            var IdProgetto = $('[id$=txtIdProgettoF]').val();
            if (IdProgetto != "")
                parametri += '|IdProgetto=' + IdProgetto;




            SNCVisualizzaReport('rptDecretiPagamento', 2, parametri);
        }

        function selezionaDomanda(id) {
            if ($('[id$=hdnIDomandaPagamento]').val() == null || $('[id$=hdnIDomandaPagamento]').val() == "") {
                $('[id$=hdnIDomandaPagamento]').val(id);
                $('[id$=hdnIdMandato]').val('');
            }
            else {
                $('[id$=hdnIDomandaPagamento]').val('');
            }

            $('[id$=hdnIdDecretiXDomPagEsportazione]').val('');
            $('[id$=hdnIdAtto]').val('');

            $('[id$=btnPost]').click();
        }
        //function selezionaDomanda(id, elem) {
        //    if (elem.checked == false) {
        //        $('[id$=hdnIDomandaPagamento]').val('');
        //    }
        //    else {
        //        $('[id$=hdnIDomandaPagamento]').val(id);
        //        $('[id$=hdnIdMandato]').val('');
        //    }
        //    $('[id$=hdnIdDecretiXDomPagEsportazione]').val('');
        //    $('[id$=hdnIdAtto]').val('');

        //    $('[id$=btnPost]').click();
        //}
        //function selezionaDecreto(id, elem) {
        //    if (elem.checked == false) {
        //        $('[id$=hdnIdDecretiXDomPagEsportazione]').val('');
        //        $('[id$=hdnIdAtto]').val('');
        //    }
        //    else $('[id$=hdnIdDecretiXDomPagEsportazione]').val(id);
        //    $('[id$=btnPost]').click();
        //}

        function selezionaDecreto(id) {
            if ($('[id$=hdnIdDecretiXDomPagEsportazione]').val() == null || $('[id$=hdnIdDecretiXDomPagEsportazione]').val() == "") {
                $('[id$=hdnIdDecretiXDomPagEsportazione]').val(id);
            }
            else {
                $('[id$=hdnIdDecretiXDomPagEsportazione]').val('');
                $('[id$=hdnIdAtto]').val('');
            }
            $('[id$=btnPost]').click();
        }

        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }

        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
            else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); return stopEvent(ev); }
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        }

        function ctrlTipoAttoOrg(ev) {
            if ($('[id$=txtDataDecretoOrg_text]').val() == "" || $('[id$=txtDescrizioneDecretoOrg_text]').val() == "" || $('[id$=txtLinkEst_text]').val() == "" || $('[id$=txtNumeroDecretoOrg_text]').val() == "" || $('[id$=txtAttoImportoOrg_text]').val() == "") {
                alert('Per proseguire è necessario specificare la data, il numero, la descrizione, il link esterno e l importo.'); return stopEvent(ev);
            }
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        }

        function ctrlRichiesta(ev) {
            if ($('[id$=txtRichiestaData_text]').val() == "" || $('[id$=txtRichiestaImporto_text]').val() == "" || $('[id$=txtRichiestaSegnatura_text]').val() == "") {
                alert('Per proseguire è necessario specificare data, importo, segnatura della richiesta.');
                return stopEvent(ev);
            }


        }


        function ctrlMandato(ev) { if ($('[id$=txtMandatoData_text]').val() == "" || $('[id$=txtMandatoImporto_text]').val() == "" || $('[id$=txtMandatoNumero_text]').val() == "" || $('[id$=ufMandato_hdnSNCUFUploadFile]').val() == "") { alert('Per proseguire è necessario specificare numero, data, importo e file digitale del mandato.'); return stopEvent(ev); } }
        function ctrlQuietanza(ev) { if ($('[id$=txtQuietanzaData_text]').val() == "" || $('[id$=txtQuietanzaImporto_text]').val() == "") { alert('Per proseguire è necessario specificare data e importo della quietanza di pagamento.'); return stopEvent(ev); } }

        function selezionaMandato(mandato) {
            $('[id$=hdnIdMandato]').val(mandato);
            $('[id$=btnSelezionaMandato]').click();
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function changeCompensazione() {
            if ($('[id$=chkCompensazione').is(':checked')) {
                $('[id$=txtAttoImporto_text]').attr('disabled', 'disabled');
            }
            else {
                $('[id$=txtAttoImporto_text]').removeAttr('disabled');
            }
        }

        function readyFn(jQuery) {
            $('[id$=chkCompensazione]').change(changeCompensazione);
            /*$('[id$=chkCompensazione]').change();*/
        }

        function pageLoad() {
            readyFn();
        }

    </script>

    <br />
    <div style="display: none">
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdBando" runat="server" />
        <asp:HiddenField ID="hdnIDomandaPagamento" runat="server" />
        <asp:HiddenField ID="hdnIdDecretiXDomPagEsportazione" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnIdMandato" runat="Server" />
        <asp:Button ID="btnSelezionaMandato" runat="server" OnClick="btnSelezionaMandato_Click" CausesValidation="false" />
    </div>
    <div class="row p-5">
        <h2 class="">Elenco dei decreti di pagamento</h2>
        <div class="row bd-form">
            <p>
                Di seguito sono elencate le domande di pagamento presentate dai beneficiari ed approvate dai funzionari istruttori assegnati.
            </p>
            <h4 class="pb-5">Filtra:</h4>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkNascondiDecreti" runat="server" Text="Nascondi decreti inseriti" />
            </div>
            <div class="col-sm-3 form-check">
                <asp:CheckBox ID="chkNascondiLiquidati" runat="server" Checked="True" Text="Nascondi domande liquidate" />
            </div>
            <div class="col-sm-3 form-group">
                <Siar:TextBox  Label="ID Progetto" ID="txtIdProgettoF" runat="server" onkeypress="return isNumberKey(event)" />
            </div>
            <div class="col-sm-3">
                <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra" />
            </div>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                PageSize="15" Width="100%" ShowFooter="true">
                <footerstyle cssclass="coda" horizontalalign="Right" />
                <columns>
                    <%--<asp:BoundColumn DataField="IdProgetto" HeaderText="ID Progetto">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>--%>
                    <Siar:ColonnaLinkAgid DataField="IdProgetto" HeaderText="ID Progetto" LinkFields="IdDomandaPagamento"
                        LinkFormat='javascript:selezionaDomanda({0})'>
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Modalit&#224; della richiesta">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataModifica" HeaderText="Data di presentazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo ammesso a pagamento">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo decreti associati">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <%--<asp:BoundColumn HeaderText="Importo richieste liquidazione">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>--%>
                    <asp:BoundColumn HeaderText="Importo mandato">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo liquidato">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Stato liquidazione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <%--                        <Siar:CheckColumn DataField="IdDomandaPagamento" Name="chkIdDomandaPagamento">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>--%>
                    <asp:BoundColumn HeaderText="Checklist Validata">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </columns>
            </Siar:DataGridAgid>
        </div>
        <div class="row" id="trDettaglioDomanda" runat="server" visible="false">
            <h3 class="pb-5">Dettaglio domanda selezionata:</h3>
            <h4>Dettaglio della spesa:</h4>
            <div class="col-sm-12 mb-5">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgMisura" runat="server" AutoGenerateColumns="false">
                    <columns>
                        <asp:BoundColumn DataField="Misura">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContributoDiMisura" DataFormatString="{0:c}" HeaderText="Contributo ammesso">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </columns>
                </Siar:DataGridAgid>
            </div>
            <h4>Decreti:</h4>
            <div class="col-sm-12 mb-5">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDecreti" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" ShowFooter="true">
                    <footerstyle cssclass="coda" horizontalalign="Right" />
                    <columns>
                        <asp:BoundColumn DataField="Numero" HeaderText="Decreto"></asp:BoundColumn>
                        <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdDecretiXDomPagEsportazione"
                            LinkFormat='javascript:selezionaDecreto({0})'>
                        </Siar:ColonnaLinkAgid>
                        <asp:BoundColumn DataField="TipoAtto" HeaderText="Tipo">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DefinizioneAtto" HeaderText="Definizione">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="OrganoIstituzionale" HeaderText="Organo">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderText="Importo">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="RecuperoCompensazione" HeaderText="A compensazione">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <%--<Siar:CheckColumn DataField="IdDecretiXDomPagEsportazione" Name="chkIdDecretiXDomPagEsportazione">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </Siar:CheckColumn>--%>
                    </columns>
                </Siar:DataGridAgid>
            </div>
            <div class="row bd-form pt-5" runat="server" id="trDecretiRicerca">
                <div class="col-sm-2 form-group">
                    <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstAttoDefinizione" runat="server" NoBlankItem="True">
                    </Siar:ComboDefinizioneAtto>
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:IntegerTextBox Label="Numero:" NoCurrency="True" ID="txtAttoNumero" runat="server" NomeCampo="Numero decreto" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:DateTextBox Label="Data:" ID="txtAttoData" runat="server" NomeCampo="Data decreto" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:ComboRegistriAtto Label="Registro:" ID="lstAttoRegistro" runat="server">
                    </Siar:ComboRegistriAtto>
                </div>
                <div class="col-sm-4 text-start">
                    <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                        Text="Ricerca" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                </div>
            </div>
            <div class="row bd-form" runat="server" id="trDecreti">
                <h4 class="pb-5">Dati Decreto:
                </h4>
                <div class="col-sm-12 form-group">
                    <Siar:TextArea ID="txtAttoDescrizione" Label="Descrizione:" runat="server" ReadOnly="True"
                        Rows="4" ExpandableRows="5">
                    </Siar:TextArea>
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:ComboOrganoIstituzionale Label="Organo Istituzionale:" ID="lstAttoOrgIstituzionale" runat="server"
                        Enabled="False">
                    </Siar:ComboOrganoIstituzionale>
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:ComboTipoAtto Label="Tipo atto:" ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                    </Siar:ComboTipoAtto>
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:CurrencyBox Label="Importo €:" ID="txtAttoImporto" runat="server" />
                </div>
                <div class="col-sm-3 form-group">
                    <asp:CheckBox ID="chkCompensazione" runat="server" />Recupero a compensazione a seguito dell’irregolarità
                </div>
                <h5 class="pb-5">Pubblicazione B.U.R.
                </h5>
                <div class="col-sm-3 form-group">
                    <Siar:IntegerTextBox Label="Numero:" ID="txtAttoBurNumero" runat="server" ReadOnly="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:DateTextBox Label="Data:" ID="txtAttoBurData" runat="server" ReadOnly="True" />
                </div>
                <div class="col-sm-6 text-start">
                    <input id="btnVidualizzaDecreto" runat="server" class="btn btn-primary py-1" type="button" disabled="disabled" value="Visualizza atto" />
                    <Siar:Button ID="btnAssociaDecreto" runat="server" OnClick="btnAssociaDecreto_Click"
                        Text="Associa decreto" Modifica="True" OnClientClick="return ctrlTipoAtto(event);" />
                    <Siar:Button ID="btnEliminaDecreto" runat="server" OnClick="btnElimnaDecreto_Click" Enabled="false"
                        Text="Elimina decreto" Conferma="Sei sicuro di voler eliminare il decreto?" Modifica="False" />
                </div>
                <div class="row mt-5" runat="server" id="trDecretiOrg" visible="false">
                    <p>
                        Inserire tutti i dati relativi al decreto/atto ed il link dello stesso presente nel proprio albo pretorio.
                    </p>
                    <div class="col-sm-4 form-group">
                        <Siar:DateTextBox Label="Data:" ID="txtDataDecretoOrg" runat="server" />
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:IntegerTextBox Label="Numero:" NoCurrency="True" ID="txtNumeroDecretoOrg" runat="server" />
                    </div>
                    <div class="col-sm-4 form-group">
                        <Siar:CurrencyBox Label="Importo €:" ID="txtAttoImportoOrg" runat="server" />
                    </div>
                    <div class="col-sm-12 form-group">
                        <Siar:TextArea Label="Descrizione/titolo:" Rows="3" MaxLength="3000" ID="txtDescrizioneDecretoOrg" runat="server" />
                    </div>
                    <div class="col-sm-12 form-group">
                        <Siar:TextBox  Label="Link Esterno:" ID="txtLinkEst" runat="server" />
                    </div>
                    <div class="col-sm-12 form-group">
                        <Siar:Button ID="btnAssociaDecretoOrg" runat="server" OnClick="btnAssociaDecreto_Click"
                            Text="Associa decreto" Modifica="True" OnClientClick="return ctrlTipoAttoOrg(event);" />
                        <Siar:Button ID="btnEliminaDecretoOrg" runat="server" OnClick="btnElimnaDecreto_Click" Enabled="false"
                            Text="Elimina decreto" Conferma="Sei sicuro di voler eliminare il decreto?" Modifica="False" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgDomandeLiquidazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="15" ShowFooter="true">
                        <itemstyle height="28px" />
                        <footerstyle cssclass="coda" horizontalalign="Right" />
                        <columns>
                            <Siar:ColonnaLink LinkFields="Id" LinkFormat="javascript:selezionaMandato({0});"
                                DataField="Id">
                            </Siar:ColonnaLink>
                            <%--<asp:BoundColumn DataField="RichiestaMandatoData" HeaderText="Data">
										<ItemStyle HorizontalAlign="Center" Width="150px" />	
									</asp:BoundColumn>	
									<asp:BoundColumn DataField="RichiestaMandatoImporto" HeaderText="Importo">
										<ItemStyle HorizontalAlign="Right" Width="110px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RichiestaMandatoSegnatura" HeaderText="Segnatura">
										<ItemStyle HorizontalAlign="Center" Width="150px" />
									</asp:BoundColumn>--%>
                            <asp:BoundColumn DataField="MandatoNumero" HeaderText="Numero">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="MandatoData" HeaderText="Data">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="MandatoImporto" HeaderText="Importo">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdImpresaBeneficiaria" HeaderText="Impresa">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="QuietanzaData" HeaderText="Data">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="QuietanzaImporto" HeaderText="Importo">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundColumn>
                        </columns>
                    </Siar:DataGridAgid>
                </div>
                <div class="col-sm-12 mb-5">
                    <Siar:Button ID="btnNuovoMandato" runat="server" OnClick="btnNuovoMandato_Click"
                        Text="Aggiungi nuovo mandato" Visible="false" />
                </div>
                <div class="row" id="trMandato" runat="server" visible="false">
                    <h3 class="pb-5">Dettaglio del mandato:</h3>
                    <div class="row" style="display: none;">
                        <h4 class="pb-5">Dati della richesta di mandato:
                        </h4>
                        <div class="col-sm-3">
                            <Siar:DateTextBox Label="Data:" ID="txtRichiestaData" runat="server" />
                        </div>
                        <div class="col-sm-3">
                            <Siar:CurrencyBox Label="Importo €:" ID="txtRichiestaImporto" runat="server" />
                        </div>
                        <div class="col-sm-3">
                            <Siar:TextBox  Label="Segnatura:" ID="txtRichiestaSegnatura" runat="server" />
                            <img id="imgRichiestaSegnatura" runat="server" height="18" src="../../images/lente.png"
                                title="Visualizza documento" width="18" />
                        </div>
                        <div class="col-sm-3">
                            <Siar:Button ID="btnSalvaRichiesta" runat="server" OnClick="btnSalvaRichiesta_Click"
                                Text="Salva dati richiesta" Modifica="False" OnClientClick="return ctrlRichiesta(event);"
                                Enabled="False" />
                        </div>
                    </div>
                    <div class="row">
                        <h4>Dati del mandato di pagamento:</h4>
                        <div class="col-sm-12 mb-5">
                            <uc1:SNCUploadFileControl Text="Caricare il file digitale:" ID="ufMandato" runat="server" TipoFile="Documento" AbilitaModifica="false" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:TextBox  Label="Numero:" ID="txtMandatoNumero" runat="server" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:DateTextBox Label="Data:" ID="txtMandatoData" runat="server" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:CurrencyBox Label="Importo €:" ID="txtMandatoImporto" runat="server" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:ComboBase Label="Impresa:" ID="lstBeneficiarioMandato" runat="server" NomeCampo="BeneficiarioMandato"></Siar:ComboBase>
                        </div>
                        <div class="col-sm-12 text-start mb-5">
                            <Siar:Button ID="btnSalvaMandato" runat="server" OnClick="btnSalvaMandato_Click"
                                Text="Salva dati mandato" Modifica="False" OnClientClick="return ctrlMandato(event);"
                                Enabled="False" />
                        </div>
                    </div>
                    <div class="row">
                        <h4 class="pb-5">Dati della quietanza:</h4>
                        <div class="col-sm-3 form-group">
                            <Siar:DateTextBox Label="Data:" ID="txtQuietanzaData" runat="server" />
                        </div>
                        <div class="col-sm-3 form-group">
                            <Siar:CurrencyBox Label="Importo €:" ID="txtQuietanzaImporto" runat="server" />
                        </div>
                        <div class="col-sm-6 text-start">
                            <Siar:Button ID="btnSalvaQuietanza" runat="server" OnClick="btnSalvaQuietanza_Click"
                                Text="Salva dati quietanza" Modifica="False" OnClientClick="return ctrlQuietanza(event);"
                                Enabled="False" />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <Siar:Button ID="btnEliminaMandato" runat="server" OnClick="btnEliminaMandato_Click"
                            Text="Elimina mandato" Conferma="Sei sicuro di voler eliminare il mandato?"
                            Enabled="False" Modifica="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
