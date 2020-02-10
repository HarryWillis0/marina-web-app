using MarinaData;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace app
{
    /// <summary>
    /// Page to allow user to select a dock and view all slips that are available. Selecting a slip will 
    /// display all leases currently on the slip. User will also be able to add a lease to the slip.
    /// </summary>
    /// @author - Chi 
    public partial class LeaseSlip : System.Web.UI.Page
    {
        /// <summary>
        /// When page loads, check if user is logged in. Redirect to login page if user is not.
        /// </summary>
        /// <returns>Void</returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Register");
            }
            else
            {
                DisplayLeases();
            }
        }

        /// <summary>
        /// Display all the leases for current user.
        /// </summary>
        /// <returns>Void</returns>
        private void DisplayLeases()
        {
            int count = 0; // Leases count
            string leaseCardString = ""; // HTML string for each lease
            string userName = User.Identity.GetUserName(); // UserName or email to login with

            List<Lease> userLeases = LeaseDB.GetUserLease(userName); // Get all leases for current user

            // Display leases
            foreach (Lease lease in userLeases)
            {
                count++;
                leaseCardString += "<div class='card col-sm-3 col-md-3'>" +
                                        "<div class='card-body'>" +
                                            "<h5 class='card-title'>Lease " + count + "</h5>" +
                                            "<p class='card-text'>" +
                                                "<p>Slip ID: " + lease.SlipID + "</p>" +
                                                "<p>Leased by: " + lease.FirstName + " " + lease.LastName + "</p>" +
                                                "<p>Location: " + lease.Dock + "</p>" +
                                            "</p>" +
                                            "<a href = '#' class='btn btn-primary'>Manage</a>  " +
                                            "<a href = '#' class='btn btn-danger'>Remove</a>" +
                                        "</div>" +
                                    "</div>";
                
            }
            myLeases.InnerHtml = leaseCardString;
        }

        /// <summary>
        /// This reset paging to first page if new dock is selected
        /// </summary>
        /// <returns>Void</returns>
        protected void ddlDocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSlips.PageIndex = 0;
        }

        /// <summary>
        /// Set selected row to a distinct color when selected and remove if another row is selected.
        /// </summary>
        /// <returns>Void</returns>
        protected void gvSlips_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Check if Viewstate is null or not
            if (ViewState["PreviousRowIndex"] != null)
            {
                //Get the Previously selected rowindex
                var previousRowIndex = (int)ViewState["PreviousRowIndex"];
                //Get the previously selected row
                GridViewRow PreviousRow = gvSlips.Rows[previousRowIndex];
                //Assign back color to previously selected row
                PreviousRow.BackColor = System.Drawing.Color.White;
            }
            //Get the Command Name
            // string currentCommand = e.CommandName;
            //Get the Selected RowIndex
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            //Get the GridViewRow from Current Row Index
            GridViewRow row = gvSlips.Rows[currentRowIndex];
            //Assign the Back Color to Yellow
            //Change this color as per your need
            row.BackColor = System.Drawing.Color.Gray;
            //Assign the index as PreviousRowIndex
            ViewState["PreviousRowIndex"] = currentRowIndex;
        }

        /// <summary>
        /// Allow clicking on row of GridView to select item.
        /// </summary>
        /// <returns>Void</returns>
        protected void gvSlips_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Attach click event to each row in Gridview
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvSlips, "Select$" + e.Row.RowIndex);
            }
        }

        /// <summary>
        /// Shows all current leases on user's selected slip from GridView.
        /// </summary>
        /// <returns>Void</returns>
        protected void gvSlips_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvSlips.SelectedRow; // Row selected.
            int slipID = Convert.ToInt32(row.Cells[0].Text); // SlipID in first column selected

            lblLeaseInfo.Text = "Lease available for Slip ID " + slipID.ToString();
            btnLease.Visible = true;
            
        }

        /// <summary>
        /// Allows user to add a lease to slected slip.
        /// </summary>
        /// <returns>Void</returns>
        protected void btnLease_Click(object sender, EventArgs e)
        {
            string userName; // User's login name.
            int userID;      // User's ID.
            int slipID;      // Slip's ID.
            GridViewRow row = gvSlips.SelectedRow; // Row selected.
            slipID = Convert.ToInt32(row.Cells[0].Text); // SlipID in first column selected.

            userName = User.Identity.GetUserName(); // Get current user's login name.
            userID = CustomerDB.GetCustomerIDbyUserName(userName); // Get User's ID.

            // Insert new lease
            try
            {
                

                LeaseDB.InsertLease(userID, slipID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while adding new Lease.", ex.Message);
            }

            DisplayLeases();
        }

        
    }
}