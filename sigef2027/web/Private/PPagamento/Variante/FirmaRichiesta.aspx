<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Variante.FirmaRichiesta" CodeBehind="FirmaRichiesta.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/WorkFlowVarianti.ascx" TagName="WorkFlowVarianti"
    TagPrefix="uc2" %>
<%@ Register Src="../../../CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento"
    TagPrefix="uc1" %>
<%@ Register Src="../../../CONTROLS/FirmaDocumentoEsterna.ascx" TagName="ucFirmaEsternaAruba" TagPrefix="uc5" %>
<%@ Register Src="~/CONTROLS/CardVarianti.ascx" TagName="CardVarianti" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);
        });
    </script>
    <uc3:CardVarianti ID="ucCardVarianti" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkFlowVarianti ID="ucWorkflowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row py-5 mx-2">
                        <h2 class="pb-5">Firma e Rilascio della Richiesta</h2>
                        <p>Sotto elencati tutti i <b>requisiti di controllo</b> da soddisfare per poterb rilasciare la presente richiesta.</p>
                        <p>E' necessario soddisfare positivamente tutti i requisiti indicati come <b>OBBLIGATORI</b>.</p>
                        <h3 class="pb-5">Requisiti di controllo:</h3>
                        <div class="col-sm-12">
                            <Siar:DataGridAgid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" Width="100%">
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione requisito"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Obbligatorio" DataFormatString="{0:SI|NO}" HeaderText="Obbligatorio">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Esito della verifica">
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                            <div align="center" style="height: 50px">
                                <Siar:Button ID="btnVerifica" runat="server" Modifica="True" Text="Verifica requisiti"
                                    Width="200px" OnClick="btnVerifica_Click" />
                            </div>
                        </div>
                        <h4 class="pb-5">Termine procedura:</h4>
                        <p>
                            Qualora i suddetti requisiti di controllo siano soddisfatti, sarà possibile concludere la procedura di richiesta<br />
                            apponendo la <b>firma digitale</b> sul documento generato dal sistema.
                        </p>
                        <p>
                            Fatto la richiesta ciò verrà inviata al <b>protocollo</b> regionale<br />
                            in attesa della fase successiva ovvero l&#39;istruttoria della stessa.
                        </p>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnFirma" runat="server" Conferma="Attenzione, rendere la richiesta definitiva? Non sarà più possibile modificare i dati"
                                Text="Firma la richiesta" OnClick="btnFirma_Click" />
                            <Siar:Button ID="btnFirmaEsterna" runat="server" CausesValidation="False" Text="Scarica e presenta richiesta con firma esterna" Enabled="false" OnClick="btnFirmaEsterna_Click"
                                Modifica="True" />
                            <input type="button" class="btn btn-secondary py-1" id="btnStampaRicevuta" runat="server" value="Ricevuta di protocollazione" disabled="disabled" />
                        </div>

                        <div class="col-sm-12" id="rowProtocolliAllegati" visible="false" runat="server">
                            <Siar:Button ID="btnProtocollaAllegati" runat="server" CausesValidation="False"
                                Text="Protocolla allegati" Enabled="false" OnClick="btnProtocollaAllegati_Click"
                                Modifica="True" />
                        </div>

                        <div class="row pt-5" id="trPredisposizione" runat="server">

                            <h4 class="pb-5">Predisposizione alla firma della domanda:</h4>
                            <p>
                                <b>FACOLTATIVO</b>: la predisposizione alla firma è la modalità di presentazione della domanda di aiuto per i casi di <b>firma differita.</b>
                            </p>
                            <p>
                                Ovvero questa modalità prevede il congelamento della domanda in tutte le sue sezioni, quindi non piu&#39; modificabile, in attesa della firma finale da parte del <b>rappresentante legale</b> dell&#39;impresa o di altro soggetto titolato, che potrà eseguire il successivo rilascio da una qualsiasi postazione egli abbia a disposizione. 
                            </p>
                            <p>
                                Ciò è utile nei casi in cui il firmatario non può essere presente nella stessa sede in cui si trova l&#39;operatore che compila la domanda.
                            </p>
                            <p>
                                Tale predisposizione può essere sempre annullata <b>prima del rilascio</b> per eseguire correzioni o adeguamenti finali.
                            </p>

                            <div class="col-sm-12 text-center">
                                <Siar:Button ID="btnPredisponi" runat="server" Text="Predisponi alla firma"
                                    CausesValidation="false" Conferma="Attenzione! Predisporre la domanda di aiuto alla firma da remoto?"
                                    OnClick="btnPredisponi_Click" Modifica="False" Enabled="False" />
                            </div>
                        </div>
                    </div>
                    <div id="containerCopiaPulsanti" class="row py-5 steppers">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" Titolo="FIRMA DIGITALE DELLA VARIANTE\A.T." TipoDocumento="VARIANTE" />
        <uc5:ucFirmaEsternaAruba ID="modaleFirmaEsterna" runat="server"
            TipoDocumento="VARIANTE"
            TitoloControllo="FIRMA DIGITALE ESTERNA DELLA VARIANTE\A.T." />
    </div>
</asp:Content>
