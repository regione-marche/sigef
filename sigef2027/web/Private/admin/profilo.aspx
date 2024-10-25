<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.admin.Profilo"
    CodeBehind="Profilo.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function selezionaProfilo(id) { $('[id$=hdnIdProfilo]').val(id); $('[id$=btnSelezionaProfilo]').click(); }
    function eliminaProfilo(ev) {
        if ($('[id$=hdnIdProfilo]').val() == '') { alert('Il profilo selezionato non è valido.'); return stopEvent(ev); }
        else if (!confirm('Attenzione! Eliminando il profilo selezionato verranno eliminate anche tutte le correlazioni alle funzionalità. Continuare?')) return stopEvent(ev);
    }
    function pulisciCampi() { $('[id$=hdnIdProfilo]').val(''); $('[id$=txtDescrizione_text]').val(''); $('[id$=txtOrdine_text]').val(''); $('[id$=lstTipoEnte]').val(''); }
//--></script>




    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco profili|Dettaglio\Nuovo" />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdProfilo" runat="server" />
        <asp:Button ID="btnSelezionaProfilo" runat="server" CausesValidation="False" OnClick="btnSelezionaProfilo_Click" />
    </div>
    <div class="tableTab" id="tbProfili" runat="server">
        <div class="d-flex flex-row py-2">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgProfili" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" AllowPaging="false" PageSize="15">
                        <ItemStyle Height="22px" />
                        <Columns>
                            <Siar:NumberColumn>
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <Siar:ColonnaLink HeaderText="Descrizione" DataField="Descrizione" LinkFields="IdProfilo"
                                IsJavascript="true" LinkFormat="selezionaProfilo({0});">
                            </Siar:ColonnaLink>
                            <asp:BoundColumn HeaderText="Tipo ente" DataField="CodTipoEnte">
                                <ItemStyle Width="150px" HorizontalAlign="center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>&nbsp;
                </div>
            </div>
        </div>
    </div>
    <div class="tableTab row bd-form" id="tbDettaglio" runat="server">
        <div class="container-fluid container-no-margin">
            <div class="row mt-5">
                <div class="col-md-2 form-group">
                    <Siar:ComboTipoEnte ID="lstTipoEnte" Label="Tipologia ente" runat="server" NomeCampo="Tipo ente"></Siar:ComboTipoEnte>
                </div>
                <div class="col-md-2 form-group">
                    <Siar:TextBox ID="txtDescrizione" Label="Descrizione" runat="server" NomeCampo="Descrizione" Obbligatorio="True"></Siar:TextBox>
                </div>
                <div class="col-md-2 form-group">
                    <Siar:IntegerTextBox ID="txtOrdine" Label="Ordine" runat="server" NomeCampo="Ordine" DataColumn="Ordine" />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click" Text="Salva" />
                    <Siar:Button ID="btnElimina" runat="server" Modifica="true" OnClick="btnElimina_Click" Text="Elimina" OnClientClick="return eliminaProfilo(event);" CausesValidation="false" />
                    <input type="button" class="btn btn-secondary py-1" value="Nuovo" onclick="pulisciCampi()" />
                </div>
            </div>
            <div class="paragrafo_bold">Dati spesa</div>
            <div class="container-fluid container-no-margin">
                <div class="row mt-5">
                    <div class="col-sm-5">
                        <Siar:ComboProfilo Label="Selezionare le funzionalità da associare al profilo" ID="lstProfili" runat="server"></Siar:ComboProfilo>
                    </div>
                    <div class="col-sm-3">
                        <Siar:Button ID="btnCaricaProfilo" runat="server" Modifica="False" OnClick="btnCaricaProfilo_Click"
                            Text="Carica profilo" Width="150px" CausesValidation="False" />
                    </div>
                </div>
                <div class="container-fluid container-no-margin">
                    <div class="d-flex flex-row py-4 row-no-margin ">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <Siar:DataGridAgid ID="dgFunzionalita" runat="server" AAutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" AllowPaging="true">
                                    <%--      <HeaderStyle CssClass="headerStyle " />--%>
                                    <ItemStyle CssClass="DataGridRow " />
                                    <AlternatingItemStyle CssClass="DataGridRowAlt" />
                                    <Columns>
                                        <Siar:NumberColumn HeaderText="Nr.">
                                        </Siar:NumberColumn>
                                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="DescMenu" HeaderText="Descrizione Menu">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <Siar:CheckColumnAgid DataField="CodFunzione" Name="chkModifica" HeaderText="In modifica"
                                            HeaderSelectAll="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:CheckColumnAgid>
                                        <Siar:CheckColumnAgid DataField="CodFunzione" Name="chkFunzionalita" HeaderText="Seleziona"
                                            HeaderSelectAll="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </Siar:CheckColumnAgid>
                                    </Columns>
                                </Siar:DataGridAgid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
