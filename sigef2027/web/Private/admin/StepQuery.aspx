<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master"
    CodeBehind="StepQuery.aspx.cs" Inherits="web.Private.admin.StepQuery" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function selezionaControllo(id) { $('[id$=hdnIdControllo]').val(id); $('[id$=btnPost]').click(); }
    function nuovo() { $('[id$=hdnIdControllo]').val(''); $('[id$=txtNome_text]').val(''); $('[id$=txtQueryLungaSQL]').val(''); }
//--></script>

    <div style="display: none">
        <input id="hdnIdControllo" type="hidden" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Controlli |Dettaglio" />
    <div class="tableTab" id="tdElencoStep" runat="server" visible="false">
        <p class="py-5 fw-Semibold">In questa pagina vengono elencati tutti i controlli utilizzati per gli Step Automatici</p>

        <div class="row py-3">
            <div class="col-sm-2 form-group">
                <Siar:TextBox runat="server" CssClass="fw-semibold" Label="Filtra per Nome" ID="txtFiltroNome" />
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnFiltro" runat="server" Text="Cerca" CausesValidation="false" />
            </div>
        </div>

        <div class="d-flex flex-row py-3">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgControlli" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="center"></ItemStyle>
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Nome" HeaderText="Nome"></asp:BoundColumn>
                            <asp:BoundColumn>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="coda" Mode="NumericPages"></PagerStyle>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>
    <div class="row bd-form" id="tdDettaglioStep" runat="server" visible="false">

        <h4 class="fw-semibold py-3">Attenzione!Non Modificare o inserire valori nei campi sottostanti a meno che non si sappia quello che si sta facendo!</h4>
        <div class="row py-3">
            <div class="col-sm-4 form-group">
                <Siar:TextBox Label="Nome" ID="txtNome" runat="server" CssClass="fw-semibold" Obbligatorio="true" />
            </div>
        </div>
        <div class="row py-3">
            <div class="col-sm-12 form-group">
                <Siar:TextArea ID="txtQueryLungaSQL" Label="Query SQL" CssClass="fw-semibold " runat="server" Rows="40" MaxLength="15000" />
            </div>
        </div>
        <div class="d-flex flex-row py-3">
            <div class="flex-column px-3">
                <Siar:Button ID="btnSalva" Text="Salva" runat="server" OnClick="btnSalva_Click" CausesValidation="true" />
                <input class="btn btn-primary py-1 " onclick="javascript: nuovo()" type="button" value="Nuovo" />
            </div>
        </div>


        <h4 class="fw-semibold pt-5 mx-1">Elenco Step associati al controllo</h4>

        <div class="d-flex flex-row py-2 mx-1">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgStepAssociati" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle HorizontalAlign="center"></ItemStyle>
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="Step" HeaderText="Descrizione">
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ValMinimo" HeaderText="Minimo">
                                <ItemStyle HorizontalAlign="center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ValMassimo" HeaderText="Massimo">
                                <ItemStyle HorizontalAlign="center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FaseProcedurale" HeaderText="Fase Procedurale"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CheckList" HeaderText="CheckList/Scheda Valutazione"></asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
