using System;
using System.Windows.Forms;
using VuelingSchool.Common.Library.Models;

namespace VuelingSchool.Presentation.WinSite
{
    public partial class AddForm : Form
    {
        public event StudentAddedHandler StudentAddedEvent;
        public AddForm()
        {
            InitializeComponent();
        }
        
        private void btAddEvent_Click(object sender, EventArgs e)
        {
            OnStudedAdded();
        }

        private void OnStudedAdded()
        {
            Student s = new Student(tbId.Text, tbName.Text, tbSurname.Text, tbBirthday.Text);
            if (StudentAddedEvent != null)
                StudentAddedEvent(s);
        }
    }
}
