<%@ Page Title="" Language="C#" MasterPageFile="~/RCM1.Master" AutoEventWireup="true" CodeBehind="AddCHG.aspx.cs" Inherits="RCM_NEW.WebForm4" %>
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
        <li style="width: 19%" class="active"><div class="nav-wedge"></div><a href="#" data-toggle="tab">CHG</a><div class="nav-arrow"></div></li>
        <li style="width: 19%"><div class="nav-wedge"></div><a href="AddAssessmentRates.aspx" >Assessments</a><div class="nav-arrow"></div></li>
        <li style="width: 19%"><div class="nav-wedge"></div><a href="AddExpendutersBudget.aspx" >Expenditures</a><div class="nav-arrow"></div></li>
        <li style="width: 21%"><div class="nav-wedge"></div><a href="#" >Allocated Costs</a></li>
    </ul>
        
        
        
        
        </div>
        </div>
        <div class="row">
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">

        <ul class="nav nav-tabs">
        <li id="GrossCHGLink" runat="server" role="presentation" class="active" ><asp:LinkButton ID="GrossCHGLinkButton"  OnClick="GrossCHGLinkButton_click" runat="server">Gross CHG</asp:LinkButton></li>
        <li id="ExportedCHGLink" runat="server" role="presentation"><asp:LinkButton ID="ExportedCHGLinkButton"  OnClick="ExportedCHGLinkButton_click" runat="server">Exported CHG</asp:LinkButton></li>
         <li id="DifferentialRevenueLink" runat="server" role="presentation"><asp:LinkButton ID="DifferentialRevenueLinkButton"  OnClick="DifferentialRevenueLinkButton_click" runat="server">Differential Revenue</asp:LinkButton></li>
        </ul>
              
        </div>
        </div>

      <asp:Panel ID="GrossCHGPanel" runat="server" Visible="True" class="row" style="margin-top: 20px" >
        
        <div class="col-lg-3 col-md-3 col-sm-12"></div>
        <div class="col-lg-6 col-md-6 col-sm-12">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="GrossCHGLabel" runat="server" Text ="Gross CHG / Rate" />
        </div>
        <div class="panel-body">
       <asp:GridView ID="GrossCHGGridView" runat="server" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%; margin-top: 10px;" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="17%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Undergraduate CHG">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle  CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Undrgraduate Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox4" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Graduate CHG">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox5" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Graduate Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox6" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle ></ItemStyle>
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
     <asp:Panel ID="ExportedCHGPanel" runat="server" Visible="False" class="row" style="margin-top: 20px" >
        
        <div class="col-lg-3 col-md-3 col-sm-12"></div>
        <div class="col-lg-6 col-md-6 col-sm-12">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="Label1" runat="server" Text ="Exported CHG / Rate" />
        </div>
        <div class="panel-body">
       <asp:GridView ID="ExportedCHGGridView" runat="server" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%; margin-top: 10px;" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="17%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Undergraduate CHG">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox10" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle  CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Undrgraduate Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox7" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Graduate CHG">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox8" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Graduate Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox9" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle ></ItemStyle>
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
        
         <asp:Panel ID="DifferentialRevenuePanel" runat="server" Visible="False" class="row" style="margin-top: 20px" >
        
        <div class="col-lg-3 col-md-3 col-sm-12"></div>
        <div class="col-lg-6 col-md-6 col-sm-12">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="DifferentialRevenueLabel" runat="server" Text ="Differenttial Revenue CHG / Number of students / Rate" />
        </div>
        <div class="panel-body">
       <asp:GridView ID="DifferentialRevenueGridView" runat="server" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%; margin-top: 5px;" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="differentialRevenue" HeaderText="Differential Revenue" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="17%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Undergraduate CHG">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox11" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle  CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Undrgraduate Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox12" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Num of Graduate  Students">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox13" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Graduate Rate">

                    <ItemTemplate>
                        <asp:TextBox ID="TextBox14" Width="90%" style="margin-top: 6px" runat="server"></asp:TextBox>
                    </ItemTemplate>

                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle ></ItemStyle>
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
                    <span >
                    <input  type="file" 
                    style="visibility:hidden; width: 1px; " 
                    id='${multipartFilePath}' name='${multipartFilePath}'  
                    onchange="$(this).parent().find('span').html($(this).val().replace('C:\\fakepath\\', ''))"  /> <!-- Chrome security returns 'C:\fakepath\'  -->
                    <input style="margin-top:25px; border-color: #ccc" class="btn btn-default" type="button" value="Upload Cognos Report" onclick="$(this).parent().find('input[type=file]').click();"/> <!-- on button click fire the file click event -->
                    &nbsp;
                    <span  class="badge badge-important" ></span>
                    </span>
                    </div>
        
        <div class="col-lg-4 col-md-12 col-xs-4" >
             <asp:Button class="btn btn-default" ID="Button1" runat="server" style="width: 100%; margin-bottom: 10px; margin-top: 0px; float: right" Text="Cancel" />
            <asp:Button class="btn btn-primary" ID="Button2" runat="server" OnClick="SubmitYearButton_Click" style="width: 100%; margin-bottom: 0px; margin-top: 0px; float: right" BackColor="#9E1B34" Text="Submit" />
           
        </div>
          </div>
            </div>
       
            </div>


</asp:Content>
