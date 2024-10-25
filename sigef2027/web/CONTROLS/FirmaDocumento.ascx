<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FirmaDocumento.ascx.cs"
    Inherits="web.CONTROLS.FirmaDocumento" %>
<%@ Register Src="FirmaDocumentoApplet.ascx" TagName="FirmaDocumentoApplet" TagPrefix="uc1" %>
<%@ Register Src="FirmaDocumentoCalamaio.ascx" TagName="FirmaDocumentoCalamaio" TagPrefix="uc1" %>
<%--<asp:Label ID="lblTitolo" runat="server" Text=""></asp:Label>--%>
<asp:PlaceHolder runat="server" ID="plc">
    <uc1:FirmaDocumentoApplet runat="server" ID="ucFirmaDocumentoApplet" />
    <uc1:FirmaDocumentoCalamaio runat="server" ID="ucFirmaDocumentoCalamaio" />
</asp:PlaceHolder>
