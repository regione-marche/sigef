using System;

public partial class VFEPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
#if (!DEBUG)
        SiarLibrary.Web.CohesionSSO cohesionSSO = new SiarLibrary.Web.CohesionSSO(Request, Response, Session);
        cohesionSSO.ValidateFE();
#endif
    }
}
