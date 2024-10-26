<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="web.CONTROLS.RequisitiMisuraPagamento" Codebehind="RequisitiMisuraPagamento.ascx.cs" %>
<div id="divContenitore" runat="server" class="dBox">
    <h3 id="rowMisura" runat="server" class="separatore"></h3>

     <Siar:DataGridAgid ID="dgRequisiti" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" PageSize="20" Width="100%">
                <PagerStyle CssClass="coda" Mode="NumericPages" />                
                <Columns>
                    <Siar:NumberColumn HeaderText="Nr.">                        
                        <ItemStyle HorizontalAlign="center" />
                    </Siar:NumberColumn>
                    <asp:BoundColumn DataField="Requisito" HeaderText="Descrizione requisito">                        
                    </asp:BoundColumn>
                    <asp:BoundColumn headertext="Obbligatorio" DataField="Obbligatorio" DataFormatString="{0:SI|NO}">
                        <itemstyle HorizontalAlign="center"></itemstyle>
                    </asp:BoundColumn>
                    <Siar:CheckColumnAgid DataField="IdRequisito" Name="chkRequisito">                        
                    </Siar:CheckColumnAgid>
                    <asp:BoundColumn></asp:BoundColumn>
                </Columns>
            </Siar:DataGridAgid>
     <asp:HiddenField ID="hdnIdDisposizioniMisura"  runat="server" />
</div>
