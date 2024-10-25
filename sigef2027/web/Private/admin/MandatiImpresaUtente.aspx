<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="MandatiImpresaUtente.aspx.cs" Inherits="web.Private.admin.MandatiImpresaUtente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
    function revocaMandato(id_mandato) { if (confirm('Attenzione! Revocare il mandato aziendale?')) { $('[id$=hdnIdMandato]').val(id_mandato); $('[id$=btnRevocaMandato]').click(); } }
    function ctrlCuaa(elem, ev) { var cf = $(elem).val(); if (cf != "") { if (!ctrlPIVA(cf) && !ctrlCodiceFiscale(cf)) { alert('Attenzione! Codice fiscale/P.Iva non verificato!'); return stopEvent(ev); } } }
    function checkCuaa(ev) { if ($('[id$=txtCFabilitato_text]').val() == "") { alert('Attenzione! Digitare il Codice fiscale/P.Iva dell`impresa.'); return stopEvent(ev); } }
 //--></script>

    <%-- <table class="tableNoTab" width="900px">--%>



    <div class="container-fluid shadow rounded-2 pt-4 bd-form">
        <h3 class="fw-bold py-4">Registrazione Mandati Impresa</h3>
        <div class="row pt-3">
            <div class="col-sm-9">
                <p class="py-1">
                    In questa pagina è possibile attribuire all'operatore selezionato le funzionalità
                <strong>gestione e inserimento/modifica</strong>
                    dei dati delle imprese agricole, ovvero la registrazione del mandato dell&#39;impresa.
           
                   <br />
                    A tal scopo è sufficiente inserire il <strong>Codice Fiscale</strong> (P.iva o C.F.) dell'impresa
            e definire l'intervallo temporaneo di validità,
            trascorso il quale l'operatore non potrà più operare per conto dell&#39;azienda.             
            <br />
                    A seguire si visualizza l&#39;elenco completo dei mandati attivi e scaduti in carico
            all&#39;operatore.
       
                </p>
            </div>
        </div>
    </div>

    <div class="tableTab py-3">
        <div class="container-fluid tableTab bd-form rounded-2">
            <h5 class="fw-semibold paragrafo_bold pt-4">Operatore selezionato</h5>
            <div class="row py-5">
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtCercaOperatore" Label="Ricerca C.F" CssClass="fw-semibold" runat="server" />
                </div>

                <div class="col-sm-2">
                    <Siar:Button ID="btCercaOperatore" runat="server" Text="Cerca Consulente" Modifica="False" OnClick="btCercaOperatore_Click" CausesValidation="false"></Siar:Button>
                </div>
            </div>
            <div class="row align-items-center py-3">
                <div class="form-group col-sm-2 ">
                    <Siar:TextBox ID="txtNominativoOperatore" runat="server" CssClass="fw-semibold" Label="Nominativo" ReadOnly="True" />

                </div>
                <div class="form-group col-sm-2">
                    <Siar:TextBox ID="txtCFOperatore" runat="server" CssClass="fw-semibold" Label="C.F." ReadOnly="True" />
                </div>

                <div class="form-group col-sm-2">
                    <Siar:TextBox Label="Ruolo" ID="txtRuoloOperatore" CssClass="fw-semibold" runat="server" ReadOnly="True" />
                </div>

                <div class="form-group col-sm-2">
                    <Siar:TextBox ID="txtEnteOperatore" CssClass="fw-semibold" Label="Ente" runat="server" ReadOnly="True" />
                </div>
            </div>


            <h5 class="fw-semibold paragrafo_light pt-5">Selezione dell&#39;impresa</h5>

            <div class="row mt-5">
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtCFabilitato" Label="C.F./P.Iva" CssClass="fw-semibold" runat="server" Obbligatorio="True" MaxLength="16" NomeCampo="Codice Fiscale dell`azienda" />
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnScaricaAT" runat="server" Text="Scarica dati anagrafici"
                        OnClick="btnScaricaAT_Click" Modifica="True" CausesValidation="False" OnClientClick="return checkCuaa(event);"></Siar:Button>
                </div>
                <div class="col-sm-4 offset-sm-2 pt-5">
                    <p>
                        <b>1)</b> Digitare il <b>Codice Fiscale</b> dell&#39;impresa desiderata e scaricare i dati anagrafici  
                    </p>
                    <p>
                        <b>2)</b> Se la procedura ha successo verrà visualizzata la ragione sociale dell&#39;impresa                
                    </p>
                    <p>
                        <b>3)</b> Digitare data inizio e data fine validità del mandato<br />
                    </p>
                </div>
            </div>
            <div class="row align-items-center py-3">
                <div class="col-sm-4 form-group">
                    <Siar:TextBox ID="txtRagSociale" CssClass="fw-semibold" Label="Ragione Sociale" runat="server" ReadOnly="True" />
                </div>
            </div>
            <div class="row align-items-center py-4">
                <div class="col-sm-2 form-group">
                    <Siar:DateTextBoxAgid ID="txtDataInizio" CssClass="fw-semibold" runat="server" Label="Data inizio validità" ReadOnly="True" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:DateTextBoxAgid ID="txtDataFV" CssClass="fw-semibold" runat="server" Label="Data fine validità" NomeCampo="Data fine validità" Obbligatorio="True"></Siar:DateTextBoxAgid>
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" Modifica="True"></Siar:Button>
                    <asp:HiddenField ID="hdnIdImpresa" runat="server" />
                </div>
            </div>


            <h5 class="fw-semibold paragrafo_bold pt-5">Elenco mandati in carico: (<asp:Label ID="lblNumeroAbilitati" runat="server"></asp:Label>)</h5>

            <div class="row align-items-center py-5 rounded-2">
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtRicercaCuaa" Label="Codice Fiscale" CssClass="fw-semibold" runat="server" MaxLength="16" />
                </div>
                <div class="col-sm-2 form-group">
                    <Siar:TextBox ID="txtRicercaRagioneSociale" CssClass="fw-semibold" Label="Ragione sociale" runat="server" />
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnRicerca" runat="server" CausesValidation="False" OnClick="btnRicerca_Click"
                        Text="Filtra" OnClientClick="return ctrlCuaa($('[id$=txtRicercaCuaa_text]'),event);" />
                </div>
            </div>
            <div class="d-flex flex-row py-4">
                <div class="col-sm-12">
                    <div class="table-responsive">
                        <Siar:DataGridAgid ID="dgMandati" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemStyle CssClass="DataGridRow itemStyle" />
                            <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="center" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn HeaderText="Codice Fiscale" DataField="Cuaa">
                                    <ItemStyle />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="P.Iva" DataField="CodiceFiscale">
                                    <ItemStyle />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Ragione Sociale" DataField="RagioneSociale"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Valido fino" DataField="DataFineValidita">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>

                        <div style="display: none">
                            <asp:HiddenField ID="hdnIdMandato" runat="server" />
                            <asp:Button ID="btnRevocaMandato" runat="server" OnClick="btnRevocaMandato_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
