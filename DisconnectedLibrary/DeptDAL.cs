﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Data;
namespace DisconnectedLibrary
{
    public class DeptDAL
    {


        public bool AddDept(Dept dept) 
        {
            bool operationStatus = false;
            string str=ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);

            SqlDataAdapter da = new SqlDataAdapter("Select * from dept", cn);

            DataSet ds=new DataSet();
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;//Primary key info about the table, also brings the identity 
            //columns

            da.Fill(ds,"dept");//data table---we disconnected, and u r on your app server
           DataRow newrow= ds.Tables["dept"].NewRow();//creating a schema row for the datatable

            //DataTable dt_dept =ConnectToServer();
            //DataRow newrow=dt_dept.NewRow();
            newrow["Dname"] = dept.Dname;
            newrow["Loc"] = dept.Loc;
            newrow["MgrName"] = dept.MgrName;
            ds.Tables["dept"].Rows.Add(newrow);//adding new row to the existing rows in the dataset's datatable(dept)

            //Now submit the newly added row to the database, for that --SqlCommandBuilder
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);//insert command generated by Commandbuilder, taking help of the column info
                                                               //from the data adapter

            da.Update(ds.Tables["dept"]);





            //bool operationStatus = false;
            //string str=ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            //SqlConnection cn = new SqlConnection(str);



            //     cn.Close();
            //   cn.Dispose();


            return operationStatus;
        
        }

        public bool EditDept(Dept dept, int deptno) 
        {


            bool operationStatus = false;
            string str = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);
                     cn.Close();
                cn.Dispose();

            
            return operationStatus;

        }
        public bool RemoveDept(int deptno) 
        {
            bool operationStatus = false;
            string str = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);

        
            operationStatus = true;
            cn.Close();
            cn.Dispose();

            return operationStatus;
        
        }

        public List<Dept> GetDeptList() 
        {
            
            string str = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);

            SqlDataAdapter da = new SqlDataAdapter("Select * from dept", cn);

            DataSet ds = new DataSet();
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;//Primary key info about the table, also brings the identity 
            //columns
            da.Fill(ds, "dept");


            List<Dept> deptlist = new List<Dept>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow drow = ds.Tables[0].Rows[i];
                Dept d = new Dept();

                d.Deptno=Convert.ToInt32(drow[0]);
                d.Dname = drow[1].ToString();
                d.Loc = drow[2].ToString();
                d.MgrName = drow[3].ToString();
                deptlist.Add(d);



            }
            


        


            return deptlist;
             
        }

        public int DeptNumber() {
            string str = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);
            int cnt = 0;

            return cnt;



        }


       public Dept FindDept(int deptno) {

            Dept dept = new Dept();
            string str = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);

            
            cn.Close();
            cn.Dispose();
            return dept;
        }

    }

   
}
