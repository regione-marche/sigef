<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Cruscotto.aspx.cs" Inherits="web.Private.PDomanda.Cruscotto" %>

<%@ Register Src="~/CONTROLS/ucCruscotto.ascx" TagName="Cruscotto" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <div id="divCruscotto" class="row ">
        <uc1:Cruscotto ID="ucCruscotto" runat="server" />
    </div>

</asp:Content>
