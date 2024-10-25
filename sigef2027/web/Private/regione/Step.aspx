<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.regione.Step"
    CodeBehind="Step.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
		<!--

    function nuovo() {
        $('[id$=txtMisura_text]').val(''); $('[id$=txtDescrizione_text]').val(''); $('[id$=txtUrl_text]').val('');
        $('[id$=txtIdStepSel_text]').val('');
        $('[id$=txtValoreMinimo_text]').val(''); $('[id$=txtValoreMassimo_text]').val(''); $('[id$=txtCode_text]').val('');
        $('[id$=txtQueryLungaSQL_text]').val(''); $('[id$=txtQueryPost_text]').val('');
        $('[id$=hdnEdit]').val(''); $('[id$=lstFase]').val(''); $('[id$=chkAutomatico').removeAttr('checked');
        $('[id$=btnSalva]').removeAttr("disabled"); $('[id$=btnElimina]').attr("disabled", "disabled");
    }

    function selezionaStep(id) { $('[id$=hdnEdit]').val(id); $('[id$=btnPost]').click(); }
		//-->
    </script>
    <div style="display: none;">
        <input id="hdnEdit" type="hidden" name="hdnEdit" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" />
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Step|Nuovo Step" />
    <div id="tbElenco" runat="server" class="tableTab row pt-5">
        <div class="col-sm-4 form-group">
            <Siar:ComboFasiProcedurali Label="Fase Procedurale:" ID="lstFaseProcedurale" runat="server">
            </Siar:ComboFasiProcedurali>
        </div>
        <div class="col-sm-3 form-group">
            <Siar:TextBox  Label="Parole chiave:" runat="server" ID="txtFiltroMisura" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:IntegerTextBox Label="ID:" NoCurrency="true" runat="server" ID="txtIdStep" />
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnFiltroMisura" runat="server"
                Text="Applica Filtro" CausesValidation="false" />
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dg" runat="server" Width="100%" AllowPaging="True" PageSize="30"
                AutoGenerateColumns="False" EnableViewState="False">
                <AlternatingItemStyle CssClass="DataGridRow"></AlternatingItemStyle>
                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="35px" HorizontalAlign="center"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="IdStep" HeaderText="ID Step">
                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" LinkFields="IdStep"
                        LinkFormat="javascript:selezionaStep({0});">
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn DataField="Misura" HeaderText="Parola chiave">
                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale">
                        <ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Automatico" HeaderText="Automatico" DataFormatString="{0:SI|NO}">
                        <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                    </asp:BoundColumn>
                    <%-- <asp:TemplateColumn>
                                            <headerstyle width="50px"></headerstyle>
                                            <itemstyle horizontalalign="Center"></itemstyle>
                                            <itemtemplate>
												<asp:HyperLink id=HyperLink1 runat="server" EnableViewState="False" NavigateUrl='<%# getElimina(Container) %>'>Elimina</asp:HyperLink>
											</itemtemplate>
                                        </asp:TemplateColumn>--%>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>
    <div id="tbModifica" runat="server" class="tableTab row bd-form pt-5">
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="ID step:" ID="txtIdStepSel" runat="server" ReadOnly="true" NomeCampo="IdStep" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea ID="txtDescrizione" Label="Descrizione step:" runat="server" NomeCampo="Descrizione"
                Obbligatorio="True" DataColumn="Descrizione"></Siar:TextArea>
        </div>
        <div class="col-sm-3 form-group">
            <Siar:TextBox  Label="Parole chiave:" ID="txtMisura" runat="server" NomeCampo="Misura" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:ComboFasiProcedurali Label="Fase procedurale del progetto associato:" ID="lstFase" runat="server" Obbligatorio="true" NomeCampo="Fase Procedurale"
                DataColumn="CodFase">
            </Siar:ComboFasiProcedurali>
        </div>
        <div class="col-sm-3 form-group">
            <Siar:CurrencyBox Label="Valore Minimo:" ID="txtValoreMinimo" NomeCampo="Valore Minimo" runat="server" DataColumn="ValMinimo" />
        </div>
        <div class="col-sm-3 form-group">
            <Siar:CurrencyBox Label="Valore Massimo:" ID="txtValoreMassimo" NomeCampo="Valore Massimo" runat="server"
                DataColumn="ValMassimo" />
        </div>
        <div class="col-sm-12 form-check">
            <asp:CheckBox ID="chkAutomatico" runat="server" Text="Automatico" />
        </div>
        <h3 class="mt-5 pb-5">(MESSAGGIO DA ADMINISTRATOR: NON MODIFICARE O INSERIRE NEI CAMPI QUI SOTTO A MENO CHE NON SI SAPPIA QUELLO CHE SI STA FACENDO)
        </h3>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query SQL:" ID="txtQueryLungaSQL" runat="server" Rows="10" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Query SQL Post:" ID="txtQueryPost" runat="server" Rows="4" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Nome Metodo:" ID="txtCode" runat="server" MaxLength="30" DataColumn="CodeMethod" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Url:" ID="txtUrl" runat="server" MaxLength="100" DataColumn="Url" />
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                        Modifica="true"></Siar:Button>
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" Modifica="true"
                                    OnClick="btnElimina_Click"></Siar:Button>
            <input class="btn btn-secondary py-1" onclick="javascript: nuovo()" type="button" value="Nuovo" />
        </div>      
    </div>
</asp:Content>
