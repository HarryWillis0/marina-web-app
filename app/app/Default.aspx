<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="aboutus" class="jumbotron">
        <%--<h1>ASP.NET</h1>--%>
        <p class="lead">Welcome to Inland Marina Limited</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div id="WhoWeAre" class="jumbotron jumbotron-fluid">
  <div class="container">
    <h1 id="heading" class="display-4">Who we are</h1>
    <p class="welcomeMessage">Welcome to Inland Marina located on the south shore Inland Lake, just a small commute from major
centers in the south west.
Inland Marina was established in the 1967 shortly after Inland Lake was created as a result of the South
West damn. From its humble beginnings, it has grown to be the largest marina on Inland Lake. Due to
the warm climate that extends year-round, Inland Lake has become a popular tourist destination in the
south west. Boat owners from California, Arizona, Nevada, and Utah are attracted to the area. Inland
Marina has 90 slips ranging in size from 16 to 32 feet in length. Dock services include electrical and
fresh water.</p>
  </div>
</div>

    <div><p>.</p></div>



   <%-- <div class="row">

    </div>--%>


 <div class="row">
       <%-- <div class="col-sm-3 col-md-3">
           <div class="card" style="width:400px">
            <img class="card-img-top" src="Images/ship.jpg" alt="Card image">
           <div class="card-body">
            <h4 class="card-title">John Doe</h4>
            <p class="card-text">Some example text.</p>
            <a href="#" class="btn btn-primary">See Profile</a>
           </div>
        </div>
     </div>
    --%>
  <div class="col-sm-3 col-md-3">
       <div class="card" style="width: 18rem;">
               <img class="card-img-top" src="Images/boatt.jpg" alt="Card image cap">
          <div class="card-body">
               <h5 class="card-title"><strong>Investors Relations</strong></h5>
               <p id="postcard" class="card-text">2019 Q4 Report</p>
              <%-- <a href="#" class="btn btn-primary">Go somewhere</a>--%>
          </div>
      </div>
  </div>

     <div class="col-sm-3 col-md-3">
       <div class="card" style="width: 18rem;">
               <img class="card-img-top" src="Images/ship.jpg" alt="Card image cap">
          <div class="card-body">
               <h5 class="card-title">&nbsp;&nbsp;&nbsp;<strong>Sustainability</strong> </h5>
               <p id="postcards" class="card-text"> 2019 Report on Sustainability</p>
               <%--<a href="#" class="btn btn-primary"> Go somewhere </a>--%>
          </div>
      </div>
  </div>


     <div class="col-sm-3 col-md-3">
       <div class="card" style="width: 18rem;">
               <img class="card-img-top" src="Images/boatt1.jpg" alt="Card image cap">
          <div class="card-body">
               <h5 class="card-title"><strong>Community Investment</strong></h5>
               <p id="funding" class="card-text">Funding priorities <br /> Apply for funding here</p>
               <%--<a href="#" class="btn btn-primary">Go somewhere</a>--%>
          </div>
      </div>
  </div>
        

     <div class="col-sm-3 col-md-3">
       <div class="card" style="width: 18rem;">
               <img class="card-img-top" src="Images/boatt6.jpg" alt="Card image cap">
          <div class="card-body">
               <h5 class="card-title"><strong>Careers & Jobs</strong></h5>
               <p id="team" class="card-text">Why choose us? <br />Meet our team</p>
              <%-- <a href="#" class="btn btn-primary">Go somewhere</a>--%>
          </div>
      </div>
  </div>
        
        
        
      <%--<div class="col-sm-3 col-md-3">
         <div class="card" style="width:100px">
            <img class="card-img-top" src="Images/boatt.jpg" alt="Card image">
           <div class="card-body">
            <h4 class="card-title">John Doe</h4>
            <p class="card-text">Some example text.</p>
            <a href="#" class="btn btn-primary">See Profile</a>
           </div>
         </div>
       </div>--%>
         
        
      <%--<div class="col-sm-3 col-md-3">
         <div class="card" style="width:100px">
            <img class="card-img-top" src="Images/boatt1.jpg" alt="Card image">
           <div  class="card-body">
            <h4 class="card-title">John Doe</h4>
            <p class="card-text">Some example text.</p>
            <a href="#" class="btn btn-primary">See Profile</a>
           </div>
         </div>
      </div>
         --%>
        
       <%--<div class="col-sm-3 col-md-3">
         <div class="card" style="width:400px">
            <img class="card-img-top" src="Images/boatt2.jpg" alt="Card image">
           <div  class="card-body">
            <h4 class="card-title">John Doe</h4>
            <p class="card-text">Some example text.</p>
            <a href="#" class="btn btn-primary">See Profile</a>
           </div>
         </div>
       </div>--%>
 </div>




    <%--<div class="row">
        <div class="col-md-3">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>

</asp:Content>
