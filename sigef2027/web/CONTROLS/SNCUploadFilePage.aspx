<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SNCUploadFilePage.aspx.cs"
    Inherits="web.CONTROLS.SNCUploadFilePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="headerUFPage" runat="server">

    <script type="text/javascript">
        function SNCUFPFileSelected(el) { document.getElementById('txtPercorsoFile_text').value = el.value; }
        var dvWaiting;
        function SNCUFPWaiting() {
            var w = Math.min((window.innerWidth ? window.innerWidth : 100000), document.documentElement.clientWidth);
            var h = Math.min((window.innerHeight ? window.innerHeight : 100000), document.documentElement.clientHeight);
            dvWaiting = document.createElement("div"); dvWaiting.className = "dvWaiting";
            dvWaiting.style.width = w + 'px'; dvWaiting.style.height = h + 'px'; dvWaiting.style.lineHeight = h + 'px';
            dvWaiting.appendChild(document.createTextNode("Attendere prego.."));
            document.body.appendChild(dvWaiting);
        }
        function SNCUFPDone(id, nome_file, id_elem, feObj) { if (dvWaiting) dvWaiting.style.display = 'none'; top.SNCUFUpdateActiveElement({ 'id': id, 'nome_file': nome_file, 'id_SNCUFActiveElement': id_elem, 'feObj': feObj }); }
    </script>

</head>
<body style="margin: 0">
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="form-group">
            <table class="table">
                <tr>
                    <td>
                        <Siar:TextBox  ID="txtPercorsoFile" runat="server" ReadOnly="true" />
                    </td>
                    <td>
                        <div class="fileUpload Button">
                            <span style="line-height: 1.7em">Sfoglia</span>
                            <asp:FileUpload CssClass="upload" ID="ucFileUpload" runat="server" />
                        </div>
                    </td>
                    <td>
                        <asp:Button ID="btnSNCUFCarica" runat="server" class="btn btn-primary py-1" Text="Carica"
                            OnClick="btnSNCUFCarica_Click" OnClientClick="SNCUFPWaiting();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
