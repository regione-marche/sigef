<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Controlli.RiepilogoControlli" CodeBehind="RiepilogoControlli.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <br />
    <table class="tableNoTab" width="900">
        <tr>
            <td class="separatore_big">
                RIEPILOGO GENERALE CONTROLLI IN LOCO
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 415px" class="testo_pagina">
                            Di seguito viene visualizzata la situazione generale dei controlli in<br />
                            loco che comprende:
                            <br />
                            - Numero di domande di pagamento controllate e da controllare<br />
                            - Numero dei lotti creati e situazione specifica<br />
                            - Totale contributo pubblico controllato e da controllare.
                        </td>
                        <td>
                            <table style="border: 1px solid black; width: 100%">
                                <tr>
                                    <td class="separatore"">
                                        Filtra per programmazione e/o anno:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px;">
                                        <Siar:ComboGroupZProgrammazioneShort ID="lstProgrammazione" runat="server"></Siar:ComboGroupZProgrammazioneShort>
                                        &nbsp;&nbsp;&nbsp;
                                        <Siar:ComboAnno ID="lstAnno" runat="server" Width="70px"></Siar:ComboAnno>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <Siar:Button ID="btnCerca" runat="server" CausesValidation="False" OnClick="btnCerca_Click" Text="Filtra" Width="70px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tbRiepilogoLotti" runat="server" cellspacing="0" style="width: 100%; border-collapse: collapse"
                    border="1">
                    <tr class="TESTA1">
                        <td style="width: 150px"> </td>
                        <td style="width: 150px"> Totale creati </td>
                        <td style="width: 150px"> Campioni estratti </td>
                        <td style="width: 150px"> Controlli conclusi </td>
                        <td style="width: 135px">Num.conclusi / <br /> Num. totale (%) </td>
                        <td> Num.conclusi / <br /> Num. estratti (%) </td>
                    </tr>
                    <tr class="DataGridRow">
                        <td style="width: 150px; font-size: 12px; font-weight: bold; height: 26px;"> &nbsp;Lotti di controllo </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px; width: 135px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                    </tr>
                </table>
                <br />
                <table id="tbRiepilogoDomande" runat="server" cellspacing="0" style="width: 100%;
                    border-collapse: collapse" border="1">
                    <tr class="TESTA1">
                        <td style="width: 150px"> </td>
                        <td style="width: 150px"> Domande totali </td>
                        <td style="width: 150px"> Domande inserite in lotti </td>
                        <td style="width: 150px"> Domande controllate </td>
                        <td style="width: 135px"> Num. controllate / <br /> num. totale (%) </td>
                        <td> Num. controllate / <br /> num. nei lotti (%) </td>
                    </tr>
                    <tr class="DataGridRow">
                        <td style="width: 150px; font-size: 12px; font-weight: bold; height: 26px;"> &nbsp;Domande di pagamento </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px; width: 135px;"></td>
                        <td style="text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                    </tr>
                </table>
                <br />
                <table id="tbRiepilogoContributo" runat="server" cellspacing="0" style="width: 100%;
                    border-collapse: collapse" border="1">
                    <tr class="TESTA1">
                        <td style="width: 150px"> </td>
                        <td style="width: 150px"> Totale </td>
                        <td style="width: 150px"> Totale nei lotti </td>
                        <td style="width: 150px"> Totale controllato </td>
                        <td style="width: 135px"> &nbsp;Controllato / Totale (%) </td>
                        <td> &nbsp;Controllato /<br /> &nbsp;Contributo nei lotti (%) </td>
                    </tr>
                    <tr class="DataGridRow">
                        <td class="coda" style="width: 150px; font-size: 12px; font-weight: bold; height: 26px;"> &nbsp;Contributo richiesto </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px; width: 135px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                    </tr>
                    <tr class="DataGridRow">
                        <td class="coda" style="width: 150px; font-size: 12px; font-weight: bold; height: 26px;"> &nbsp;Contributo ammesso </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px; width: 135px;"> </td>
                        <td style="text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                    </tr>
                    <tr class="DataGridRow">
                        <td class="coda" style="width: 150px; font-size: 12px; font-weight: bold; height: 26px;"> &nbsp;Contributo liquidato </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                        <td style="text-align: right; font-weight: bold; height: 26px; width: 135px;"> &nbsp; </td>
                        <td style="text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                    </tr>
                    <tr class="DataGridRow">
                        <td class="coda" style="width: 150px; font-size: 12px; height: 26px; padding-left: 10px"> &nbsp; - di cui durante l'anno </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                        <td style="width: 150px; text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                        <td style="text-align: right; font-weight: bold; height: 26px; width: 135px;"> &nbsp; </td>
                        <td style="text-align: right; font-weight: bold; height: 26px;"> &nbsp; </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
