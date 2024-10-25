<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RendicontazioneFem.aspx.cs" Inherits="web.Private.Fem.RendicontazioneFem" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
         function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraRendicontazione]');
                    img = $('[id$=imgRendicontazione]')[0];
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

            if (div[0].style.display === "none") {
                div.show("fast");
            } else {
                div.hide("fast");
            }
        }

        function selezionaBando(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdBando]').val('');

            }
            else {
                $('[id$=hdnIdBando]').val(id);
            }
            $('[id$=hdnIdProgetto]').val('');
            $('[id$=hdnIdErogazione]').val('');
            $('[id$=hdnIdErogazioneXDecreti]').val('');
            $('[id$=hdnIdLiquidazione]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaProgetto(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdProgetto]').val('');
                }
            else {
                $('[id$=hdnIdProgetto]').val(id);
                }
            $('[id$=hdnIdErogazione]').val('');
            $('[id$=hdnIdErogazioneXDecreti]').val('');
            $('[id$=hdnIdLiquidazione]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaErogazione(erogazione)
        {
            $('[id$=hdnIdErogazione]').val(erogazione);
            $('[id$=hdnIdErogazioneXDecreti]').val('');
            $('[id$=hdnIdLiquidazione]').val('');

            $('[id$=btnPostNull]').click();

        }

        function selezionaDecretoPag(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdErogazioneXDecreti]').val('');
                $('[id$=hdnIdLiquidazione]').val('');

            }
            else {
                $('[id$=hdnIdErogazioneXDecreti]').val(id);
                $('[id$=hdnIdLiquidazione]').val('');
            }
            $('[id$=btnPostNull]').click();
        }

        function selezionaMandato(mandato) {
            $('[id$=hdnIdLiquidazione]').val(mandato);
            $('[id$=btnPostNull]').click();
        }

        
        function validaCreaErogazione(event) {
            var messaggio_errore = '';
            if ($('[id$=txtSogliaContributi]').val() == '') messaggio_errore = "Indicare la soglia € da raggiungere per poter chiudere l'erogazione.";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function ctrlMandato(ev) { if ($('[id$=txtMandatoData_text]').val() == "" || $('[id$=txtMandatoImporto_text]').val() == "" || $('[id$=txtMandatoNumero_text]').val() == "" || $('[id$=ufMandato_hdnSNCUFUploadFile]').val() == "") { alert('Per proseguire è necessario specificare numero, data, importo e file digitale del mandato.'); return stopEvent(ev); } }
        function ctrlQuietanza(ev) {
            if ($('[id$=txtMandatoData_text]').val() == "" || $('[id$=txtMandatoImporto_text]').val() == "" || $('[id$=txtMandatoNumero_text]').val() == "" || $('[id$=ufMandato_hdnSNCUFUploadFile]').val() == "")
            {
                alert('Per proseguire è necessario specificare numero, data, importo e file digitale del mandato.');
                return stopEvent(ev);
            }

            if ($('[id$=txtQuietanzaData_text]').val() == "" || $('[id$=txtQuietanzaImporto_text]').val() == "")
            {
                alert('Per proseguire è necessario specificare data e importo della quietanza di pagamento.');
                return stopEvent(ev);
            }
        }


        function chiudiPopup() { chiudiPopupTemplate(); }

        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtNumeroDecreto_text]').val() == "" || $('[id$=txtDataDecreto_text]').val() == "" || $('[id$=lstRegistro]').val() == "") { alert('Per la ricerca dei decreti è necessario digitare sia numero che data che registro dell`atto.'); return stopEvent(ev); } }
        function selezionaDecreto(obj) { $('[id$=hdnDecretoJson]').val(sjsConvertiOggettoToJsonString(obj)); $('[id$=btnPostNull]').click(); }

        
        function validaImportoDecreto(event) {
            var messaggio_errore = '';
            if ($('[id$=txtImportoDecreto]').val() == '') messaggio_errore += "Indicare l'importo del decreto.\n";
            if ($('[id$=txtImportoDecretoAmmesso]').val() == '') messaggio_errore += "Indicare l'importo ammesso del decreto.\n";

            if (messaggio_errore != '') {
                alert(messaggio_errore);
                return stopEvent(event);
            }
        }

        function sommaPagamentiSelezionati() {
            var tblGrid = $('[id$=dgPagamentiDaIstruire]')[0];
            var tot = 0.00;

            var rows = tblGrid.rows;
            var i = 0, row, cell, count = 0;
            for (i = 2; i < rows.length - 1; i++) {
                row = rows[i];
                var found = false;
                var dgImportoAmmesso = row.cells[12].firstChild.value;
                var dgSelezionato = row.cells[13].firstChild.firstChild;
                
                if (dgSelezionato.checked) {
                    dgImportoAmmesso = dgImportoAmmesso.replace(/\./g, '');
                    dgImportoAmmesso = dgImportoAmmesso.replace(',', '.');
                    tot += parseFloat(dgImportoAmmesso);
                }
            }

            var a = $('[id$=TotImportoAmmessiPrecedenti]').val();
            a = a.replace(/\./g, '');
            a = a.replace(',', '.');
            a = parseFloat(a) + parseFloat(tot);
            $('[id$=TotImportoAmmesso]').val(FromNumberToCurrency(tot));
            $('[id$=TotPagamentiAmmessi]').val(FromNumberToCurrency(a));
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
        <asp:HiddenField ID="hdnIdErogazione" runat="server" />
        <asp:HiddenField ID="hdnIdErogazioneXDecreti" runat="server" />
        <asp:HiddenField ID="hdnIdLiquidazione" runat="server" />
        
        <asp:HiddenField ID="hdnDecretoJson" runat="server" />

        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnPostNull" runat="server" OnClick="btnPostNull_click" />
    </div>
    <div style="text-align:center">
        <h1>Rendicontazione spesa</h1>
    </div>
    <div class="dBox" id="divRendicontazione"  runat="server">
        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
            <img id="imgRendicontazione" runat="server" style="width: 23px; height: 23px;" />
        </div>
        <div  style="padding:25px"  id="divMostraRendicontazione">
            <table width="100%">
                <tr>
                    <td>
                        <Siar:DataGrid ID="dgBandi" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                            AutoGenerateColumns="False" ShowFooter="false">
                            <ItemStyle Height="28px" />
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <asp:BoundColumn DataField="IdBando" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Descrizione" HeaderText="Oggetto">
                                    <ItemStyle HorizontalAlign="left" Width="500px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Nominativo" HeaderText="RUP">
                                    <ItemStyle HorizontalAlign="left" Width="100px" />
                                </asp:BoundColumn>
                                <Siar:CheckColumn DataField="IdBando" Name="chkIdBando">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </Siar:CheckColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td >
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" runat="server" id="tbProgetti" visible="false"> 
                            <tr>
                                <td class="paragrafo">
                                    Seleziona il progetto:
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <Siar:DataGrid ID="dgProgetti" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                                        AutoGenerateColumns="False" ShowFooter="false">
                                        <ItemStyle Height="28px" />
                                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:BoundColumn DataField="IdProgetto" HeaderText="ID Progetto">
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn  HeaderText="Ragione Sociale">
                                                <ItemStyle HorizontalAlign="left" Width="500px" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn  HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                            </asp:BoundColumn>
                                            <Siar:CheckColumn DataField="IdProgetto" Name="chkIdProgetto">
                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                            </Siar:CheckColumn>
                                        </Columns>
                                    </Siar:DataGrid>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div>
                <br />
            </div>
            <table width="100%" runat="server" id="tbErogazioni" visible="false"> 
                <tr>
                    <td>
                        <input type="button" class="Button" id="btnStampa" runat="server" value="Esporta in XLS"
                                            style="width: 155px; margin-left: 20px" />
                    </td>
                </tr>
                <tr>
                    <td >
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="paragrafo">
                        Erogazioni:
                    </td>
                </tr>
                <tr>
                    <td>
                        <Siar:DataGrid ID="dgErogazioni" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                            AutoGenerateColumns="False" ShowFooter="true">
                            <ItemStyle Height="28px" />
                                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                            <Columns>
                                <Siar:ColonnaLink HeaderText="ID" DataField="IdErogazione" LinkFields="IdErogazione"
                                    ItemStyle-Width = "20px" ItemStyle-HorizontalAlign="Center"  LinkFormat="selezionaErogazione({0});" IsJavascript="true">
                                </Siar:ColonnaLink>
                                <asp:BoundColumn DataField="Numero" HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SogliaContributi" HeaderText="Soglie contributi da erogare" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaContratti" HeaderText="Contratti" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaPagamenti" HeaderText="Pagamenti" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaPagamentiAmmessi" HeaderText="Pagamenti Ammessi" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaDecreti" HeaderText="Importo Decreti" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaDecretiAmmessi" HeaderText="Importo Decreti Ammessi" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaMandati" HeaderText="Mandati" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SommaQuietanza" HeaderText="Quietanza" HeaderStyle-HorizontalAlign="Right" >
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn  HeaderText="Definitiva" >
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn  >
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn  DataField="IdDomandaPagamento" HeaderText="ID Domanda Pagamento" >
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Data certificazione">
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </td>
                </tr>
                <tr runat="server" visible="false" id="trNuovaErogazione"> 
                    <td>
                       <table>
                           <tr>
                               <td style="width: 250px">
						            Soglia contributi da raggiungere per l'erogazione:<br />
                                   (Se anticipo inserire 0 )<br />
						            <Siar:CurrencyBox  ID="txtSogliaContributi" runat="server" Width="260px" />
                                   <br />
					            </td>
                            </tr>
                           <tr>
                               <td >
                                   <br />
						            <Siar:Button ID="btnCreaErogazione" runat="server" OnClick="btnCreaErogazione_Click"
											Text="Inizia nuova erogazione" Width="250px" OnClientClick="return validaCreaErogazione(event);" />
					            </td>
                            </tr>
                       </table>
                    </td>
                </tr>
                <tr>
                    <td runat="server" visible="false" id="trErogazioneSelezionata">
                        <table>
                            <tr>
                                <td colspan ="4" class="paragrafo">
                                    Riassunto Erogazione selezionata
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 250px">
                                    Numero Erogazione:<br />
                                    <Siar:TextBox  ReadOnly="true" ID="txtNumeroErogazione" runat="server"  Width="50px" />
                                </td>
                                <td style="width: 250px">
                                </td>
                                <td style="width: 250px">
                                </td>
                                <td style="width: 250px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 250px">
                                    Soglia contributi da raggiungere:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSogliaContributiErog" runat="server" Width="260px" />
                                </td>
                                <td style="width: 250px">
                                    Somma dei contratti:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaContrattiErog" runat="server" Width="260px" />
                                </td>
                                <td style="width: 250px">
                                    Somma Pagamenti:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaPagamentiErog" runat="server" Width="260px" />
                                </td>
                                <td style="width: 250px">
                                    Somma Pagamenti ammessi:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaPagamentiAmmessiErog" runat="server" Width="260px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 250px">
                                    Somma Decreti:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaDecretiErog" runat="server" Width="260px" />
                                </td>
                                <td style="width: 250px">
                                    Somma Decreti ammessi:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaDecretiAmmErog" runat="server" Width="260px" />
                                </td>
                                <td style="width: 250px">
                                    Somma Mandati:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaMandati" runat="server" Width="260px" />
                                </td>
                                <td style="width: 250px">
                                    Somma Quietanza:<br />
                                    <Siar:CurrencyBox  ReadOnly="true" ID="txtSommaQuietanza" runat="server" Width="260px" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp</td>
                            </tr>
                            <tr id="trButtonConcludi" runat="server">
                                <td align="center" colspan ="4">
                                    <Siar:Button ID="btnConcludi" runat="server" OnClick="btnConcludi_Click" 
											Text="Concludi EROGAZIONE" Width="250px" Conferma="Sei sicuro di voler concludere l'erogazione selezionata? Non sarà piu possibile modificarla."  />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" Width="100%" TabNames="Pagamenti|Decreti e Mandati" />
                        <table class="tableTab" width="100%" id="tbpagamenti" runat="server">
                            <tr runat="server" visible="false" id="trPagamentiDaIstruire"> 
                                <td>
                                    <table>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td class="paragrafo" colspan="2">
                                                Elenco dei pagamenti ricevuti da associare all'erogazione
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td align="left" rowspan="4">
                                                In elenco tutti i pagamenti dei contratti e dei giustificativi di spesa ricevuti, cliccando sul pulsante "Salva Pagamenti Ammessi", 
                                                si possono salvare gli importi ammessi di tutti i pagamenti debitamente istruiti.
                                                <br />LEGGENDA: 
                                                <br />(A) Totale dei pagamenti ammessi nelle precedenti  erogazioni.
                                                <br />(B) Totale dei pagamenti selezionati che si stanno istruendo.
                                                <br /><br />Con il pulsante "Associa decreto" si associano i pagamenti selezionati col il check in fondo ad ogni riga alla erogazione attuale.
                                                Successivamente all'associazione del decreto è possibile inserire i mandati di pagamento e/o altri decreti, ma non sarà possibile selezionare altri pagamenti dalla lista.
                                                Dopo essere sicuri di aver inserito tutti i decreti con i loro relativi mandati è possibile chiudere l'erogazione con l'apposito pulsante e si potra procedere alla validazione e/o alla apertura di una nuova erogazione.                                
                                                Nel caso si stia lavorando sulla prima erogazione al fondo sarà possibile associare i decreti senza avere selezionato nessun pagamento.
                                            </td>
                                            <td align="right">
                                                <b>Tot. Pagamenti Ammessi precedenti (A)</b>
                                                <Siar:CurrencyBox ID="TotImportoAmmessiPrecedenti" runat="server" ReadOnly="true" Width="150px" />
                                            </td>
                                        </tr>
                                        <tr>
                                
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                
                                            <td align="right" >
                                                <b>Tot. Pagamenti Ammessi selezionati (B)</b>
                                                <Siar:CurrencyBox ID="TotImportoAmmesso" runat="server" ReadOnly="true" Width="150px" />
                                            </td>
                                        </tr>
                                        <tr>
                                
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                            <td align="right">
                                                <b>A + B =</b>
                                                <Siar:CurrencyBox ID="TotPagamentiAmmessi" runat="server" ReadOnly="true" Width="150px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <Siar:Button ID="btnAssociaDecreto" runat="server" OnClick="btnAssociaDecreto_Click"
                                                    Text="Associa Decreto" Width="250px" />
                                            </td>
                                            <td align="right" >
                                               <Siar:Button ID="btnSalvaPagAmmessi" runat="server" OnClick="btnSalvaPagAmmessi_Click"
											            Text="Salva Pagamenti Ammessi" Width="250px"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <Siar:DataGrid ID="dgPagamentiDaIstruire" runat="server" Width="100%"  AllowPaging="false"
                                                    AutoGenerateColumns="False" ShowFooter="true" >
                                                    <ItemStyle Height="28px" />
                                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="IdContrattoFem" HeaderText="ID">
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Tipo" >
                                                            <ItemStyle HorizontalAlign="left" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Numero Contratto/Giustificativo">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Data Contratto/Giustificativo">
                                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="File" >
                                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TipoPagamento" HeaderText="Tipo">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
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
                                                        <asp:BoundColumn DataField="Importo"  HeaderStyle-HorizontalAlign="Right" HeaderText="Importo" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <Siar:ImportoColumn DataField="IdContrattoFemPagamenti" HeaderText="Importo Ammesso" HeaderStyle-HorizontalAlign="Right" Name="txtImportoAmmesso">
                                                            <ItemStyle HorizontalAlign="center" Width="140px" />
                                                        </Siar:ImportoColumn>
                                            
                                                    <Siar:CheckColumn DataField="IdContrattoFemPagamenti" Name="chkQuadro" HeaderSelectAll="true" OnHeaderCheckClick="sommaPagamentiSelezionati();">
                                                            <ItemStyle Width="50px" HorizontalAlign="center" />
                                                        </Siar:CheckColumn>
                                                    </Columns>
                                                </Siar:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trPagamentiIstruiti" Width="100%"  visible="false" runat ="server">
                                <td>
                                    <table Width="100%">
                                        <tr>
                                            <td class="paragrafo" colspan="2">
                                                Elenco dei pagamenti associati all'erogazione selezionata:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <Siar:DataGrid ID="dgPagamentiErogazione" runat="server" Width="100%"  AllowPaging="false" PageSize="100"
                                                    AutoGenerateColumns="False" ShowFooter="true" >
                                                    <ItemStyle Height="28px" />
                                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="IdContrattoFem" HeaderText="ID">
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Tipo" >
                                                            <ItemStyle HorizontalAlign="left" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Numero Contratto/Giustificativo">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Data Contratto/Giustificativo">
                                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="File" >
                                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TipoPagamento" HeaderText="Tipo">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
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
                                                        <asp:BoundColumn DataField="Importo"  HeaderStyle-HorizontalAlign="Right" HeaderText="Importo" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ImportoAmmesso"  HeaderStyle-HorizontalAlign="Right" HeaderText="Importo Ammesso" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                    </Columns>
                                                </Siar:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <br /><br />
                                </td>
                            </tr>
                            <tr id="trPagamentiIstruitiPrec" Width="100%"  visible="false" runat ="server">
                                <td>
                                    <table Width="100%">
                                        <tr>
                                            <td class="paragrafo" colspan="2">
                                                Elenco dei pagamenti associati alle erogazione precedenti:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <Siar:DataGrid ID="dgPagamentiErogazionePrec" runat="server" Width="100%"  AllowPaging="false" PageSize="100"
                                                    AutoGenerateColumns="False" ShowFooter="true" >
                                                    <ItemStyle Height="28px" />
                                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="IdContrattoFem" HeaderText="ID">
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="Tipo" >
                                                            <ItemStyle HorizontalAlign="left" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Numero Contratto/Giustificativo">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Data Contratto/Giustificativo">
                                                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Importo" HeaderStyle-HorizontalAlign="Right" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn HeaderText="File" >
                                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TipoPagamento" HeaderText="Tipo">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
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
                                                        <asp:BoundColumn DataField="Importo"  HeaderStyle-HorizontalAlign="Right" HeaderText="Importo" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ImportoAmmesso"  HeaderStyle-HorizontalAlign="Right" HeaderText="Importo Ammesso" >
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>
                                                    </Columns>
                                                </Siar:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </table>
                        <table class="tableTab" width="100%" id="tbDecreti" runat="server">
                            <tr  id="trDecreti"  visible="false" runat ="server">
                                <td>
                                    <table width ="100%">
                                         <tr>
                                            <td class="paragrafo" colspan="2">
                                                Elenco dei decreti associati all'erogazione:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  colspan="2">
                                                Selezionare un decreto dall'elenco per poter agganciarci il mandato e la quietanza relativa
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <Siar:DataGrid ID="dgDecretiPag" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    PageSize="15" Width="100%" ShowFooter="true">
                                                    <ItemStyle Height="28px" />
                                                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                                    <Columns>
                                                        <asp:BoundColumn  HeaderText="Decreto">
                                                            <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Descrizione">
                                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Tipo">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Definizione">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn  HeaderText="Organo">
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:BoundColumn>     
                                                        <asp:BoundColumn  HeaderText="Importo">
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn>         
                                                        <asp:BoundColumn  HeaderText="Importo Ammesso">
                                                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                        </asp:BoundColumn> 
                                                        <Siar:CheckColumn DataField="IdErogazioneXDecreti" Name="chkIdErogazioneXDecreti">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                        </Siar:CheckColumn>
                                                    </Columns>
                                                </Siar:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 10px">
					                            <br />
							                    <Siar:Button ID="btnAssociaDecreto1" runat="server" OnClick="btnAssociaDecreto1_Click"
								                    Text="Associa nuovo decreto" Width="160px"  />
						                    </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="tbDettaglioMandato" runat="server" width="100%" visible="false" >
                                                    <tr>
                                                        <td  class="paragrafo">
                                                            Elenco dei mandati e quietanze relative al decreto selezionato
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <Siar:DataGrid ID="dgDomandeLiquidazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
								                            PageSize="15" Width="100%"  ShowFooter="true" >
								                            <ItemStyle Height="28px" />
								                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
								                            <Columns>
								                                <Siar:ColonnaLink  LinkFields="IdLiquidazione" LinkFormat="javascript:selezionaMandato({0});" 
                                                                    DataField="IdLiquidazione" ItemStyle-Width = "20px">
                                                                </Siar:ColonnaLink>
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
					                                    <td align="left" style="padding: 10px">
					                                        <br />
							                                <Siar:Button ID="btnNuovoMandato" runat="server" OnClick="btnNuovoMandato_Click"
								                                Text="Aggiungi nuovo mandato" Width="160px"  />
						                                </td>
					                                </tr>
					                                <tr id="trMandato" runat="server" visible="false">
						                                <td>
							                                <table width="100%">
								                                <tr>
									                                <td class="paragrafo">
										                                Dati del mandato di pagamento:
									                                </td>
								                                </tr>
								                                <tr>
									                                <td style="padding: 10px">
										                   

										                                <table >
                                                                            <tr >
                                                                                <td colspan="3">
                                                                                     Caricare il file digitale:
										                                             <uc1:SNCUploadFileControl ID="ufMandato" runat="server" AbilitaModifica ="true" TipoFile="Documento"  />
                                                                                </td>
                                                                            </tr>
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
												                                <td colspan="3" align="right">
													                                <br />
													                                <Siar:Button ID="btnSalvaMandato" runat="server" OnClick="btnSalvaMandato_Click"
														                                Text="Salva dati mandato" Width="160px"  OnClientClick="return ctrlMandato(event);"
														                                 />
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
										                                <table >
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
														                                Text="Salva dati quietanza" Width="160px" OnClientClick="return ctrlQuietanza(event);"
														                                />
												                                </td>
											                                </tr>
                                                                            <tr>
                                                                                <td colspan="3" align="right">
                                                                                    <br />
                                                                                    <br />
                                                                                    <Siar:Button ID="btnEliminaMandato" runat="server" OnClick="btnEliminaMandato_Click"
														                                Text="Elimina mandato" Width="160px"  Conferma="Sei sicuro di voler eliminare il mandato?"
														                                 />
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
                    </td>
                </tr>                
            </table>
        </div>
    </div>
    <div id="divSchedaForm" style="display: none; width: 850px; position: absolute">
        <table class="tableNoTab" width="100%">
            <tr>
                <td>
                    <table id="tbDettaglioDecreto" runat="server" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="separatore">
                                Decreto
                            </td>
                        </tr>
                        <tr id="trDecretoComunicazione">
                            <td>
                                <table id="tbAttoDecreto">
                                    <tr>
                                        <td class="testo_pagina">
                                            La ricerca degli atti sui sistemi informatici della regione (ATTIWEB, NORMEMARCHE,
                                            OPEN ACT) richiede obbligatoriamente la specifica del <b>numero</b> e della <b>data</b>,
                                            e qualora si intenda ricercare un <b>decreto</b> e&#39; obbligatorio specificare
                                            anche il <b>registro</b>.
                                            <br />
                                            Una volta trovato l&#39;atto desiderato è necessario selezionarlo e <b>completare l&#39;importazione</b>
                                            specificando, nella maschera di dettaglio, il <b>tipo</b> (di approvazione, di revoca,
                                            di impegno, ecc).
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 108px">
                                                        Numero:<br />
                                                        <Siar:IntegerTextBox ID="txtNumeroDecreto"  NoCurrency="True"  runat="server" Width="80px" NomeCampo="Numero decreto" />
                                                    </td>
                                                    <td style="width: 120px">
                                                        Data:<br />
                                                        <Siar:DateTextBox ID="txtDataDecreto" runat="server" Width="100px" NomeCampo="Data decreto" />
                                                    </td>
                                                    <td style="width: 155px">
                                                        Registro:<br />
                                                        <Siar:ComboRegistriAtto ID="lstRegistro" runat="server" Width="120px">
                                                        </Siar:ComboRegistriAtto>
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                                             Text="Importa" Width="122px" OnClientClick="return ctrlCampiRicercaNormeMarche(event)" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trElencoDecreti" runat="server" visible="false">
                                        <td>
                                            &nbsp;
                                            <Siar:DataGrid ID="dgDecreti" runat="server" Width="100%" EnableViewState="False"
                                                AutoGenerateColumns="False" AllowPaging="false">
                                                <Columns>
                                                    <asp:BoundColumn DataField="Numero" HeaderText="Numero" Visible="True">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Data" HeaderText="Data" DataFormatString="{0:d}">
                                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                                                    <asp:BoundColumn>
                                                        <ItemStyle HorizontalAlign="center" Width="130px" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                            </Siar:DataGrid>
                                        </td>
                                    </tr>
                                    <tr id="trDettaglioDecreto" runat="server">
                                        <td>
                                            &nbsp;<table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 118px">
                                                        &nbsp;
                                                    </td>
                                                    <td style="width: 463px">
                                                        &nbsp;
                                                    </td>
                                                    <td rowspan="6" align="center" valign="middle">
                                                        <table class="tableNoTab">
                                                            <tr>
                                                                <td class="separatore" colspan="2">
                                                                    &nbsp;Pubblicazione B.U.R.&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 58px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 107px">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="middle" style="width: 58px">
                                                                    Numero:
                                                                </td>
                                                                <td align="left" style="width: 107px">
                                                                    <Siar:IntegerTextBox ID="txtNumeroBur" runat="server" Width="75px" ReadOnly="True" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 58px">
                                                                    Data:
                                                                </td>
                                                                <td align="left" style="width: 107px">
                                                                    <Siar:DateTextBox ID="txtDataBur" runat="server" Width="76px" ReadOnly="True" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 58px">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 107px">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 118px">
                                                        Definizione Atto:
                                                    </td>
                                                    <td style="height: 24px; width: 463px;">
                                                        <Siar:ComboDefinizioneAtto ID="lstDefAtto" runat="server" DataColumn="IdDefinizioneAtto"
                                                            Width="210px" Enabled="False">
                                                        </Siar:ComboDefinizioneAtto>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 118px">
                                                        Organo Istituzionale:
                                                    </td>
                                                    <td style="width: 463px">
                                                        <Siar:ComboOrganoIstituzionale ID="lstOrgIstituzionale" runat="server" DataColumn="IdOrganoIstituzionale"
                                                            Width="210px" Enabled="False">
                                                        </Siar:ComboOrganoIstituzionale>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 118px">
                                                        Registro:
                                                    </td>
                                                    <td style="height: 26px; width: 463px;">
                                                        <Siar:TextBox ID="txtRegistro" runat="server" Width="145px" DataColumn="Registro"
                                                            ReadOnly="True"></Siar:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 118px" valign="top">
                                                        Descrizione:
                                                    </td>
                                                    <td style="width: 463px">
                                                        <Siar:TextArea ID="txtDescrizione" runat="server" Width="437px" DataColumn="Descrizione"
                                                            ReadOnly="True"></Siar:TextArea>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px" valign="top">
                                                        Importo Erogato allo strumento finanziario:
                                                    </td>
                                                    <td style="width: 463px">
                                                        <Siar:CurrencyBox  ID="txtImportoDecreto" runat="server" Width="160px" />
                                                        €
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px" valign="top">
                                                        Importo erogato a titolo di spesa ammissibile:
                                                    </td>
                                                    <td style="width: 463px">
                                                        <Siar:CurrencyBox  ID="txtImportoDecretoAmmesso" runat="server" Width="160px" />
                                                        €
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
            <tr>
                <td style="height: 58px;" align="right" colspan="2">
                    &nbsp;
                    <Siar:Button ID="btnInserisciDecreto" runat="server" OnClick="btnInserisciDecreto_Click" 
                        OnClientClick="return validaImportoDecreto(event);" Text ="Salva" Width="178px" />
                    &nbsp;&nbsp;
                    <input id="Button2" class="Button" onclick="chiudiPopup()" style="width: 120px" type="button"
                        value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>
    <uc3:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="FIRMA DIGITALE DELL'EROGAZIONE"
        TipoDocumento="EROGAZIONE" />
</asp:Content>
