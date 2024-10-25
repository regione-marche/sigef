using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

public partial class VisualizzaDocumento : System.Web.UI.Page
{
    SiarLibrary.ArchivioFile af = new SiarLibrary.ArchivioFile();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ClearHeaders();
        Response.ClearContent();
        try
        {
            getContenutoDocumento();
            SiarLibrary.Protocollo p = new SiarLibrary.Protocollo();
            if (af.Contenuto == null && af.Id != null)
                af.Contenuto = p.AF_RicercaFile(af.NomeCompleto, af.Id);
            if (af.Contenuto == null) 
                throw new Exception("Non è stato possibile renderizzare il documento selezionato.");
            if(af.Tipo == "text/xml")
            {
                MemoryStream str = new MemoryStream(af.Contenuto);
                var xdoc = XDocument.Load(str);
                if (CheckFatturaElettronica(xdoc))
                {
                    string versione = xdoc.Descendants().Where(v => v.Name.LocalName == "FatturaElettronica").FirstOrDefault().Attribute("versione").Value;
                    XPathDocument dx1 = new XPathDocument(XmlReader.Create(new StringReader(xdoc.ToString())));
                    XslCompiledTransform xst = new XslCompiledTransform();
                    if (versione.StartsWith("FPR"))
                    {
                        xst.Load(Server.MapPath("~/resources/fatturaordinaria_v1.2.1.xsl"));
                    }
                    else
                    {
                        xst.Load(Server.MapPath("~/resources/fatturaPA_v1.2.1.xsl"));
                    }
                    
                    MemoryStream outputStream = new MemoryStream();
                    xst.Transform(dx1, null, outputStream);
                    var output = outputStream.ToArray();
                    af.Contenuto = output;
                    setResponseMimeType("text/html", "html");
                }
            }
            else
            {
                setResponseMimeType();
            }
            //setResponseMimeType();
            Response.BinaryWrite(af.Contenuto);
        }
        catch (Exception ex) { Response.Write(ex.Message); }
        clearReportSession();
        Response.End();
    }

    private void getContenutoDocumento()
    {
        if (Session["doc"] != null)
        {
            af.Contenuto = (byte[])Session["doc"];
            af.NomeCompleto = "siar_visualizza_documento.pdf";
            af.Tipo = "application/pdf";
        }
        else if (Session["siar_view_file"] != null)
        {
            SiarLibrary.ArchivioFileCollection docs = (SiarLibrary.ArchivioFileCollection)Session["siar_view_file"];
            int indice;
            int.TryParse(Request.QueryString["nf"], out indice);
            if (docs.Count > indice) 
                af = docs[indice];
        }
        else if (Session["idArchivioFile"] != null)
        {
            int idArchivio;
            int.TryParse(Request.QueryString["nf"].ToString(), out idArchivio);
            //af = new SiarBLL.ArchivioFileCollectionProvider().GetById(idArchivio);
            af.Id = idArchivio;
        }
    }

    private void setResponseMimeType()
    {
        string ext = af.NomeCompleto.Value.Substring(af.NomeCompleto.Value.LastIndexOf(".") + 1);
        if (af.Tipo == null) 
            af.Tipo = SiarLibrary.DbStaticProvider.GetExtensionMimeType(ext, null);
        Response.ContentType = af.Tipo;
        Response.AppendHeader("Content-Disposition", "inline; filename=sdoc_" + Server.UrlEncode(af.NomeFile ?? "report." + ext));
    }

    private void setResponseMimeType(string MimeType, string Extension)
    {
        //string ext = af.NomeCompleto.Value.Substring(af.NomeCompleto.Value.LastIndexOf(".") + 1);
        //if (af.Tipo == null) af.Tipo = SiarLibrary.DbStaticProvider.GetExtensionMimeType(ext, null);
        Response.ContentType = MimeType;
        Response.AppendHeader("Content-Disposition", "inline; filename=sdoc_" + Server.UrlEncode(af.NomeFile ?? "report." + Extension));
    }

    private void clearReportSession()
    {
        //tolgo il report di tipo singolo dalla sessione
        Session.Remove("doc");
    }


    private bool CheckFatturaElettronica(XDocument xdoc)
    {
        bool result = false;
        XElement datiFattura = xdoc.Elements().Where(p => p.Name.LocalName == "FatturaElettronica").FirstOrDefault();
        if (datiFattura != null)
        {
            result = true;
        }

        return result;
    }
}
