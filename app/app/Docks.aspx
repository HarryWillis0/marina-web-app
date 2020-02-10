<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docks.aspx.cs" Inherits="app.Docks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Select a Dock:
        <asp:DropDownList ID="ddlDocks" runat="server" AutoPostBack="True" DataSourceID="DocksDataSource" DataTextField="DockName" DataValueField="DockID" OnSelectedIndexChanged="ddlDocks_SelectedIndexChanged" style="height: 22px">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="DocksDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="MarinaData.DockDB"></asp:ObjectDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="gvSlips" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SlipsDataSource" CssClass="table table-hover table-bordered" >
            <Columns>
                <asp:BoundField DataField="SlipID" HeaderText="SlipID" SortExpression="SlipID" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                <asp:BoundField DataField="Dock" HeaderText="Dock" SortExpression="Dock" />
            </Columns>
            <PagerSettings FirstPageText="" LastPageText="" NextPageText="" />
            <PagerStyle ForeColor="#FF3300" HorizontalAlign="Justify" />
        </asp:GridView>
        <asp:ObjectDataSource ID="SlipsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="MarinaData.SlipDB">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlDocks" Name="Dock" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblLeaseInfo" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
