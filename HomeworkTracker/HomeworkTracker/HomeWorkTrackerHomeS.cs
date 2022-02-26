using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeworkTracker
{
    public partial class HomeWorkTrackerHomeS : Form
    {
        Color ClassButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))));
        Font ClassButtonFont = new System.Drawing.Font("Brush Script MT", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        Size ClassButtonSize = new Size(170, 66);
        String DateDisplayFormat = "MM/dd/yyyy";
        String DataLocation = @"C:\Users\Public\Documents";

        SchoolClass ActiveClass = null;
        List<SchoolClass> AllClasses = new List<SchoolClass>();
        Button CreateClassListButton()
        {
            Button classButton = new Button();
            classButton.BackColor = ClassButtonBackgroundColor;
            classButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            classButton.Font = ClassButtonFont;
            //classButton.Location = new System.Drawing.Point(0, 66);  //Don't care about location Here.
            classButton.Padding = new System.Windows.Forms.Padding(1);
            classButton.Size = new Size(170, 66);
            classButton.TabIndex = 1;//When controls share tab indexes they are iterated in the order in which they are known in memory which in our case will be the order in which we insert them into the list.
            classButton.UseVisualStyleBackColor = false;
            return classButton;

        }
        Button CreateClassButton(SchoolClass sClass)
        {
            var classButton = CreateClassListButton();
            classButton.Name = $"Class{sClass.Id}Button";
            classButton.Text = $"{sClass.Name}";
            classButton.Tag = sClass;
            classButton.Click += (s, e) => { LoadClass((SchoolClass)((Control)s).Tag); };
            return classButton;
        }
        Button CreateNewClassButton()
        {
            var classButton = CreateClassListButton();
            classButton.Name = "CreateNewClassButton";
            classButton.Text = "Add Class";
            classButton.Click += (s, e) =>
            {
                var newClass = new SchoolClass() { Name = "New Class" };
                AllClasses.Add(newClass);
                RefreshClassList();
                LoadClass(newClass);
            };
            return classButton;
        }
        public void LoadClass(SchoolClass sClass)
        {
            _TBClassName.Text = sClass.Name;
            _CLBAssignments.Items.Clear();
            if (sClass.Assignments != null)
                foreach (var assignment in sClass.Assignments)
                    _CLBAssignments.Items.Add(assignment, assignment.Completed);
            ActiveClass = sClass;
        }

        public HomeWorkTrackerHomeS()
        {
            InitializeComponent();

        }
        void SaveAndClose()
        {
            foreach (var sClass in AllClasses)
                sClass.ToFile(System.IO.Path.Combine(DataLocation, $"Class{sClass.Id}.txt"));
            this.Close();
        }

        void RefreshClassList()
        {
            _PNLClassList.Controls.Clear();
            int i = 0;
            foreach(var sClass in AllClasses)
            {
                var nxtBtn = CreateClassButton(sClass);
                nxtBtn.Location = new Point(0, i*(nxtBtn.Height+1));
                _PNLClassList.Controls.Add(nxtBtn);
                i++;
            }
            var addClassBtn = CreateNewClassButton();
            addClassBtn.Location = new Point(0, i * (addClassBtn.Height + 1));
            _PNLClassList.Controls.Add(addClassBtn);
        }

        private void HomeWorkTrackerHomeS_Load(object sender, EventArgs e)
        {
            foreach (var f in System.IO.Directory.EnumerateFiles(DataLocation,"Class*.txt"))
            {
                AllClasses.Add(SchoolClass.FromFile(f));
            }
            
            RefreshClassList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveClass.Name = _TBClassName.Text;
            RefreshClassList();
        }

        private void _BTNAddAssignment_Click(object sender, EventArgs e)
        {
            if (ActiveClass.Assignments == null)
                ActiveClass.Assignments = new List<Assignment>();
            var newAssignment = new Assignment() { Completed = false, Description = _TBAssignmentName.Text };
            ActiveClass.Assignments.Add(newAssignment);

            LoadClass(ActiveClass);
        }

        private void _BTNDeleteAssignment_Click(object sender, EventArgs e)
        {
            if (ActiveClass.Assignments == null) return;
            ActiveClass.Assignments.RemoveAll(x => String.Compare(x.Description, _TBAssignmentName.Text,true)==0);
            LoadClass(ActiveClass);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void _CLBAssignments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var completed = e.NewValue== CheckState.Checked;
            var checkedItem = ((CheckedListBox)sender).Items[e.Index];
            if (checkedItem == null || ActiveClass.Assignments==null) return;
            var Assignment = ActiveClass.Assignments.FirstOrDefault(x => x.Id == ((Assignment)checkedItem).Id);
            if (Assignment == null) return;
            Assignment.Completed = completed;
        }
    }
}
