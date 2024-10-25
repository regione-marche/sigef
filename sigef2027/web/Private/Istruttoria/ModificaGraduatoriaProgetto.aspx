<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits=" web.Private.Istruttoria.ModificaGraduatoriaProgetto" CodeBehind="ModificaGraduatoriaProgetto.aspx.cs" %>

<%@ Register Src="../../CONTROLS/InfoDomanda.ascx" TagName="InfoDomanda" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <div style="display: none">
        <asp:HiddenField ID="hdnIdAtto" runat="server" />
    </div>

    <uc2:InfoDomanda ID="ucInfoDomanda" runat="server" />
    <br />

    <h3>Modifica graduatoria domanda di contributo</h3>
    <p>
        E' possibile modificare gli importi della spesa ammessa totale e del contributo totale ammesso 
            della singola domanda di contributo.<br />
        Solo il responsabile del procedimento può modificare queste informazioni salvo che la graduatoria sia almeno definitiva 
            e non riaperta e solamente ricercando il decreto che giustifichi tali modifiche.<br />
        E' sufficiente ricercare il decreto: se vengono visualizzate le relative informazioni l'atto è stato trovato
            e sarà automaticamente associato alla modifica.<br />
        Il sistema verificherà la disponibilità di fondi del bando ed eventualmente avviserà l'utente di aggiungerli 
            o ridurre il contributo ad altre domande prima di modificare in aumento.<br />
    </p>
    <br />

    <div id="divAttiModificaGraduatoria" runat="server">
        <h4>Atto a giustificazione delle modifiche</h4>

        <div class="row bd-form pt-5" runat="server" id="trDecreti">
            <div class="col-sm-2 form-group">
                <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstAttoDefinizione" runat="server" NoBlankItem="True">
                </Siar:ComboDefinizioneAtto>
            </div>
            <div class="col-sm-2 form-group">
                <Siar:IntegerTextBox Label="Numero:" NoCurrency="True" ID="txtAttoNumero" runat="server" NomeCampo="Numero decreto" />
            </div>
            <div class="col-sm-2 form-group">
                <Siar:DateTextBox Label="Data:" ID="txtAttoData" runat="server" NomeCampo="Data decreto" />
            </div>
            <div class="col-sm-4 form-group">
                <Siar:ComboRegistriAtto Label="Registro:" ID="lstAttoRegistro" runat="server">
                </Siar:ComboRegistriAtto>
            </div>
            <div class="col-sm-2 text-start">
                <Siar:Button ID="btnCercaDecreto" runat="server" OnClick="btnCercaDecreto_Click"
                    Text="Ricerca" OnClientClick="return ctrlCampiRicercaNormeMarche(event);" />
            </div>

            <div class="col-sm-12 form-group">
                <Siar:TextArea ID="txtAttoDescrizione" Label="Descrizione:" runat="server" ReadOnly="True"
                    Rows="4" ExpandableRows="5"></Siar:TextArea>
            </div>
        </div>
    </div>
    <br />

    <div id="divImportiProgettoGraduatoria" runat="server">
        <h4>Sezione importi</h4>

        <div class="row bd-form pt-5" runat="server" id="trImportiProgettoGraduatoria">
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox ID="txtSpesaAmmessaPrecedente" Label="Spesa totale ammessa precedente:" ReadOnly="true" runat="server" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox ID="txtSpesaAmmessaNuova" Label="Spesa totale ammessa nuova:" runat="server" />
            </div>

            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox ID="txtContributoAmmessoPrecedente" Label="Contributo totale ammesso precedente" ReadOnly="true" runat="server" />
            </div>
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox ID="txtContributoAmmessoNuovo" Label="Contributo totale ammesso nuovo:" runat="server" />
            </div>

            <div class="col-sm-12 form-group">
                <Siar:TextArea ID="txtAreaNote" runat="server" Label="Note:" Rows="2" ExpandableRows="2"
                    MaxLength="8000"></Siar:TextArea>
            </div>
        </div>

    </div>
    <br />

    <div class="col-sm-12">
        <Siar:Button ID="btnSalvaModifica" runat="server" OnClick="btnSalvaModifica_Click"
            Text="Salva modifica" />

        <Siar:Button ID="btnIndietro" runat="server" Text="Indietro"
            OnClick="btnIndietro_Click" CausesValidation="false"></Siar:Button>
    </div>
    <br />

</asp:Content>
