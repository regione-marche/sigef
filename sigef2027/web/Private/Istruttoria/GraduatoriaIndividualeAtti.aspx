<%@ Page Title="" Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true" CodeBehind="GraduatoriaIndividualeAtti.aspx.cs" Inherits="web.Private.Istruttoria.GraduatoriaIndividualeAtti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript">

        function selezionaRiga(riga) {
            $('[id$=HdnIdGradProgettiAtti]').val(riga);
            $('[id$=btnSelezionaProgettiAtti]').click();
        }
    </script>



    <br />
    <div style="display: none">
        <asp:HiddenField ID="hdnIdProgetto" runat="server" />
        <asp:HiddenField ID="HdnIdGradProgettiAtti" runat="server" />
        <asp:Button ID="btnSelezionaProgettiAtti" runat="server" OnClick="btnSelezionaGradProgettiAtti_Click" CausesValidation="false" />
    </div>



    <div class="tableNoTab row">
        <h2>Elenco Decreti Graduatoria
        </h2>
        <p>
            Nella sezione sottostante è possibile aggiungere piu decreti di finanziabilità ad un progetto
        </p>
        <div class="col-sm-12 text-end mb-5">
            <input id="btnBack" runat="server" class="btn btn-secondary py-1" type="button"
                onclick="location = 'GraduatoriaIndividuale.aspx'" value="Indietro" /><br />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:IntegerTextBox Label="Id Progetto:" ID="txtProgetto" runat="server" ReadOnly />
        </div>
        <div class="col-sm-6 form-group">
            <Siar:CurrencyBox Label="Contributo Totale €:" ID="txtContributoTotale" runat="server" ReadOnly />
        </div>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <h3>Elenco dei decreti e relativi importi</h3>
        <div class="col-sm-12">

            <Siar:DataGridAgid CssClass="table table-striped" ID="dgGradAtti" runat="server" AutoGenerateColumns="False"
                AllowPaging="False" ShowFooter="true">
                <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                <ItemStyle Height="26px" />
                <Columns>
                    <Siar:ColonnaLinkAgid LinkFields="IdGraduatoriaProgettiAtti" LinkFormat="javascript:selezionaRiga({0});"
                        DataField="IdGraduatoriaProgettiAtti" HeaderText="ID" ItemStyle-Width="20px">
                    </Siar:ColonnaLinkAgid>
                    <asp:BoundColumn DataField="Importo" HeaderText="Contributo Concesso" DataFormatString="{0:c}">
                        <ItemStyle HorizontalAlign="right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Decreto">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
        </div>
        <div class="col-sm-12">
            <Siar:Button ID="Button1" runat="server" OnClick="AggiungiDecr_Click"
                Text="Aggiungi decreto" Modifica="False" />
        </div>
        <div runat="server" id="divAtto" class="row bd-form pt-5" visible="false">
            <div class="col-sm-6 form-group">
                <Siar:CurrencyBox Label="Importo €:" ID="txtAttoImporto" runat="server" />
            </div>
            <div class="col-sm-6 form-group">
            </div>
            <div class="col-sm-3 form-group">
                <Siar:ComboDefinizioneAtto Label="Definizione:" ID="lstAttoDefinizione" runat="server" NoBlankItem="True">
                </Siar:ComboDefinizioneAtto>
            </div>
            <div class="col-sm-3 form-group">
                <Siar:IntegerTextBox Label="Numero:" NoCurrency="True" ID="txtAttoNumero" runat="server" NomeCampo="Numero decreto" />
            </div>
            <div class="col-sm-3 form-group">
                <Siar:DateTextBoxAgid Label="Data:" ID="txtAttoData" runat="server" NomeCampo="Data decreto" />
            </div>
            <div class="col-sm-3 form-group">

                <Siar:ComboRegistriAtto Label="Registro:" ID="lstAttoRegistro" runat="server">
                </Siar:ComboRegistriAtto>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaRiga" runat="server" OnClick="btnSalvaRiga_Click"
                    Text="Salva dati" Modifica="False" />
            </div>
        </div>
    </div>
</asp:Content>
