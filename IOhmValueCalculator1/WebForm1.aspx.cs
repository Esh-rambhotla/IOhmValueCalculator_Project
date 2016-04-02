using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IOhmValueCalculator1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValueCalculator a = new ValueCalculator();
            a.createLists(DDL1, DDL2, DDL3, DDL4);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var a = new ValueCalculator();
            a.createLists(DDL1, DDL2, DDL3, DDL4);
            Label1.Text = a.CalculateOhmValue(DDL1, DDL2, DDL3, DDL4);
            a.clearList();
            

        }

        
    }
}