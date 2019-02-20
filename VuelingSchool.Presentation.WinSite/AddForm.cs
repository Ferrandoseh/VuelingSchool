using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VuelingSchool.Common.Library.Models;
using VuelingSchool.DataAccess.Repository;

namespace VuelingSchool.Presentation.WinSite
{
    public partial class AddForm : Form
    {
        StudentRepository sr;
        public AddForm(StudentRepository srForm1)
        {
            InitializeComponent();

            sr = srForm1;
        }

        private void btAddEvent_Click(object sender, EventArgs e)
        {
            Student s = new Student(tbId.Text, tbName.Text, tbSurname.Text, tbBirthday.Text);
            sr.AddNewStudent(s);
        }
    }
}
