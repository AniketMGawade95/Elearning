<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="AdminChat.aspx.cs" Inherits="Elearning.Admin.AdminChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>

<style>
    .user-item:hover {
        background-color: #e2e6ea;
    }

    .selected-user {
        background-color: #cce5ff !important;
        font-weight: bold;
        border-left: 4px solid #007bff;
    }

    .chat-container {
        height: 600px;
        overflow-y: auto;
        background-color: #f5f5f5;
        padding: 15px;
        border: 1px solid #ccc;
        border-radius: 8px;
    }

    .msg {
        padding: 10px 15px;
        border-radius: 20px;
        margin-bottom: 10px;
        max-width: 75%;
        display: inline-block;
        clear: both;
        position: relative;
    }

    .msg-left {
        background-color: #ffffff;
        float: left;
    }

    .msg-right {
        background-color: #dcf8c6;
        float: right;
    }

    .msg-time {
        font-size: 11px;
        color: gray;
        margin-top: 4px;
        display: block;
    }

    .badge {
        background-color: red;
        color: white;
        padding: 3px 7px;
        border-radius: 50%;
        font-size: 12px;
    }

    .input-area {
        margin-top: 15px;
    }
</style>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

<div class="container-fluid">
    <div class="row vh-100">
        <!-- User List -->
        <div class="col-3 border-end bg-light p-3 overflow-auto">
            <h5 class="mb-3">Users</h5>
            <asp:Repeater ID="rptUsers" runat="server" OnItemCommand="UserSelected_Command">
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                                    CommandName="SelectUser"
                                    CommandArgument='<%# Eval("UserID") %>'
                                    CssClass='<%# GetUserCss(Eval("UserID").ToString()) + " list-group-item list-group-item-action user-item d-flex justify-content-between align-items-center mb-1 rounded" %>'>
                        <%# Eval("Name") %>
                        <%# Convert.ToInt32(Eval("UnreadCount")) > 0 ? "<span class='badge'>" + Eval("UnreadCount") + "</span>" : "" %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- Chat Area -->
        <div class="col-9 p-3 d-flex flex-column">
            <!-- Messages -->
            <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="chat-container mb-3" id="chatBox" runat="server">
                        <asp:Repeater ID="rptMessages" runat="server">
                            <ItemTemplate>
                                <div class='<%# GetMessageCss(Eval("SenderID")) + " msg" %>'>
                                    <%# Eval("MessageText") %>
                                    <span class="msg-time"><%# Eval("MessageTime", "{0:hh:mm tt}") %></span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>

            <!-- Timer -->
            <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" />

            <!-- Input -->
            <asp:UpdatePanel ID="UpdatePanelInput" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="input-area d-flex">
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control me-2" placeholder="Type your message..." />
                        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="btnSend_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>

<script type="text/javascript">
    function scrollToBottom() {
        var chatBox = document.getElementById('<%= chatBox.ClientID %>');
        if (chatBox) {
            chatBox.scrollTop = chatBox.scrollHeight;
        }
    }

    Sys.Application.add_load(function () {
        scrollToBottom();
    });
</script>
</asp:Content>
