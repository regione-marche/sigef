<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.regione.Allegati" CodeBehind="Allegati.aspx.cs" %>

<%@ Register Src="../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
    function pulisciCampi() { $('[id$=hdnIdAllegato]').val(''); $('[id$=txtDescrizione]').val(''); $('[id$=txtMisura]').val(''); $('[id$=lstTipoAllegato]').val(''); $('[id$=lstTipoEnte]').val(''); $('[id$=lstTipoEnte]')[0].disabled = true; }
    function selezionaAllegato(id) { $('[id$=hdnIdAllegato]').val(id); swapTab(2); }
    function checkEnteEmettitore(elem) { $('[id$=lstTipoEnte]')[0].disabled = $(elem).val() != 'S'; if ($('[id$=lstTipoEnte]')[0].disabled == true) $('[id$=lstTipoEnte]').val(''); }
//--></script>

    <input id="hdnIdAllegato" type="hidden" runat="server" />
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco allegati|Dettaglio allegato" />
    <div class="row tableTab py-5 mx-2" id="tbElenco" runat="server" visible="false">
        <div class="row">
            <div class="form-group col-sm-3">
                <Siar:TextBox  Label="Misura:" ID="txtCercaMisura" runat="server" MaxLength="10" />
            </div>
            <div class="form-group col-sm-3">
                <Siar:ComboSql Label="Tipo documento:" ID="lstCercaTipoDocumento" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM TIPO_ALLEGATO ORDER BY ATTIVO DESC,DESCRIZIONE"
                    DataTextField="DESCRIZIONE" DataValueField="CODICE">
                </Siar:ComboSql>
            </div>
            <div class="form-group col-sm-3">
                <Siar:TextBox  Label="Descrizione:" ID="txtCercaDescrizione" runat="server" MaxLength="80" />
            </div>
            <div class="col-sm-3">
                <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca"
                    CausesValidation="false" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dg" runat="server" CssClass="table table-striped" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="false">
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </Siar:NumberColumn>
                        <Siar:ColonnaLink DataField="Descrizione" LinkFields="IdAllegato" IsJavascript="true"
                            HeaderText="Descrizione" LinkFormat="selezionaAllegato({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="CodTipo" HeaderText="Tipo documento" DataFormatString="{0:S=Dichiarazione Sostitutiva|D=Supporto Digitale|C=Supporto Cartaceo}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodTipoEnteEmettitore" HeaderText="Ente emettitore" DataFormatString="{0:CM=Comune|PR=Provincia}">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>&nbsp;
            </div>
        </div>
    </div>
    <div class="row tableTab py-5 mx-2 bd-form" id="tbDettaglio" runat="server" visible="false">
        <div class="form-group col-sm-4">
            <Siar:TextBox  Label="Misura:" ID="txtMisura" runat="server" NomeCampo="Misura" />
        </div>
        <div class="form-group col-sm-4">
            <Siar:ComboSql Label="Tipo documento:" ID="lstTipoAllegato" runat="server" CommandText="SELECT CODICE,DESCRIZIONE FROM TIPO_ALLEGATO ORDER BY ATTIVO DESC,DESCRIZIONE"
                DataTextField="DESCRIZIONE" DataValueField="CODICE" Obbligatorio="true" NomeCampo="Tipo documento">
            </Siar:ComboSql>
        </div>
        <div class="form-group col-sm-4">
            <Siar:Combo Label="Ente emettitore:" ID="lstTipoEnte" runat="server">
                <asp:ListItem Value="" />
                <asp:ListItem Value="CM">Comune</asp:ListItem>
                <asp:ListItem Value="PR">Provincia</asp:ListItem>
            </Siar:Combo>
        </div>
        <div class="form-group col-sm-12">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizione" runat="server" NomeCampo="Descrizione"
                Obbligatorio="True" Rows="10" MaxLength="1000"></Siar:TextArea>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click"
                Modifica="True"></Siar:Button>
            <Siar:Button ID="btnElimina" runat="server" Text="Elimina" OnClick="btnElimina_Click" Modifica="True"
                Conferma="Attenzione! Eliminare l`allegato selezionato?" CausesValidation="false"></Siar:Button>
            <input class="btn btn-primary py-1" onclick="pulisciCampi();" type="button" value="Nuovo" />
        </div>
    </div>
</asp:Content>
