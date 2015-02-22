<%@ Page Title="" Language="C#" MasterPageFile="~/RCM1.Master" AutoEventWireup="true" CodeBehind="CreateFiscalYear.aspx.cs" Inherits="RCM_NEW.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
                
        <div class="row">
        
        <div class="col-lg-3 cl-md-6"></div>
        
            <div class="col-lg-6 cl-md-6">
            <h1 class="page-header">Create Fiscal Year</h1>
            </div>
        </div>
        <div class="row">
        <div class="col-lg-3 cl-md-12"></div>
        <div class="col-lg-6 col-md-12">

        <ul class="nav nav-pills nav-wizard">
         
        <li style="width: 21%" class="active"><div></div><a href="#" data-toggle="tab">Year</a><div class="nav-arrow"></div></li>
        <li style="width: 19%"><div class="nav-wedge"></div><a href="AddCHG.aspx">CHG</a><div class="nav-arrow"></div></li>
   
        <li style="width: 19%"><div class="nav-wedge"></div><a href="AddAssessmentRates.aspx" >Assessments</a><div class="nav-arrow"></div></li>
        <li style="width: 19%"><div class="nav-wedge"></div><a href="AddExpendutersBudget.aspx" >Expenditures</a><div class="nav-arrow"></div></li>
        <li style="width: 21%"><div class="nav-wedge"></div><a href="#" >Allocated Costs</a></li>  
            
        </ul>
        </div>
        </div>
        <%--<div class="row">--%>
        
        <asp:Panel ID="SelectYearPanel" runat="server" Visible="True" class="row" style="margin-top: 20px" >
        <div class="col-lg-3 col-md-12"></div>
        <div class="col-lg-6 col-md-12">
        <div class="panel panel-default" >
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="TuitionBreakdownByLevelLabel" runat="server" Text ="Year" />
        </div>
        <div class="panel-body">
            <div class="col-lg-8 cl-md-12">        
            <asp:DropDownList class="form-control" ID="YearDropDownList" runat="server" style=" width: 100%; margin-top: 10px">
                <asp:ListItem Value="Select">Select</asp:ListItem>
            </asp:DropDownList>
            </div>
               
               
        <div class="col-lg-4 col-md-12" >
             <asp:Button class="btn btn-default" ID="CancelButton" runat="server" style="width: 100%; margin-bottom: 10px; margin-top: 10px; float: right" Text="Cancel" />
            <asp:Button class="btn btn-primary" ID="SubmitYearButton" runat="server" OnClick="SubmitYearButton_Click" style="width: 100%; margin-bottom: 10px; float: right" BackColor="#9E1B34" Text="Submit" />
           
        </div>
        </div>
        </div></div>
        </asp:Panel>
       </div>
           
        
        
        
        <%--</div>--%>
        <%--</div>--%>



</asp:Content>
