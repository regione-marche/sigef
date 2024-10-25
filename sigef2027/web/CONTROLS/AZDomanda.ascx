<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.AZDomanda" CodeBehind="AZDomanda.ascx.cs" %>
<div id="tbAzioni" runat="server" class="col-sm-12">
    <h3 class="pb-5 mt-5">FASE 2: gestione lavori e domande pagamento</h3>
    <p>
        Questa sezione è accessibile qualora la domanda di aiuto abbia passato la fase di istruttoria e quindi sia stata ammessa a finanziamento. Si viene reindirizzati ad una pagina web di gestione lavori, ovvero richieste di varianti, variazioni finanziarie e adeguamenti tecnici, e di inserimento di domande di pagamento.

    </p>

    <button id="btnProsegui" runat="server" class="btn btn-primary py-1" type="button">
        <svg class="icon icon-breadcrumb icon-secondary icon-white me-1" aria-hidden="true">
            <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right"></use>
        </svg>Prosegui</button>
</div>
