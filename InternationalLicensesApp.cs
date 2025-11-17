using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buisness;

namespace DVLManagementSystem
{
    public partial class InternationalLicensesApp : UserControl
    {
        //clsInternationalLicenses internationalLicense;
        clsLicenses license;
        
        //clsPeople people;
        

        public InternationalLicensesApp()
        {
            InitializeComponent();
        }

        private void LoadLocalLicenseData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text))
                return;
            license = clsLicenses.Find_ByID(int.Parse(txtSearchLicenseID.Text));
            if(license != null)
            {
                lblLicenseID.Text = license._LicenseID.ToString();
                lblLocalLID.Text = lblLicenseID.Text;
                lblisactive.Text = (license._IsActive) ? "Yes" : "No";
                lblIsDetained.Text = (license._IsActive) ? "No" : "Yes";
                lblIssueDate.Text = license._IssueDate.ToShortDateString();
                lblIssueReason.Text = license._IssueReasonText;
                lblExpirationDate.Text = license._ExpirationDate.ToShortDateString();
                lblDriverID.Text = license._DriverID.ToString();
                lblNotes.Text = license._Notes;
            }
            else
            {
                MessageBox.Show("You Cann't have international License ");
                return;
            }

            
        }
        private void LoadPersonData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text) || license == null)
                return;
            //people = clsPeople.Find_ByDriverID(license._DriverID);
            lblName.Text = license.DriverInfo.PersonInfo.FullName ;
            lblNationalNo.Text = license.DriverInfo.PersonInfo._NationalNo;
            lblEmail.Text = license.DriverInfo.PersonInfo._Email;
            lblDateOfBrith.Text = license.DriverInfo.PersonInfo._DateOfBirth.ToShortDateString();
            lblGender.Text = (license.DriverInfo.PersonInfo._Gendor == 1) ? "Male" : "Female";
            picPerson.ImageLocation = license.DriverInfo.PersonInfo.ImagePath;
        }
        
        private void LoadData()
        {

            LoadLocalLicenseData();
            LoadPersonData();

            
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

       
    }
}
