<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccordion.ascx.cs" Inherits="web.CONTROLS.ucAccordion" %>

<style type="text/css">

    .css_accordion_selected
    {
        display: block;
        cursor: pointer;
        position: relative;
        padding: .5em .5em .5em .7em;
        border-top-right-radius: 3px;
        border-top-left-radius: 3px;
        border: 1px solid #003eff;
        /*background: #007fff;*/
        background-color: #0A6BB1;
        background: linear-gradient(#0A6BB1,#1482C6,#0A6BB1);
        color: #ffffff;
    }


    .css_accordion
    {
        display: block;
        cursor: pointer;
        position: relative;
        padding: .5em .5em .5em .7em;
        border-top-right-radius: 3px;
        border-top-left-radius: 3px;
        border: 1px solid #c5c5c5;
        background: #f6f6f6;
        font-weight: normal;
        color: #454545;
    }

    .css_accordion_box
    {
        border: 1px solid #c5c5c5;
        margin-top: 1px;
    }

</style>

<script>
    alert("ciaone");
</script>

<div id="divAccordion" runat="server" style="width: 100%;">

</div>

<div style="display: none">
    <asp:HiddenField ID="hdnDivSelected" runat="server" />
    <Siar:Button ID="btnPostDivSelect" runat="server" CausesValidation="False" OnClick="btnPostDivSelect_Click" />
</div>

<div id="divAccordionContent" runat="server" style="width: 100%;">

</div>
<input type="hidden" class=".scripttoexecute" value="alert('ciaoneeee');" />
