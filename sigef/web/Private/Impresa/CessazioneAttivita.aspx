<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="CessazioneAttivita.aspx.cs" Inherits="web.Private.Impresa.CessazioneAttivita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <br />
    <table class="tableNoTab" width="900px">
        <tr>
            <td class="separatore_big">
                CESSAZIONE DELL&#39;ATTIVITA DELL&#39;IMPRESA
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 141px">
                            Data cessazione:<br />
                            <Siar:DateTextBox ID="txtDataCessazione" runat="server" Width="110px" />
                        </td>
                        <td>
                            Motivazione:<br />
                            <Siar:Combo ID="lstMotivazione" runat="server">
                            </Siar:Combo>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 141px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 141px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
