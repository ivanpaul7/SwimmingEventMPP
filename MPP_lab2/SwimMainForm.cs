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
        private readonly IList<Participant> participants;
        private readonly IList<EventPartDTO> events;
        private SwimClientController ctrl;
        public SwimMainForm(SwimClientController sc) {
            this.ctrl = sc;
            InitializeComponent();
            InitializeDataGridColumn();
            participants = sc.findAllPart();
            dataGvParticipant.DataSource = participants;
            events = sc.findAllEvents();
            dataGvEvent.DataSource = events;
            ctrl.updateEvent += userUpdate;
        }

        

        /////////////////////////////////////////////////////////////////
        

        private void userUpdate(object sender, SwimUserEventArgs suea) {
            if (suea.UserEventType == SwimUserEvent.AddEventPart) {
                foreach(EventPartDTO ev in events) {
                    EventPartDTO x = (EventPartDTO)suea.Data;
                    if (ev.Distance == x.Distance && ev.Style == x.Style) {
                        ev.CodPart = ev.CodPart + 1;
                        break;
                    }
                }
                dataGvParticipant.BeginInvoke(new UpdateDGViewEventCallback(this.UpdateObserverEvent), new Object[] { dataGvEvent, events });
            }
            if (suea.UserEventType == SwimUserEvent.AddParticipant) {
                participants.Add((Participant)suea.Data);
                dataGvParticipant.BeginInvoke(new UpdateDGViewPartCallback(this.UpdateObserverPart), new Object[] { dataGvParticipant, participants });
            }
        }

        public void UpdateObserverPart(DataGridView dataGridView, IList<Participant> list) {
            dataGridView.DataSource = null;
            dataGridView.DataSource = list;
        }
        public delegate void UpdateDGViewPartCallback(DataGridView dataGridView, IList<Participant> list);
        /// ///////////////////
        public void UpdateObserverEvent(DataGridView dataGridView, IList<EventPartDTO> list) {
            dataGridView.DataSource = null;
            dataGridView.DataSource = list;
        }
        public delegate void UpdateDGViewEventCallback(DataGridView dataGridView, IList<EventPartDTO> list);

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

        private void loadParticipants(int distanta, String stil) {
            if (distanta == -1)
                dataGvParticipant.DataSource = ctrl.findAllPart();
            else
                dataGvParticipant.DataSource = ctrl.findAllPartForEvent(new Event(distanta, stil));
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
