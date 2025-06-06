<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fin Elecciones.aspx.cs" Inherits="Votaciones_Web.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p class="text-center">
        <asp:Button ID="btFinalizarElecciones" runat="server" Text="Finalizar Elecciones" OnClick="btFinalizarElecciones_Click" />
        <asp:Label ID="lbAlerta" runat="server" Visible="False" style="text-align: left"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lbGanador" runat="server" style="font-size: xx-large" Visible="False"></asp:Label>
</p>
    <p style="font-size: x-large">
        <asp:Label ID="lbConteoCandidato" runat="server" Text="CONTEO DE VOTOS POR CANDIDATO" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvVotosCandidato" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Visible="False" Width="567px" DataKeyNames="TARJETON">
            <Columns>
                <asp:BoundField DataField="NOMBRE DEL CANDIDATO" HeaderText="NOMBRE DEL CANDIDATO" SortExpression="NOMBRE DEL CANDIDATO" />
                <asp:BoundField DataField="NOMBRE DEL PARTIDO" HeaderText="NOMBRE DEL PARTIDO" SortExpression="NOMBRE DEL PARTIDO" />
                <asp:BoundField DataField="CANTIDAD DE VOTOS" HeaderText="CANTIDAD DE VOTOS" SortExpression="CANTIDAD DE VOTOS" />
                <asp:BoundField DataField="TARJETON" HeaderText="TARJETON" ReadOnly="True" SortExpression="TARJETON" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT C.NOMBRE_CANDIDATO AS 'NOMBRE DEL CANDIDATO', P.NOMBRE_PARTIDO AS 'NOMBRE DEL PARTIDO', C.CANTIDAD_VOTOS AS 'CANTIDAD DE VOTOS', C.TARJETON FROM CANDIDATOS AS C INNER JOIN PARTIDOS AS P ON C.ID_PARTIDO = P.ID_PARTIDO ORDER BY 'CANTIDAD DE VOTOS' DESC"></asp:SqlDataSource>
    </p>
    <p style="font-size: x-large">
        <asp:Label ID="lbConteoPartido" runat="server" Text="CONTEO DE VOTOS POR PARTIDO" Visible="False"></asp:Label>
    </p>
    <asp:GridView ID="gvVotosPartido" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Visible="False" Width="577px">
        <Columns>
            <asp:BoundField DataField="NOMBRE DEL PARTIDO" HeaderText="NOMBRE DEL PARTIDO" SortExpression="NOMBRE DEL PARTIDO" />
            <asp:BoundField DataField="TOTAL DE VOTOS POR PARTIDO" HeaderText="TOTAL DE VOTOS POR PARTIDO" ReadOnly="True" SortExpression="TOTAL DE VOTOS POR PARTIDO" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT P.NOMBRE_PARTIDO AS 'NOMBRE DEL PARTIDO', SUM(C.CANTIDAD_VOTOS) AS 'TOTAL DE VOTOS POR PARTIDO' FROM CANDIDATOS AS C INNER JOIN PARTIDOS AS P ON C.ID_PARTIDO = P.ID_PARTIDO GROUP BY P.NOMBRE_PARTIDO ORDER BY 'TOTAL DE VOTOS POR PARTIDO' DESC"></asp:SqlDataSource>
    <p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
