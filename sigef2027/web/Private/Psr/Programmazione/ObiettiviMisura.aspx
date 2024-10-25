<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="ObiettiviMisura.aspx.cs" Inherits="web.Private.Psr.Programmazione.ObiettiviMisura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) { $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val() == id ? '' : id); $('[id$=btnProgrammazionePost]').click(); }
        function selezionaObMisura(id) { $('[id$=hdnIdObMisura]').val(id); $('[id$=btnProgrammazionePost]').click(); }
        function nuovoObMisura() { $('[id$=hdnIdObMisura]').val(''); $('[id$=txtObCodice]').val(''); $('[id$=txtObDescrizione]').val(''); $('[id$=btnObElimina]')[0].disabled = 'disabled'; }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnIdObMisura" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>
    <div class="row bd-form">
        <h2 class="pb-5">Obiettivi di misura e finalità degli interventi:</h2>


        <p>
            Elenco generale degli obiettivi di misura e delle finalità degli interventi.<br />
        </p>
        <div class="col-sm-12 form-group mt-5">            
            <Siar:ComboZPsr Label="Selezionare il programma desiderato:" ID="lstPsr" runat="server" AutoPostBack="true">
            </Siar:ComboZPsr>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgProgrammazione" CssClass="table table-striped" runat="server" AutoGenerateColumns="False">                
                <Columns>
                    <Siar:NumberColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="Id" LinkFormat="selezionaProgrammazione({0});">
                    </Siar:ColonnaLinkAgid>
                    <Siar:CheckColumnAgid DataField="Id" Name="chkProgrammazioneSelect" OnCheckClick="return false;">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="row" id="tbObMisura" runat="server" visible="false">
            <h3 class="pb-5">Elenco obiettivi associati:</h3>
            <div class="col-sm-12">
                <Siar:DataGridAgid ID="dgObMisura" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <Siar:NumberColumnAgid>
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:NumberColumnAgid>
                        <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                            LinkFields="Id" LinkFormat="selezionaObMisura({0});">
                        </Siar:ColonnaLinkAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <h3 class="pb-5">Dettaglio Obiettivo:</h3>
            <div class="col-sm-12 form-group">
                <Siar:TextBox  Label="Codice:" ID="txtObCodice" runat="server" NomeCampo="Codice" Obbligatorio="True"
                    MaxLength="10" />
            </div>
            <div class="col-sm-12 form-group">
                <Siar:TextArea Label="Descrizione:" ID="txtObDescrizione" runat="server" NomeCampo="Descrizione" Obbligatorio="True"
                    Rows="5" MaxLength="500" />
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnObSalva" runat="server" Modifica="True" OnClick="btnObSalva_Click"
                    Text="Salva" />
                <Siar:Button ID="btnObElimina" runat="server" OnClick="btnObElimina_Click" Text="Elimina"
                    Modifica="true" CausesValidation="false" Conferma="Attenzione! Eliminare l`obiettivo selezionato?" />
                <input class="btn btn-secondary py-1" type="button" value="Nuovo" onclick="nuovoObMisura();" />
            </div>
        </div>
    </div>
</asp:Content>
