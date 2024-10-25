<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.CUPCategoria" CodeBehind="CUPCategoria.ascx.cs" %>
<h3 class="pb-5">Classificazioni CUP</h3>
<div class="form-group col-sm-12">
    <Siar:ComboCUPCategoriaSettore Label="Settore:" ID="cmbSettore" runat="server" NomeCampo="Settore" Obbligatorio="true" />
</div>
<div class="form-group col-sm-12">
    <Siar:ComboCUPCategoriaSottoSettore Label="Sotto Settore:" ID="cmbSottoSettore" runat="server" NomeCampo="Sotto settore" Obbligatorio="true" />
</div>
<div class="form-group col-sm-12">
    <Siar:ComboCUPCategoria Label="Categoria:" ID="cmbCategoria" runat="server" Obbligatorio="true" NomeCampo="Categoria" />
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
