<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="CertificazioneRendicontazione.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneRendicontazione" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function createUrlDettaglio(id) { createBaseUrl('private/psr/bandi/dettaglio.aspx?idb=' + id); }
        function createUrlIstruttoria(id, filiera, cod_stato) {
            if (cod_stato == 'P') alert('Attenzione! Il bando selezionato non è ancora stato pubblicato, impossibile continuare.');
            else if (filiera) createBaseUrl('private/ManifInteresse/istruttoria/Collaboratori.aspx?idb=' + id);
            else createBaseUrl('private/istruttoria/statistiche.aspx?idb=' + id);
        }
        function createUrlRendicontazione(id, filiera, cod_stato) {
            if (cod_stato == 'P') alert('Attenzione! Il bando selezionato non è ancora stato pubblicato, impossibile continuare.');
            else if (cod_stato == 'L') alert('Attenzione! La graduatoria non è ancora stata resa definitiva, impossibile continuare.');
            else if (filiera) alert('Attenzione! La sezione rendicontazione non è abilitata per le Manifestazioni di Interesse di Filiera.');
            else { createBaseUrl('private/IPagamento/SelezioneDomande.aspx?idb=' + id); }
        }
        function createBaseUrl(url) { document.location = getBaseUrl() + url; }
        function estraiInXls() {
            var iCodPsrequalthis =$('[id$=lstPsr]').val();
            var parametri = "CodPsrequalthis=" + iCodPsrequalthis;
             SNCVisualizzaReport('rptCertificazioneDiRendicontazioneXLS', 2, parametri);
        }
        function formatMoney(num) {
            var newNum = parseFloat(num).toFixed(2);
            newNum = newNum.toString().replace('.',',')
            return  newNum.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")+ ' €';

        }
        function addRowDettaglioDati(tipo, asse, azione, intervento, bando, imp1, imp2, imp3, imp4, imp5, rup, dettaglio) {
     
            var tipoLivSup ='Asse '+ asse;
            var valTipo = 'Azione ' + azione;

            if (tipo == 1) {
                tipoLivSup = 'Azione ' + azione;
                valTipo = 'Intervento ' + intervento;
            }
            else if (tipo == 2) {
                tipoLivSup = 'Intervento ' + intervento;
                valTipo = 'Bando ' + bando + ' - ' + rup;
            }
            else if (tipo == 3) {
                tipoLivSup = 'bando ' + bando ;
                valTipo = '';
            }
   
            var indx = 0;
            var j = 0;
            var newInsert = true;
            var t = document.getElementById('tblDettaglioDati');

            $("#tblDettaglioDati tr").each(function() {
                var val1 = $(t.rows[j].cells[1]).text().trim();

                if (tipoLivSup.trim() == val1) {
                    indx = j+1;
                }
                if (valTipo.trim() == val1 || tipo == 3) {
                    newInsert = false;
                }
                j++;
            });
            // striId per individuare in mdodo univico la singola riga
            var strId = ''
            if (asse != null && asse !='') {
                strId += asse + '_';
            }
     
            if (azione != null &&  azione !='') {
                strId += azione + '_';
            }
            if (intervento != null &&  intervento !='') {
                strId += intervento + '_';
            }
            if (bando != null &&  bando !='') {
                strId += bando;
            }
            var sEspandibile = 'details-control';
            if (dettaglio == null || dettaglio =='') {
                sEspandibile = 'stop-details-control';
            }
            var strParam = + tipo + 1 + ',' + "'" + asse + "'" + ',' + "'" + azione + "'" + ',' + "'" + intervento + "'" + ',' + "'" + bando + "'" + ',' + 'this';
            var newRow = $('<tr id = \"tr_' + strId + '\" class="DataGridRow" style="text-align: right;" >'
                + '<td id = \"' + strId + '\" class="'+ sEspandibile+'" onclick="selezionaRaggruppamento(' + strParam + '); " style="text - align: center; "'
                +'</td >'
                +'<td style="text-align: center;">'
                + valTipo
                +'</td >'
                +'<td>'
                +formatMoney(imp1)
                +'</td >'
                +'<td>'
                +formatMoney(imp2)
                +'</td >'
                +'<td>'
                +formatMoney(imp3)
                +'</td >'
                +'<td>'
                +formatMoney(imp4)
                + '</td >'
                +'<td>'
                +formatMoney(imp5)
                +'</td >'
                + '</tr > ');
            if (newInsert) {
                newRow.insertBefore($('#tblDettaglioDati tbody tr:nth(' + indx + ')'));
            }

        }

        function selezionaRaggruppamento(id_tipo, id_asse, id_azione, id_intervento, id_bando, id_td) {  
            //inserisco in un array i riferimenti alle righe di dettaglio visualizzate per la riga selezionata
            var obj = id_td;
            var matches = [];
            var elems = document.getElementsByTagName("tr");
            for (var i = 0; i < elems.length; i++) {
                var ok0 = (elems[i].id).trim();
                var ok1 = ('tr_' + obj.id).trim();

                if (ok0.indexOf(ok1) == 0 && ok0 != ok1) {
                    matches.push(elems[i]);
                }

            }
            //elimino, se presenti le righe di dettaglio per la riga selezionata e se l'icona della riga di dettaglio è l'icona per chiudere il dettaglio.
            if (matches.length > 0) { 
                var bnodo = false;
                for (var j = 0; j < matches.length; j++) {
                    if ((obj.className == 'no-details-control')) {
                        var myObj = matches[j];
                        var k = myObj.rowIndex;
                        var t = document.getElementById('tblDettaglioDati');
                        t.deleteRow(k);
                    }
                }
            }
            //cambio l'icona della riga selezionata. Se l'icona è il segno "+" cambia in "-" e viceversa.
            if (obj.className == 'no-details-control') {
                obj.className = 'details-control';
            }
            else {
                if (obj.className == 'details-control') {
                    obj.className = 'no-details-control';
                }
                $.ajax({
                type: "POST",
                url: "CertificazioneRendicontazione.aspx/SommaperTipoRagggruppamento",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: '{selectedValue: "' + $("[id$='lstPsr']").val() + '", asse: "' + id_asse + '", azione: "' + id_azione + '", intervento: "' + id_intervento + '", bando: "' + id_bando + '" }',
                success: function (msg) {
                    if (msg.d != "") {
                         $.each(msg, function(key, val) {
                        var newTemp = val.substring(1, val.length - 2).replace(/'/g, '"');
                        var obj = JSON.parse(newTemp);
                        var rows = obj.length;                    
                        var row = "";
                        for (i = 0; i < rows; i++) {
                            addRowDettaglioDati(id_tipo, id_asse, obj[i].Azione, obj[i].Intervento, obj[i].Bando, obj[i].ImportoAmmesso, obj[i].ContributoUE, obj[i].ContributoStato, obj[i].ContributoRegione, obj[i].ImportoPrivato, obj[i].Rup, obj[i].Dettaglio)
                        }                     
                    });
                    }
                },
                failure: function(response) {
                    alert(response.d);
                },
                error: function(response) {
                    alert(response.d);
                }
            });
            }


            
        }      


    </script>
        <asp:HiddenField ID="hdnCodPsr" runat="server" />
        <asp:HiddenField ID="hdnIdCertSp" runat="server" />

    < <!-- Testa -->
    <div style="text-align:center;">
        <h1>Certificazione di rendicontazione</h1>
    </div>
    <div class="dBox">        
        <div class="dSezione">
            <div class="dContenutoFloat">
                <strong>Selezionare il programma:</strong>
                <Siar:ComboZPsr ID="lstPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr><br /><br />
            </div>
        </div>
    </div>
    <div id="divDettaglio" class="dBox" visible="false" runat="server">        
    <uc2:SiarNewTab ID="tabDettaglio" runat="server" TabNames="Elenco|Dati riassuntivi"
        Titolo="Certificazione di rendicontazione" />
        <div id="divDettaglioElenco" class="dContenuto" runat="server" visible="false">
            <div class="dContenutoFloat">
                <input type="button" class="Button" value="Estrai in xls" style="width: 140px" onclick="return estraiInXls();" />
                <br />
                <asp:Label ID="lblNrRecord" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            </div>
            <Siar:DataGrid ID="dgDettaglio" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundColumn DataField="AsseCodice" HeaderText="Asse"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Azione" HeaderText="Azione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Intervento" HeaderText="Intervento"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdBando" HeaderText="Id Bando"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IdDomandaPagamento" HeaderText="Id Domanda Pagamento">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CodiceCUP" HeaderText="CUP"></asp:BoundColumn>
                    <asp:BoundColumn DataField="TipoOperazione" HeaderText="Tipo Operazione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CostoTotale" HeaderText="Costo Investimento Ammesso"
                        DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoAmmesso" HeaderText="Contributo Concesso" DataFormatString="{0:c}">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Beneficiario" HeaderText="Beneficiario"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SpesaAmmessa" HeaderText="Importo Ammesso Rendicontato"
                        DataFormatString="{0:c}"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ContributoConcesso" HeaderText="Contributo Concesso Rendicontato"
                        DataFormatString="{0:c}"></asp:BoundColumn>
                     <asp:BoundColumn DataField="ImportoPrivato" HeaderText="Importo privato*"
                        DataFormatString="{0:c}"></asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
        </div>
        <div id="divDettaglioDati" class="dContenuto" runat="server" visible="false">
           
        </div>
    </div>
</asp:Content>
