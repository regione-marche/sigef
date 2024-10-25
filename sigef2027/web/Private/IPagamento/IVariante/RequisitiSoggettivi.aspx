<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.RequisitiSoggettivi" CodeBehind="RequisitiSoggettivi.aspx.cs" %>


<%@ Register Src="~/CONTROLS/ProgettoIndicatori.ascx" TagName="ProgettoIndicatori" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc2" %>
<%@ Register Src="~/CONTROLS/WorkFlowVariantiIstruttoria.ascx" TagName="WorkFlowVariantiIstruttoria" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function selezionaPlurivalore(jobj) 
        {
            if (jobj == null) 
                alert('L`elemento selezionato non è valido.');
            else 
            {
                $('[id$=lblPlurivaloreSelezionato' + jobj.IdPriorita + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionato' + jobj.IdPriorita + ']').val(jobj.IdValore);
            } 
        }
        function deselezionaPlurivalore(id) 
        {
            $('[id$=lblPlurivaloreSelezionato' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionato' + id + ']').val(''); 
        }
        function selezionaPlurivaloreSql(jobj) 
        {
            if (jobj == null) 
            alert('L`elemento selezionato non è valido.');
            else 
            {
                $('[id$=lblPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').text(jobj.Descrizione);
                $('[id$=hdnPlurivaloreSelezionatoSql' + jobj.IdPriorita + ']').val(jobj.Codice);
            } 
        }
        function deselezionaPlurivaloreSql(id) 
        {
            $('[id$=lblPlurivaloreSelezionatoSql' + id + ']').text('');
            $('[id$=hdnPlurivaloreSelezionatoSql' + id + ']').val(''); 
        }

        $(document).ready(function () {
            let $el = $('.steppers-nav').clone();
            $('#containerCopiaPulsanti').append($el);
        });
    </script>

    <uc2:CardVariantiIstruttoria ID="ucCardVariantiIstruttoria" runat="server" />
    <div class="row pt-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc3:WorkFlowVariantiIstruttoria ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form pt-5 mx-2">
                        <div class="form-group col-sm-12">
                            <h2 class="pb-5">Requisiti Soggettivi</h2>
                            <p class="pb-5">
                                Elenco dei requisiti soggettivi definiti dal bando di gara: tali requisiti possono
                attribuire sia punti in graduatoria<br />
                                che maggiori percentuali di aiuto ammissibile per gli investimenti.

                            </p>
                            <p class="pb-5">
                                Nel caso in cui il bando attivi più tipologie di intervento<br />
                                si richiedere di specificare tali requisiti per tutte quelle per le quali si intende
                            chiedere il finanziamento.
                            </p>
                        </div>
                        <div class="form-group col-sm-12">
                            <div id="rowControls" runat="server" />
                        </div>
                        <uc1:ProgettoIndicatori ID="ucProgettoInd" runat="server" />
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" Text="Ammetti" runat="server" Modifica="True" OnClick="btnSalva_Click" Width="160px" />
                        </div>
                    </div>
                     <div id="containerCopiaPulsanti" class="row py-5 steppers">
                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
