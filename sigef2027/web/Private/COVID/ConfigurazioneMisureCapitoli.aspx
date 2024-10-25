<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ConfigurazioneMisureCapitoli.aspx.cs" Inherits="web.Private.COVID.ConfigurazioneMisureCapitoli" %>

<%@ Register Src="../../CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaConfigurazione(id) {
            $('[id$=hdnIdConfigurazione]').val(id);
            swapTab(2);
        }
        function svuotaCampi() {
            $('[id$=hdnIdConfigurazione]').val("");
            $('[id$=txtCapitolo]').val("");
            $('[id$=txtAnnoImp]').val("");
            $('[id$=txtAnnoSubimp]').val("");
            $('[id$=txtDescrizioneImpSubimp]').val("");
            $('[id$=txtPercentualeImporto]').val("");
            $('[id$=txtAnnoProposta]').val("");
            $('[id$=txtUnitaProponente]').val("");
            $('[id$=txtNumeroProposta]').val("");
            $('[id$=txtTransazione]').val("");
            $('[id$=txtCodiceRitenuta]').val("");
            $('[id$=txtAliquotaRitenuta]').val("");
            $('[id$=txtCausaleIrpef]').val("");
            $('[id$=txtControlloEquitalia]').val("");
            $('[id$=txtNote]').val("");
            $('[id$=txtRimodulazioneContributo]').val("100,00");

        }

        function EstraiXLS(idBando,Data) {
            var parametri = "ID_BANDO=" + idBando + "|DATA_INSERIMENTO=" + Data;
            SNCVisualizzaReport('rptCovidLiquidazioni2', 2, parametri);
        }
    </script>

    <style type="text/css">
        td.SNTEnd {
            background-color: #E6E6EE;
        }
    </style>

    <div class="dBox" style="padding: 20px">
        <uc1:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Configurazioni|Nuova-Configurazione"
            Width="900px" />
        <input id="hdnIdConfigurazione" type="hidden" name="hdnIdConfigurazione" runat="server" />
        <div class="tableTab" width="900px" id="tabConfigurazioni" runat="server">
            <div class="separatore">
                Elenco Configurazioni
            </div>

            <Siar:DataGrid ID="dgConfigurazioni" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="20" AllowPaging="True">
                <ItemStyle Height="24px" />
                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">
                        <ItemStyle Width="15px" HorizontalAlign="center"></ItemStyle>
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Idbando" HeaderText="Id bando">
                        <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLink LinkFields="IdCovidCapitoliBando" LinkFormat="javascript:selezionaConfigurazione('{0}');"
                        DataField="IdCovidCapitoliBando" HeaderText="Id configurazione" ItemStyle-Width="50px">
                    </Siar:ColonnaLink>
                    <asp:BoundColumn DataField="Capitolo" HeaderText="Capitolo">
                        <ItemStyle Width="50px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Anno Imp" DataField="AnnoImp">
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Anno Subimp" DataField="AnnoSubimp">
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DescrizioneImpSubimp" HeaderText="Descrizione imp subimp">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RimodulazioneContributo" HeaderText="Rimodulazione contributo (%)">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PercentualeImporto" HeaderText="Percentuale importo capitolo (%)">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="AnnoProposta" HeaderText="Anno proposta">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="UnitaProponente" HeaderText="Unità proponente">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NumeroProposta" HeaderText="Numero proposta">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Transazione" HeaderText="Transazione">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CodiceRitenuta" HeaderText="Codice ritentuta">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="AliquotaRitenuta" HeaderText="Aliquota ritenuta (%)">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CausaleIrpef" HeaderText="Causale IRPEF">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ControlloEquitalia" HeaderText="Controllo equitalia">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Note" HeaderText="Note">
                        <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Confermata" HeaderText="Confermata" DataFormatString="{0:SI|NO}">
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <div>
                &nbsp; Bando:<br />
                <Siar:ComboBandiCovid ID="lstBandoExport" runat="server" NoBlankItem="true"
                    NomeCampo="Bando"></Siar:ComboBandiCovid>
                <Siar:Button ID="btnExportConfigurazioni" runat="server" Width="220px" Text="Esporta le liquidazioni"
                    CausesValidation="False" OnClick="btnExport_Click"></Siar:Button>
                <%--<input type="button" id="btnCrea" class="Button" value="Crea File XLS"
                    onclick="EstraiXLS($('[id$=lstBandoExport]').val())" />--%>
            </div>
            <div id="divEstrazioni" runat="server" visible="false">
                <div>
                    <br />
                </div>
                <div class="separatore">
                Elenco Estrazioni Effettuate
                </div>
                
                <Siar:DataGrid ID="dgEstrazioni" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="false">
                <ItemStyle Height="24px" />
                <ItemStyle CssClass="DataGridRow"></ItemStyle>
                <HeaderStyle Font-Bold="True" ForeColor="White" CssClass="TESTA1"></HeaderStyle>
                <Columns>
                    <asp:BoundColumn DataField="Idbando" HeaderText="Id bando">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione"  HeaderText="Descrizione Bando">
                        <ItemStyle Width="400px" HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Data Creazione">
                        <ItemStyle Width="100px" HorizontalAlign="left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn >
                        <ItemStyle Width="50px"  HorizontalAlign="center"/>
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGrid>
            </div>
        </div>
        <div class="tableTab" width="500px" id="tabNuovaConfigurazione" runat="server">
            <div class="separatore">
                Nuova configurazione
            </div>
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="3">
                        <br />
                        &nbsp; Bando:<br />
                        <Siar:ComboBandiCovid ID="lstBando" runat="server" NoBlankItem="true"
                            NomeCampo="Bando" Obbligatorio="true">
                        </Siar:ComboBandiCovid>
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Capitolo:<br />
                        <Siar:TextBox  ID="txtCapitolo" Obbligatorio="true" NomeCampo="Capitolo" runat="server" Width="160px" TextAlign="right" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Anno Imp:<br />
                        <Siar:IntegerTextBox ID="txtAnnoImp" Obbligatorio="true" NomeCampo="Anno Imp" MaxLength="4" NoCurrency="True" runat="server" Width="160px" TextAlign="right" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Anno Subimp:<br />
                        <Siar:IntegerTextBox ID="txtAnnoSubimp" Obbligatorio="true" NomeCampo="Anno Subimp" MaxLength="4" NoCurrency="True" runat="server" Width="160px" TextAlign="right" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Descrizione Imp Subimp:<br />
                        <Siar:TextBox  ID="txtDescrizioneImpSubimp" Obbligatorio="true" NomeCampo="Descrizione Imp Subimp" MaxLength="160" runat="server" Width="160px" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Percentuale importo capitolo (%):<br />
                        <Siar:QuotaBox ID="txtPercentualeImporto" Obbligatorio="true" NrDecimali="3" runat="server" NomeCampo="Percentuale importo" Width="160px" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Anno proposta:<br />
                        <Siar:IntegerTextBox ID="txtAnnoProposta" Obbligatorio="true" NomeCampo="Anno proposta" MaxLength="4" NoCurrency="True" runat="server" Width="160px" TextAlign="right" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Unità proponente:<br />
                        <Siar:TextBox  ID="txtUnitaProponente" Obbligatorio="true" NomeCampo="Unità proponente" MaxLength="15" runat="server" Width="160px" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Numero proposta:<br />
                        <Siar:TextBox  ID="txtNumeroProposta" Obbligatorio="true" NomeCampo="Numero proposta" runat="server" Width="160px" TextAlign="right" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Transazione:<br />
                        <Siar:TextBox  ID="txtTransazione" Obbligatorio="true" MaxLength="500" NomeCampo="Transazione" runat="server" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Codice ritenuta:<br />
                        <Siar:TextBox  ID="txtCodiceRitenuta" Obbligatorio="true" MaxLength="32" NomeCampo="Codice ritenuta" runat="server" Width="160px" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Aliquota ritenuta (%):<br />
                        <Siar:DecimalBox ID="txtAliquotaRitenuta" Obbligatorio="true" runat="server" NomeCampo="Aliquota ritenuta" Width="160px" />
                    </td>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Causale IRPEF:<br />
                        <Siar:TextBox  ID="txtCausaleIrpef" Obbligatorio="true" MaxLength="1000" runat="server" NomeCampo="Causale IRPEF" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px">
                        <br />
                        &nbsp; Controllo equitalia:<br />
                        <Siar:TextBox  ID="txtControlloEquitalia" Obbligatorio="true" MaxLength="30" runat="server" NomeCampo="Controllo equitalia" Width="160px" />
                    </td>
                    <td style="width: 200px" colspan="2">
                        <br />
                        &nbsp; Rimodulazione contributo (%):<br />
                        <Siar:DecimalBox ID="txtRimodulazioneContributo" Obbligatorio="true" runat="server" NomeCampo="Rimodulezione contributo" Width="160px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 200px">
                        <br />
                        &nbsp; Note:<br />
                        <Siar:TextArea ID="txtNote" MaxLength="500" runat="server" Width="500px" />
                    </td>
                </tr>
            </table>
            <br />
            <Siar:Button ID="btnSalva" runat="server" Width="220px" Text="Salva configurazione"
                CausesValidation="True" OnClick="btnSalva_Click"></Siar:Button>
            <Siar:Button ID="btnElimina" CausesValidation="false" runat="server" Width="220px" Text="Elimina configurazione"
                OnClick="btnElimina_Click" Conferma="Attenzione! Una volta eliminata la configurazione bisognerà ricrearla completamente. Continuare?"></Siar:Button>
            <input id="btnNew" type="button" class="Button"
                value="Nuova configurazione" style="width: 220px;" onclick="svuotaCampi();" />
            <Siar:Button ID="btnConferma" CausesValidation="false" runat="server" Width="220px" Text="Conferma configurazione"
                OnClick="btnConferma_Click" Conferma="Attenzione! Una volta confermata la configurazione non sarà più possibile modificarla o eliminarla. Continuare?"></Siar:Button>
        </div>
    </div>
</asp:Content>
