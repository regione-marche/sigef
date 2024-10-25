<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    Inherits="web.Private.Istruttoria.AssegnazioneDomande" CodeBehind="AssegnazioneDomande.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">

    <script type="text/javascript">
        function SNCVZCercaUtenti_onselect(obj) { if(obj) { $('[id$=hdnIdUtente]').val(obj.IdUtente);$('[id$=txtNominativo_text]').val(obj.Nominativo); } else alert('L`elemento selezionato non è valido.'); }
        function SNCVZCercaUtenti_onprepare() { $('[id$=hdnIdUtente]').val(''); }
    </script>

    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                Assegnazione delle domande di aiuto
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 672px" class="testo_pagina">
                            In questa pagina e&#39; possibile nominare i funzionari che effettueranno l&#39;istruttoria
                            sulle domande di aiuto pervenute.<br />
                            E` necessario selezionare oltre al <b>nominativo</b> dell&#39;operatore anche la
                            <b>provincia</b> di assegnazione, tale scelta
                            <br />
                            comportera&#39; anche l&#39;attribuzione della pratica e del funzionario al relativo
                            responsabile provinciale.<br />
                            La ricerca verra' effettuata solo sulle domande <b>non ancora assegnate</b> ad alcun
                            operatore.
                        </td>
                        <td>
                            <input type="button" class="Button" onclick="location='Collaboratori.aspx'" value="Indietro"
                                style="width: 150px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                <br />
                Selezionare l&#39;operatore:
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; height: 43px;">
                <Siar:TextBox  ID="txtNominativo" runat="server" Width="524px" />
                <asp:HiddenField ID="hdnIdUtente" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Selezionare la provincia:
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; height: 62px;">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 170px">
                            Provincia:&nbsp;<br />
                            <Siar:ComboProvinceMarche ID="lstProvincia" runat="server" AutoPostBack="True" EnableTheming="False"
                                NomeCampo="Provincia" Obbligatorio="True">
                            </Siar:ComboProvinceMarche>
                        </td>
                        <td style="width: 162px; padding-right: 20px;">
                            Comune (facoltativo):<br />
                            <Siar:ComboComuniMarche ID="lstComune" runat="server">
                            </Siar:ComboComuniMarche>
                        </td>
                        <td style="height: 27px">
                            <br />
                            <Siar:Button ID="btnCerca" runat="server" OnClick="btnCerca_Click" Text="Cerca" Width="139px"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="paragrafo">
                Selezionare le domande di aiuto:
            </td>
        </tr>
        <tr>
            <td>
                <Siar:DataGrid ID="dg" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="20" Width="100%">
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Domanda"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Data di presentazione">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ProvinciaDiPresentazione" HeaderText="Provincia">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Stato" HeaderText="Stato procedurale">
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:BoundColumn>
                        <Siar:CheckColumn DataField="IdProgetto" Name="chk" HeaderSelectAll="true">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </Siar:CheckColumn>
                    </Columns>
                </Siar:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 30px; height: 60px">
                <Siar:Button ID="btnAssegna" runat="server" OnClick="btnAssegna_Click" Text="Assegna domande selezionate"
                    Width="230px" Modifica="True" />
            </td>
        </tr>
    </table>
</asp:Content>
