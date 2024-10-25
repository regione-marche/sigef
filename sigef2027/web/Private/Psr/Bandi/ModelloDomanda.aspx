<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.Psr.Bandi.ModelloDomanda" CodeBehind="ModelloDomanda.aspx.cs" %>

<%@ Register Src="../../../CONTROLS/SiarNewTabAgid.ascx" TagName="SiarNewTab" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <div class="row bd-form">
        <h3 class="mt-5 pb-5">Modello di domanda associato al bando:</h3>
        <div class="col-sm-12 form-group">
            <Siar:TextBox  Label="Denominazione:" ID="txtDenominazione" runat="server" NomeCampo="Denominazione" Obbligatorio="True" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Descrizione:" ID="txtDescrizioneLunga" runat="server" NomeCampo="Descrizione"
                Obbligatorio="True" Rows="6"></Siar:TextArea>
        </div>
        <div class="col-sm-12 mb-5">
            <Siar:Button ID="btnStampa" runat="server" Text="Prova di stampa" OnClick="btnStampa_Click" />
            <Siar:Button ID="btnSalvaReport" runat="server" OnClick="btnSalvaReport_Click"
                Text="Salva Report" />
            <Siar:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" Modifica="true"></Siar:Button>
        </div>
        <uc2:SiarNewTab ID="ucSiarNewTab" runat="server" TabNames="Quadri domanda|Dichiarazioni|Allegati" />
        <div class="tableTab row" id="tableQuadri" runat="server" width="800px" visible="false">
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgQuadri" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="Denominazione" HeaderText="Denominazione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <Siar:IntegerColumn DataField="IdQuadro" HeaderText="Ordine" Valore="Ordine" Name="OrdineQuadro">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:IntegerColumn>
                        <Siar:CheckColumnAgid DataField="IdQuadro" Name="chkQuadro" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaQuadri" runat="server" OnClick="btnSalvaQuadri_Click" Text="Salva" CausesValidation="False" Modifica="true" />
            </div>
        </div>
        <div class="tableTab row" id="tableDichiarazioni" runat="server" width="800px" visible="false">
            <div class="row mt-5">
                <div class="col-sm-5 form-group">
                    <Siar:TextBox  ID="txtDMisuraCerca" Label="Misura" runat="server"></Siar:TextBox>
                </div>
                <div class="col-sm-5 form-group">
                    <Siar:TextBox  Label="Descrizione" ID="txtDescrizioneDichiarazione" runat="server"></Siar:TextBox>
                </div>
                <div class="col-sm-2">
                    <Siar:Button ID="btnDMisuraCerca" runat="server" CausesValidation="False" OnClick="btnDMisuraCerca_Click"
                        Text="Cerca" />
                </div>
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgDichiarazioni" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="40">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="IdDichiarazione" HeaderText="Id"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="center" Width="40px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdDichiarazione" Name="chkObbligatorioDichiarazione"
                            HeaderText="Obbligatorio">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:CheckColumnAgid>
                        <Siar:IntegerColumnAgid DataField="IdDichiarazione" HeaderText="Ordine" Valore="Ordine"
                            Name="OrdineDichiarazione">
                            <ItemStyle HorizontalAlign="center" />
                        </Siar:IntegerColumnAgid>
                        <Siar:CheckColumnAgid DataField="IdDichiarazione" Name="chkDInclusa" HeaderSelectAll="true">
                            <ItemStyle Width="80px" HorizontalAlign="center" />
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaDichiarazioni" runat="server" OnClick="btnSalvaDichiarazioni_Click"
                    Text="Salva" CausesValidation="False" Modifica="true" />
            </div>
        </div>
        <div class="tableTab row" id="tableAllegati" runat="server" visible="false">
            <div class="row mt-5">
                <div class="col-sm-6 form-group">
                    <Siar:TextBox  Label="Filtra per misura:" ID="txtAMisuraCerca" runat="server" />
                </div>
                <div class="col-sm-6">
                    <Siar:Button ID="btnAMisuraCerca" runat="server" CausesValidation="False" OnClick="btnAMisuraCerca_Click"
                        Text="Cerca" />
                </div>
            </div>
            <div class="col-sm-12">
                <Siar:DataGridAgid CssClass="table table-striped" ID="dgAllegati" runat="server" Width="100%" PageSize="20" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn DataField="TipoAllegato" HeaderText="Tipo documento">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Descrizione" HeaderText="Descrizione"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Misura" HeaderText="Misura">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumnAgid DataField="IdAllegato" Name="chkInclAllegato" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" />
                        </Siar:CheckColumnAgid>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <div class="col-sm-12">
                <Siar:Button ID="btnSalvaAllegati" runat="server" OnClick="btnSalvaAllegati_Click"
                    Text="Salva" CausesValidation="False" Modifica="true" />
            </div>
        </div>
    </div>
</asp:Content>
