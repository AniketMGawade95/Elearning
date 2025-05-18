<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Elearning.Admin.dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .card {
            border-radius: 12px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.05);
        }
        .dashboard-title {
            font-size: 2rem;
            font-weight: 600;
            margin-bottom: 30px;
            text-align: center;
        }
        .chart-container {
            background: #ffffff;
            padding: 20px;
            border-radius: 12px;
            margin-bottom: 30px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.05);
        }
    </style>



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <%--<div style="width:50px; height:10000px; background-color:pink;"></div>--%>


    <div class="container py-5">
            <div class="dashboard-title">📊 Admin Dashboard</div>

            <!-- Stats Section -->
            <div class="row mb-4 text-center">
                <div class="col-md-3 mb-3">
                    <div class="card bg-success text-white p-4">
                        <h6>Active Users</h6>
                        <asp:DataList ID="DataList1" runat="server">
                            <ItemTemplate>
                                <h2><%# Eval("active") %></h2>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="col-md-3 mb-3">
                    <div class="card bg-warning text-dark p-4">
                        <h6>Inactive Users</h6>
                        <asp:DataList ID="DataList2" runat="server">
                            <ItemTemplate>
                                <h2><%# Eval("inactive") %></h2>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="col-md-3 mb-3">
                    <div class="card bg-primary text-white p-4">
                        <h6>Total Master Courses</h6>
                        <asp:DataList ID="DataList3" runat="server">
                            <ItemTemplate>
                                <h2><%# Eval("count") %></h2>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <div class="col-md-3 mb-3">
                    <div class="card bg-info text-white p-4">
                        <h6>Total Sub Courses</h6>
                        <asp:DataList ID="DataList4" runat="server">
                            <ItemTemplate>
                                <h2><%# Eval("count") %></h2>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>

            <!-- ScriptManager for UpdatePanels -->
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <!-- Monthly Sales Chart -->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="chart-container">
                        <div class="d-flex justify-content-between align-items-center mb-3">
                            <h5 class="text-primary fw-bold mb-0">
                                <i class="bi bi-bar-chart-line-fill me-2"></i>Monthly Sales Chart
                            </h5>

                            <div class="w-25">
                                <asp:DropDownList
                                    ID="DropDownList2"
                                    runat="server"
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                                    CssClass="form-select border-primary shadow-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Chart
                            ID="Chart2"
                            runat="server"
                            Width="1000px"
                            Height="400px"
                            CssClass="bg-light p-2 rounded shadow-sm">
                            <Series>
                                <asp:Series
                                    Name="Sales"
                                    ChartType="Column"
                                    XValueMember="MonthName"
                                    YValueMembers="TotalSales"
                                    ToolTip="#VALX: $#VALY" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisX Title="Month" TitleFont="Arial, 10pt, style=Bold" />
                                    <AxisY Title="Sales Amount" TitleFont="Arial, 10pt, style=Bold" LabelStyle-ForeColor="DarkGreen" />
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- User Status Pie Chart -->
            <div class="chart-container">
                <h5 class="mb-3">🧮 User Status Pie Chart</h5>
                <asp:Chart ID="Chart3" runat="server" Width="1000px" Height="400px">
                    <Series>
                        <asp:Series
                            Name="user"
                            ChartType="Pie"
                            XValueMember="Status"
                            YValueMembers="UserCount"
                            ToolTip="#VALX: #VALY user (#PERCENT{P1})" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" />
                    </ChartAreas>
                </asp:Chart>
            </div>

            <!-- Dropdown & Grid -->
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-4">
                        <label class="form-label fw-bold">🔽 Filter By:</label>
                        <asp:DropDownList
                            ID="DropDownList3"
                            runat="server"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                            CssClass="form-select w-25 mb-3">
                        </asp:DropDownList>
                        <asp:GridView
                            ID="GridView2"
                            runat="server"
                            CssClass="table table-bordered table-striped">
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
   













</asp:Content>
