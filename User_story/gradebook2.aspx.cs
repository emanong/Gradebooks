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
    public partial class gradebook2 : System.Web.UI.Page
    {
        protected GridView gvstudent_grade2;
        string connectionString = @"Data Source=SOPHIAKONOP9442\SQLEXPRESS;Initial Catalog=login;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from student_grade where id_group='ББ-22' and subject='Физика'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvstudent_grade2.DataSource = dtbl;
                    gvstudent_grade2.DataBind();
                }

                else if (Session["user"].ToString() == "prof2")
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from student_grade where id_group='ББ-22' and subject='Культурология'", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gvstudent_grade2.DataSource = dtbl;
                    gvstudent_grade2.DataBind();
                }
            }
        }

        protected void gvstudent_grade2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvstudent_grade2.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void gvstudent_grade2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvstudent_grade2.EditIndex = -1;
            PopulateGridView();
        }

        protected void gvstudent_grade2_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
                        sqlCmd.Parameters.AddWithValue("@num", (gvstudent_grade2.Rows[e.RowIndex].FindControl("txtnum") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@fio", (gvstudent_grade2.Rows[e.RowIndex].FindControl("txtfio") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@avggrade", (gvstudent_grade2.Rows[e.RowIndex].FindControl("txtavggrade") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvstudent_grade2.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        gvstudent_grade2.EditIndex = -1;
                        PopulateGridView();
                        lblSuccessMessage.Text = "Информация обновлена";
                        lblErrorMessage.Text = "";
                    }

                    else if (Session["user"].ToString() == "prof2")
                    {
                        string query = "update student_grade set num=@num, fio=@fio, avggrade=@avggrade where student_grade_ID = @id and subject='Культурология'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@num", (gvstudent_grade2.Rows[e.RowIndex].FindControl("txtnum") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@fio", (gvstudent_grade2.Rows[e.RowIndex].FindControl("txtfio") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@avggrade", (gvstudent_grade2.Rows[e.RowIndex].FindControl("txtavggrade") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvstudent_grade2.DataKeys[e.RowIndex].Value.ToString()));
                        sqlCmd.ExecuteNonQuery();
                        gvstudent_grade2.EditIndex = -1;
                        PopulateGridView();
                        lblSuccessMessage.Text = "Информация обновлена";
                        lblErrorMessage.Text = "";
                    }

                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}