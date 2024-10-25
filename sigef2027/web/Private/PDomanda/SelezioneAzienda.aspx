<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.SelezioneAzienda" CodeBehind="SelezioneAzienda.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlCuaaDitta(ev) {
        var text_box_cuaa = $('[id$=txtCuaaRicerca_text]')[0]; var cuaa = $(text_box_cuaa).val(); cuaa = $.trim(cuaa);
        if (cuaa != null && cuaa != "" && !ctrlCodiceFiscale(cuaa) && !ctrlPIVA(cuaa)) {
            alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.'); return stopEvent(ev);
            //$(text_box_cuaa).select();
        }
    }
    function scaricaAnagrafica(cuaa) { $('[id$=txtCuaaRicerca_text]').val(cuaa); $('[id$=btnCercaWS]').click(); }

    function switchMostraInserisciImpresa() {
        var div = $('[id$=divInserisciImpresa]');
        var btn = $('[id$=btnInserisciImpresa]')[0];

        if (div[0].style.display === "none") {
            div.show("fast");
            btn.value = "Nascondi inserisci impresa";
        } else {
            div.hide("fast");
            btn.value = "Mostra inserisci impresa";
        }
    }

    function controllaAutodichiarazione() {
        var btn = $('[id$=btnSalvaConDichiarazione]')[0];

        if (($('[id$=chckAutodichiarazione]')[0].checked)) {
            btn.disabled = false;
        }
        else {
            btn.disabled = true;
        }
    }

    function pageLoad() {
        controllaAutodichiarazione();
    }

//--></script>

    <div class="row pb-5 mx-2">
        <h3 class="pb-5">Presentazione della domanda di aiuto</h3>
        <p>
            Specificare il <b>Codice Fiscale</b> o la <b>Ragione sociale</b> dell'impresa per cui presentare la domanda di aiuto.<br />
            Qualora l'azienda non fosse presente nel <b>database regionale</b> effettuare il download dei dati dall'<b>Anagrafe Tributaria</b>.<br />
            La ricerca viene effettuata tra i soggetti per cui l'utente e' abilitato a operare, nel caso in cui l&#39;impresa desiderata non venga trovata, o per qualsiasi altra segnalazione si prega di contattare l'helpdesk.
        </p>
        <h4 class="pb-5">Selezione dell'impresa beneficiaria:</h4>
        <div class="row pt-3">
            <div class="form-group col-sm-6">
                <Siar:TextBox Label="Ricerca per Codice Fiscale:" ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale" Style="text-align: left" />
                <p>
                    (inserire il codice fiscale dell'impresa/ente da ricercare)
                </p>
            </div>
            <div class="form-group col-sm-6">
                <Siar:TextBox Label="Ricerca per ragione sociale:" ID="txtRagSociale" runat="server" />
                <p>
                    (consigliato digitare una sola parola o parte di essa)
                </p>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-sm-12">
                <Siar:Button ID="btnCercaDB" runat="server" Width="220px" Text="Cerca sul database locale"
                    CausesValidation="False" OnClick="btnCercaDB_Click"></Siar:Button>
                <input runat="server" id="btnInserisciImpresa" type="button" visible="false"
                    class="btn btn-primary py-1" value="Mostra inserisci impresa" onclick="switchMostraInserisciImpresa();" />
                <Siar:Button ID="btnCercaWS" runat="server" Visible="false"
                    Width="220px" Text="Cerca su Anagrafe Tributaria" OnClick="btnCercaWS_Click"
                    CausesValidation="TRUE"></Siar:Button>
            </div>
        </div>
        <div class="row pt-3">
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" PageSize="15" AllowPaging="True" AutoGenerateColumns="False">
                    <ItemStyle Height="30px"></ItemStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Right" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione sociale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Cuaa" HeaderText="Codice Fiscale">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Cf/P.Iva">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid><br />
            </div>
        </div>
    </div>
    <div runat="server" id="divInserisciImpresa" class="row pb-5 mx-2" style="display: none;">
        <h4 class="pb-5">Inserisci una nuova impresa</h4>
        <div class="col-sm-12">
            <div class="row">
                <p>Prima di inserire una nuova impresa verificare che non esista già!</p>
                <p><b>TUTTI I CAMPI SONO OBBLIGATORI</b></p>
                <div class="form-check col-sm-12">
                    <asp:CheckBox ID="chckAutodichiarazione" runat="server" Text="DICHIARAZIONE SOSTITUTIVA DELL’ATTO DI NOTORIETA’" onchange="controllaAutodichiarazione();" />
                    <label for="chckAutodichiarazione">
                        Il sottoscritto, in qualità di legale rappresentante oppure persona da lui delegata, 
                consapevole delle responsabilità anche penali derivanti dal rilascio di dichiarazioni mendaci 
                ai sensi degli articoli 75 e 76 del D.P.R. 445/2000, dichiara ai sensi dell’articolo 47 del D.P.R. 445/2000:<br />
                        - di essere autorizzato, all'inserimento dei dati anagrafici del soggetto richiedente necessari e utili ai fini della 
                presentazione di istanze sul sistema informatico della Regione Marche. Il sottoscritto si impegna inoltre a rendere la 
                necessaria documentazione ai fini istruttori.<br />
                    </label>
                </div>
            </div>
            <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True"
                ClassificazioneUmaVisibile="false" InserisciImpresaPerPresentazioneDomanda="True" />
        </div>
    </div>
</asp:Content>
