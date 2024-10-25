<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Logout" CodeBehind="Logout.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    $(document).ready(function () {
        getDimensioniVisibili();
        //$('#tab1').css({ 'left': scrollLeft + ((clientWidth - 650) / 2), 'top': scrollTop + ((clientHeight - 300) / 2) });
        document.execCommand("ClearAuthenticationCache");
        window.setTimeout("document.location='HomePageAgid.aspx'", 7000);
    });
//--></script>
    <div id="tab1" class="row">
        <div class="col-sm-12 text-center">
            <h3>Sessione terminata.</h3>
            <p>Reindirizzamento alla <a href="HomePageAgid.aspx">home page </a>del portale...</p>
            <p><a href="javascript:location='private/welcome.aspx'">Accedi a Sigef</a></p>
            <p>
                (reindirizzamento alla pagina di autenticazione)
            </p>
        </div>

    </div>
</asp:Content>
