using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using ADO.Code;

namespace ADO.Dialog
{
    public partial class EditRole : Form
    {
        private User user;

        public EditRole(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadData();
        }

        private void LoadData()
        {
            var roles = RoleBus.Instance.GetRoles();
            foreach(var item in roles)
            {
                RadioButton radio = new RadioButton();
                radio.Name = item.roldID.ToString();
                radio.Text = item.roleName;
                if(user.role_id == item.roldID)
                {
                    radio.Checked = true;
                }
                flowLayoutPanel1.Controls.Add(radio);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<RadioButton> radios = new List<RadioButton>();
            foreach (Control p in flowLayoutPanel1.Controls)
            {
                if (p.GetType() == typeof(RadioButton))
                {
                    radios.Add(p as RadioButton);
                }
            }
            var temp = radios.Where(x => x.Checked).FirstOrDefault();
            if(UserBus.Instance.SuaQuyen(user.user_name, int.Parse(temp.Name)) > 0)
            {
                this.Close();
                MessageBox.Show("Thành công");
            }
        }
    }
}
