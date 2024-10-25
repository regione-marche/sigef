<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.PPagamento.CheckList" CodeBehind="CheckList.aspx.cs" %>

<%@ Register Src="../../CONTROLS/WorkflowPagamento.ascx" TagName="WorkflowPagamento" TagPrefix="uc1" %>
<%@ Register Src="../../CONTROLS/CardPagamento.ascx" TagName="CardPagamento" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript"><!--    
    $(document).ready(function () {
        let $el = $('.steppers-nav').clone();
        $('#containerCopiaPulsanti').append($el);
    });


//--></script>
    <uc2:CardPagamento ID="ucCardPagamento" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkflowPagamento ID="ucWorkflowPagamento" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <!-- Esempio START -->
                    <div class="row py-5 mx-2" visible="true">
                        <h3>Checklist di Controllo della domanda di pagamento</h3>
                        <p>Di seguito vengono elencati tutti i requisiti, suddivisi per misura, che la domandadi pagamento deve soddisfare.</p>
                        <p>Per quelli <b>OBBLIGATORI</b> è richiesto l' <b>esito positivo</b>, in caso contrario non sarà possibile presentare la domanda.</p>
                    </div>
                    <div id="tdControls" class="row py-5 mx-2" runat="server"></div>
                    <div class="row py-5 mx-2">
                        <div align="center" style="height: 66px">
                            <Siar:Button ID="Button1" runat="server" CausesValidation="False" Modifica="True"
                                OnClick="btnVerifica_Click" Text="Verifica requisiti" Width="210px" />
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
