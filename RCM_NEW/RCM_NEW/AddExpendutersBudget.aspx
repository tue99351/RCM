﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RCM1.Master" AutoEventWireup="true" CodeBehind="AddExpendutersBudget.aspx.cs" Inherits="RCM_NEW.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
                
        <div class="row">
        
        <div class="col-lg-3 cl-md-6"></div>
        
            <div class="col-lg-6 cl-md-6">
            <h1 style="margin-bottom: 10px" class="page-header">Create Fiscal Year</h1>
            </div>
        </div>
        <div class="row">
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">

            

            <ul class="nav nav-pills nav-wizard">
        <li style="width: 21%" ><div></div><a href="CreateFiscalYear.aspx">Year</a><div class="nav-arrow"></div></li>
        <li style="width: 19%" ><div class="nav-wedge"></div><a href="#" data-toggle="tab">CHG</a><div class="nav-arrow"></div></li>
        <li style="width: 19%"><div class="nav-wedge"></div><a href="AddAssessmentRates.aspx" >Assessments</a><div class="nav-arrow"></div></li>
        <li style="width: 19%"class="active"><div class="nav-wedge"></div><a href="#" >Expenditures</a><div class="nav-arrow"></div></li>
        <li style="width: 21%"><div class="nav-wedge"></div><a href="#" >Allocated Costs</a></li>
    </ul>
        
        
        
        
        </div>
        </div>
        <div class="row">
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">

        <ul class="nav nav-tabs">
        <li id="InstractionalCompensationLink" runat="server" role="presentation" class="active" ><asp:LinkButton ID="InstractionalCompensationLinkButton"  OnClick="InstractionalCompensationButton_click" runat="server">Instractional Compensation Expenses</asp:LinkButton></li>
        <li id="NonInstractionalCompensationLink" runat="server" role="presentation"><asp:LinkButton ID="NonInstractionalCompensationLinkButton"  OnClick="NonInstractionalCompensationLinkButton_click" runat="server">Non-Instractional Compensation Expenses</asp:LinkButton></li>
         <li id="NonCompensationLink" runat="server" role="presentation"><asp:LinkButton ID="NonCompensationLinkButton"  OnClick="NonCompensationLinkButton_click" runat="server">Non-Compensation Expenses</asp:LinkButton></li>
        </ul>
              
        </div>
        </div>

      <asp:Panel ID="InstractionalCompensationPanel" runat="server" Visible="True" class="row" style="margin-top: 20px" >
        
        <div class="col-lg-3 col-md-3 col-sm-12"></div>
        <div class="col-lg-6 col-md-6 col-sm-12">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="InstractionalCompensationLabel" runat="server" Text ="Instractional Compensation Expenses" />
        </div>
        <div class="panel-body">
       <asp:GridView ID="InstractionalCompensationGridView" runat="server" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%; margin-top: 10px;" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="expenseType" HeaderText="Expense Type" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="25%" />
                </asp:BoundField>
                
                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="25%" HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="Budget">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle  CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fringe Benefit Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="White" CssClass="header_border_input" ForeColor="Black" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
        </div>
        </div>
        </div>
        </asp:Panel>    
    
        <asp:Panel ID="NonInstractionalCompensationPanel" runat="server" Visible="False" class="row" style="margin-top: 20px" >
        
        <div class="col-lg-3 col-md-3 col-sm-12"></div>
        <div class="col-lg-6 col-md-6 col-sm-12">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="NonInstractionalCompensationLabel" runat="server" Text ="Non-Instractional Compensation Expenses" />
        </div>
        <div class="panel-body">
       <asp:GridView ID="NonInstractionalCompensationGridView" runat="server" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%; margin-top: 10px;" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="expenseType" HeaderText="Expense Type" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="25%" />
                </asp:BoundField>
                
                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="25%" HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="Budget">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle  CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fringe Benefit Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="White" CssClass="header_border_input" ForeColor="Black" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
        </div>
        </div>
        </div>
        </asp:Panel>    

        <asp:Panel ID="NonCompensationPanel" runat="server" Visible="False" class="row" style="margin-top: 20px" >
        
        <div class="col-lg-3 col-md-3 col-sm-12"></div>
        <div class="col-lg-6 col-md-6 col-sm-12">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="NonCompensationLabel" runat="server" Text ="Non-Compensation Expenses" />
        </div>
        <div class="panel-body">
       <asp:GridView ID="NonCompensationGridView" runat="server" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%; margin-top: 10px;" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="expenseType" HeaderText="Expense Type" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="30%" />
                </asp:BoundField>
                
                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="30%" HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="Budget">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle  CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                
                
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="White" CssClass="header_border_input" ForeColor="Black" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
        </div>
        </div>
        </div>
        </asp:Panel>    

        <div class="row">
        
        <div class="col-lg-3 col-md-12 col-xs-12"></div>
        <div class="col-lg-6 col-md-12 col-xs-12">
                       
        <div class="col-lg-8 col-md-12 col-xs-8" >
                    <%--<span >
                    <input  type="file" 
                    style="visibility:hidden; width: 1px; " 
                    id='${multipartFilePath}' name='${multipartFilePath}'  
                    onchange="$(this).parent().find('span').html($(this).val().replace('C:\\fakepath\\', ''))"  /> <!-- Chrome security returns 'C:\fakepath\'  -->
                    <input style="margin-top:25px; border-color: #ccc" class="btn btn-default" type="button" value="Upload Cognos Report" onclick="$(this).parent().find('input[type=file]').click();"/> <!-- on button click fire the file click event -->
                    &nbsp;
                    <span  class="badge badge-important" ></span>
                    </span>--%>
                    </div>
        
        <div class="col-lg-4 col-md-12 col-xs-4" >
             <asp:Button class="btn btn-default" ID="CancelButton" runat="server" style="width: 100%; margin-bottom: 10px; margin-top: 0px; float: right" Text="Cancel" />
            <asp:Button class="btn btn-primary" ID="SubmitYearButton" runat="server" OnClick="SubmitYearButton_Click" style="width: 100%; margin-bottom: 10px; margin-top: 0px; float: right" BackColor="#9E1B34" Text="Submit" />
           
        </div>
          </div>
            </div>
            </div>

</asp:Content>
