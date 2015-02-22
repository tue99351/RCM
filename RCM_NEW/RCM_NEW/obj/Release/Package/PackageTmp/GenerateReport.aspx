<%@ Page Title="" Language="C#" MasterPageFile="~/RCM1.Master" AutoEventWireup="true" CodeBehind="GenerateReport.aspx.cs" Inherits="RCM_NEW.WebForm1 " %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
                
        <div class="row" style="top: 5px">
        
        <div class="col-lg-3 cl-md-6"></div>
        
            <div class="col-lg-6 cl-md-6">
            <h1 class="page-header">RCM Report</h1>
            </div>
        </div>
        <div class="row">
        <div class="col-lg-3 cl-md-6"></div>
        
        <div class="col-lg-6 col-md-6">
        
            <div class="col-lg-6 cl-md-6">
            <asp:Label ID="FiscalYearLabel" runat="server" style="margin-bottom: 10px" Text="Fiscal Year" Font-Bold="True" Font-Size="Medium" ForeColor="#666666"></asp:Label>
        
            <asp:DropDownList class="form-control" ID="FinancialYearDropDownList" runat="server" style=" width: 100%; margin-top: 10px">
            <asp:ListItem Value="FY2015"></asp:ListItem>
            </asp:DropDownList>
            
        </div>
        
        <div class="col-lg-6 cl-md-6" >
            <asp:Button class="btn btn-primary" ID="GenerateReportButton" runat="server" OnClick="GenerateReportButton_Click" style="width: 60%; margin-top: 27px; float: right" BackColor="#9E1B34" Text="Generate Report" />
            <asp:Button class="btn btn-default" ID="ExportDataButton" runat="server" style="width: 60%; margin-bottom: 10px; margin-top: 10px; float: right" Text="Export Data" />
        </div>
    </div>
    </div>
    
    <asp:Panel ID="SummaryReportPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="RevenueSummaryLabel" runat="server" Text ="Revenue / Expense Summary" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="SummaryReportGridView" runat="server" OnRowCommand ="SummaryReportGridView_RowCommand"  OnDataBound = "SummaryReportGridView_OnDataBound" style=" margin-left: auto; margin-right:auto; position:relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:ButtonField DataTextField="RevenueExpense" HeaderText=" Revenue / Expense" CommandName="MyCommand">
                <ControlStyle ></ControlStyle>

                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle Width="70%" ForeColor="Black" />
            </asp:ButtonField>
            <asp:BoundField DataField="Amount" DataFormatString="{0:C}" HeaderText="Amount">
            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
    
        <asp:Panel ID="TuitionBreakdownByLevelPanel" Visible="False" runat="server" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
    
        <div class="panel panel-default" >
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="TuitionBreakdownByLevelLabel" runat="server" Text ="Revenue Breakdown by Level" />
        </div>
        <div class="panel-body">
        
        <asp:GridView ID="TuitionBreakdownByLevelGridView" runat="server" OnRowCommand ="TuitionBreakdownByLevelGridView_RowCommand" OnDataBound="TuitionBreakdownByLevelGridView_OnDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
             <asp:ButtonField DataTextField="TuitionRevenue"  HeaderText="Tuition Revenue" CommandName="MyCommand">
             <ControlStyle ></ControlStyle>
              <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            <ItemStyle Width="70%" ForeColor="Black" />
            </asp:ButtonField>
            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}">
            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
            </asp:BoundField>
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
       <asp:GridView ID="TuitionDifferentialRevenueGridView" runat="server" ShowFooter="true" OnRowCancelingEdit="TuitionDifferentialRevenueGridView_RowCancelingEdit" OnRowUpdating="TuitionDifferentialRevenueGridView_RowUpdating" OnRowEditing="TuitionDifferentialRevenueGridView_RowEditing" OnRowDataBound="TuitionDifferentialRevenueGridView_RowDataBound" Style="margin-top: 15px; margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="tuitionDifferentialRevenue" HeaderText="Tuition Differential Revenue" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="33%" />
                </asp:BoundField>
                <asp:BoundField DataField="numberStudentsCHG" HeaderText="Number of Students / CHG">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="24%" />
                </asp:BoundField>
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="17%" />
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" Width="17%" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                    <FooterStyle BackColor="White"></FooterStyle>
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
    
    <asp:Panel ID="GrossTuitionRevenueUndergradPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="GrossTuitionRevenueUndergradLabel" runat="server" Text ="Revenue / Expense Summary" />
        </div>
        <div class="panel-body">
        <asp:GridView ID="GrossTuitionRevenueUndergradGridView" runat="server" ShowFooter="true" OnRowCancelingEdit="GrossTuitionRevenueUndergradGridView_RowCancelingEdit" OnRowUpdating="GrossTuitionRevenueUndergradGridView_RowUpdating" OnRowEditing="GrossTuitionRevenueUndergradGridView_RowEditing" OnRowDataBound="GrossTuitionRevenueUndergradGridView_RowDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="33%" />
                </asp:BoundField>
                <asp:BoundField DataField="CHG" HeaderText="CHG">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="24%" />
                </asp:BoundField>
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="17%" />
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" Width="17%" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                    <FooterStyle BackColor="White"></FooterStyle>
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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

        <asp:Panel ID="GrossTuitionRevenueGradPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="GrossTuitionRevenueGradLabel" runat="server" Text ="Revenue / Expense Summary" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="GrossTuitionRevenueGradGridView" runat="server" ShowFooter="true" OnRowCancelingEdit="GrossTuitionRevenueGradGridView_RowCancelingEdit" OnRowUpdating="GrossTuitionRevenueGradGridView_RowUpdating" OnRowEditing="GrossTuitionRevenueGradGridView_RowEditing" OnRowDataBound="GrossTuitionRevenueGradGridView_RowDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="33%" />
                </asp:BoundField>
                <asp:BoundField DataField="CHG" HeaderText="CHG">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="24%" />
                </asp:BoundField>
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="17%" />
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" Width="17%" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                    <FooterStyle BackColor="White"></FooterStyle>
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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

        <asp:Panel ID="ExportedTuitionRevenueUndergradPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="ExportedTuitionRevenueUndergradLabel" runat="server" Text ="Revenue / Expense Summary" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="ExportedTuitionRevenueUndergradGridView" runat="server" ShowFooter="true" OnRowCancelingEdit="ExportedTuitionRevenueUndergradGridView_RowCancelingEdit" OnRowUpdating="ExportedTuitionRevenueUndergradGridView_RowUpdating" OnRowEditing="ExportedTuitionRevenueUndergradGridView_RowEditing" OnRowDataBound="ExportedTuitionRevenueUndergradGridView_RowDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="33%" />
                </asp:BoundField>
                <asp:BoundField DataField="CHG" HeaderText="CHG">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="24%" />
                </asp:BoundField>
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="17%" />
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" Width="17%" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                    <FooterStyle BackColor="White"></FooterStyle>
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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

        <asp:Panel ID="ExportedTuitionRevenueGradPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="ExportedTuitionRevenueGradLabel" runat="server" Text ="Revenue / Expense Summary" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="ExportedTuitionRevenueGradGridView" runat="server" ShowFooter="true" OnRowCancelingEdit="ExportedTuitionRevenueGradGridView_RowCancelingEdit" OnRowUpdating="ExportedTuitionRevenueGradGridView_RowUpdating" OnRowEditing="ExportedTuitionRevenueGradGridView_RowEditing" OnRowDataBound="ExportedTuitionRevenueGradGridView_RowDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="term" HeaderText="Term" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle ForeColor="Black" Width="33%" />
                </asp:BoundField>
                <asp:BoundField DataField="CHG" HeaderText="CHG">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="24%" />
                </asp:BoundField>
                <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="17%" />
                </asp:BoundField>
                <asp:BoundField DataField="total" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" Width="17%" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                    <FooterStyle BackColor="White"></FooterStyle>
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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


        <asp:Panel ID="AssessmentsPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
    
        <div class="panel panel-default" >
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="AssessmentsLabel" runat="server" Text ="Assessments" />
        </div>
        <div class="panel-body">
        
        <asp:GridView ID="AssessmentsGridView" runat="server" OnRowCancelingEdit="AssessmentsGridView_RowCancelingEdit" OnRowUpdating="AssessmentsGridView_RowUpdating" OnRowEditing="AssessmentsGridView_RowEditing" OnRowDataBound="AssessmentsGridView_RowDataBound" OnDataBound="AssessmentsGridView_OnDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" AutoGenerateColumns="False" BackColor="White" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Assessments" ReadOnly="True">
            <FooterStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="Black" />
            <ItemStyle ForeColor="Black" />
            </asp:BoundField>
            <asp:BoundField DataField="UndergraduatePercentage" HeaderText="Rate" DataFormatString="{0:P}">
                <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                <FooterStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
            </asp:BoundField>
                <asp:BoundField DataField="UndergraduateDollars" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="GraduatePercentage" HeaderText="Rate" DataFormatString="{0:P}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="GraduateDollars" HeaderText="Amount" DataFormatString="{0:C}" ReadOnly="True">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
            </asp:BoundField>                        
            <asp:CommandField ShowEditButton="True" ButtonType="Button">
                <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
            </asp:CommandField>            
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
        
            <asp:Panel ID="DirectEspensesPanel" runat="server" class="row" Visible="False" style="margin-top: 5px" >
            <div class="col-lg-3 cl-md-6"></div>
            <div class="col-lg-6 col-md-6">
            
            <div class="panel panel-default" >
            <div class="panel-heading">
            <i class="fa fa-table"></i> <asp:Label ID="DirectExpensesLabel" runat="server" Text ="Direct Expendures" />
            </div>
            <div class="panel-body">
   
            <asp:GridView ID="DirectExpensesGridView" runat="server" OnDataBound = "DirectExpensesGridView_OnDataBound" OnRowCommand ="DirectExpensesGridView_RowCommand" style=" margin-left: auto; margin-right:auto; position:relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
            <asp:ButtonField DataTextField="ExpenseType" HeaderText="Expense Type" CommandName="MyCommand">
                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle Width="70%" ForeColor="Black" />
            </asp:ButtonField>
            <asp:BoundField DataField="Amount" DataFormatString="{0:C}" HeaderText="Amount">
            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
    
        <asp:Panel ID="InstractionalCompensationPanel" Visible="False" runat="server" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
    
        <div class="panel panel-default" >
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="InstractionalCompensationLabel" runat="server" Text ="Instractional Compensation Expenses" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="InstractionalCompenstationGridView" runat="server" OnRowCancelingEdit="InstractionalCompenstationGridView_RowCancelingEdit" OnRowUpdating="InstractionalCompenstationGridView_RowUpdating" OnRowEditing="InstractionalCompenstationGridView_RowEditing" AutoGenerateColumns="False" style=" margin-left: auto; margin-right:auto; position:relative; width: 100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="expenseType" HeaderText="Expense Type" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left" BorderStyle="None"></HeaderStyle>
                    <ItemStyle ForeColor="Black" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="budget" HeaderText="Budget" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="fringeBenefitRate" HeaderText="Fringe Benefit Rate" DataFormatString="{0:P}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="benefit" HeaderText="Benefit Cost" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>
                
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
        
        <asp:Panel ID="NonInstractionalCompensationPanel" Visible="False" runat="server" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
    
        <div class="panel panel-default" >
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="NonInstractionalCompensationLabel" runat="server" Text ="Non-instractional Compensation Expenses" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="NonInstractionalCompensationGridView" runat="server" OnRowCancelingEdit="NonInstractionalCompensationGridView_RowCancelingEdit" OnRowUpdating="NonInstractionalCompensationGridView_RowUpdating" OnRowEditing="NonInstractionalCompensationGridView_RowEditing" AutoGenerateColumns="False" style=" margin-left: auto; margin-right:auto; position:relative; width: 100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="expenseType" HeaderText="Expense Type" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left" BorderStyle="None"></HeaderStyle>
                    <ItemStyle ForeColor="Black" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="budget" HeaderText="Budget" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="fringeBenefitRate" HeaderText="Fringe Benefit Rate" DataFormatString="{0:P}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="benefit" HeaderText="Benefit Cost" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>
                
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
        
        <asp:Panel ID="NonCompensationExpensesPanel" runat="server" class="row" Visible="False" style="margin-top: 5px" >
            <div class="col-lg-3 cl-md-6"></div>
            <div class="col-lg-6 col-md-6">
        
            <div class="panel panel-default" >
            
            <div class="panel-heading">
            <i class="fa fa-table"></i> <asp:Label ID="NonCompensationExpensesLabel" runat="server" Text ="Non-compensation Expenses" />
            </div>
            
            <div class="panel-body">

            <asp:GridView ID="NonCompensationExpensesGridView" runat="server" style=" margin-top: 5px; margin-left: auto; margin-right:auto; position:relative; width: 100%" OnRowCancelingEdit="NonCompensationExpensesGridView_RowCancelingEdit" OnRowUpdating="NonCompensationExpensesGridView_RowUpdating" OnRowEditing="NonCompensationExpensesGridView_RowEditing" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="expenseType" HeaderText="Expense Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ReadOnly="True">
                    <FooterStyle BackColor="White" BorderColor="Silver" BorderStyle="None" BorderWidth="1px" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle></HeaderStyle>
                    <ItemStyle Width="50%" BorderColor="Silver" BorderStyle="None" BorderWidth="1px" ForeColor="Black" />
                </asp:BoundField>
                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True">
                    <FooterStyle HorizontalAlign="Center" BackColor="White" BorderColor="Silver" BorderWidth="1px" BorderStyle="None" Font-Bold="True" ForeColor="Black"></FooterStyle>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="Silver" BorderWidth="1px" BorderStyle="None" ForeColor="Black"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="budget" DataFormatString="{0:C}" HeaderText="Budget">
                    <ControlStyle CssClass="form-control"></ControlStyle>

                    <FooterStyle HorizontalAlign="Center" BackColor="White" BorderColor="Silver" BorderWidth="1px" BorderStyle="None" Font-Bold="True" ForeColor="Black"></FooterStyle>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" BorderColor="Silver" BorderWidth="1px" BorderStyle="None" ForeColor="Black"></ItemStyle>
            </asp:BoundField>
            
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            
            </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
        
        <asp:Panel ID="AllocatedCostsPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="AllocatedCostsLabel" runat="server" Text ="Allocated Costs" />
        </div>
        <div class="panel-body">
   
        <asp:GridView ID="AllocatedCostsGridView" runat="server" OnRowCommand ="AllocatedCostsGridView_RowCommand"  OnDataBound = "AllocatedCostsGridView_OnDataBound" style=" margin-left: auto; margin-right:auto; position:relative; width: 100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:ButtonField DataTextField="AllocatedCost" HeaderText=" Support Unit" CommandName="MyCommand">
                <ControlStyle ></ControlStyle>

                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle Width="70%" ForeColor="Black" />
            </asp:ButtonField>
            <asp:BoundField DataField="Amount" DataFormatString="{0:C}" HeaderText="Amount">
            <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle ForeColor="Black" HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
        
        <asp:Panel ID="SupportUnitPanel" runat="server" Visible="False" class="row" style="margin-top: 5px" >
        <div class="col-lg-3 cl-md-6"></div>
        <div class="col-lg-6 col-md-6">
        <div class="panel panel-default" >
        
        <div class="panel-heading">
        <i class="fa fa-table"></i> <asp:Label ID="SupportUnitLabel" runat="server" Text ="Revenue / Expense Summary" />
        </div>
        <div class="panel-body">
   
            <asp:GridView ID="SupportUnitGridView" runat="server" OnRowDataBound="SupportUnitGridView_RowDataBound" Style="margin-left: auto; margin-right: auto; position: relative; width: 100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" RowStyle-ForeColor="Black">
        <Columns>
            <asp:BoundField DataField="AllocatedCost" HeaderText=" Support Unit" >
                <ControlStyle ></ControlStyle>

                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle ForeColor="Black" Width="25 %" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
               
        <asp:GridView ID="SupportUnitMetricsGridView" runat="server" OnRowCancelingEdit="SupportUnitMetricsGridView_RowCancelingEdit" OnRowUpdating="SupportUnitMetricsGridView_RowUpdating" OnRowEditing="SupportUnitMetricsGridView_RowEditing" AutoGenerateColumns="False" Style="margin-top: 15px; margin-left: auto; margin-right: auto; position: relative; width: 100%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="metricType" HeaderText="Metric Type" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle HorizontalAlign="Left" BorderStyle="None"></HeaderStyle>
                    <ItemStyle ForeColor="Black" BorderStyle="None" />
                </asp:BoundField>

               <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString="{0:P}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>
                
                <asp:BoundField DataField="totalMetric" HeaderText="Total Metric" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="amount" HeaderText="Cost to Allocate" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>
                
                 <asp:BoundField DataField="costPerMetric" HeaderText="Cost Per Metric" DataFormatString="{0:C}" ReadOnly="True">
                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>

                <asp:BoundField DataField="metrics" HeaderText="Metrics" DataFormatString="{0:C}">
                    <ControlStyle CssClass="form-control" Width="100%"></ControlStyle>

                    <FooterStyle BackColor="White" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" BorderStyle="None" />
                    <ItemStyle ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                </asp:BoundField>
               
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                <ControlStyle CssClass="btn btn-primary btn-xs" BackColor="#9E1B34" Width="100%" BorderColor="#9E1B34"></ControlStyle>
                <ItemStyle ForeColor="Black" HorizontalAlign="Center" Width="7%" />
                </asp:CommandField>
            
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#9e1b34" Font-Bold="True" ForeColor="White" />
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
        
        <a id="FocusAnchor" runat="server"></a>
        
</div> 
    
</asp:Content>
