<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="Indicatori.aspx.cs" Inherits="web.Private.Psr.Monitoraggio.Indicatori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaIntervento(id) {
            $('[id$=hdnIdIntervento]').val($('[id$=hdnIdIntervento]').val() == id ? '' : id);
            //$('[id$=hdnIdIntervento]').val(id);
            $('[id$=btnInterventoPost]').click();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdAzione" runat="server" />
        <asp:HiddenField ID="hdnIdIntervento" runat="server" />
        <asp:Button ID="btnAzionePost" runat="server" OnClick="btnAzionePost_Click"
            CausesValidation="false" />
        <asp:Button ID="btnInterventoPost" runat="server" OnClick="btnInterventoPost_Click"
            CausesValidation="false" />
    </div>

    <div class="row bd-form">
        <h3>INDICATORI DI OUTPUT PER TIPOLOGIA INTERVENTO
        </h3>
        <p>
            Gestione degli Indicatori di Output collegati alla Tipologia Intervento.
        </p>
        <p>
            Per ogni Tipologia Intervento selezionare gli Indicatori collegati ad esso, quindi salvare.<br />
        </p>
        <div class="col-sm-12 form-group">
            <Siar:ComboZPsr Label="Selezionare il Por di riferimento:" ID="lstPsr" runat="server" AutoPostBack="true">
            </Siar:ComboZPsr>
        </div>

        <div class="row" id="tbAzioni" runat="server" visible="false">
            <div class="col-sm-12 form-group">

                <Siar:ComboZProgrammazione Label="Selezionare l'Azione:" ID="lstAzione" runat="server" AutoPostBack="True"
                    Width="700px">
                </Siar:ComboZProgrammazione>
            </div>
            <div class="col-sm-12" id="tbInterventi" runat="server" visible="false">

                <Siar:DataGridAgid CssClass="table table-striped" ID="dgInterventi" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Center" Width="110px" Font-Bold="True" Font-Size="14px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Id" LinkFormat="selezionaIntervento({0});">
                        </Siar:ColonnaLink>
                        <Siar:CheckColumn DataField="Id" Name="chkIdIntervento" HeaderSelectAll="true">
                            <ItemStyle Width="50px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGridAgid>

            </div>

        </div>


        <div id="tbIndicatori" class="row" runat="server" visible="false">
            <p>Elenco Indicatori di Output:</p>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgIndicatori" runat="server" AutoGenerateColumns="False">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:NumberColumn>

                        <asp:BoundColumn DataField="CodDimensione" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>

                        <asp:BoundColumn DataField="CodDim" HeaderText="Cod_DIM">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>

                        <asp:BoundColumn DataField="DesDimensione" HeaderText="Descrizione">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Um" HeaderText="UM">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundColumn>

                        <Siar:CheckColumnAgid DataField="IdDimensione" HeaderSelectAll="true" Name="chkIdIndicatore" HeaderText="Seleziona">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumnAgid>

                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalva" runat="server" Width="158px" Text="Salva" OnClick="btnSalva_Click"
                    Modifica="true" />
            </div>
        </div>
    </div>
</asp:Content>
