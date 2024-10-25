<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.DatiAnagrafici" CodeBehind="DatiAnagrafici.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        $(document).ready(function() {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);           
        });
    </script>
    <uc4:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc2:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
            </div>
            <div class="steppers-content" aria-live="polite">
                <!-- Esempio START -->
                <div class="row py-5 mx-2" visible="true">
                    <h3 class="pb-5">Inizio procedura guidata per la domanda di pagamento</h3>
                    <p>
                        La procedura guidata consente di navigare nelle pagine, da compilare con i dati richiesti dalle stesse, previste dalla tipologia di domanda di pagamento richiesta.
                    </p>
                    <p>
                        I pulsanti colorati in verde consentiranno di seguire un ordine cronologico nella navigazione delle sezioni di cui è richiesta la compilazione.
                    </p>
                </div>
                <div id="tableSanzioni" class="row py-5 mx-2" runat="server">
                    <h3 class="pb-5">Elenco delle sanzioni applicate alla domanda di pagamento:</h3>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgSanzioni" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" Width="100%">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="Titolo" HeaderText="Descrizione"></asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Center" Width="160px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Ammontare" DataFormatString="{0:c}" HeaderText="Ammontare">
                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                    </div>
                    <div align="center" valign="middle">
                        <img alt="Avviso di applicazione sanzione" src="../../images/warning.gif" />
                        &nbsp;
                            <br />
                        <br />
                        <b>La presente domanda di pagamento sarà soggetta a sanzione.</b>
                    </div>
                </div>
                <div id="tableElencoPagamento" runat="server" class="row py-5 mx-2" visible="true">
                    <h3 class="pb-5">Monitoraggio stato di avanzamento del pagamento:
                    </h3>
                    <div class="col-sm-12">
                        <Siar:DataGridAgid ID="dgElencoPagamento" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" Width="900px" EnableViewState="False">
                            <ItemStyle Height="24px" />
                            <Columns>
                                <asp:BoundColumn HeaderText="Programmazione">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="110px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdElencoPagamento" HeaderText="Identificativo elenco">
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Barcode">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Esportato" DataFormatString="{0:SI|NO}" HeaderText="Esportato ad AGEA">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DataEsportazione" HeaderText="Data di esportazione ad AGEA">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Num. Decreto AGEA">
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data Decreto AGEA">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo Liquidato">
                                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGridAgid>
                        <div width="900px" id="tableElenchiPagamentoLegenda" runat="server">

                            <div align="right" style="width: 600px">
                                (
                            </div>
                            <div style="width: 11px; background-color: #ccccb3">
                            </div>
                            <div>
                                = misure per cui non è stato richiesto pagamento)
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row py-5 mx-2">
                    <h4 class="pb-5">Annullamento della domanda di pagamento</h4>
                    <p>
                        Questa procedura cancellerà completamente dal sistema questa domanda come se non fosse mai stata inserita e l`impresa potrà inserirne una nuova.
                    </p>
                    <p>
                        E' possibile utilizzarla quando la domanda non è ancora resa definitiva ed è consigliato utilizzarla quando le modifiche da eseguire sulla stessa siano più onerose che inserirne una nuova.
                    </p>
                    <div class="text-center">
                        <Siar:Button ID="btnElimina" runat="server" Conferma="Attenzione! Questo eliminerà completamente la domanda di pagamento dal sistema. Continuare?"
                            Text="Annulla la domanda di pagamento" OnClick="btnElimina_Click" Modifica="true"
                            CausesValidation="False" />
                    </div>
                    <h4 class="pb-5 mt-5">Dati anagrafici dell'azienda:</h4>
                    <p>Sotto elencati i dati anagrafici dell'azienda attualmente presenti nella banca dati.</p>
                    <p>Qualora fossero variati si consiglia di effettuare il download della situazione aggiornata dalla anagrafe tributaria e successivamente effettuare le altre modifiche necessarie usando i pulsanti appositi.</p>
                    <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ClassificazioneUmaVisibile="false" ContoCorrenteVisibile="true" />
                </div>
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
            <!-- Esempio END -->
        </div>
    </div>
</asp:Content>
