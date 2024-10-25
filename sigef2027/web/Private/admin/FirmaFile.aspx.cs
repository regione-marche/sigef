using System;
using System.Web;

namespace web.Private.admin
{
    public partial class FirmaFile : SiarLibrary.Web.PrivatePage
    {
        protected override void OnPreInit(EventArgs e)
        {
            FunzioneMenu = "firma_file_admin";
            base.OnPreInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string testo_cella = "<input id='btnFirmaNuovaApplet' type=button value='Firma il documento' class='Button' onclick='firmaInLocale();'/>";
            if (Request.Browser.Browser == "IE" || Request.Browser.Browser == "InternetExplorer")

                testo_cella += "<OBJECT CODE='it.unicam.cs.sign.SignApplet.class' ARCHIVE='" + System.Configuration.ConfigurationManager.AppSettings["DownloadDir"] + "SignApplet.jar' id='siarSignApplet' height='1px' width='1px'>"
                    + "<PARAM name='java_arguments' value='-Xmx2048m'>" // <!-- Necessario per firmare file grandi richiede java > 1.6u10 -->
                    + "<PARAM name='PathDll' value='PKCS11.dll%inp11lib.dll%bit4xpki.dll%incryptoki2.dll%bit4ipki.dll%bit4opki.dll%OCSCryptoki.dll%asepkcs.dll%SI_PKCS11.dll%cmP11.dll%bit4cpki.dll%bit4p11.dll%asepkcs.dll%libbit4opki.so%libbit4spki.so%libbit4p11.so%libbit4ipki.so%opensc-pkcs11.so%libopensc.dylib%libbit4xpki.dylib%libbit4ipki.dylib%libbit4opki.dylib%libASEP11.dylib'>" // <!-- Librerie PKCS11 da usare. Si può inserire o solo il nome o, in caso non venisse trovata, tutto il percorso. Vanno separate con % ; Se nessuna libreria viene specificata o il parametro non è presente verrà chiesto di scegliere la libreria da utilizzare direttamente dall'applet nel pc dell'utente -->
                    + "<PARAM name='SalvataggioLocale' value='si'>" // <!-- se si verrà chiesto dove salvare il file firmato nel pc, altrimenti verrà richiamata la funzione PassaFileFirmato dove in caso si firmassero piu files, la variabile StringaFilePdf sarà dello stesso formato del parametro DataToSign; se il parametro è vuoto o non presente il valore di default è no-->
                    + "<PARAM name='FirmaPDFComeP7m' value='no'>" //<!-- se impostata su si firmerà i pdf in formato P7M, quindi la firma non verrà integrata nel PDF e i parametri FirmaVisibile e NumeroPagina non verranno considerati. Impostando no la firma verrà integrata nel pdf cercando di non sovrapporsi alle firme precedenti qualora ci siano ; se il parametro è vuoto o non presente il valore di default è no -->
                    + "<PARAM name='FirmaVisibile' value='si'>"// <!-- Se si viene mostrata la firma nel pdf ; se il parametro è vuoto o non presente il valore di default è no-->
                    + "<PARAM name='NumeroPagina' value=''>" // <!-- se impostata seleziona il numero di pagina su cui applicare la firma se questa è visibile; se il parametro è vuoto o non presente o = -1 e la firma è visibile allora questa viene applicata all'ultima pagina -->
                    + "<PARAM name='PosizioneFirma' value='DESTRA'>"// <!-- se impostato può assumere valore "SINISTRA" o "DESTRA" ed indica la posizione della firma nel pdf nella pagina specificata precedentemente, qualora la firma sia visible. Se vuoto, non presente, o conentente un altro valore la posizione della firma nei pdf verrà calcolata cercando di non sovrapporsi alle firme esistenti -->
                    + "<PARAM name='ControlloCodiceFiscaleFirmatario' value=''>"// <!-- se impostato permette di limitare la firma al solo utente con codice fiscale specificato -->
                    + "<PARAM name='TimeServerUrl' value='" + System.Configuration.ConfigurationManager.AppSettings["CohesionUrl"] + "/SignApplet/TimeService.aspx'>"// <!-- Indirizzo della pagina certificata da cui prendere la data da impostare sulla firma; la pagina controlla anche che l'host su cui è caricata l'applet sia censito ed abilitato all'utilizzo -->
                    + "<PARAM name='SignButtonText' value=''>"// <!-- Testo da mostrare nel bottone di firma; se il parametro è vuoto o non presente il bottone non sarà visibile-->
                    + "<PARAM name='UploadButtonText' value=''>" //<!-- Testo da mostrare nel bottone per il caricamento di documenti già firmati; se il parametro è vuoto o non presente il bottone non sarà visibile. Il bottone permette di caricare documenti già firmati e passarli alla funzione PassaFileFirmato secondo il formato usato dalla funzione di firma dell'applet -->
                    + "<PARAM name='MostraTuttiICertificati' value='no'>"// <!-- Se impostato a si, l'applet mostrerà tutti i certificati abilitati alla firma (includendo anche quelli di autenticazione), altrimenti da priorità ai certificati di "Non ripudio"; se il parametro è vuoto o non presente il valore di default è no -->
                    + "</OBJECT>";
            else
                testo_cella += "<embed id='siarSignApplet' code='it.unicam.cs.sign.SignApplet.class' archive='"
                    + System.Configuration.ConfigurationManager.AppSettings["DownloadDir"] + "SignApplet.jar' type='application/x-java-applet;version=1.8' "
                    + "height='1px' width='1px' java_arguments='-Xmx2048m' PathDll='PKCS11.dll%inp11lib.dll%bit4xpki.dll%incryptoki2.dll%bit4ipki.dll%bit4opki.dll%OCSCryptoki.dll%asepkcs.dll%SI_PKCS11.dll%cmP11.dll%bit4cpki.dll%bit4p11.dll%asepkcs.dll%libbit4opki.so%libbit4spki.so%libbit4p11.so%libbit4ipki.so%opensc-pkcs11.so%libopensc.dylib%libbit4xpki.dylib%libbit4ipki.dylib%libbit4opki.dylib%libASEP11.dylib' "
                    + "SalvataggioLocale='si' FirmaPDFComeP7m='no' FirmaVisibile='si' NumeroPagina='' PosizioneFirma='DESTRA' "
                    + "ControlloCodiceFiscaleFirmatario='' TimeServerUrl='" + System.Configuration.ConfigurationManager.AppSettings["CohesionUrl"]
                    + "/SignApplet/TimeService.aspx' SignButtonText='' UploadButtonText='' MostraTuttiICertificati='no' />";

            divObjFirma.InnerHtml = testo_cella;
        }
    }
}