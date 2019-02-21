using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VuelingSchool.Common.Library.Factory;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        private static StudentRepository sr;
        private string[] fileTypes = { "xml", "json", "txt"};
        public Form1()
        {
            InitializeComponent();
            LoadProvinces();
            

            cbFileType.DataSource = fileTypes;
            CreateRepository();
            RefreshView();

        }

        public StudentRepository getActiveStudenRepository()
        {
            return sr;
        }

        private void RefreshView()
        {
            List<Student> studentList = sr.GetAllStudents();
            dgvStudents.DataSource = studentList;
        }

        private void CreateRepository()
        {
            string fileSelected = cbFileType.SelectedValue.ToString();
            sr = new StudentRepository(FileManagerFactory.Instance.CreateFileManager( fileSelected ));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProvinces();
        }
        
        private void LoadProvinces()
        {
            cbProvinces.DataSource = ProvincesSingleton.Instance.ProvinceList;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.StudentAddedEvent += this.OnStudentAdded;
            addForm.Show(this);
        }

        private void cbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateRepository();
            RefreshView();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        public void OnStudentAdded(Student s)
        {
            sr.AddNewStudent(s);
            RefreshView();
        }
    }
}
