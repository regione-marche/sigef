<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.QuadroRelazioneTecnica"
    CodeBehind="QuadroRelazioneTecnica.ascx.cs" %>
<table width="100%">
    <tr class="TESTA">
        <td id="tdTitolo" runat="server">
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td id="tdDescrizione" runat="server" class="testo_pagina" style="width: 650px">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="width: 650px">
                        <Siar:TextArea ID="txtDescrizioneLunga" runat="server" Obbligatorio="True" NomeCampo="Testo"
                                       Rows="10" Width="650px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
