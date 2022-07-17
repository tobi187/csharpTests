namespace Kniffel
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.Label();
            this.createGroup = new System.Windows.Forms.Button();
            this.joinGame = new System.Windows.Forms.Button();
            this.roomList = new System.Windows.Forms.ListBox();
            this.groupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(326, 133);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(145, 44);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Banner", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(254, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // statusBox
            // 
            this.statusBox.AutoSize = true;
            this.statusBox.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusBox.Location = new System.Drawing.Point(354, 60);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(157, 27);
            this.statusBox.TabIndex = 2;
            this.statusBox.Text = "Not Connected";
            // 
            // createGroup
            // 
            this.createGroup.Location = new System.Drawing.Point(71, 278);
            this.createGroup.Name = "createGroup";
            this.createGroup.Size = new System.Drawing.Size(119, 35);
            this.createGroup.TabIndex = 3;
            this.createGroup.Text = "Create Goup";
            this.createGroup.UseVisualStyleBackColor = true;
            this.createGroup.Visible = false;
            this.createGroup.Click += new System.EventHandler(this.createGroup_Click);
            // 
            // joinGame
            // 
            this.joinGame.Location = new System.Drawing.Point(355, 354);
            this.joinGame.Name = "joinGame";
            this.joinGame.Size = new System.Drawing.Size(75, 23);
            this.joinGame.TabIndex = 5;
            this.joinGame.Text = "Join";
            this.joinGame.UseVisualStyleBackColor = true;
            this.joinGame.Visible = false;
            this.joinGame.Click += new System.EventHandler(this.joinGame_Click);
            // 
            // roomList
            // 
            this.roomList.FormattingEnabled = true;
            this.roomList.ItemHeight = 15;
            this.roomList.Location = new System.Drawing.Point(263, 223);
            this.roomList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roomList.Name = "roomList";
            this.roomList.Size = new System.Drawing.Size(269, 109);
            this.roomList.TabIndex = 6;
            this.roomList.Visible = false;
            // 
            // groupName
            // 
            this.groupName.Location = new System.Drawing.Point(71, 239);
            this.groupName.Name = "groupName";
            this.groupName.Size = new System.Drawing.Size(119, 23);
            this.groupName.TabIndex = 7;
            this.groupName.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupName);
            this.Controls.Add(this.roomList);
            this.Controls.Add(this.joinGame);
            this.Controls.Add(this.createGroup);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectButton);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button connectButton;
        private Label label1;
        private Label statusBox;
        private Button createGroup;
        private Button joinGame;
        private ListBox roomList;
        private TextBox groupName;
    }
}