<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/User.Master" AutoEventWireup="true" CodeBehind="UserChat.aspx.cs" Inherits="Elearning.User.UserChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

<style>
    body {
        font-family: Arial;
    }

    .chat-toggle-btn {
        position: fixed;
        bottom: 30px;
        right: 30px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 50%;
        width: 60px;
        height: 60px;
        font-size: 30px;
        cursor: pointer;
        z-index: 9999;
    }

    .chat-popup {
        display: none;
        position: fixed;
        bottom: 100px;
        right: 30px;
        width: 400px;
        background-color: white;
        box-shadow: 0 0 10px rgba(0,0,0,0.3);
        z-index: 9998;
    }

    .chat-header {
        background-color: #007bff;
        color: white;
        padding: 10px;
        font-weight: bold;
        border-top-left-radius: .3rem;
        border-top-right-radius: .3rem;
    }

    .chat-container {
        height: 300px;
        overflow-y: auto;
        background-color: #f5f5f5;
        padding: 10px;
    }

    .msg {
        padding: 8px 12px;
        border-radius: 15px;
        margin: 5px 0;
        max-width: 70%;
        display: inline-block;
        clear: both;
    }

    .msg-left {
        background-color: #ffffff;
        float: left;
    }

    .msg-right {
        background-color: #dcf8c6;
        float: right;
        text-align: right;
    }

    .msg-time {
        font-size: 10px;
        color: gray;
        display: block;
        margin-top: 2px;
    }

    .input-area {
        padding: 10px;
        border-top: 1px solid #ccc;
    }
</style>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" />

<!-- Floating Button -->
<button type="button" class="chat-toggle-btn shadow" onclick="toggleChat()">💬</button>

<!-- Chat Popup Panel -->
<div id="chatPopup" class="chat-popup rounded border">
    <div class="chat-header d-flex justify-content-between align-items-center">
        <span>Chat</span>
        <button type="button" class="btn-close btn-close-white" onclick="toggleChat()"></button>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="p-2">

                <%--<asp:DropDownList ID="ddlUsers" CssClass="form-select mb-2" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" />--%>


                <div class="chat-container rounded" id="chatBox" runat="server">
                    <asp:Repeater ID="rptMessages" runat="server">
                        <ItemTemplate>
                            <div class='<%# GetMessageCss(Eval("SenderID")) %> msg'>
                                <%# Eval("MessageText") %>
                                <span class="msg-time"><%# Eval("MessageTime", "{0:hh:mm tt}") %></span>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" />

    <asp:UpdatePanel ID="UpdatePanelInput" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="input-area">
                <div class="input-group">
                    <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="Type your message..."></asp:TextBox>
                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-success" OnClick="btnSend_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

<script type="text/javascript">
    function toggleChat() {
        var box = document.getElementById("chatPopup");
        box.style.display = (box.style.display === "none" || box.style.display === "") ? "block" : "none";

        if (box.style.display === "block") {
            setTimeout(function () {
                scrollToBottom();
                focusOnMessageBox();
            }, 100);
        }
    }

    function scrollToBottom() {
        var chatBox = document.getElementById('<%= chatBox.ClientID %>');
        chatBox.scrollTop = chatBox.scrollHeight;
    }

    function focusOnMessageBox() {
        var txt = document.getElementById('<%= txtMessage.ClientID %>');
        if (txt) {
            txt.focus();
        }
    }

    Sys.Application.add_load(function () {
        scrollToBottom();
        focusOnMessageBox();
    });
</script>

</asp:Content>
