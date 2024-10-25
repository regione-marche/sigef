<%@ Page Language="C#" MasterPageFile="~/SiarPage.master" AutoEventWireup="true"
    CodeBehind="Manuali.aspx.cs" Inherits="web.Public.Manuali" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenuto" runat="server">
    <div>
        <strong>Manuali video Sigef</strong>
        <br />
        <br />
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lVarianti" runat="server" Text="Inserimento Varianti"
                    Font-Bold="true" Font-Size="Medium"></asp:Label>
                <br />
                <video id="InserimentoVarianti" class="video-js vjs-default-skin" controls
                    preload="none" width="500px" height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/PIN_COHESION_First_Frame.png"
                    data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/RichiestaVariante.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 
                            <a href="http://videojs.com/html5-video-support/" target="_blank"></a></p>
                            <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/RichiestaVariante.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come inserire una variante per il bando Misura 4.1
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lAutenticazionePinCohesion" runat="server" Text="Autenticazione PIN Cohesion"
                    Font-Bold="true" Font-Size="Medium"></asp:Label>
                <br />
                <video id="AutenticazionePinCohesion" class="video-js vjs-default-skin" controls
                    preload="none" width="500px" height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/PIN_COHESION_First_Frame.png"
                    data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/PIN_COHESION.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 
                            <a href="http://videojs.com/html5-video-support/" target="_blank"></a></p>
                            <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/PIN_COHESION.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come effettuare l'autenticazione al framework Cohesion con la
                credenziale Pin Cohesion
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lAutenticazioneCartaRaffaello" runat="server" Text="Autenticazione Carta Raffaello"
                    Font-Bold="true" Font-Size="Medium"></asp:Label>
                <br />
                <video id="AutenticazioneCartaRaffaello" class="video-js vjs-default-skin" controls
                    preload="none" width="500px" height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/CARTA_RAFFAELLO_First_Frame.png"
                    data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/CARTA_RAFFAELLO.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 <a href="http://videojs.com/html5-video-support/" target="_blank"></a>
                            </p>
                             <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/CARTA_RAFFAELLO.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come effettuare l'autenticazione al framework Cohesion con la
                credenziale Carta Raffaello
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lOtpCohesion" runat="server" Text="Autenticazione Otp Cohesion" Font-Bold="true"
                    Font-Size="Medium"></asp:Label>
                <br />
                <video id="AutenticazioneOtpCohesion" class="video-js vjs-default-skin" controls
                    preload="none" width="500px" height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/OTP_COHESION_First_Frame.png"
                    data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/OTP_COHESION.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 <a href="http://videojs.com/html5-video-support/" target="_blank"></a></p>
                               <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/OTP_COHESION.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come effettuare l'autenticazione al framework Cohesion con la
                credenziale Otp Cohesion
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Domanda di contributo" Font-Bold="true" Font-Size="Medium"></asp:Label>
                <br />
                <video id="StartUp" class="video-js vjs-default-skin" controls preload="none" width="500px"
                    height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/DOMANDA_CONTRIBUTO_First_Frame.png" data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/DOMANDA_CONTRIBUTO.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 <a href="http://videojs.com/html5-video-support/" target="_blank"></a></p>
                               <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/OTP_COHESION.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come presentare una domanda in risposta ad un bando
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Firma Digitale" Font-Bold="true" Font-Size="Medium"></asp:Label>
                <br />
                <video id="StartUp" class="video-js vjs-default-skin" controls preload="none" width="500px"
                    height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/FIRMA_DIGITALE_First_Frame.png" data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/FIRMA_DIGITALE.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 <a href="http://videojs.com/html5-video-support/" target="_blank"></a></p>
                               <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/OTP_COHESION.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come firmare digitalmente una domanda
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Domanda di pagamento" Font-Bold="true" Font-Size="Medium"></asp:Label>
                <br />
                <video id="IdDomandaPagamento" class="video-js vjs-default-skin" controls="controls" preload="none" width="500px"
                    height="auto" poster="https://sigef.regione.marche.it/Public/Manuali/DOMANDA_PAGAMENTO_First_Frame.png" data-setup="{}">
                            <source src="https://sigef.regione.marche.it/Public/Manuali/DOMANDA_PAGAMENTO.mp4" type='video/mp4' />
                            <p class="vjs-no-js">Per la visualizzazione di questo video bisogna abilitare JavaScript e il supporto a HTML5 <a href="http://videojs.com/html5-video-support/" target="_blank"></a></p>
                               <p>
                            Per scaricare il video <a href="https://sigef.regione.marche.it/Public/Manuali/DOMANDA_PAGAMENTO.mp4">cliccare qui</a>
                            </p>
                  </video>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Il video descrive come compilare una domanda di pagamento
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabeCalcoloIndicatori" runat="server" Text="Vademecum calcolo e monitoraggio Indicatori (All. G e H Linee guida Bandi FESR)" Font-Bold="true" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <br />
                <br />
            </td>
            <td>
                Vademecum calcolo e monitoraggio Indicatori (All. G e H Linee guida Bandi FESR)&nbsp;
                <a href='../Public/Download/Vademecum_calcolo_e_monitoraggio_Indicatori_(All._G_e_H_Linee_guida_Bandi_FESR).pdf' target='_blank'>
                    <img src='../images/acrobat.gif' alt='Vademecum calcolo e monitoraggio Indicatori (All. G e H Linee guida Bandi FESR)' /></a>
                &nbsp;&nbsp;&nbsp;(pdf editabile)
            </td>
        </tr>
    </table>
</asp:Content>
