<%@ Control Language="C#" AutoEventWireup="true" 
CodeBehind="CertificazioneControl.ascx.cs" Inherits="web.CONTROLS.CertificazioneControl" %>

<table class="tableNoTab" style="border-bottom: none" width="1000px">
    <tr class="TESTA1">
        <td align="center">
            SEZIONE CERTIFICAZIONI DI SPESA
            <p style="font-weight:bold; color:Red;">
                Questa schermata è obsoleta. 
                La nuova gestione si trova alla voce di menù "Sezione controlli", "Certificazione spesa new"
            </p>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
</table>
<table width="1000px" cellpadding="0" cellspacing="0">
    <tr id="trMenu">
        <td id="tdLeft" style="height: 24px; background-color: #E6E6EE; border-top-style: none;
            border-right: #142952 1px solid; border-left: #142952 1px solid; border-bottom: #142952 1px solid;">
            &nbsp;
        </td>
        <td class="tdSchedaMenu" onclick="location='CertificazioneSpesa.aspx'">
            Intermedio
        </td>
        <td class="tdSchedaMenu" onclick="location='Bilancio.aspx'">
            Bilancio
        </td>
        <td class="tdSchedaMenu" onclick="location='CertificazioneRecuperi.aspx'">
            Recuperi importi
        </td>
        <td class="tdSchedaMenu" onclick="location='CertificazioneDomande.aspx'">
            Domande di pagamento
        </td>
        <td class="tdSchedaMenu" onclick="location='CertificazioneConti.aspx'">
            Conti trasmessi
        </td>
         <td class="tdSchedaMenu" onclick="location='CertificazioneSpCostiEffett.aspx'">
            Costi effettivi</td>    
           
     </tr>
</table>
<table style="height: 5px; width: 1000px; border-right: #142952 1px solid; border-left: #142952 1px solid;
    background-color: #fefeee; border-bottom: #142952 1px solid;" cellpadding="0"
    cellspacing="0">
    <tr>
        <td>
        </td>
    </tr>
</table>