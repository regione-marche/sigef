<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="CalcoloIndicatori.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.CalcoloIndicatori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaDimensione(id) {
            $('[id$=hdnIdDimensione]').val(id);
            $('[id$=btnSelezionaDimensione]').click();
        }
    </script>
    <div class="row bd-form">
        <div class="col-sm-12 mb-3">
            <h3>CALCOLO INDICATORI DI OUTPUT COMUNI E SPECIFICI
            </h3>
            <p>
                Confronto tra Valore Programmato previsto dal Fondo e Valore Realizzato Ammesso, sui Progetti Finanziabili. Per ogni anno è possibile eseguire il calcolo; al successivo accesso verranno visualizzati i dati calcolati precedentemente e sarà possibile effettuarne il Ricalcolo, finchè non vengono Bloccati, rendendoli ufficiali.
            </p>

        </div>
        <div class="col-sm-10 form-group">
            <Siar:ComboZPsr Label="Selezionare POR" ID="cmbPsr" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
        </div>
        <div class="col-sm-2 form-group">
            <Siar:ComboAnno Label="Selezionare Anno" ID="cmbAnno" runat="server" AutoPostBack="true"></Siar:ComboAnno>
        </div>
        <div id="divDownloadRptIN01" runat="server" class="col-sm-12" visible="false">
            <Siar:Button ID="btnDownloadRptIN01" runat="server" Text="Download dettaglio xls" Modifica="true" />
        </div>
        <div id="tbCalcIndic" runat="server" visible="false" class="row">
            <div class="col-sm-12 form-group">
                <Siar:DataGridAgid ID="dgCalcIndic" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">                    
                    <Columns>
                        <%-- <Siar:NumberColumn>
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </Siar:NumberColumn> --%>
                        <asp:BoundColumn DataField="CodPriorita" HeaderText="Priorità">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodIndicatore" HeaderText="Indicatore">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DesIndicatore" HeaderText="Indicatore di Output">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="UM" HeaderText="Unità di misura">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreF" HeaderText="Valore Programmato" DataFormatString="{0:N2}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ValorePF" HeaderText="Valore al 2018" DataFormatString="{0:N2}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ValoreRTot" HeaderText="Valore Realizzato" DataFormatString="{0:N2}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnRicalcola" runat="server" Text="Ricalcola" Enabled="false" OnClick="btnRicalcola_Click" Modifica="true" />
                <%-- <Siar:Button ID="btnSalva" runat="server" Text="Salva" Enabled="false" OnClick="btnSalva_Click" Modifica="true" />--%>
                <Siar:Button Conferma="Attenzione! I dati verranno resi non più modificabili. Continuare?" ID="btnBlocca" runat="server" Text="Blocca" Enabled="false" OnClick="btnBlocca_Click" Modifica="true" />
            </div>
        </div>
    </div>
</asp:Content>
