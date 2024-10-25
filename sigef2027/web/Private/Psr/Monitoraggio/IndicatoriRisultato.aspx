<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="IndicatoriRisultato.aspx.cs" Inherits="web.Private.Psr.Programmazione.IndicatoriRisultato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <%--
    <script type="text/javascript">
        function selezionaDimensione(id) 
        {
            $('[id$=hdnIdDimensione]').val(id);
            $('[id$=btnSelezionaDimensione]').click();
        }
    </script>
    --%>

    <div class="row">
        <h3>INDICATORI DI RISULTATO
        </h3>
        <p>
            Compilazione Indicatori di Risultato.<br />
        </p>
        <p>
            Selezionare il POR e l'anno da compilare e quindi inserire il Valore Realizzato.<br />
        </p>
    </div>

    <div class="row bd-form pt-5" id="tbElenco" runat="server">
        <div class="col-sm-10 form-group">
            <Siar:ComboZPsr Label="Selezionare POR" ID="cmbPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>

        </div>
        <div class="col-sm-2 form-group">
            <Siar:ComboAnno Label="Selezionare Anno" ID="cmbAnno" runat="server" AutoPostBack="true" Width="70px"></Siar:ComboAnno>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid CssClass="table table-striped" ID="dgDimensioni" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <%-- <Siar:NumberColumn></Siar:NumberColumn> --%>
                    <asp:BoundColumn DataField="CodiceObmisura" HeaderText="OS" HeaderStyle-HorizontalAlign="Center">                        
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DimensioneCodice" HeaderText="Codice IR" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DimensioneDescrizione" HeaderText="Descrizione IR" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                    <asp:BoundColumn DataField="UM" HeaderText="U.M." HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ValoreBase" HeaderText="Valore Base" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ValoreObbiettivo" HeaderText="Valore Obiettivo" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <Siar:ImportoColumnAgid DataField="IdDimensione" Importo="ValoreRealizzato" HeaderText="Valore Realizzato" Name="ValoreRealizzato"></Siar:ImportoColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-2">
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" Enabled="false" OnClick="btnSalvaDimensione" Modifica="true" />
        </div>
    </div>

</asp:Content>
