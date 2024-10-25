<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SigefAgidPrivate.master"
 CodeBehind="EstrazioneProgetti.aspx.cs" Inherits="web.Private.admin.EstrazioneProgetti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table>
        <tr>
            <td>
                <Siar:TextBox  runat="server" ID="txtIdProgetto" Width="150px" />
            </td>
            <td>
                <Siar:Button ID="btnScarica" Width="80px" runat="server" Text="Scarica"
                        OnClick="btnScarica_Click" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>