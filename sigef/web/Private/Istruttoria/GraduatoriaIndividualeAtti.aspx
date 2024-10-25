<%@ Page Title="" Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true" CodeBehind="GraduatoriaIndividualeAtti.aspx.cs" Inherits="web.Private.Istruttoria.GraduatoriaIndividualeAtti" %>
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

    
    
    <table width="800px" class="tableNoTab">
        <tr>
            <td class="separatore_big">
                Elenco Decreti Graduatoria
            </td>
        </tr>
        <tr>
            <td class="testo_pagina">
                Nella sezione sottostante è possibile aggiungere piu decreti di finanziabilità ad un progetto
            </td>
        </tr>
        <tr>
            <td  style="height: 33px; padding-right: 50px;" align="right">
                <input id="btnBack" runat="server" class="Button" style="width: 130px" type="button"
                    onclick="location='GraduatoriaIndividuale.aspx'" value="Indietro" /><br />
            </td>
        </tr>
        <tr>
            <td style="padding-left:20px;">
                <table >
                    <tr >
						<td style="width: 100px">
							Id Progetto:<br />
							<Siar:IntegerTextBox ID="txtProgetto" runat="server" ReadOnly Width="80px" />
						</td>
						<td style="width: 130px">
							Contributo Totale €:<br />
							<Siar:CurrencyBox ID="txtContributoTotale" runat="server" ReadOnly Width="100px" />
						</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td style="padding-left:20px;>
                <table width="100%">
                    <tr >
                        <td class="separatore" >
                            Elenco dei decreti e relativi importi
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:20px;">
                            <table >   
                                <tr >
						            <td style="padding-bottom: 10px; padding-top: 10px">
                                        <Siar:DataGrid ID="dgGradAtti" runat="server" Width="400px" AutoGenerateColumns="False"
                                            AllowPaging="False"  ShowFooter="true">
                                            <FooterStyle CssClass="coda" HorizontalAlign="Right" />
                                            <ItemStyle Height="26px" />
                                            <Columns>
                                                <Siar:ColonnaLink  LinkFields="IdGraduatoriaProgettiAtti" LinkFormat="javascript:selezionaRiga({0});" 
                                                    DataField="IdGraduatoriaProgettiAtti" HeaderText="ID" ItemStyle-Width = "20px">
                                                </Siar:ColonnaLink>
                                                <asp:BoundColumn DataField="Importo" HeaderText="Contributo Concesso" DataFormatString="{0:c}">
                                                    <ItemStyle HorizontalAlign="right" Width="120px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Decreto">
                                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                        </Siar:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:20px;">
                            <Siar:Button ID="Button1" runat="server" OnClick="AggiungiDecr_Click"
												Text="Aggiungi decreto" Width="160px" Modifica="False"  />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding:20px;" > 
                            <div runat="server" id="divAtto" visible="false"> 
                                <table>
                                    <tr>
                                        <td style="width: 200px" colspan="4">
											Importo €:<br />
											<Siar:CurrencyBox ID="txtAttoImporto" runat="server" Width="160px" />
										</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            Definizione:<br />
                                            <Siar:ComboDefinizioneAtto ID="lstAttoDefinizione" runat="server" NoBlankItem="True"
                                                Width="80px">
                                            </Siar:ComboDefinizioneAtto>
                                        </td>
                                        <td style="width: 100px">
                                            Numero:<br />
                                            <Siar:IntegerTextBox NoCurrency="True" ID="txtAttoNumero" runat="server" Width="80px" NomeCampo="Numero decreto" />
                                        </td>
                                        <td style="width: 120px">
                                            Data:<br />
                                            <Siar:DateTextBox ID="txtAttoData" runat="server" Width="100px" NomeCampo="Data decreto" />
                                        </td>
                                        <td style="width: 146px">
                                            Registro:<br />
                                            <Siar:ComboRegistriAtto ID="lstAttoRegistro" runat="server" Width="100px">
                                            </Siar:ComboRegistriAtto>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
											<br />
											<Siar:Button ID="btnSalvaRiga" runat="server" OnClick="btnSalvaRiga_Click"
												Text="Salva dati" Width="160px" Modifica="False"  />
										</td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
