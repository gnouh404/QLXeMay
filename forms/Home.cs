﻿using QLXeMay.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXeMay.forms
{
    public partial class Home : Form
    {
        private int userId;

        public Home(int userId)
        {
            InitializeComponent();
            trangChuUserControl2.BringToFront();
            this.userId = userId;
            //this.Size = new Size(1700, 1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RoundedButton button = sender as RoundedButton;
            if (button != null)
            {
                button.BackColor = Color.LightBlue;
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            sanPhamUserControl3.BringToFront();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            khachHangUserControl3.BringToFront();
        }

        private void profileControl1_Load(object sender, EventArgs e)
        {
            profileControl1.BringToFront();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        public void UpdateProfilePicture(Image newImage)
        {
            pb1.Image = newImage;
            pb1.SizeMode = PictureBoxSizeMode.Zoom;  // Đảm bảo ảnh tự động thu nhỏ/phóng to

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(100,100);
        }
        private void OpenProfileControl()
        {
            // Tạo đối tượng ProfileControl
            ProfileControl profileControl = new ProfileControl();

            // Truyền ảnh từ PictureBox ở trang chủ sang ProfileControl
            profileControl.SetProfilePicture(pb1.Image);

            // Hiển thị ProfileControl
            profileControl.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            trangChuUserControl2.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            donHangUserControl1.BringToFront();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //Close Current Form
                this.Hide();
                //Open Form Login
                Login loginForm = new Login();
                loginForm.Show();
            }
        }
    }
}
