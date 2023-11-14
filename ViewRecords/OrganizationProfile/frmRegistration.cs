using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        public static string SetFileName;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
            "BS Information Technology",
            "BS Computer Science",
            "BS Information Systems",
            "BS in Accountancy",
            "BS in Hospitality Management",
            "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string StudentNo, Program, Fullname, Date, Age, Gender, ContactNo;

            StudentNo = txtStudentNo.Text;
            Program = cbPrograms.Text;
            Fullname = txtLastName.Text + ", " + txtFirstName.Text + " " + txtMiddleInitial.Text + ".";
            Age = txtAge.Text;
            Date = datePickerBirthday.Value.ToString("yyyy-MM-dd");
            Gender = cbGender.Text;
            ContactNo = txtContactNo.Text;

            string[] StudentInfo = new string[]
            {
                "Student No: " + StudentNo,
                "Full Name: " + Fullname,
                "Program: " + Program,
                "Gender: " + Gender,
                "Age: " + Age,
                "Birthday: " + Date,
                "Contact No:" + ContactNo

            };

            SetFileName = StudentNo + ".txt";

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,frmRegistration.SetFileName)))
            {
                foreach (string s in StudentInfo)
                {
                    outputFile.WriteLine(s);
                }
                foreach (string s in StudentInfo)
                {
                    Console.WriteLine(s);
                }
            }
        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            new FrmStudentRecord().ShowDialog();
        }
    }
}
