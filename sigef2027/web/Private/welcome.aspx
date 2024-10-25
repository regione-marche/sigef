<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.Welcome"
    CodeBehind="Welcome.aspx.cs" %>

<%@ Register Src="../CONTROLS/ucCruscotto.ascx" TagName="Cruscotto" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function SNCVZCercaUtenti_onselect(obj) { if (obj) { $('[id$=hdnIdUtenteAlias]').val(obj.IdUtente); $('[id$=txtOperatoreAlias_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
    function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtenteAlias]').val(''); }
    //--></script>

    <%--    <div id="divOperatoreAlias" class="dBox" runat="server" visible="false">
        <div class="separatore">Account:</div>
        <div style="padding: 15px;">
            <label for="txtOperatoreAlias" style="padding-right: 20px;">
                Seleziona l'operatore: 
                <Siar:TextBox  ID="txtOperatoreAlias" runat="server" Width="384px" />
            </label><asp:GridView runat="server"></asp:GridView>
            <Siar:Button ID="btnAlias" runat="server" OnClick="btnAlias_Click" Text="Set alias" Width="150px" />
            <asp:HiddenField ID="hdnIdUtenteAlias" runat="server" />
        </div>
    </div>--%>
    <div class="row justify" id="divCruscotto">
        <%--<div class="container-fluid border-bottom">
            <div class="container p-2">
                <div class="col-sm-12">
                    <h1>Cruscotto</h1>
                    <p>In questa sezione è diponibile un riepilogo di tutte le pratiche collegate alla propria utenza</p>
                </div>
            </div>
        </div>--%>
        <div class="row">
            <uc1:Cruscotto ID="ucCruscotto" runat="server" />
        </div>
    </div>
</asp:Content>
