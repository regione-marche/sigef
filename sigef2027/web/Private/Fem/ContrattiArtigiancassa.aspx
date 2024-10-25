<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ContrattiArtigiancassa.aspx.cs" Inherits="web.Private.Fem.ContrattiArtigiancassa" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="uc4" %>
<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="ucFU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">

        function selezionaBando(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdBando]').val('');
                $('[id$=hdnIdProgetto]').val('');
                $('[id$=hdnIdContrattoFem]').val('');
            }
            else {
                $('[id$=hdnIdBando]').val(id);
                $('[id$=hdnIdProgetto]').val('');
                $('[id$=hdnIdContrattoFem]').val('');
            }

            $('[id$=btnPost]').click();
        }

        function selezionaProgetto(progetto) {
            $('[id$=hdnIdProgetto]').val(progetto);
            $('[id$=hdnIdContrattoFem]').val('');
            $('[id$=btnSelezionaProgetto]').click();

        }

        function selezionaContratto(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdContrattoFem]').val('');
            }
            else {
                $('[id$=hdnIdContrattoFem]').val(id);


            }

            $('[id$=btnPost2]').click();
        }

        function selezionaContrattoGiustificativo(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdContrattoFemGiustificativo]').val('');
            }
            else {
                $('[id$=hdnIdContrattoFemGiustificativo]').val(id);


            }

            $('[id$=btnPostGiust2]').click();
        }
        


        function AggiungiContratto() {
            $('[id$=hdnIdContrattoFem]').val('');
        }

        function AggiungiGiustificativo() {
            $('[id$=hdnIdContrattoFemGiustificativo]').val('');
        }

        function validaDatiPag(event) {
            var messaggio_errore = '';
            if($('[id$=lstPagamento]').val()=='') messaggio_errore="Indicare la tipologia del pagamento.";
            else if($('[id$=txtDataPagamento]').val()=='') messaggio_errore="Indicare la data del pagamento.";
            else if($('[id$=txtImportoLordoPagamento]').val()=='') messaggio_errore="Indicare l'importo del pagamento.";
            else if($('[id$=txtEstremi]').val()=='') messaggio_errore="Indicare gli estremi del pagamento.";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }

            var importoInserito = $('[id$=txtImportoLordoPagamento]').val().replace('.', '');
            importoInserito  = importoInserito.replace(',', '.');
            var nImportoInserito = parseFloat(importoInserito);
            var importoContratto = $('[id$=hdnTotaleContratto]').val().replace(',', '.');
            var nImportoContratto = parseFloat(importoContratto);
            var importoPaginseriti = $('[id$=hdnTotalePagamentiInseriti]').val().replace(',', '.');
            var nImportoPaginseriti = parseFloat(importoPaginseriti);
            if (nImportoContratto < (nImportoInserito + nImportoPaginseriti))
                messaggio_errore = "L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo del contratto.";
            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function validaDatiPagGiust(event) {
            var messaggio_errore = '';
            if($('[id$=lstPagamentoGiust]').val()=='') messaggio_errore="Indicare la tipologia del pagamento.";
            else if($('[id$=txtDataPagamentoGiust]').val()=='') messaggio_errore="Indicare la data del pagamento.";
            else if($('[id$=txtImportoLordoPagamentoGiust]').val()=='') messaggio_errore="Indicare l'importo del pagamento.";
            else if($('[id$=txtEstremiGiust]').val()=='') messaggio_errore="Indicare gli estremi del pagamento.";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }

            var importoInserito = $('[id$=txtImportoLordoPagamentoGiust]').val().replace('.', '');
            importoInserito  = importoInserito.replace(',', '.');
            var nImportoInserito = parseFloat(importoInserito);
            var importoContratto = $('[id$=hdnTotaleGiustificativo]').val().replace(',', '.');
            var nImportoContratto = parseFloat(importoContratto);
            var importoPaginseriti = $('[id$=hdnTotalePagamentiGiustificativiInseriti]').val().replace(',', '.');
            var nImportoPaginseriti = parseFloat(importoPaginseriti);
            if (nImportoContratto < (nImportoInserito + nImportoPaginseriti))
                messaggio_errore = "L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo del giustificativo.";
            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function validaDatiContratto(event) {
            var messaggio_errore = '';
            if($('[id$=txtDataContratto]').val()=='') messaggio_errore+="\n- Indicare la data del contratto.";
            //if($('[id$=txtNumeroContratto]').val()=='') messaggio_errore+="\n- Indicare Il numero del contratto.";
            if ($('[id$=txtNewImporto]').val() == '') messaggio_errore += "\n- Indicare l'importo del contratto.";
            
            //if($('[id$=txtDataSegnatura]').val()=='') messaggio_errore+="\n- Indicare la data della segnatura del contratto.\n";
            //if($('[id$=txtSegnatura]').val()=='') messaggio_errore+="\n- Indicare la segnatura del contratto.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }

            var importoInserito = $('[id$=txtNewImporto]').val().replace('.', '');
            importoInserito  = importoInserito.replace(',', '.');
            var nImportoInserito = parseFloat(importoInserito);
            var importoFem = $('[id$=hdnTotaleFem]').val().replace(',', '.');
            var nImportoFem = parseFloat(importoFem);
            var importoContrinseriti = $('[id$=hdnTotaleContrattiInseriti]').val().replace(',', '.');
            var nImportoContrinseriti = parseFloat(importoContrinseriti);
            if (nImportoFem < (nImportoInserito + nImportoContrinseriti))
                messaggio_errore = "L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo totale del progetto.";
            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }

        }

        function validaDatiGiustificativo(event) {
            var messaggio_errore = '';    

            if ($('[id$=lstTipoGiustificativo]').val() == '') messaggio_errore += "\n- Indicare il tipo del giustificativo.";
            if($('[id$=txtNumGiustificativo]').val()=='') messaggio_errore+="\n- Indicare il numero del giustificativo.";
            if($('[id$=txtDataGiustificativo]').val()=='') messaggio_errore+="\n- Indicare la data del giustificativo.";
            if ($('[id$=txtImportoGiustificativo]').val() == '') messaggio_errore += "\n- Indicare l'importo del giustificativo.";
            if($('[id$=txtIva]').val()=='') messaggio_errore+="\n- Indicare l'iva del giustificativo.";
            if($('[id$=txtDescGiustificativo]').val()=='') messaggio_errore+="\n- Indicare l'oggetto del giustificativo.";
            if ($('[id$=txtPivaFornitore]').val() == '') messaggio_errore += "\n- Indicare la partita iva del fornitore.";
            if (messaggio_errore != '') {
                    alert(messaggio_errore);
                    return stopEvent(event);
                }

            var cf = $('[id$=txtPivaFornitore_text]').val();
            if (cf != "" && !ctrlCodiceFiscale(cf) && !ctrlPIVA(cf)) { messaggio_errore += "Attenzione! Codice fiscale/P.Iva formalmente non corretto." }
            if (messaggio_errore != '') {
                    alert(messaggio_errore);
                    return stopEvent(event);
                }

            //var importoInserito = $('[id$=txtImportoGiustificativo]').val().replace('.', '');
            //importoInserito  = importoInserito.replace(',', '.');
            //var nImportoInserito = parseFloat(importoInserito);
            //var importoFem = $('[id$=hdnTotaleFem]').val().replace(',', '.');
            //var nImportoFem = parseFloat(importoFem);
            //var importoContrinseriti = $('[id$=hdnTotaleGiustificativiInseriti]').val().replace(',', '.');
            //var nImportoContrinseriti = parseFloat(importoContrinseriti);
            //if (nImportoFem < (nImportoInserito + nImportoContrinseriti))
            //    messaggio_errore = "L'importo inserito o la somma degli importi inseriti sono maggiori dell'importo totale del progetto.";
            //if (messaggio_errore != '') {
            //    alert(messaggio_errore);
            //    return stopEvent(event);
            //}
        }

        function changeTipoContratto() {
            var radiovalue = $('[id$=rblTipoContratto]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=tableContratto]').hide();
                $('[id$=tableGiustificativo]').show();
            }
            else {
                $('[id$=tableContratto]').show();
                $('[id$=tableGiustificativo]').hide();
            }
        }

        //function readyFn(jQuery) {
        //    $('[id$=rblTipoContratto]').change(changeTipoContratto);
        //    $('[id$=rblTipoContratto]').change();
        //}

        //function pageLoad() {
        //    readyFn();
        //}

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraGiustificativi]');
                    img = $('[id$=imgGiustificativi]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraContratti]');
                    img = $('[id$=imgContratti]')[0];
                    break;
                
            }

            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            //if (div.style.display === "none") {
            //    div.style.display = "block";
            //} else {
            //    div.style.display = "none";
            //}
            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

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

    <div style="display: none">
        <asp:HiddenField ID="hdnIdBando" runat="server" />     
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdContrattoFem" runat="server" />
        <asp:HiddenField ID="hdnIdContrattoFemGiustificativo" runat="server" />
        
        <asp:HiddenField ID="hdnTotaleFem" runat="server" />
        <asp:HiddenField ID="hdnTotaleContrattiInseriti" runat="server" />
        <asp:HiddenField ID="hdnTotaleGiustificativiInseriti" runat="server" />

        <asp:HiddenField ID="hdnTotalePagamentiInseriti" runat="server" />
        <asp:HiddenField ID="hdnTotalePagamentiGiustificativiInseriti" runat="server" />

        <asp:HiddenField ID="hdnTotaleContratto" runat="server" />
        <asp:HiddenField ID="hdnTotaleGiustificativo" runat="server" />
        

        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnPost2" runat="server" OnClick="btnPost2_Click" />
        <asp:Button ID="btnPostGiust2" runat="server" OnClick="btnPostGiust2_Click" />
        <asp:Button ID="btnSelezionaProgetto" runat="server" OnClick="btnSelezionaProgetto_Click" />
    </div>

    <div style="text-align:center">
        <h1>Fondo Energia</h1>
    </div>
    <div class="dBox" id="div1"  runat="server">
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
            Report 
        </div>
        <div style="padding:25px">
            <input type="button" class="Button" id="btnStampa" runat="server" value="Esporta in XLS"
                  style="width: 155px; margin-left: 20px" />
        </div>
    </div>
    <div class="dBox" id="divGiustificativi"  runat="server">
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
            <img id="imgGiustificativi" runat="server" style="width: 23px; height: 23px;" />
            Inserimento Giustificativi di Spese di Gestione Artigiancassa:
        </div>
        <div  id="divMostraGiustificativi" style="padding:25px">
            <table Width="100%">
                <tr>
                    <td>
                        <Siar:DataGrid ID="dgContrattiFemGiustificativi" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                            AutoGenerateColumns="False" ShowFooter="true">
                            <ItemStyle Height="28px" />
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <asp:BoundColumn DataField="IdContrattoFem" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Numero" HeaderText="Numero Giustificativo">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataStipulaContratto" HeaderText="Data Giustificativo">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="File">
                                    <ItemStyle HorizontalAlign="center" Width="40px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo Pagamenti" HeaderStyle-HorizontalAlign="Right">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                </asp:BoundColumn>
                                <Siar:CheckColumn DataField="IdContrattoFem" Name="chkIdContrattoFem">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </Siar:CheckColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </td>
                </tr>

            </table>
            <br />
            <br />
            <Siar:Button Text="Aggiungi Giustificativo"  runat="server" ID="Button1" OnClientClick="AggiungiGiustificativo();"
                OnClick="btnAggiungiGiustificativo_Click" Width="200px" />
            <br />
            <br />
            <div id="divNuovoGiustificativo" visible="false" runat="server">
<%--                                                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoContratto" runat="server">
                    <asp:ListItem Selected="True" Text="Contratto" Value="0" />
                    <asp:ListItem Text="Giustificativo" Value="1" />
                </asp:RadioButtonList>--%>
                <br />
                <table id="tableGiustificativo" runat="server" >
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>Tipo giustificativo:<br />
                                        <Siar:ComboSql ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                                            DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo giustificativo"
                                            Width="280px">
                                        </Siar:ComboSql>
                                    </td>
                                    <td style="height: 25px; font-size: 13px; font-style: italic;" align="right"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 140px">Numero:<br />
                                        <Siar:TextBox  ID="txtNumGiustificativo" runat="server" Width="120px" MaxLength="30" />
                                    </td>
                                    <td style="width: 140px">Data:<br />
                                        <Siar:DateTextBox ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo"
                                            Width="100px" />
                                    </td>
                                    <%-- campi DAS oscurati perchè non utilizzati --%>
                                    <td style="width: 140px"><%--Numero DAS:--%><br />
                                        <Siar:TextBox  ID="txtNumDocTrasporto" runat="server" Width="120px" MaxLength="30" Visible="false" />
                                    </td>
                                    <td><%--Data DAS:--%><br />
                                        <Siar:DateTextBox ID="txtDataDocTrasporto" runat="server" Width="100px" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 130px">Imponibile €:<br />
                                        <Siar:CurrencyBox ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo"
                                            Width="110px" />
                                    </td>
                                    <td style="width: 90px">Iva %:<br />
                                        <Siar:QuotaBox ID="txtIva" runat="server" NomeCampo="Iva" Width="70px" />
                                    </td>
                                    <td>
                                        <br />
                                        <asp:CheckBox ID="chkNonRecuperabile" runat="server" Text="Iva non recuperabile" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>Oggetto della spesa:<br />
                            <Siar:TextArea ID="txtDescGiustificativo" runat="server" NomeCampo="Oggetto della spesa"
                                Width="578px" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 235px">
                                        <br />
                                        Fornitore (P.Iva):<br />
                                        <Siar:TextBox  ID="txtPivaFornitore" runat="server" Width="190px" NomeCampo="Partita iva del fornitore"
                                                MaxLength="16" />
                                    </td>
                                    <td>
                                        <br />
                                        <br />
                                        <%--<Siar:Button ID="btnScaricaFornitore" runat="server" CausesValidation="false" Modifica="True"
                                            OnClick="btnScaricaFornitore_Click" Text="Cerca" Width="120px" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>Ragione sociale:<br />
                            <Siar:TextBox  ID="txtRSFornitore" runat="server" Width="576px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            Specificare il file digitale relativo al giustificativo:<br />
                            <uc4:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="DocumentoFE"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <Siar:Button ID="btnSalvaGiustificativo" runat="server" OnClick="btnSalvaGiustificativo_Click"
                                Text="Salva dati" Width="160px" OnClientClick="return validaDatiGiustificativo(event);" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table visible="false" id="tbGiustificativiFemPagamento" runat="server" Width="100%">
                    <tr>
						<td class="paragrafo">
							Dati dei pagamenti:
						</td>
					</tr>
                    <tr>
                        <td>
                            <Siar:DataGrid ID="dgGiustificativoFemPagamenti" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                                AutoGenerateColumns="False" ShowFooter="true">
                                <ItemStyle Height="28px" />
                                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                <Columns>
                                    <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CodTipo" HeaderText="Tipo">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Estremi" DataField="Estremi" >
                                        <ItemStyle HorizontalAlign="Right" Width="300px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="File" >
                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo" >
                                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br /><br />
                            <Siar:Button Text="Aggiungi Pagamento"  runat="server" ID="btnAggiungiPagamentoGiustificativo" 
                                OnClick="btnAggiungiPagamentoGiustificativo_Click" Width="200px" />
                            <br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table  visible="false" id="tbNuovoPagamentoGiustificativo" runat="server">
                                <tr>
                                    <td style="padding: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    Tipo pagamento:<br />
                                                    <Siar:ComboSql ID="lstPagamentoGiust" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                                                        DataTextField="DESCRIZIONE" DataValueField="COD_TIPO"  NomeCampo="Tipo pagamento">
                                                    </Siar:ComboSql>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 120px">
                                                                Data:<br />
                                                                <Siar:DateTextBox ID="txtDataPagamentoGiust" runat="server" NomeCampo="Data pagamento"
                                                                        Width="90px" />
                                                            </td>
                                                            <td style="width: 140px">
                                                                Importo €:<br />
                                                                <Siar:CurrencyBox ID="txtImportoLordoPagamentoGiust" runat="server" NomeCampo="Importo lordo del pagamento"
                                                                    Width="110px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Estremi:<br />
                                                    <Siar:TextBox  ID="txtEstremiGiust" runat="server" Width="488px" NomeCampo="Estremi del pagamento"
                                                            />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <br />
                                                    Specificare il file digitale relativo al pagamento:<br />
                                                    <uc4:SNCUploadFileControl ID="ufPagamentoGiust" runat="server" TipoFile="Documento" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
									<td></td>
                                    <td></td>
                                    <td></td>
									<td align="right">
										<br />
										<Siar:Button ID="btnSalvaPagamentoGiustificativo" runat="server" OnClick="btnSalvaPagamentoGiustificativo_Click"
											Text="Salva dati" Width="160px"  OnClientClick="return validaDatiPagGiust(event);" />
									</td>      
								</tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="dBox" id="divContratti"  runat="server">
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(1); return false;">
            <img id="imgContratti" runat="server" style="width: 23px; height: 23px;" />
            Inserimento Contratti Artigiancassa:
        </div>
        <div  id="divMostraContratti" style="padding:25px">
            <table width="100%">
                <tr>
                    <td>
                        <table Width="100%">
                            <tr>
                                <td>
                                    <br />
                                    <Siar:DataGrid ID="dgBando" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        PageSize="15" Width="100%" ShowFooter="false">
                                        <ItemStyle Height="28px" />
                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:BoundColumn DataField="IdBando" HeaderText="ID Bando">
                                                <ItemStyle Font-Bold="True" Font-Size="Small" HorizontalAlign="Center" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Descrizione" HeaderText="Bando">
                                                <ItemStyle  Width="200px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Totale Contratti" HeaderStyle-HorizontalAlign="center">
                                                <ItemStyle HorizontalAlign="center" Width="50px" />
                                            </asp:BoundColumn>
                                            <%--<asp:BoundColumn HeaderText="Totale contratti" HeaderStyle-HorizontalAlign="center">
                                                <ItemStyle HorizontalAlign="center" Width="50px" />
                                            </asp:BoundColumn>--%>
                                            <asp:BoundColumn HeaderText="Importo FEM" HeaderStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Importo Contratti" HeaderStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Importo Pagamenti" HeaderStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </asp:BoundColumn>
                                            <Siar:CheckColumn DataField="IdBando" Name="chkIdDomandaPagamento">
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                            </Siar:CheckColumn>
                                        </Columns>
                                    </Siar:DataGrid>
                                    <br />
                                    <br />
                                </td>
                            </tr>  
                        </table>
                        <table id="tbProgetti" runat="server"  width="100%">
                            <tr>
                                <td class="separatore">
                                    Elenco dei progetti:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                
                                        <tr >
                                            <td  style="padding-left:10px;padding-top:10px" >  
						                            Nr. Domanda:<br /> 
						                            <Siar:TextBox   ID="txtProgettoFiltra" runat="server" Width="120px"/>
								            </td> 
								            <td style="padding-left:30px;padding-top:20px">
								            <Siar:Button ID="btnFiltra" runat="server" CausesValidation="False" OnClick="btnFiltra_Click"
                                                 Text="Filtra" Width="140px" />
                                            </td>   
                                        </tr>
                                    </table>
                                </td>    
                            </tr>
                            <tr>
                                <td>
                        
                                    <Siar:DataGrid ID="dgProgetti" runat="server" Width="100%" PageSize="20" AllowPaging="False"
                                        AutoGenerateColumns="False">
                                        <ItemStyle Height="28px" />
                                        <Columns>
                                            <Siar:ColonnaLink HeaderText="ID Progetto" DataField="IdProgetto" LinkFields="IdProgetto"
                                              ItemStyle-Width = "20px" ItemStyle-HorizontalAlign="Center"  LinkFormat="selezionaProgetto({0});" IsJavascript="true">
                                            </Siar:ColonnaLink>
                                            <asp:BoundColumn DataField="Stato" HeaderText="Stato">
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Impresa">  
                                                <ItemStyle Width="200px" />                   
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Importo FEM" HeaderStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Importo Contratti" HeaderStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Importo Pagamenti" HeaderStyle-HorizontalAlign="Right">
                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGrid>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="tbContratto" runat="server" width="100%"> 
                                        <tr>
									        <td class="paragrafo">
										        Dati del contatto:
									        </td>
								        </tr>
								        <tr>   
								            <td>
                                                <table>
                                                    <tr>
                                                        <td style="width: 140px">  
								                            Nr. Domanda:<br /> 
								                            <Siar:TextBox  ReadOnly="true" ID="txtIdProgetto" runat="server" Width="120px"/>
								                        </td>
                                                        <td style="width: 180px">
										                    Totale Contributo €:<br />
										                    <Siar:CurrencyBox ReadOnly="true" ID="txtImporto" runat="server" Width="160px" />
									                    </td>
                                                        <td style="width: 250px">
										                    Ragione Sociale:<br />
										                    <Siar:TextBox  ReadOnly="true" ID="txtRagioneSociale" runat="server" Width="500px"/>
									                    </td>  
                                                    </tr>
                                                </table>
                                                <table Width="100%">
                                                    <tr>
                                                        <td>
                                                            <Siar:DataGrid ID="dgContrattiFem" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                                                                AutoGenerateColumns="False" ShowFooter="true">
                                                                <ItemStyle Height="28px" />
                                                                 <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="IdContrattoFem" HeaderText="ID">
                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Numero" HeaderText="Numero Contratto">
                                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="DataStipulaContratto" HeaderText="Data Contratto">
                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn HeaderText="File">
                                                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                                                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn HeaderText="Importo Pagamenti" HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                                    </asp:BoundColumn>
                                                                    <Siar:CheckColumn DataField="IdContrattoFem" Name="chkIdContrattoFem">
                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    </Siar:CheckColumn>
                                                                </Columns>
                                                            </Siar:DataGrid>
                                                        </td>
                                                    </tr>

                                                </table>
                                                <br />
                                                <br />
                                                <Siar:Button Text="Aggiungi Contratto"  runat="server" ID="btnAggiungi" OnClientClick="AggiungiContratto();"
                                                    OnClick="btnAggiungi_Click" Width="200px" />
                                                <br />
                                                <br />
                                                <div id="divNuovoContratto" visible="false" runat="server">
<%--                                                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoContratto" runat="server">
                                                        <asp:ListItem Selected="True" Text="Contratto" Value="0" />
                                                        <asp:ListItem Text="Giustificativo" Value="1" />
                                                    </asp:RadioButtonList>--%>
                                                    <br />

								                    <table id="tableContratto" runat="server">
                                                        <tr>
                                                            <td>
                                                                <br />
                                                            </td>
                                                        </tr>
								                        <tr>
                                                            <td style="width: 180px">
                                                                Numero contratto:<br />
                                                                <Siar:TextBox  ID="txtNumeroContratto" runat="server" Width="120px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px">
										                        Data Stipula Contratto:<br />
										                        <Siar:DateTextBox ID="txtDataContratto" runat="server" Width="120px" />
									                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px">
										                        Importo FEM €:<br />
										                        <Siar:CurrencyBox  ID="txtNewImporto" runat="server" Width="160px" />
									                        </td>
                                                        </tr>
                                                        <tr>
									                        <td style="width: 180px">
                                                                File del contratto:<br />
                                                                <uc4:SNCUploadFileControl ID="ufContratto" runat="server" TipoFile="Documento" />
									                        </td>
								                        </tr>
								                        <tr>
									                        <td><%--<td align="right">--%>
										                        <br />
										                        <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click"
											                        Text="Salva dati" Width="160px" OnClientClick="return validaDatiContratto(event);" />
									                        </td>      
								                        </tr>
								                        <tr>
								                            <td>
								                                <br />
								                            </td>
								                        </tr>
								                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <table visible="false" id="tbContrattiFemPagamento" runat="server" Width="100%">
                                                    <tr>
									                    <td class="paragrafo">
										                    Dati dei pagamenti:
									                    </td>
								                    </tr>
                                                    <tr>
                                                        <td>
                                                            <Siar:DataGrid ID="dgContrattiFemPagamenti" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                                                                AutoGenerateColumns="False" ShowFooter="true">
                                                                <ItemStyle Height="28px" />
                                                                 <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                                <Columns>
                                                                    <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="CodTipo" HeaderText="Tipo">
                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn HeaderText="Estremi" DataField="Estremi" >
                                                                        <ItemStyle HorizontalAlign="Right" Width="300px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn HeaderText="File" >
                                                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                                                    </asp:BoundColumn>
                                                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo" >
                                                                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                                    </asp:BoundColumn>
                                                                </Columns>
                                                            </Siar:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <br /><br />
                                                            <Siar:Button Text="Aggiungi Pagamento"  runat="server" ID="btnAggiungiPagamento" 
                                                                OnClick="btnAggiungiPagamento_Click" Width="200px" />
                                                            <br /><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table  visible="false" id="tbNuovoPagamento" runat="server">
                                                                <tr>
                                                                    <td style="padding: 10px">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    Tipo pagamento:<br />
                                                                                    <Siar:ComboSql ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                                                                                        DataTextField="DESCRIZIONE" DataValueField="COD_TIPO"  NomeCampo="Tipo pagamento">
                                                                                    </Siar:ComboSql>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td style="width: 120px">
                                                                                                Data:<br />
                                                                                                <Siar:DateTextBox ID="txtDataPagamento" runat="server" NomeCampo="Data pagamento"
                                                                                                     Width="90px" />
                                                                                            </td>
                                                                                            <td style="width: 140px">
                                                                                                Importo €:<br />
                                                                                                <Siar:CurrencyBox ID="txtImportoLordoPagamento" runat="server" NomeCampo="Importo lordo del pagamento"
                                                                                                    Width="110px" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Estremi:<br />
                                                                                    <Siar:TextBox  ID="txtEstremi" runat="server" Width="488px" NomeCampo="Estremi del pagamento"
                                                                                         />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <br />
                                                                                    Specificare il file digitale relativo al pagamento:<br />
                                                                                    <uc4:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
									                                <td></td>
                                                                    <td></td>
                                                                    <td></td>
									                                <td align="right">
										                                <br />
										                                <Siar:Button ID="btnSalvaPagamento" runat="server" OnClick="btnSalvaPagamento_Click"
											                                Text="Salva dati" Width="160px"  OnClientClick="return validaDatiPag(event);" />
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
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
