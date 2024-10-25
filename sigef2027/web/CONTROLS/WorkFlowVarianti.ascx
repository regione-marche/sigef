<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.WorkFlowVarianti"
    CodeBehind="WorkFlowVarianti.ascx.cs" %>
<%@ Register Src="SNCVisualizzaProtocollo.ascx" TagName="SNCVisualizzaProtocollo"
    TagPrefix="uc1" %>
<%@ Register Src="VisualizzaReport.ascx" TagName="VisualizzaReport" TagPrefix="uc2" %>

<div class="steppers-header">
    <ul>
        <asp:Repeater ID="rptSteppers" runat="server">
            <ItemTemplate>
                <!-- confirmed -->
                <li class="<%# (WorkflowCorrente.Ordine == int.Parse(Eval("Ordine").ToString())) ? "active" : "confirmed" %>">
                    <a class="steppers-link" type="button" title="<%# Eval("Descrizione") %>" href="<%# Eval("Url") %>">
                        <svg class="icon icon-lg ">
                            <use href="/web/bootstrap-italia/svg/sprites.svg#it-arrow-right"></use>
                        </svg>
                        <span class="steppers-text"><%# Eval("Descrizione") %><%# (WorkflowCorrente.Ordine == int.Parse(Eval("Ordine").ToString())) ? "<span class='visually-hidden'>Attivo</span>" : (WorkflowCorrente.Ordine < int.Parse(Eval("Ordine").ToString())) ? "" : "<svg class='icon steppers-success'><use href='/web/bootstrap-italia/svg/sprites.svg#it-check'></use></svg><span class='visually-hidden'>Confermato</span>" %></span>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
  <%--  <span class="steppers-index" aria-hidden="true">2/6</span>--%>
</div>
<nav class="steppers-nav">
    <button type="button" id="btnPrec" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-prev">
        <svg class="icon icon-primary">
            <use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-left"></use></svg>Indietro
    </button>
    <button type="button" id="btnSucc" runat="server" class="btn btn-outline-primary btn-sm steppers-btn-next">
        Avanti<svg class="icon icon-primary"><use href="/web/bootstrap-italia/svg/sprites.svg#it-chevron-right"></use></svg>
    </button>
</nav>


<%--<table>
    <tr>
        <td align="left">
            <input class="ButtonProsegui" onclick="location = 'Riepilogo.aspx'" type="button" value="Riepilogo"
                style="width: 76px" />
            &nbsp;<input class="ButtonProsegui" onclick="location = 'PianoInvestimenti.aspx'" type="button"
                value="Modifica investimenti" style="width: 137px" />&nbsp;
                       
            <input class="ButtonProsegui" onclick="location = 'Allegati.aspx'" type="button" value="Allegati"
                style="width: 75px" />&nbsp;
                       
            <input class="ButtonProsegui" onclick="location = 'FirmaRichiesta.aspx'" type="button"
                value="Firma richiesta" style="width: 110px" />
            <input class="ButtonProsegui" onclick="location = 'Localizzazione.aspx'" type="button"
                value="Localizzazione" style="width: 110px" />
        </td>
    </tr>
</table>--%>
