<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="PrioritaInvestimento.aspx.cs" Inherits="web.Private.Psr.Programmazione.PrioritaInvestimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) {
            $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click();
        }
        function selezionaPI(id) {
            $('[id$=hdnPI]').val($('[id$=hdnPI]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click();
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnPI" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>
    <div class="container-fluid bd-form">
        <h3>Priorità Investimenti
            </h3>
        <p class="py-3">
            Gestione delle Priorità di Investimento collegate alle Azioni della Programmazione.<br />
            Tramite il combo selezionare il POR desiderato, verranno quindi visualizzate le 
                Priorità di Investimento collegate.<br />
            Selezionando una Priorità di Investimento, verrà visualizzato l&#39;elenco delle 
                Azioni ad ess associate e le Azioni non ancora associate a nessuna Priorità.<br />
            Selezionare tramite il checkbox le Azioni da collegare alla Priorità di 
                Investimento e salvare con il pulsante &quot;Salva&quot;.<br />
        </p>
        <div class="col-sm-4 form-group pt-5">

            <Siar:ComboZPsr Label="Selezionare il programma desiderato" ID="lstPsr" runat="server" AutoPostBack="true">
            </Siar:ComboZPsr>
        </div>
        <div class="col-sm-12 ">
            <Siar:DataGridAgid ID="dgPI" CssClass="table table-striped" runat="server" AutoGenerateColumns="false">                
                <Columns>
                    <Siar:NumberColumn>
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="Id" LinkFormat="selezionaPI({0});">
                    </Siar:ColonnaLinkAgid>
                    <Siar:CheckColumnAgid DataField="Id" Name="chkPISelect" OnCheckClick="return false;">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div id="tbDettaglio" class="row" runat="server" visible="false">
            <div class="col-sm-12 ">
                <Siar:DataGridAgid ID="dgProgrammazione" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" >                    
                    <Columns>
                        <Siar:NumberColumn>
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="CodProgrammazione" HeaderText="Codice">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="LivelloProgrammazione" HeaderText="Livello">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DesProgrammazione" HeaderText="Azione"></asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdProgrammazione" Name="chkProgrammazioneSelect" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12 ">
                <Siar:Button ID="btnSalva" runat="server" OnClick="btnSalva_Click" Text="Salva" Width="175px" Modifica="True" />
            </div>
        </div>
    </div>
</asp:Content>
