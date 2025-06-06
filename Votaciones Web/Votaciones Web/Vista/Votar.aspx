<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Votar.aspx.cs" Inherits="Votaciones_Web.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dl>
        <dd>
            <p class="text-center" style="font-size: xx-large">
                &nbsp; &nbsp; Sistema De Votaciones</p>
        </dd>
        <dt>Filtrar por partido:
            <asp:DropDownList ID="cbPartidos" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NOMBRE_PARTIDO" DataValueField="ID_PARTIDO" Width="188px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT [ID_PARTIDO], [NOMBRE_PARTIDO] FROM [PARTIDOS]"></asp:SqlDataSource>
        </dt>
    </dl>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Numero del Tarjeton" DataSourceID="SqlDataSource2" Width="448px">
            <Columns>
                <asp:BoundField DataField="Partido" HeaderText="Partido" SortExpression="Partido" />
                <asp:BoundField DataField="Nombre Candidato" HeaderText="Nombre Candidato" SortExpression="Nombre Candidato" />
                <asp:BoundField DataField="Numero del Tarjeton" HeaderText="Numero del Tarjeton" ReadOnly="True" SortExpression="Numero del Tarjeton" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT P.NOMBRE_PARTIDO AS 'Partido', C.NOMBRE_CANDIDATO AS 'Nombre Candidato', C.TARJETON AS 'Numero del Tarjeton' FROM CANDIDATOS AS C INNER JOIN PARTIDOS AS P ON C.ID_PARTIDO = P.ID_PARTIDO WHERE (C.ID_PARTIDO = @ID_PARTIDO)">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbPartidos" Name="ID_PARTIDO" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Cedula Del Votante:&nbsp;
        <asp:DropDownList ID="cbVotante" runat="server" DataSourceID="SqlDataSource3" DataTextField="CEDULA" DataValueField="CEDULA" Width="214px" AutoPostBack="True" AppendDataBoundItems="True">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;Nombre del Votante:&nbsp;<asp:TextBox ID="txNombre" runat="server" ReadOnly="True" Width="307px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btConsultarNombre" runat="server" OnClick="btConsultarNombre_Click" Text="Consultar Nombre" Width="153px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btCancelar" runat="server" Enabled="False" OnClick="btCancelar_Click" Text="Cancelar" Width="126px" />
        &nbsp;<asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT [CEDULA], [NOMBRE] FROM [VOTANTES] WHERE ([CEDULA] = @CEDULA)">
            <SelectParameters>
                <asp:ControlParameter ControlID="cbVotante" Name="CEDULA" PropertyName="SelectedValue" Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp; Numero Del Tarjeton:&nbsp;&nbsp; <asp:DropDownList ID="cbTarjeton" runat="server" DataSourceID="SqlDataSource4" DataTextField="TARJETON" DataValueField="TARJETON" Width="173px" AppendDataBoundItems="True" Enabled="False">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btVotar" runat="server" Text="Votar" Width="80px" OnClick="btVotar_Click" Enabled="False" />
&nbsp;<asp:Label ID="lbRealizado" runat="server"></asp:Label>
&nbsp;<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT [TARJETON] FROM [CANDIDATOS]"></asp:SqlDataSource>
&nbsp;<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:VOTACIONESConnectionString %>" SelectCommand="SELECT CEDULA, NOMBRE FROM VOTANTES WHERE (YA_VOTO = 0)"></asp:SqlDataSource>
    </p>
</asp:Content>
