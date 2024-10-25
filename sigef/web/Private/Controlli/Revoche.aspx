<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" 
    CodeBehind="Revoche.aspx.cs" Inherits="web.Private.Controlli.Revoche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

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

        $('html').bind('keypress', function (e) {
            if (e.keyCode == 13) {
                return false;
            }
        });

        function MostraNascondiDiv(id) {
            var div;
            var img;
            switch (id) {
                case 0:
                    div = $('[id$=divMostraRevoca]');
                    img = $('[id$=imgMostraRevoca]')[0];
                    break;
                case 1:
                    div = $('[id$=divMostraRecuperoBeneficiario]');
                    img = $('[id$=imgMostraRecuperoBeneficiario]')[0];
                    break;
            }
            if (img.style.transform == "")
                img.style.transform = "rotate(180deg)";
            else
                img.style.transform = "";

            if (div[0].style.display === "none")
                div.show("fast");
            else
                div.hide("fast");
        }

        function mostraDatiIrrecuperabile() {
            if ($('[id$=chkIrrecuperabile]').is(':checked')) {
                $('[id$=divDatiIrrecuperabile]').show("fast");
            }
            else {
                $('[id$=divDatiIrrecuperabile]').hide("fast");
            }
        }

        function isEmpty(val) {
            return (val === undefined || val == null || val.length <= 0 || val == 'NaN') ? true : false;
        }

        function sommaTotale() {
            importoRecuperare = FromCurrencyToNumber($('[id$=txtImportoDaRecuperare]').val());
            interessiLegali = FromCurrencyToNumber($('[id$=txtInteressiLegali]').val());
            speseNotifica = FromCurrencyToNumber($('[id$=txtSpeseNotifica]').val());
            sanzioni = FromCurrencyToNumber($('[id$=txtSanzioni]').val());

            tot = importoRecuperare + interessiLegali + speseNotifica + sanzioni;
            $('[id$=txtTotale]').val(FromNumberToCurrency(tot));
        }

        function readyFn(jQuery) {
            $('[id$=chkIrrecuperabile]').change(mostraDatiIrrecuperabile);
            $('[id$=chkIrrecuperabile]').change();

            $('[id$=txtImportoDaRecuperare]').change(sommaTotale);
            $('[id$=txtImportoDaRecuperare]').change();

            $('[id$=txtInteressiLegali]').change(sommaTotale);
            $('[id$=txtInteressiLegali]').change();

            $('[id$=txtSpeseNotifica]').change(sommaTotale);
            $('[id$=txtSpeseNotifica]').change();

            $('[id$=txtSanzioni]').change(sommaTotale);
            $('[id$=txtSanzioni]').change();
        }

        function pageLoad() {
            readyFn();
        }

        function confermaElimina()
        {
            var r = confirm("Eliminare la revoca e tutti gli ordinativi associati?");
            if (r == true) {
                return true;
            } else {
                return false;
            }
        }

        function ctrlSalva(ev) {
            if ($('[id$=txtIdProgetto_text]').val() == "") { alert('Per proseguire è necessario inserire il progetto.'); return stopEvent(ev); }
            if ($('[id$=lstDestinatario]').val() == "") { alert('Per proseguire è necessario inserire il beneficiario.'); return stopEvent(ev); }


            //if ($('[id$=txtAttoNumero_text]').val() == "" || $('[id$=txtAttoData_text]').val() == "" || $('[id$=lstAttoRegistro]').val() == "" || $('[id$=lstAttoDefinizione]').val() == "") { alert('Per proseguire è necessario inserire il numero, data, registro e tipo dell atto o decreto.'); return stopEvent(ev); }
        }

        function selezionaRecupero(idRecupero) {
            $('[id$=hdnIdRecupero]').val($('[id$=hdnIdRecupero]').val() == idRecupero ? '' : idRecupero);
            $('[id$=btnVisualizzaRecupero]').click();
        }

    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdRecupero" runat="server" />
        <asp:Button ID="btnVisualizzaRecupero" runat="server" OnClick="btnVisualizzaRecupero_Click" CausesValidation="false" />
    </div>

    <div id="divRiepilogoRevoca" runat="server">
        <div style="text-align: center;">
            <h1>Scheda Revoche</h1>
        </div>
        <div id="tdDomanda" runat="server" style="margin: 10px; text-align: center;">
        </div>

        <div id="divDatiRevoca" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="separatore" style="padding-bottom: 3px; cursor: pointer;" onclick="MostraNascondiDiv(0); return false;">
                <img id="imgMostraRevoca" runat="server" style="width: 23px; height: 23px;" />
                Revoca
            </div>

            <div id="divMostraRevoca" style="padding: 15px;">

                <div class="first_elem_block">
                    <label>ID Revoca:</label>
                    <div class="value">
                        <Siar:TextBox ID="txtIdRevoca" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>
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
                <div id="divProgettoPresente" runat="server" style="display:none">
                    <div class="first_elem_block">
                        <label>Stato Progetto:</label>
                        <div class="value">
                           <Siar:TextBox ID="txtStatoProgetto" ReadOnly="true" runat="server" Width="120px"></Siar:TextBox>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="first_elem_block">
                        <label>Beneficiario (indicare l'eventuale capofila):</label>
                        <div class="value">
                            <Siar:ComboBase ID="lstDestinatario" runat="server" NomeCampo="Origine"></Siar:ComboBase>
                        </div>
                    </div>
                    <br />
                    <br />

<%--                    <div class="first_elem_block">
                        <label>Origine:</label>
                        <div class="value">
                            <Siar:ComboBase ID="lstOrigine" runat="server" NomeCampo="Origine">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <br />
                    <br />--%>

                    <div class="first_elem_block">
                        <label>Note:</label>
                        <div class="value">
                            <Siar:TextArea ID="txtAreaNote" runat="server" Width="395px" Rows="2" ExpandableRows="2"
                                MaxLength="8000"></Siar:TextArea>
                        </div>
                    </div>
                    <br />
                    <br />
                    
                    <div class="first_elem_block">
                        <label>Contributo Ammissibile (totale del progetto):</label>
                        <div class="value">
                            <Siar:CurrencyBox ID="txtContributoAmm" ReadOnly="true" runat="server" Width="100px" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="first_elem_block">
                        <label>Contributo da revocare:</label>
                        <div class="value">
                            <Siar:CurrencyBox ID="txtImporto" runat="server" Width="100px" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div runat ="server"  id="divAtto">
                        <div class="first_elem_block">
                            <label>Decreto/Atto Numero:</label>
                            <div class="value">
                                <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="80px" NomeCampo="Numero decreto" />
                            </div>
                        </div>
                        <div class="elem_block">
                            <label style="width: 100px; min-width: 100px; max-width: 100px;">Data:</label>
                            <div class="value">
                               <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                            </div>
                        </div>
                        <div class="elem_block">
                            <label style="width: 100px; min-width: 100px; max-width: 100px;">Registro:</label>
                            <div class="value">
                              <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px"></Siar:ComboRegistriAtto>
                            </div>
                        </div>
                        <div class="elem_block">
                            <label style="width: 100px; min-width: 100px; max-width: 100px;">Definizione:</label>
                            <div class="value">
                              <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True" Width="80px"></Siar:ComboDefinizioneAtto>
                                <input id="btnVisualizzaDecreto" runat="server" class="Button" style="width: 130px;    margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />
                            </div>
                        </div>         
                    </div>
                    <div runat ="server"  id="divAttoOrgInt" visible =" false">
                        <div class="first_elem_block">
                            <label>Decreto/Atto Numero:</label>
                            <div class="value">
                                <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumeroOrgInt" runat="server" Width="80px"  />
                            </div>
                        </div>
                        <div class="elem_block">
                            <label style="width: 100px; min-width: 100px; max-width: 100px;">Data:</label>
                            <div class="value">
                               <Siar:DateTextBox ID="txtAttoDataOrgInt" runat="server" Width="100px" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="first_elem_block">
                            <label>Descrizione/Titolo Atto:</label>
                            <div class="value">
                                 <Siar:TextArea Rows="3" MaxLength="3000" ID="txtDescrAttoOrgInt" runat="server" Width="630px"  /> 
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="first_elem_block">
                            <label>Link Esterno Atto:</label>
                            <div class="value">
                                <Siar:TextBox ID="txtLinkEstOrgInt" runat="server" Width="430px"  />
                            </div>
                        </div>
                        <input id="btnVisualizzaDecretoOrgInt" runat="server" class="Button" style="width: 130px;    margin-left: 30px; margin-right: 20px" type="button" disabled="disabled" value="Visualizza atto" />
                    </div>
                    <br />
                    <br />
                    <div class="first_elem_block">
                        <label>Revoca totale dell'importo:<br />(Selezionando SI verrà cambiato lo stato del progetto in REVOCATO)</label>
                        <div class="value">
                            <Siar:ComboBase ID="lstRevocaTotale" runat="server" NomeCampo="RecuperareBeneficiario">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="first_elem_block">
                        <label>Da recuperare c/o il beneficiario:</label>
                        <div class="value">
                            <asp:CheckBox ID="chkDaRecuperare" runat="server" />
                        </div>
                    </div>
                    <br />
                    <br />

                    <div id="divMostraPulsanteCreaRecupero" class="first_elem_block" runat="server">
                        <Siar:Button ID="btnCreaRecuperoDaRevoca" runat="server" Text="Crea recupero associato alla revoca"
                            OnClick="btnCreaRecuperoDaRevoca_Click" CausesValidation="false"></Siar:Button>
                    </div>
                    <br />
                    <br />

                    <div id="divMostraRecuperoAssociato" runat="server">
                        <Siar:DataGrid ID="dgRecuperi" runat="server" AutoGenerateColumns="false" Width="100%">
                            <ItemStyle Height="30px" />
                            <Columns>
                                <asp:BoundColumn DataField="IdRecuperoBeneficiario" HeaderText="Id Recupero">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdProgetto" HeaderText="Id Progetto">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="RagioneSocialeImpresa" HeaderText="Beneficiario">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <Siar:CheckColumn DataField="Definitivo" HeaderText="Definitivo" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                </Siar:CheckColumn>
                                <Siar:JsButtonColumn Arguments="IdRecuperoBeneficiario" ButtonText="Visualizza elemento" JsFunction="selezionaRecupero">
                                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                                </Siar:JsButtonColumn>
                            </Columns>
                        </Siar:DataGrid>
                        <br />
                        <br />
                    </div>

                   <%-- <div class="first_elem_block">
                        <label>Revocare il contributo:</label>
                        <div class="value">
                            <Siar:ComboBase ID="lstRevocare" runat="server" NomeCampo="Revocare">
                            </Siar:ComboBase>
                        </div>
                    </div>
                    <br />
                    <br />--%>
                </div>
        </div>
    </div>
       
        <div class="first_elem_block" style="padding-left:20px;">
            <Siar:Button ID="btnSalvaRevoca" runat="server" Width="150px" Text="Salva Revoca" OnClientClick="return ctrlSalva(event);"
                OnClick="btnSalvaRevoca_Click" CausesValidation="false"></Siar:Button>
        </div>

        <div class="elem_block">
            <Siar:Button ID="btnEliminaRevoca" runat="server" Width="150px" Text="Elimina Revoca" OnClientClick="if(!confermaElimina()) return false;"
                OnClick="btnEliminaRevoca_Click" CausesValidation="false"></Siar:Button>
        </div>
        <div class="elem_block">
            <Siar:Button ID="btnIndietro" runat="server" Width="150px" Text="Indietro"
                OnClick="btnIndietro_Click" CausesValidation="false"></Siar:Button>
        </div>
    </div>
</asp:Content>
