using RCM_Model_Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace RCM_NEW
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["supportUnit"] = null;
            }
        }

        protected void GenerateReportButton_Click(object sender, EventArgs e)
        {
            AssessmentsPanel.Visible = false;

            DisplayRevenueExpenseSummaryReport();

            RevenueSummaryLabel.Text = "Revenue / Expense Summary " + FinancialYearDropDownList.SelectedValue;
        }

        private void DisplayRevenueExpenseSummaryReport()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataTable tbl = rtrvDB.DisplayRevenueExpenseSummaryReport(FinancialYearDropDownList.SelectedValue);
            
            SummaryReportPanel.Visible = true;

            SummaryReportGridView.DataSource = tbl;
            SummaryReportGridView.DataBind();
        }

        protected void SummaryReportGridView_OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            cell.ColumnSpan = 2;
            row.Controls.Add(cell);

            row.BackColor = ColorTranslator.FromHtml("#9e1b34");
            row.ForeColor = ColorTranslator.FromHtml("White");
            
            SummaryReportGridView.Rows[5].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
            
            row.HorizontalAlign = HorizontalAlign.Center;

            foreach (GridViewRow row2 in SummaryReportGridView.Rows)
            {
                LinkButton lb = (LinkButton)row2.Cells[0].Controls[0];
                lb.ForeColor = ColorTranslator.FromHtml("#0000EE");
            
            }
            
            LinkButton lb2 = (LinkButton)SummaryReportGridView.Rows[5].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            lb2.ControlStyle.Font.Bold = true;   
        }
        protected void SummaryReportGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (index == 0 || index == 1)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayTuitionRevenueBreakdown();
                    DisplayTuitionDifferentialRevenue();

                    FocusAnchor.Focus();
                    
                    SupportUnitPanel.Visible = false;
                    AllocatedCostsPanel.Visible = false;
                    
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    AssessmentsPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    DirectEspensesPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                }
            }

            else if (index == 2)
            {
                if (e.CommandName == "MyCommand")
                {

                    DisplayAssesments();
                    FocusAnchor.Focus();

                    SupportUnitPanel.Visible = false;
                    AllocatedCostsPanel.Visible = false;
                    TuitionBreakdownByLevelPanel.Visible = false;
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    TuitionBreakdownByLevelPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    DirectEspensesPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                
                }
            }

            else if (index == 3)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayAllocatedCostsSummaryReport();
                    FocusAnchor.Focus();
                   
                    DirectEspensesPanel.Visible = false;
                    TuitionBreakdownByLevelPanel.Visible = false;
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    AssessmentsPanel.Visible = false;
                    TuitionBreakdownByLevelPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                }
            }
            else if (index == 4)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayDirectExpenses();
                    FocusAnchor.Focus();
                    
                    SupportUnitPanel.Visible = false;
                    AllocatedCostsPanel.Visible = false;
                    TuitionBreakdownByLevelPanel.Visible = false;
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    AssessmentsPanel.Visible = false;
                    TuitionBreakdownByLevelPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                }
            }
        }

        protected void DisplayTuitionRevenueBreakdown()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataTable tbl = rtrvDB.DisplayTuitionRevenueBreakDown(FinancialYearDropDownList.SelectedValue);

            TuitionBreakdownByLevelPanel.Visible = true;

            TuitionBreakdownByLevelGridView.DataSource = tbl;
            TuitionBreakdownByLevelGridView.DataBind();

            TuitionBreakdownByLevelLabel.Text = "Revenue Breakdown by Level " + FinancialYearDropDownList.SelectedValue;

            
        }

               
        protected void TuitionBreakdownByLevelGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (index == 0)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayGrossTuitionUndergrad();

                    FocusAnchor.Focus();
                    TuitionBreakdownByLevelPanel.Visible = true;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    AssessmentsPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    DirectEspensesPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                }
            }

            else if (index == 1)
            {
                if (e.CommandName == "MyCommand")
                {

                    DisplayGrossTuitionGrad();
                    FocusAnchor.Focus();
                    TuitionBreakdownByLevelPanel.Visible = true;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    DirectEspensesPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;

                }
            }
            else if (index == 3)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayExportedTuitionUndergrad();
                    FocusAnchor.Focus();
                    TuitionBreakdownByLevelPanel.Visible = true;
                    ExportedTuitionRevenueGradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    AssessmentsPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                }
            }
            else if (index == 4)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayExportedTuitionGrad();
                    FocusAnchor.Focus();
                    TuitionBreakdownByLevelPanel.Visible = true;
                    ExportedTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueUndergradPanel.Visible = false;
                    GrossTuitionRevenueGradPanel.Visible = false;
                    AssessmentsPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                    InstractionalCompensationPanel.Visible = false;
                }
            }
        
        }
        
        
        protected void TuitionBreakdownByLevelGridView_OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            cell.ColumnSpan = 2;
            row.Controls.Add(cell);

            row.BackColor = ColorTranslator.FromHtml("#9e1b34");
            row.ForeColor = ColorTranslator.FromHtml("White");


            row.HorizontalAlign = HorizontalAlign.Center;

            TuitionBreakdownByLevelGridView.Rows[2].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
            TuitionBreakdownByLevelGridView.Rows[5].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
            TuitionBreakdownByLevelGridView.Rows[8].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");

            foreach (GridViewRow row2 in TuitionBreakdownByLevelGridView.Rows)
            {
                LinkButton lb = (LinkButton)row2.Cells[0].Controls[0];
                lb.ForeColor = ColorTranslator.FromHtml("#0000EE");

            }

            LinkButton lb2 = (LinkButton)TuitionBreakdownByLevelGridView.Rows[2].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            lb2.ControlStyle.Font.Bold = true;

            lb2 = (LinkButton)TuitionBreakdownByLevelGridView.Rows[5].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            lb2.ControlStyle.Font.Bold = true;

            lb2 = (LinkButton)TuitionBreakdownByLevelGridView.Rows[6].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            
            lb2 = (LinkButton)TuitionBreakdownByLevelGridView.Rows[7].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            
            lb2 = (LinkButton)TuitionBreakdownByLevelGridView.Rows[8].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            lb2.ControlStyle.Font.Bold = true;
        }

        
        
        
        protected void DisplayTuitionDifferentialRevenue()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionDifferentialRevenue(FinancialYearDropDownList.SelectedValue);

            TuitionDifferentialRevenueGridView.DataSource = ds;
            TuitionDifferentialRevenueGridView.DataBind();

            DirectExpensesLabel.Text = "Direct Expendures " + FinancialYearDropDownList.SelectedValue;
                  
        }

        
        protected void TuitionDifferentialRevenueGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            TuitionDifferentialRevenueGridView.EditIndex = e.NewEditIndex;

            DisplayTuitionDifferentialRevenue();
            FocusAnchor.Focus();
        }

        protected void TuitionDifferentialRevenueGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            String gradUndergrad;
            Double rate;
            Double numberStudentsCHG;
            
            if (e.RowIndex == 0)
            {
                gradUndergrad = "Undergraduate";
                         
            }
            else
            {
                gradUndergrad = "Graduate";

            }
                 
            TBox = (TextBox)TuitionDifferentialRevenueGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            numberStudentsCHG = Double.Parse(TBox.Text);
            TBox = (TextBox)TuitionDifferentialRevenueGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            rate = Double.Parse(TBox.Text);
            
            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.DifferentialRevenueUpdate(FinancialYearDropDownList.SelectedValue, gradUndergrad, rate, numberStudentsCHG);
            UpdateDB.AssessmentsUpdate(FinancialYearDropDownList.SelectedValue);
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            DisplayRevenueExpenseSummaryReport();

            TuitionDifferentialRevenueGridView.EditIndex = -1;
            DisplayTuitionDifferentialRevenue();
            FocusAnchor.Focus();
        }

        protected void TuitionDifferentialRevenueGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            TuitionDifferentialRevenueGridView.EditIndex = -1;

            DisplayTuitionDifferentialRevenue();
            FocusAnchor.Focus();
        }
        
        
        protected void TuitionDifferentialRevenueGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionDifferentialRevenue(FinancialYearDropDownList.SelectedValue);

            double undergradRevenue = double.Parse(ds.Tables[0].Rows[0][3].ToString());
            double gradRevenue = double.Parse(ds.Tables[0].Rows[1][3].ToString());
      
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Tuition Differential Revenue";
                e.Row.Cells[3].Text = String.Format("{0:C}", undergradRevenue + gradRevenue);

            }
        }
        
        protected void DisplayGrossTuitionUndergrad()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Gross/Undergraduate");

            GrossTuitionRevenueUndergradPanel.Visible = true;

            GrossTuitionRevenueUndergradGridView.DataSource = ds;
            GrossTuitionRevenueUndergradGridView.DataBind();

            GrossTuitionRevenueUndergradLabel.Text = "Undergraduate Gross Tuition Revenue " + FinancialYearDropDownList.SelectedValue;


        }

        protected void GrossTuitionRevenueUndergradGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            GrossTuitionRevenueUndergradGridView.EditIndex = e.NewEditIndex;
            
            DisplayGrossTuitionUndergrad();
            FocusAnchor.Focus();
        }

        protected void GrossTuitionRevenueUndergradGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            
            
            TextBox TBox;
            String term;
            Double rate;
            Double CHG;


            term = GrossTuitionRevenueUndergradGridView.Rows[e.RowIndex].Cells[0].Text;
            TBox = (TextBox)GrossTuitionRevenueUndergradGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            CHG = Double.Parse(TBox.Text);
            
            TBox = (TextBox)GrossTuitionRevenueUndergradGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            rate = Double.Parse(TBox.Text);
            
            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.RevenueUpdateByCategory(FinancialYearDropDownList.SelectedValue, term, rate, CHG, "Gross/Undergraduate");
            UpdateDB.AssessmentsUpdate(FinancialYearDropDownList.SelectedValue);
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            DisplayRevenueExpenseSummaryReport();

            DisplayTuitionRevenueBreakdown();

            GrossTuitionRevenueUndergradGridView.EditIndex = -1;
            DisplayGrossTuitionUndergrad();
            FocusAnchor.Focus();
        }

        protected void GrossTuitionRevenueUndergradGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
           
            GrossTuitionRevenueUndergradGridView.EditIndex = -1;

            DisplayGrossTuitionUndergrad();
            FocusAnchor.Focus();
        }
        protected void GrossTuitionRevenueUndergradGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Gross/Undergraduate");

            Double total = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                total = total + Double.Parse(row[3].ToString());
            }
            
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Undergraduate Gross Revenue";
                e.Row.Cells[3].Text = String.Format("{0:C}", total);

            }
        }

        protected void DisplayGrossTuitionGrad()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Gross/Graduate");

            GrossTuitionRevenueGradPanel.Visible = true;

            GrossTuitionRevenueGradGridView.DataSource = ds;
            GrossTuitionRevenueGradGridView.DataBind();

            GrossTuitionRevenueGradLabel.Text = "Graduate Gross Tuition Revenue " + FinancialYearDropDownList.SelectedValue;


        }

        protected void GrossTuitionRevenueGradGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            GrossTuitionRevenueGradGridView.EditIndex = e.NewEditIndex;
            FocusAnchor.Focus();
            DisplayGrossTuitionGrad();

        }

        protected void GrossTuitionRevenueGradGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            String term;
            Double rate;
            Double CHG;


            term = GrossTuitionRevenueGradGridView.Rows[e.RowIndex].Cells[0].Text;
            TBox = (TextBox)GrossTuitionRevenueGradGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            CHG = Double.Parse(TBox.Text);
            TBox = (TextBox)GrossTuitionRevenueGradGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            rate = Double.Parse(TBox.Text);

            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.RevenueUpdateByCategory(FinancialYearDropDownList.SelectedValue, term, rate, CHG, "Gross/Graduate");
            UpdateDB.AssessmentsUpdate(FinancialYearDropDownList.SelectedValue);
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            DisplayRevenueExpenseSummaryReport();

            DisplayTuitionRevenueBreakdown();

            GrossTuitionRevenueGradGridView.EditIndex = -1;
            DisplayGrossTuitionGrad();
            FocusAnchor.Focus();
        }

        protected void GrossTuitionRevenueGradGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            GrossTuitionRevenueGradGridView.EditIndex = -1;

            DisplayGrossTuitionGrad();
            FocusAnchor.Focus();
        }
        protected void GrossTuitionRevenueGradGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Gross/Graduate");

            Double total = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                total = total + Double.Parse(row[3].ToString());
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Graduate Gross Revenue";
                e.Row.Cells[3].Text = String.Format("{0:C}", total);

            }
        }

        protected void DisplayExportedTuitionUndergrad()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Exported/Undergraduate");

            ExportedTuitionRevenueUndergradPanel.Visible = true;

            ExportedTuitionRevenueUndergradGridView.DataSource = ds;
            ExportedTuitionRevenueUndergradGridView.DataBind();

            ExportedTuitionRevenueUndergradLabel.Text = "Undergraduate Exported Tuition Revenue " + FinancialYearDropDownList.SelectedValue;


        }

        protected void ExportedTuitionRevenueUndergradGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            ExportedTuitionRevenueUndergradGridView.EditIndex = e.NewEditIndex;
            
            DisplayExportedTuitionUndergrad();
            FocusAnchor.Focus();
        }

        protected void ExportedTuitionRevenueUndergradGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            String term;
            Double rate;
            Double CHG;


            term = ExportedTuitionRevenueUndergradGridView.Rows[e.RowIndex].Cells[0].Text;
            TBox = (TextBox)ExportedTuitionRevenueUndergradGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            CHG = Double.Parse(TBox.Text);
            TBox = (TextBox)ExportedTuitionRevenueUndergradGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            rate = Double.Parse(TBox.Text);

            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.RevenueUpdateByCategory(FinancialYearDropDownList.SelectedValue, term, rate, CHG, "Exported/Undergraduate");
            UpdateDB.AssessmentsUpdate(FinancialYearDropDownList.SelectedValue);
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            DisplayRevenueExpenseSummaryReport();

            DisplayTuitionRevenueBreakdown();

            ExportedTuitionRevenueUndergradGridView.EditIndex = -1;
            DisplayExportedTuitionUndergrad();
            FocusAnchor.Focus();

        }

        protected void ExportedTuitionRevenueUndergradGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            ExportedTuitionRevenueUndergradGridView.EditIndex = -1;

            DisplayExportedTuitionUndergrad();
            FocusAnchor.Focus();
        }
        protected void ExportedTuitionRevenueUndergradGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Exported/Undergraduate");

            Double total = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                total = total + Double.Parse(row[3].ToString());
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Undergraduate Exported Revenue";
                e.Row.Cells[3].Text = String.Format("{0:C}", total);

            }
        }

        protected void DisplayExportedTuitionGrad()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Exported/Graduate");

            ExportedTuitionRevenueGradPanel.Visible = true;

            ExportedTuitionRevenueGradGridView.DataSource = ds;
            ExportedTuitionRevenueGradGridView.DataBind();

            ExportedTuitionRevenueGradLabel.Text = "Graduate Exported Tuition Revenue " + FinancialYearDropDownList.SelectedValue;


        }

        protected void ExportedTuitionRevenueGradGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            ExportedTuitionRevenueGradGridView.EditIndex = e.NewEditIndex;
            
            DisplayExportedTuitionGrad();
            FocusAnchor.Focus();
        }

        protected void ExportedTuitionRevenueGradGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            String term;
            Double rate;
            Double CHG;


            term = ExportedTuitionRevenueGradGridView.Rows[e.RowIndex].Cells[0].Text;
            TBox = (TextBox)ExportedTuitionRevenueGradGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            CHG = Double.Parse(TBox.Text);
            TBox = (TextBox)ExportedTuitionRevenueGradGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            rate = Double.Parse(TBox.Text);

            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.RevenueUpdateByCategory(FinancialYearDropDownList.SelectedValue, term, rate, CHG, "Exported/Graduate");
            UpdateDB.AssessmentsUpdate(FinancialYearDropDownList.SelectedValue);
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            DisplayRevenueExpenseSummaryReport();

            DisplayTuitionRevenueBreakdown();

            ExportedTuitionRevenueGradGridView.EditIndex = -1;
            DisplayExportedTuitionGrad();
            FocusAnchor.Focus();
        }

        protected void ExportedTuitionRevenueGradGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            ExportedTuitionRevenueGradGridView.EditIndex = -1;

            DisplayExportedTuitionGrad();
            FocusAnchor.Focus();
        }
        protected void ExportedTuitionRevenueGradGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayTuitionRevenueByCategory(FinancialYearDropDownList.SelectedValue, "Exported/Graduate");

            Double total = 0;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                total = total + Double.Parse(row[3].ToString());
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Graduate Exported Revenue";
                e.Row.Cells[3].Text = String.Format("{0:C}", total);

            }
        }
        
      
        public void DisplayAssesments()
        {

            RetrieveFromDB rtrvDB = new RetrieveFromDB();
            
            DataTable tbl = rtrvDB.DisplayAssessments(FinancialYearDropDownList.SelectedValue);

            AssessmentsGridView.DataSource = tbl;
            AssessmentsGridView.DataBind();

            AssessmentsPanel.Visible = true;

            AssessmentsLabel.Text = "Assessments " + FinancialYearDropDownList.SelectedValue;

        }
        protected void AssessmentsGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {

            AssessmentsGridView.EditIndex = e.NewEditIndex;
            
            DisplayAssesments();
            FocusAnchor.Focus();
        }

        protected void AssessmentsGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            String assessment;
            Double undergradRate;
            Double gradRate;
            
            assessment = AssessmentsGridView.Rows[e.RowIndex + 1].Cells[0].Text;
            TBox = (TextBox)AssessmentsGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            undergradRate = Double.Parse(TBox.Text);
            TBox = (TextBox)AssessmentsGridView.Rows[e.RowIndex].Cells[3].Controls[0];
            gradRate = Double.Parse(TBox.Text);
                
            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.AssessmentsUpdateRate(FinancialYearDropDownList.SelectedValue, assessment, undergradRate, gradRate);

            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            DisplayRevenueExpenseSummaryReport();

            AssessmentsGridView.EditIndex = -1;
            DisplayAssesments();
            FocusAnchor.Focus();
        }

        protected void AssessmentsGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            AssessmentsGridView.EditIndex = -1;

            DisplayAssesments();
            FocusAnchor.Focus();
        }
        
        protected void AssessmentsGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {

           if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells.RemoveAt(0);

            }

        }
        
        protected void AssessmentsGridView_OnDataBound(object sender, EventArgs e)
        { 
            
            
            AssessmentsGridView.Rows[2].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");

            Button btn = (Button)AssessmentsGridView.Rows[2].Cells[5].Controls[0];
            btn.Visible = false;

            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            
            TableHeaderCell cell2 = new TableHeaderCell();
            cell2.Text = "Assesments";
            cell2.HorizontalAlign = HorizontalAlign.Left;
            cell2.ColumnSpan = 1;
            cell2.RowSpan = 2;
            row.Controls.Add(cell2);
            
            TableHeaderCell cell3 = new TableHeaderCell();
            cell3.Text = "Undergraduate";
            cell3.HorizontalAlign = HorizontalAlign.Center;
            cell3.ColumnSpan = 2;
            row.Controls.Add(cell3);
            
            TableHeaderCell cell4 = new TableHeaderCell();
            cell4.Text = "Graduate";
            cell4.HorizontalAlign = HorizontalAlign.Center;
            cell4.ColumnSpan = 2;
            row.Controls.Add(cell4);

            TableHeaderCell cell5 = new TableHeaderCell();
            cell5.Text = "";
            cell5.HorizontalAlign = HorizontalAlign.Center;
            cell5.ColumnSpan = 1;
            row.Controls.Add(cell5);

            row.BackColor = ColorTranslator.FromHtml("#9e1b34");
            row.ForeColor = ColorTranslator.FromHtml("White");

            AssessmentsGridView.HeaderRow.Parent.Controls.AddAt(0, row);
        }

        protected void DisplayDirectExpenses()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataTable tbl = rtrvDB.DisplayDirectExpenses(FinancialYearDropDownList.SelectedValue);

            DirectEspensesPanel.Visible = true;

            DirectExpensesGridView.DataSource = tbl;
            DirectExpensesGridView.DataBind();

            DirectExpensesLabel.Text = "Direct Expendures " + FinancialYearDropDownList.SelectedValue;
        }

        protected void DirectExpensesGridView_OnDataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow row in DirectExpensesGridView.Rows)
            {
                LinkButton lb = (LinkButton)row.Cells[0].Controls[0];
                lb.ForeColor = ColorTranslator.FromHtml("#0000EE");

            }

            DirectExpensesGridView.Rows[2].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
            DirectExpensesGridView.Rows[3].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
            DirectExpensesGridView.Rows[4].Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
           
            LinkButton lb2 = (LinkButton)DirectExpensesGridView.Rows[2].Cells[0].Controls[0];
            lb2.Enabled = false;
            lb2.ControlStyle.Font.Underline = false;
            lb2.ForeColor = ColorTranslator.FromHtml("Black");
            lb2.ControlStyle.Font.Bold = true;

            LinkButton lb3 = (LinkButton)DirectExpensesGridView.Rows[3].Cells[0].Controls[0];
            lb3.Enabled = false;
            lb3.ControlStyle.Font.Underline = false;
            lb3.ForeColor = ColorTranslator.FromHtml("Black");
            lb3.ControlStyle.Font.Bold = true;

            LinkButton lb4 = (LinkButton)DirectExpensesGridView.Rows[4].Cells[0].Controls[0];
            lb4.Enabled = false;
            lb4.ControlStyle.Font.Underline = false;
            lb4.ForeColor = ColorTranslator.FromHtml("Black");
            lb4.ControlStyle.Font.Bold = true;
        
        }

        protected void DirectExpensesGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            if (index == 0)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayInstructionalCompensation();
                    FocusAnchor.Focus();
                    NonInstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                }
            }

            else if (index == 1)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayNonInstructionalCompensation();
                    FocusAnchor.Focus();
                    InstractionalCompensationPanel.Visible = false;
                    NonCompensationExpensesPanel.Visible = false;
                }
            }
            else if (index == 5)
            {
                if (e.CommandName == "MyCommand")
                {
                    DisplayNonCompensationExpenses();
                    FocusAnchor.Focus();
                    InstractionalCompensationPanel.Visible = false;
                    NonInstractionalCompensationPanel.Visible = false;
                    
                }
            }
        }
        
        protected void DisplayInstructionalCompensation()
        {

            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayCompensation(FinancialYearDropDownList.SelectedValue, "Instractional");

             InstractionalCompenstationGridView.DataSource = ds;
            InstractionalCompenstationGridView.DataBind();

            InstractionalCompensationLabel.Text = "Instractional Compensation Expenses " + FinancialYearDropDownList.SelectedValue;

            InstractionalCompensationPanel.Visible = true;
        }
        
        protected void InstractionalCompenstationGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            InstractionalCompenstationGridView.EditIndex = e.NewEditIndex;

            DisplayInstructionalCompensation();
            FocusAnchor.Focus();
        }

        protected void InstractionalCompenstationGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            Double budget;
            Double rate;

            String accountNumber = InstractionalCompenstationGridView.Rows[e.RowIndex].Cells[1].Text;
            TBox = (TextBox)InstractionalCompenstationGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            budget = Double.Parse(TBox.Text);
            TBox = (TextBox)InstractionalCompenstationGridView.Rows[e.RowIndex].Cells[3].Controls[0];
            rate = Double.Parse(TBox.Text);
            
            
            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.CompensationUpdate(FinancialYearDropDownList.SelectedValue, accountNumber, budget, rate, "Instractional");

            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            
            DisplayRevenueExpenseSummaryReport();
            DisplayDirectExpenses();
            InstractionalCompenstationGridView.EditIndex = -1;
            
            DisplayInstructionalCompensation();
            FocusAnchor.Focus();
        }

        protected void InstractionalCompenstationGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            InstractionalCompenstationGridView.EditIndex = -1;

            DisplayInstructionalCompensation();
            FocusAnchor.Focus();
        }
        protected void DisplayNonInstructionalCompensation()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplayCompensation(FinancialYearDropDownList.SelectedValue, "NonInstractional");

            NonInstractionalCompensationGridView.DataSource = ds;
            NonInstractionalCompensationGridView.DataBind();

            NonInstractionalCompensationLabel.Text = "Non-instractional Compensation Expenses " + FinancialYearDropDownList.SelectedValue;

            NonInstractionalCompensationPanel.Visible = true;
        }

        protected void NonInstractionalCompensationGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            NonInstractionalCompensationGridView.EditIndex = e.NewEditIndex;
            
            DisplayNonInstructionalCompensation();
            FocusAnchor.Focus();
        }

        protected void NonInstractionalCompensationGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            Double budget;
            Double rate;

            String accountNumber = NonInstractionalCompensationGridView.Rows[e.RowIndex].Cells[1].Text;
            TBox = (TextBox)NonInstractionalCompensationGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            budget = Double.Parse(TBox.Text);
            TBox = (TextBox)NonInstractionalCompensationGridView.Rows[e.RowIndex].Cells[3].Controls[0];
            rate = Double.Parse(TBox.Text);


            
            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.CompensationUpdate(FinancialYearDropDownList.SelectedValue, accountNumber, budget, rate, "NonInstractional");
            
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);

            DisplayRevenueExpenseSummaryReport();
            DisplayDirectExpenses();
            NonInstractionalCompensationGridView.EditIndex = -1;
            FocusAnchor.Focus();
            DisplayNonInstructionalCompensation();
            FocusAnchor.Focus();
        }

        protected void NonInstractionalCompensationGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            NonInstractionalCompensationGridView.EditIndex = -1;

            DisplayNonInstructionalCompensation();
            FocusAnchor.Focus();
        }

        protected void DisplayNonCompensationExpenses()
        {

            RetrieveFromDB rtrvDB = new RetrieveFromDB();
            DataSet ds = rtrvDB.DisplayNonCompensationExpenses(FinancialYearDropDownList.SelectedValue);

            NonCompensationExpensesGridView.DataSource = ds;
            NonCompensationExpensesGridView.DataBind();

            NonCompensationExpensesLabel.Text = "Non-Compensation Expenses " + FinancialYearDropDownList.SelectedValue;
            
            NonCompensationExpensesPanel.Visible = true;
        }
    
        protected void NonCompensationExpensesGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            NonCompensationExpensesGridView.EditIndex = e.NewEditIndex;
            DisplayNonCompensationExpenses();
            FocusAnchor.Focus();
        }

        protected void NonCompensationExpensesGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            TextBox TBox;
            Double budget;
           
            String expenseType = NonCompensationExpensesGridView.Rows[e.RowIndex].Cells[0].Text;
            TBox = (TextBox)NonCompensationExpensesGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            budget = Double.Parse(TBox.Text);
            
            RCMDatabaseUpdate RCMUpdate = new RCMDatabaseUpdate();
            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.NonCompensationExpensesUpdate(FinancialYearDropDownList.SelectedValue, expenseType, budget);
            
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);

            DisplayRevenueExpenseSummaryReport();
            DisplayDirectExpenses();
            NonCompensationExpensesGridView.EditIndex = -1;
            DisplayNonCompensationExpenses();
            FocusAnchor.Focus();
        }

        protected void NonCompensationExpensesGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            NonCompensationExpensesGridView.EditIndex = -1;

            DisplayNonCompensationExpenses();
            FocusAnchor.Focus();
        }

        private void DisplayAllocatedCostsSummaryReport()
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataTable tbl = rtrvDB.DisplayAllocatedCostsSummary(FinancialYearDropDownList.SelectedValue);

            AllocatedCostsPanel.Visible = true;

            AllocatedCostsGridView.DataSource = tbl;
            AllocatedCostsGridView.DataBind();

            AllocatedCostsLabel.Text = "Allocated Costs " + FinancialYearDropDownList.SelectedValue;
        }

        protected void AllocatedCostsGridView_OnDataBound(object sender, EventArgs e)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            cell.ColumnSpan = 2;
            row.Controls.Add(cell);

            row.BackColor = ColorTranslator.FromHtml("#9e1b34");
            row.ForeColor = ColorTranslator.FromHtml("White");

            row.HorizontalAlign = HorizontalAlign.Center;

            foreach (GridViewRow row2 in AllocatedCostsGridView.Rows)
            {
                LinkButton lb = (LinkButton)row2.Cells[0].Controls[0];
                lb.ForeColor = ColorTranslator.FromHtml("#0000EE");

            }
                        
        }
        protected void AllocatedCostsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            
            
            int index = Convert.ToInt32(e.CommandArgument);

            LinkButton lb = (LinkButton)AllocatedCostsGridView.Rows[index].Cells[0].Controls[0];
            String supportUnit = lb.Text;
            Session["supportUnit"] = supportUnit;

            DisplaySupportUnit(supportUnit);
            DisplayAllocatedCostsSummaryReport();
            DisplaySupportUnitMetrics(supportUnit);
            
            FocusAnchor.Focus();
            
        }

        
        protected void SupportUnitGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            
            if (e.Row.RowType == DataControlRowType.DataRow)
                   {
                    for (int i = 2; i < e.Row.Cells.Count; i++)
                    {

                       e.Row.Cells[i].ForeColor = System.Drawing.Color.Black;
                       e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                      
                    }

                    }
            
                
        }
        
        private void DisplaySupportUnit(String supportUnit)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();
            
            DataTable tbl = rtrvDB.DisplaySupportUnit(FinancialYearDropDownList.SelectedValue, supportUnit);

            SupportUnitPanel.Visible = true;

            SupportUnitGridView.DataSource = tbl;
            SupportUnitGridView.DataBind();
            
            SupportUnitLabel.Text = "Support Unit Breakdown " + FinancialYearDropDownList.SelectedValue;
        }

        private void DisplaySupportUnitMetrics(String supportUnit)
        {
            RetrieveFromDB rtrvDB = new RetrieveFromDB();

            DataSet ds = rtrvDB.DisplaySupportUnitMetrics(FinancialYearDropDownList.SelectedValue, supportUnit);
            
            SupportUnitMetricsGridView.DataSource = ds;
            SupportUnitMetricsGridView.DataBind();

         }

        protected void SupportUnitMetricsGridView_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            String supportUnit = (String)Session["supportUnit"];

            SupportUnitMetricsGridView.EditIndex = e.NewEditIndex;

            DisplaySupportUnitMetrics(supportUnit);
            FocusAnchor.Focus();
        }

        protected void SupportUnitMetricsGridView_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            String supportUnit = (String)Session["supportUnit"];
            TextBox TBox;
            String metricType;
            Double rate;
            Double totalMetrics;
            Double costToAllocate;
            Double metrics;

            metricType = SupportUnitMetricsGridView.Rows[e.RowIndex].Cells[0].Text;
            TBox = (TextBox)SupportUnitMetricsGridView.Rows[e.RowIndex].Cells[1].Controls[0];
            rate = Double.Parse(TBox.Text);
            TBox = (TextBox)SupportUnitMetricsGridView.Rows[e.RowIndex].Cells[2].Controls[0];
            totalMetrics = Double.Parse(TBox.Text);
            TBox = (TextBox)SupportUnitMetricsGridView.Rows[e.RowIndex].Cells[3].Controls[0];
            costToAllocate = Double.Parse(TBox.Text);
            TBox = (TextBox)SupportUnitMetricsGridView.Rows[e.RowIndex].Cells[5].Controls[0];
            metrics = Double.Parse(TBox.Text);

            UpdateDatabase UpdateDB = new UpdateDatabase();

            UpdateDB.CostDriversUpdate(FinancialYearDropDownList.SelectedValue, supportUnit, metricType, rate, totalMetrics, costToAllocate, metrics);
                       
            UpdateDB.RevenueSummaryUpdate(FinancialYearDropDownList.SelectedValue);
            
            DisplayRevenueExpenseSummaryReport();
            DisplaySupportUnit(supportUnit);
            DisplayAllocatedCostsSummaryReport();

            SupportUnitMetricsGridView.EditIndex = -1;
            DisplaySupportUnitMetrics(supportUnit);
            FocusAnchor.Focus();
        }

        protected void SupportUnitMetricsGridView_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            String supportUnit = (String)Session["supportUnit"];
            
            SupportUnitMetricsGridView.EditIndex = -1;

            DisplaySupportUnitMetrics(supportUnit);
            FocusAnchor.Focus();
        }
             
    
    }
 }