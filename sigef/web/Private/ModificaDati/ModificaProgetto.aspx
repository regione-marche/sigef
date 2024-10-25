<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ModificaProgetto.aspx.cs" Inherits="web.Private.ModificaDati.ModificaProgetto" %>

<%@ Register Src="../../CONTROLS/DatiDomanda.ascx" TagName="DatiDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

<asp:content id="Content1" contentplaceholderid="cphContenuto" runat="server">

    <script type="text/javascript">

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraModificaProgetto]');
                    img = $('[id$=imgMostraModificaProgetto]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraRequisitiSoggettivi]');
                    img = $('[id$=imgMostraRequisitiSoggettivi]')[0];
                    break;
                case 2:
                    div = $('[id$=divMostraProgettoIndicatori]');
                    img = $('[id$=imgMostraProgettoIndicatori]')[0];
                    break;
                case 3:
                    div = $('[id$=divMostraModificaDomandePagamento]');
                    img = $('[id$=imgMostraModificaDomandePagamento]')[0];
                    break;
                case 4:
                    div = $('[id$=divMostraModificaVarianti]');
                    img = $('[id$=imgMostraModificaVarianti]')[0];
                    break;
                case 5:
                    div = $('[id$=divMostraStoricoModifiche]');
                    img = $('[id$=imgMostraStoricoModifiche]')[0];
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

        function selezionaDomanda(idDomanda) {
            $('[id$=hdnIdDomanda]').val($('[id$=hdnIdDomanda]').val() == idDomanda ? '' : idDomanda);
            $('[id$=btnModificaDomanda]').click();
        }

        function selezionaVariante(idVariante) {
            $('[id$=hdnIdVariante]').val($('[id$=hdnIdVariante]').val() == idVariante ? '' : idVariante);
            $('[id$=btnModificaVariante]').click();
        }

        function selezionaModifica(idModifica) {
            $('[id$=hdnIdModifica]').val($('[id$=hdnIdModifica]').val() == idModifica ? '' : idModifica);
            $('[id$=btnVisualizzaModifica]').click();
        }

        function selezionaPlurivalore(jobj) {
            if (jobj == null)
                alert('L`elemento selezionato non è valido.');
            else {
                $('[id$=lblPlurivaloreSelezionato' + jobj.IdPriorita + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionato' + jobj.IdPriorita + ']').val(jobj.IdValore);
            }
        }

        function deselezionaPlurivalore(id) {
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text(''); $('[id$=hdnPlurivaloreSelezionato' + id + ']').val('');
        }

        function selezionaPlurivaloreSql(jobj) {
            if (jobj == null)
                alert('L`elemento selezionato non è valido.');
            else {
                $('[id$=lblPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').val(jobj.Codice);
            }
        }

        function deselezionaPlurivaloreSql(id) {
            $('[id$=lblPlurivaloreSelezionatoSql' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionatoSql' + id + ']').val('');
        }

        function MostraProtocolloNew(segnatura) {
            $('[id$=hdnSegnatura]').val(segnatura);
            $('[id$=btnMostraProtocollo]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdDomanda" runat="server" />
        <asp:Button ID="btnModificaDomanda" runat="server" OnClick="btnModificaDomanda_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdVariante" runat="server" />
        <asp:Button ID="btnModificaVariante" runat="server" OnClick="btnModificaVariante_Click" CausesValidation="false" />

        <asp:HiddenField ID="hdnIdModifica" runat="server" />
        <asp:Button ID="btnVisualizzaModifica" runat="server" OnClick="btnVisualizzaModifica_Click" CausesValidation="false" />

        <asp:Button ID="btnMostraProtocollo" runat="server" OnClick="btnMostraProtocollo_Click" CausesValidation="false" />
        <asp:HiddenField ID="hdnSegnatura" runat="server" />
    </div>

    <%--Riepilogo progetto--%>
    <div style="padding-left:10px; padding-bottom: 10px;">
        <uc1:DatiDomanda ID="ucDatiDomanda" runat="server" />
    </div>

    <%--Progetto--%>
    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
            <img id="imgMostraModificaProgetto" runat="server" style="width: 23px; height: 23px;" />
            Modifica dati domanda di aiuto
        </div>

        <div id="divMostraModificaProgetto" style="padding: 10px;">

            <div id="divRequisitiProgetto" runat="server" class="dBox" >

                <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(1); return false;">
                    <img id="imgMostraRequisitiSoggettivi" runat="server" style="width: 23px; height: 23px;" />
                    Requisiti soggettivi della domanda di aiuto
                </div>

                <div id="divMostraRequisitiSoggettivi" style="padding: 10px;">
                    <div id="divDisposizioniAttuative" runat="server" style="margin-top:10px; width:800px;" >
                    </div>

                    <div>
                        Note modifiche requisiti:<br />
                        <Siar:TextArea ID="txtNoteRequisitiProgetto" runat="server" NomeCampo="Note requisiti progetto"
                            Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>

                    <input type="button" class="Button" value="Indietro" style="width: 120px; margin-left:10px; margin-right:10px;" onclick="history.back();" />
                    <Siar:Button ID="btnSalvaRequisitiProgetto" runat="server" Modifica="True" Width="120px" Text="Salva requisiti" OnClick="btnSalvaRequisitiProgetto_Click" />
                </div>
            </div>

            <div id="divProgettoIndicatori" runat="server" class="dBox">

                <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(2); return false;">
                    <img id="imgMostraProgettoIndicatori" runat="server" style="width: 23px; height: 23px;" />
                    Indicatori della domanda di aiuto
                </div>

                <div id="divMostraProgettoIndicatori" style="padding:10px;">
                    <uc2:ProgettoIndicatori ID="ucProgettoInd" runat="server" style="margin-top:10px; margin-bottom:10px;" />

                    <div style="margin-top: 10px;">
                        Note modifiche indicatori:<br />
                        <Siar:TextArea ID="txtNoteIndicatoriProgetto" runat="server" NomeCampo="Note indicatori progetto"
                            Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" />
                    </div>

                    <input type="button" class="Button" value="Indietro" style="width: 120px; margin-top:10px; margin-left: 10px; margin-right: 10px;" onclick="history.back();" />
                    <Siar:Button ID="btnSalvaIndicatoriProgetto" runat="server" Modifica="True" Width="120px" Text="Salva indicatori" OnClick="btnSalvaIndicatoriProgetto_Click" />
                </div>
            </div>
        </div>

    </div>

    <%--Domande di pagamento--%>
    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(3); return false;">
            <img id="imgMostraModificaDomandePagamento" runat="server" style="width: 23px; height: 23px;" />
            Modifica dati domande di pagamento
        </div>

        <div class="testo_pagina">
            Di seguito vengono listate, in ordine cronologico crescente, tutte le richieste di pagamento della domanda di aiuto in questione.
        </div>

        <div id="divMostraModificaDomandePagamento" runat="server" style="padding: 10px;">

            <Siar:DataGrid ID="dgDomande" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn HeaderText="Richiesto">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Id" DataField="IdDomandaPagamento">
                        <ItemStyle HorizontalAlign="center" Width="40px" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Modalità di pagamento" DataField="Descrizione">
                        <ItemStyle HorizontalAlign="center" Width="140px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo richiesto" DataField="ImportoRichiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo richiesto" DataField="ContributoRichiesto" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Domanda pagamento">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Istruita">
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data approvazione">
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo ammesso" DataField="ImportoAmmesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Contributo ammesso (*)" DataField="ContributoAmmesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" Width="100px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdDomandaPagamento" ButtonText="Modifica dati domanda" JsFunction="selezionaDomanda">
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />

            <div style="width: 100%; text-align: right">
                (<font style="text-decoration: line-through; font-weight: bold; color: #bc3333">in rosso</font>
                le domande di pagamento non approvate)
                   
                <br />
                (*=importo calcolato al netto delle sanzioni e del recupero anticipo percepito)
                   
                <br />
                (** = contributo troncato per superamento massimali di domanda)
               
            </div>

        </div>

    </div>

    <%--Varianti--%>
    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(4); return false;">
            <img id="imgMostraModificaVarianti" runat="server" style="width: 23px; height: 23px;" />
            Modifica dati varianti
        </div>

        <div class="testo_pagina" >
            Di seguito vengono listate, in ordine cronologico crescente, tutte le richieste di modifica al piano degli investimenti della domanda di aiuto in questione.
        </div>

        <div id="divMostraModificaVarianti" runat="server" style="padding: 10px;">

            <Siar:DataGrid ID="dgVarianti" runat="server" Width="100%" AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data" DataField="DataModifica">
                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Modalita e descrizione tecnica"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Operatore">
                        <ItemStyle Width="180px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Istruita">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data approvazione" DataField="DataApprovazione">
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Approvata" DataField="Approvata" DataFormatString="{0:SI|NO}">
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Operatore di istruttoria" DataField="NominativoIstruttore">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdVariante" ButtonText="Modifica dati variante" JsFunction="selezionaVariante">
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />

            <div style="text-align:right;">
                (<img src="../../images/soggetto.ico" alt="Variante/variazione finanziaria con richiesta di cambio beneficiario" />
                = variante/variazione finanziaria con richiesta di cambio beneficiario)
            </div>

        </div>

    </div>

    <%--Storico--%>
    <div class="dBox">

        <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(5); return false;">
            <img id="imgMostraStoricoModifiche" runat="server" style="width: 23px; height: 23px;" />
            Storico modifiche
        </div>

        <div class="testo_pagina">
            Di seguito vengono listate, in ordine cronologico crescente, tutte le modifiche apportate alla domanda di aiuto in questione.
        </div>

        <div id="divMostraStoricoModifiche" runat="server" style="padding: 10px;">

            <asp:Label ID="lblNumModifiche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
            <br />
            <Siar:DataGrid ID="dgModifiche" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="IdModifica" HeaderText="Id">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Target" HeaderText="Target">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdDomanda" HeaderText="Id domanda pagamento">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdVariante" HeaderText="Id variante">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataModifica" HeaderText="Data modifica">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="UtenteModifica" HeaderText="Utente modifica">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="TipoModifica" HeaderText="Tipo modifica">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Note" HeaderText="Note">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdModifica" ButtonText="Visualizza modifica" JsFunction="selezionaModifica">
                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>

        </div>

    </div>

    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />

</asp:content>