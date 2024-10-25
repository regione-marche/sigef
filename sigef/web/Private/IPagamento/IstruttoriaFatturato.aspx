<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="IstruttoriaFatturato.aspx.cs" Inherits="web.Private.IPagamento.IstruttoriaFatturato" %>

<%@ Register Src="../../CONTROLS/IDomandaPagamento.ascx" TagName="IDomandaPagamento"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">

    <script type="text/javascript"><!--
        function CalcoloRicavo(idfatturato) {
            var somma=0;sommarica=0;
            var ALI=FromCurrencyToNumber($('[id*=AliquotaIVA'+idfatturato+']').val());
            var impo=FromCurrencyToNumber($('[id*=Imponibile'+idfatturato+'_text]').val());
            ricavo=impo+impo*ALI/100;
            $('[id*=Ricavo'+idfatturato+']').text(FromNumberToCurrency(ricavo));
            var tot=$('[id*=Imponibile][id$=_text]');
            var ric=$('[id*=Ricavo][id*=_text]');
            //totale riga
            if(tot.length>0) {
                for(var i=0;i<tot.length;i++) { somma=somma+getNumber(tot[i].value); }
                $('[id$=lblFatturatoFooter]').html(FromNumberToCurrency(somma));
            }
            //totale riga
            if(ric.length>0) {
                for(var i=0;i<ric.length;i++) { sommarica=sommarica+getNumber(ric[i].innerHTML); }
                $('[id$=lblRicavoFooter]').html(FromNumberToCurrency(sommarica));
            }
        }
        function eliminaFatt(id) { if(confirm('Attenzione! Si sta per eliminare il dato selezionato. Continuare?')) { $('#ctl00_cphContenuto_hdnIdFatt').val(id);$('#ctl00_cphContenuto_btnEliminaFatt').click(); } }
        function controllaAliquota(ev) { if($("#ctl00_cphContenuto_lstAliquota option:selected").val()=='') { alert("Impossibile salvare. Specificare l'aliquota.");return stopEvent(ev); } }
        function getNumber(str) { if(str==null||str.length==0) return 0;while(str.indexOf('.')>=0) str=str.replace('.','');if(str.indexOf(',')>0) str=str.replace(',','.');return Number(str); }
//--></script>

    <div style="display: none">
        <asp:HiddenField ID="hdnIdFatt" runat="server" />
        <asp:Button ID="btnEliminaFatt" runat="server" Text="Button" OnClick="btnEliminaFatt_Click" />
    </div>
    <br />
    <uc2:IDomandaPagamento ID="ucIDomandaPagamento" runat="server" />
    <br />
    <table id="tbFatturato" class="tableNoTab" width="750px">
        <tr>
            <td class="separatore_big">
                ISTRUTTORIA DEL FATTURATO AZIENDALE
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Selezionare l' anno di riferimento per il fatturato: &nbsp;&nbsp;<Siar:ComboBase
                    ID="lstAnno" runat="server" NomeCampo="Anno" AutoPostBack="true">
                </Siar:ComboBase>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table class="tableTab" id="tabledatagrid" runat="server" style="width: 750px">
        <tr>
            <td align="center">
                <br />
                &nbsp;Aliquota IVA (%):
                <Siar:ComboAliquota ID="lstAliquota" runat="server" NomeCampo="Aliquota">
                </Siar:ComboAliquota>
                <Siar:Button ID="btnInsertProdotto" runat="server" Text="Inserisci" Width="151px"
                    OnClick="btnInsertProdotto_Click" Modifica="True" OnClientClick="return controllaAliquota(event)" /><br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgFatturato" runat="server" AutoGenerateColumns="False" CssClass="tabella"
                    PageSize="20" ShowShadow="False" Width="600px" Wrap="false" ShowFooter="True">
                    <PagerStyle CssClass="coda" />
                    <AlternatingItemStyle BackColor="#FFF0D2" CssClass="DataGridRow" />
                    <ItemStyle CssClass="DataGridRow" Height="18px" />
                    <FooterStyle CssClass="TESTA" />
                    <HeaderStyle BackColor="#ABAE80" CssClass="TESTA1" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundColumn DataField="Anno" HeaderText="Anno fatturato">
                            <ItemStyle Width="110px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IdFatturato" HeaderText="Classi aliquote"></asp:BoundColumn>
                        <Siar:ImportoColumn DataField="IdFatturato" HeaderText="Imponibile (€)" Name="Imponibile"
                            Importo="Importo">
                            <ItemStyle Width="140px" HorizontalAlign="Center"></ItemStyle>
                        </Siar:ImportoColumn>
                        <asp:BoundColumn HeaderText="Totale (€)">
                            <ItemStyle Width="120px" HorizontalAlign="Right"></ItemStyle>
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 57px">
                <Siar:Button ID="btnSalva" runat="server" Text="Salva" Width="130px" CausesValidation="False"
                    Modifica="True" OnClick="btnSalva_Click" />
                &nbsp; &nbsp
                <input id="btnBack" runat="server" class="Button" style="width: 160px" type="button"
                    onclick="location='CheckListPagamento.aspx'" value="Indietro" />
            </td>
        </tr>
    </table>
</asp:Content>
