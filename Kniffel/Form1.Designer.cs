namespace Kniffel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.einserBox = new System.Windows.Forms.TextBox();
            this.zweierBox = new System.Windows.Forms.TextBox();
            this.dreierBox = new System.Windows.Forms.TextBox();
            this.viererBox = new System.Windows.Forms.TextBox();
            this.fuenferBox = new System.Windows.Forms.TextBox();
            this.sechserBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.wuerfelButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gesamtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fullHouseBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dreierpasch_box = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.viererpasch_box = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.WurfCounter = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.KniffelBox = new System.Windows.Forms.TextBox();
            this.enemyPoints = new System.Windows.Forms.TextBox();
            this.countSonder = new System.Windows.Forms.TextBox();
            this.countAll = new System.Windows.Forms.TextBox();
            this.enemySonder = new System.Windows.Forms.TextBox();
            this.enemyNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Einser";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zweier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sechs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fünfer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vierer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dreier";
            // 
            // einserBox
            // 
            this.einserBox.Location = new System.Drawing.Point(122, 79);
            this.einserBox.Name = "einserBox";
            this.einserBox.Size = new System.Drawing.Size(36, 23);
            this.einserBox.TabIndex = 6;
            this.einserBox.Click += new System.EventHandler(this.BoxClickEvent);
            // 
            // zweierBox
            // 
            this.zweierBox.Location = new System.Drawing.Point(122, 112);
            this.zweierBox.Name = "zweierBox";
            this.zweierBox.Size = new System.Drawing.Size(36, 23);
            this.zweierBox.TabIndex = 7;
            this.zweierBox.Click += new System.EventHandler(this.BoxClickEvent);
            // 
            // dreierBox
            // 
            this.dreierBox.Location = new System.Drawing.Point(122, 144);
            this.dreierBox.Name = "dreierBox";
            this.dreierBox.Size = new System.Drawing.Size(36, 23);
            this.dreierBox.TabIndex = 8;
            this.dreierBox.Click += new System.EventHandler(this.BoxClickEvent);
            // 
            // viererBox
            // 
            this.viererBox.Location = new System.Drawing.Point(122, 173);
            this.viererBox.Name = "viererBox";
            this.viererBox.Size = new System.Drawing.Size(36, 23);
            this.viererBox.TabIndex = 9;
            this.viererBox.Click += new System.EventHandler(this.BoxClickEvent);
            // 
            // fuenferBox
            // 
            this.fuenferBox.Location = new System.Drawing.Point(122, 204);
            this.fuenferBox.Name = "fuenferBox";
            this.fuenferBox.Size = new System.Drawing.Size(36, 23);
            this.fuenferBox.TabIndex = 10;
            this.fuenferBox.Click += new System.EventHandler(this.BoxClickEvent);
            // 
            // sechserBox
            // 
            this.sechserBox.Location = new System.Drawing.Point(122, 240);
            this.sechserBox.Name = "sechserBox";
            this.sechserBox.Size = new System.Drawing.Size(36, 23);
            this.sechserBox.TabIndex = 11;
            this.sechserBox.Click += new System.EventHandler(this.BoxClickEvent);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SelectWuerfel);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SelectWuerfel);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(433, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SelectWuerfel);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(525, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SelectWuerfel);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(620, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.SelectWuerfel);
            // 
            // wuerfelButton
            // 
            this.wuerfelButton.Location = new System.Drawing.Point(394, 135);
            this.wuerfelButton.Name = "wuerfelButton";
            this.wuerfelButton.Size = new System.Drawing.Size(75, 23);
            this.wuerfelButton.TabIndex = 17;
            this.wuerfelButton.Text = "Würfeln";
            this.wuerfelButton.UseVisualStyleBackColor = true;
            this.wuerfelButton.Click += new System.EventHandler(this.wuerfelButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 273);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "gesamt";
            // 
            // gesamtBox
            // 
            this.gesamtBox.BackColor = System.Drawing.Color.Orange;
            this.gesamtBox.Location = new System.Drawing.Point(122, 273);
            this.gesamtBox.Margin = new System.Windows.Forms.Padding(2);
            this.gesamtBox.Name = "gesamtBox";
            this.gesamtBox.ReadOnly = true;
            this.gesamtBox.Size = new System.Drawing.Size(36, 23);
            this.gesamtBox.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 334);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "FullHouse";
            // 
            // fullHouseBox
            // 
            this.fullHouseBox.Location = new System.Drawing.Point(117, 326);
            this.fullHouseBox.Margin = new System.Windows.Forms.Padding(2);
            this.fullHouseBox.Name = "fullHouseBox";
            this.fullHouseBox.Size = new System.Drawing.Size(40, 23);
            this.fullHouseBox.TabIndex = 21;
            this.fullHouseBox.Click += new System.EventHandler(this.fullHouseBox_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 23;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(278, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 24;
            this.button6.Text = "Submit";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Manipulation Würfel";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Yu Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(377, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "falsche Eingabe!";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 370);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Dreierpasch";
            // 
            // dreierpasch_box
            // 
            this.dreierpasch_box.Location = new System.Drawing.Point(117, 362);
            this.dreierpasch_box.Margin = new System.Windows.Forms.Padding(2);
            this.dreierpasch_box.Name = "dreierpasch_box";
            this.dreierpasch_box.Size = new System.Drawing.Size(40, 23);
            this.dreierpasch_box.TabIndex = 28;
            this.dreierpasch_box.Click += new System.EventHandler(this.dreierpasch_box_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 402);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = "Viererpasch";
            // 
            // viererpasch_box
            // 
            this.viererpasch_box.Location = new System.Drawing.Point(117, 394);
            this.viererpasch_box.Margin = new System.Windows.Forms.Padding(2);
            this.viererpasch_box.Name = "viererpasch_box";
            this.viererpasch_box.Size = new System.Drawing.Size(40, 23);
            this.viererpasch_box.TabIndex = 30;
            this.viererpasch_box.Click += new System.EventHandler(this.viererpasch_box_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(269, 334);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 31;
            this.label13.Text = "große Straße";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(348, 326);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 23);
            this.textBox1.TabIndex = 32;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(269, 370);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 15);
            this.label14.TabIndex = 33;
            this.label14.Text = "kleine Straße";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(348, 364);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(40, 23);
            this.textBox3.TabIndex = 34;
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // WurfCounter
            // 
            this.WurfCounter.Location = new System.Drawing.Point(339, 135);
            this.WurfCounter.Name = "WurfCounter";
            this.WurfCounter.ReadOnly = true;
            this.WurfCounter.Size = new System.Drawing.Size(26, 23);
            this.WurfCounter.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(270, 402);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 15);
            this.label16.TabIndex = 37;
            this.label16.Text = "Kniffel";
            // 
            // KniffelBox
            // 
            this.KniffelBox.Location = new System.Drawing.Point(348, 399);
            this.KniffelBox.Name = "KniffelBox";
            this.KniffelBox.Size = new System.Drawing.Size(40, 23);
            this.KniffelBox.TabIndex = 38;
            this.KniffelBox.Click += new System.EventHandler(this.KniffelBox_Click);
            // 
            // enemyPoints
            // 
            this.enemyPoints.BackColor = System.Drawing.Color.OrangeRed;
            this.enemyPoints.Location = new System.Drawing.Point(658, 273);
            this.enemyPoints.Name = "enemyPoints";
            this.enemyPoints.ReadOnly = true;
            this.enemyPoints.Size = new System.Drawing.Size(37, 23);
            this.enemyPoints.TabIndex = 39;
            // 
            // countSonder
            // 
            this.countSonder.BackColor = System.Drawing.Color.Orange;
            this.countSonder.Location = new System.Drawing.Point(122, 445);
            this.countSonder.Name = "countSonder";
            this.countSonder.Size = new System.Drawing.Size(35, 23);
            this.countSonder.TabIndex = 40;
            // 
            // countAll
            // 
            this.countAll.BackColor = System.Drawing.Color.Gold;
            this.countAll.Location = new System.Drawing.Point(348, 444);
            this.countAll.Name = "countAll";
            this.countAll.Size = new System.Drawing.Size(40, 23);
            this.countAll.TabIndex = 41;
            // 
            // enemySonder
            // 
            this.enemySonder.BackColor = System.Drawing.Color.Orange;
            this.enemySonder.Location = new System.Drawing.Point(658, 243);
            this.enemySonder.Name = "enemySonder";
            this.enemySonder.Size = new System.Drawing.Size(37, 23);
            this.enemySonder.TabIndex = 42;
            // 
            // enemyNumber
            // 
            this.enemyNumber.BackColor = System.Drawing.Color.Orange;
            this.enemyNumber.Location = new System.Drawing.Point(658, 214);
            this.enemyNumber.Name = "enemyNumber";
            this.enemyNumber.Size = new System.Drawing.Size(37, 23);
            this.enemyNumber.TabIndex = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.enemyNumber);
            this.Controls.Add(this.enemySonder);
            this.Controls.Add(this.countAll);
            this.Controls.Add(this.countSonder);
            this.Controls.Add(this.enemyPoints);
            this.Controls.Add(this.KniffelBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.WurfCounter);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.viererpasch_box);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dreierpasch_box);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.fullHouseBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gesamtBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.wuerfelButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sechserBox);
            this.Controls.Add(this.fuenferBox);
            this.Controls.Add(this.viererBox);
            this.Controls.Add(this.dreierBox);
            this.Controls.Add(this.zweierBox);
            this.Controls.Add(this.einserBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox einserBox;
        private TextBox zweierBox;
        private TextBox dreierBox;
        private TextBox viererBox;
        private TextBox fuenferBox;
        private TextBox sechserBox;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button wuerfelButton;
        private Label label7;
        private TextBox gesamtBox;
        private Label label8;
        private TextBox fullHouseBox;
        private TextBox textBox2;
        private Button button6;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox dreierpasch_box;
        private Label label12;
        private TextBox viererpasch_box;
        private Label label13;
        private TextBox textBox1;
        private Label label14;
        private TextBox textBox3;
        private TextBox WurfCounter;
        private Label label16;
        private TextBox KniffelBox;
        private TextBox enemyPoints;
        private TextBox countSonder;
        private TextBox countAll;
        private TextBox enemySonder;
        private TextBox enemyNumber;
    }
}