<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZoomLoader.ascx.cs"
    Inherits="web.CONTROLS.ZoomLoader" %>
<div class="col-sm-12">
    <svg class="icon" id="imgZApri" style="cursor: pointer;" runat="server" alt="Apri la finestra di ricerca">
        <use href="/web/bootstrap-italia/svg/sprites.svg#it-folder"></use>
    </svg>
    <svg class="icon" id="imgZChiudi" src="" runat="server" alt="Cancella la selezione" style="cursor: pointer;">
        <use href="/web/bootstrap-italia/svg/sprites.svg#it-close"></use>
    </svg>
    <%--    <img id="imgZApri" src="" runat="server" alt="Apri la finestra di ricerca" onmouseover="this.style.cursor='pointer';" />
    <img id="imgZChiudi" src="" runat="server" alt="Cancella la selezione" onmouseover="this.style.cursor='pointer';" />--%>
    <Siar:Hidden ID="hdnSNZSelectedValue" runat="server">
    </Siar:Hidden>
    <Siar:Hidden ID="hdnSNZSelectedText" runat="server">
    </Siar:Hidden>
    <asp:Label ID="lblSNZSelectedText" runat="server"></asp:Label>
</div>
<%--<div id="tbZoomMain" runat="server" style="display: none; position: absolute;">--%>
<div id="tbZoomMain" runat="server" class="modal it-dialog" tabindex="-1" role="dialog" style="display: none;">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h4 id="tdZLTitolo" runat="server">Finestra di ricerca</h4>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-12">
                        <div id="tdParametri" runat="server"></div>
                    </div>

                    <div class="col-md-12 mt-3">
                        <input id="btnCerca" class="btn btn-secondary py-1 text-white" runat="server" type="button" value="Cerca" />
                        <input type="button" class="btn btn-secondary py-1 text-white" value="Chiudi" onclick="chiudiPopupTemplate()" />
                    </div>
                    <div class="col-md-12">
                        <div id="divZoomResult" runat="server">
                            <b><em>Iniziare la ricerca.</em></b>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
