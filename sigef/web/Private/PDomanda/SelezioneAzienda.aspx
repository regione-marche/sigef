<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.PDomanda.SelezioneAzienda" CodeBehind="SelezioneAzienda.aspx.cs" %>

<%@ Register Src="~/CONTROLS/ImpresaControl.ascx" TagName="ImpresaControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript"><!--
        function ctrlCuaaDitta(ev) {
            var text_box_cuaa=$('[id$=txtCuaaRicerca_text]')[0];var cuaa=$(text_box_cuaa).val();cuaa=$.trim(cuaa);
            if(cuaa!=null&&cuaa!=""&&!ctrlCodiceFiscale(cuaa)&&!ctrlPIVA(cuaa)) {
                alert('Attenzione! Il Codice Fiscale inserito per la ricerca della ditta non è valido.');return stopEvent(ev);
                //$(text_box_cuaa).select();
            }
        }
        function scaricaAnagrafica(cuaa) { $('[id$=txtCuaaRicerca_text]').val(cuaa); $('[id$=btnCercaWS]').click(); }

        function switchMostraInserisciImpresa() {
            var div = $('[id$=divInserisciImpresa]');
            var btn = $('[id$=btnInserisciImpresa]')[0];

            if (div[0].style.display === "none") {
                div.show("fast");
                btn.value = "Nascondi inserisci impresa";
            } else {
                div.hide("fast");
                btn.value = "Mostra inserisci impresa";
            }
        }

        function controllaAutodichiarazione() {
            var btn = $('[id$=btnSalvaConDichiarazione]')[0];

            if (($('[id$=chckAutodichiarazione]')[0].checked)) {
                btn.disabled = false;
            }
            else {
                btn.disabled = true;
            }
        }

        function pageLoad() {
            controllaAutodichiarazione();
        }
           
//--></script>

    <table class="tableNoTab" width="800px">
        <tr>
            <td class="separatore_big">
                PRESENTAZIONE DOMANDA DI AIUTO
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Specificare il <b>Codice Fiscale</b> o la <b>Ragione sociale</b> dell'impresa per cui presentare
                la domanda di aiuto.<br />
                Qualora l'azienda non fosse presente nel <b>database regionale</b> effettuare il
                download dei dati dall'<b>Anagrafe Tributaria</b>.<br />
                La ricerca viene effettuata tra i soggetti per cui l'utente e' abilitato a operare,
                nel caso in cui l&#39;impresa desiderata<br />
                non venga trovata, o per qualsiasi altra segnalazione si prega di contattare l'helpdesk.
            </td>
        </tr>
        <tr>
            <td class="separatore_light">
                Selezione dell'impresa beneficiaria:
            </td>
        </tr>
        <tr>
            <td style="padding: 10px">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 215px;">
                            <b>Ricerca per Codice Fiscale:</b>
                        </td>
                        <td>
                            <b>Ricerca per ragione sociale:</b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 215px">
                            <Siar:TextBox ID="txtCuaaRicerca" runat="server" Obbligatorio="true" NomeCampo="Partita iva/Codice fiscale"
                                Width="150px" Style="text-align: left" />
                        </td>
                        <td>
                            <Siar:TextBox ID="txtRagSociale" runat="server" Width="289px" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 215px" align="center">
                            (inserire il codice fiscale dell'impresa/ente da ricercare)
                        </td>
                        <td>
                            (consigliato digitare una sola parola o parte di essa)
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px">
                <Siar:Button ID="btnCercaDB" runat="server" Width="220px" Text="Cerca sul database locale"
                    CausesValidation="False" OnClick="btnCercaDB_Click"></Siar:Button>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                <input runat="server" id="btnInserisciImpresa" type="button" style="width:220px" Visible="false"
                    class="ButtonGrid" value="Mostra inserisci impresa"
                    onclick="switchMostraInserisciImpresa();" />
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                <Siar:Button ID="btnCercaWS" runat="server" Visible="false"
                    Width="220px" Text="Cerca su Anagrafe Tributaria" OnClick="btnCercaWS_Click"
                    CausesValidation="TRUE"></Siar:Button>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <Siar:DataGrid ID="dg" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="30px"></ItemStyle>
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Right" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="RagioneSociale" HeaderText="Ragione sociale"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Cuaa" HeaderText="Codice Fiscale">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CodiceFiscale" HeaderText="Cf/P.Iva">
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle HorizontalAlign="Center" Width="160px" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid><br />
            </td>
        </tr>
    </table>
    <br />
    <br />

    <div runat="server" id="divInserisciImpresa" class="dBox" style="display: none; width: 800px;" >
        <div class="separatore" >
            Inserisci una nuova impresa
        </div>
        <br />
        
        <div style="padding: 5px;">
            <p>Prima di inserire una nuova impresa verificare che non esista già!</p>
            <br />
            <b>TUTTI I CAMPI SONO OBBLIGATORI</b>
            <br />
            <br />

            <asp:CheckBox ID="chckAutodichiarazione" runat="server" onchange="controllaAutodichiarazione();" />  
            <label for="chckAutodichiarazione">DICHIARAZIONE SOSTITUTIVA DELL’ATTO DI NOTORIETA’<br />
                Il sottoscritto, in qualità di legale rappresentante oppure persona da lui delegata, 
                consapevole delle responsabilità anche penali derivanti dal rilascio di dichiarazioni mendaci 
                ai sensi degli articoli 75 e 76 del D.P.R. 445/2000, dichiara ai sensi dell’articolo 47 del D.P.R. 445/2000:<br />
                - di essere autorizzato, all'inserimento dei dati anagrafici del soggetto richiedente necessari e utili ai fini della 
                presentazione di istanze sul sistema informatico della Regione Marche. Il sottoscritto si impegna inoltre a rendere la 
                necessaria documentazione ai fini istruttori.<br />
            </label>

            <uc3:ImpresaControl ID="ucImpresaControl" runat="server" ContoCorrenteVisibile="True"
                ClassificazioneUmaVisibile="false" InserisciImpresaPerPresentazioneDomanda="True" />
        </div>
    </div>
</asp:Content>
