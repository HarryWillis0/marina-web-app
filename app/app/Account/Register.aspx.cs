﻿using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using app.Models;
using MarinaData;
using System.Windows.Forms;

namespace app.Account
{
    public partial class Register : Page
    {
        private Customer newCustomer;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // get new customer info
            newCustomer = new Customer();
            newCustomer.FirstName = FirstName.Text;
            newCustomer.LastName = LastName.Text;
            newCustomer.Phone = PhoneNumber.Text;
            newCustomer.City = City.Text;
            newCustomer.Email = Email.Text;
            newCustomer.Password = Password.Text;

            // need to check database to see if customer has already registered to avoid duplicates
            bool exists = CustomerDB.FindCustomerByName(newCustomer.FirstName, newCustomer.LastName);

            if (!exists) // customer not in marina db, add customer to marina db and add a user to web app
                RegisterNewCustomer();
            else // customer is in marina database
            {
                // see if we have login information
                bool loginExists = AppDB.UserExists(Email.Text);
                if (loginExists)
                    ErrorMessage.Text = "You've already registered with us, please login.";
                else // customer is in marina database but does not have account on web app
                    AddLoginInfo();
            }
        }

        /// <summary>
        /// Add a new customer to marina db
        /// </summary>
        private void RegisterNewCustomer()
        {
            // try add new customer to marina db
            try
            {
                CustomerDB.Insert(newCustomer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while adding new customer.", ex.GetType().ToString());
            }

            AddLoginInfo();
        }

        /// <summary>
        /// Add new login information - this code is auto-generated by ASP.NET user accounts
        /// </summary>
        private void AddLoginInfo()
        {

            // auto generated - for App_Data
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser()
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Phone = PhoneNumber.Text,
                City = City.Text
            };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);

                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}