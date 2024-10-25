<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.ControlliLocoControl"
    CodeBehind="ControlliLocoControl.ascx.cs" %>
<table class="tableNoTab" style="border-bottom: none" width="900px">
    <tr class="TESTA1">
        <td align="center">
            SEZIONE CONTROLLI IN LOCO
            <p style="font-weight:bold; color:Red;">
                Questa schermata è obsoleta. 
                La nuova gestione si trova alla voce di menù "Sezione controlli", "Controlli in Loco new"
            </p>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
</table>
<table width="900px" cellpadding="0" cellspacing="0">
    <tr id="trMenu">
        <td id="tdLeft" style="height: 24px; background-color: #E6E6EE; border-top-style: none;
            border-right: #142952 1px solid; border-left: #142952 1px solid; border-bottom: #142952 1px solid;">
            &nbsp;
        </td>
        <td class="tdSchedaMenu" onclick="location='RiepilogoControlli.aspx'">
            Riepilogo
        </td>
        <td class="tdSchedaMenu" onclick="location='ParametriRischio.aspx'">
            Parametri di rischio
        </td>
        <td class="tdSchedaMenu" onclick="location='LottidiControllo.aspx'">
            Lotti di controllo
        </td>
        <td class="tdSchedaMenu" onclick="location='ControlloDomande.aspx'">
            Controllo domande
        </td>
    </tr>
</table>
<table style="height: 5px; width: 900px; border-right: #142952 1px solid; border-left: #142952 1px solid;
    background-color: #fefeee; border-bottom: #142952 1px solid;" cellpadding="0"
    cellspacing="0">
    <tr>
        <td>
        </td>
    </tr>
</table>
