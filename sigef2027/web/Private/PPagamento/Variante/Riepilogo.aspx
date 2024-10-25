<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.Riepilogo" CodeBehind="Riepilogo.aspx.cs" %>

<%@ Register Src="~/CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/CardVarianti.ascx" TagName="CardVarianti" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function ctrlCuaa(ev) {
        var text_box_cuaa = $('[id$=txtCuaaEntrante_text]'); var cuaa = $(text_box_cuaa).val().replace(/\s/g, '');
        if (cuaa != '' && !ctrlCodiceFiscale(cuaa) && !ctrlPIVA(cuaa)) { alert('Attenzione! Il Codice fiscale specificato non è valido.'); return stopEvent(ev); }
    }

    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });
 //--></script>

    <div style="display: none">
        <input type="hidden" id="hdnIdImpresaEntrante" runat="server" />
    </div>
    <uc3:CardVarianti ID="ucCardVarianti" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVarianti ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form pt-5 mx-2">
                        <div class="form-group col-sm-12">
                            <h2 class="pb-5">Riepilogo dati della richiesta</h2>
                            <p>
                                In questa pagina e' possibile <b>modificare</b> la modalità della modifica al piano degli investimenti che si intende  richiedere ed inserire una breve <b>descrizione tecnica</b> della stessa 
                            </p>
                            <p>
                                E' inoltre possibile <b>annullare</b> l'attuale richiesta e <b>cambiare il beneficiario</b> dell'aiuto.
                            </p>
                        </div>

                        <div class="form-group col-sm-4">
                            <Siar:ComboBase Label="Modalità:" ID="lstModalita" runat="server" NomeCampo="Modalita" Enabled="false"></Siar:ComboBase>
                        </div>
                        <div class="form-group col-sm-12">
                            <Siar:TextArea Label="Descrizione tecnica: (max 1000 caratteri)" ID="txtDescrizione" runat="server" Rows="5" MaxLength="1000" ExpandableRows="5" />
                        </div>
                        <div class="form-group col-sm-12">
                            <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva le modifiche" OnClick="btnSalva_Click" />
                        </div>
                    </div>
                    <div class="row bd-form pt-5 mx-2">
                        <h4 class="pb-5">Annullamento della richiesta:</h4>
                        <p>
                            Questa procedura <b>cancellerà completamente</b> dal sistema la presente richiesta come se non fosse mai stata inserita e
                         l`impresa potrà inserirne una nuova.
                        </p>
                        <p>
                            E' possibile utilizzarla quando ancora non è stata firmata ed è consigliato utilizzarla quando
                            le modifiche da eseguire sulla stessa siano più onerose che inserirne una nuova.
                        </p>
                        <div class="text-center col-sm-12">
                            <Siar:Button ID="btnAnnullamento" runat="server" Modifica="True" Text="Annulla la richiesta"
                                CausesValidation="False" Conferma="Attenzione! La richiesta verrà cancellata dal sistema con tutte le modifiche effettuate. Continuare?"
                                OnClick="btnAnnullamento_Click" />
                        </div>
                    </div>
                    <div class="row bd-form pt-5 mx-2">
                        <h4 class="pb-5">Richiesta di cambio beneficiario dell'aiuto:</h4>
                        <p>
                            La richiesta deve essere effettuata dal <b>beneficiario uscente</b> che attribuisce
                                all'entrante l'assegnazione<br />
                            del contributo alla domanda di aiuto relativa.
                        </p>
                        <p>
                            Tale domanda e tutte le relative richieste di pagamento cambieranno 
                                 intestazione e l'azienda uscente comparira' solo nello storico dell'iter procedurale.
                        </p>
                        <p>
                            Per continuare digitare il <b>nuovo codice fiscale</b> nella casella relativa e click su <b>Ottieni Dati Anagrafici.</b>
                        </p>
                        <h5 class="pb-5">Beneficiario uscente:</h5>
                        <div class="form-group col-sm-12">
                            <div class="row">
                                <div class="form-group col-sm-3">
                                    <Siar:TextBox  Label="Codice fiscale:" ID="txtCuaaUscente" runat="server" ReadOnly="True" />
                                </div>
                                <div class="form-group col-sm-3">
                                    <Siar:TextBox  CssClass=" " Label="Ragione Sociale" ID="txtRagSocUscente" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                        </div>
                        <h5 class="pb-5">Beneficiario entrante:</h5>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="form-group col-sm-3">
                                    <Siar:TextBox  Label="Codice fiscale:" ID="txtCuaaEntrante" runat="server" />
                                </div>
                                <div class="col-sm-3">
                                    <Siar:Button ID="btnScarica" runat="server" Modifica="True" Text="Ottieni dati anagrafici"
                                        OnClick="btnScarica_Click" OnClientClick="return ctrlCuaa(event);" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="row">
                                <div class="form-group col-sm-3">
                                    <Siar:TextBox  Label=" P.Iva:" ID="txtPivaEntrante" runat="server" ReadOnly="True" />
                                </div>
                                <div class="form-group col-sm-3">
                                    <Siar:TextBox  Label="Ragione Sociale:" ID="txtRagSocEntrante" runat="server" ReadOnly="True" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnCambiaBeneficiario" runat="server" Modifica="False" Text="Assegna nuovo beneficiario"
                                OnClick="btnCambiaBeneficiario_Click" Enabled="False" />
                        </div>
                    </div>
                    <div id="containerCopiaPulsanti" class="row py-5 steppers">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
