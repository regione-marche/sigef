<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="ContrattiConfidi.aspx.cs" Inherits="web.Private.Fem.ContrattiConfidi" %>

<%@ Register Src="~/CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="ucFUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">

        .first_elem_block {
            /*width: 200px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 200px;*/
            vertical-align: top;
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-left: 20px;
            padding-bottom: 5px;
        }

        .paragrafo_light {
            border-bottom: solid 1px #084600;
            font-size: 14px;
        }

        .box_ricerca {
            background-color: #cfcfd6;
            padding: 7px;
        }

        .label {
            display: inline;
            float: left;
            min-width: 200px;
            max-width: 200px;
            width: 200px;
            text-align: right;
            vertical-align: middle;
        }

        .value {
            float: right;
            margin-left: 5px;
        }

        .nascondi {
            display: none;
        }

        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

    </style>

    <script type="text/javascript">

        function selezionaContratto(id, elem) {
            if (elem.checked == false) {
                $('[id$=hdnIdContratto]').val('');
            }
            else {
                $('[id$=hdnIdContratto]').val(id);
            }

            $('[id$=hdnIdPagamento]').val('');
            $('[id$=btnPost]').click();
        }

        function changeTipoInserimento() {
            var radiovalue = $('[id$=rblTipoInserimento]').find(":checked").val();

            if (radiovalue == "1") {
                $('[id$=divImportContratti]').hide();
                $('[id$=divInsertGiustificativo]').show();
            }
            else {
                $('[id$=divImportContratti]').show();
                $('[id$=divInsertGiustificativo]').hide();
            }
        }

        function changeProgetto(id, elem) {
            var radiovalue = $('[id$=rblProgettiSoggetto]').find(":checked").val();
            $('[id$=hdnIdProgetto]').val(radiovalue);
        }

        function changeProgettoInserimento(id, elem) {
            var radiovalue = $('[id$=rblProgettiSoggettoInserimento]').find(":checked").val();
            $('[id$=hdnIdProgettoInserimento]').val(radiovalue);
        }

        function readyFn(jQuery) {
            $('[id$=rblTipoInserimento]').change(changeTipoInserimento);
            $('[id$=rblTipoInserimento]').change();

            $('[id$=rblProgettiSoggetto]').change(changeProgetto);
            $('[id$=rblProgettiSoggetto]').change();

            $('[id$=rblProgettiSoggettoInserimento]').change(changeProgettoInserimento);
            $('[id$=rblProgettiSoggettoInserimento]').change();
        }

        function pageLoad() {
            readyFn();
        }

    </script>

    <div style="display: none">

        <asp:HiddenField ID="hdnIdContratto" runat="server" />
        <asp:HiddenField ID="hdnIdPagamento" runat="server" />
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="hdnIdProgettoInserimento" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />

    </div>

    <div style="text-align: center;">
        <h1>Fondo Confidi UNI.CO.</h1>
    </div>

    <div class="dBox">
        <div class="separatore">
            Inserimento contratti Confidi
        </div>

        <div style="padding:10px;">
            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblTipoInserimento" runat="server">
                <asp:ListItem Selected="True" Text="Importa file contratti" Value="0" />
                <asp:ListItem Text="Inserisci giustificativo" Value="1" />
            </asp:RadioButtonList>
            <br />

            <div id="divImportContratti" runat="server">
                <div class="first_elem_block">
                    <%--<div class="label"></div>--%>
                    <div class="value">
                        <ucFUC:SNCUploadFileControl ID="ufContratti" runat="server" TipoFile="NonSpecificato" AbilitaModifica="true" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnImportaContratti" runat="server" OnClick="btnImportaContratti_Click" Width="160px" Modifica="true" Text="Importa contratti" />
                </div>
                <br />
            </div>
            
            <div id="divInsertGiustificativo" runat="server" style="display: none;">
                <%--<div class="first_elem_block">
                    <div class="label">Asse in cui inserire la spesa:</div>
                    <div class="value">
                        <Siar:ComboSql ID="lstAsseGiustificativo" runat="server" CommandText="SELECT 3 AS ASSE UNION SELECT 8 AS ASSE" DataTextField="ASSE"
                            DataValueField="ASSE"  Width="70px"></Siar:ComboSql>
                    </div>
                </div>
                <br />--%>
                <div class="first_elem_block">
                    <div class="label">Id Progetto:</div>
                    <div class="value">
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblProgettiInserimento" runat="server">
                        </asp:RadioButtonList>
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Tipo giustificativo:</div>
                    <div class="value">
                        <Siar:ComboSql ID="lstTipoGiustificativo" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_SPESA=1"
                            DataTextField="DESCRIZIONE" DataValueField="COD_TIPO"  NomeCampo="Tipo giustificativo"
                            Width="280px">
                        </Siar:ComboSql>
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Numero:</div>
                    <div class="value">
                        <Siar:TextBox ID="txtNumGiustificativo" runat="server" Width="120px" MaxLength="30" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Data:</div>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataGiustificativo" runat="server" NomeCampo="Data giustificativo" Width="100px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Imponibile €:</div>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtImportoGiustificativo" runat="server" NomeCampo="Importo giustificativo" Width="110px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Iva %:</div>
                    <div class="value">
                        <Siar:QuotaBox ID="txtIva" runat="server" NomeCampo="Iva" Width="70px" />
                    </div>
                </div>

                <div class="elem_block">
                    <div class="label">Iva non recuperabile</div>
                    <div class="value">
                        <asp:CheckBox ID="chkNonRecuperabile" runat="server" Text="" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Oggetto della spesa:</div>
                    <div class="value">
                        <Siar:TextArea ID="txtDescGiustificativo" runat="server" NomeCampo="Oggetto della spesa" Width="578px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Fornitore (P. IVA):</div>
                    <div class="value">
                        <Siar:TextBox ID="txtPivaFornitore" runat="server" Width="190px" NomeCampo="Partita iva del fornitore" MaxLength="16" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">Ragione sociale:</div>
                    <div class="value">
                        <Siar:TextBox ID="txtRSFornitore" runat="server" Width="576px" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <div class="label">File digitale relativo al giustificativo:</div>
                    <div class="value">
                        <ucFUC:SNCUploadFileControl ID="ufGiustificativo" runat="server" TipoFile="DocumentoFE" AbilitaModifica="true" />
                    </div>
                </div>
                <br />

                <div class="first_elem_block">
                    <Siar:Button ID="btnSalvaGiustificativo" runat="server" OnClick="btnSalvaGiustificativo_Click" Text="Aggiungi giustificativo" Width="160px" />
                </div>
                <br />

            </div>
        </div>

    </div>

    <div class="dBox">
        <div class="separatore">
            Elenco contratti Confidi
        </div>

        <div style="padding: 10px;">
            <div class="first_elem_block" id="divProgettiSoggetto" runat="server">
                <div class="label"><b>Id Progetto:</b></div>
                <div class="value">
                    <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblProgettiSoggetto" runat="server">
                        <asp:ListItem Selected="True" Text="Tutti" Value="Y" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <div class="label"></div>
                <div class="value">
                    <Siar:Button ID="btnMostraContratti" runat="server" OnClick="btnMostraContratti_Click" Text="Mostra contratti progetto selezionato" Width="250px" />
                    <Siar:Button ID="btnEstraiContratti" runat="server" OnClick="btnEstraiContratti_Click" Text="Estrai Xls contratti progetto selezionato" Width="250px" />
                    
                </div>
            </div>
            <br />
            <br />

            <Siar:DataGrid ID="dgContratti" runat="server" Width="100%" PageSize="100" AllowPaging="True" AutoGenerateColumns="False">
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <Columns>
                    <asp:BoundColumn DataField="Numero" HeaderText="Codice Istruttoria univoco ATI">
                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="File">
                        <ItemStyle HorizontalAlign="center" Width="40px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Impresa" HeaderText="Denominazione Impresa"></asp:BoundColumn>
                    <asp:BoundColumn DataField="CodiceFiscaleImpresa" HeaderText="Partita IVA"></asp:BoundColumn>
                    <asp:BoundColumn DataField="TipologiaCredito" HeaderText="Tipologia credito"></asp:BoundColumn>
                    <asp:BoundColumn DataField="FinalitaOperazione" HeaderText="Finalità operazione"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoFinanziamento" HeaderText="Importo finanziamento">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DataStipulaContratto" HeaderText="Data erogazione">
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoGaranziaConfidi" HeaderText="Importo garanzia Confidi">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="ImportoGaranziaFondo" HeaderText="Importo garanzia Fondo">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Regime" HeaderText="Regime"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PerditaFondoEscussioneConfidi" HeaderText="Perdita Fondo per escussione Confidi">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Impegno Fondo - Accantonamento">
                        <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo Pagamenti">
                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </asp:BoundColumn>
                    <Siar:CheckColumn DataField="IdContrattoFem" Name="chkIdContrattoFem">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </Siar:CheckColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <br />

            <div id="divContrattoPagamento" runat="server">
                <div class="paragrafo">
                    Elenco pagamenti associati al contratto
                </div>
                <br />

                <Siar:DataGrid ID="dgContrattiPagamenti" runat="server" Width="100%" PageSize="20" AllowPaging="True" AutoGenerateColumns="False" ShowFooter="true">
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <asp:BoundColumn DataField="IdContrattoFemPagamenti" HeaderText="ID">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TipoPagamento" HeaderText="Tipo">
                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Data" HeaderText="Data">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Estremi" DataField="Estremi">
                            <ItemStyle HorizontalAlign="Right" Width="300px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="File">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Importo" HeaderText="Importo">
                            <ItemStyle HorizontalAlign="Right" Width="80px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
                <br />

                <div id="divAggiungiPagamento" runat="server">
                    <div class="paragrafo_light">
                        Aggiungi pagamento al contratto
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Tipo pagamento:</div>
                        <div class="value">
                            <Siar:ComboSql ID="lstPagamento" runat="server" CommandText="SELECT * FROM TIPO_GIUSTIFICATIVO WHERE DI_PAGAMENTO=1"
                                DataTextField="DESCRIZIONE" DataValueField="COD_TIPO" NomeCampo="Tipo pagamento">
                            </Siar:ComboSql>
                        </div>
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Data:</div>
                        <div class="value">
                            <Siar:DateTextBox ID="txtDataPagamento" runat="server" NomeCampo="Data pagamento" Width="90px" />
                        </div>
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Importo €:</div>
                        <div class="value">
                            <Siar:CurrencyBox ID="txtImportoLordoPagamento" runat="server" NomeCampo="Importo lordo del pagamento" Width="110px" />
                        </div>
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Estremi:</div>
                        <div class="value">
                            <Siar:TextBox ID="txtEstremi" runat="server" Width="488px" NomeCampo="Estremi del pagamento" />
                        </div>
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <div class="label">Specificare il file digitale relativo al pagamento:</div>
                        <div class="value">
                            <ucFUC:SNCUploadFileControl ID="ufPagamento" runat="server" TipoFile="Documento" AbilitaModifica="true" />
                        </div>
                    </div>
                    <br />

                    <div class="first_elem_block">
                        <Siar:Button ID="btnAggiungiPagamento" runat="server" OnClick="btnAggiungiPagamento_Click" Text="Aggiungi pagamento" Width="160px" />
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>

</asp:Content>