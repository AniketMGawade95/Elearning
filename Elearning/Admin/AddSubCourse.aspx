<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddSubCourse.aspx.cs" Inherits="Elearning.Admin.AddSubCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- Add Sub Course Section -->
        <div class="card border-info shadow-sm mb-4">
            <div class="card-header bg-info text-white text-center">
                <h4>Add Sub Course</h4>
            </div>
            <div class="card-body">
                <div class="mb-3 row">
                    <label class="col-sm-3 col-form-label text-end fw-bold">Select Master Course:</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" />
                    </div>
                </div>

                <div class="mb-3 row">
                    <label class="col-sm-3 col-form-label text-end fw-bold">Sub Course Name:</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="mb-3 row">
                    <label class="col-sm-3 col-form-label text-end fw-bold">Price:</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" CssClass="form-control" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^\d+$"
                            ErrorMessage="Enter Numbers Only!" ForeColor="Red" ControlToValidate="TextBox2" CssClass="form-text text-danger" />
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2"
                            ErrorMessage="Price should be 0 or greater than 0" ForeColor="Red" MaximumValue="1000000"
                            MinimumValue="0" Type="Currency" CssClass="form-text text-danger" />
                    </div>
                </div>

                <div class="mb-3 row">
                    <label class="col-sm-3 col-form-label text-end fw-bold">Upload Image:</label>
                    <div class="col-sm-6">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="row">
                    <div class="offset-sm-3 col-sm-6 text-center">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" CssClass="btn btn-primary w-50" />
                    </div>
                </div>
            </div>
        </div>

        <!-- View Sub Courses Section -->
        <div class="card border-primary shadow-sm">
            <div class="card-header bg-primary text-white text-center">
                <h4>View Sub Courses</h4>
            </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server"
                    CssClass="table table-bordered table-hover table-striped"
                    HeaderStyle-CssClass="table-info"
                    AllowPaging="True"
                    AllowSorting="True"
                    AutoGenerateColumns="False"
                    DataKeyNames="SubCourseID"
                    DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="SubCourseID" HeaderText="SubCourse ID" ReadOnly="True" />
                        <asp:BoundField DataField="MasterCourseID" HeaderText="Master Course ID" />
                        <asp:BoundField DataField="SubCourseName" HeaderText="Sub Course Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Rating" HeaderText="Rating" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        <asp:BoundField DataField="Picture" HeaderText="Picture" />
                        
                        <asp:TemplateField HeaderText="Picture">
                            <ItemTemplate>
                                <asp:Image ID="imgSubCourse" runat="server" ImageUrl='<%# Eval("Picture") %>' Width="60px" Height="60px" CssClass="img-thumbnail" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ShowSelectButton="True"
                            ButtonType="Button" ControlStyle-CssClass="btn btn-sm btn-outline-primary mx-1" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:con %>"
        SelectCommand="SELECT * FROM [SubCourses]"
        InsertCommand="INSERT INTO [SubCourses] ([MasterCourseID], [SubCourseName], [Price], [Rating], [Duration], [Picture], [CreatedAt]) VALUES (@MasterCourseID, @SubCourseName, @Price, @Rating, @Duration, @Picture, @CreatedAt)"
        UpdateCommand="UPDATE [SubCourses] SET [MasterCourseID] = @MasterCourseID, [SubCourseName] = @SubCourseName, [Price] = @Price, [Rating] = @Rating, [Duration] = @Duration, [Picture] = @Picture, [CreatedAt] = @CreatedAt WHERE [SubCourseID] = @SubCourseID"
        DeleteCommand="DELETE FROM [SubCourses] WHERE [SubCourseID] = @SubCourseID">
        <DeleteParameters>
            <asp:Parameter Name="SubCourseID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="MasterCourseID" Type="Int32" />
            <asp:Parameter Name="SubCourseName" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="Rating" Type="Decimal" />
            <asp:Parameter Name="Duration" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="CreatedAt" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="MasterCourseID" Type="Int32" />
            <asp:Parameter Name="SubCourseName" Type="String" />
            <asp:Parameter Name="Price" Type="Decimal" />
            <asp:Parameter Name="Rating" Type="Decimal" />
            <asp:Parameter Name="Duration" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="CreatedAt" Type="DateTime" />
            <asp:Parameter Name="SubCourseID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
