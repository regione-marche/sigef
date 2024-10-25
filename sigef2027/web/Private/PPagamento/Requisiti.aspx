<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.Requisiti" CodeBehind="Requisiti.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc2" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function selezionaPlurivalore(jobj) {
            if (jobj == null)
                alert('L`elemento selezionato non è valido.');
            else {
                $('[id$=lblPlurivaloreSelezionato' + jobj.IdRequisito + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionato' + jobj.IdRequisito + ']').val(jobj.IdValore);
            }
        }
        function deselezionaPlurivalore(id) {
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionato' + id + ']').val('');
        }

        $(document).ready(function () {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);
        });
    </script>
    <uc3:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <!-- Esempio START -->
                    <div class="row py-5 mx-2" visible="true">
                        <h3>Requisiti Soggettivi</h3>
                        <p>
                            Di seguito vengono elencati i requisiti soggettivi richiesti dallo specifico bando e dalle disposizioni attuative attuative.
                        </p>
                        <p>
                            Tali requisiti possono attribuire sia maggior punteggio in graduatoria che una maggior pecentuale di contributo pubblico sugli investimenti del piano di sviluppo.
                        </p>
                    </div>

                    <div id="tdControls" class="row py-5 mx-2" runat="server"></div>

                    <div class="row py-5 mx-2">
                        <uc2:ProgettoIndicatori ID="ucProgettoInd" runat="server" />

                        <div style="height: 50px" align="center">
                            <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva i requisiti"
                                Modifica="true" Width="200px" />
                        </div>

                    </div>
                </div>
                <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
            </div>
            <!-- Esempio END -->
        </div>
    </div>
</asp:Content>
