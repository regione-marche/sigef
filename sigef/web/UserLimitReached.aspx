<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="UserLimitReached.aspx.cs" Inherits="web.UserLimitReached" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <div class="dBox">
        <div class="separatore">RAGGIUNTO LIMITE DI UTENTI CONNESSI</div>
        <br />

        <div style="padding: 10px;">
            <div>
                Il Sigef ha raggiunto il limite di utenti connessi contemporaneamente, si prega di riprovare più tardi.
            <br />
                <br />
                <Siar:Button ID="btnHomePage" runat="server" Text="Torna alla HomePage" OnClick="btnHomePage_Click" />
            </div>
        </div>
    </div>
    

</asp:Content>