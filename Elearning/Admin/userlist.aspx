<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="userlist.aspx.cs" Inherits="Elearning.Admin.userlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview th, .gridview td {
            text-align: center;
            vertical-align: middle;
        }

        .gridview th, .gridview td {
        text-align: center;
        vertical-align: middle;
        white-space: nowrap;
        max-width: 150px;
        overflow: hidden;
        text-overflow: ellipsis;
    }

    .gridview input[type="text"],
    .gridview select {
        width: 100%;
        max-width: 140px;
    }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card border-primary shadow-sm">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Registered User List</h4>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" 
                    CssClass="table table-bordered table-hover table-striped gridview"
                    HeaderStyle-CssClass="table-primary"
                    PageSize="5"
                    AllowPaging="True" AllowSorting="True" 
                    AutoGenerateColumns="False" 
                    DataKeyNames="UserID" 
                    DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                        <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                        <asp:BoundField DataField="ProfilePic" HeaderText="ProfilePic" SortExpression="ProfilePic" />




                       <%-- <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />--%>

                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
    <ItemTemplate>
        <%# Eval("Status") %>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("Status") %>' CssClass="form-control form-control-sm">
    <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
    <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
</asp:DropDownList>

    </EditItemTemplate>
</asp:TemplateField>





                        <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt" SortExpression="CreatedAt" />
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                </div>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:con %>" 
                    DeleteCommand="DELETE FROM [Users] WHERE [UserID] = @UserID" 
                    InsertCommand="INSERT INTO [Users] ([Name], [Email], [Password], [Role], [ProfilePic], [Status], [CreatedAt]) VALUES (@Name, @Email, @Password, @Role, @ProfilePic, @Status, @CreatedAt)" 
                    SelectCommand="SELECT * FROM [Users]" 
                    UpdateCommand="UPDATE [Users] SET [Name] = @Name, [Email] = @Email, [Password] = @Password, [Role] = @Role, [ProfilePic] = @ProfilePic, [Status] = @Status, [CreatedAt] = @CreatedAt WHERE [UserID] = @UserID">
                    <DeleteParameters>
                        <asp:Parameter Name="UserID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="Role" Type="String" />
                        <asp:Parameter Name="ProfilePic" Type="String" />
                        <asp:Parameter Name="Status" Type="String" />
                        <asp:Parameter Name="CreatedAt" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Email" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="Role" Type="String" />
                        <asp:Parameter Name="ProfilePic" Type="String" />
                        <asp:Parameter Name="Status" Type="String" />
                        <asp:Parameter Name="CreatedAt" Type="DateTime" />
                        <asp:Parameter Name="UserID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </div>
</asp:Content>
