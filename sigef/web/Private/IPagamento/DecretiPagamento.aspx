<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="DecretiPagamento.aspx.cs" Inherits="web.Private.IPagamento.DecretiPagamento" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function estraiInXls() {

            var IdBando = $('[id$=hdnIdBando]').val();
            var IdDomanda = $('[id$=hdnIDomandaPagamento]').val();
            var NascondiDecreti =0;
            var NascondiLiquidati = 0;
            var dettaglioDecreti = 1;
            var dettaglioMandati = 1;

            if($("#ctl00_cphContenuto_chkNascondiDecreti").is(':checked'))
                {
                    NascondiDecreti = 1;
            }   

            if($("#ctl00_cphContenuto_chkNascondiLiquidati").is(':checked'))
                {
                    NascondiLiquidati = 1;
            } 
            var parametri = '';
            if (IdDomanda == '') {
                parametri = 'Idbando=' + IdBando + '|NascondiDecreti=' + NascondiDecreti + '|NascondiLiquidati=' + NascondiLiquidati+ '|dettaglioDecreti=' + dettaglioDecreti + '|dettaglioMandati=' + dettaglioMandati;
            }
            else {
                parametri = 'Idbando=' + IdBando + '|IdDomanda=' + IdDomanda + '|NascondiDecreti=' + NascondiDecreti + '|NascondiLiquidati=' + NascondiLiquidati+ '|dettaglioDecreti=' + dettaglioDecreti + '|dettaglioMandati=' + dettaglioMandati;
            }
            var IdProgetto = $('[id$=txtIdProgettoF]').val();
            if (IdProgetto != "")
                parametri += '|IdProgetto=' + IdProgetto;



            
            SNCVisualizzaReport('rptDecretiPagamento', 2, parametri);
        }
        function selezionaDomanda(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIDomandaPagamento]').val('');
            }
            else {
                $('[id$=hdnIDomandaPagamento]').val(id);
                $('[id$=hdnIdMandato]').val('');
            }
            $('[id$=hdnIdDecretiXDomPagEsportazione]').val('');
            $('[id$=hdnIdAtto]').val('');

            $('[id$=btnPost]').click();
        }
        function selezionaDecreto(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdDecretiXDomPagEsportazione]').val('');
                $('[id$=hdnIdAtto]').val('');
            }
            else $('[id$=hdnIdDecretiXDomPagEsportazione]').val(id);
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
                alert('Per proseguire è necessario specificare la data, il numero, la descrizione, il link esterno e l importo.'); return stopEvent(ev); }        
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        }

        function ctrlRichiesta(ev) {
            if ($('[id$=txtRichiestaData_text]').val() == "" || $('[id$=txtRichiestaImporto_text]').val() == "" || $('[id$=txtRichiestaSegnatura_text]').val() == "") 
            {
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
    <table class="tableNoTab" width="1000px">
        <tr>
            <td class="separatore_big">
                ELENCO DECRETI DI PAGAMENTO
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="testo_pagina" style="width: 587px">
                            Di seguito sono elencate le domande di pagamento presentate dai beneficiari<br />
                            ed approvate dai funzionari istruttori assegnati.
                        </td>
                        <td style="width: 229px">
                            <br />
                            <asp:CheckBox ID="chkNascondiDecreti" runat="server" Text="Nascondi decreti inseriti" />
                            <br />
                            <asp:CheckBox ID="chkNascondiLiquidati" runat="server" Checked="True" Text="Nascondi domande liquidate" />
                            <br />
                            <br />
                            <Siar:Button ID="btnEsporta" runat="server" OnClientClick="return estraiInXls();" Text="Estrai in xls"
                                Width="140px" />
                            <%--<input type="btnEsporta" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls();" />--%>
                            </td>
                        <td>
                            <br />
                            ID Progetto <br />
                            <Siar:TextBox ID="txtIdProgettoF" runat="server" Width="104px" onkeypress="return isNumberKey(event)" />
                            <br /><br />
                            
                            <Siar:Button ID="btnFiltra" runat="server" OnClick="btnFiltra_Click" Text="Filtra"
                                Width="80px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dgDomande" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="15" Width="100%" ShowFooter="true">
                    <ItemStyle Height="28px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="ID Progetto">
                            <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="110px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Modalit&#224; della richiesta">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DataModifica" HeaderText="Data di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contributo ammesso a pagamento">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo decreti associati">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                        <%--<asp:BoundColumn HeaderText="Importo richieste liquidazione">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn HeaderText="Importo mandato">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo liquidato">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Stato liquidazione">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdDomandaPagamento" Name="chkIdDomandaPagamento">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn HeaderText="Checklist Validata">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />
                <br />
            </td>
        </tr>
        <tr id="trDettaglioDomanda" runat="server" visible="false">
            <td>
                <table width="100%">
                    <tr>
                        <td class="separatore">
                            Dettaglio domanda selezionata:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table width="100%">
                                <tr>
                                    <td class="paragrafo" style="width: 287px">
                                        Dettaglio della spesa:
                                    </td>

                                </tr>
                                
                                <tr>
                                    <td style="width: 287px; vertical-align: top">
                                        <Siar:DataGrid ID="dgMisura" runat="server" AutoGenerateColumns="false">
                                            <ItemStyle Height="26px" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Misura">
                                                    <ItemStyle HorizontalAlign="Center" Width="160px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="ContributoDiMisura" DataFormatString="{0:c}" HeaderText="Contributo ammesso">
                                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="paragrafo">
                                        Decreti:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="padding: 10px">                
                                                    <Siar:DataGrid ID="dgDecreti" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        PageSize="15" Width="100%" ShowFooter="true">
                                                        <ItemStyle Height="28px" />
                                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="Numero" HeaderText="Decreto">
                                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                                                <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TipoAtto" HeaderText="Tipo">
                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="DefinizioneAtto" HeaderText="Definizione">
                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="OrganoIstituzionale" HeaderText="Organo">
                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                            </asp:BoundColumn>     
                                                            <asp:BoundColumn DataField="Importo" HeaderText="Importo">
                                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                            </asp:BoundColumn>    
                                                            <asp:BoundColumn DataField="RecuperoCompensazione" HeaderText="A compensazione">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:BoundColumn> 
                                                            <Siar:CheckColumn DataField="IdDecretiXDomPagEsportazione" Name="chkIdDecretiXDomPagEsportazione">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </Siar:CheckColumn>
                                                        </Columns>
                                                    </Siar:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 10px" class="paragrafo">Dati Decreto:
                                                </td>
                                            </tr>    
                                            <tr  runat="server" id="trDecretiRicerca">
                                                <td style="padding: 10px">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 100px">
                                                                Definizione:<br />
                                                                <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True"
                                                                    Width="80px">
                                                                </Siar:ComboDefinizioneAtto>
                                                            </td>
                                                            <td style="width: 100px">
                                                                Numero:<br />
                                                                <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="80px" NomeCampo="Numero decreto" />
                                                            </td>
                                                            <td style="width: 120px">
                                                                Data:<br />
                                                                <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                                                            </td>
                                                            <td style="width: 146px">
                                                                Registro:<br />
                                                                <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px">
                                                                </Siar:ComboRegistriAtto>
                                                            </td>
                                                            <td>
                                                                <br />
                                                                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                                                    Text="Ricerca" Width="109px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trDecreti">
                                                <td style="padding-left: 10px">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                Descrizione:<br />
                                                                <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="600px" ReadOnly="True"
                                                                    Rows="4" ExpandableRows="5"></Siar:TextArea>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 260px">
                                                                            Organo Istituzionale:<br />
                                                                            <Siar:ComboOrganoIstituzionale ID="lstAttoOrgIstituzionale" runat="server" Width="210px"
                                                                                Enabled="False">
                                                                            </Siar:ComboOrganoIstituzionale>
                                                                        </td>
                                                                        <td>
                                                                            Tipo atto:<br />
                                                                            <Siar:ComboTipoAtto ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                                                                            </Siar:ComboTipoAtto>
                                                                        </td>
                                                                        <td>
													                        Importo €:<br />
													                        <Siar:CurrencyBox ID="txtAttoImporto" runat="server" Width="160px" />
												                        </td>
                                                                        <td>
                                                                            <br />
                                                                            <asp:CheckBox ID="chkCompensazione" runat="server" />Recupero a compensazione a seguito dell’irregolarità
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td class="paragrafo" colspan="2">
                                                                            Pubblicazione B.U.R.
                                                                        </td>
                                                                        <td rowspan="2">
                                                                            <br />
                                                                            <br />
                                                                            <input id="btnVidualizzaDecreto" runat="server" class="Button" style="width: 130px;
                                                                                margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />
                                                                            <Siar:Button ID="btnAssociaDecreto" runat="server" OnClick="btnAssociaDecreto_Click"
                                                                                Text="Associa decreto" Width="140px" Modifica="True" OnClientClick="return ctrlTipoAtto(event);" />
                                                                            <Siar:Button ID="btnEliminaDecreto" runat="server" OnClick="btnElimnaDecreto_Click" Enabled="false"
                                                                                Text="Elimina decreto" Width="140px" Conferma="Sei sicuro di voler eliminare il decreto?" Modifica="False"/>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 150px">
                                                                            Numero:<br />
                                                                            <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                                                        </td>
                                                                        <td style="width: 150px">
                                                                            Data:<br />
                                                                            <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr  runat="server" id="trDecretiOrg" visible = "false">
                                                <td style="padding: 10px"> 
                                                    <table width="100%"> 
                                                        <tr>
                                                            <td class="testo_pagina" colspan="3">
                                                                Inserire tutti i dati relativi al decreto/atto ed il link dello stesso presente
                                                                nel proprio albo pretorio.
                                                            </td>
                                                        </tr> 
                                                        <tr > 
                                                           <td style="width: 160px"> 
								                                Data:<br /> 
								                                <Siar:DateTextBox ID="txtDataDecretoOrg" runat="server" Width="120px" />							</td> 
                                                            <td style="width: 160px"> 
								                                Numero:<br /> 
								                                <Siar:IntegerTextBox  NoCurrency="True" ID="txtNumeroDecretoOrg" runat="server" Width="120px" /> 
							                                </td> 
                                                            <td style="width: 330px"> 
													            Importo €:<br />
													            <Siar:CurrencyBox ID="txtAttoImportoOrg" runat="server" Width="160px" />
							                                </td> 
                                                        </tr> 
                                                        <tr> 
							                                <td colspan="3" style="width: 650px"> 
								                                Descrizione/titolo:<br /> 
								                                <Siar:TextArea Rows="3" MaxLength="3000" ID="txtDescrizioneDecretoOrg" runat="server" Width="630px"  /> 
							                                </td> 
                                                        </tr> 
                                                        <tr> 
							                                <td colspan="3" style="width: 650px"> 
								                                Link Esterno:<br /> 
								                                <asp:TextBox ID="txtLinkEst" runat="server" Width="630px"  /> 
							                                </td> 
                                                        </tr> 
                                                        <tr >  
                                                            <td align="right" style="height: 70px; " colspan="3"> 
                                                                   <%--<input id="btnVidualizzaDecretoOrg" runat="server" class="Button" style="width: 130px;
                                                                        margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />--%>
                                                                    <Siar:Button ID="btnAssociaDecretoOrg" runat="server" OnClick="btnAssociaDecreto_Click"
                                                                        Text="Associa decreto" Width="140px" Modifica="True" OnClientClick="return ctrlTipoAttoOrg(event);" />
                                                                    <Siar:Button ID="btnEliminaDecretoOrg" runat="server" OnClick="btnElimnaDecreto_Click" Enabled="false"
                                                                        Text="Elimina decreto" Width="140px" Conferma="Sei sicuro di voler eliminare il decreto?" Modifica="False"/>
                                                            </td> 
                                                        </tr> 
                                                    </table> 
                                                </td> 
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
						<td>
							<Siar:DataGrid ID="dgDomandeLiquidazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								PageSize="15" Width="100%"  ShowFooter="true" >
								<ItemStyle Height="28px" />
								<FooterStyle CssClass="coda" HorizontalAlign="Right" />
								<Columns>
								    <Siar:ColonnaLink  LinkFields="Id" LinkFormat="javascript:selezionaMandato({0});" 
                                        DataField="Id" ItemStyle-Width = "20px">
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
										<ItemStyle HorizontalAlign="Center" Width="150px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MandatoData" HeaderText="Data">
										<ItemStyle HorizontalAlign="Center" Width="150px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MandatoImporto" HeaderText="Importo">
										<ItemStyle HorizontalAlign="Right" Width="150px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IdImpresaBeneficiaria" HeaderText="Impresa">
									    <ItemStyle HorizontalAlign="Center" Width="250px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QuietanzaData" HeaderText="Data">
										<ItemStyle HorizontalAlign="Center" Width="150px" />
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QuietanzaImporto" HeaderText="Importo">
										<ItemStyle HorizontalAlign="Right" Width="150px" />
									</asp:BoundColumn>
								</Columns>
							</Siar:DataGrid>
						
						
						</td>
					</tr>
					<tr>
					    <td align="right" style="padding: 10px">
					        <br />
							<Siar:Button ID="btnNuovoMandato" runat="server" OnClick="btnNuovoMandato_Click"
								Text="Aggiungi nuovo mandato" Width="160px" Visible="false" />
						</td>
					</tr>
					<tr id="trMandato" runat="server" visible="false">
						<td>
							<table width="100%">
							    <tr>
							        <td class="separatore">
                                        Dettaglio del mandato:
                                    </td>
                                </tr>
								<tr style="display:none;">
									<td class="paragrafo">
										Dati della richesta di mandato:
									</td>
								</tr>
								<tr style="display:none;">
									<td style="padding: 10px">
										<table width="100%">
											<tr>
												<td style="width: 140px">
													Data:<br />
													<Siar:DateTextBox ID="txtRichiestaData" runat="server" Width="120px" />
												</td>
												<td style="width: 180px">
													Importo €:<br />
													<Siar:CurrencyBox ID="txtRichiestaImporto" runat="server" Width="160px" />
												</td>
												<td style="width: 440px">
													Segnatura:<br />
													<Siar:TextBox ID="txtRichiestaSegnatura" runat="server" Width="400px" />
													<img id="imgRichiestaSegnatura" runat="server" height="18" src="../../images/lente.png"
														title="Visualizza documento" width="18" />
												</td>
												<td align="right">
													<br />
													<Siar:Button ID="btnSalvaRichiesta" runat="server" OnClick="btnSalvaRichiesta_Click"
														Text="Salva dati richiesta" Width="160px" Modifica="False" OnClientClick="return ctrlRichiesta(event);"
														Enabled="False" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td class="paragrafo">
										Dati del mandato di pagamento:
									</td>
								</tr>
								<tr>
									<td style="padding: 10px">
										Caricare il file digitale:
										<uc1:SNCUploadFileControl ID="ufMandato" runat="server" TipoFile="Documento" AbilitaModifica="false" />
										<table width="100%">
											<tr>
												<td style="width: 200px">
													Numero:
													<br />
													<Siar:TextBox ID="txtMandatoNumero" runat="server" Width="160px" />
												</td>
												<td style="width: 140px">
													Data:<br />
													<Siar:DateTextBox ID="txtMandatoData" runat="server" Width="120px" />
												</td>
												<td style="width: 200px">
													Importo €:<br />
													<Siar:CurrencyBox ID="txtMandatoImporto" runat="server" Width="160px" />
												</td>
											</tr>
											<tr>
											    <td colspan="3">
											        Impresa:<br />
                                                    <Siar:ComboBase ID="lstBeneficiarioMandato" runat="server" NomeCampo="BeneficiarioMandato" Width="250px" ></Siar:ComboBase>
											    </td>
												<td align="right">
													<br />
													<Siar:Button ID="btnSalvaMandato" runat="server" OnClick="btnSalvaMandato_Click"
														Text="Salva dati mandato" Width="160px" Modifica="False" OnClientClick="return ctrlMandato(event);"
														Enabled="False" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td class="paragrafo">
										Dati della quietanza:
									</td>
								</tr>
								<tr>
									<td style="padding: 10px">
										<table width="100%">
											<tr>
												<td style="width: 140px">
													Data:<br />
													<Siar:DateTextBox ID="txtQuietanzaData" runat="server" Width="120px" />
												</td>
												<td style="width: 200px">
													Importo €:<br />
													<Siar:CurrencyBox ID="txtQuietanzaImporto" runat="server" Width="160px" />
												</td>
												<td align="right">
													<br />
													<Siar:Button ID="btnSalvaQuietanza" runat="server" OnClick="btnSalvaQuietanza_Click"
														Text="Salva dati quietanza" Width="160px" Modifica="False" OnClientClick="return ctrlQuietanza(event);"
														Enabled="False" />
												</td>
											</tr>
                                            <tr>
                                                <td colspan="3" align="right">
                                                    <br />
                                                    <br />
                                                    <Siar:Button ID="btnEliminaMandato" runat="server" OnClick="btnEliminaMandato_Click"
														Text="Elimina mandato" Width="160px"  Conferma="Sei sicuro di voler eliminare il mandato?"
														Enabled="False" Modifica="False"/>
                                                </td>
                                            </tr>
										</table>
									</td>
								</tr>

							</table>
						</td>
					</tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
