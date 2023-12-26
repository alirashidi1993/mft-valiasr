using MFT.Training.DataAccessLayer;
using MFT.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace MFT.Training
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                OstanRepository ostanRepository = new OstanRepository();
                List<Ostan> ostanha = ostanRepository.GetOstans();
                drp_ostans.DataSource = ostanha;
                drp_ostans.DataBind();
                GetOstanShahrs();
                lbl_success.Visible = false;
            }

            if (Request.QueryString["customerId"] != null && Page.IsPostBack==false)
            {
                //برای ویرایش آمده است
                lbl_title.Text = "ویرابش مشتری";
                Button1.Text = "ذخیره";
                int customerId =
                    Convert.ToInt32(Request.QueryString.GetValues("customerId").First());
                CustomerRepository customerRepository = new CustomerRepository();
                Customer moshtari = customerRepository.GetById(customerId);

                txt_firstname.Text = moshtari.FirstName;
                txt_lastname.Text = moshtari.LastName;
                txt_codeMelli.Text = moshtari.CodeMelli;
                txt_mobile.Text = moshtari.Mobile;
                txt_codeMelli.Enabled = false;
                div_password.Visible = false;
                drp_ostans.SelectedValue = moshtari.Shahr.OstanId.ToString();
                GetOstanShahrs();
                drp_shahrs.SelectedValue = moshtari.ShahrId.ToString();
            }
            else
            {
                lbl_title.Text = "ایجاد مشتری";
                Button1.Text = "ثبت";
                //برای ثبت جدید آمده است
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer moshtari = new Customer();
            moshtari.FirstName = txt_firstname.Text;
            moshtari.LastName = txt_lastname.Text;
            moshtari.CodeMelli = txt_codeMelli.Text;
            moshtari.Mobile = txt_mobile.Text;
            moshtari.ShahrId = Convert.ToInt32(drp_shahrs.SelectedValue);

            if (Request.QueryString["customerId"] != null)
            {
                int customerId =
                    Convert.ToInt32(Request.QueryString.GetValues("customerId").First());

                customerRepository.UpdateCustomer(customerId, moshtari);
            }
            else
            {
                moshtari.Password = txt_password.Text;

                customerRepository.CreateCustomer(moshtari);
            }

            Response.Redirect("managecustomers.aspx");
        }

        protected void drp_ostans_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOstanShahrs();
        }

        private void GetOstanShahrs()
        {
            ShahrRepository shahrRepository = new ShahrRepository();

            long selectedOstanId = Convert.ToInt64(drp_ostans.SelectedValue);

            List<Shahr> shahrhayeOstan = shahrRepository.GetShahrsByOstanId(selectedOstanId);
            drp_shahrs.DataSource = shahrhayeOstan;
            drp_shahrs.DataBind();
        }
    }
}