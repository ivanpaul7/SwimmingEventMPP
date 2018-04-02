using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;
using services;

namespace client {
    public partial class SwimMainForm : Form {
        private BindingSource bindingSourceEvent, bindingSourcePart;
        private readonly IList<Participant> participants;
        private SwimClientController ctrl;
        public SwimMainForm(SwimClientController sc) {
            this.ctrl = sc;
            InitializeComponent();
            InitializeDataGridColumn();
            loadEvents();
            ctrl.setFormForObserver(this);
            //myDelegate = new UpdateObserverDelegate(UpdateObserver);
            participants = sc.findAllPart();
            dataGvParticipant.DataSource = participants;
            ctrl.updateEvent += userUpdate;
        }

        

        /////////////////////////////////////////////////////////////////
        

        private void userUpdate(object sender, SwimUserEventArgs e) {
            if (e.UserEventType == SwimUserEvent.Update) {
                //BeginInvoke(new UpdateObserverDelegate(this.UpdateObserver));
                //dataGvParticipant.BeginInvoke(new UpdateDataGridViewCallback(this.UpdateObserver2), new Object[] { dataGvParticipant, e.Data });
            }
            if (e.UserEventType == SwimUserEvent.AddParticipant) {
                //BeginInvoke(new UpdateObserverDelegate(this.UpdateObserver));
                //dataGvParticipant.BeginInvoke(new UpdateDataGridViewCallback(this.UpdateObserver2), new Object[] { dataGvParticipant, e.Data });

                participants.Add((Participant)e.Data);
                dataGvParticipant.BeginInvoke(new UpdateDataGridViewCallback(this.UpdateObserver2), new Object[] { dataGvParticipant, participants });
                

            }
        }





        public void UpdateObserver2(DataGridView dataGridView, IList<Participant> list) {
            dataGridView.DataSource = null;
            dataGridView.DataSource = list;
        }
        public delegate void UpdateDataGridViewCallback(DataGridView dataGridView, IList<Participant> list);

        //public void UpdateObserver2(DataGridView dataGridView, IList<Participant> list) {
        //    dataGridView.DataSource = null;
        //    dataGridView.DataSource = list;
        //}
        //public delegate void UpdateDataGridViewCallback(DataGridView dataGridView, IList<Participant> list);


        //public void UpdateObserver2(DataGridView dataGridView, BindingSource newBindingSource) {
        //    dataGridView.DataSource = null;
        //    dataGridView.DataSource = newBindingSource;
        //}
        //public delegate void UpdateDataGridViewCallback(DataGridView dataGridView, BindingSource newBindingSource);

        ///////////// 1111
        //public delegate void UpdateObserverDelegate();
        //public UpdateObserverDelegate myDelegate;
        //public void UpdateObserver() {
        //    loadParticipants(-1, "");
        //    loadEvents();
        //}
        /////////////////////////////////////////////////////////////////
        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e) {
            Console.WriteLine("ChatWindow closing " + e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing) {
                ctrl.logout();
                ctrl.updateEvent -= userUpdate;
                Application.Exit();
            }

        }
        private void InitializeDataGridColumn() {
            //dataGvEvent.AutoSize = true;
            // Initialize the DataGridView.
            dataGvEvent.AutoGenerateColumns = false;
            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Distance";
            column.Name = "Distanta";
            dataGvEvent.Columns.Add(column);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "Style";
            column2.Name = "Stil";
            dataGvEvent.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
            column3.DataPropertyName = "CodPart";
            column3.Name = "No.Part";
            dataGvEvent.Columns.Add(column3);

            // Initialize the DataGridView.
            dataGvParticipant.AutoGenerateColumns = false;
            // Initialize and add a text box column.
            DataGridViewColumn column11 = new DataGridViewTextBoxColumn();
            column11.DataPropertyName = "Id";
            column11.Name = "ID";
            dataGvParticipant.Columns.Add(column11);

            DataGridViewColumn column22 = new DataGridViewTextBoxColumn();
            column22.DataPropertyName = "Name";
            column22.Name = "Name";
            dataGvParticipant.Columns.Add(column22);

            DataGridViewColumn column33 = new DataGridViewTextBoxColumn();
            column33.DataPropertyName = "Age";
            column33.Name = "Age";
            dataGvParticipant.Columns.Add(column33);
        }

        private void loadEvents() {
            dataGvEvent.DataSource = ctrl.findAllEvent(); ;
        }

        private void loadParticipants(int distanta, String stil) {
            if (distanta == -1)
                dataGvParticipant.DataSource = ctrl.findAllPart();
            else
                dataGvParticipant.DataSource = ctrl.findAllPartForEvent(new Event(distanta, stil));
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void dataGvEvent_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int dist = (Int32)dataGvEvent.Rows[dataGvEvent.CurrentRow.Index].Cells["Distanta"].Value;
            string stil= (string)dataGvEvent.Rows[dataGvEvent.CurrentRow.Index].Cells["Stil"].Value;
            textBoxDistance.Text = dist.ToString();
            textBoxStyle.Text = stil;
            loadParticipants(dist, stil);
        }

        private void dataGvParticipant_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int id = (Int32)dataGvParticipant.Rows[dataGvParticipant.CurrentRow.Index].Cells["ID"].Value;
            string name = (string)dataGvParticipant.Rows[dataGvParticipant.CurrentRow.Index].Cells["Name"].Value;
            int age = (Int32)dataGvParticipant.Rows[dataGvParticipant.CurrentRow.Index].Cells["Age"].Value;
            textBoxID1.Text = id.ToString();
            textBoxId2.Text = id.ToString();
            textBoxName.Text = name;
            textBoxAge.Text = age.ToString();

        }

        private void buttonAddPart_Click(object sender, EventArgs e) {
            ctrl.addParticipant(new Participant(Int32.Parse(textBoxID1.Text), textBoxName.Text, Int32.Parse(textBoxAge.Text)));
        }

        private void buttonRegistePart_Click(object sender, EventArgs e) {
            ctrl.addPart2Event(new EventPartDTO(Int32.Parse(textBoxDistance.Text), textBoxStyle.Text, Int32.Parse(textBoxId2.Text)));
        }

        private void allPartBtn_Click(object sender, EventArgs e) {
            loadParticipants(-1, "");
        }
    }
}
