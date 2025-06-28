using Source.Dtos.Account;
using Source.Dtos.Product;
using Source.Models;
using Source.Repository;
using Source.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Source.Views
{
    public partial class Test1 : Form
    {
        private readonly AccountService _accountService;
        private readonly ImageService _imageService;
        public Test1()
        {
         //   InitializeComponent();
            _accountService = new AccountService();
            _imageService = new ImageService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //string s = "AB3A1D7B-23A7-45BD-9E75-1EA2640F9D2B";
            //Guid guid = Guid.Parse(s);
            //var registerResponse = await _imageService.GetImagesByProductId(guid);
            //if (registerResponse != null && registerResponse.Success)
            //{
            //    MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Url}");

            //}
            //else
            //{
            //    MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
            //}

            // Test RegisterAsync

            //RegisterUserDto registerDto = new RegisterUserDto
            //{
            //    Email = "6351071002@st.utc2.edu.vn",
            //    UserName = "testuser3",
            //    Password = "password123A@",
            //    FirstName = "Test",
            //    LastName = "User"
            //};
            //var registerResponse = await _accountService.RegisterAsync(registerDto);
            //if (registerResponse != null && registerResponse.Success)
            //{
            //    MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.UserName}");

            //}
            //else
            //{
            //    MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
            //}

            //        CreateImageDTO imageDTO = new CreateImageDTO()
            //        {
            //            Id = 
            //            public string Url { get; set; }
            //            public string AltText { get; set; }
            //            public Guid ProductId { get; set; }
            //            public DateTime CreatedAt { get; set; }
            //};
            //        var registerResponse = await _imageService.UploadMultipleImages();
            //        if (registerResponse != null && registerResponse.Success)
            //        {
            //            MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Url}");

            //        }
            //        else
            //        {
            //            MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
            //        }
            string s = "AB3A1D7B-23A7-45BD-9E75-1EA2640F9D2B";
            Guid guid = Guid.Parse(s);
            var registerResponse = await _imageService.GetImagesByProductId(guid);
            if (registerResponse != null && registerResponse.Success)
            {
                MessageBox.Show($"Registration Successful\nMessage: {registerResponse.Message}\nUser: {registerResponse.Data.Url}");

            }
            else
            {
                MessageBox.Show($"Registration Failed\nError: {string.Join(", ", registerResponse.Errors)}");
            }

        }

    }
}
