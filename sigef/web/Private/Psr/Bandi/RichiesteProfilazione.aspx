<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="RichiesteProfilazione.aspx.cs" Inherits="web.Private.Psr.Bandi.RichiesteProfilazione" %>

<%@ Register Src="~/CONTROLS/FirmaDocumento.ascx" TagName="FirmaDocumento" TagPrefix="uc1" %>

<%@ Register Src="~/CONTROLS/SiarNewTab.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <script type="text/javascript">
        function selezionaRichiesta(id) {
            $('[id$=hdnIdRichiesta]').val(id);
            swapTab(2);
            //$('[id$=btnPost]').click();
            //swapTab(2);
        }

        function controllaCampi(e,invia)
        {
                var testo = '';
                if ($('[id$=txtServizio]').val() == "") { testo += '- inserire il servizio della procedura di attivazione. \n'; }
                if ($('[id$=txtPec]').val() == "") { testo += '- inserire la PEC del Servizio/P.F. \n'; }
                if ($('[id$=txtAsse]').val() == "") { testo += '- inserire l\'asse della procedura di attivazione. \n'; }
                if ($('[id$=txtAzione]').val() == "") { testo += '- inserire l\'azione della procedura di attivazione. \n'; }
                if ($('[id$=txtIva_text]').val() == "") { testo += '- inserire la PEC del Servizio/P.F. \n'; }
                if ($('[id$=txtParereAdg]').val() == "") { testo += '- inserire la segnatura del parere dell\'Autorità di Gestione \n'; }
                if ($('[id$=txtOggetto]').val() == "") { testo += '- inserire l\'oggetto della procedura di attivazione. \n'; }
                if ($('[id$=txtImporto]').val() == "") { testo += '- inserire l\'importo della procedura di attivazione. \n'; }
                if ($('[id$=txtRup]').val() == "") { testo += '- inserire il RUP della procedura di attivazione. \n'; }
                if ($('[id$=txtDataApertura]').val() == "") { testo += '- inserire la data di apertura approssimativa della procedura di attivazione. \n'; }
                if ($('[id$=txtOraApertura]').val() == "") { testo += '- inserire l\'ora di apertura approssimativa della procedura di attivazione. \n'; }
                if ($('[id$=txtDataChiusura]').val() == "") { testo += '- inserire la data di chiusura approssimativa della procedura di attivazione. \n'; }
                if ($('[id$=txtOraChiusura]').val() == "") { testo += '- inserire l\'ora di chiusura approssimativa della procedura di attivazione. \n'; }
                if ($('[id$=txtDecreto]').val() == "") { testo += '- inserire il decreto della procedura di attivazione. \n'; }
                if ($('[id$=txtFascicolo]').val() == "") { testo += '- inserire il fascicolo PALEO della procedura di attivazione. \n'; }
                if ($('[id$=txtTipoProcedura]').val() == "") { testo += '- inserire il tipo della procedura di attivazione. \n'; }
                if ($('[id$=ddlTipoBeneficiario]').val() == "") { testo += '- inserire il tipo di beneficiario della procedura di attivazione. \n'; }
                if ($('[id$=ddlTipoAggregazione]').val() == "") { testo += '- inserire il tipo di aggregazione della procedura di attivazione. \n'; }
                if (!$('[id$=checkCupBeni]').is(':checked') && !$('[id$=checkCupCap]').is(':checked')
                    && !$('[id$=checkCupContr]').is(':checked') && !$('[id$=checkCupLavPub]').is(':checked')
                    && !$('[id$=checkCupProd]').is(':checked') && !$('[id$=checkCupServizi]').is(':checked')) { testo += '- inserire almeno una tipologia di CUP della procedura di attivazione. \n'; }

                if (testo != "") {
                    testo += 'Impossibile continuare.';
                    alert(testo);
                    return stopEvent(e)
            }
            if (invia == 0)
            {
                if (!confirm("La domanda verrà inoltrata all'approvazione dell'Autorità di Gestione, non sarà piu possibile modificarla. Ricevuta l'approvazione la domanda dovrà essere inviata tramite protocollo con l'apposito pulsante.Continuare ? "))
                    return stopEvent(e)
            }
        }

    </script>
     <style type="text/css">
        h1 {
            display: block;
            font-size: 2em;
            margin-top: 0.67em;
            margin-bottom: 0.67em;
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }
        td.SNTEnd {
            background-color: #E6E6EE;
        }
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

        table.elenco
        {
            width: 100%;
            border: 2px solid #89BBDB;
            border-collapse: collapse;
        }
        td.elenco
        {
            width: 55%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.voce
        {
            width: 35%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.modifica
        {
            width: 10%;
            padding: 5px;
            border: 2px solid #89BBDB;
        }
        td.edata
        {
            width: 10%;
            padding: 5px;
            border: 2px solid #89BBDB;
            text-align: center;
        }
        input.elenco
        {
            width: 20px;
            height: 20px;
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
        }
        imageButton.elenco, image.elenco
        {
            width: 20px;
            height: 20px;
            cursor: pointer;
            padding-left: 10px;
            padding-right: 10px;
        }
        label.elenco
        {
            padding-left: 10px;
            padding-right: 10px;
        }

        .nascondi {
            display: none;
            width: 2px;
        }
    </style>
    <div style="display: none">
        <asp:HiddenField ID="hdnIdRichiesta" runat="server" />
        <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" CausesValidation="false" />
    </div>
    <div class="dBox" id="divTab" style="padding:20px" runat="server">
        <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="ELENCO RICHIESTE|SCHEDA PROFILAZIONE"  />
        <div class="dBox" id="divElencoRichieste" style="margin: 0px 0px 0px 0px ;padding:10px; border:1px solid grey ;border-radius:5px" runat="server" >
            <div class="dSezione">
                <div class="dContenutoFloat" style="width:95%"  >
                    <div>
                        <Siar:Button ID="btnNuovaRichiesta" runat="server" Width="220px" Text="Nuova Richiesta Profilazione"
                            CausesValidation="True" OnClick="btnNuovaRichiesta_Click"></Siar:Button>
                    </div>
                    <br />
                    <div runat="server" id="divRichiesteApprovateDaInviare"> 
                        <div class="paragrafo">Elenco delle richieste di profilazione APPROVATE DA INVIARE AL PROTOCOLLO:</div>
                        <br />
                        <div  >
                            <Siar:DataGrid ID="dgRichiesteApprovateDaInviare" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataApprovazione" HeaderText="Data Approvazione">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>

                        </div>
                        <div>
                            <br />
                            <br />
                        </div>
                    </div>
                    <div runat="server" id="divRichiesteIncomplete"> 
                        <div class="paragrafo">Elenco delle richieste di profilazione NON INVIATE ALL'APPROVAZIONE:</div>
                        <br />
                        <div  >
                            <Siar:DataGrid ID="dgRichiesteIncomplete" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                        <div>
                            <br />
                            <br />
                        </div>
                    </div>
                    <div runat="server" id="divRichiesteInviate"> 
                        <div class="paragrafo">Elenco delle richieste di profilazione APPROVATE ED INVIATE AL PROTOCOLLO:</div>
                        <br />
                        <div>
                            <Siar:DataGrid ID="dgRichiesteInviate" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                        <div>
                            <br />
                            <br />
                        </div>
                    </div>
                    <div runat="server" id="divRichiesteInviateDaApprovare"> 
                        <div class="paragrafo">Elenco delle richieste di profilazione INVIATE IN ATTESA DI APPROVAZIONE da Autorita di Gestione:</div>
                        <br />
                        <div>
                            <Siar:DataGrid ID="dgRichiesteInviateDaApprovare" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="LasteditDatetim" HeaderText="Data Invio">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                        <div>
                            <br />
                            <br />
                        </div>
                    </div>
                    <div runat="server" id="divRichiesteRifiutate"> 
                        <div class="paragrafo">Elenco delle richieste di profilazione RIFIUTATE da Autorita di Gestione:</div>
                        <br />
                        <div>
                            <Siar:DataGrid ID="dgRichiesteRifiutate" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Importo" HeaderText="Importo " DataFormatString="{0:c}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="MotivazioneRifiuto" HeaderText="Motivazione Rifiuto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataApprovazione" HeaderText="Data Rifiuto">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                            <div>
                            <br />
                            <br />
                            </div>
                        </div>
                    </div>


                    <div runat="server" id="divRichiesteAdg"> 
                        <div class="paragrafo">Elenco delle richieste approvate o rifiutate come Autorita di Gestione:</div>
                        <br />
                        <div>
                            <Siar:DataGrid ID="dgRichiesteAdg" runat="server" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                                <ItemStyle Height="24px" />
                                <Columns>
                                    <Siar:ColonnaLink HeaderText="ID" DataField="IdRichiesta" LinkFields="IdRichiesta"
                                        ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" LinkFormat="selezionaRichiesta({0});" IsJavascript="true">
                                    </Siar:ColonnaLink>
                                    <asp:BoundColumn DataField="Rup" HeaderText="Responsabile">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Asse" HeaderText="Asse">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Azione" HeaderText="Azione">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Oggetto" HeaderText="Oggetto">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn  HeaderText="Esito">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="DataApprovazione" HeaderText="Data Esito">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="dBox" id="divRichiesta" style="margin: 0px 0px 0px 0px ;padding:10px; border:1px solid grey ;border-radius:5px" runat="server" visible="false">
            <div class="dSezione">
                <div class="dContenutoFloat">
                    <div class="paragrafo">Scheda per la profilazione della Procedura di Attivazione SIGEF per le domande di aiuto/contributi:</div>
                    <br />
                    <div>
                        <table cellpadding="0" cellspacing="0" style="width: 100%; padding-left: 25px">
                            <tr>
                                <td>
                                    <table id="tbButton" runat="server">
                                        <tr>
                                            <td>
                                                <Siar:Button ID="btnSalva" runat="server" Width="220px" Text="Salva"
                                                    CausesValidation="True" OnClick="btnSalva_Click"  OnClientClick="return controllaCampi(event,1);"></Siar:Button>
                                                <Siar:Button ID="btnSalvaInvia" runat="server" Width="220px" Text="Invia all'approvazione AdG"
                                                CausesValidation="True" OnClick="btnInviaApprovazione_Click"  OnClientClick="return controllaCampi(event,0);" ></Siar:Button>
                                                <Siar:Button ID="btnInviaProtocollo" runat="server" Width="220px" Text="Invia al Protocollo" Enabled="false"
                                                CausesValidation="True" OnClick="btnSalvaInvia_Click"  OnClientClick="return controllaCampi(event,1);" ></Siar:Button>
                                                <Siar:Button ID="btnElimina" runat="server" Width="220px" Text="Elimina"
                                                CausesValidation="True" OnClick="btnElimina_Click" Conferma="Sei sicuro di voler eliminare la richiesta di profilazione?"></Siar:Button>

                                            </td>
                                        </tr>
                                    </table>
                                    <label id="lbApprovazione" runat="server" style="color:red"></label>
                                    <table id="tbsegnatura" runat="server" visible ="false">
                                        <tr>
                                            <td>
                                                <Siar:TextBox ID="txtSegnatura" runat="server" ReadOnly="True" Width="800px" />
                                                <input id="btnSegnatura" runat="server" type="image" src="~/images/lente24.png"
                                                                value="Visualizza segnatura"  />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    &nbsp; Operatore di compilazione:<br />
                                    <Siar:TextBox ID="txtOperatore" runat="server" ReadOnly="True" Width="800px" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Servizio:<br />
                                    <Siar:TextBox ID="txtServizio" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;PF:<br />
                                    <Siar:TextBox ID="txtPF" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Posta elettronica certificata della P.F.:<br />
                                    <Siar:TextBox ID="txtPec" runat="server" Width="800px" />
                                </td>
                            </tr>
                             <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Tipologia fondi:<br />
                                    <asp:DropDownList ID="ddlTipoFondi" runat="server">
                                        <asp:ListItem Text="FONDI GESTITI DA ADG (FESR 2014-20 2021-27, ITI AREE INTERNE LS 2014-20, FSC)" Value="1" Selected="true"></asp:ListItem>
                                        <asp:ListItem Text="ALTRI FONDI REGIONALI" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    <b>&nbsp;PROGRAMMA OPERATIVO REGIONALE (POR) MARCHE FESR 2014/2020</b><br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Asse:<br />
                                    <Siar:TextBox ID="txtAsse" runat="server" Width="400px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Azione:<br />
                                    <Siar:TextBox ID="txtAzione" runat="server" Width="400px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Parere Autorità di Gestione (Segnatura) :<br />
                                    <Siar:TextBox ID="txtParereAdg" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkMultiazione" runat="server" Text="Intervento multi-azione" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkPerc10" runat="server" Text="Intervento che attua obiettivi FSE fino ad un massimo del 10% " />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Titolo intervento (Oggetto Procedura di Attivazione):<br />
                                    <Siar:TextBox ID="txtOggetto" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Importo €:<br />
                                    <Siar:CurrencyBox ID="txtImporto" runat="server" Width="160px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Responsabile del procedimento (Nome e Cognome):<br />
                                    <Siar:TextBox ID="txtRup" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Telefono:<br />
                                    <Siar:TextBox ID="txtRupTelefono" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;E-mail:<br />
                                    <Siar:TextBox ID="txtRupEmail" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    Apertura Procedura di Attivazione (inizio presentazione domande sul SIGEF)<br />
                                    <br />
                                    <table style="padding-left: 15px">
                                        <tr>
                                            <td>&nbsp;Data:<br />
                                                <Siar:DateTextBox ID="txtDataApertura" runat="server" Width="100px"
                                                    NomeCampo="Data Apertura" />
                                            </td>
                                            <td>&nbsp;Ora:<br />
                                                <Siar:ClockBox ID="txtOraApertura" runat="server" Width="80px"
                                                    NomeCampo="Ora Apertura" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    Chiusura Procedura di Attivazione (scadenza per presentazione domande su sigef)<br />
                                    <br />
                                    <table style="padding-left: 15px">
                                        <tr>
                                            <td>&nbsp;Data:<br />
                                                <Siar:DateTextBox ID="txtDataChiusura" runat="server" Width="100px"
                                                    NomeCampo="Data Chiusura" />
                                            </td>
                                            <td>&nbsp;Ora:<br />
                                                <Siar:ClockBox ID="txtOraChiusura" runat="server" Width="80px"
                                                    NomeCampo="Ora Chiusura" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Decreto:<br />
                                    <Siar:TextBox ID="txtDecreto" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Fascicolo Paleo (se non esistente deve essere creato in PALEO):<br />
                                    <Siar:TextBox ID="txtFascicolo" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkGraduatoria" runat="server" Text="Graduatoria unica (se NO va ripetuta ogni scheda per ogni graduatoria)" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkSportello" runat="server" Text="Bando a sportello " />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkStrumentiFinanz" runat="server" Text="Previsti strumenti finanziari" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkFinanzParz" runat="server" Text="Prevista finanziabilità parziale delle domande" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Tipo di procedura di attivazione (affidamento diretto, bando, accordo, ecc):<br />
                                    <Siar:TextBox ID="txtTipoProcedura" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkMarcaDaBollo" runat="server" Text="Prevista marca da bollo" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Tipo beneficiario:<br />
                                    <asp:DropDownList ID="ddlTipoAggregazione" runat="server">
                                        <asp:ListItem Text="" Value="" Selected="true"></asp:ListItem>
                                        <asp:ListItem Text="SINGOLA" Value="Singola"></asp:ListItem>
                                        <asp:ListItem Text="AGGREGATA" Value="Aggregata"></asp:ListItem>
                                        <asp:ListItem Text="SINGOLA E AGGREGATA" Value="Singole e aggregata"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkCapofila" runat="server" Text="In caso di aggregazione solo rapporto con capofila" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Natura beneficiario:<br />
                                    <asp:DropDownList ID="ddlTipoBeneficiario" runat="server">
                                        <asp:ListItem Text="" Value="" Selected="true"></asp:ListItem>
                                        <asp:ListItem Text="PUBBLICO" Value="Pubblico"></asp:ListItem>
                                        <asp:ListItem Text="PRIVATO" Value="Privato"></asp:ListItem>
                                        <asp:ListItem Text="PUBBLICO E PRIVATO" Value="Pubblico e Privato"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Settori ammessi a contributo (Se SI indicare i codici ATECO Ammessi):<br />
                                    <Siar:TextBox ID="txtAteco" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkNumeroDomande" runat="server" Text="E’ possibile presentare più domande per lo stesso beneficiario" />
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkDeMinimis" runat="server" Text="Aiuti in regime de minimis" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkContributoUe" runat="server" Text="Contributo chiesto ai sensi del Reg. UE 651/2014" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Tipologie Spese ammissibili e % di aiuto o limiti [piano investimento]:<br />
                                    <Siar:TextArea ID="txtTipoPiano" runat="server"  MaxLength="30000" Rows="3" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Data ammissibilità della spesa ( specificare se si ammettono spese antecedenti la Procedura di Attivazione):<br />
                                    <Siar:TextBox ID="txtDataAmmissibile" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Costo minimo del progetto se previsto €:<br />
                                    <Siar:CurrencyBox ID="txtCostoMin" runat="server" Width="160px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Contributo massimo del progetto se previsto €:<br />
                                    <Siar:CurrencyBox ID="txtCostoMax" runat="server" Width="160px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:CheckBox ID="checkComitato" runat="server" Text="E’ previsto un comitato di valutazione" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Punteggio minimo della scheda di valutazione se previsto:<br />
                                    <Siar:TextBox ID="txtPunteggioMin" runat="server" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Elenco allegati a corredo della domanda generata dal sigef:<br />
                                    <Siar:TextArea ID="txtAllegati" runat="server"  MaxLength="30000" Rows="3" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Elenco dichiarazioni obbligatorie:<br />
                                    <Siar:TextArea ID="txtDichiarazioni" runat="server"  MaxLength="30000" Rows="3" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    &nbsp;Elenco dichiarazioni opzionali:<br />
                                    <Siar:TextArea ID="txtDichiarazioniOpz" runat="server" MaxLength="30000" Rows="3" Width="800px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <br />
                                    Selezionare le tipologie della natura CUP:<br />
                                    <br />
                                    <table style="padding-left: 15px">
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:CheckBox ID="checkCupBeni" runat="server" Text="Acquisto di beni" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:CheckBox ID="checkCupServizi" runat="server" Text="Acquisto o realizzazione di servizi" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:CheckBox ID="checkCupLavPub" runat="server" Text="Realizzazione di lavori pubblici (opere ed impiantistica)" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:CheckBox ID="checkCupContr" runat="server" Text="Concessione di contributi ad altri soggetti (diversi da unita' produttive)" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:CheckBox ID="checkCupProd" runat="server" Text="Concessione di incentivi ad unita' produttive" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:CheckBox ID="checkCupCap" runat="server" Text="Sottoscrizione iniziale o aumento di capitale sociale (compresi spin off), fondi rischio o garanzia)" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table id="tbButtonFooter" runat="server">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <Siar:Button ID="Button1" runat="server" Width="220px" Text="Salva"
                                                    CausesValidation="True" OnClick="btnSalva_Click"  OnClientClick="return controllaCampi(event,1);"></Siar:Button>
                                                <Siar:Button ID="Button2" runat="server" Width="220px" Text="Invia all'approvazione AdG"
                                                CausesValidation="True" OnClick="btnInviaApprovazione_Click"  OnClientClick="return controllaCampi(event,0);"></Siar:Button>
                                                <Siar:Button ID="Button4" runat="server" Width="220px" Text="Invia al Protocollo" Enabled ="false"
                                                CausesValidation="True" OnClick="btnSalvaInvia_Click"  OnClientClick="return controllaCampi(event,1);" ></Siar:Button>

                                                <Siar:Button ID="Button3" runat="server" Width="220px" Text="Elimina"
                                                CausesValidation="True" OnClick="btnElimina_Click" Conferma="Sei sicuro di voler eliminare la richiesta di profilazione?"></Siar:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <uc1:FirmaDocumento ID="ucFirmaDocumento" runat="server" TitoloControllo="RICHIESTA PROFILAZIONE PROCEDURA DI ATTIVAZIONE"
        TipoDocumento="RICHIESTA_PROF" />
</asp:Content>
