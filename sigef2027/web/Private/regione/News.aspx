<%@ Page Async="true" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.regione.News" CodeBehind="News.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function modificaNews(id) { $('[id$=hdnIdNews]').val(id); $('[id$=btnPost]').click(); }
    function nuovaNews() {
        $('[id$=btnElimina]').disabled = true; $('[id$=hdnIdNews]').val(''); $('[id$=txtUrl_text]').val(''); $('[id$=txtNewsLunga_text]').val('');
        $('[id$=txtTitolo_text]').val(''); $('[id$=txtOraInizio]').val(''); $('[id$=txtOraFine]').val(''); $('[id$=txtMinutiInizio]').val('');
        $('[id$=txtMinutiFine]').val(''); $('[id$=txtDataInterruzione]').val(''); $('[id$=chkInterruzione]')[0].checked = false;
        abilitaDataInterruzione($('[id$=chkInterruzione]')[0]);
    }
    function ctrlOra(textbox) { var numero = Number(textbox.value); if (numero > 23 || numero < 0) { alert("Attenzione! Ora non valida."); textbox.select(); } }
    function ctrlMinuti(textbox) { var numero = Number(textbox.value); if (numero > 59 || numero < 0) { alert("Attenzione! Minuti non validi."); textbox.select(); } }
    function abilitaDataInterruzione(chkbox) { if (chkbox.checked) $('#tableInterruzione').fadeIn("slow"); else $('#tableInterruzione').fadeOut("slow"); }
    function bindEventi() {
        $('[id$=chkInterruzione]').click(function () { abilitaDataInterruzione(this); });
        abilitaDataInterruzione($('[id$=chkInterruzione]')[0]);
        $('[id$=txtOraInizio_text]').blur(function () { ctrlOra(this); });
        $('[id$=txtOraFine_text]').blur(function () { ctrlOra(this); });
        $('[id$=txtMinutiInizio_text]').blur(function () { ctrlMinuti(this); });
        $('[id$=txtMinutiFine_text]').blur(function () { ctrlMinuti(this); });
    }
//--></script>

    <div style="display: none">
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdNews" runat="server" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="News & Comunicazioni|Nuovo" />
    <div id="tbNews" runat="server" class="tableTab row">
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgNews" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                AutoGenerateColumns="False">
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="30px" HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn></asp:BoundColumn>
                    <asp:BoundColumn>
                        <ItemStyle HorizontalAlign="center" Width="140px" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbNuovo" runat="server" class="tableTab bd-form row pt-5">
        <div class="col-sm-6 form-group">
            <Siar:TextBox  Label="Titolo:" ID="txtTitolo" runat="server" Obbligatorio="True" MaxLength="255"
                NomeCampo="Titolo" />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:TextBox  ID="txtUrl" Label="Url:" runat="server" MaxLength="255" />
            <asp:RegularExpressionValidator ID="rfvUrl" runat="server" ControlToValidate="txtUrl"
                ErrorMessage="Url errato" ValidationExpression="http(s)?://.+"></asp:RegularExpressionValidator>
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtNewsLunga" runat="server" NomeCampo="News" Obbligatorio="True"
                Label="News:" Rows="6" />
        </div>
        <div class="col-sm-6 form-check">
            <asp:CheckBox ID="chkInvioTelegram" runat="server" Text="Invia la news anche via Telegram" />
        </div>
        <div class="col-sm-6 form-check">
            <asp:CheckBox ID="chkInterruzione" runat="server" Text="Interruzione per aggiornamenti" />
        </div>
        <div class="row mt-5" id="tableInterruzione">
            <div class="col-sm-4 form-group">
                <Siar:DateTextBoxAgid Label="Data interruzione:" ID="txtDataInterruzione" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:IntegerTextBox Label="Ora inizio:" ID="txtOraInizio" runat="server" MaxLength="2" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:IntegerTextBox Label="Minuto inizio:" ID="txtMinutiInizio" runat="server" MaxLength="2" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:IntegerTextBox Label="Ora fine:" ID="txtOraFine" runat="server" MaxLength="2" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:IntegerTextBox Label="Minuto fine:" ID="txtMinutiFine" runat="server" MaxLength="2" />
            </div>
        </div>
        <div>
            <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" OnClick="btnSalva_Click" />
            <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Modifica="True" OnClick="btnElimina_Click" Text="Elimina" />
            <input class="btn btn-secondary py-1" onclick="nuovaNews();" type="button" value="Nuova" />
        </div>
    </div>
</asp:Content>
