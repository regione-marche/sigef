<%@ Page Language="C#" MasterPageFile="~/SigefAgidPrivate.master" AutoEventWireup="true"
    Inherits="web.Private.IPagamento.IVariante.Allegati" CodeBehind="Allegati.aspx.cs" %>

<%@ Register Src="~/CONTROLS/WorkFlowVariantiIstruttoria.ascx" TagName="WorkFlowVariantiIstruttoria" TagPrefix="uc1" %>
<%@ Register Src="~/CONTROLS/CardVariantiIstruttoria.ascx" TagName="CardVariantiIstruttoria" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
 <uc2:CardVariantiIstruttoria ID="ucCardVarianti" runat="server" />
    <div class="row py-5">
        <div class="col-sm-12">
            <div class="steppers">
                <uc1:WorkFlowVariantiIstruttoria ID="ucWorkFlowVarianti" runat="server" />
                <div class="steppers-content" aria-live="polite">
                    <div class="row bd-form mx-2">
                        <h2 class="pb-5">Istruttoria degli allegati</h2>
                        <div class="form-group mt-5 col-sm-12">
                            <Siar:TextBox  Label="Digitare la segnatura della busta chiusa pervenuta:"  runat="server" ID="txtNumProtocollo" MaxLength="80" Width="590px" NomeCampo="Segnatura degli allegati" ReadOnly="true" />
                        </div>
                        <div class="form-group col-sm-12">
                            <Siar:DataGridAgid ID="dgAllegati" runat="server" AutoGenerateColumns="False" >
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="center" Width="30px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="Formato" HeaderText="Formato">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Dettaglio documento"></asp:BoundColumn>
                                    <Siar:JsButtonColumn Arguments="IdFile" ButtonImage="lente.png" ButtonText="Visualizza"
                                        ButtonType="ImageButton" JsFunction="SNCUFVisualizzaFile">
                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </Siar:JsButtonColumn>
                                    <asp:BoundColumn HeaderText="Esito">
                                        <ItemStyle HorizontalAlign="Center" Width="130px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Note">
                                        <ItemStyle HorizontalAlign="Center" Width="150px"/>
                                    </asp:BoundColumn>
                                    <Siar:CheckColumn Name="chkSelezionaPerRichiedeIntegrazione" HeaderSelectAll="true"
                                        DataField="IdAllegato">
                                        <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                    </Siar:CheckColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>
                        <div class="col-sm-12">
                            <Siar:Button ID="btnSalva" runat="server" Modifica="true" OnClick="btnSalva_Click"
                                Text="Ammetti">
                            </Siar:Button>

                            <Siar:Button ID="btnRichiestaCertificazione" runat="server" Text="Richiedi Certificazione"
                                OnClick="btnRichiestaCertificazione_Click" Modifica="true" />

                            <Siar:Button ID="btnRichiestaDocumentiIntegrativi" runat="server" Text="Richiedi Documentazione Integrativa"
                                OnClick="btnRichiestaDocumentiIntegrativi_Click" Modifica="true" />
                        </div>

                        <div class="form-group mt-5 col-sm-12">
                            <Siar:TextBox  Label="Elenco delle richieste di certificazione e comunicazioni inviate"  runat="server" ID="TextBox1" MaxLength="80" Width="590px" NomeCampo="Segnatura degli allegati" ReadOnly="true" />
                        </div>
                        <div class="form-group col-sm-12">
                            <Siar:DataGridAgid ID="dgComunicazioniInviate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="15" Width="100%">
                                <ItemStyle Height="50px" />
                                <Columns>
                                    <Siar:NumberColumn HeaderText="Nr.">
                                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                                    </Siar:NumberColumn>
                                    <asp:BoundColumn DataField="TipoSegnatura" HeaderText="Tipo">
                                        <ItemStyle Width="200px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Ente" DataField="Ente">
                                        <ItemStyle Width="100px" HorizontalAlign="left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Data" HeaderText="Data">
                                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="NominativoOperatore" HeaderText="Operatore">
                                        <ItemStyle Width="100px" HorizontalAlign="left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Stato">
                                        <ItemStyle Width="100px" HorizontalAlign="left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn>
                                        <ItemStyle Width="50px" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                </Columns>
                            </Siar:DataGridAgid>
                        </div>


                </div>
            </div>
        </div>
    </div>  
</asp:Content>
