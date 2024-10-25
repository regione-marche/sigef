<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bilancio.aspx.cs" MasterPageFile="~/SiarPage.master"
    Inherits="web.Private.CertificazioneSpesa.Bilancio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableNoTab" width="1000">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Importi registrati nei sistemi contabili dell'autorità di certificazione – Appendice 1
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera a), del regolamento (UE) n. 1303/2013
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgImportiRegistrati" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <%-- provvisorio da modificare con l'ItemDataBound da Code Behind
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale di spese ammissibili registrato dall'autorità di certificazione nei propri sistemi contabili e inserito nelle domande di pagamento presentate alla Commissione">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale della corrispondente spesa pubblica relativa all'attuazione delle operazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        --%>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>Asse</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"ASSE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale di spese ammissibili registrato dall'autorità di certificazione nei propri sistemi contabili e inserito nelle domande di pagamento presentate alla Commissione
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_RICHIESTO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale della corrispondente spesa pubblica relativa all'attuazione delle operazioni
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_AMMESSO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale dei pagamenti corrispondenti effettuati ai beneficiari a norma dell'articolo 132, paragrafo 1, del regolamento (UE) n. 1303/2013
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_AMMESSO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--  
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale dei pagamenti corrispondenti effettuati ai beneficiari a norma dell'articolo 132, paragrafo 1, del regolamento (UE) n. 1303/2013">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>--%>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Importi ritirati e recuperati durante il periodo contabile
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgImportiRitirati" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale ammissibile delle spese incluse nelle domande di pagamento">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Importo totale ammissibile delle spese incluse nelle domande di pagamento">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Importi da recuperare alla chiusura del periodo contabile
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013
                
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgImportiDaRecuperare" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale ammissibile delle spese">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Recuperi effettuati a norma dell'articolo 71 del regolamento (ue) n. 1303/2013 (STABILITA’ DELLE OPERAZIONI) durante il periodo contabile
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                 articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRecuperiEffettuati" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale ammissibile delle spese">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Importi irrecuperabili alla chiusura del periodo contabile
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera b), del regolamento (UE) n. 1303/2013
                
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgImportiIrrecuperabili" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale ammissibile delle spese">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Osservazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Importi dei contributi per programma erogati agli strumenti finanziari a norma dell'articolo 41 del regolamento (UE) n. 1303/2013) (dati cumulativi dall'inizio del programma) 
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera c), del regolamento (UE) n. 1303/2013
                
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgStrumentiFinanziari" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo dei contributi per programma erogati agli strumenti finanziari">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo dei contributi del programma effettivamente erogati o, nel caso delle garanzie, impegnati a titolo di spesa ammissibile ai sensi dell'articolo 42, paragrafo 1, lettere a), b) e d), del regolamento (UE) n. 1303/2013">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Spesa pubblica corrispondente">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Anticipi versati nel quadro di aiuti di Stato a norma dell'articolo 131, paragrafo 5, del regolamento (UE) n. 1303/2013 (dati cumulativi dall'inizio del programma) 
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera c), del regolamento (UE) n. 1303/2013
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgAnticipiAiutiStato" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo complessivo versato come anticipo dal programma operativo">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo che è stato coperto dalle spese pagate dai beneficiari entro tre anni dal pagamento dell'anticipo">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo che non è stato coperto dalle spese sostenute dai beneficiari e per il quale il periodo di tre anni non è ancora trascorso">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="separatore_big">
                Riconciliazione delle spese – Appendice 8
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                articolo 137, paragrafo 1, lettera c), del regolamento (UE) n. 1303/2013
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dgRiconciliazioneSpese" runat="server" ShowFooter="true" AutoGenerateColumns="False">
                    <ItemStyle Height="30px" />
                    <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="50px" HorizontalAlign="center" />
                            <FooterStyle Width="50px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <%-- provvisorio da modificare con l'ItemDataBound da Code Behind
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Asse">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale della spesa pubblica relativa all'attuazione delle operazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale di spese ammissibili registrato dall'autorità di certificazione nei propri sistemi contabili e inserito nelle domande di pagamento presentate alla Commissione">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Importo totale della corrispondente spesa pubblica relativa all'attuazione delle operazioni">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="(E=A-C)">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="(F=B-D)">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        --%>
                        <%-- --%>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>Asse</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"ASSE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale delle spese ammissibili sostenute dai beneficiari e pagate nell'attuazione delle operazioni
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_RICHIESTO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale della spesa pubblica relativa all'attuazione delle operazioni
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_RICHIESTO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale di spese ammissibili registrato dall'autorità di certificazione nei propri sistemi contabili e inserito nelle domande di pagamento presentate alla Commissione
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_RICHIESTO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                Importo totale della corrispondente spesa pubblica relativa all'attuazione delle operazioni
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalAttributes.[\"CONTRIBUTO_RICHIESTO_TOTALE\"]") %>' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                (E=A-C)
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" Text='0' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                (F=B-D)
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" Text='0' runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%-- --%>

                        <asp:BoundColumn HeaderStyle-HorizontalAlign="Center" HeaderText="&nbsp;">
                            <ItemStyle Width="200px" HorizontalAlign="center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
