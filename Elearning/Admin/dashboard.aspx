<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Elearning.Admin.dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="justify-evenly flex py-5">
        <div>
            <h3>Active Users Count</h3>
            <asp:Label ID="Label1" runat="server"></asp:Label>

            <div>
                <h3>Inactive Users Count</h3>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </div>
            <div>
                <h3>Registered Users Count</h3>

                <asp:Label ID="Label3" runat="server"></asp:Label>
            </div>
            <div>
                <h3>No. of Master Courses</h3>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </div>
        </div>

        <div class="flex justify-evenly">
            <asp:Chart ID="Graph" runat="server" Height="323px" Width="428px">
                <Series>
                    <asp:Series Name="Graph" ChartType="StackedColumn"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:Chart ID="pi" runat="server" Height="334px" Width="440px">
                <Series>
                    <asp:Series Name="PiChart" ChartType="Pie" ChartArea="ChartArea1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>

</asp:Content>
