<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="CertificazioneRecuperi.aspx.cs" Inherits="web.Private.CertificazioneSpesa.CertificazioneRecuperi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <script type="text/javascript">
        function selezionaRecupero(id) 
        {
            $('[id$=hdnIdRecupero]').val(id);
            $('[id$=btnSelezionaRecupero]').click();
        }
        function ctrlCampiRicercaNormeMarche(ev) 
        {
            if ($('[id$=txtAttoNumero_text]').val() == "" ||
                $('[id$=txtAttoData_text]').val() == "" || 
                $('[id$=lstAttoRegistro]').val() == "") 
            {
                alert('Per la ricerca degli atti è necessario specificare numero, data e registro.');
                return stopEvent(ev);
            } 
        }
        function ctrlTipoAtto(ev) 
        {
            if ($('[id$=hdnIdAttoNew]').val() == "") 
            {
                alert('Per proseguire è necessario specificare un atto.');
                return stopEvent(ev); 
            }
            else if ($('[id$=lstAttoTipo]').val() == "") 
            {
                alert('Per proseguire è necessario specificare la tipologia dell`atto.');
                return stopEvent(ev); 
            }
        }
        function chiudiPopup() 
        {
            $('[id$=hdnIdAttoNew]').val('');
            $('[id$=lstAttoOrgIstituzionale]').val('');
            $('[id$=lstAttoTipo]').val('');
            chiudiPopupTemplate(); 
        }
    </script>

    <div id="divHidden" style="display: none">       
        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnIdAttoNew" runat="server" />
        <asp:Button ID="btnSelezionaRecupero" runat="server" OnClick="btnSelezionaRecupero_Click" CausesValidation="false" />
    </div>
       
    <div id="divElenco" runat="server">
        <table class="tableTab" id="tblElencoH" runat="server" width="1000px">
        <tr class="separatore_big">
            <td style="width:40%">
                Selezionare il recupero da modificare
            </td>
            <td>
                <Siar:Button ID="btnNuovo" runat="server" Text="Nuova" OnClick="btnNuovo_OnClick"/>
            </td>
        </tr>
        </table>
        <table class="tableTab" id="tblElencoR" runat="server" width="1000px">
        <tr>
            <td>
                <Siar:DataGrid ID="dgRecuperi" runat="server" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:BoundColumn DataField="IdRecupero" HeaderText="Id Recupero"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdProgetto" HeaderText="Progetto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IdAtto" HeaderText="Atto"></asp:BoundColumn>
                        <Siar:ColonnaLink DataField="Sostegno" HeaderText="Sostegno" IsJavascript="true" LinkFields="IdRecupero" 
                                          LinkFormat="selezionaRecupero({0});">
                        </Siar:ColonnaLink>
                        <asp:BoundColumn DataField="SpeseAmm" HeaderText="Spese Amminstr."></asp:BoundColumn>
                        <asp:BoundColumn DataField="DataRicevRimb" HeaderText="Dt. ricevim. rimborso"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RimbSostegno" HeaderText="Rimborso Sostegno"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RimbSpeseAmm" HeaderText="Rimborso Spese Amministr."></asp:BoundColumn>
                        <asp:BoundColumn DataField="NonRSostegno" HeaderText="Sostegno non recuper."></asp:BoundColumn>
                        <asp:BoundColumn DataField="NonRSpeseAmm" HeaderText="Spese amministr. non recuper."></asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        </table>
    </div>
    
    <div id="divDettaglio" runat="server">
        <table class="tableTab" id="tblDettaglioH" runat="server" width="1000px">
        <tr class="separatore_big">
            <td style="width:40%">
                Dettaglio Recupero
           </td>
           <td>
                <Siar:Button ID="btnElenco" runat="server" Text="Ritorna all'elenco" OnClick="btnRitorna_OnClick" 
                             Width="150px" CausesValidation="false" />
            </td>
        </tr>
        </table>
        <table class="tableTab" id="tblDettaglioR" runat="server" width="1000px" cellspacing="15">
        <tr>
            <td style="width:300px">
                Id Recupero
            </td>
            <td>
                <asp:TextBox ID="txtIdRecupero" runat="server" width="150px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Id Progetto
            </td>
            <td>
                <Siar:IntegerTextBox ID="txtIdProgetto" runat="server" Width="150px" NoCurrency="True" Obbligatorio="true" NomeCampo="Id Progetto" />
            </td>
        </tr>
        <tr>
            <td>
                Atto
            </td>
            <td>
                <table id="tblIdAtto" >
                    <tr>
                        <td>
                            Numero
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdAttoNr" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdAttoDt" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Registro
                        </td>
                        <td>
                            <asp:TextBox ID="txtIdAttoRe" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <Siar:Button ID="btnCercaAtto" runat="server" Text="Cerca Atto" OnClick="btnCercaAtto_Click" Width="100px" 
                                         Modifica="true" CausesValidation="false" />       
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Sostegno: importo del sostegno pubblico interessato da ciascuna decisione di recupero
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSostegno" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Spese ammissibili: spese totali ammissibili interessate da ciascuna decisione di recupero
            </td>
            <td>
                <Siar:CurrencyBox ID="txtSpeseAmm" runat="server" Width="150px"/>
            </td>
        </tr>
        <tr>
            <td>
                Data ricevimento rimborso: data di ricevimento di ogni importo rimborsato dal beneficiario 
                in seguito a una decisione di recupero
            </td>
            <td>
                <Siar:DateTextBox ID="txtDataRicevRimb" runat="server" Width="100px" Obbligatorio="true" NomeCampo="Data ricevimento rimborso" />
            </td>
        </tr>
        <tr>
            <td>
                Rimborso sostegno: importo del sostegno pubblico rimborsato dal beneficiario in seguito a una 
                decisione di recupero (senza interessi o penali)
            </td>
            <td>
                <Siar:CurrencyBox ID="txtRimbSostegno" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Rimborso spese ammissibili: spesa totale ammissibile corrispondente al sostegno pubblico rimborsato dal beneficiario
            </td>
            <td>
                <Siar:CurrencyBox ID="txtRimbSpeseAmm" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Sostegno non recuperabile: importo del sostegno pubblico non recuperabile in seguito a una decisione di recupero
            </td>
            <td>
                <Siar:CurrencyBox ID="txtNonRSostegno" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td>
                Spese ammissibile non recuperabilie: spesa totale ammissibile corrispondente al sostegno pubblico non recuperabile
            </td>
            <td>
                <Siar:CurrencyBox ID="txtNonRSpeseAmm" runat="server" Width="150px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva recupero" OnClick="btnSalva_OnClick" Width="150px" />
                <Siar:Button ID="btnCancella" runat="server" Text="Cancella recupero" OnClick="btnCancella_OnClick" 
                             Width="150px" CausesValidation="false" />
                <br /> <br />
            </td>
        </tr>
        </table>
    </div>
    
    <div id="divDecreto" style="width: 850px; position: absolute; display: none">
        <table class="tableNoTab" width="100%">
            <tr>
                <td class="separatore">
                    Caricamento Atto di Concessione/Non Finanziabilità
                </td>
            </tr>
            <tr>
                <td style="padding: 10px">
                    <table width="100%">
                        <tr>
                            <td style="width: 100px">
                                Definizione:<br />
                                <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True" Width="80px"></Siar:ComboDefinizioneAtto>
                            </td>
                            <td style="width: 100px">
                                Numero:<br />
                                <Siar:IntegerTextBox ID="txtAttoNumero" NoCurrency="True" runat="server" Width="80px" NomeCampo="Numero decreto" />
                            </td>
                            <td style="width: 120px">
                                Data:<br />
                                <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                            </td>
                            <td style="width: 155px">
                                Registro:<br />
                                <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="120px"></Siar:ComboRegistriAtto>
                            </td>
                            <td>
                                <br />
                                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click" Text="Ricerca" 
                                             Width="120px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                Descrizione:<br />
                                <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="650px" ReadOnly="True"
                                               Rows="4" ExpandableRows="5"></Siar:TextArea>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 260px">
                                            Organo Istituzionale:<br />
                                            <Siar:ComboOrganoIstituzionale ID="lstAttoOrgIstituzionale" runat="server" Width="210px" Enabled="False">
                                            </Siar:ComboOrganoIstituzionale>
                                        </td>
                                        <td>
                                            Tipo atto:<br />
                                            <Siar:ComboTipoAtto ID="lstAttoTipo" runat="server" NomeCampo="Tipo Atto"></Siar:ComboTipoAtto>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="350px">
                                    <tr>
                                        <td class="paragrafo" colspan="2">
                                            Pubblicazione B.U.R.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px">
                                            Numero:<br />
                                            <Siar:IntegerTextBox ID="txtAttoBurNumero" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                        <td>
                                            Data:<br />
                                            <Siar:DateTextBox ID="txtAttoBurData" runat="server" Width="120px" ReadOnly="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trDataComunicazione" runat="server" visible="false">
                <td style="padding-left: 10px">
                    Data del CDA per i GAL / Determina per le Province:<br />
                    <Siar:DateTextBox ID="txtAttoDataXComunicazione" runat="server" Width="100px" NomeCampo="Data per Comunicazione" />
                    <br /> <br />
                </td>
            </tr>
            <tr>
                <td class="separatore_light">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 58px; padding-right: 40px" align="right">
                    &nbsp;
                    <Siar:Button ID="btnAttoSeleziona" 
                                 runat="server" 
                                 OnClick="btnAttoSeleziona_Click"
                                 OnClientClick="return ctrlTipoAtto(event);" 
                                 Enabled="false" 
                                 Text="Seleziona Atto"
                                 Width="180px" 
                                 Modifica="true"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input class="Button" 
                           onclick="chiudiPopup()" 
                           style="width: 120px; margin-left: 80px" 
                           type="button" 
                           value="Chiudi" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
