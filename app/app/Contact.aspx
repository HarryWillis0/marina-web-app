<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="app.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h2><%: Title %>.</h2>--%>
   
    <h2>Contact Information</h2> <br /><br />

    <div class="row">
        <div class="col-md-6">
            <address>Inland Lake Marina<br />
                Box 123 <br />
                Inland Lake, Arizona <br />
                86038 <br /><br />
            </address>
            <p><strong>Office Phone:</strong>928-450-2234<br />
                <strong>Leasing Phone:</strong>928-450-2235</br>
                <strong>Fax:</strong>928-450-2236
            </p>
        </div>
        <div class="col-md-6">
            <p><strong>Manager: </strong>Glenn Cooke <br />
                <strong>Slip Manager:</strong> Kimberley Carson<br />
                <strong>Contact Email:</strong> info@inlandmarina.com
            </p>
        </div>

    </div>
    
   
</asp:Content>
