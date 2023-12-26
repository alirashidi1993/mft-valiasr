using MFT.Training.DataAccessLayer;
using MFT.Training.Repositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace MFT.Training
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ReloadData();
            }

        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> moshtariha = customerRepository.SearchCustomers(searchValue:txt_search.Text);
            grid_customers.DataSource = moshtariha;
            grid_customers.DataBind();
        }

        protected void grid_customers_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int selectedCustomerId = (int)e.Keys["Id"];
            if (selectedCustomerId != 0)
            {
                CustomerRepository customerRepository = new CustomerRepository();
                customerRepository.DeleteCustomer(selectedCustomerId);
                RefreshPage();
            }
        }

        protected void grid_customers_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            grid_customers.EditIndex = e.NewEditIndex;
            ReloadData();
        }

        protected void grid_customers_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int selectedCustomerId = (int)e.Keys["Id"];
            CustomerRepository customerRepository = new CustomerRepository();
            Customer moshtari = new Customer();
            moshtari.FirstName = e.NewValues["FirstName"].ToString();
            moshtari.LastName = e.NewValues["LastName"].ToString();
            moshtari.CodeMelli = e.NewValues["CodeMelli"].ToString();
            moshtari.Mobile = e.NewValues["Mobile"].ToString();
            customerRepository.UpdateCustomer(selectedCustomerId, moshtari);
            RefreshPage();

        }
        private void ReloadData()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> moshtariha = customerRepository.SearchCustomers();
            grid_customers.DataSource = moshtariha;
            grid_customers.DataBind();
        }
        private void RefreshPage()
        {
            Response.Redirect("managecustomers.aspx");
        }
        protected void grid_customers_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            grid_customers.EditIndex = -1;
            ReloadData();
        }

        protected void grid_customers_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            ReloadData();
            grid_customers.PageIndex = e.NewPageIndex;
            grid_customers.DataBind();
        }
    }
}