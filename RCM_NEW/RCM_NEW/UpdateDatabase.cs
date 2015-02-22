using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utilities;

namespace RCM_NEW
{
    public class UpdateDatabase
    {
       // DBConnect objDB = new DBConnect();

        public Boolean RevenueSummaryUpdate(String fiscalYear)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;
            objcomm.CommandText = "UpdateRevenueExpenseSummary";
            objcomm.Parameters.Add("@fiscalYear", fiscalYear);

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);

            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        
         }

        public Boolean DifferentialRevenueUpdate(String fiscalYear, String undergradGrad, double rate, double numberStudentsCHG)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "UpdateDifferentialRevenue";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@graduateUndergraduate", undergradGrad);
            objcomm.Parameters.Add("@rate", rate);
            objcomm.Parameters.Add("@numberStudentsCHG", numberStudentsCHG);
            
            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);       
            
            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);
            
            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean RevenueUpdateByCategory(String fiscalYear, String term, double rate, double CHG, String category)
        {

            DataSet ds = new DataSet();
            String storeProcedure = "";

            if (category == "Gross/Undergraduate")
            {
                storeProcedure = "UpdateGrossRevenueUndergrad";
            }
            else if (category == "Gross/Graduate")
            {
                storeProcedure = "UpdateGrossRevenueGrad";
            }
            else if (category == "Exported/Undergraduate")
            {
                storeProcedure = "UpdateExportedRevenueUndergrad";
            }
            else if (category == "Exported/Graduate")
            {
                storeProcedure = "UpdateExportedRevenueGrad";
            }
                       
            
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = storeProcedure;

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@term", term);
            objcomm.Parameters.Add("@rate", rate);
            objcomm.Parameters.Add("@CHG", CHG);

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);

            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Boolean AssessmentsUpdateRate(String fiscalYear, String assessment, double undergradRate, double gradRate)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "UpdateAssessmentsRate";
            
            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@assessment", assessment);
            objcomm.Parameters.Add("@undergradRate", undergradRate);
            objcomm.Parameters.Add("@gradRate", gradRate);

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);

            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean AssessmentsUpdate(String fiscalYear)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "UpdateAssessments";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
           
            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);

            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Boolean CompensationUpdate(String fiscalYear, String accountNumber, double budget, double fringeBenefitRate, String compensationType)
        {
            String storedProcedure = "";

            if (compensationType == "Instractional")
            {
                storedProcedure = "UpdateInstractionalCompensation";
            }
            else if (compensationType == "NonInstractional")
            {
                storedProcedure = "UpdateNonInstractionalCompensation";
            }
                    
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = storedProcedure;

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@accountNumber", accountNumber);
            objcomm.Parameters.Add("@budget", budget);
            objcomm.Parameters.Add("@fringeBenefitRate", fringeBenefitRate);

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

             DBConnect objDB = new DBConnect();
             objDB.DoUpdateUsingCmdObj(objcomm);
            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        
        
        public Boolean NonCompensationExpensesUpdate(String fiscalYear, String expenseType, double budget)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "NonCompensationExpensesUpdate";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@expenseType", expenseType);
            objcomm.Parameters.Add("@budget", budget);

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);
            
            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Boolean CostDriversUpdate(String fiscalYear, String supportUnit, String metricType, double rate, double totalMetrics, double costToAllocate, double metrics)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "UpdateAllocatedCostsMetrics";

            objcomm.Parameters.Add("@fiscalYear", fiscalYear);
            objcomm.Parameters.Add("@supportUnit", supportUnit);
            objcomm.Parameters.Add("@metricType", metricType);
            objcomm.Parameters.Add("@rate", rate);
            objcomm.Parameters.Add("@totalMetrics", totalMetrics);
            objcomm.Parameters.Add("@costToAllocate", costToAllocate);
            objcomm.Parameters.Add("@metrics", metrics);
            
            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;

            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.DoUpdateUsingCmdObj(objcomm);

            int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}