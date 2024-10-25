<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits=" web.Private.Istruttoria.ModificaGraduatoriaProgetto" CodeBehind="ModificaGraduatoriaProgetto.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <style type="text/css">
        h1 {
            display: block;
            font-size: 22px; /*font-size: 2em;*/
            margin-top: 10px; /*margin-top: 0.67em;*/
            margin-bottom: 10px; /*margin-bottom: 0.67em;*/
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

    <div style="display: none">
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
    </div>

    <div id="divModificaGraduatoria" runat="server" class="dBox" style="margin-top: 10px; margin-bottom: 10px;">
        <div class="separatore">
            MODIFICA GRADUATORIA DOMANDA DI CONTRIBUTO CON DECRETO
        </div>
        <br />

        <p style="padding: 15px;">
            E' possibile modificare gli importi della spesa ammessa totale e del contributo totale ammesso 
            della singola domanda di contributo.<br />
            Solo il responsabile del procedimento può modificare queste informazioni salvo che la graduatoria sia almeno definitiva 
            e non riaperta e solamente ricercando il decreto che giustifichi tali modifiche.<br />
            E' sufficiente ricercare il decreto: se vengono visualizzate le relative informazioni l'atto è stato trovato
            e sarà automaticamente associato alla modifica.<br />
            Il sistema verificherà la disponibilità di fondi del bando ed eventualmente avviserà l'utente di aggiungerli 
            o ridurre il contributo ad altre domande prima di modificare in aumento.<br />
        </p>

        <div id="divDettaglioDomanda" runat="server" style="padding: 15px;">
            <div class="paragrafo">Dettaglio della domanda</div>
            <br />

            <div class="first_elem_block">
                <label>Numero domanda contributo:</label>
                <div class="value" style="display: block; width: 120px;">
                    <%--<Siar:TextBox ID="txtIdProgetto" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>--%>
                    <Siar:Label ID="txtIdProgetto" runat="server"></Siar:Label>
                </div>
            </div>

            <div class="elem_block">
                <label>Ragione sociale:</label>
                <div class="value">
                    <%--<Siar:TextBox ID="txtRagioneSociale" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>--%>
                    <Siar:Label ID="txtRagioneSociale" runat="server"></Siar:Label>
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <label>Partita iva:</label>
                <div class="value" style="display: block; width: 120px;">
                    <%--<Siar:TextBox ID="txtPartitaIva" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>--%>
                    <Siar:Label ID="txtPartitaIva" runat="server"></Siar:Label>
                </div>
            </div>

            <div class="elem_block">
                <label>Codice fiscale:</label>
                <div class="value">
                    <%--<Siar:TextBox ID="txtCodiceFiscale" runat="server" ReadOnly="true" Enabled="false" Width="120px"></Siar:TextBox>--%>
                    <Siar:Label ID="txtCodiceFiscale" runat="server"></Siar:Label>
                </div>
            </div>
            <br />

        </div>

        <div id="divAttiModificaGraduatoria" runat="server" style="padding: 15px;">
            <div class="paragrafo">Atto a giustificazione delle modifiche</div>
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
                <div class="value">
                    <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                        Text="Ricerca" Width="109px" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
                </div>
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

            <%-- <div class="first_elem_block">
                <Siar:Button ID="btnAssociaAttoModificaGraduatoria" runat="server" OnClick="btnAssociaAttoModificaGraduatoria_Click"
                    Text="Associa atto alla modifica" Width="160px" Modifica="True" Visible="false" OnClientClick="return ctrlTipoAtto(event);" />
            </div>
            <br />
            <br />--%>
        </div>

        <div id="divImportiProgettoGraduatoria" runat="server" style="padding: 15px;">
            <div class="paragrafo">Sezione importi</div>
            <br />

            <div class="first_elem_block">
                <label>Spesa totale ammessa precedente:</label>
                <div class="value">
                    <Siar:CurrencyBox ID="txtSpesaAmmessaPrecedente" ReadOnly="true" runat="server" Width="100px" />
                </div>
            </div>

            <div class="elem_block">
                <label>Spesa totale ammessa nuova:</label>
                <div class="value">
                    <Siar:CurrencyBox ID="txtSpesaAmmessaNuova" runat="server" Width="100px" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <label>Contributo totale ammesso precedente:</label>
                <div class="value">
                    <Siar:CurrencyBox ID="txtContributoAmmessoPrecedente" ReadOnly="true" runat="server" Width="100px" />
                </div>
            </div>

            <div class="elem_block">
                <label>Contributo totale ammesso nuovo:</label>
                <div class="value">
                    <Siar:CurrencyBox ID="txtContributoAmmessoNuovo" runat="server" Width="100px" />
                </div>
            </div>
            <br />

            <div class="first_elem_block">
                <label>Note:</label>
                <div class="value">
                    <Siar:TextArea ID="txtAreaNote" runat="server" Width="395px" Rows="2" ExpandableRows="2"
                        MaxLength="8000"></Siar:TextArea>
                </div>
            </div>
            <br />
        </div>

        <div class="first_elem_block">
            <div class="value">
                <Siar:Button ID="btnSalvaModifica" runat="server" OnClick="btnSalvaModifica_Click"
                    Text="Salva modifica" Width="150px" />
            </div>
        </div>
        <div class="elem_block">
            <div class="value">
                <Siar:Button ID="btnIndietro" runat="server" Width="150px" Text="Indietro"
                    OnClick="btnIndietro_Click" CausesValidation="false"></Siar:Button>
            </div>
        </div>
        <br />
        <br />
    </div>

</asp:Content>
