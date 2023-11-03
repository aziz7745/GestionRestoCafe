namespace ProjetRestoCafe.Views
{
    partial class Menu
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
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            button10 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(55, 17);
            label1.TabIndex = 0;
            label1.Text = "Serveur";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(104, 20);
            label2.Name = "label2";
            label2.Size = new Size(107, 17);
            label2.TabIndex = 1;
            label2.Text = "Nom de serveur";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(223, 395);
            dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.Orange;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(263, 58);
            button1.Name = "button1";
            button1.Size = new Size(65, 58);
            button1.TabIndex = 5;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(263, 141);
            button2.Name = "button2";
            button2.Size = new Size(65, 58);
            button2.TabIndex = 6;
            button2.Text = "Annuler";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.imge36;
            button3.Location = new Point(263, 226);
            button3.Name = "button3";
            button3.Size = new Size(65, 58);
            button3.TabIndex = 7;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DodgerBlue;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(263, 312);
            button4.Name = "button4";
            button4.Size = new Size(65, 58);
            button4.TabIndex = 8;
            button4.Text = "Qte+";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Olive;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(263, 395);
            button5.Name = "button5";
            button5.Size = new Size(65, 58);
            button5.TabIndex = 9;
            button5.Text = "Qte-";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Image = Properties.Resources.gauche1;
            button6.Location = new Point(364, 180);
            button6.Name = "button6";
            button6.Size = new Size(50, 43);
            button6.TabIndex = 10;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Image = Properties.Resources.gauche1;
            button7.Location = new Point(364, 400);
            button7.Name = "button7";
            button7.Size = new Size(50, 43);
            button7.TabIndex = 12;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Image = Properties.Resources.droit1;
            button8.Location = new Point(1148, 180);
            button8.Name = "button8";
            button8.Size = new Size(50, 43);
            button8.TabIndex = 13;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Image = Properties.Resources.droit1;
            button9.Location = new Point(1148, 400);
            button9.Name = "button9";
            button9.Size = new Size(50, 43);
            button9.TabIndex = 14;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 481);
            label3.Name = "label3";
            label3.Size = new Size(46, 17);
            label3.TabIndex = 15;
            label3.Text = "Totale";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(64, 480);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(172, 23);
            textBox1.TabIndex = 16;
            // 
            // button10
            // 
            button10.BackColor = Color.Brown;
            button10.Location = new Point(1151, 16);
            button10.Name = "button10";
            button10.Size = new Size(75, 29);
            button10.TabIndex = 17;
            button10.Text = "Close";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1238, 526);
            Controls.Add(button10);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Label label3;
        private TextBox textBox1;
        private Button button10;
    }
}