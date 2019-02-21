using System;
using System.Windows.Forms;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.WinSite
{
    public partial class AddForm : Form
    {
        public event StudentAddedHandler StudentAddedEvent;
        public StudentRepository sr;
        public AddForm(StudentRepository srForm1)
        {
            InitializeComponent();
            sr = srForm1;
        }
        
        private void btAddEvent_Click(object sender, EventArgs e)
        {
            OnStudedAdded();
        }

        private void OnStudedAdded()
        {
            Student s = new Student(tbId.Text, tbName.Text, tbSurname.Text, tbBirthday.Text);
            sr.AddNewStudent(s);
            if (StudentAddedEvent != null)
                StudentAddedEvent();
        }
    }
}
