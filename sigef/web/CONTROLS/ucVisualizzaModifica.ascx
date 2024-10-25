<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVisualizzaModifica.ascx.cs" Inherits="web.CONTROLS.ucVisualizzaModifica" %>

<%@ Register Src="~/CONTROLS/DatiDomanda.ascx" TagName="DatiDomanda" TagPrefix="uc1" %>

<div>

    <style type="text/css">

        .hide {
            display: none;
        }

    </style>

    <div style="padding-left: 10px; padding-bottom: 10px;">
        <uc1:DatiDomanda ID="ucDatiDomanda" runat="server" />
    </div>

    <div class="dBox">

        <div class="separatore">
            Visualizza modifica
        </div>

        <div id="divMostraModifica" style="padding: 10px;">

            <input type="button" class="Button" value="Indietro" style="width: 120px; margin: 10px;" onclick="history.back();" />

            <div style="margin: 10px;">
                Note modifiche:<br />
                <Siar:TextArea ID="txtNote" runat="server" NomeCampo="Note modifiche"
                    Obbligatorio="false" Width="800px" Rows="4" ExpandableRows="5" MaxLength="10000" ReadOnly="true" />
            </div>

            <%--Piorita--%>
            <div id="divPriorita" runat="server">
                <div class="dBox">
                    <div class="separatore">
                        Requisiti soggettivi precedenti alla modifica
                    </div>
                    <div id="divPrioritaPrecedenti" runat="server" style="margin: 10px; width: 800px;">
                        <Siar:DataGrid ID="dgPrioritaPrecedenti" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle Width="35px" HorizontalAlign="center" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="PRIORITA" HeaderText="Descrizione requisito">
                                    <ItemStyle Width="330px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdPriorita">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                    <FooterStyle CssClass="hide" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>

                <div class="dBox" style="margin-top: 10px;">
                    <div class="separatore">
                        Requisiti soggettivi successivi alla modifica
                    </div>
                    <div id="divPrioritaNuove" runat="server" style="margin: 10px; width: 800px;">
                        <Siar:DataGrid ID="dgPrioritaNuove" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <Siar:NumberColumn HeaderText="Nr.">
                                    <ItemStyle Width="35px" HorizontalAlign="center" />
                                </Siar:NumberColumn>
                                <asp:BoundColumn DataField="PRIORITA" HeaderText="Descrizione requisito">
                                    <ItemStyle Width="330px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IdPriorita">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                    <FooterStyle CssClass="hide" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>

            <%--Requisiti--%>
            <div id="divRequisiti" runat="server">
                <div class="dBox">
                    <div class="separatore">
                        Requisiti soggettivi prima della modifica
                    </div>
                    <div id="divRequisitiPrecedenti" runat="server" style="margin: 10px; width: 800px;">
                        <Siar:DataGrid ID="dgRequisitiPrecedenti" runat="server" Width="100%" PageSize="15" CssClass="tabella"
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
                                <asp:BoundColumn DataField="IdRequisito" HeaderText="Descrizione requisito">
                                    <ItemStyle Width="330px"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdRequisito">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                    <FooterStyle CssClass="hide" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>

                <div class="dBox" style="margin-top: 10px;">
                    <div class="separatore">
                        Requisiti soggettivi successivi alla modifica
                    </div>
                    <div id="divRequisitiNuovi" runat="server" style="margin: 10px; width: 800px;">
                        <Siar:DataGrid ID="dgRequisitiNuovi" runat="server" Width="100%" PageSize="15" CssClass="tabella"
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
                                <asp:BoundColumn DataField="IdRequisito" HeaderText="Descrizione requisito">
                                    <ItemStyle Width="330px"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn DataField="IdRequisito">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                    <FooterStyle CssClass="hide" />
                                </asp:BoundColumn>
                            </Columns>
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>

            <%--Indicatori--%>
            <div id="divIndicatori" runat="server">
                <div class="dBox">
                    <div class="separatore">
                        Indicatori precedenti alla modifica
                    </div>
                    <div id="divIndicatoriPrecedenti" runat="server" style="margin: 10px; width: 800px;">
                        <Siar:DataGrid ID="dgIndicatoriPrecedenti" runat="server" AutoGenerateColumns="False" Width="100%">
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
                        </Siar:DataGrid>
                    </div>
                </div>

                <div class="dBox" style="margin-top: 10px;">
                    <div class="separatore">
                        Indicatori successivi alla modifica
                    </div>
                    <div id="divIndicatoriNuovi" runat="server" style="margin: 10px; width: 800px;">
                        <Siar:DataGrid ID="dgIndicatoriNuovi" runat="server" AutoGenerateColumns="False" Width="100%">
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
                        </Siar:DataGrid>
                    </div>
                </div>
            </div>

        </div>
    </div>

</div>