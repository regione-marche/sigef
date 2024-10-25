<%@ Control Language="C#" AutoEventWireup="true" Inherits="web.CONTROLS.AdminAteco2007" CodeBehind="AdminAteco2007.ascx.cs" %>

<%--<div class="row align-items-center py-2">--%>
    <div class="col-sm-3">
        <label for="cmbAteco" class="fw-semibold ">Codice ATECO 2007</label>
        <asp:TextBox ID="cmbAteco" runat="server" CssClass="rounded" /> 
    </div>
   <div class="col-sm-2">
        <asp:HiddenField ID="IDAtecoHide" runat="server" />
        <input type="hidden" id="hdnsavedatimonitoraggio" runat="server" />
    </div>
<%--</div>--%>
            
