<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AddTopic.aspx.cs" Inherits="Elearning.Admin.AddTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">
    <div class="card border-primary">
        <div class="card-header bg-primary text-white text-center">
            <h4>Add Topics</h4>
        </div>
        <div class="card-body">
            <div class="mb-3">
                <label class="form-label fw-bold">Select Master Course</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label fw-bold">Select Sub Course</label>
                <asp:DropDownList ID="DropDownList2" CssClass="form-select" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label fw-bold">Enter Topic Name</label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label fw-bold">Add Video Link (Embed Code)</label>
                <%--<asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3" />--%>
                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="MultiLine" ValidateRequestMode="Disabled" Rows="3"></asp:TextBox>

            </div>
            <div class="mb-3">
                <label class="form-label fw-bold">Video Duration (Seconds)</label>
                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" />
            </div>
            <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-info w-100" OnClick="Button1_Click" />
        </div>
    </div>

    <div class="card mt-5 border-info">
        <div class="card-header bg-info text-white text-center">
            <h4>View Topics</h4>
        </div>
        <div class="card-body table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover table-striped"
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="TopicID" DataSourceID="SqlDataSource1">
                <Columns>
                    
                    <asp:BoundField DataField="TopicID" HeaderText="Topic ID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="SubCourseID" HeaderText="Sub Course ID" />
                    <asp:BoundField DataField="TopicName" HeaderText="Topic Name" />
                    <asp:BoundField DataField="VideoEmbedCode" HeaderText="Video Embed Code" />
                    <asp:BoundField DataField="CreatedAt" HeaderText="Created At" />
                    <asp:BoundField DataField="VideoDurationSeconds" HeaderText="Duration (Sec)" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>

<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ ConnectionStrings:con %>"
    DeleteCommand="DELETE FROM [Topics] WHERE [TopicID] = @TopicID"
    InsertCommand="INSERT INTO [Topics] ([SubCourseID], [TopicName], [VideoEmbedCode], [CreatedAt], [VideoDurationSeconds]) VALUES (@SubCourseID, @TopicName, @VideoEmbedCode, @CreatedAt, @VideoDurationSeconds)"
    SelectCommand="SELECT * FROM [Topics]"
    UpdateCommand="UPDATE [Topics] SET [SubCourseID] = @SubCourseID, [TopicName] = @TopicName, [VideoEmbedCode] = @VideoEmbedCode, [CreatedAt] = @CreatedAt, [VideoDurationSeconds] = @VideoDurationSeconds WHERE [TopicID] = @TopicID">
    <DeleteParameters>
        <asp:Parameter Name="TopicID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="SubCourseID" Type="Int32" />
        <asp:Parameter Name="TopicName" Type="String" />
        <asp:Parameter Name="VideoEmbedCode" Type="String" />
        <asp:Parameter Name="CreatedAt" Type="DateTime" />
        <asp:Parameter Name="VideoDurationSeconds" Type="Int32" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="SubCourseID" Type="Int32" />
        <asp:Parameter Name="TopicName" Type="String" />
        <asp:Parameter Name="VideoEmbedCode" Type="String" />
        <asp:Parameter Name="CreatedAt" Type="DateTime" />
        <asp:Parameter Name="VideoDurationSeconds" Type="Int32" />
        <asp:Parameter Name="TopicID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

</asp:Content>
