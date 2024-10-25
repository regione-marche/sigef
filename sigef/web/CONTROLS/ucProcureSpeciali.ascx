<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProcureSpeciali.ascx.cs" Inherits="web.CONTROLS.ucProcureSpeciali" %>

<script type="text/javascript">

        function MostraNascondiDivProcure() {
        var divProcure;
        var imgProcure;
        divProcure = $('[id$=divMostraProcure]')[0];
        imgProcure = $('[id$=imgMostraProcure]')[0];


        if (imgProcure.style.transform == "")
            imgProcure.style.transform = "rotate(180deg)";
        else
            imgProcure.style.transform = "";

        if (divProcure.style.display === "none") {
            divProcure.style.display = "block";
        } else {
            divProcure.style.display = "none";
        }
    }

</script>

<div class="dBox" id="divProcure" runat="server">
    <div class="separatore" style="cursor: pointer; padding-bottom: 3px;" onclick="MostraNascondiDivProcure();">
        <img id="imgMostraProcure" runat="server" style="width: 23px; height: 23px;" />
        Procure Speciali:
    </div>
    <div class="dSezione" id="divMostraProcure">
        <div class="dContenutoFloat">
            <Siar:DataGrid ID="dgMandatiProcura" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                    AutoGenerateColumns="False">
                    <ItemStyle Height="24px" />
                    <Columns>
                        <Siar:NumberColumn HeaderText="Nr.">
                            <ItemStyle Width="35px" HorizontalAlign="center" />
                        </Siar:NumberColumn>
                        <asp:BoundColumn HeaderText="Codice Fiscale">
                            <ItemStyle Width="130px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Consulente">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Bando" DataField="IdBando">
                            <ItemStyle Width="200px" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Attivo" DataField="Attivo">
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                    </Columns>
                </Siar:DataGrid>
        </div>
    </div>
</div>