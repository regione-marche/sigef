<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.Private.Welcome"
    CodeBehind="Welcome.aspx.cs" %>

<%@ Register Src="../CONTROLS/ucCruscotto.ascx" TagName="Cruscotto" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function SNCVZCercaUtenti_onselect(obj) { if(obj) { $('[id$=hdnIdUtenteAlias]').val(obj.IdUtente);$('[id$=txtOperatoreAlias_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtenteAlias]').val(''); } 
    //--></script>

<%--    <div id="divOperatoreAlias" class="dBox" runat="server" visible="false">
        <div class="separatore">Account:</div>
        <div style="padding: 15px;">
            <label for="txtOperatoreAlias" style="padding-right: 20px;">
                Seleziona l'operatore: 
                <Siar:TextBox ID="txtOperatoreAlias" runat="server" Width="384px" />
            </label>
            <Siar:Button ID="btnAlias" runat="server" OnClick="btnAlias_Click" Text="Set alias" Width="150px" />
            <asp:HiddenField ID="hdnIdUtenteAlias" runat="server" />
        </div>
    </div>--%>
    <div id="divCruscotto">
        <uc1:Cruscotto id="ucCruscotto" runat="server" />
    </div>
</asp:Content>
