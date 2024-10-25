<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" Inherits="web.Private.PPagamento.VisualizzaModifica" CodeBehind="VisualizzaModifica.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ucVisualizzaModifica.ascx" TagName="VisualizzaModifica" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <uc1:VisualizzaModifica ID="ucVisualizzaModifica" runat="server" />

</asp:Content>