using System;
using System.Collections.Generic;

namespace Bankv1.entity
{
    public class Account
    {
        public enum ActiveStatus
        {
            INACTIVE = 0,
            ACTIVE = 1,
            LOCKED = 2
        }
        private string _username { get; set; }
        private string _password { get; set; }
        private string _confirmPassword { get; set; }
        private string _salt { get; set; }
        private string _accountNumber { get; set; } // Số tài khoản
        private string _identityCard { get; set; } //chứng minh nhân dân
        private decimal _balance { get; set; } //số dư
        private string _phone { get; set; }
        private string _email { get; set; }
        private string _fullName { get; set; }
        private string _createdAt { get; set; }
        private string _updateAt { get; set; }
        private ActiveStatus _status { get; set; }

        public void GenerateAccountNumber()
        {
            this._accountNumber = Guid.NewGuid().ToString();
        }

        public Account(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public Account(string username, string password, string confirmPassword, string identityCard,
        string phone, string email, string fullName)
        {
            GenerateAccountNumber();
            _username = username;
            _password = password;
            _confirmPassword = confirmPassword;
            _identityCard = identityCard;
            _phone = phone;
            _email = email;
            _fullName = fullName;
        }

        public Account(string username, string password, string salt, string accountNumber, string identityCard,
            decimal balance, string phone, string email, string fullName, string createdAt, string updatedAt,
            ActiveStatus status)
        {
            _username = username;
            _password = password;
            _salt = salt;
            _accountNumber = accountNumber;
            _identityCard = identityCard;
            _balance = balance;
            _phone = phone;
            _email = email;
            _fullName = fullName;
            _createdAt = createdAt;
            _updateAt = updatedAt;
            _status = status;
        }

        public Account()
        {

        }

        // kiểm tra thông tin nhập khi đăng ký tài khoản
        public Dictionary<string, string> checkValid()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this._username))
            {
                errors.Add("username", "Username can not be null or empty.");
            }
            else if (this._username.Length < 6)
            {
                errors.Add("username", "Username is too short.");
            }

            if (string.IsNullOrEmpty(this._password))
            {
                errors.Add("password", "Password can not be null or empty.");
            }
            else if (this._username != this._confirmPassword)
            {
                errors.Add("password", "Confirm password does not match.");
            }
            return errors;
        }

        // Kiểm tra thông tin nhập khi đăng nhập tài khoản
        public Dictionary<string, string> ValidLoginInformation()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(this._username))
            {
                errors.Add("username", "Username can not be null or empty.");
            }
            if (string.IsNullOrEmpty(this._password))
            {
                errors.Add("password","Password can not be null or empty.");
            }
            return errors;
        }
    }
}