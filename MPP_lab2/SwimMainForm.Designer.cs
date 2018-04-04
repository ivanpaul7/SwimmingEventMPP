namespace client {
    partial class SwimMainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGvEvent = new System.Windows.Forms.DataGridView();
            this.dataGvParticipant = new System.Windows.Forms.DataGridView();
            this.textBoxID1 = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxId2 = new System.Windows.Forms.TextBox();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.textBoxStyle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddPart = new System.Windows.Forms.Button();
            this.buttonRegistePart = new System.Windows.Forms.Button();
            this.allPartBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGvEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGvParticipant)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGvEvent
            // 
            this.dataGvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGvEvent.Location = new System.Drawing.Point(12, 12);
            this.dataGvEvent.Name = "dataGvEvent";
            this.dataGvEvent.RowTemplate.Height = 24;
            this.dataGvEvent.Size = new System.Drawing.Size(430, 487);
            this.dataGvEvent.TabIndex = 0;
            this.dataGvEvent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGvEvent_CellContentClick);
            this.dataGvEvent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGvEvent_CellContentClick);
            // 
            // dataGvParticipant
            // 
            this.dataGvParticipant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGvParticipant.Location = new System.Drawing.Point(448, 12);
            this.dataGvParticipant.Name = "dataGvParticipant";
            this.dataGvParticipant.RowTemplate.Height = 24;
            this.dataGvParticipant.Size = new System.Drawing.Size(411, 487);
            this.dataGvParticipant.TabIndex = 1;
            this.dataGvParticipant.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGvParticipant_CellContentClick);
            this.dataGvParticipant.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGvParticipant_CellContentClick);
            // 
            // textBoxID1
            // 
            this.textBoxID1.Location = new System.Drawing.Point(975, 8);
            this.textBoxID1.Name = "textBoxID1";
            this.textBoxID1.Size = new System.Drawing.Size(117, 22);
            this.textBoxID1.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(975, 36);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(117, 22);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(975, 64);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(117, 22);
            this.textBoxAge.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(874, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID Participant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(921, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Age";
            // 
            // textBoxId2
            // 
            this.textBoxId2.Location = new System.Drawing.Point(975, 166);
            this.textBoxId2.Name = "textBoxId2";
            this.textBoxId2.Size = new System.Drawing.Size(117, 22);
            this.textBoxId2.TabIndex = 8;
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(975, 194);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(117, 22);
            this.textBoxDistance.TabIndex = 9;
            // 
            // textBoxStyle
            // 
            this.textBoxStyle.Location = new System.Drawing.Point(975, 222);
            this.textBoxStyle.Name = "textBoxStyle";
            this.textBoxStyle.Size = new System.Drawing.Size(117, 22);
            this.textBoxStyle.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(874, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "ID Participant";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(903, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Distance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(921, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Style";
            // 
            // buttonAddPart
            // 
            this.buttonAddPart.Location = new System.Drawing.Point(975, 92);
            this.buttonAddPart.Name = "buttonAddPart";
            this.buttonAddPart.Size = new System.Drawing.Size(117, 23);
            this.buttonAddPart.TabIndex = 14;
            this.buttonAddPart.Text = "Add participant";
            this.buttonAddPart.UseVisualStyleBackColor = true;
            this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
            // 
            // buttonRegistePart
            // 
            this.buttonRegistePart.Location = new System.Drawing.Point(951, 250);
            this.buttonRegistePart.Name = "buttonRegistePart";
            this.buttonRegistePart.Size = new System.Drawing.Size(141, 23);
            this.buttonRegistePart.TabIndex = 15;
            this.buttonRegistePart.Text = "Register participant";
            this.buttonRegistePart.UseVisualStyleBackColor = true;
            this.buttonRegistePart.Click += new System.EventHandler(this.buttonRegistePart_Click);
            // 
            // allPartBtn
            // 
            this.allPartBtn.Location = new System.Drawing.Point(865, 476);
            this.allPartBtn.Name = "allPartBtn";
            this.allPartBtn.Size = new System.Drawing.Size(117, 23);
            this.allPartBtn.TabIndex = 16;
            this.allPartBtn.Text = "All Participants";
            this.allPartBtn.UseVisualStyleBackColor = true;
            this.allPartBtn.Click += new System.EventHandler(this.allPartBtn_Click);
            // 
            // SwimMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 511);
            this.Controls.Add(this.allPartBtn);
            this.Controls.Add(this.buttonRegistePart);
            this.Controls.Add(this.buttonAddPart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStyle);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.textBoxId2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxID1);
            this.Controls.Add(this.dataGvParticipant);
            this.Controls.Add(this.dataGvEvent);
            this.Name = "SwimMainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGvEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGvParticipant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGvEvent;
        private System.Windows.Forms.DataGridView dataGvParticipant;
        private System.Windows.Forms.TextBox textBoxID1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxId2;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.TextBox textBoxStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddPart;
        private System.Windows.Forms.Button buttonRegistePart;
        private System.Windows.Forms.Button allPartBtn;
    }
}

