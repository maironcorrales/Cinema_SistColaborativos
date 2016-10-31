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
                     google
				  </div>
				  <div class="col-md-6 contact-right">
					 
				 </div>
				 <div class="clearfix"></div>
			 
	     </div>
		 <div class="contact_info">
	 </div>
</div>
        </div>
</asp:Content>
