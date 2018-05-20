using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class ViewSalesBetweenDates : System.Web.UI.Page
    {
        ViewSellsManager aViewSellsManager = new ViewSellsManager();
        private DateTime toDate, fromDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDateCalendar.Visible = false;
                toDateCalendar.Visible = false;
            }
        }

        protected void fromImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (fromDateCalendar.Visible)
            {
                fromDateCalendar.Visible = false;
            }
                
            else
            {
                fromDateCalendar.Visible = true;
            }
        }

        protected void toImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (toDateCalendar.Visible)
            {
                toDateCalendar.Visible = false;
            }
            else
            {
                toDateCalendar.Visible = true;
            }
        }

        protected void fromDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            fromTextBox.Text = fromDateCalendar.SelectedDate.ToString("yyyy-MM-dd");
            
            fromDateCalendar.Visible = false;
        }

        protected void toDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            toTextBox.Text = toDateCalendar.SelectedDate.ToString("yyyy-MM-dd");
            
            toDateCalendar.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(fromTextBox.Text);
            toDate = Convert.ToDateTime(toTextBox.Text);
            if (toDate >= fromDate )
            {
                List<ViewSells> viewSellses = aViewSellsManager.ViewSellses(fromDate, toDate);
                if (viewSellses.Count != 0)
                {
                    viewSellsGridView.DataSource = viewSellses;
                    viewSellsGridView.DataBind();
                }
                else
                {
                    salesMsgLabel.Text = "No Sales Between these dates.";
                }
            }
            else
            {
                salesMsgLabel.Text ="Pick right date.";
            }
        }
    }
}