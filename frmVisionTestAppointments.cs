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
    
    public partial class frmVisionTestAppointments : Form
    {

        clsLocalDrivingLicense license;
        clsApplications applications;

        int License_id;
        public frmVisionTestAppointments(int id)
        {
            InitializeComponent();
            License_id = id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        clsTestAppointments Last_appointment;
        private void btnadd_Click(object sender, EventArgs e)
        {
            Last_appointment = clsTestAppointments.GetLastTestAppointment(License_id, clsTestTypes.enTestType.VisionTest);

            //تححق اذا كان به طلب سابق
            if (Last_appointment != null && !Last_appointment._IsLocked)
            {
                MessageBox.Show("There's an active Appointment , Cann't Sechdule Test", "Active Appointment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTests.CheckTestResult(1, License_id))
            {
                MessageBox.Show("The Driver is already Passed This Test","Passed Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvAppointments.Rows.Count == 0 )
            {
                frmSechduleTest sechduleTest = new frmSechduleTest(License_id, -1);
                sechduleTest.ShowDialog();
                _GetAllTest();
                return;
            }
            else
            {
                //clsTests tests = clsTests.Find_ByAppoentID((int)dgvAppointments.CurrentRow.Cells[0].Value);
                if(!clsTests.CheckTestResult(1, License_id))
                {
                    frmSechduleTest sechduleTest = new frmSechduleTest(License_id, -1);
                    sechduleTest.testMode = frmSechduleTest.enTestMode.RetakeTest;
                    sechduleTest.ShowDialog();
                    _GetAllTest();
                    return;
                }

                frmSechduleTest sechduleTest1 = new frmSechduleTest(License_id, -1);
                sechduleTest1.ShowDialog();
                _GetAllTest();
            }
            
        }
        private void _GetAllTest()
        {
            dgvAppointments.DataSource = Last_appointment.GetAll(1);
        }
        private void _LoadData()
        {

            license = clsLocalDrivingLicense.Find_ByID(License_id);
            applications = clsApplications.FindBaseApplication(license._ApplicationID);
            clsLicenseClasses licenseClasses = clsLicenseClasses.Find_ByID(license._LicenseClassID);
            //clsPeople people = clsPeople.Find_ByID(applications._ApplicantPersonID);
            clsAppsTypes types = clsAppsTypes.Find_ByID(1);
            dlInfo1.lbDLID.Text = license._LocalDrivingLicenseApplicationID.ToString();
            dlInfo1.lblClassName.Text = licenseClasses._ClassName;
            dlInfo1.lblPassedTests.Text = clsTests.GetPassedTests(License_id).ToString("#0/3");
            dlInfo1.lblAppID.Text = applications._ApplicationID.ToString();
            dlInfo1.lblAppDate.Text = applications._ApplicationDate.ToString();
            dlInfo1.lblAppFees.Text = types._ApplicationFees.ToString();
            dlInfo1.lblAppApplicant.Text =applications.ApplicantFullName;
            dlInfo1.lblAppCreatedBy.Text = clsUsers.Find_ByID(applications._CreatedByUserID)._UserName.ToString();
            dlInfo1.lblAppStatus.Text = applications._StatusText;
            dlInfo1.lblAppStatusDate.Text = applications._LastStatusDate.ToString();
            dlInfo1.lblAppType.Text = types._ApplicationTypeTitle;
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadData();
            _GetAllTest();
        }

        private void EditStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSechduleTest sechduleTest = new frmSechduleTest(License_id, (int)dgvAppointments.CurrentRow.Cells[0].Value);
            sechduleTest.ShowDialog();
            _GetAllTest();
        }

        private void TakeTestStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTakeTest takeTest = new frmTakeTest(License_id, (int)dgvAppointments.CurrentRow.Cells[0].Value);
            takeTest.ShowDialog();
            _GetAllTest();

        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (clsTestAppointments.Find_ByID((int)dgvAppointments.CurrentRow.Cells[0].Value)._IsLocked)
            {
                contextMenuStrip1.Items[1].Enabled = false;
                return;
            }
            contextMenuStrip1.Items[1].Enabled = true;
        }
    }
}
