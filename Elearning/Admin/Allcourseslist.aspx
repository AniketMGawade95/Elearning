<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Allcourseslist.aspx.cs" Inherits="Elearning.Admin.Allcourseslist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View All CourseList</title>
    <style>
        body {
            font-family: Arial;
        }
        .filter-row select, .filter-row button {
            margin-right: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card border-primary">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">All Courses List</h4>
            </div>
            <div class="card-body">

                <!-- Filters -->
                <div class="row filter-row mb-4">
                    <div class="col-md-3">
                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary w-100" OnClick="Button1_Click" />
                    </div>
                </div>

                <!-- Table -->
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped text-center" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                        <asp:BoundField DataField="SubCourseName" HeaderText="SubCourse Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price (₹)" />
                        <asp:BoundField DataField="NumberOfTopics" HeaderText="Number of Topics" />
                        <asp:BoundField DataField="FormattedDuration" HeaderText="Total Duration (hh:mm:ss)" />
                        <asp:BoundField DataField="NumberOfAssignments" HeaderText="Number of Assignments" />
                        <asp:BoundField DataField="NumberOfMCQs" HeaderText="Number of MCQs" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="Button2" runat="server" Text="Delete" CommandArgument='<%#Eval("SubCourseID") %>' CommandName="Delete" CssClass="btn btn-danger btn-sm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
</asp:Content>
