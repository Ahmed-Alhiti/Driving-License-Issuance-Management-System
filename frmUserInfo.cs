using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buisness;

namespace DVLManagementSystem
{
    public partial class frmUserInfo : Form
    {
        clsUsers users;
        clsPeople people;
        int User_id;
        public frmUserInfo(int id)
        {
            InitializeComponent();
            User_id = id;
        }

        private void _LoadData()
        {
            users = clsUsers.Find_ByID(User_id);
            userDetails1.lbID.Text = users._UserID.ToString();
            userDetails1.lblIsActive.Text = users._IsActive.ToString();
            userDetails1.lblUserName.Text = users._UserName;

            people = clsPeople.Find_ByID(users._PersonID);
            userDetails1.personinfo1.lbID.Text = people._PersonID.ToString();
            userDetails1.personinfo1.lblAddress.Text = people._Address;
            userDetails1.personinfo1.lblCountry.Text = people.CountryInfo._CountryName;
            userDetails1.personinfo1.lblDate.Text = people._DateOfBirth.ToShortDateString();
            userDetails1.personinfo1.lblEmail.Text = people._Email;
            if (people._Gendor == 0)
                userDetails1.personinfo1.lblGender.Text = "Male";
            else
                userDetails1.personinfo1.lblGender.Text = "Female";
            userDetails1.personinfo1.lblName.Text = people._FirstName+" "+people._SecondName+" "+people._ThirdName+" "+people._LastName;
            userDetails1.personinfo1.lblNationalNo.Text = people._NationalNo;
            userDetails1.personinfo1.lblPhone.Text = people._Phone;
            userDetails1.personinfo1.picPerson.ImageLocation = people.ImagePath;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
