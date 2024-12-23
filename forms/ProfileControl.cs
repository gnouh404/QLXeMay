﻿using QLXeMay.data_connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLXeMay.forms
{
    public partial class ProfileControl : UserControl
    {
        public ProfileControl()
        {
            InitializeComponent();
            lblUserName.Text = "HARRY KANE";
            lblUserName.Font = new Font("Arial", 14, FontStyle.Bold);

            //Button buttonSaveImage = new Button();
            //buttonSaveImage.Text = "Lưu";
            //buttonSaveImage.Location = new Point(btnChangeImg.Right + 10, btnChangeImg.Top); // Đặt nút cạnh nút Chọn ảnh
            //grb1.Controls.Add(buttonSaveImage);

            // Xử lý sự kiện khi nhấn nút Lưu
            buttonSaveImage.Click += new EventHandler(SaveImage_Click);
        }
        private void SaveImage_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem PictureBox có ảnh hay không
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc lưu nếu chưa có ảnh
            }

            // Nếu có ảnh, tiến hành lưu ảnh
            Image selectedImage = pictureBox1.Image;

            // Thực hiện các thao tác lưu ảnh vào cơ sở dữ liệu hoặc file...

            // Đồng bộ ảnh với PictureBox ở trang chủ
            Home mainForm = (Home)this.ParentForm;
            mainForm.UpdateProfilePicture(selectedImage);

            MessageBox.Show("Ảnh đã được lưu và đồng bộ với trang chủ!");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lblUserName.Text = $"{txtFirstName.Text} {txtLastName.Text}";
            // Lấy dữ liệu từ các textbox
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string city = txtCity.Text.Trim();
            string dateOfBirth = txtDateOfBirth.Text.Trim();
            string postcode = txtPassWord.Text.Trim();
            string country = txtCountry.Text.Trim();

            // Kiểm tra dữ liệu
            if (!IsValidFirstName(firstName))
            {
                MessageBox.Show("First Name không được để trống.");
                return;
            }

            if (!IsValidLastName(lastName))
            {
                MessageBox.Show("Last Name không được để trống.");
                return;
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Phone Number phải có 10 chữ số.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email phải đúng định dạng.");
                return;
            }

            if (!IsValidDateOfBirth(dateOfBirth))
            {
                MessageBox.Show("Ngày sinh phải đúng định dạng ngày/tháng/năm.");
                return;
            }

            if (!IsValidPostcode(postcode))
            {
                MessageBox.Show("Postcode phải là số.");
                return;
            }

            if (!IsValidCity(city))
            {
                MessageBox.Show("City không được để trống.");
                return;
            }

            if (!IsValidCountry(country))
            {
                MessageBox.Show("Country không được để trống.");
                return;
            }

            //// Nếu tất cả thông tin hợp lệ, thực hiện cập nhật
            //// Gọi hàm cập nhật dữ liệu ở đây

            //ClassQLXM kn = new ClassQLXM();
            //DateTime dob;
            //DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);

            //// Chèn thông tin vào bảng UserName
            //kn.InsertUser(firstName, lastName, phoneNumber, email, city, dob, postcode, country);

            MessageBox.Show("Cập nhật thành công!");

            // Truy cập form chính (trang chủ) để cập nhật PictureBox
            // Lấy ảnh từ PictureBox trong ProfileControl
            Image updatedProfilePicture = pictureBox1.Image;

            // Truy cập MainForm và cập nhật ảnh trong PictureBox
            Home mainForm = (Home)this.ParentForm;
            mainForm.UpdateProfilePicture(updatedProfilePicture);
        }
        private bool IsValidFirstName(string firstName)
        {
            return Regex.IsMatch(firstName, @"^[a-zA-Z]+$");
        }

        private bool IsValidLastName(string lastName)
        {
            return Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^0\d{9}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidDateOfBirth(string dateOfBirth)
        {
            return DateTime.TryParseExact(dateOfBirth, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _);
        }

        private bool IsValidPostcode(string postcode)
        {
            return Regex.IsMatch(postcode, @"^\d+$");
        }

        private bool IsValidCity(string city)
        {
            return Regex.IsMatch(city, @"^[a-zA-Z]+$");
        }

        private bool IsValidCountry(string country)
        {
            return Regex.IsMatch(country, @"^[a-zA-Z]+$");
        }
        private void UpdateNameLabel(object sender, EventArgs e)
        {
            lblUserName.Text = $"{txtFirstName.Text} {txtLastName.Text}";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
        }
        private void MakePictureBoxCircular(PictureBox pictureBox)
        {
            
        }

        private void btnChangeImg_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại chọn file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Chỉ cho phép chọn file hình ảnh
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            // Kiểm tra nếu người dùng chọn file và nhấn OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Đặt hình ảnh vào PictureBox1
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }
        public void SetProfilePicture(Image profileImage)
        {
            pictureBox1.Image = profileImage;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Resize(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(200, 200);
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {

        }
    }
}