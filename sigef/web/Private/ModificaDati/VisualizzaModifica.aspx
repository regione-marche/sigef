<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="VisualizzaModifica.aspx.cs" Inherits="web.Private.ModificaDati.VisualizzaModifica" %>

<%@ Register Src="~/CONTROLS/ucVisualizzaModifica.ascx" TagName="VisualizzaModifica" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <uc1:VisualizzaModifica ID="ucVisualizzaModifica" runat="server" />

</asp:Content>
