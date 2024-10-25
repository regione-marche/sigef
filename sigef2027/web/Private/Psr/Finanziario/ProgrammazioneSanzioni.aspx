<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    CodeBehind="ProgrammazioneSanzioni.aspx.cs" Inherits="web.Private.Psr.Programmazione.ProgrammazioneSanzioni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">
        function selezionaProgrammazione(id) {
            $('[id$=hdnIdProgrammazione]').val($('[id$=hdnIdProgrammazione]').val() == id ? '' : id);
            $('[id$=btnProgrammazionePost]').click();
        }
        function selezionaSanzione(id) {
            $('[id$=hdnIdSanzione]').val(id);
            $('[id$=btnProgrammazionePost]').click();
        }
        function nuovaSanzione() {
            $('[id$=hdnIdSanzione]').val('');
            $('[id$=txtCod_Sanzione]').val('');
            $('[id$=txtAttiva]').val('');
            $('[id$=btnElimina]')[0].disabled = 'disabled';
        }
    </script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgrammazione" runat="server" />
        <asp:HiddenField ID="hdnIdSanzione" runat="server" />
        <asp:Button ID="btnProgrammazionePost" runat="server" OnClick="btnProgrammazionePost_Click"
            CausesValidation="false" />
    </div>

    <div class="row bd-form py-5 mx-2">
        <h2 class="Programmazione Sanzioni"></h2>
        <p>
            Gestione delle Sanzioni collegate alle Azioni della Programmazione.
        </p>
        <p>
            Selezionando un programma si avrà l'elenco delle "Azioni" a cui è collegato. 
        </p>
        <p>
            Selezionando una "Azione" si avrà a disposizione l'elenco delle "Sanzioni" ad essa collegabili. 
        </p>
        <p>
            Per attivare una "Sanzione" compilare il campo "Ordine", marcare il campo di spunta ed infine cliccare "Salva Sanzioni".
        </p>
        <br />
        <div class="col-sm-12 form-group py-5">
            <Siar:ComboZPsr ID="lstPsr" Label="Selezionare il programma desiderato" runat="server" AutoPostBack="true"></Siar:ComboZPsr>
        </div>
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgProgrammazione" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                <Columns>
                    <Siar:NumberColumnAgid>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </Siar:NumberColumnAgid>
                    <asp:BoundColumn DataField="Codice" HeaderText="Codice">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Tipo" HeaderText="Livello">
                        <ItemStyle Width="130px" HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:ColonnaLinkAgid DataField="Descrizione" HeaderText="Descrizione" IsJavascript="true"
                        LinkFields="Id" LinkFormat="selezionaProgrammazione({0});">
                    </Siar:ColonnaLinkAgid>
                    <Siar:CheckColumnAgid DataField="Id" Name="chkProgrammazioneSelect" OnCheckClick="return false;">
                        <ItemStyle Width="60px" HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
    </div>

    <h2 class="Elenco Sanzioni associate"></h2>
    <div id="tbSanzioni" runat="server" visible="false">
        <div class="col-sm-12">
            <Siar:DataGridAgid ID="dgSanzioni" CssClass="table table-striped" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                <Columns>
                    <Siar:NumberColumnAgid>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </Siar:NumberColumnAgid>
                    <asp:BoundColumn DataField="CodSanzione" HeaderText="Cod. Sanzione">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="SanzioneTitolo" HeaderText="Titolo Sanzione">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <Siar:IntegerColumn DataField="CodSanzione" Valore="Ordine" Name="dgTxtOrdine" NoCurrency="true" HeaderText="Ordine">
                        <ItemStyle HorizontalAlign="Right" />
                    </Siar:IntegerColumn>
                    <asp:BoundColumn DataField="DataInizio" HeaderText="Data Inizio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="CodSanzione" HeaderSelectAll="true" Name="chkSanzioneAttiva">
                        <ItemStyle HorizontalAlign="Center" />
                    </Siar:CheckColumnAgid>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12 pb-5 pe-5 text-end">
            <Siar:Button ID="btnSanzioniSalva" runat="server" OnClick="btnSanzioniSalva_Click" Text="Salva Sanzioni" Width="175px" Modifica="True" />
        </div>
    </div>
</asp:Content>
