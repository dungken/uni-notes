using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Source.Dtos.Account;
using Source.Models;
using Source.Service;
using Source.Utils;
using Source.Views.Admin;
using Source.Views.Custommer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.Views
{
    public partial class Login : Form
    {
        private readonly AccountService _AccountService;
        public static int frmLoginLocationX, frmLoginLocationY;
        public static int pnlChildFormLocationX, pnlChildFormLocationY;
        public static int frmWith, frmHeight;

        public static int parentX, parentY;
        private readonly UserService _userService;

        private string accessToken;
        public Login()
        {
            InitializeComponent();
            _AccountService = new AccountService();
            _userService = new UserService();
        }
        // Tạo Form con 
        private Form? activeForm = null;
        private void openChildForm(Form childForm)
        {
            frmLoginLocationX = this.Location.X;
            frmLoginLocationY = this.Location.Y;
            frmHeight = this.Height;
            frmWith = this.Width;
            pnlChildFormLocationX = pnlLogin.Location.X;
            pnlChildFormLocationY = pnlLogin.Location.Y;
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

        }

        private void btnResgister_Click(object sender, EventArgs e)
        {
            openChildForm(new Resgister());
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var emailOrUsername = txtUsername.Text;
                var password = txtPassWord.Text;

                // Validate input
                if (string.IsNullOrWhiteSpace(emailOrUsername))
                {
                    MessageBox.Show("Please enter your email or username.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter your password.");
                    return;
                }

                var loginUserDto = new LoginUserDto
                {
                    EmailOrUsername = emailOrUsername,
                    Password = password
                };


                var response = await _AccountService.LoginAsync(loginUserDto);


                // If token is null, login failed
                if (response == null)
                {
                    MessageBox.Show("Your information is not corret");
                }
                else
                {
                    Config.token = response.Data.Token;
                    var p = await _AccountService.CheckEnableVerifyAsync(emailOrUsername);
                    if (p.Data.TwoFactorEnabled == true)
                    {
                        MessageBox.Show("Please verify your email before login");
                        Form modalBackground = new Form();

                        using (_2StepVerifycationForLogin modal = new _2StepVerifycationForLogin())
                        {
                            modalBackground.StartPosition = FormStartPosition.Manual;
                            modalBackground.FormBorderStyle = FormBorderStyle.None;
                            modalBackground.Opacity = 0.50d;
                            modalBackground.Size = new System.Drawing.Size(this.Width, this.Height);


                            modalBackground.Location = new Point(this.Location.X, this.Location.Y);
                            modalBackground.ShowInTaskbar = false;
                            modalBackground.Show();
                            modal.Owner = modalBackground;

                            parentX = this.Location.X + 50 ;
                            parentY = this.Location.Y  ;
                            modal.ShowDialog();
                            modalBackground.Dispose();

                        }
                        if (_2StepVerifycationForLogin.isVerifyEmail)
                        {
                            Config.token = response.Data.Token;
                            MessageBox.Show("Login successful! ");
                            var user = await _userService.GetUserByToken();
                            if (user.Data.Roles.FirstOrDefault() == "Customer")
                            {
                                openChildForm(new MainForm());
                            }
                            else if (user.Data.Roles.FirstOrDefault() == "Admin")
                            {
                                openChildForm(new MainFormAdmin());
                            }
                            //openChildForm(new MainForm());

                            //openChildForm(new MainFormAdmin());

                        }
                        else
                        {
                            MessageBox.Show("Login failed: Your email is not verify");
                        }
                    }
                    else
                    {
                        //Config.token = response.Data.Token;
                        if (accessToken == null)
                        {

                            var userId = await _userService.GetUserIdByToken();

                            var user = await _userService.GetUserById(userId.Data.UserId);
                            if (user.Data.Roles.FirstOrDefault() == "Customer")
                            {
                                openChildForm(new MainForm());
                            }
                            else if (user.Data.Roles.FirstOrDefault() == "Admin")
                            {
                                openChildForm(new MainFormAdmin());
                            }
                            MessageBox.Show("Login successful! ");

                        }else
                        {
                            openChildForm(new MainForm());
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }

        }
        private void lblForget_Click(object sender, EventArgs e)
        {
            openChildForm(new ForgetPassword());
            //ForgetPassword forgetPassword = new ForgetPassword();
            //forgetPassword.Show();
        }
        private async void btnLoginWGoogle_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "credentials.json");

                // Đọc tệp credentials.json
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Tệp credentials.json không tồn tại.");
                    return;
                }

                string credentialsJson = await File.ReadAllTextAsync(filePath);
                var jsonObject = JObject.Parse(credentialsJson);

                // Lấy thông tin từ JSON
                string clientId = jsonObject["web"]?["client_id"]?.ToString();
                string clientSecret = jsonObject["web"]?["client_secret"]?.ToString();
                var redirectUris = jsonObject["web"]?["redirect_uris"] as JArray;
                string redirectUri = redirectUris?.FirstOrDefault()?.ToString();

                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret) || string.IsNullOrEmpty(redirectUri))
                {
                    MessageBox.Show("Thông tin trong credentials.json không hợp lệ.");
                    return;
                }

                // Lấy mã xác thực từ Google
                string authCode = await GetAuthCodeAsync(clientId, redirectUri);
                if (string.IsNullOrEmpty(authCode))
                {
                    MessageBox.Show("Không nhận được mã xác thực từ Google.");
                    return;
                }

                // Đổi mã xác thực lấy access_token
                TokenResponse tokens = await ExchangeAuthCodeForTokens(authCode, clientId, clientSecret, redirectUri);
                if (!string.IsNullOrEmpty(tokens?.AccessToken))
                {
                    // Gọi API Google để lấy thông tin người dùng
                    await GetUserInfo(tokens.AccessToken);
                    SocialLoginDto socialLogin = new SocialLoginDto()
                    {
                        AccessToken = tokens.AccessToken,
                        Provider = "Google"
                    };
                    var resp = await _AccountService.SocialLogin(socialLogin);
                }
                else
                {
                    MessageBox.Show("Không thể lấy AccessToken.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private async Task<string> GetAuthCodeAsync(string clientId, string redirectUri)
        {
            using (var httpListener = new HttpListener())
            {
                httpListener.Prefixes.Add(redirectUri);
                httpListener.Start();

                string authUrl = $"https://accounts.google.com/o/oauth2/v2/auth?" +
                                 $"client_id={clientId}&response_type=code&scope=openid%20email%20profile&" +
                                 $"redirect_uri={Uri.EscapeDataString(redirectUri)}&access_type=offline";

                // Mở trình duyệt để người dùng đăng nhập
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = authUrl,
                    UseShellExecute = true
                });

                var context = await httpListener.GetContextAsync();
                string code = context.Request.QueryString["code"];
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("Không nhận được mã xác thực từ Google.");
                }

                // Hiển thị thông báo đăng nhập thành công trong trình duyệt
                using (var writer = new StreamWriter(context.Response.OutputStream))
                {
                    writer.WriteLine("<html><body><h1>Đăng nhập thành công!</h1><p>Bạn có thể quay lại ứng dụng.</p></body></html>");
                }

                context.Response.StatusCode = 200;
                context.Response.Close();

                return code;
            }
        }

        private async Task<TokenResponse> ExchangeAuthCodeForTokens(string authCode, string clientId, string clientSecret, string redirectUri)
        {
            var queryParams = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("code", authCode),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("redirect_uri", redirectUri),
            new KeyValuePair<string, string>("grant_type", "authorization_code")
        };

            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(queryParams);
                var response = await client.PostAsync("https://oauth2.googleapis.com/token", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TokenResponse>(responseContent);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Lỗi khi trao đổi mã xác thực: {response.StatusCode}, Nội dung: {errorContent}");
                }
            }
        }

        private async Task GetUserInfo(string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await client.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");

                if (response.IsSuccessStatusCode)
                {
                    var userInfo = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thông tin người dùng: {userInfo}");
                    openChildForm(new MainForm());
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API request failed. Error: {errorContent}");
                }
            }
        }
    }

    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }


}