<%@ Page Title="" Language="C#" MasterPageFile="~/Cinema.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="CinemaColaborativos.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
                <div class="main-contact">
                    <h3 class="head">Haz tu pago</h3>
                    
                    <div class="contact-form">
                        <form>
                            <div class="col-md-6 contact-left">
                                <div class="form-group">

                                    <input type="text" aria-describedby="basic-addon2" placeholder="Correo electrónico" style="width:80%;" class="form-control" required />
                                    <br />
                                    <input type="text" placeholder="Nombre de la tarjeta" style="width:80%;" class="form-control" required />
                                    <br />
                                    <input type="text" placeholder="Numero de la tarjeta" style="width:80%;" class="form-control" required />
                                    <br />
                                    <input type="password" placeholder="Código de seguridad de la tarjeta" style="width:80%;" class="form-control" required />
                                    <br />
                                    <input type="text" placeholder="Teléfono" class="form-control" style="width:80%;" required />
                                </div>
                                <span id="lblExpiryDate" class="">Fecha de vencimiento:</span>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 contact-left">
                                            <select class="form-control" name="dropCardExpiryMonth" id="dropCardExpiryMonth" tabindex="1" style="width:100%;">
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
                                            <select class="form-control" name="dropCardExpiryYear" tabindex="1" style="width:100%;">
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
                                        <select class="form-control" name="dropCardType" id="dropCardType" tabindex="1" style="width:80%;" onchange="SaveCardTypeSelected();">
                                            <option value="">Método de pago</option>
                                            <option value="Visa">Visa</option>
                                            <option value="Mastercard">Mastercard</option>
                                            <option value="Amex">American Express</option>
                                            <option value="Discover">Discover</option>
                                        </select>
                                    </div>
                                    <input type="submit" class="btn-primary" value="Pagar" />
                                </div>
                                    <div class="col-md-6 contact-right">
                                        <img src="images/creditcards.jpg" style="width:100%;"/>
                                    </div>
                                    <div class="clearfix"></div>
</form>
                    </div>
                </div>

    <script src="https://apis.google.com/js/platform.js" async defer></script>
</asp:Content>
