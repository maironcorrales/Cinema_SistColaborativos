﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Stripe;
using System.Configuration;
using System.Threading.Tasks;
using System.Reflection;

namespace CinemaColaborativos

{
    public partial class Checkout : System.Web.UI.Page
    {
        private string API_KEY = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //API_KEY = ConfigurationManager.AppSettings["StripeApiKey"];
            error.Visible = false;
           
           
        }

           protected void Button1_Click(object sender, EventArgs e)
            {

            try
            {
                StripeCustomer current = GetCustomer();
                // int? days = getaTraildays();
                //if (days != null)
                //{
                int chargetotal = 500;//Convert.ToInt32((3.33*Convert.ToInt32(days)*100));
                var mycharge = new StripeChargeCreateOptions();
                mycharge.Amount = chargetotal;
                mycharge.Currency = "USD";
                mycharge.CustomerId = current.Id;
                string key = "sk_test_5jzcBuYhyxAk08sB8mT7KL43";
                var chargeservice = new StripeChargeService(key);
                StripeCharge currentcharge = chargeservice.Create(mycharge);
                error.Visible = true;
                error.InnerText = "La transacción se realizo con éxito";

            }
            catch (StripeException ex)
            {
                error.Visible = true;
                error.InnerText = ex.Message;
            }
            catch
            {
                error.Visible = true;
                
                error.InnerText = "Error en la transacción";
            }
            //}
        }
            private StripeCustomer GetCustomer()
            {
            var mycust = new StripeCustomerCreateOptions();
            mycust.SourceCard = new SourceCard()
            {
                 Number = NumeroTarjeta.Value,
                 ExpirationYear = dropCardExpiryYear.Value,
                 ExpirationMonth = dropCardExpiryMonth.Value,
                 AddressCountry = "US",                // optional
                 AddressLine1 = "24 Beef Flank St",    // optional
                 AddressLine2 = "Apt 24",              // optional
                 AddressCity = "Biggie Smalls",        // optional
                 AddressState = "NC",                  // optional
                 AddressZip = "27617",                 // optional
                 Name = Correo.Value,               // optional
                 Cvc = CodigoSeguridad.Value,                          // optional
                /*Number = "4242424242424242",
                ExpirationYear = "2022",
                ExpirationMonth = "10",
                AddressCountry = "US",                // optional
                AddressLine1 = "24 Beef Flank St",    // optional
                AddressLine2 = "Apt 24",              // optional
                AddressCity = "Biggie Smalls",        // optional
                AddressState = "NC",                  // optional
                AddressZip = "27617",                 // optional
                Name = "hola",                        // optional
                Cvc = "123",                          // optional*/
   

            };
            //mycust.TrialEnd = getrialend();


            try
            {
                var customerservice = new StripeCustomerService("sk_test_5jzcBuYhyxAk08sB8mT7KL43");
                return customerservice.Create(mycust);

            }
            catch (StripeException ex)
            {
                error.Visible = true;
                error.InnerText = ex.Message;
                return null;
            }

        } 
        }

        
    }

