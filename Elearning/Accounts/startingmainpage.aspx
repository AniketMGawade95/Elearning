<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StartingPage.Master" AutoEventWireup="true" CodeBehind="startingmainpage.aspx.cs" Inherits="Elearning.Accounts.startingmainpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Header Start -->
<div class="jumbotron jumbotron-fluid position-relative overlay-bottom" style="margin-bottom: 90px;">
    <div class="container text-center my-5 py-5">
        <h1 class="text-white mt-4 mb-4">Learn From Home</h1>
        <h1 class="text-white display-1 mb-5">Education Courses</h1>
        <div class="mx-auto mb-5" style="width: 100%; max-width: 600px;">
            <div class="input-group">
                <div class="input-group-prepend">
                    <button class="btn btn-outline-light bg-white text-body px-4 dropdown-toggle" type="button" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">Courses</button>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="#">Courses 1</a>
                        <a class="dropdown-item" href="#">Courses 2</a>
                        <a class="dropdown-item" href="#">Courses 3</a>
                    </div>
                </div>
                <input type="text" class="form-control border-light" style="padding: 30px 25px;" placeholder="Keyword">
                <div class="input-group-append">
                    <button class="btn btn-secondary px-4 px-lg-5">Search</button>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Header End -->


<!-- About Start -->
<div class="container-fluid py-5">
    <div class="container py-5">
        <div class="row">
            <div class="col-lg-5 mb-5 mb-lg-0" style="min-height: 500px;">
                <div class="position-relative h-100">
                    <img class="position-absolute w-100 h-100" src="img/about.jpg" style="object-fit: cover;">
                </div>
            </div>
            <div class="col-lg-7">
                <div class="section-title position-relative mb-4">
                    <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">About Us</h6>
                    <h1 class="display-4">First Choice For Online Education Anywhere</h1>
                </div>
                <p>Tempor erat elitr at rebum at at clita aliquyam consetetur. Diam dolor diam ipsum et, tempor voluptua sit consetetur sit. Aliquyam diam amet diam et eos sadipscing labore. Clita erat ipsum et lorem et sit, sed stet no labore lorem sit. Sanctus clita duo justo et tempor consetetur takimata eirmod, dolores takimata consetetur invidunt magna dolores aliquyam dolores dolore. Amet erat amet et magna</p>
                <div class="row pt-3 mx-0">
                    <div class="col-3 px-0">
                        <div class="bg-success text-center p-4">
                            <h1 class="text-white" data-toggle="counter-up">123</h1>
                            <h6 class="text-uppercase text-white">Available<span class="d-block">Subjects</span></h6>
                        </div>
                    </div>
                    <div class="col-3 px-0">
                        <div class="bg-primary text-center p-4">
                            <h1 class="text-white" data-toggle="counter-up">1234</h1>
                            <h6 class="text-uppercase text-white">Online<span class="d-block">Courses</span></h6>
                        </div>
                    </div>
                    <div class="col-3 px-0">
                        <div class="bg-secondary text-center p-4">
                            <h1 class="text-white" data-toggle="counter-up">123</h1>
                            <h6 class="text-uppercase text-white">Skilled<span class="d-block">Instructors</span></h6>
                        </div>
                    </div>
                    <div class="col-3 px-0">
                        <div class="bg-warning text-center p-4">
                            <h1 class="text-white" data-toggle="counter-up">1234</h1>
                            <h6 class="text-uppercase text-white">Happy<span class="d-block">Students</span></h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- About End -->


<!-- Feature Start -->
<div class="container-fluid bg-image" style="margin: 90px 0;">
    <div class="container">
        <div class="row">
            <div class="col-lg-7 my-5 pt-5 pb-lg-5">
                <div class="section-title position-relative mb-4">
                    <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Why Choose Us?</h6>
                    <h1 class="display-4">Why You Should Start Learning with Us?</h1>
                </div>
                <p class="mb-4 pb-2">Aliquyam accusam clita nonumy ipsum sit sea clita ipsum clita, ipsum dolores amet voluptua duo dolores et sit ipsum rebum, sadipscing et erat eirmod diam kasd labore clita est. Diam sanctus gubergren sit rebum clita amet.</p>
                <div class="d-flex mb-3">
                    <div class="btn-icon bg-primary mr-4">
                        <i class="fa fa-2x fa-graduation-cap text-white"></i>
                    </div>
                    <div class="mt-n1">
                        <h4>Skilled Instructors</h4>
                        <p>Labore rebum duo est Sit dolore eos sit tempor eos stet, vero vero clita magna kasd no nonumy et eos dolor magna ipsum.</p>
                    </div>
                </div>
                <div class="d-flex mb-3">
                    <div class="btn-icon bg-secondary mr-4">
                        <i class="fa fa-2x fa-certificate text-white"></i>
                    </div>
                    <div class="mt-n1">
                        <h4>International Certificate</h4>
                        <p>Labore rebum duo est Sit dolore eos sit tempor eos stet, vero vero clita magna kasd no nonumy et eos dolor magna ipsum.</p>
                    </div>
                </div>
                <div class="d-flex">
                    <div class="btn-icon bg-warning mr-4">
                        <i class="fa fa-2x fa-book-reader text-white"></i>
                    </div>
                    <div class="mt-n1">
                        <h4>Online Classes</h4>
                        <p class="m-0">Labore rebum duo est Sit dolore eos sit tempor eos stet, vero vero clita magna kasd no nonumy et eos dolor magna ipsum.</p>
                    </div>
                </div>
            </div>
            <div class="col-lg-5" style="min-height: 500px;">
                <div class="position-relative h-100">
                    <img class="position-absolute w-100 h-100" src="img/feature.jpg" style="object-fit: cover;">
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Feature Start -->


<!-- Courses Start -->





    <div class="container-fluid px-0 py-5">
    <div class="row mx-0 justify-content-center pt-5">
        <div class="col-lg-6">
            <div class="section-title text-center position-relative mb-4">
                <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Our Courses</h6>
                <h1 class="display-4">Checkout New Releases Of Our Courses</h1>
            </div>
        </div>
    </div>

    <div class="owl-carousel courses-carousel">
        <asp:Repeater ID="rptCourses" runat="server" OnItemCommand="rptCourses_ItemCommand">
    <ItemTemplate>
        <div class="courses-item position-relative">
            <img class="img-fluid" src='<%# ResolveUrl(Eval("Picture").ToString()) %>' alt="">
            <div class="courses-text">
                <h4 class="text-center text-white px-3"><%# Eval("SubCourseName") %></h4>
                <div class="border-top w-100 mt-3">
                    <div class="d-flex justify-content-between p-4">
                        <span class="text-white"><i class="fa fa-rupee-sign mr-2"></i><%# Eval("Price") %></span>
                        <span class="text-white"><i class="fa fa-star mr-2"></i><%# Eval("Rating") != DBNull.Value ? Eval("Rating") : "New" %> <small></small></span>
                    </div>
                </div>
                <div class="w-100 bg-white text-center p-4">
                    <asp:LinkButton ID="lnkView" runat="server" CommandName="View" CommandArgument='<%# Eval("SubCourseID") %>' CssClass="btn btn-primary">Course Detail</asp:LinkButton>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

    </div>
</div>






<!-- Courses End -->





    

   <asp:ScriptManager ID="ScriptManager1" runat="server" />

<asp:UpdatePanel ID="upSpin" runat="server">
    <ContentTemplate>

        <div class="container my-5">
            <div class="card shadow-lg p-4">
                <div class="text-center">
                    <h2 class="mb-3 text-primary">🎁 Spin the Wheel - Get Your Discount!</h2>
                    <p class="text-muted">Enter your email and click "Spin" to win a discount. One-time use only!</p>
                </div>

                <asp:Panel ID="pnlSpin" runat="server" DefaultButton="btnSpin" CssClass="text-center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/spin.gif" Width="120px" Height="120px" CssClass="mb-3" />
                    <div class="mb-3">
                        <asp:TextBox ID="TextBox1" runat="server" Placeholder="Enter your email" CssClass="form-control w-50 mx-auto" TextMode="Email"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSpin" runat="server" Text="Spin" OnClick="btnSpin_Click" CssClass="btn btn-warning px-4" />
                </asp:Panel>

                <asp:Image ID="imgSpinWheel" runat="server" ImageUrl="~/Images/spin.gif" Visible="false" CssClass="d-block mx-auto my-3" Width="100" Height="100" />

                <asp:Panel ID="pnlCaptcha" runat="server" Visible="false" CssClass="text-center mt-4">
                    <asp:Label ID="lblCaptcha" runat="server" CssClass="badge bg-success fs-4 p-2 mb-2 d-block text-black" />
                    <asp:Label ID="Label1" runat="server" Text="Copy and use this Captcha on the Cart page after adding your courses. This is a one-time-use discount!" CssClass="form-text text-black" />
                </asp:Panel>

                <div class="mt-3 text-center">
                    <asp:Label ID="lblResult" runat="server" CssClass="text-success fw-bold fs-5" />
                </div>
            </div>
        </div>

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSpin" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>











<!-- Team Start -->
<div class="container-fluid py-5">
    <div class="container py-5">
        <div class="section-title text-center position-relative mb-5">
            <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Instructors</h6>
            <h1 class="display-4">Meet Our Instructors</h1>
        </div>
        <div class="owl-carousel team-carousel position-relative" style="padding: 0 30px;">
            <div class="team-item">
                <img class="img-fluid w-100" src="img/team-1.jpg" alt="">
                <div class="bg-light text-center p-4">
                    <h5 class="mb-3">Instructor Name</h5>
                    <p class="mb-2">Web Design & Development</p>
                    <div class="d-flex justify-content-center">
                        <a class="mx-1 p-1" href="#"><i class="fab fa-twitter"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-facebook-f"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-linkedin-in"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-instagram"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-youtube"></i></a>
                    </div>
                </div>
            </div>
            <div class="team-item">
                <img class="img-fluid w-100" src="img/team-2.jpg" alt="">
                <div class="bg-light text-center p-4">
                    <h5 class="mb-3">Instructor Name</h5>
                    <p class="mb-2">Web Design & Development</p>
                    <div class="d-flex justify-content-center">
                        <a class="mx-1 p-1" href="#"><i class="fab fa-twitter"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-facebook-f"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-linkedin-in"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-instagram"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-youtube"></i></a>
                    </div>
                </div>
            </div>
            <div class="team-item">
                <img class="img-fluid w-100" src="img/team-3.jpg" alt="">
                <div class="bg-light text-center p-4">
                    <h5 class="mb-3">Instructor Name</h5>
                    <p class="mb-2">Web Design & Development</p>
                    <div class="d-flex justify-content-center">
                        <a class="mx-1 p-1" href="#"><i class="fab fa-twitter"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-facebook-f"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-linkedin-in"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-instagram"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-youtube"></i></a>
                    </div>
                </div>
            </div>
            <div class="team-item">
                <img class="img-fluid w-100" src="img/team-4.jpg" alt="">
                <div class="bg-light text-center p-4">
                    <h5 class="mb-3">Instructor Name</h5>
                    <p class="mb-2">Web Design & Development</p>
                    <div class="d-flex justify-content-center">
                        <a class="mx-1 p-1" href="#"><i class="fab fa-twitter"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-facebook-f"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-linkedin-in"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-instagram"></i></a>
                        <a class="mx-1 p-1" href="#"><i class="fab fa-youtube"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Team End -->


<!-- Testimonial Start -->
<div class="container-fluid bg-image py-5" style="margin: 90px 0;">
    <div class="container py-5">
        <div class="row align-items-center">
            <div class="col-lg-5 mb-5 mb-lg-0">
                <div class="section-title position-relative mb-4">
                    <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Testimonial</h6>
                    <h1 class="display-4">What Say Our Students</h1>
                </div>
                <p class="m-0">Dolor est dolores et nonumy sit labore dolores est sed rebum amet, justo duo ipsum sanctus dolore magna rebum sit et. Diam lorem ea sea at. Nonumy et at at sed justo est nonumy tempor. Vero sea ea eirmod, elitr ea amet diam ipsum at amet. Erat sed stet eos ipsum diam</p>
            </div>
            <div class="col-lg-7">
                <div class="owl-carousel testimonial-carousel">
                    <div class="bg-white p-5">
                        <i class="fa fa-3x fa-quote-left text-primary mb-4"></i>
                        <p>Sed et elitr ipsum labore dolor diam, ipsum duo vero sed sit est est ipsum eos clita est ipsum. Est nonumy tempor at kasd. Sed at dolor duo ut dolor, et justo erat dolor magna sed stet amet elitr duo lorem</p>
                        <div class="d-flex flex-shrink-0 align-items-center mt-4">
                            <img class="img-fluid mr-4" src="img/testimonial-2.jpg" alt="">
                            <div>
                                <h5>Student Name</h5>
                                <span>Web Design</span>
                            </div>
                        </div>
                    </div>
                    <div class="bg-white p-5">
                        <i class="fa fa-3x fa-quote-left text-primary mb-4"></i>
                        <p>Sed et elitr ipsum labore dolor diam, ipsum duo vero sed sit est est ipsum eos clita est ipsum. Est nonumy tempor at kasd. Sed at dolor duo ut dolor, et justo erat dolor magna sed stet amet elitr duo lorem</p>
                        <div class="d-flex flex-shrink-0 align-items-center mt-4">
                            <img class="img-fluid mr-4" src="img/testimonial-1.jpg" alt="">
                            <div>
                                <h5>Student Name</h5>
                                <span>Web Design</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Testimonial Start -->


<!-- Contact Start -->
<div class="container-fluid py-5">
    <div class="container py-5">
        <div class="row align-items-center">
            <div class="col-lg-5 mb-5 mb-lg-0">
                <div class="bg-light d-flex flex-column justify-content-center px-5" style="height: 450px;">
                    <div class="d-flex align-items-center mb-5">
                        <div class="btn-icon bg-primary mr-4">
                            <i class="fa fa-2x fa-map-marker-alt text-white"></i>
                        </div>
                        <div class="mt-n1">
                            <h4>Our Location</h4>
                            <p class="m-0">Thane, India</p>
                        </div>
                    </div>
                    <div class="d-flex align-items-center mb-5">
                        <div class="btn-icon bg-secondary mr-4">
                            <i class="fa fa-2x fa-phone-alt text-white"></i>
                        </div>
                        <div class="mt-n1">
                            <h4>Call Us</h4>
                            <p class="m-0">+012 345 6789</p>
                        </div>
                    </div>
                    <div class="d-flex align-items-center">
                        <div class="btn-icon bg-warning mr-4">
                            <i class="fa fa-2x fa-envelope text-white"></i>
                        </div>
                        <div class="mt-n1">
                            <h4>Email Us</h4>
                            <p class="m-0">info@example.com</p>
                        </div>
                    </div>
                </div>
            </div>




            <%--<div class="col-lg-7">
                <div class="section-title position-relative mb-4">
                    <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Need Help?</h6>
                    <h1 class="display-4">Send Us A Message</h1>
                </div>
                <div class="contact-form">
                    <div>
                        <div class="row">
                            <div class="col-6 form-group">
                                <input type="text" class="form-control border-top-0 border-right-0 border-left-0 p-0" placeholder="Your Name" required="required">
                            </div>
                            <div class="col-6 form-group">
                                <input type="email" class="form-control border-top-0 border-right-0 border-left-0 p-0" placeholder="Your Email" required="required">
                            </div>
                        </div>
                        <div class="form-group">
                            <input type="text" class="form-control border-top-0 border-right-0 border-left-0 p-0" placeholder="Subject" required="required">
                        </div>
                        <div class="form-group">
                            <textarea class="form-control border-top-0 border-right-0 border-left-0 p-0" rows="5" placeholder="Message" required="required"></textarea>
                        </div>
                        <div>
                            <button class="btn btn-primary py-3 px-5" type="submit">Send Message</button>
                        </div>
                    </div>
                </div>
            </div>--%>

            <div class="col-lg-7">
    <div class="section-title position-relative mb-4">
        <h6 class="d-inline-block position-relative text-secondary text-uppercase pb-2">Need Help?</h6>
        <h1 class="display-4">Send Us A Message</h1>
    </div>
    <div class="contact-form">
        <asp:Literal ID="litMessage" runat="server" EnableViewState="false" />
        <asp:Panel ID="pnlForm" runat="server">
            <div class="row">
                <div class="col-6 form-group">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control border-top-0 border-right-0 border-left-0 p-0" 
                        Placeholder="Your Name"  />
                </div>
                <div class="col-6 form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control border-top-0 border-right-0 border-left-0 p-0" 
                        Placeholder="Your Email" TextMode="Email"  />
                </div>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control border-top-0 border-right-0 border-left-0 p-0" 
                    Placeholder="Subject"  />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control border-top-0 border-right-0 border-left-0 p-0"
                    Rows="5" TextMode="MultiLine" Placeholder="Message"  />
            </div>
            <div>
                <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="btn btn-primary py-3 px-5" OnClick="btnSend_Click" />
            </div>
        </asp:Panel>
    </div>
</div>



        </div>
    </div>
</div>
<!-- Contact End -->


</asp:Content>
