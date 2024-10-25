<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="Trasferimenti.aspx.cs" Inherits="web.Private.Istruttoria.Trasferimenti" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function ctrlCuaaDitta() {
            var text_box_cuaa = $('[id$=txtCuaaRicerca_text]'); var cuaa = $(text_box_cuaa).val().replace(/\s/g, '');
            if (cuaa != null && cuaa != "" && !ctrlCodiceFiscale(cuaa) && !ctrlPIVA(cuaa)) {
                alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');
            }
        }



        function ctrlCampiRicercaNormeMarche(ev) { if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") { alert('Per la ricerca degli atti è necessario specificare numero, data e registro.'); return stopEvent(ev); } }

        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") { alert('Per proseguire è necessario specificare un atto.'); return stopEvent(ev); }
            else if ($('[id$=lstAttoTipo]').val() == "") { alert('Per proseguire è necessario specificare la tipologia dell`atto.'); }
            else if ($('[id$=txtAttoImporto]').val() == "") {
                alert('Per proseguire è necessario specificare l`importo dell`atto.'); return stopEvent(ev);
            }
            if (!confirm("Si sta per inserire il decreto di pagamento per la domanda selezionata. Continuare?")) return stopEvent(ev);
        }

        function selezionaTrasferimento(erog) {
            $('[id$=hdnIdTrasferimento]').val(erog);
            $('[id$=hdnIdTrasferimentoMandato]').val('');
            $('[id$=btnSelezionaTrasf]').click();
        }

        function visualizzaTraferimento(id) {

            $('[id$=hdnIdTrasferimento]').val($('[id$=hdnIdTrasferimento]').val() == id ? '' : id);
            $('[id$=hdnIdTrasferimentoMandato]').val('');
            $('[id$=btnPost]').click();
        }

        function selezionaMandato(id) {
            $('[id$=hdnIdTrasferimentoMandato]').val(id);
            $('[id$=btnPostNull]').click();
        }

        function ctrlMandato(ev) { if ($('[id$=txtMandatoData_text]').val() == "" || $('[id$=txtMandatoImporto_text]').val() == "" || $('[id$=txtMandatoNumero_text]').val() == "" || $('[id$=ufMandato_hdnSNCUFUploadFile]').val() == "") { alert('Per proseguire è necessario specificare numero, data, importo e file digitale del mandato.'); return stopEvent(ev); } }

    </script>


    <div style="display: none">
        <asp:HiddenField ID="hdnIdImpresa" runat="server" />
        <asp:HiddenField ID="hdnIdTrasferimento" runat="server" />
        <asp:HiddenField ID="hdnIdTrasferimentoMandato" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:Button ID="btnPost" CausesValidation="false" runat="server" OnClick="btnPost_Click" />
        <asp:Button ID="btnPostNull" CausesValidation="false" runat="server" OnClick="btnPostNull_Click" />


        <%--   <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
     <asp:Button ID="btnPost2" runat="server" OnClick="btnPost2_Click" />
        <asp:Button ID="btnSelezionaProgetto" runat="server" OnClick="btnSelezionaProgetto_Click" />--%>

        <asp:Button ID="btnSelezionaTrasf" runat="server" OnClick="btnSelezionaTrasf_Click" />
    </div>

    <div class="row bd-form py5" id="divRicerca" visible="true" runat="server">
        <h2 class="pb-5">Inserimento dei trasferimenti ad enti pubblici / organismi intermedi
        </h2>
        <div class="col-sm-10 form-group">

            <Siar:TextBox  Label="Ricerca per CF/P.IVA:" ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale" />
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnCercaDB" runat="server" Text="Cerca sul database locale"
                CausesValidation="False" OnClick="btnCercaDB_Click"></Siar:Button>
        </div>
        <div class="row">
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Codice Fiscale:" ID="txtCuaa" runat="server" ReadOnly="True" Width="140px" TextAlign="right" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  ID="txtPiva" Label="P.Iva:" runat="server" ReadOnly="True" Width="140px" TextAlign="right" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:TextBox  Label="Ragione sociale:" ID="txtRagioneSociale" runat="server" ReadOnly="True" Width="450px" />
            </div>
        </div>
        <div visible="false" id="tbImpresa" runat="server" class="row">
            <h3 class="py-5">Elenco dei Trasferimenti:</h3>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgTrasferimenti" runat="server" AllowPaging="false"
                    AutoGenerateColumns="False" ShowFooter="true">
                    <ItemStyle Height="28px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdTrasferimento" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Numero" HeaderText="Numero Decreto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data Decreto">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Registro" HeaderText="Registro">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderText="Importo" HeaderStyle-HorizontalAlign="Right">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Causale Trasferimento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Nominativo" HeaderText="Operatore Inserimento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo Mandati">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo Quietanza">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <Siar:JsButtonColumnAgid Arguments="IdTrasferimento" ButtonType="TextButton" ButtonText="Seleziona" JsFunction="visualizzaTraferimento" HeaderText="Visualizza">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:JsButtonColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12 text-start">
                <Siar:Button ID="btnInserisciNew" runat="server" Text="Inserisci nuovo trasferimento"
                    CausesValidation="False" OnClick="btnInserisciNew_Click"></Siar:Button>
            </div>
        </div>
    </div>
    <div class="row py5 mt-5">
        <div class="col-sm-12">
            <div class="accordion" id="collapseExample">
                <div class="accordion-item" id="divTrasf_new" runat="server">
                    <h2 class="accordion-header " id="heading3c">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse3c" aria-expanded="true" aria-controls="collapse3c">
                            Trasferimento:
                        </button>
                    </h2>
                    <div id="collapse3c" class="accordion-collapse collapse show bd-form" role="region" aria-labelledby="heading3c">
                        <div class="accordion-body">
                            <div class="row pt-5" id="tbTrasf_new" visible="false" runat="server">
                                <div class="col-sm-2 form-group">
                                    <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstAttoDefinizione" runat="server" NoBlankItem="True">
                                    </Siar:ComboDefinizioneAtto>
                                </div>
                                <div class="col-sm-1 form-group">
                                    <Siar:IntegerTextBox Label="Numero:" NoCurrency="True" ID="txtAttoNumero" runat="server" NomeCampo="Numero decreto" />
                                </div>
                                <div class="col-sm-2 form-group">
                                    <Siar:DateTextBox Label="Data:" ID="txtAttoData" runat="server" NomeCampo="Data decreto" />
                                </div>
                                <div class="col-sm-1 form-group">
                                    <Siar:ComboRegistriAtto Label="Registro:" ID="lstAttoRegistro" runat="server">
                                    </Siar:ComboRegistriAtto>
                                </div>
                                <div class="col-sm-1">
                                    <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                                        Text="Ricerca" Width="100px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                                </div>
                                <div class="col-sm-3 form-group">
                                    <Siar:ComboOrganoIstituzionale Label="Organo Istituzionale:" ID="lstAttoOrgIstituzionale" runat="server"
                                        Enabled="False">
                                    </Siar:ComboOrganoIstituzionale>
                                </div>
                                <div class="col-sm-2 form-group">
                                    <Siar:ComboTipoAtto Label="Tipo atto:" ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto">
                                    </Siar:ComboTipoAtto>
                                </div>
                                <div class="col-sm-7 form-group">
                                    <Siar:TextArea Label="Descrizione:" ID="txtAttoDescrizione" runat="server" ReadOnly="True"
                                        Rows="4" ExpandableRows="5"></Siar:TextArea>
                                </div>
                                <div class="col-sm-3 form-group">
                                    <h5 class="pb-3">Pubblicazione B.U.R.</h5>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <Siar:IntegerTextBox Label="Numero:" ID="txtAttoBurNumero" runat="server" ReadOnly="True" />
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <Siar:DateTextBox Label="Data:" ID="txtAttoBurData" runat="server" ReadOnly="True" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-2">
                                    <input id="btnVidualizzaDecreto" runat="server" class="btn btn-secondary py-1" type="button" disabled="disabled" value="Visualizza atto" />
                                </div>
                                <h3 class="py-5">Dati del trasferimento</h3>
                                <div class="col-sm-4 form-group">
                                    <div class="select-wrapper">
                                        <label for="<% =ddlCausale.ClientID %>">Causale trasferimento:</label>
                                        <asp:DropDownList ID="ddlCausale" AutoPostBack="True" runat="server">
                                            <asp:ListItem Selected="True" Value="1">Trasferimento a titolo di anticipazione</asp:ListItem>
                                            <asp:ListItem Value="2">Trasferimento intermedio</asp:ListItem>
                                            <asp:ListItem Value="3">Trasferimento a saldo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-3 form-group">

                                    <Siar:CurrencyBox Label="Importo €:" ID="txtAttoImporto" runat="server" />
                                </div>
                                <div class="col-sm-5 text-start">
                                    <Siar:Button ID="btnAssociaDecreto" runat="server" OnClick="btnAssociaDecreto_Click"
                                        Text="Associa decreto" Modifica="True" OnClientClick="return ctrlTipoAtto(event);" />
                                </div>

                                <div id="divMostraMandati" visible="false" runat="server" class="row">
                                    <h4 class="pb-5">Elenco dei mandati del trasferimento:</h4>
                                    <div class="col-sm-12">
                                        <Siar:DataGridAgid CssClass="table table-striped" ID="dgTrasferimentoMandato" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            PageSize="15" ShowFooter="true">
                                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                            <Columns>
                                                <Siar:ColonnaLinkAgid LinkFields="IdTrasferimentoMandato" LinkFormat="javascript:selezionaMandato({0});"
                                                    DataField="IdTrasferimentoMandato" ItemStyle-Width="20px">
                                                </Siar:ColonnaLinkAgid>
                                                <asp:BoundColumn DataField="MandatoNumero" HeaderText="Numero">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="MandatoData" HeaderText="Data">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="MandatoImporto" HeaderText="Importo">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuietanzaData" HeaderText="Data">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuietanzaImporto" HeaderText="Importo">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGridAgid>
                                    </div>
                                    <div class="col-sm-12 text-start">
                                        <Siar:Button ID="btnNuovoMandato" runat="server" OnClick="btnNuovoMandato_Click"
                                            Text="Aggiungi nuovo mandato" />
                                    </div>
                                    <div class="row mt-5" runat="server" visible="false" id="divMandato">
                                        <h4 class="pb-3">Dettaglio del mandato:
                                        </h4>
                                        <div class="col-sm-12 mb-5">
                                            <uc1:SNCUploadFileControl ID="ufMandato" Text="Caricare il file digitale:" runat="server" AbilitaModifica="true" TipoFile="Documento" />
                                        </div>
                                        <div class="col-sm-4 pt-5 form-group">
                                            <Siar:DateTextBox ID="txtMandatoData" runat="server" Label="Data:" />
                                        </div>
                                        <div class="col-sm-4 pt-5 form-group">
                                            <Siar:CurrencyBox Label="Importo €:" ID="txtMandatoImporto" runat="server" />
                                        </div>
                                        <div class="col-sm-4 pt-5 form-group">
                                            <Siar:TextBox  Label="Numero:" ID="txtMandatoNumero" runat="server" />
                                        </div>
                                        <h4 class="pb-5">Dettaglio della quietanza:
                                        </h4>
                                        <div class="col-sm-4 form-group">
                                            <Siar:DateTextBox Label="Data:" ID="txtQuietanzaData" runat="server" />
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <Siar:CurrencyBox Label="Importo €:" ID="txtQuietanzaImporto" runat="server" />
                                        </div>
                                        <div class="col-sm-4">
                                            <Siar:Button ID="btnSalvaMandato" runat="server" OnClick="btnSalvaMandato_Click"
                                                Text="Salva" OnClientClick="return ctrlMandato(event);" />
                                            <Siar:Button ID="btnEliminaMandato" runat="server" OnClick="btnEliminaMandato_Click"
                                                Text="Elimina" Conferma="Sei sicuro di voler eliminare il mandato?" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="accordion-item" id="divProgetti" visible="false" runat="server">
                    <h2 class="accordion-header " id="heading4c">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse4c" aria-expanded="true" aria-controls="collapse4c">
                            Elenco dei progetti collegati al trasferimento selezionato: 
                        </button>
                    </h2>
                    <div id="collapse4c" class="accordion-collapse collapse show bd-form" role="region" aria-labelledby="heading4c">
                        <div class="accordion-body">
                            <div class="row">
                                <div id="divMostraProgetti" class="col-sm-12 mb-5">
                                    <Siar:DataGridAgid ID="dgTrasfDettaglioProgetti" CssClass="table table-striped" runat="server" PageSize="20" AllowPaging="True"
                                        AutoGenerateColumns="False" ShowFooter="true">
                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:BoundColumn DataField="IdProgetto" HeaderText="Num. Progetto">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Bando">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Stato Progetto">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Operatore Inserimento">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <Siar:IntegerTextBox Label="Id progetto:" ID="txtIdProgetto" runat="server" NomeCampo="ID Progetto"
                                        Style="text-align: left" NoCurrency="true" />
                                </div>
                                <div class="col-sm-6 text-start">
                                    <Siar:Button ID="btnAggiungiProgetto" runat="server" Text="Aggiungi Progetto"
                                        CausesValidation="False" OnClick="btnAggiungiProgetto_Click"></Siar:Button>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="accordion-item" id="divBandi" visible="false" runat="server">
                    <h2 class="accordion-header " id="heading5c">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapse5c" aria-expanded="true" aria-controls="collapse5c">
                            Elenco delle Procedure di Attivazione collegate al trasferimento selezionato - Organismi Intermedi : 
                        </button>
                    </h2>
                    <div id="collapse5c" class="accordion-collapse collapse show bd-form" role="region" aria-labelledby="heading5c">
                        <div class="accordion-body">
                            <div class="row">
                                <div id="divMostraBandi" class="col-sm-12 mb-5">

                                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgTrasfDettaglioBando" runat="server" PageSize="20" AllowPaging="True"
                                        AutoGenerateColumns="False" ShowFooter="true">
                                        <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:BoundColumn DataField="IdBando" HeaderText="Id Bando">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Bando">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Stato Bando">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn HeaderText="Operatore Inserimento">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                        </Columns>
                                    </Siar:DataGridAgid>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <Siar:ComboBandiOrganismiIntermedi Label="Selezionare la Procedura di Attivazione:" ID="lstBandi" runat="server"></Siar:ComboBandiOrganismiIntermedi>
                                </div>
                                <div class="col-sm-6">
                                    <Siar:Button ID="btnAggiungiBando" runat="server" Text="Aggiungi Bando"
                                        CausesValidation="False" OnClick="btnAggiungiBando_Click"></Siar:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
