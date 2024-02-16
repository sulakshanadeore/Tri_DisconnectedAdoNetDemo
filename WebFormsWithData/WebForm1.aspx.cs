using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DisconnectedLibrary;
namespace WebFormsWithData
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeptDAL dal=new DeptDAL();
            DataView dv=dal.FilterData();
            GridView1.DataSource = dv;
            GridView1.DataBind();


            DataView dv1 = dal.FilterDataByCity();
            GridView2.DataSource = dv1;
            GridView2.DataBind();


            DataView dv2 = dal.SortData();
            GridView3.DataSource = dv2;
            GridView3.DataBind();




        }
    }
}