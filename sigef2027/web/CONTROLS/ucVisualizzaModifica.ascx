<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVisualizzaModifica.ascx.cs" Inherits="web.CONTROLS.ucVisualizzaModifica" %>

<%@ Register Src="~/CONTROLS/DatiDomanda.ascx" TagName="DatiDomanda" TagPrefix="uc1" %>

<div>

    <style type="text/css">
        .hide {
            display: none;
        }
    </style>


    <uc1:DatiDomanda ID="ucDatiDomanda" runat="server" />

    <div class="row">
        <h3 class="pb-5">Ricerca generale domande di aiuto</h3>

        <div class="col-sm-12">
            <input type="button" class="btn btn-secondary py-1" value="Indietro" onclick="history.back();" />
        </div>
        <div class="col-sm-12 form-group">
            <Siar:TextArea Label="Note modifiche:" ID="txtNote" runat="server" NomeCampo="Note modifiche"
                Obbligatorio="false" ows="4" ExpandableRows="5" MaxLength="10000" ReadOnly="true" />
        </div>
        <div class="col-sm-12" id="divPriorita" runat="server">
            <div class="row">
                <h5 class="pb-5">Requisiti soggettivi precedenti alla modifica</h5>
                <div id="divPrioritaPrecedenti" runat="server" class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgPrioritaPrecedenti" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="PRIORITA" HeaderText="Descrizione requisito"></asp:BoundColumn>
                            <asp:BoundColumn>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdPriorita">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                                <FooterStyle CssClass="hide" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
                <h5 class="pb-5">Requisiti soggettivi successivi alla modifica</h5>
                <div id="divPrioritaNuove" runat="server" class="col-sm-12">
                    <Siar:DataGridAgid CssClass="table table-striped" ID="dgPrioritaNuove" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="PRIORITA" HeaderText="Descrizione requisito"></asp:BoundColumn>
                            <asp:BoundColumn>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IdPriorita">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                                <FooterStyle CssClass="hide" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
        <div class="col-sm-12" id="divRequisiti" runat="server">
            <div class="row">
                <h5 class="pb-5">Requisiti soggettivi prima della modifica</h5>
                <div id="divRequisitiPrecedenti" runat="server" class="col-sm-12">
                    <Siar:DataGridAgid ID="dgRequisitiPrecedenti" runat="server" PageSize="15" CssClass="table table-striped"
                        AutoGenerateColumns="False">
                        <PagerStyle CssClass="coda" Mode="NumericPages" />
                        <ItemStyle CssClass="DataGridRow" Height="24px" />
                        <AlternatingItemStyle BackColor="#fff0d2" />
                        <HeaderStyle CssClass="TESTA1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <HeaderStyle Width="35px" />
                                <ItemStyle HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="IdRequisito" HeaderText="Descrizione requisito"></asp:BoundColumn>
                            <asp:BoundColumn></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdRequisito">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                                <FooterStyle CssClass="hide" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
                <h5 class="pb-5">Requisiti soggettivi successivi alla modifica</h5>
                <div id="divRequisitiNuovi" runat="server" class="col-sm-12">
                    <Siar:DataGridAgid ID="dgRequisitiNuovi" runat="server" PageSize="15" CssClass="table table-striped"
                        AutoGenerateColumns="False">
                        <PagerStyle CssClass="coda" Mode="NumericPages" />
                        <ItemStyle CssClass="DataGridRow" Height="24px" />
                        <AlternatingItemStyle BackColor="#fff0d2" />
                        <HeaderStyle CssClass="TESTA1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <Siar:NumberColumn HeaderText="Nr.">
                                <HeaderStyle Width="35px" />
                                <ItemStyle HorizontalAlign="center" />
                            </Siar:NumberColumn>
                            <asp:BoundColumn DataField="IdRequisito" HeaderText="Descrizione requisito"></asp:BoundColumn>
                            <asp:BoundColumn></asp:BoundColumn>
                            <asp:BoundColumn DataField="IdRequisito">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                                <FooterStyle CssClass="hide" />
                            </asp:BoundColumn>
                        </Columns>
                    </Siar:DataGridAgid>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-12" id="divIndicatori" runat="server">
        <div class="row">
            <h5 class="pb-5">Indicatori precedenti alla modifica</h5>
            <div id="divIndicatoriPrecedenti" runat="server" class="col-sm-12">
                <Siar:DataGridAgid ID="dgIndicatoriPrecedenti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn></Siar:NumberColumn>
                        <asp:BoundColumn DataField="PROGRAMMAZIONE_CODICE" HeaderText="Intervento"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DIM_CODICE" HeaderText="Indicatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DIM_DESCRIZIONE" HeaderText="Indicatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_PROGRAMMATO_RICHIESTO" HeaderText="Val. Programmato Richiesto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_PROGRAMMATO_AMMESSO" HeaderText="Val. Programmato Ammesso"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_REALIZZATO_RICHIESTO" HeaderText="Val. Realizzato Richiesto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_REALIZZATO_AMMESSO" HeaderText="Val. Realizzato Ammesso"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DIM_UM" HeaderText="Unità di misura"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RICHIEDIBILE" HeaderText="Richiedibile" Visible="false"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
            <h5 class="pb-5">Indicatori precedenti alla modifica</h5>
            <div id="divIndicatoriNuovi" runat="server" class="col-sm-12">
                <Siar:DataGridAgid ID="dgIndicatoriNuovi" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn></Siar:NumberColumn>
                        <asp:BoundColumn DataField="PROGRAMMAZIONE_CODICE" HeaderText="Intervento"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DIM_CODICE" HeaderText="Indicatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DIM_DESCRIZIONE" HeaderText="Indicatore"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_PROGRAMMATO_RICHIESTO" HeaderText="Val. Programmato Richiesto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_PROGRAMMATO_AMMESSO" HeaderText="Val. Programmato Ammesso"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_REALIZZATO_RICHIESTO" HeaderText="Val. Realizzato Richiesto"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VALORE_REALIZZATO_AMMESSO" HeaderText="Val. Realizzato Ammesso"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DIM_UM" HeaderText="Unità di misura"></asp:BoundColumn>
                        <asp:BoundColumn DataField="RICHIEDIBILE" HeaderText="Richiedibile" Visible="false"></asp:BoundColumn>
                    </Columns>
                </Siar:DataGridAgid>
            </div>
        </div>
    </div>
</div>
