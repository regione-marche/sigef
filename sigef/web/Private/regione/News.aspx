<%@ Page Async="true" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.regione.News" CodeBehind="News.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function modificaNews(id) { $('[id$=hdnIdNews]').val(id);$('[id$=btnPost]').click(); }
        function nuovaNews() {
            $('[id$=btnElimina]').disabled=true;$('[id$=hdnIdNews]').val('');$('[id$=txtUrl_text]').val('');$('[id$=txtNewsLunga_text]').val('');
            $('[id$=txtTitolo_text]').val('');$('[id$=txtOraInizio]').val('');$('[id$=txtOraFine]').val('');$('[id$=txtMinutiInizio]').val('');
            $('[id$=txtMinutiFine]').val('');$('[id$=txtDataInterruzione]').val('');$('[id$=chkInterruzione]')[0].checked=false;
            abilitaDataInterruzione($('[id$=chkInterruzione]')[0]);
        }
        function ctrlOra(textbox) { var numero=Number(textbox.value);if(numero>23||numero<0) { alert("Attenzione! Ora non valida.");textbox.select(); } }
        function ctrlMinuti(textbox) { var numero=Number(textbox.value);if(numero>59||numero<0) { alert("Attenzione! Minuti non validi.");textbox.select(); } }
        function abilitaDataInterruzione(chkbox) { if(chkbox.checked) $('#tableInterruzione').fadeIn("slow");else $('#tableInterruzione').fadeOut("slow"); }
        function bindEventi() {
            $('[id$=chkInterruzione]').click(function() { abilitaDataInterruzione(this); });
            abilitaDataInterruzione($('[id$=chkInterruzione]')[0]);
            $('[id$=txtOraInizio_text]').blur(function() { ctrlOra(this); });
            $('[id$=txtOraFine_text]').blur(function() { ctrlOra(this); });
            $('[id$=txtMinutiInizio_text]').blur(function() { ctrlMinuti(this); });
            $('[id$=txtMinutiFine_text]').blur(function() { ctrlMinuti(this); });
        }	    
//--></script>

    <div style="display: none">
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
        <asp:HiddenField ID="hdnIdNews" runat="server" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="News & Comunicazioni|Nuovo"
        Width="900px" />
    <table id="tbNews" runat="server" width="900px" class="tableTab">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgNews" runat="server" Width="100%" PageSize="20" AllowPaging="True"
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
                </Siar:DataGrid>&nbsp;
            </td>
        </tr>
    </table>
    <table id="tbNuovo" runat="server" width="900px" class="tableTab">
        <tr>
            <td style="width: 45px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
                &nbsp;Titolo :
            </td>
            <td>
                <Siar:TextBox ID="txtTitolo" runat="server" Obbligatorio="True" Width="700px" MaxLength="255"
                    NomeCampo="Titolo" />
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
                &nbsp;URL :
            </td>
            <td>
                <Siar:TextBox ID="txtUrl" runat="server" MaxLength="255" Width="700px" />                
                <asp:RegularExpressionValidator ID="rfvUrl" runat="server" ControlToValidate="txtUrl"
                    ErrorMessage="Url errato" ValidationExpression="http(s)?://.+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
                &nbsp;News :
            </td>
            <td>
                <Siar:TextArea ID="txtNewsLunga" runat="server" NomeCampo="News" Obbligatorio="True"
                    Width="750px" Rows="6" />
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 45px"></td>
            <td>
                <asp:CheckBox ID="chkInvioTelegram" runat="server" Text="Invia la news anche via Telegram" />
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
            </td>
            <td>
                <asp:CheckBox ID="chkInterruzione" runat="server" Text="Interruzione per aggiornamenti" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table id="tableInterruzione" width="100%">
                    <tr>
                        <td style="width: 43px">
                        </td>
                        <td style="width: 165px">
                            Data interruzione:
                        </td>
                        <td style="width: 167px">
                            Ora inizio:
                        </td>
                        <td>
                            Ora fine:
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 43px">
                        </td>
                        <td style="width: 165px">
                            <Siar:DateTextBox ID="txtDataInterruzione" runat="server" Width="102px" />
                        </td>
                        <td style="width: 167px">
                            <Siar:IntegerTextBox ID="txtOraInizio" runat="server" MaxLength="2" Width="24px" />
                            <Siar:IntegerTextBox ID="txtMinutiInizio" runat="server" MaxLength="2" Width="24px" />
                        </td>
                        <td>
                            <Siar:IntegerTextBox ID="txtOraFine" runat="server" MaxLength="2" Width="24px" />
                            <Siar:IntegerTextBox ID="txtMinutiFine" runat="server" MaxLength="2" Width="24px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 43px">
                        </td>
                        <td style="width: 165px">
                        </td>
                        <td style="width: 167px">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 45px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-bottom: #142952 1px solid">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 39px; text-align: center;" align="right" colspan="2">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" Text="Salva" Width="145px"
                    OnClick="btnSalva_Click" />&nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnElimina" runat="server" CausesValidation="False" Modifica="True"
                    OnClick="btnElimina_Click" Text="Elimina" Width="145px" />&nbsp;&nbsp; &nbsp;<input
                        class="Button" onclick="nuovaNews();" type="button" value="Nuova" style="width: 145px" />
            </td>
        </tr>
    </table>
</asp:Content>
