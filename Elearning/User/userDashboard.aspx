<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="userDashboard.aspx.cs" Inherits="Elearning.User.userDashboard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div style="width:50px; height:10000px; background-color:pink;"></div>--%>



    <%--<div class="dashboard-container">
                <div class="dashboard-header">
                    <h1>User Dashboard</h1>

                    <p>
                        Welcome back,
                        <asp:Literal ID="litUserName" runat="server"></asp:Literal>!
                    </p>
                </div>

                <div class="stats-container">
                    <div class="stat-box">
                        <h2>Course Statistics<br />
                        </h2>
                        <div style="display: flex; justify-content: space-between;">
                            <div>
                                <h3>Sub Courses</h3>
                                <asp:DataList ID="DataList1" runat="server">
                                    <ItemTemplate>
                                        <p>
                                            subcource count:<%#Eval("count") %>
                                        </p>
                                    </ItemTemplate>

                                </asp:DataList>

                                <p>
                                    <asp:Literal ID="litSubCoursesCount" runat="server">
                                    </asp:Literal>
                                </p>
                            </div>
                            <div>
                                <h3>Master Courses</h3>

                                <asp:DataList ID="DataList2" runat="server">
                                    <ItemTemplate>
                                        <p>
                                            Mastercource count:<%#Eval("NoOfMasterCourse") %>
                                        </p>
                                    </ItemTemplate>
                                </asp:DataList>
                                <p>
                                    <asp:Literal ID="litMasterCoursesCount" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="stat-box">
                        <h2>Overall Progress</h2>
                        <div style="display: flex; justify-content: space-between;">
                            <div>
                                <h3>Topics Completed</h3>
                                <asp:DataList ID="DataList3" runat="server">
                                         <ItemTemplate>
                                             <p>
                                                 complete:<%#Eval("count") %>
                                             </p>
                                         </ItemTemplate>
                                </asp:DataList>
                                <p>
                                    <asp:Literal ID="litTopicsCompleted" runat="server"></asp:Literal>
                                </p>
                            </div>
                            <div>
                                <h3>Incomplete Topics</h3>
                                 <asp:DataList ID="DataList4" runat="server">
                                          <ItemTemplate>
                                            <p>
                                             incomplete:<%#Eval("count") %>
                                           </p>
                                        </ItemTemplate>
                                 </asp:DataList>
                                <p>
                                    <asp:Literal ID="litDaysActive" runat="server"></asp:Literal>
                                </p>
                            </div>

                          <!--  <div>
                                <h3>Days Active</h3>
                                <p>
                                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                </p>
                            </div> -->
                        </div>
                    </div>
                </div>

                <div class="chart-container">
                    <div class="chart-box">
                        <h2>Course Completion</h2>
                        <asp:Chart ID="Chart1" runat="server">
                            <Series>
                                <asp:Series Name="Series1" ChartType ="Pie" XValueMember ="Status" YValueMembers ="UserCount">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        <canvas id="completionChart" width="200" height="100"></canvas>
                        <asp:HiddenField ID="hdnCompletedCourses" runat="server" />
                        <asp:HiddenField ID="hdnIncompleteCourses" runat="server" />
                    </div>

                   <div class="progress-container">
     <h2 class="chart-title">Learning Progress</h2>
    
    <asp:Repeater ID="rptProgressBars" runat="server">
        <ItemTemplate>
            <div style="margin-bottom: 15px;">
                <div><strong><%# Eval("SubCourseName") %></strong></div>
                <div style="background-color: #e0e0e0; width: 100%; height: 25px; border-radius: 5px;">
                    <div style='width: <%# Eval("ProgressPercent") %>%; height: 100%; background-color: #4caf50; border-radius: 5px;'>
                    </div>
                </div>
                <div><%# Eval("ProgressPercent") %>% completed</div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</div>


                    </div>
                    </div>
                </div>

                <div class="subscription-alert" id="subscriptionAlert" runat="server">
                    <i class="fas fa-exclamation-triangle"></i>
                    <div>
                        <h3>Subscription Reminder</h3>
                        <p>
                            Your subscription will expire in
                            <asp:Literal ID="litDaysRemaining" runat="server"></asp:Literal>
                            days. <a href="RenewSubscription.aspx">Renew now</a> to continue learning without interruption.
                        </p>
                    </div>
                </div>

                <div class="course-list">
                    <h3>My Courses</h3>
                    <asp:Repeater ID="rptCourses" runat="server">
                        <ItemTemplate>
                            <div class="course-item">
                                <div class="course-name"><%# Eval("CourseName") %></div>
                                <div class="course-status <%# Convert.ToBoolean(Eval("IsCompleted")) ? "status-completed" : "status-incomplete" %>">
                                    <%# Convert.ToBoolean(Eval("IsCompleted")) ? "Completed" : "In Progress" %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

               



            </div>

            <script type="text/javascript">
                document.addEventListener('DOMContentLoaded', function () {
                    // Pie Chart for Course Completion
                    var completedCourses = parseInt(document.getElementById('<%= hdnCompletedCourses.ClientID %>').value);
                    var incompleteCourses = parseInt(document.getElementById('<%= hdnIncompleteCourses.ClientID %>').value);

                    var ctx = document.getElementById('Chart1').getContext('2d');
                    var myChart = new Chart(ctx, {
                        type: 'pie',
                        data: {
                            labels: ['Completed Sub Courses', 'Incomplete Sub Courses'],
                            datasets: [{
                                data: [completedCourses, incompleteCourses],
                                backgroundColor: [
                                    '#4CAF50',
                                    '#F44336'
                                ],
                                borderWidth: 0
                            }]
                        },
                        options: {
                            responsive: true,
                            plugins: {
                                legend: {
                                    position: 'bottom'
                                }
                            }
                        }
                    });
                });
            </script>
        </form>
    </body>
    </html>--%>


</asp:Content>
