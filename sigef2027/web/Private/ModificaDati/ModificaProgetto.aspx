<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="ModificaProgetto.aspx.cs" Inherits="web.Private.ModificaDati.ModificaProgetto" %>

<%@ Register Src="../../CONTROLS/DatiDomanda.ascx" TagName="DatiDomanda" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ucVisualizzaProtocollo.ascx" TagName="ucVisualizzaProtocollo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">

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
    <uc1:DatiDomanda ID="ucDatiDomanda" runat="server" />
    <%--Progetto--%>
    <div class="row">
        <div class="col-sm-12">
            <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                <div class="accordion-item">
                    <h2 class="accordion-header " id="headingProgetti">
                        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseProgetti" aria-expanded="true" aria-controls="collapseProgetti">
                            Modifica dati domanda di aiuto
                        </button>
                    </h2>
                    <div id="collapseProgetti" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingProgetti">
                        <div class="accordion-body">
                            <div class="col-sm-12">
                                <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                                    <div class="accordion-item" id="divRequisitiProgetto" runat="server">
                                        <h2 class="accordion-header " id="headingProgetto">
                                            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseProgetto" aria-expanded="true" aria-controls="collapseProgetto">
                                                Requisiti soggettivi della domanda di aiuto
                                            </button>
                                        </h2>
                                        <div id="collapseProgetto" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingProgetto">
                                            <div class="accordion-body">
                                                <div class="row bd-form">
                                                    <div class="col-sm-12" id="divDisposizioniAttuative" runat="server">
                                                    </div>
                                                    <div class="col-sm-12 form-group my-2">
                                                        <Siar:TextArea Label="Note modifiche requisiti:" ID="txtNoteRequisitiProgetto" runat="server" NomeCampo="Note requisiti progetto"
                                                            Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
                                                        <Siar:Button ID="btnSalvaRequisitiProgetto" runat="server" Modifica="True" Text="Salva requisiti" OnClick="btnSalvaRequisitiProgetto_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="accordion-item" id="divProgettoIndicatori" runat="server">
                                        <h2 class="accordion-header " id="headingIndicatori">
                                            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseIndicatori" aria-expanded="true" aria-controls="collapseIndicatori">
                                                Indicatori della domanda di aiuto
                                            </button>
                                        </h2>
                                        <div id="collapseIndicatori" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingIndicatori">
                                            <div class="accordion-body">
                                                <div class="row bd-form">
                                                    <uc2:ProgettoIndicatori ID="ucProgettoInd" runat="server" />

                                                    <div class="col-sm-12 form-group my-2">
                                                        <Siar:TextArea Label="Note modifiche indicatori:" ID="txtNoteIndicatoriProgetto" runat="server" NomeCampo="Note indicatori progetto"
                                                            Obbligatorio="false" Rows="4" ExpandableRows="5" MaxLength="10000" />
                                                    </div>
                                                    <div class="col-sm-12">
                                                        <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
                                                        <Siar:Button ID="btnSalvaIndicatoriProgetto" runat="server" Modifica="True" Text="Salva indicatori" OnClick="btnSalvaIndicatoriProgetto_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header " id="headingDomandaPagamento">
                        <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseDomandaPagamento" aria-expanded="true" aria-controls="collapseDomandaPagamento">
                            Modifica dati domande di pagamento
                        </button>
                    </h2>
                    <div id="collapseDomandaPagamento" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingDomandaPagamento">
                        <div class="accordion-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>Di seguito vengono listate, in ordine cronologico crescente, tutte le richieste di pagamento della domanda di aiuto in questione.</p>
                                    <Siar:DataGridAgid ID="dgDomande" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
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
                                    </Siar:DataGridAgid>
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
                        </div>
                    </div>
                </div>
                <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                    <div class="accordion-item">
                        <h2 class="accordion-header " id="headingVariante">
                            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseVariante" aria-expanded="true" aria-controls="collapseVariante">
                                Modifica dati varianti
                            </button>
                        </h2>
                        <div id="collapseVariante" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingVariante">
                            <div class="accordion-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <p>Di seguito vengono listate, in ordine cronologico crescente, tutte le richieste di modifica al piano degli investimenti della domanda di aiuto in questione.</p>
                                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgVarianti" runat="server" AutoGenerateColumns="False">
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
                                        </Siar:DataGridAgid>
                                        <br />

                                        <div style="text-align: right;">
                                            (<img src="../../images/soggetto.ico" alt="Variante/variazione finanziaria con richiesta di cambio beneficiario" />
                                            = variante/variazione finanziaria con richiesta di cambio beneficiario)
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="accordion accordion-background-active" id="collapseRaggruppamenti">
                    <div class="accordion-item">
                        <h2 class="accordion-header " id="headingStorico">
                            <button class="accordion-button rounded-2" type="button" data-bs-toggle="collapse" data-bs-target="#collapseStorico" aria-expanded="true" aria-controls="collapseStorico">
                                Storico modifiche
                            </button>
                        </h2>
                        <div id="collapseStorico" class="accordion-collapse collapse show" data-bs-parent="#accordionExampleHa" role="region" aria-labelledby="headingStorico">
                            <div class="accordion-body">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <p>Di seguito vengono listate, in ordine cronologico crescente, tutte le modifiche apportate alla domanda di aiuto in questione.</p>
                                        <asp:Label ID="lblNumModifiche" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                                        <br />
                                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgModifiche" runat="server" AutoGenerateColumns="false" Width="100%">
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
                                        </Siar:DataGridAgid>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <uc1:ucVisualizzaProtocollo ID="modaleMostraProtocollo" runat="server" />

</asp:Content>
