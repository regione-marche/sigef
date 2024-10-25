<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Logout" CodeBehind="Logout.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        $(document).ready(function() {
            getDimensioniVisibili();
            $('#tab1').css({ 'left': scrollLeft+((clientWidth-650)/2),'top': scrollTop+((clientHeight-300)/2) });
            document.execCommand("ClearAuthenticationCache");
            window.setTimeout("document.location='HomePage.aspx'",7000);
        });		
//--></script>
    <table id="tab1" style="position: absolute; width: 520px">
        <tr>
            <td align="center" style="height: 130px; border-bottom: solid 1px black">
                <strong><font color="#006d51" size="+2" style="font-family: Verdana">Sessione terminata.
                </font><br /><br />
                    <font color="#006d51" style="font-family: Verdana">Reindirizzamento alla <a href="HomePage.aspx">
                        home page </a>del portale...</font></strong>
            </td>
        </tr>
        <tr valign="middle" align="center">
            <td style="height: 96px">
                <strong><font color="#006d51" style="font-family: Verdana"><a href="javascript:location='private/welcome.aspx'">
                    Accedi a Sigef</a>
                    <br />
                    <br />
                    (reindirizzamento alla pagina di autenticazione)</font></strong>
            </td>
        </tr>
    </table>
</asp:Content>
