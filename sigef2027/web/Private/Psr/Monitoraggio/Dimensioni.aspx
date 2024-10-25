<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Dimensioni.aspx.cs" Inherits="web.Private.Psr.Programmazione.Dimensioni" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaDimensione(id) {
            //$('[id$=hdnIdDimensione]').val($('[id$=hdnIdDimensione]').val() == id ? '' : id);
            //$('[id$=btnProgrammazionePost]').click();
            $('[id$=hdnIdDimensione]').val(id);
            $('[id$=btnSelezionaDimensione]').click();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdDimensione" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click" CausesValidation="false" />
        <asp:Button ID="btnSelezionaDimensione" runat="server" OnClick="btnSelezionaDimensione_Click" CausesValidation="false" />
    </div>
    <div class="row py-3">
        <h3>Anagrafica dimensioni</h3>
        <p class="pt-3">
            Gestione delle dimensioni.<br />
            Selezionare il "Tipo Dimensione" e quindi inserire o editare le dimensioni.<br />
        </p>
    </div>
    <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Elenco Dimensioni|Dettaglio\Nuovo" />

    <div class="row tableTab" id="tbElenco" runat="server">
        <div class="col-sm-3 form-group mt-5">
            <Siar:ComboZTipoDimensioni Label="Tipo Dimensione" ID="cmbTipo" runat="server" AutoPostBack="true"></Siar:ComboZTipoDimensioni>
        </div>
        <div class="col-sm-12">
            <div class="table-responsive">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDimensioni" runat="server" AutoGenerateColumns="false" PageSize="30" AllowPaging="true">
                  <%--  <HeaderStyle CssClass="headerStyle" />--%>
                    <ItemStyle CssClass="DataGridRow itemStyle" />
                    <AlternatingItemStyle CssClass="DataGridRowAlt itemStyle" />
                    <Columns>
                        <Siar:NumberColumn>
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="DesDim" HeaderText="Tipo Dimensione">                                                   
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" IsJavascript="true" LinkFields="Id" LinkFormat="selezionaDimensione({0});">
                        </Siar:ColonnaLinkAgid>
                        <asp:BoundColumn DataField="Metodo" HeaderText="Metodo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreBase" HeaderText="Valore Base"></asp:BoundColumn>
                        
                       
                        <asp:BoundColumn DataField="Valore" HeaderText="Valore Obiettivo"></asp:BoundColumn>
                        
                        <asp:BoundColumn DataField="UM" HeaderText="U.M." ></asp:BoundColumn>
                        <asp:BoundColumn DataField="Richiedibile" HeaderText="Rich."></asp:BoundColumn>
                        <asp:BoundColumn DataField="ProceduraCalcolo" HeaderText="Calcolo"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Ordine" HeaderText="Ordine">
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>

    <div id="tbDettaglio" class="row tableTab bd-form pt-5" runat="server">
        <div class="row py-2">
            <div class="col-sm-2 form-group">
                <Siar:ComboZTipoDimensioni Label="Tipo Dimensione" ID="cmbTipoDettaglio" runat="server"></Siar:ComboZTipoDimensioni>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:TextBox Label="Codice" CssClass="rounded" ID="txtCodice" runat="server"></Siar:TextBox>
            </div>
        </div>
        <div class="row py-2">
            <div class="col-sm-8 form-group">
                <Siar:TextArea Label="Descrizione" CssClass="rounded" ID="txtDescrizione" runat="server" Rows="4" TextMode="MultiLine"></Siar:TextArea>
            </div>
        </div>
        <div class="row py-2">
            <div class="col-sm-2 form-group">
                <Siar:TextBox Label="Unità di misura" CssClass="rounded" ID="txtUM" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DecimalBox Label="Valore Base" ID="txtValoreBase" runat="server" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DecimalBox Label="Valore Obiettivo" ID="txtValore" runat="server" />
            </div>

            <div class="col-sm-2 form-group">
                <Siar:TextBox Label="Richiedibile" CssClass="rounded" ID="txtRichiedibile" runat="server"></Siar:TextBox>
            </div>
        </div>
        <div class="row py-2">
            <div class="col-sm-8 form-group">
                <Siar:TextBox Label="Procedura Calcolo" CssClass="rounded" ID="txtProCalcolo" runat="server"></Siar:TextBox>
            </div>
            <div class="col-sm-8 form-group">
                <Siar:TextArea Label="Metodo" CssClass="rounded" ID="txtMetodo" runat="server" Rows="4" TextMode="MultiLine"></Siar:TextArea>
            </div>
        </div>
        <div class="row py-2">
            <div class="col-sm-3 form-group">
                <Siar:TextBox Label="Ordine" CssClass="rounded" ID="txtOrdine" runat="server"></Siar:TextBox>
            </div>
        </div>
        <div class="row py-2">
            <div class="col-sm-12">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalvaDimensione" />
                <Siar:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancellaDimensione" />
                <Siar:Button ID="btnNuova" runat="server" Text="Nuova" OnClick="btnNuovaDimensione" />
            </div>
        </div>
    </div>
</asp:Content>
