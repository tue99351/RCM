using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utilities;

namespace RCM_Model_Project
{
    public class RCMDatabaseUpdate
    {

        public Boolean UpdateAllocatedCosts()
        {




            return true;
        }


        public void DifferentialRevenueUpdate(String fiscalYear, int undergradStudents, double undergradRate, int gradCHG, double gradRate)
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "DifferentialRevenueUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);
            objcomm.Parameters.Add("@numberUndergradStudents", undergradStudents);
            objcomm.Parameters.Add("@undergradRate", undergradRate);
            objcomm.Parameters.Add("@gradStudentsCHG", gradCHG);
            objcomm.Parameters.Add("@gradRate", gradRate);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

        }
           
        
        public void DirectExpensesUpdate(String fiscalYear)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "DirectExpensesUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);


            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);
        }

        public void NonCompensationExpensesUpdate(String fiscalYear, String expenseType, String accountNum, double budget)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "NonCompensationExpensesUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);
            objcomm.Parameters.Add("@expenseType", expenseType);
            objcomm.Parameters.Add("@budget", budget);


            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);
                       
        }

        public void NonInstractionalCompensationUpdate(String fiscalYear, int accountNumber, double budget, double fringeBenefitRate)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "NonInstractionalCompensationUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);
            objcomm.Parameters.Add("@accountNumber", accountNumber);
            objcomm.Parameters.Add("@budget", budget);
            objcomm.Parameters.Add("@fringeBenefitRate", fringeBenefitRate);


            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

            //int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            //if (result == 1)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


        }

        public void InstractionalCompensationUpdate(String fiscalYear, int accountNumber, double budget, double fringeBenefitRate)
        {
                    
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "InstractionalCompensationUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);
            objcomm.Parameters.Add("@accountNumber", accountNumber);
            objcomm.Parameters.Add("@budget", budget);
            objcomm.Parameters.Add("@fringeBenefitRate", fringeBenefitRate);
            

             DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

            //int result = int.Parse(objcomm.Parameters["@result"].Value.ToString());

            //if (result == 1)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}


        }

        public Boolean AssestmentsCreate()
        {
            String fiscalYearId = "FY2015";
            double financialAidRateGrad = 0.019;
            double plandFundFeeGradRate = 0.0508;
            double financialAidRateUndergrad = 0.176;
            double plandFundFeeRateUndergrad = 0.0508;
            
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "AssesmentsUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYearId);
            objcomm.Parameters.Add("@financialAidRateGrad", financialAidRateGrad);
            objcomm.Parameters.Add("@plandFundFeeGradRate", plandFundFeeGradRate);
            objcomm.Parameters.Add("@financialAidRateUndergrad", financialAidRateUndergrad);
            objcomm.Parameters.Add("@plandFundFeeRateUndergrad", plandFundFeeRateUndergrad);
            

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;


            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

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

        public Boolean AssestmentsUpdate(String fiscalYear,double financialAidRateGrad,double plandFundFeeGradRate,double financialAidRateUndergrad,double plandFundFeeRateUndergrad )
        {
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "AssesmentsUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);
            objcomm.Parameters.Add("@financialAidRateGrad", financialAidRateGrad);
            objcomm.Parameters.Add("@plandFundFeeGradRate", plandFundFeeGradRate);
            objcomm.Parameters.Add("@financialAidRateUndergrad", financialAidRateUndergrad);
            objcomm.Parameters.Add("@plandFundFeeRateUndergrad", plandFundFeeRateUndergrad);


            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;


            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

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

        public Boolean RevenueSummaryUpdate(String fiscalYear)
        {

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "RevenueExpenseSummaryUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYear);
            


            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;


            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

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

        public Boolean CHG()
        {
            String fiscalYearId = "FY2014";
            String termId = "SS1_2014";
            double undergradRate = 567;
            double gradRate = 805;
            double exportUndergradRate = 540;
            double exportGradRate = 805;            
            double undergradGrossCHG = 3038;
            double gradGrossCHG = 68;
            double undergradExportedCHG = 744;
            double gradExportedCHG = 19;

            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "CHG_Update";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYearId);
            objcomm.Parameters.Add("@termId", termId);
            objcomm.Parameters.Add("@undergradRate", undergradRate);
            objcomm.Parameters.Add("@gradRate", gradRate);
            objcomm.Parameters.Add("@exportUndergradRate", exportUndergradRate);
            objcomm.Parameters.Add("@exportGradRate", exportGradRate);            
            objcomm.Parameters.Add("@gradGrossCHG", gradGrossCHG);
            objcomm.Parameters.Add("@undergradGrossCHG", undergradGrossCHG);
            objcomm.Parameters.Add("@undergradExportedCHG", undergradExportedCHG);
            objcomm.Parameters.Add("@gradExportedCHG", gradExportedCHG);

            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;


            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

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


        public Boolean TuitionDifferentialRevenue()
        {
            String fiscalYearId = "FY2014";
            double numberUndergradStudents = 2865; //Where does it come from?
            double undergradRate = 900;
            double gradStudentsCHG = 1312; //Why 1312?
            double gradRate = 60;
            
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "TuitionDifferentialRevenueUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYearId);
            objcomm.Parameters.Add("@numberUndergradStudents", numberUndergradStudents);
            objcomm.Parameters.Add("@undergradRate", undergradRate);
            objcomm.Parameters.Add("@gradStudentsCHG", gradStudentsCHG);
            objcomm.Parameters.Add("@gradRate", gradRate);
            
            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;


            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

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

        public void NonCompensationExpenses(String fiscalYearId, DataTable dt)
        {
           
            foreach (DataRow row in dt.Rows)
            {
                String expenseType = row[0].ToString();
                String accountNum = row[1].ToString();
                Double budget = Double.Parse(row[2].ToString());
            
                 
            SqlCommand objcomm = new SqlCommand();

            objcomm.CommandType = CommandType.StoredProcedure;

            objcomm.CommandText = "NonCompensationExpensesUpdate";

            objcomm.Parameters.Add("@fiscalYearId", fiscalYearId);
            objcomm.Parameters.Add("@expenseType", expenseType);
            objcomm.Parameters.Add("@accountNum", accountNum);
            objcomm.Parameters.Add("@budget", budget);
            
            SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
            outputParameter.Direction = ParameterDirection.ReturnValue;


            objcomm.Parameters.Add(outputParameter);

            DBConnect objDB = new DBConnect();
            objDB.GetDataSetUsingCmdObj(objcomm);

             }
        }

        public void NonInstractionalCompensation(String fiscalYearId, DataTable dt)
        {
                
            foreach (DataRow row in dt.Rows)
            {
                int accountNumber = int.Parse(row[0].ToString());
                
                                  
                Double fringeBenefitRate = Double.Parse(row[1].ToString());
                
                
                Double budget = Double.Parse(row[2].ToString());


                SqlCommand objcomm = new SqlCommand();

                objcomm.CommandType = CommandType.StoredProcedure;

                objcomm.CommandText = "NonInstractionalCompensationUpdate";

                objcomm.Parameters.Add("@fiscalYearId", fiscalYearId);
                objcomm.Parameters.Add("@accountNumber", accountNumber);
                objcomm.Parameters.Add("@fringeBenefitRate", fringeBenefitRate);
                objcomm.Parameters.Add("@budget", budget);

                DBConnect objDB = new DBConnect();
                objDB.GetDataSetUsingCmdObj(objcomm);

            }
        }

        public void InstractionalCompensation(String fiscalYearId, DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                int accountNumber = int.Parse(row[0].ToString());


                Double fringeBenefitRate = Double.Parse(row[1].ToString());


                Double budget = Double.Parse(row[2].ToString());


                SqlCommand objcomm = new SqlCommand();

                objcomm.CommandType = CommandType.StoredProcedure;

                objcomm.CommandText = "InstractionalCompensationUpdate";

                objcomm.Parameters.Add("@fiscalYearId", fiscalYearId);
                objcomm.Parameters.Add("@accountNumber", accountNumber);
                objcomm.Parameters.Add("@fringeBenefitRate", fringeBenefitRate);
                objcomm.Parameters.Add("@budget", budget);

                DBConnect objDB = new DBConnect();
                objDB.GetDataSetUsingCmdObj(objcomm);

            }
        }

        public void FringeBenefits(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                String accountCode = row[0].ToString();
                Double gvrnSponsoredPrjRates = Double.Parse(row[1].ToString());
                Double clinicalFacultyRates = Double.Parse(row[2].ToString());
                Double otherRates = Double.Parse(row[3].ToString());

                SqlCommand objcomm = new SqlCommand();

                objcomm.CommandType = CommandType.StoredProcedure;

                objcomm.CommandText = "FringeBenefitUpdate";

                objcomm.Parameters.Add("@accountCode", accountCode);
                objcomm.Parameters.Add("@gvrnSponsoredPrjRates", gvrnSponsoredPrjRates);
                objcomm.Parameters.Add("@clinicalFacultyRates", clinicalFacultyRates);
                objcomm.Parameters.Add("@otherRates", otherRates);

                //SqlParameter outputParameter = new SqlParameter("@result", DbType.Int32);
                //outputParameter.Direction = ParameterDirection.ReturnValue;


                //objcomm.Parameters.Add(outputParameter);

                DBConnect objDB = new DBConnect();
                objDB.GetDataSetUsingCmdObj(objcomm);

            }
        }
    
    }
}