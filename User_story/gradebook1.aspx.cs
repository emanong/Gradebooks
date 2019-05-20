using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace User_story
{
    public partial class gradebook1 : System.Web.UI.Page
    {
        protected GridView gvstudent_grade1;
        string connectionString = @"Data Source=SOPHIAKONOP9442\SQLEXPRESS;Initial Catalog=login;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridView();
            }
        }

        void PopulateGridView()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                if (Session["user"].ToString() == "prof1")
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from student_grade where id_group='АА-11' and subject='Физика'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvstudent_grade1.DataSource = dtbl;
                    gvstudent_grade1.DataBind();
                }

                else if (Session["user"].ToString() == "prof2")
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from student_grade where id_group='АА-11' and subject='Культурология'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvstudent_grade1.DataSource = dtbl;
                    gvstudent_grade1.DataBind();
                }
            }
        }

        protected void gvstudent_grade1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvstudent_grade1.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvstudent_grade1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvstudent_grade1.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvstudent_grade1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    if (Session["user"].ToString() == "prof1")
                    {
                        string query = "update student_grade set num=@num, fio=@fio, avggrade=@avggrade where student_grade_ID = @id and subject='Физика'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@num", (gvstudent_grade1.Rows[e.RowIndex].FindControl("txtnum") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@fio", (gvstudent_grade1.Rows[e.RowIndex].FindControl("txtfio") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@avggrade", (gvstudent_grade1.Rows[e.RowIndex].FindControl("txtavggrade") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvstudent_grade1.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        gvstudent_grade1.EditIndex = -1;
                        PopulateGridView();
                        lblSuccessMessage.Text = "Информация обновлена";
                        lblErrorMessage.Text = "";
                    }

                    else if (Session["user"].ToString() == "prof2")
                    {
                        string query = "update student_grade set num=@num, fio=@fio, avggrade=@avggrade where student_grade_ID = @id and subject='Культурология'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@num", (gvstudent_grade1.Rows[e.RowIndex].FindControl("txtnum") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@fio", (gvstudent_grade1.Rows[e.RowIndex].FindControl("txtfio") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@avggrade", (gvstudent_grade1.Rows[e.RowIndex].FindControl("txtavggrade") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvstudent_grade1.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        gvstudent_grade1.EditIndex = -1;
                        PopulateGridView();
                        lblSuccessMessage.Text = "Информация обновлена";
                        lblErrorMessage.Text = "";
                    }

                }
            }
            catch(Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}