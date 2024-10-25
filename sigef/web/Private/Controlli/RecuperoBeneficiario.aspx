<%@ Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="RecuperoBeneficiario.aspx.cs" Inherits="web.Private.Controlli.RecuperoBeneficiario" %>

<%@ Register Src="../../CONTROLS/SNCUploadFileControl.ascx" TagName="SNCUploadFileControl" TagPrefix="ucFU" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <style type="text/css">

        h1 {
            display: block;
            font-size: 22px;/*font-size: 2em;*/
            margin-top: 10px;/*margin-top: 0.67em;*/
            margin-bottom: 10px;/*margin-bottom: 0.67em;*/
            margin-left: 10px;
            margin-right: 0;
            font-weight: bold;
        }

        .first_elem_block {
            /*width: 250px;*/
            display: inline-block;
            *display: inline;
            zoom: 1;
            padding-bottom: 5px;
        }

        .elem_block {
            /*width: 250px;*/
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

        label {
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

    </style>
    
    <script type="text/javascript">

        function visualizzaOrdinativo(idOrdinativo) {
            SNCUFVisualizzaFile(idOrdinativo);
        }

        $('html').bind('keypress', function (e) {
            if (e.keyCode == 13) {
                return false;
            }
        });

        function eliminaOrdinativo(idOrdinativo) {
            if (confermaEliminaOrdinativo()) {
                $('[id$=hdnIdOrdinativo]').val(idOrdinativo);
                $('[id$=btnEliminaOrdinativo]').click();
            }
            else
                return false;
        }

        function sommaTotale() {
            var importoRecuperare = isEmpty($('[id$=txtContributo]').val()) ? 0 : parseFloat(($('[id$=txtContributo]').val().replace(/\./g, '')).replace(',', '.'));
            var interessiLegali = isEmpty($('[id$=txtInteressi]').val()) ? 0 : parseFloat(($('[id$=txtInteressi]').val().replace(/\./g, '')).replace(',', '.'));
            var speseNotifica = isEmpty($('[id$=txtSpese]').val()) ? 0 : parseFloat(($('[id$=txtSpese]').val().replace(/\./g, '')).replace(',', '.'));
            var sanzioni = isEmpty($('[id$=txtSanzioni]').val()) ? 0 : parseFloat(($('[id$=txtSanzioni]').val().replace(/\./g, '')).replace(',', '.'));
            var tot = importoRecuperare + interessiLegali + speseNotifica + sanzioni;
            $('[id$=txtTotale]').val(FromNumberToCurrency(Arrotonda(tot, 2)));
        }

        function readyFn(jQuery) {

            $('[id$=txtContributo]').change(sommaTotale);
            $('[id$=txtContributo]').change();

            $('[id$=txtInteressi]').change(sommaTotale);
            $('[id$=txtInteressi]').change();

            $('[id$=txtSpese]').change(sommaTotale);
            $('[id$=txtSpese]').change();

            $('[id$=txtSanzioni]').change(sommaTotale);
            $('[id$=txtSanzioni]').change();
        }

        function pageLoad() {
            readyFn();
        }

        function isEmpty(val) {
            return (val === undefined || val == null || val.length <= 0 || val == 'NaN') ? true : false;
        }

        function confermaEliminaOrdinativo() {
            var r = confirm("Eliminare l'ordinativo?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function confermaEliminaRecupero() {
            var r = confirm("Eliminare il recupero e tutti gli ordinativi associati?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function confermaRendiDefinitivo() {
            var r = confirm("Una volta reso definitivo non sarà più possibile modificare i dati, proseguire?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function confermaDisassociaAtto() {
            var r = confirm("Disassociare l'atto?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function confermaAssociaOrigine() {
            var r = confirm("Associare l'origine del recupero?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function visualizzaProtocollo() {
            sncAjaxCallVisualizzaProtocollo($('[id$=txtSegnatura]').val());
        }

        function verificaOrdinativo() {
            if ($('[id$=btnSNCUFAggiungiFile]').val()!='Rimuovi') {
                alert("Occorre caricare il documento per salvare l'ordinativo.");
                return false;
            }
            if (isEmpty($('[id$=txtNumeroOrdinativo]').val()) || isEmpty($('[id$=txtDataOrdinativo]').val()) || isEmpty($('[id$=txtImportoOrdinativo]').val()) || isEmpty($('[id$=txtQuietanzaOrdinativo]').val())) {
                alert("Inserire tutti i campi dell'ordinativo prima di salvare.");
                return false;
            }
            return true;
        }    

        function ctrlCampiRicercaNormeMarche(ev) {
            if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "") {
                alert('Per la ricerca degli atti è necessario specificare numero, data e registro.');
                return stopEvent(ev);
            }
        }

        function ctrlTipoAtto(ev) {
            if ($('[id$=hdnIdAtto]').val() == "") {
                alert('Per proseguire è necessario specificare un atto.');
                return stopEvent(ev);
            }
            else if ($('[id$=lstAttoTipo]').val() == "") {
                alert('Per proseguire è necessario specificare la tipologia dell`atto.');
                return stopEvent(ev);
            }

            //if (!confirm("Si sta per inserire l'atto per il recupero. Continuare?"))
            //    return stopEvent(ev);
        }

        function disassociaAtto(idOrdinativo) {
            if (confermaDisassociaAtto()) {
                $('[id$=hdnIdAttoDisassocia]').val(idOrdinativo);
                $('[id$=btnDisassociaAtto]').click();
            }
            else
                return false;
        }

        function associaOrigine(origine) {
            if (confermaAssociaOrigine()) {
                $('[id$=hdnOrigine]').val(origine);
                $('[id$=btnAssociaOrigine]').click();
            }
            else
                return false;
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdOrdinativo" runat="server" />
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
        <asp:HiddenField ID="hdnIdAttoDisassocia" runat="server" />
        <asp:HiddenField ID="hdnOrigine" runat="server" />
        <asp:Button ID="btnEliminaOrdinativo" runat="server" OnClick="btnEliminaOrdinativo_Click" CausesValidation="false" />
        <asp:Button ID="btnDisassociaAtto" runat="server" OnClick="btnDisassociaAtto_Click" CausesValidation="false" />
        <asp:Button ID="btnAssociaOrigine" runat="server" OnClick="btnAssociaOrigine_Click" CausesValidation="false" />
    </div>

    <div id="divRiepilogoRecupero" runat="server">
        <div style="text-align: center;">
            <h1>Recupero Beneficiario</h1>
        </div>
        <div id="divDatiRecupero" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
                Recupero
            </div>
            <div id="divMostraRecupero" style="padding: 15px;">
            <div class="first_elem_block">
                <label>ID Recupero:</label>
                <div class="value">
                    <Siar:TextBox ID="txtIdRecupero" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="first_elem_block">
                <label>ID Progetto:</label>
                <div class="value">
                    <Siar:TextBox ID="txtIdProgetto" runat="server" Width="120px"></Siar:TextBox>
                </div>
            </div>
            <div class="elem_block">
                <Siar:Button ID="btnCercaProgetto" runat="server" Width="120px" Text="Cerca"
                    OnClick="btnCercaProgetto_Click" CausesValidation="false"></Siar:Button>
            </div>
            <br />
            <br />
            <div id="divProgettoPresente" runat="server" style="display: none">
                <div class="first_elem_block">
                    <label>Destinatario:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstDestinatario" runat="server" NomeCampo="Origine"></Siar:ComboBase>
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Stato:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstStato" runat="server" NomeCampo="Origine">
                        </Siar:ComboBase>
                    </div>
                </div>
                <br />
                <br />

                <%--<div class="first_elem_block">
                    <label>Origine:</label>
                    <div class="value">
                        <Siar:ComboBase ID="lstOrigine" runat="server" NomeCampo="Origine">
                        </Siar:ComboBase>
                    </div>
                </div>
                <br />
                <br />--%>

               <%-- <div class="first_elem_block">
                    <label>Decreto/Atto recupero numero:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtNumeroAtto" runat="server" Width="100px"></Siar:TextBox>
                    </div>
                </div>
                <div class="elem_block">
                    <label style="width: 100px; min-width: 100px; max-width: 100px;">Data Atto:</label>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataAtto" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />--%>

                <div class="first_elem_block">
                    <label>Data Avvio Recupero:</label>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataAvvioRecupero" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Data inizio rateizzazione:</label>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataInizioRateizzazione" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Data fine prevista rateizzazione:</label>
                    <div class="value">
                        <Siar:DateTextBox ID="txtDataFineRateizzazione" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <%--<div class="first_elem_block">
                    <label>Segnatura comunicazione al beneficiario:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtSegnatura" runat="server" Width="250px"></Siar:TextBox>
                    </div>
                </div>
                <img id="imgSegnatura" runat="server" style="width: 23px; height: 23px; padding-left: 6px; padding-bottom: 8px; cursor: pointer;" onclick="visualizzaProtocollo()" />
                <br />
                <br />--%>

                <div class="first_elem_block">
                    <label>Importo Recuperato:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtImportoRecuperato" runat="server" Width="100px" ReadOnly="true" Enabled="false"></Siar:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div class="first_elem_block">
                    <label>Importo da recuperare:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtImportoIrrecuperabile" runat="server" Width="100px" ReadOnly="true" Enabled="false"></Siar:TextBox>
                    </div>
                </div>
                <br />
                <br />

               <%-- <div class="first_elem_block">
                    <label>Importo irrecuperabile</label>
                    <div class="value">
                        <asp:CheckBox ID="chkImportoIrrecuperabile" runat="server" />
                    </div>
                </div>
                <br />
                <br />--%>

               <%-- <div class="first_elem_block">
                    <label>Recupero completo</label>
                    <div class="value">
                        <asp:CheckBox ID="chkRecuperoCompleto" runat="server" />
                    </div>
                </div>
                <br />
                <br /> --%>

                <div class="paragrafo">Origine</div>
                <br />

                <div id="divOrigineRecupero" runat="server" style="display: none; padding: 15px;">
                    <Siar:DataGrid ID="dgOrigine" runat="server" AutoGenerateColumns="false" Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="Id" HeaderText="Id">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Tipologia" HeaderText="Tipologia">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Origine" HeaderText="Origine">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Importo" HeaderText="Importo">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <Siar:JsButtonColumn Arguments="IdETipologia" ButtonText="Associa" JsFunction="associaOrigine">
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </Siar:JsButtonColumn>
                        </Columns>
                    </Siar:DataGrid>
                    <br />
                    <br />
                </div>
                
                <%--SOMMA DA QUI--%>
                <div class="paragrafo">Importo da recuperare</div>
                <br />
                <div class="first_elem_block">
                    <label>Contributo:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtContributo" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />
                <div class="first_elem_block">
                    <label>Interessi:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtInteressi" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />
                <div class="first_elem_block">
                    <label>Spese:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtSpese" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />
                <div class="first_elem_block">
                    <label>Sanzioni:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtSanzioni" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />
                <div class="first_elem_block">
                    <label>Totale:</label>
                    <div class="value">
                        <Siar:CurrencyBox ID="txtTotale" runat="server" Width="100px" />
                    </div>
                </div>
                <br />
                <br />

                <div class="first_elem_block">
                    <label>Note:</label>
                    <div class="value">
                        <Siar:TextArea ID="txtAreaNote" runat="server" Width="395px" Rows="2" ExpandableRows="2"
                            MaxLength="8000"></Siar:TextArea>
                    </div>
                </div>
                <br />
                <br />
                <label id="lblOrdinativi" style="width: auto; min-width: inherit; max-width: inherit; padding-left: 100px" runat="server">(Per inserire gli ordinativi e gli atti occorre salvare prima il recupero)</label>
            </div>
        </div>
        <br />
        <br />

        <div id="divAttiRecupero" runat="server" style="display: none; padding: 15px;">
            <div class="paragrafo">Atti del recupero</div>
            <br />

            <Siar:DataGrid ID="dgAttiRecupero" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="Numero" HeaderText="Decreto">
                        <ItemStyle HorizontalAlign="Center" Width="140px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="TipoAtto">
                        <ItemStyle HorizontalAlign="Center"  Width="140px" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdAtto" ButtonText="Disassocia" JsFunction="disassociaAtto">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <br />

            <div class="first_elem_block">
                <label>Definizione:</label>
                <div class="value">
                    <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True" Width="100px"></Siar:ComboDefinizioneAtto>
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <label>Numero:</label>
                <div class="value">
                    <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="100px" NomeCampo="Numero decreto" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <label>Data:</label>
                <div class="value">
                    <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <label>Registro:</label>
                <div class="value">
                    <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px">
                    </Siar:ComboRegistriAtto>
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <br />
                    <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                        Text="Ricerca" Width="109px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
            </div>
            <br />
            <br />

            <div class="first_elem_block">
                <label>Descrizione:</label>
                <div class="value">
                    <Siar:TextArea ID="txtAttoDescrizione" runat="server" Width="600px" ReadOnly="True"
                        Rows="4" ExpandableRows="5"></Siar:TextArea>
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <Siar:Button ID="btnAssociaAttoRecupero" runat="server" OnClick="btnAssociaAttoRecupero_Click"
                    Text="Associa atto recupero" Width="160px" Modifica="True" OnClientClick="return ctrlTipoAtto(event);" />
            </div>

            <div class="elem_block">
                 <Siar:Button ID="btnAssociaAttoRateizzazione" runat="server" OnClick="btnAssociaAttoRateizzazione_Click"
                    Text="Associa atto rateizzazione" Width="160px" Modifica="True" OnClientClick="return ctrlTipoAtto(event);" />
            </div>

            
            <br />
            <br />
        </div>

        <div id="divOrdinativi" runat="server" style="display: none; padding: 15px;">
            <div class="paragrafo">Ordinativi d'Incasso</div>
            <br />

            <Siar:DataGrid ID="dgOrdinativi" runat="server" AutoGenerateColumns="false" Width="100%">
                <ItemStyle Height="30px" />
                <Columns>
                    <asp:BoundColumn DataField="Numero" HeaderText="Numero Ordinativo">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Importo" HeaderText="Importo">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="quietanza" HeaderText="Quietanza">
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:BoundColumn>
                    <Siar:JsButtonColumn Arguments="IdFileMandato" ButtonText="Visualizza" JsFunction="visualizzaOrdinativo" HeaderText="Documento">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                    <Siar:JsButtonColumn Arguments="IdOrdinativoIncasso" ButtonText="Elimina" JsFunction="eliminaOrdinativo">
                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                    </Siar:JsButtonColumn>
                </Columns>
            </Siar:DataGrid>
            <br />
            <br />
            <div class="first_elem_block">
                <label>Ordinativo:</label>
                <div class="value">
                    <ucFU:SNCUploadFileControl ID="ufOrdinativo" runat="server" TipoFile="Documento" />
                </div>
            </div>
            <br />
            <br />
            <div class="first_elem_block">
                <label>Numero ordinativo:</label>
                <div class="value">
                    <Siar:TextBox ID="txtNumeroOrdinativo" runat="server" Width="100px"></Siar:TextBox>
                </div>
            </div>
            <br />
            <br />
            <div class="first_elem_block">
                <label>Data Ordinativo:</label>
                <div class="value">
                    <Siar:DateTextBox ID="txtDataOrdinativo" runat="server" Width="100px" />
                </div>
            </div>
            <br />
            <br />

        <div class="first_elem_block">
            <label>Importo ordinativo:</label>
            <div class="value">
                <Siar:CurrencyBox ID="txtImportoOrdinativo" runat="server" Width="100px" />
            </div>
        </div>
        <br />
        <br />
        <div class="first_elem_block">
            <label>Importo quietanza:</label>
            <div class="value">
                <Siar:CurrencyBox ID="txtQuietanzaOrdinativo" runat="server" Width="100px" />
            </div>
        </div>
        <br />
        <br />
            <div class="first_elem_block" style="padding-left: 20px;">
                <Siar:Button ID="btnSalvaOrdinativo" runat="server" Width="150px" Text="Salva Ordinativo" OnClientClick="if(!verificaOrdinativo()) return false;"
                    OnClick="btnSalvaOrdinativo_Click" CausesValidation="false"></Siar:Button>
            </div>
            <br />
       </div>
    </div>
        <br />
        <div class="first_elem_block" style="padding-left: 20px;">
            <Siar:Button ID="btnSalvaRecupero" runat="server" Width="150px" Text="Salva Recupero"
                OnClick="btnSalvaRecupero_Click" CausesValidation="false"></Siar:Button>
        </div>

        <div class="elem_block">
            <Siar:Button ID="btnEliminaRecupero" runat="server" Width="150px" Text="Elimina Recupero" OnClientClick="if(!confermaEliminaRecupero()) return false;"
                OnClick="btnEliminaRecupero_Click" CausesValidation="false"></Siar:Button>
        </div>
        <div class="elem_block" style="visibility:hidden">
            <Siar:Button ID="btnRendiDefinitivo" runat="server" Width="150px" Text="Rendi Definitivo" OnClientClick="if(!confermaRendiDefinitivo()) return false;"
                OnClick="btnRendiDefinitivo_Click" CausesValidation="false"></Siar:Button>
        </div>
        <div class="elem_block">
            <Siar:Button ID="btnIndietro" runat="server" Width="150px" Text="Indietro"
                OnClick="btnIndietro_Click" CausesValidation="false"></Siar:Button>
        </div>
    </div>
</asp:Content>
