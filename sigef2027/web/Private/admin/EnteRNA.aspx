<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="EnteRNA.aspx.cs" Inherits="web.Private.admin.EnteRNA" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTabAgid" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function dettaglioEnte(cod_ente) { $('[id$=hdnCodEnte]').val(cod_ente); swapTab(2); }
    function pulisciCampi() {
        $('[id$=hdnCodEnte]').val(''); $('[id$=txtCodice_text]').val(''); $('[id$=txtCodice_text]').removeAttr('readonly'); $('[id$=lstTipoEnte]').val(''); $('[id$=lstTipoEnte]').removeAttr('disabled');
        $('[id$=txtCodice_text]').css("background-color", '#ffffff'); $('[id$=txtDescrizione_text]').val(''); $('[id$=txtDescrizione_text]').css("background-color", '#ffffff');
    }
//--></script>

    <uc1:SiarNewTabAgid ID="ucSiarNewTab" runat="server" TabNames="Elenco generale|Dettaglio ente" />
    <div class="row tableTab py-5" id="tabLista" runat="server">
        <div class="col-sm-3">
            <Siar:ComboTipoEnte Label="Tipologia" ID="lstTipoEnteRicerca" runat="server" DataColumn="CodTipoEnte" />
        </div>
        <div class="col-sm-2 pt-2">
            <Siar:Button ID="btnFiltroEnte" runat="server" Modifica="True" OnClick="btnFiltroEnte_Click"
                Text="Filtra" />
        </div>

        <div class="d-flex flex-row pt-5">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dg_enti" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn>
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="CodEnte" HeaderText="Codice">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="CodEnte"
                                LinkFormat="dettaglioEnte('{0}');" IsJavascript="true">
                                <ItemStyle HorizontalAlign="left" />
                            </Siar:ColonnaLink>
                            <asp:BoundColumn DataField="CodTipoEnte" HeaderText="Codice tipo">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Abilitato" HeaderText="Abilitato" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Abilitato" HeaderText="Salvato" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>
    <div class="tableTab py-5" id="tabNuovo" runat="server">
        <div class="container-fluid bd-form">
            <div class="row align-items-center pt-3">
                <div class="form-group col-sm-3">
                    <Siar:TextBox ID="txtCodice" Label="Codice" runat="server" DataColumn="CodEnte" NomeCampo="Codice ente" />
                </div>
                <div class="form-group col-sm-3">
                    <Siar:TextBox ID="txtDescrizione" Label="Descrizione" runat="server" DataColumn="Descrizione" NomeCampo="Descrizione" />
                </div>
                <div class="form-group col-sm-3">
                    <Siar:TextBox ID="txtUsername" Label="Username" runat="server" DataColumn="Username"
                        NomeCampo="Username" />
                </div>
                <div class="form-group col-sm-3">

                    <Siar:TextBox ID="txtPassword" Label="Password" runat="server" DataColumn="Password"
                        NomeCampo="Password" />
                </div>
            </div>
            <div class="row pb-3 px-3">
                <div class="col-sm-12">
                    <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClick="btnSalva_Click" Text="Salva" />
                    <Siar:Button ID="btnElimina" runat="server" Text="Elimina credenziali" OnClick="btnElimina_Click"
                        Modifica="True" Conferma="Rimuovere le credenziali dell'ente selezionato?"></Siar:Button>
                </div>
            </div>
        </div>

        <h5 class="py-3 fw-bold">Elenco dei profili associati all'ente</h5>

        <div class="row align-items-center py-3">
            <div class="table-responsive">
                <Siar:DataGridAgid ID="dgProfili" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="30" AllowPaging="true">
                    <Columns>
                        <Siar:CheckColumnAgid DataField="IdProfilo" Name="chkProfilo" HeaderText="">
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                        </Siar:CheckColumnAgid>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnCodEnte" runat="server" />
</asp:Content>
