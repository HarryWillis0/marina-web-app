﻿<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaseSlip.aspx.cs" Inherits="app.LeaseSlip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        Select a Dock:
        <asp:DropDownList ID="ddlDocks" runat="server" AutoPostBack="True" DataSourceID="DocksDataSource" DataTextField="DockName" DataValueField="DockID" OnSelectedIndexChanged="ddlDocks_SelectedIndexChanged" style="height: 22px">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="DocksDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="MarinaData.DockDB"></asp:ObjectDataSource>
    </p>
    <p>
        <h2>Available slips:</h2>
    </p>
    <p>
        <asp:GridView ID="gvSlips" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SlipsDataSource" CssClass="table table-hover table-bordered" OnRowCommand="gvSlips_RowCommand" OnRowCreated="gvSlips_RowCreated" OnSelectedIndexChanged="gvSlips_SelectedIndexChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid">
            <Columns>
                <asp:BoundField DataField="SlipID" HeaderText="SlipID" SortExpression="SlipID" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
                <asp:BoundField DataField="Dock" HeaderText="Dock" SortExpression="Dock" />
            </Columns>
            <PagerSettings FirstPageText="" LastPageText="" NextPageText="" />
            <PagerStyle ForeColor="#FF3300" HorizontalAlign="Justify" CssClass="pagerMargin"/>
        </asp:GridView>
        <asp:ObjectDataSource ID="SlipsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="MarinaData.SlipDB">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlDocks" Name="Dock" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="lblLeaseInfo" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnLease" runat="server" CssClass="btn-success" Text="Lease current Slip" OnClick="btnLease_Click" Visible="False" />
    </p>
    <h2 id="yourLeases">Your Leases:</h2>
    <div runat="server" id="myLeases" class="container row">
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
