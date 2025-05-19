<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="userDashboard.aspx.cs" Inherits="Elearning.User.userDashboard" %>


<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Add custom styles if needed -->
    <style>
        .dashboard-header {
            margin-bottom: 30px;
        }

        .card-progress {
            margin-bottom: 25px;
        }

        .progress {
            height: 25px;
        }

        .progress-bar {
            font-weight: bold;
            font-size: 14px;
        }
        .chart-container {
    text-align: center;
    margin-top: 30px;
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <!-- Dashboard Header Summary -->
        <div class="row dashboard-header">
            <div class="col-md-6">
                <div class="card text-white bg-primary mb-3">
                    <div class="card-body">
                        <h5 class="card-title">Total Courses Purchased</h5>
                        <h3 class="card-text">
                            <asp:Label ID="subcoursescount" runat="server" CssClass="text-white" />
                        </h3>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card text-white bg-success mb-3">
                    <div class="card-body">
                        <h5 class="card-title">Total Topics to Cover</h5>
                        <h3 class="card-text">
                            <asp:Label ID="totalnumbertopics" runat="server" CssClass="text-white" />
                        </h3>
                    </div>
                </div>
            </div>
        </div>

        <!-- Progress Cards Section -->
        <div class="row">
            <asp:Repeater ID="rptProgress" runat="server">
                <ItemTemplate>
                    <div class="col-md-6">
                        <div class="card card-progress shadow-sm">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("SubCourseName") %></h5>
                                <div class="progress mb-2">
                                    <div class="progress-bar bg-info" 
                                         role="progressbar"
                                         style='width:<%# Eval("ProgressPercent") %>%;'
                                         aria-valuenow='<%# Eval("ProgressPercent") %>'
                                         aria-valuemin="0"
                                         aria-valuemax="100">
                                        <%# Eval("ProgressPercent") %>% Complete
                                    </div>
                                </div>
                                <p class="text-muted mb-0">
                                    <%# Eval("CompletedTopics") %> of <%# Eval("TotalTopics") %> topics completed
                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>






        <div class="row mt-5">
    <div class="col-md-6 offset-md-3">
        <asp:Chart ID="ChartProgress" runat="server" Width="600px" Height="400px">

            <Series>
                <asp:Series Name="Progress" ChartType="Pie" />
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" />
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" />
            </Legends>
        </asp:Chart>
    </div>
</div>



       





    </div>

</asp:Content>
