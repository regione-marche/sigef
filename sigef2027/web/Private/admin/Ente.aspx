<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.admin.Ente"
    CodeBehind="Ente.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTabAgid" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function dettaglioEnte(cod_ente) { $('[id$=hdnCodEnte]').val(cod_ente); swapTab(2); }
        function pulisciCampi() {
            $('[id$=hdnCodEnte]').val(''); $('[id$=txtCodice_text]').val(''); $('[id$=txtCodice_text]').removeAttr('readonly'); $('[id$=lstTipoEnte]').val(''); $('[id$=lstTipoEnte]').removeAttr('disabled');
            $('[id$=txtCodice_text]').css("background-color", '#ffffff'); $('[id$=txtDescrizione_text]').val(''); $('[id$=txtDescrizione_text]').css("background-color", '#ffffff');
            $('.form-feedback').hide();
            $("#errorMsgContainer").empty();
        }
        function pageValid() {
            if (!Page_ClientValidate()) {
                $("#errorMsgContainer").empty();
                $('<div class="alert alert-danger alert-dismissible fade show" role="alert"><strong>Attenzione</strong> Alcuni campi inseriti sono da controllare.<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Chiudi avviso">').appendTo('#errorMsgContainer');
            }
            else
                $("#errorMsgContainer").empty();
        }
    </script>   
    <uc1:SiarNewTabAgid ID="ucSiarNewTab" runat="server" TabNames="Elenco generale|Dettaglio ente" />
    <div class="row tableTab py-5" id="tabLista" runat="server">
        <div class="row pt-5">
            <div class="form-group col-sm-3">
                <Siar:ComboTipoEnte Label="Filtra per tipologia" ID="lstTipoEnteRicerca" runat="server" DataColumn="CodTipoEnte">
                </Siar:ComboTipoEnte>
            </div>
            <div class="col-sm-2">
                <Siar:Button ID="btnFiltroEnte" runat="server" Modifica="True" OnClick="btnFiltroEnte_Click"
                    Text="Filtra" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dg" runat="server" ShowHeader="true" CssClass="table table-striped" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                     <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodEnte" HeaderText="Codice">
                            <HeaderStyle CssClass="text-center" />
                            <ItemStyle CssClass="text-center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" LinkFields="CodEnte"
                            LinkFormat="dettaglioEnte('{0}');" IsJavascript="true">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle  HorizontalAlign="Left" />
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="CodTipoEnte" HeaderText="Codice tipo">
                            <HeaderStyle CssClass="text-center" />
                            <ItemStyle CssClass="text-center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                            <HeaderStyle CssClass="text-center" />
                            <ItemStyle CssClass="text-center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <div class="row tableTab py-5 mx-2 bd-form" id="tabNuovo" runat="server" width="650px">
        <div class="row">
            <div class="form-group col-sm-4">
                <Siar:TextBox  Label="Codice:" ID="txtCodice" runat="server" DataColumn="CodEnte" NomeCampo="Codice ente"
                    Obbligatorio="True" />
            </div>
            <div class="form-group col-sm-4">
                <Siar:TextBox  ID="txtDescrizione" Label="Descrizione:" runat="server" DataColumn="Descrizione"
                    NomeCampo="Descrizione" Obbligatorio="True" />
            </div>
            <div class="col-sm-4">
                <Siar:ComboTipoEnte Label="Tipologia Ente:" ID="lstTipoEnte" runat="server" Obbligatorio="True" NomeCampo="Tipo ente"
                    AutoPostBack="True" DataColumn="CodTipoEnte">
                </Siar:ComboTipoEnte>
            </div>
        </div>
        <div class="d-flex flex-row justify-content-start px-2">
             <div class="flex-column px-2">
                <Siar:Button ID="btnSalva" runat="server" Modifica="True" OnClientClick="pageValid();" OnClick="btnSalva_Click"
                    Text="Salva" Width="140px" />
            </div>
            <div class="flex-column">
                <Siar:Button ID="btnDisabilita" runat="server" Width="140px" Text="Disabilita" OnClick="btnDisabilita_Click"
                    Modifica="True" Conferma="Attenzione! Disabilitare l`ente selezionato?"></Siar:Button>&nbsp;&nbsp;
            </div>
            <div class="flex-column">
                <input id="btnNuovo" class="btn btn-secondary py-1" style="width: 140px" type="button" value="Nuovo ente"
                    onclick="pulisciCampi();" />
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-12">
                <div aria-live="polite" id="errorMsgContainer"></div>
            </div>
        </div>
        <div class="row pt-4">
            <div class="col-sm-12">
                <label>Elenco dei profili associati all'ente</label>
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgProfili" CssClass="table table-striped" runat="server" PageSize="20" AutoGenerateColumns="False">
                    <Columns>
                        <Siar:CheckColumn DataField="IdProfilo" Name="chkProfilo" HeaderText="">
                            <HeaderStyle CssClass="text-center" />
                        </Siar:CheckColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnCodEnte" runat="server" />
</asp:Content>
