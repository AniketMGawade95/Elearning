<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Elearning.Accounts.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
    <meta name="description" content="Smarthr - Bootstrap Admin Template">
    <meta name="keywords" content="admin, estimates, bootstrap, business, html5, responsive, Projects">
    <meta name="author" content="Dreams technologies - Bootstrap Admin Template">
    <meta name="robots" content="noindex, nofollow">
    <title>Elearning</title>


    <script src="https://accounts.google.com/gsi/client" async defer></script>

    <script>
    function handleCredentialResponse(response) {
        // Decode JWT to extract user info
        const data = parseJwt(response.credential);
        const name = encodeURIComponent(data.name);
        const email = encodeURIComponent(data.email);
        const picture = encodeURIComponent(data.picture);

        // Redirect to your server-side registration handler
        window.location.href = `GoogleRegisterHandler.aspx?name=${name}&email=${email}&picture=${picture}`;
    }

    // Helper to decode JWT
    function parseJwt(token) {
        const base64Url = token.split('.')[1];
        const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        const jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
        return JSON.parse(jsonPayload);
    }
    </script>




    <!-- Apple Touch Icon -->
    <link rel="apple-touch-icon" sizes="180x180" href="assets/img/apple-touch-icon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">

    <!-- Feather CSS -->
    <link rel="stylesheet" href="assets/plugins/icons/feather/feather.css">

    <!-- Tabler Icon CSS -->
    <link rel="stylesheet" href="assets/plugins/tabler-icons/tabler-icons.css">

    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="assets/plugins/fontawesome/css/fontawesome.min.css">
    <link rel="stylesheet" href="assets/plugins/fontawesome/css/all.min.css">

    <!-- Main CSS -->
    <link rel="stylesheet" href="assets/css/style.css">
</head>
<body class="bg-white">
    <div id="global-loader" style="display: none;">
        <div class="page-loader"></div>
    </div>
    <form id="form1" runat="server">
        <div>
            <!-- Main Wrapper -->
            <div class="main-wrapper">

                <div class="container-fuild">
                    <div class="w-100 overflow-hidden position-relative flex-wrap d-block vh-100">
                        <div class="row">
                            <div class="col-lg-5">
                                <div class="d-lg-flex align-items-center justify-content-center d-none flex-wrap vh-100 bg-transparent">
                                    <div>
                                        <img src="assets/img/bg/20944356.jpg" alt="Img">
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-7 col-md-12 col-sm-12">
                                <div class="row justify-content-center align-items-center vh-100 overflow-auto flex-wrap ">
                                    <div class="col-md-7 mx-auto vh-100">
                                        <form action="login-2.html" class="vh-100">
                                            <div class="vh-100 d-flex flex-column justify-content-between p-4 pb-0">
                                                <div class=" mx-auto mb-5 text-center">
                                                    <%--<img src="assets/img/logo.svg" class="img-fluid" alt="Logo">--%>
                                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Accounts/startingmainpage.aspx"><h1 class="m-0 text-uppercase text-info"><i class="fa fa-book-reader mr-3"></i>Elearning</h1></asp:HyperLink>
                                                </div>











                                                <div class="">
                                                    <div class="text-center mb-3">
                                                        <h2 class="mb-2 text-info">Registration</h2>
                                                        <p class="mb-0">Please enter your details to sign up</p>
                                                    </div>

                                                    <div class="mb-3">
                                                        <label class="form-label">Profile Picture</label>
                                                        <div class="input-group">
                                                            <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
                                                            <span class="input-group-text text-info"><i class="ti ti-camera"></i></span>
                                                        </div>
                                                    </div>

                                                    <div class="mb-3">
                                                        <label class="form-label">Name</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control border-end-0" />
                                                            <span class="input-group-text border-start-0 text-info"><i class="ti ti-user"></i></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                                            ControlToValidate="txtName"
                                                            ErrorMessage="Name is required"
                                                            ForeColor="Red"
                                                            Display="Dynamic"
                                                            ValidationGroup="RegisterGroup" />
                                                    </div>

                                                    <div class="mb-3">
                                                        <label class="form-label">Email Address</label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control border-end-0" TextMode="Email" />
                                                            <span class="input-group-text border-start-0 text-info"><i class="ti ti-mail"></i></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                                            ControlToValidate="txtEmail"
                                                            ErrorMessage="Email is required"
                                                            ForeColor="Red"
                                                            Display="Dynamic"
                                                            ValidationGroup="RegisterGroup" />
                                                    </div>

                                                    <div class="mb-3">
                                                        <label class="form-label">Password</label>
                                                        <div class="pass-group">
                                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="pass-input form-control" TextMode="Password" />
                                                            <span class="ti toggle-password ti-eye-off text-info"></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                                            ControlToValidate="txtPassword"
                                                            ErrorMessage="Password is required"
                                                            ForeColor="Red"
                                                            Display="Dynamic"
                                                            ValidationGroup="RegisterGroup" />
                                                    </div>

                                                    <div class="mb-3">
                                                        <label class="form-label">Confirm Password</label>
                                                        <div class="pass-group">
                                                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="pass-inputs form-control" TextMode="Password" />
                                                            <span class="ti toggle-passwords ti-eye-off text-info"></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server"
                                                            ControlToValidate="txtConfirmPassword"
                                                            ErrorMessage="Confirm Password is required"
                                                            ForeColor="Red"
                                                            Display="Dynamic"
                                                            ValidationGroup="RegisterGroup" />
                                                        <asp:CompareValidator ID="cvPasswords" runat="server"
                                                            ControlToCompare="txtPassword"
                                                            ControlToValidate="txtConfirmPassword"
                                                            ErrorMessage="Passwords do not match"
                                                            ForeColor="Red"
                                                            Display="Dynamic"
                                                            ValidationGroup="RegisterGroup" />
                                                    </div>

                                                    <div class="d-flex align-items-center justify-content-between mb-3">
                                                        <div class="d-flex align-items-center">
                                                            <div class="form-check form-check-md mb-0">
                                                                <input class="form-check-input form-checked-info" id="remember_me" type="checkbox" />
                                                                <label for="remember_me" class="form-check-label text-dark mt-0">Agree to <span class="text-info">Terms & Privacy</span></label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="mb-3">
                                                        <asp:Button ID="btnRegister" runat="server"
                                                            CssClass="btn btn-info w-100"
                                                            Text="Register"
                                                            OnClick="btnRegister_Click"
                                                            ValidationGroup="RegisterGroup" />
                                                    </div>

                                                    <div class="text-center">
                                                        <h6 class="fw-normal text-dark mb-0">Already have an account?
			<asp:HyperLink ID="HyperLink1" CssClass="hover-a link-info" runat="server" NavigateUrl="~/Accounts/Login.aspx">Login</asp:HyperLink>
                                                        </h6>
                                                    </div>

                                                    <div class="login-or">
                                                        <span class="span-or">Or</span>
                                                    </div>




                                                    <div class="mt-2">
                                                        <div class="d-flex align-items-center justify-content-center flex-wrap">
                                                            <div class="text-center me-2 flex-fill">
                                                                <a href="javascript:void(0);"
                                                                    class="br-10 p-2 btn btn-info d-flex align-items-center justify-content-center">
                                                                    <img class="img-fluid m-1" src="assets/img/icons/facebook-logo.svg" alt="Facebook">
                                                                </a>
                                                            </div>





                                                            <div class="text-center me-2 flex-fill">
                                                               <%-- <a href="javascript:void(0);"
                                                                    class="br-10 p-2 btn btn-outline-light border d-flex align-items-center justify-content-center">
                                                                    <img class="img-fluid m-1" src="assets/img/icons/google-logo.svg" alt="Facebook">
                                                                </a>--%>


                                                                <%--<div id="g_id_onload"
                                                                    data-client_id="744761461029-5tc3t758jh7vdj3qqgs31iq8gvo4p1rm.apps.googleusercontent.com"
                                                                    data-context="signup"
                                                                    data-ux_mode="popup"
                                                                    data-callback="handleCredentialResponse"
                                                                    data-auto_prompt="false"
                                                                    >
                                                                </div>--%>
                                                                
                                                                <div id="g_id_onload"
                                                                    data-client_id="744761461029-5tc3t758jh7vdj3qqgs31iq8gvo4p1rm.apps.googleusercontent.com"
                                                                    data-context="signin"
                                                                    data-ux_mode="popup"
                                                                    data-callback="handleCredentialResponse"
                                                                    data-auto_prompt="false"
                                                                    >
                                                                </div>

                                                                <div class="g_id_signin br-10 p-2 btn btn-outline-light border d-flex align-items-center justify-content-center"
                                                                    data-type="icon"
                                                                    data-size="large"
                                                                    data-theme="outline"
                                                                    data-text="signin_with"
                                                                    data-shape="rectangular"
                                                                    data-logo_alignment="left">
                                                                </div>




                                                            </div>




                                                            <div class="text-center flex-fill">
                                                                <a href="javascript:void(0);"
                                                                    class="bg-dark br-10 p-2 btn btn-dark d-flex align-items-center justify-content-center">
                                                                    <img class="img-fluid m-1" src="assets/img/icons/apple-logo.svg" alt="Apple">
                                                                </a>


                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>








                                                <div class="mt-5 pb-4 text-center">
                                                    <p class="mb-0 text-gray-9">Copyright &copy; 2025 -
                                                        <text class="text-info">Elearning</text></p>
                                                </div>
                                            </div>
                                        </form>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /Main Wrapper -->

            <!-- jQuery -->
            <script src="assets/js/jquery-3.7.1.min.js"></script>

            <!-- Bootstrap Core JS -->
            <script src="assets/js/bootstrap.bundle.min.js"></script>

            <!-- Feather Icon JS -->
            <script src="assets/js/feather.min.js"></script>

            <!-- Custom JS -->
            <script src="assets/js/script.js"></script>
        </div>
    </form>
</body>


<script src="https://accounts.google.com/gsi/client" async defer></script>


</html>
