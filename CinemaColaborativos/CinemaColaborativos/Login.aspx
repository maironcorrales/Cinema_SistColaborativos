<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CinemaColaborativos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact-content">
    <div class="main-contact">
		 <h3 class="head">Registrate o Accede Usando</h3>
		 <p>alguno de los siguientes servicios</p>
		 <div class="contact-form">
			
				 <div class="col-md-6 contact-left">
                     <!--<img src="images/facebookbtn.png"/>-->
                     <asp:HyperLink runat="server" ID="fbLogin">
                         <img src="images/facebookbtn.png" style="width:50%;height:50%;"/>
                     </asp:HyperLink>
                     
                     <br />
                     <a href="#" id="A1" onclick="OpenGoogleLoginPopup();" name="butrequest"> 
                         <img src="images/GoogleSignIn.png" style="width:48%;height:54%; padding-left:15px"/>
                     </a>
                         
				  </div>
				  <div class="col-md-6 contact-right">
					 
				 </div>
				 <div class="clearfix"></div>
			 
	     </div>
		 <div class="contact_info">
	 </div>
</div>
        </div>
    <script type="text/javascript">


        function OpenGoogleLoginPopup() {
            

            var url = "https://accounts.google.com/o/oauth2/auth?";
            url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
            url += "state=%2Fprofile&"
            url += "redirect_uri=<%=Return_url %>&"
            url += "response_type=token&"
            url += "client_id=<%=Client_ID %>";

            window.location = url;
        }


    </script>
</asp:Content>
