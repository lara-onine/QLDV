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
    public partial class EventDialog : Form
    {
        public delegate void addEvenvtSuccess();
        public event addEvenvtSuccess eventSuccess;

        private User user;
        private Events events;

        public Extention.StatusDialog type { get; set; }

        public EventDialog(Extention.StatusDialog type, User user, Events events = null)
        {
            InitializeComponent();
            endTime.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.user = user;
            if (events != null)
            {
                this.events = events;
                txtTitle.Text = events.tieu_de;
                txtPlace.Text = events.dia_diem;
                txtContent.Text = events.noi_dung;
                endTime.Value = events.thoi_gian;
            }
            this.type = type;
            if (type.Equals("is_create"))
            {
                lblTitle.Text = "Thêm sự kiện";
                button1.Text = "Thêm";
            }

            if (type.Equals("is_update"))
            {
                lblTitle.Text = "Sửa sự kiện";
                button1.Text = "Lưu";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            bunifuImageButton1.BackColor = Color.FromArgb(232, 17, 35);
            bunifuImageButton1.Image = ADO.Properties.Resources.Delete_Light_96px;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            bunifuImageButton1.BackColor = Color.Transparent;
            bunifuImageButton1.Image = ADO.Properties.Resources.Delete_96px;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == Extention.StatusDialog.IS_CREATE)
            {
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sự kiên", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtPlace.Text))
                    {
                        MessageBox.Show("Vui lòng nhập địa điểm", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtContent.Text))
                        {
                            MessageBox.Show("Vui lòng nhập mô tả", "Lỗi", MessageBoxButtons.OK);
                        }
                        else
                        {
                            Events temp = new Events();
                            temp.tieu_de = txtTitle.Text;
                            temp.dia_diem = txtPlace.Text;
                            temp.noi_dung = txtContent.Text;
                            temp.thoi_gian = endTime.Value;
                            temp.thoi_gian_tao = DateTime.Now;
                            temp.user_name = user.user_name;
                            var result = EventsBus.Instance.ThemSuKien(temp);
                            if (result == -1)
                            {
                                MessageBox.Show("Thêm dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK);
                            }
                            else
                            {
                                txtTitle.Clear();
                                txtContent.Clear();
                                txtPlace.Clear();
                                MessageBox.Show("Thêm sự kiện thành công", "Thông báo", MessageBoxButtons.OK);
                                if (eventSuccess != null)
                                {
                                    eventSuccess();
                                }
                            }
                        }
                    }
                }
            }

            if (type == Extention.StatusDialog.IS_UPDATE)
            {
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sự kiên", "Lỗi", MessageBoxButtons.OK);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtPlace.Text))
                    {
                        MessageBox.Show("Vui lòng nhập địa điểm", "Lỗi", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtContent.Text))
                        {
                            MessageBox.Show("Vui lòng nhập mô tả", "Lỗi", MessageBoxButtons.OK);
                        }
                        else
                        {
                            Events temp = new Events();
                            temp.tieu_de = txtTitle.Text;
                            temp.dia_diem = txtPlace.Text;
                            temp.noi_dung = txtContent.Text;
                            temp.thoi_gian = endTime.Value;
                            temp.thoi_gian_tao = DateTime.Now;
                            temp.user_name = user.user_name;
                            temp.ma_sk = events.ma_sk;
                            var result = EventsBus.Instance.SuaSuKien(temp);
                            if (result == -1)
                            {
                                MessageBox.Show("Sửa sự kiện không thành công", "Lỗi", MessageBoxButtons.OK);
                            }
                            else
                            {
                                txtTitle.Clear();
                                txtContent.Clear();
                                txtPlace.Clear();
                                MessageBox.Show("Sửa sự kiện thành công", "Thông báo", MessageBoxButtons.OK);
                                if (eventSuccess != null)
                                {
                                    eventSuccess();
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
