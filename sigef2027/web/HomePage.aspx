<%@ Page Language="c#" MasterPageFile="~/SiarPage.master" Inherits="web.HomePage"
    CodeBehind="HomePage.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table width="1040" class="tableNoTab" style="border-radius:10px">
        <tr>
            <td class="separatore_big">
                SIGEF - SISTEMA INTEGRATO GESTIONE FONDI
            </td>
        </tr>
        <tr>
            <td style="height: 75px;padding-left:20px;padding-right:20px">
                <br />
                <br />
                Il SIGEF è un portale realizzato per supportare le attività di back office dei funzionari
                regionali e le attività di front office dei beneficiari inerenti agli interventi
                promossi, tramite la pubblicazione di bandi del POR MARCHE FESR 2014-2020 della
                Regione Marche.
                <br />
                <br />
                È il sistema che permette la presentazione elettronica delle <b>domande di partecipazione</b>
                e di contributo rispondendo ai bandi attivi, pubblicati dalla Regione Marche.<br />
                <br />
                <p style="width: 100%; text-align: center">
                    <br />
                    <a href="https://sigef.regione.marche.it/Public/Download/BROCHURE_SIGEF.pdf"
                        style="font-weight: bold" target="_blank">SCARICA LA BROCHURE INFORMATIVA</a>
                </p>
                <br />
                <br />
                L&#39;accesso all&#39;<b>area riservata</b> e&#39; permesso ai soli <b>utenti registrati</b>,
                consultare i seguenti documenti per le procedure di autorizzazione:<br />
                &nbsp;<table style="width:100%;">
                    <tr>
                        <td width="420px" style="padding-bottom: 20px;">
                            <ul>
                                <li>Procedura Accesso SIGEF :
                                    &nbsp; &nbsp; <a href='../Public/Download/Procedura_Accesso_SIGEF.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Procedura Accesso SIGEF' /></a>&nbsp;&nbsp;&nbsp;(
                                    documento pdf - 120 Kb )</li>
                            </ul>
                        </td>
                    </tr>
                    <%--<tr>
                        <td width="420px" style="padding-right: 30px; padding-bottom: 20px;">
                            <ul>
                                <li>Richiesta abilitazione utente Sigef:
                                   
                                    &nbsp; &nbsp; <a href='../Public/Download/MOD_ABILITAZIONE_SIGEF.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Richiesta abilitazione utente SIGEF' /></a>&nbsp;&nbsp;&nbsp;(
                                    pdf editabile )</li>
                            </ul>
                        </td>
                    </tr>
                     <tr>
                        <td width="420px" style="padding-right:30px; padding-bottom: 20px;">
                            <ul>
                                <li><b>Modulo abilitazione per D.L. 189/2016- Art. 20 bis - Decreto 11 agosto 2017:</b>
                          
                                    &nbsp; &nbsp; <a href='../Public/Download/Richiesta_Abilitazione_SIGEF_Art20BIS.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Richiesta abilitazione utente D.L. 189/2016- Art. 20 bis' /></a>&nbsp;&nbsp;&nbsp;(
                                    pdf editabile )</li>
                            </ul>
                        </td>
                        </tr>--%>
                    <tr>    
                    <td width="420px" style="padding-right: 30px; padding-bottom: 20px;">
                            <ul>
                                <li>Esegui il test della firma digitale Calamaio:
                                    <%--<br />--%>
                                    &nbsp; &nbsp; <a id="linkTestFirmaDigitale" runat="server" href='../Public/Download/TestFirmaDigitale.html' >
                                        <img src='images/explorer.gif' alt='Test Firma Digitale' /></a></li>
                            </ul>
                        </td>
                    </tr>
                    <tr>    
                    <td width="420px" style="padding-right: 30px; padding-bottom: 20px;">
                            <ul>
                                <li>Esegui il test della firma digitale remota e esterna:
                                    <%--<br />--%>
                                    &nbsp; &nbsp; <a id="linkTestFirmaDigitaleRemota" runat="server" href="../Public/Download/TestFirmaDigitaleRemota.aspx" >
                                        <img src='images/explorer.gif' alt='Test Firma Digitale' /></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
                <%--&nbsp;<table width="100%">
                    <tr>
                        <td width="420px" style="padding-left: 30px">
                            <ul>
                                <li>Procedura Accesso SIGEF :
                                    <br />
                                    &nbsp; &nbsp; <a href='../Public/Download/Procedura_Accesso_SIGEF.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Procedura Accesso SIGEF' /></a>&nbsp;&nbsp;&nbsp;(
                                    documento pdf - 120 Kb )</li>
                            </ul>
                        </td>
                        <td width="420px" style="padding-right: 30px">
                            <ul>
                                <li>Richiesta abilitazione utente Sigef:
                                    <br />
                                    &nbsp; &nbsp; <a href='../Public/Download/MOD_ABILITAZIONE_SIGEF.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Richiesta abilitazione utente SIGEF' /></a>&nbsp;&nbsp;&nbsp;(
                                    pdf editabile )</li>
                            </ul>
                        </td>
                        <td width="420px" style="padding-right: 30px">
                            <ul>
                                <li><b>Modulo abilitazione per D.L. 189/2016- Art. 20 bis - Decreto 11 agosto 2017:</b>
                                    <br />
                                    &nbsp; &nbsp; <a href='../Public/Download/Richiesta_Abilitazione_SIGEF_Art20BIS.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Richiesta abilitazione utente D.L. 189/2016- Art. 20 bis' /></a>&nbsp;&nbsp;&nbsp;(
                                    pdf editabile )</li>
                            </ul>
                        </td>
                        <td width="420px" style="padding-right: 30px">
                            <ul>
                                <li>Esegui il test della firma digitale Calamaio:
                                    <br />
                                    &nbsp; &nbsp; <a id="linkTestFirmaDigitale" runat="server" href='../Public/Download/TestFirmaDigitale.html' >
                                        <img src='images/explorer.gif' alt='Test Firma Digitale' /></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>--%>
                <br />
                Questo sito e&#39; usufruibile con le piu&#39; aggiornate versioni dei maggiori
                browser in circolazione, per qualsiasi problema o informazioni<br />
                consultare la pagina di <b><a href="public/assistenzautenti.aspx">ASSISTENZA AGLI UTENTI</a></b>.
                <br />
                <br />
                <br /><hr />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td  style="height: 75px;padding-left:20px;padding-right:20px">          
                            <b>
                            Nuova modalità per l'abilitazioni dei consulenti:</b>
                            <br />La richiesta per l'abilitazione di nuovi consulenti può essere fatta direttamente online in via telematica all'interno del sito dal rappresentante legale nella 
                            <b>Sezione Beneficiario -> Gestione Consulenti</b>. Inoltre in questa pagina il rappresentante legale puo revocare il mandato a qualsiasi consulente in totale autonomia. 
                            <br>
                        </td>
                    </tr>
                    <%--
                    <tr>
                        <td  style="height: 25px;padding-left:20px;padding-right:20px">          
                            In alternativa:
                        </td>
                    </tr>
                    <tr>
                        <td width="420px" style="padding-right: 30px">
                            <ul>
                                <li><b>Modulo abilitazione per Bandi POR/FESR:</b>
                                    <br />
                                    &nbsp; &nbsp; <a href='../Public/Download/MOD_ABILITAZIONE_SIGEF.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Richiesta abilitazione utente SIGEF' /></a>&nbsp;&nbsp;&nbsp;(
                                    pdf editabile )</li>
                            </ul>
                            <ul>
                                <li><b>Modulo abilitazione per Bandi D.L. 189/2016- Art. 20 bis - DDPF n.40 del 08.04.2020 - Decreto 11 agosto 2017:</b>
                                    <br />
                                    &nbsp; &nbsp; <a href='../Public/Download/Richiesta_Abilitazione_SIGEF_Art20BIS2020.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Richiesta abilitazione utente D.L. 189/2016- Art. 20 bis' /></a>&nbsp;&nbsp;&nbsp;(
                                    pdf editabile )</li>
                            </ul>
                        </td>
                    </tr>
                    --%>
                </table>
                <hr />
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr> 
                        <td  style="height: 75px;padding-left:20px;padding-right:20px">                 
                            <b> 
                            Avvisiamo tutti gli utenti</b>, che dalla data del 06/06/2019 è stata modificata la modalità di firma digitale, compatibile con quasi <b> tutti i browser</b> (Google Chrome, Edge, Firefox ).  
                            <br />Si consiglia pertanto di<b> non usare </b> il browser<b> Internet explorer v10 e v11.</b> 
                        </td> 
                    </tr> 
                </table> 
                <table width="100%" cellpadding="0" cellspacing="0"> 
                    <tr>
                        <td width="420px" style="padding-left: 30px">
                            <ul>
                                <li>Manuale Firma Digitale Calamaio:
                                    <%--<br />--%>
                                    &nbsp; &nbsp; <a href='../Public/Download/Manuale_firma_digitale_Calamaio_vers1_2.pdf' target='_blank'>
                                        <img src='images/acrobat.gif' alt='Manuale Firma Digitale Calamaio' /></a>&nbsp;&nbsp;&nbsp;(
                                    documento pdf )</li>
                            </ul> 
                        </td> 
                    </tr>
                </table>
                <hr />
                <br />
            </td>
        </tr>
        <tr> 
            <td> 
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="separatore_light" style="border-radius:5px">
                        </td>
                    </tr>
                    <tr class="DataGridRowAlt">
                        <td class="selectable" style="text-align: center; font-size: 14px; font-weight: bold;
                            height: 30px; line-height: 30px" onclick="location='private/welcome.aspx'">
                            ACCEDI ALL'AREA RISERVATA
                        </td>
                    </tr>
                    <tr>
                        <td class="separatore_light" style="border-radius:5px">
                        </td>
                    </tr>
                </table> 
            </td> 
        </tr>
    </table>
</asp:Content>
