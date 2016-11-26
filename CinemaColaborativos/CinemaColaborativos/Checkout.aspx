<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CinemaColaborativos.Checkout" EnableEventValidation="false" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
                <div class="main-contact">
                    <h3 class="head">Haz tu pago</h3>
                    
                    <div class="contact-form">
                        <form>
                            <div class="col-md-6 contact-left">
                                <div class="form-group">

                                    <input runat="server" type="text" aria-describedby="basic-addon2" placeholder="Correo electrónico" style="width:315px;" id="Correo" class="form-control" required />
                                    <br />
                                    <input runat="server" type="text" placeholder="Nombre de la tarjeta" style="width:315px;" id="NombreTarjeta" class="form-control" required />
                                    <br />
                                    <input runat="server" type="number" placeholder="Numero de la tarjeta" style="width:315px;" id="NumeroTarjeta" class="form-control" required />
                                    <br />
                                    <input runat="server" type="number" placeholder="Código de seguridad de la tarjeta" style="width:315px;" id="CodigoSeguridad" class="form-control" required />
                                    <br />
                                    <input runat="server" type="number" placeholder="Teléfono" class="form-control" id="Telefono" style="width:315px;" required />
                                </div>
                                <span id="lblExpiryDate" class="">Fecha de vencimiento:</span>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 contact-left">
                                            <select class="form-control" runat="server" name="dropCardExpiryMonth" id="dropCardExpiryMonth" tabindex="1" style="width:70px;" required>
                                                <option selected="selected" value="">Día</option>
                                                <option value="01">01</option>
                                                <option value="02">02</option>
                                                <option value="03">03</option>
                                                <option value="04">04</option>
                                                <option value="05">05</option>
                                                <option value="06">06</option>
                                                <option value="07">07</option>
                                                <option value="08">08</option>
                                                <option value="09">09</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                            </select>
                                        </div>
                                       
                                        <div class="col-md-2 contact-right">
                                            <select class="form-control" runat="server" name="dropCardExpiryYear" id="dropCardExpiryYear" tabindex="1" style="width:100px;" required>
                                                <option selected="selected" value="">Año</option>
                                                <option value="2016">2016</option>
                                                <option value="2017">2017</option>
                                                <option value="2018">2018</option>
                                                <option value="2019">2019</option>
                                                <option value="2020">2020</option>
                                                <option value="2021">2021</option>
                                                <option value="2022">2022</option>
                                                <option value="2023">2023</option>
                                                <option value="2024">2024</option>
                                                <option value="2025">2025</option>
                                                <option value="2026">2026</option>
                                                <option value="2027">2027</option>
                                                <option value="2028">2028</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                    <div class="form-group">
                                        <select class="form-control" runat="server" name="dropCardType" id="dropCardType" tabindex="1" style="width:315px;" onchange="SaveCardTypeSelected();" required>
                                            <option value="">Método de pago</option>
                                            <option value="Visa">Visa</option>
                                            <option value="Mastercard">Mastercard</option>
                                            <option value="Amex">American Express</option>
                                            <option value="Discover">Discover</option>
                                        </select>
                                    </div>                               
                                        <asp:Button ID="Button1" runat="server" Text="Pagar" onclick="Button1_Click" BorderColor="LightBlue" CssClass="button" />
                                    </div>
                                        <div class="col-md-6 contact-right">
                                            <img src="images/creditcards.jpg" style="width:100%;"/>
                                        </div>
                                      <div class="clearfix"></div>
                                    <label runat="server" id="error" color="red"> </label>
                                <div>
                                           
                                </div>

                                </div>
                            
                                    <div class="col-md-6 contact-right">
  

                                    </div>
                                    <div class="clearfix"></div>
</form>
                    </div>
                </div>

    <script src="https://apis.google.com/js/platform.js" async defer></script>
</asp:Content>
