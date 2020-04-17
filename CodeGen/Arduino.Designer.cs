namespace CodeGen
{
    partial class Arduino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arduino));
            this.Title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Composants = new System.Windows.Forms.ListBox();
            this.DeleteComposant = new System.Windows.Forms.Button();
            this.AddComposant = new System.Windows.Forms.Button();
            this.DeleteLibrary = new System.Windows.Forms.Button();
            this.AddLibrary = new System.Windows.Forms.Button();
            this.Library = new System.Windows.Forms.ComboBox();
            this.Libraries = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Composant = new System.Windows.Forms.TextBox();
            this.Datasheets = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Datasheet = new System.Windows.Forms.ComboBox();
            this.AddDatasheet = new System.Windows.Forms.Button();
            this.DeleteDatasheet = new System.Windows.Forms.Button();
            this.OpenFolder = new System.Windows.Forms.CheckBox();
            this.FinishBtn = new System.Windows.Forms.Button();
            this.LoadingGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Century Gothic", 23F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Title.Size = new System.Drawing.Size(881, 50);
            this.Title.TabIndex = 0;
            this.Title.Text = "Arduino template :";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quels composants allez-vous utiliser?";
            // 
            // Composants
            // 
            this.Composants.FormattingEnabled = true;
            this.Composants.ItemHeight = 16;
            this.Composants.Location = new System.Drawing.Point(59, 138);
            this.Composants.Name = "Composants";
            this.Composants.Size = new System.Drawing.Size(252, 212);
            this.Composants.TabIndex = 5;
            // 
            // DeleteComposant
            // 
            this.DeleteComposant.ForeColor = System.Drawing.Color.Black;
            this.DeleteComposant.Location = new System.Drawing.Point(343, 327);
            this.DeleteComposant.Name = "DeleteComposant";
            this.DeleteComposant.Size = new System.Drawing.Size(121, 23);
            this.DeleteComposant.TabIndex = 8;
            this.DeleteComposant.Text = "Supprimer";
            this.DeleteComposant.UseVisualStyleBackColor = true;
            this.DeleteComposant.Click += new System.EventHandler(this.DeleteComposant_Click);
            // 
            // AddComposant
            // 
            this.AddComposant.ForeColor = System.Drawing.Color.Black;
            this.AddComposant.Location = new System.Drawing.Point(343, 234);
            this.AddComposant.Name = "AddComposant";
            this.AddComposant.Size = new System.Drawing.Size(121, 23);
            this.AddComposant.TabIndex = 7;
            this.AddComposant.Text = "Ajouter";
            this.AddComposant.UseVisualStyleBackColor = true;
            this.AddComposant.Click += new System.EventHandler(this.AddComposant_Click);
            // 
            // DeleteLibrary
            // 
            this.DeleteLibrary.ForeColor = System.Drawing.Color.Black;
            this.DeleteLibrary.Location = new System.Drawing.Point(343, 642);
            this.DeleteLibrary.Name = "DeleteLibrary";
            this.DeleteLibrary.Size = new System.Drawing.Size(121, 23);
            this.DeleteLibrary.TabIndex = 13;
            this.DeleteLibrary.Text = "Supprimer";
            this.DeleteLibrary.UseVisualStyleBackColor = true;
            this.DeleteLibrary.Click += new System.EventHandler(this.DeleteLibrary_Click);
            // 
            // AddLibrary
            // 
            this.AddLibrary.ForeColor = System.Drawing.Color.Black;
            this.AddLibrary.Location = new System.Drawing.Point(343, 549);
            this.AddLibrary.Name = "AddLibrary";
            this.AddLibrary.Size = new System.Drawing.Size(121, 23);
            this.AddLibrary.TabIndex = 12;
            this.AddLibrary.Text = "Ajouter";
            this.AddLibrary.UseVisualStyleBackColor = true;
            this.AddLibrary.Click += new System.EventHandler(this.AddLibrary_Click);
            // 
            // Library
            // 
            this.Library.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Library.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Library.FormattingEnabled = true;
            this.Library.Items.AddRange(new object[] {
            "DHT",
            "DS3231",
            "HC-SR04",
            "IRremote",
            "Keypad",
            "LedControl",
            "LiquidCrystal",
            "MPU6050",
            "pitches",
            "rfid",
            "Servo",
            "Stepper"});
            this.Library.Location = new System.Drawing.Point(343, 453);
            this.Library.Name = "Library";
            this.Library.Size = new System.Drawing.Size(121, 24);
            this.Library.TabIndex = 11;
            // 
            // Libraries
            // 
            this.Libraries.FormattingEnabled = true;
            this.Libraries.ItemHeight = 16;
            this.Libraries.Location = new System.Drawing.Point(59, 453);
            this.Libraries.Name = "Libraries";
            this.Libraries.Size = new System.Drawing.Size(252, 212);
            this.Libraries.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Quelles librairie allez-vous utiliser?";
            // 
            // Composant
            // 
            this.Composant.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Composant.Location = new System.Drawing.Point(343, 138);
            this.Composant.Name = "Composant";
            this.Composant.Size = new System.Drawing.Size(121, 22);
            this.Composant.TabIndex = 14;
            // 
            // Datasheets
            // 
            this.Datasheets.FormattingEnabled = true;
            this.Datasheets.ItemHeight = 16;
            this.Datasheets.Location = new System.Drawing.Point(540, 265);
            this.Datasheets.Name = "Datasheets";
            this.Datasheets.Size = new System.Drawing.Size(252, 212);
            this.Datasheets.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(472, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(370, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Quelles datasheet allez-vous utiliser?";
            // 
            // Datasheet
            // 
            this.Datasheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Datasheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datasheet.FormattingEnabled = true;
            this.Datasheet.Items.AddRange(new object[] {
            "1 digit 7-segment Display",
            "4 digit 7-segment Display",
            "Resistances",
            "1N4007",
            "4x4 Matrix Membrane Keypad",
            "5V Relay",
            "9V 1A",
            "9V Battery with DC",
            "22pf 104 Ceramic Capacitor",
            "28BYJ-48 STepper Motor",
            "74HC595",
            "130 DC Motor",
            "830 430 tie-points Breadboard",
            "Active buzzer",
            "Arduino KY-037 Sensitive microphone sensor module",
            "ArduinoMega2560",
            "Button",
            "CDS-55 Photoresistor",
            "DHT11",
            "DS3231",
            "Electrolytic Capacitor",
            "hc-sr04_ultrasonic_module_user_guidejohn",
            "HC-SR501",
            "IR Remote Control",
            "IR-Receiver-AX-1838HS",
            "JOYSTICK MODULE",
            "L293d",
            "LCD1602A",
            "LED RGB",
            "MAX7219 8x8 Matrix Display Module",
            "MF52D-103f-3950  NTC thermistor",
            "MFRC522 Datasheet",
            "Passive buzzer",
            "PN2222",
            "RM-MPU-6050A",
            "Rotary Encoder module",
            "S8050",
            "SG90",
            "Spain potentiometer",
            "Tilt Switch",
            "ULN2003A",
            "UNO Proto Shield Prototype Expansion Board",
            "UNO",
            "Uses of breadboard",
            "Water Level Sensor",
            "What is Breadboard",
            "White LED Datasheets",
            "Breadboard Power Supply Module Schematic",
            "mb_102"});
            this.Datasheet.Location = new System.Drawing.Point(487, 222);
            this.Datasheet.Name = "Datasheet";
            this.Datasheet.Size = new System.Drawing.Size(121, 24);
            this.Datasheet.TabIndex = 17;
            // 
            // AddDatasheet
            // 
            this.AddDatasheet.ForeColor = System.Drawing.Color.Black;
            this.AddDatasheet.Location = new System.Drawing.Point(614, 222);
            this.AddDatasheet.Name = "AddDatasheet";
            this.AddDatasheet.Size = new System.Drawing.Size(110, 23);
            this.AddDatasheet.TabIndex = 18;
            this.AddDatasheet.Text = "Ajouter";
            this.AddDatasheet.UseVisualStyleBackColor = true;
            this.AddDatasheet.Click += new System.EventHandler(this.AddDatasheet_Click);
            // 
            // DeleteDatasheet
            // 
            this.DeleteDatasheet.ForeColor = System.Drawing.Color.Black;
            this.DeleteDatasheet.Location = new System.Drawing.Point(730, 222);
            this.DeleteDatasheet.Name = "DeleteDatasheet";
            this.DeleteDatasheet.Size = new System.Drawing.Size(110, 23);
            this.DeleteDatasheet.TabIndex = 19;
            this.DeleteDatasheet.Text = "Supprimer";
            this.DeleteDatasheet.UseVisualStyleBackColor = true;
            this.DeleteDatasheet.Click += new System.EventHandler(this.DeleteDatasheet_Click);
            // 
            // OpenFolder
            // 
            this.OpenFolder.AutoSize = true;
            this.OpenFolder.Checked = true;
            this.OpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OpenFolder.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFolder.Location = new System.Drawing.Point(487, 509);
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(336, 23);
            this.OpenFolder.TabIndex = 20;
            this.OpenFolder.Text = "Ouvrir le dossier à la fin du processus";
            this.OpenFolder.UseVisualStyleBackColor = true;
            // 
            // FinishBtn
            // 
            this.FinishBtn.ForeColor = System.Drawing.Color.Black;
            this.FinishBtn.Location = new System.Drawing.Point(540, 568);
            this.FinishBtn.Name = "FinishBtn";
            this.FinishBtn.Size = new System.Drawing.Size(252, 42);
            this.FinishBtn.TabIndex = 21;
            this.FinishBtn.Text = "Terminer";
            this.FinishBtn.UseVisualStyleBackColor = true;
            this.FinishBtn.Click += new System.EventHandler(this.FinishBtn_Click);
            // 
            // LoadingGif
            // 
            this.LoadingGif.Image = global::CodeGen.Properties.Resources.LoadingGif;
            this.LoadingGif.Location = new System.Drawing.Point(572, 538);
            this.LoadingGif.Name = "LoadingGif";
            this.LoadingGif.Size = new System.Drawing.Size(183, 177);
            this.LoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadingGif.TabIndex = 23;
            this.LoadingGif.TabStop = false;
            this.LoadingGif.Visible = false;
            // 
            // Arduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(881, 727);
            this.Controls.Add(this.FinishBtn);
            this.Controls.Add(this.OpenFolder);
            this.Controls.Add(this.DeleteDatasheet);
            this.Controls.Add(this.AddDatasheet);
            this.Controls.Add(this.Datasheet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Datasheets);
            this.Controls.Add(this.Composant);
            this.Controls.Add(this.DeleteLibrary);
            this.Controls.Add(this.AddLibrary);
            this.Controls.Add(this.Library);
            this.Controls.Add(this.Libraries);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DeleteComposant);
            this.Controls.Add(this.AddComposant);
            this.Controls.Add(this.Composants);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.LoadingGif);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Arduino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGen | Arduino";
            this.Load += new System.EventHandler(this.Arduino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Composants;
        private System.Windows.Forms.Button DeleteComposant;
        private System.Windows.Forms.Button AddComposant;
        private System.Windows.Forms.Button DeleteLibrary;
        private System.Windows.Forms.Button AddLibrary;
        private System.Windows.Forms.ComboBox Library;
        private System.Windows.Forms.ListBox Libraries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Composant;
        private System.Windows.Forms.ListBox Datasheets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Datasheet;
        private System.Windows.Forms.Button AddDatasheet;
        private System.Windows.Forms.Button DeleteDatasheet;
        private System.Windows.Forms.CheckBox OpenFolder;
        private System.Windows.Forms.Button FinishBtn;
        private System.Windows.Forms.PictureBox LoadingGif;
    }
}