<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.CUPCategoria" CodeBehind="CUPCategoria.ascx.cs" %>
<div class="dtFrmSeparaSmall">Classificazioni CUP</div>    
<div class="dtFrmRG">
    <span class ="dtFrmLabel1">Settore:</span>
    <Siar:ComboCUPCategoriaSettore ID="cmbSettore" runat="server" NomeCampo="Settore" Obbligatorio="true" CssClass="dtFrmCtrl6" />
</div>
<div class="dtFrmRG">
    <span class ="dtFrmLabel1">Sotto Settore:</span>
    <Siar:ComboCUPCategoriaSottoSettore ID="cmbSottoSettore" runat="server" NomeCampo="Sotto settore" Obbligatorio="true" CssClass="dtFrmCtrl6" />
</div>
<div class="dtFrmRG">
    <span class ="dtFrmLabel1">Categoria:</span>
    <Siar:ComboCUPCategoria ID="cmbCategoria" runat="server" Obbligatorio="true" NomeCampo="Categoria" CssClass="dtFrmCtrl6" />
</div>

<script type="text/javascript">
    //  10-11-2017: ridefinizione metodo MS validator per fix del comportamento delle combo in cascata con IE in modalità compatibile: redeclare MS validator code with fix
    function ValidatorOnChange(event) {
        if (!event) {
            event = window.event;
        }
        Page_InvalidControlToBeFocused = null;
        var targetedControl;
        if (event.srcElement) {
            if ((typeof (event.srcElement) != "undefined") && (event.srcElement != null)) {
                targetedControl = event.srcElement;
            }
            else {
                targetedControl = event.target;
            }
        }
        var vals;
        if (targetedControl) {
            if (typeof (targetedControl.Validators) != "undefined") {
                vals = targetedControl.Validators;
            }
            else {
                if (targetedControl.tagName.toLowerCase() == "label") {
                    targetedControl = document.getElementById(targetedControl.htmlFor);
                    vals = targetedControl.Validators;
                }
            }
        }
        var i;
        if (vals) {
            for (i = 0; i < vals.length; i++) {
                ValidatorValidate(vals[i], null, event);
            }
        }
        ValidatorUpdateIsValid();
    }

</script>