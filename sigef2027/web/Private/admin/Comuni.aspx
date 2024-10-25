<%@ Page Language="c#" MasterPageFile="~/SigefAgidPrivate.master" Inherits="web.Private.admin.Comuni"
    CodeBehind="Comuni.aspx.cs" %>

<%@ Register Src="~/CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function selezionaComune(idComune) { $('[id$=hdnIdComune]').val(idComune); swapTab(2); }
        function pulisciCampi() {
            $('[id$=hdnIdComune]').val(''); $('[id$=txtDenominazione_text]').val(''); $('[id$=txtCap_text]').val(''); $('[id$=lstProvince]').val('');
            $('[id$=txtCodBelfiore_text]').css({ "background-color": "#FFFFFF" }).removeAttr('readonly').val('');
            $('[id$=txtIstat_text]').val(''); $('[id$=txtTipoArea_text]').val(''); $('[id$=txtCodRubricaPaleo_text]').val('');
        }
    </script>

    <input type="hidden" id="hdnIdComune" runat="server" />

    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Comuni|Dettaglio" />

    <div class="tableTab py-2" id="tbRicerca" runat="server">
        <div class="container-fluid shadow rounded-3 bd-form py-4">
            <h4 class="pt-2">Elenco generale dei comuni presente nella banca dati del sistema</h4>

            <p class="py-4 small">
                Selezionarne uno dall'elenco per modificarne i valori. Se non lo trovi prova con la ricerca.
            </p>

            <%--  <h6>Digitare i parametri di ricerca</h6>--%>
            <div class="row py-4 px-2">
                <div class="col-sm-3 form-group">
                    <Siar:TextBox Label="Codice Belfiore" ID="txtRCodBelfiore" CssClass="fw-semibold" runat="server" MaxLength="4" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtRDenominazione" CssClass="fw-semibold" Label="Denominazione" runat="server" />
                </div>
                <div class="col-sm-3 form-group">
                    <label class="active fw-semibold" for="lstRProvince">Provincia</label>
                    <Siar:ComboSql ID="lstRProvince" runat="server" CommandText="SELECT CODICE,DENOMINAZIONE+' ('+SIGLA+')' AS PROVINCIA FROM PROVINCE WHERE CODICE NOT IN ('EE','XX') ORDER BY DENOMINAZIONE"
                        DataTextField="PROVINCIA" DataValueField="CODICE">
                    </Siar:ComboSql>
                </div>
                <div class="col-sm-2 form-check">
                    <asp:CheckBox ID="chkRAttivi" runat="server" Text="&nbsp;In corso di validità" CssClass="fw-semibold" />
                </div>
                <div class="col-sm-1">
                    <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click"
                        Text="Cerca" />
                </div>
            </div>
        </div>
        <div class="d-flex flex-row pt-4">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dg" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" AllowPaging="true">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn>
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="CodBelfiore" HeaderText="Cod. Belfiore">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <Siar:ColonnaLink IsJavascript="true" LinkFields="IdComune" LinkFormat="selezionaComune({0});"
                                DataField="Denominazione" HeaderText="Comune">
                            </Siar:ColonnaLink>
                            <asp:BoundColumn DataField="Sigla" HeaderText="Prov.">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Cap" HeaderText="CAP">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Cod. Istat">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoArea" HeaderText="Tipo Area">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Regione" HeaderText="Regione">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>

    <div id="tbDettaglio" runat="server" class="tableTab">

        <div class="container-fluid shadow rounded-3 bd-form py-4">
            <h4 class="pt-3">Dati Comune</h4>
            <div class="row py-4">
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtCodBelfiore" Label="Codice Belfiore" CssClass="fw-semibold" runat="server" Obbligatorio="true" MaxLength="4" NomeCampo="Codice Belfiore" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtDenominazione" Label="Denominazione" CssClass="fw-semibold" runat="server" Obbligatorio="true" NomeCampo="Denominazione" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtCap" Label="CAP" CssClass="fw-semibold" runat="server" MaxLength="5" NomeCampo="Cap" Obbligatorio="True" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:ComboSql ID="lstProvince" runat="server" Label="Provincia" NomeCampo="Provincia"
                        CommandText="SELECT CODICE,DENOMINAZIONE+' ('+SIGLA+')' AS PROVINCIA FROM PROVINCE WHERE CODICE NOT IN ('EE','XX') ORDER BY DENOMINAZIONE"
                        DataTextField="PROVINCIA" DataValueField="CODICE">
                    </Siar:ComboSql>
                </div>
            </div>
            <div class="row py-4">
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtIstat" Label="Codice ISTAT" CssClass="fw-semibold" runat="server" Obbligatorio="True" NomeCampo="Istat comune" MaxLength="3" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtTipoArea" Label="Tipo Area" CssClass="fw-semibold" runat="server" NomeCampo="Tipo Area" MaxLength="2" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtCodRubricaPaleo" Label="Cod. Rubrica Paleo" CssClass="fw-semibold" runat="server" NomeCampo="Cod Rubrica Paleo" MaxLength="10" />
                </div>
                <div class="col-sm-3 form-group">
                    <Siar:TextBox ID="txtStatoComune" Label="Stato" CssClass="fw-semibold" runat="server" MaxLength="0" ReadOnly="True" />
                </div>
            </div>
            <div class="row pt-4">
                <div class="col-sm-12">
                    <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                        Modifica="true"></Siar:Button>
                    <Siar:Button ID="btnDisattiva" runat="server" Text="Disattiva" Modifica="true"
                        CausesValidation="false" Conferma="Attenzione! Disattivare il comune selezionato?"
                        OnClick="btnDisattiva_Click"></Siar:Button>
                    <input type="button" class="btn btn-secondary py-1" value="Nuovo" onclick="pulisciCampi();" />
                </div>
            </div>
        </div>
        <h4 class="pt-5">Dettaglio storico</h4>
        <div class="d-flex flex-row">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <Siar:DataGridAgid ID="dgStoricoComune" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" AllowPaging="true">
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemStyle CssClass="DataGridRow itemStyle" />
                        <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                        <Columns>
                            <Siar:NumberColumn>
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="CodBelfiore" HeaderText="Cod. Belfiore">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Sigla" HeaderText="Prov.">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Cap" HeaderText="CAP">
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Cod. Istat">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TipoArea" HeaderText="Tipo Area">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Regione" HeaderText="Regione">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Attivo" HeaderText="Attivo" DataFormatString="{0:SI|NO}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid><br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
