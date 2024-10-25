<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" Inherits="web.Public.SupportoFirmaDigitale"
    AutoEventWireup="true" CodeBehind="SupportoFirmaDigitale.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="Server">
    <table class="tableTab" width="800" style="border-top: #3f6f3f 1px solid; display: none;">
        <tr>
            <td align="center" class="separatore" style="text-align: left; height: 17px;">
                &nbsp;Per il corretto funzionamento della procedura assicurarsi di aver installato:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <strong>1)<em> Adobe Acrobat Reader</em></strong>
                        </td>
                        <td>
                            <strong><a href="http://www.cartaraffaello.it/LinkClick.aspx?fileticket=%2baUBC8pYjO8%3d&amp;tabid=95&amp;language=it-IT"
                                target="_blank">Download </a></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td>
                            Installare Acrobat ed impostare le opzioni di protezioni come descritto nel manuale
                            visualizzabile <a href="http://siar.regione.marche.it/Public/Download/PreferenzeAcrobate.htm"
                                target="_blank">qui</a>.
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <strong>2)<em> Driver Lettore </em></strong>
                        </td>
                        <td>
                            <strong><a href="http://www.cartaraffaello.it/AreaDownload/Windows/tabid/95/language/en-US/Default.aspx#1"
                                target="_blank">Download </a></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td>
                            Scaricare il driver del lettore che si possiede.
                        </td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <strong>3)<em> File di configurazione Smart Card </em></strong>
                        </td>
                        <td>
                            <strong><a href="http://www.cartaraffaello.it//LinkClick.aspx?fileticket=OPhaWHaOJT8%3d&amp;tabid=95&amp;language=en-US"
                                target="_blank">Download </a></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td>
                            Scaricare il file, scompattarlo e copiare il file incryptoki2.conf nella cartella
                            C:\windows\system32.
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <strong>4)<em> Driver Carta Raffaello</em></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 50%; vertical-align: top">
                            <table style="border-right: black 1px solid;">
                                <tr>
                                    <td style="width: 350px">
                                        4.1 - Per i possessori delle <strong>nuove</strong> carte installare:
                                        <br />
                                        (numero della carta inizia per 6)
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;">
                                        <strong><a href="http://www.cartaraffaello.it//LinkClick.aspx?fileticket=HVBnrelh%2f4E%3d&amp;tabid=95&amp;language=en-US"
                                            target="_blank">Download </a></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        L'importazione dei certificati avviene in automatico.
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 50%; vertical-align: top">
                            <table>
                                <tr>
                                    <td>
                                        4.2 - Per tutti gli altri possessori installare:
                                        <br />
                                        (numero della carta inizia per 1)
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                        <strong><a href="http://www.cartaraffaello.it/LinkClick.aspx?fileticket=y5DvfKhePaY%3d&amp;tabid=95&amp;language=en-US"
                                            target="_blank">Download </a></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Al termine dell'installazione inserire la carta nel lettore ed importare i certificati.
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
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <strong>5)<em> Java Virtual Machine </em></strong>
                        </td>
                        <td>
                            <strong><a href="http://www.cartaraffaello.it/LinkClick.aspx?fileticket=uIrxf%2f5QPaY%3d&amp;tabid=95&amp;language=en-US"
                                target="_blank">Download </a></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Scaricare ed installare il pacchetto. &nbsp;<br />
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 250px">
                            <strong>6)&nbsp; TEST DELLA FIRMA DIGITALE:</strong>
                        </td>
                        <td>
                            <strong><a href="http://www.firmaraffaello.it/ServiziCarta/test/TestApplet.html"
                                target="_blank">Vai alla pagina</a></strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;Test finale per la verifica della correttezza dell'installazione.
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="separatore">
                &nbsp;Opzionale:
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <strong>&nbsp;- Lista certificati RootCA per la verifica della firma digitale:</strong>
            </td>
        </tr>
        <tr>
            <td>
                <span id="ctl00_cphContenuto_dgDocumenti_ctl05_Label4" style="font-size: 11px; font-style: italic">
                    &nbsp; &nbsp; File compresso con i certificati root CA da installare sul computer
                    per la verifica della firma digitale dei firmatari delle domande di aiuto</span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <a href="http://siar.regione.marche.it/Public/Download/CertificatiRoot.zip">
                    <img alt="Scarica il file" src="../images/winzip.gif" /></a> &nbsp; <em>( documento
                        zip - 16 Kb )</em>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <iframe width="100%" height="1200px" src="https://cittadinanzadigitale.regione.marche.it/">
    </iframe>
</asp:Content>
