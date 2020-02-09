using MarinaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app
{
    /// <summary>
    /// Page to allow user to select a dock and view all slips that are available. Selecting a slip will 
    /// display all leases currently on the slip. User will also be able to add a lease to the slip.
    /// </summary>
    /// @author - Chi 
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Lease> currentLeases = null; // Current number of leases from selected slip


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
            GridViewRow row = gvSlips.SelectedRow;
            int slipID = Convert.ToInt32(row.Cells[0].Text);

            
            currentLeases = LeaseDB.GetLease(slipID);

            if(currentLeases.Count < 1)
            {
                lblLeaseInfo.Text = "No leases found for Slip ID " + slipID.ToString();
            }
            else
            {
                lblLeaseInfo.Text = "Current leases on Slip ID " + slipID.ToString() + ":";
                gvLeases.DataSource = currentLeases;
                gvLeases.DataBind();
            }
            
        }

        /// <summary>
        /// Allows user to add a lease to slected slip
        /// </summary>
        /// <returns>Void</returns>
        protected void btnLease_Click(object sender, EventArgs e)
        {
            // TODO: Add lease
        }
    }
}