



<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddMasterCourse.aspx.cs" Inherits="Elearning.Admin.AddMasterCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Include Bootstrap if not already in your MasterPage -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card border-info shadow-sm">
            <div class="card-header bg-info text-white text-center">
                <h4>Add Master Course</h4>
            </div>
            <div class="card-body">
                <div class="mb-3 row">
                    <label for="TextBox1" class="col-sm-3 col-form-label text-end fw-bold">Course Name:</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="mb-3 row">
                    <label for="FileUpload1" class="col-sm-3 col-form-label text-end fw-bold">Upload Image:</label>
                    <div class="col-sm-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="row">
                    <div class="offset-sm-3 col-sm-6 text-center">
                        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" CssClass="btn btn-primary w-50" />
                    </div>
                </div>
            </div>
        </div>

        <div class="mt-5 card border-primary shadow-sm">
            <div class="card-header bg-primary text-white text-center">
                <h4>View Master Courses</h4>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server"
                    CssClass="table table-bordered table-hover table-striped"
                    HeaderStyle-CssClass="table-info"
                    AllowPaging="True"
                    AllowSorting="True"
                    AutoGenerateColumns="False"
                    DataKeyNames="MasterCourseID"
                    DataSourceID="SqlDataSource1"
                    PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="MasterCourseID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="MasterCourseID" />
                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName" />
                        <asp:BoundField DataField="Picture" HeaderText="Picture" SortExpression="Picture" />
                        <asp:TemplateField HeaderText="Picture">
    <ItemTemplate>
        
    <asp:Image ID="imgCourse" runat="server" ImageUrl='<%# Eval("Picture") %>' Width="60px" Height="60px" />


    </ItemTemplate>
</asp:TemplateField>

                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" SortExpression="CreatedAt" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True"
                            ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-outline-primary mx-1" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:con %>" 
        DeleteCommand="DELETE FROM [MasterCourses] WHERE [MasterCourseID] = @MasterCourseID" 
        InsertCommand="INSERT INTO [MasterCourses] ([CourseName], [Picture], [CreatedAt]) VALUES (@CourseName, @Picture, @CreatedAt)" 
        SelectCommand="SELECT * FROM [MasterCourses]" 
        UpdateCommand="UPDATE [MasterCourses] SET [CourseName] = @CourseName, [Picture] = @Picture, [CreatedAt] = @CreatedAt WHERE [MasterCourseID] = @MasterCourseID">
        
        <DeleteParameters>
            <asp:Parameter Name="MasterCourseID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CourseName" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="CreatedAt" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CourseName" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="CreatedAt" Type="DateTime" />
            <asp:Parameter Name="MasterCourseID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
