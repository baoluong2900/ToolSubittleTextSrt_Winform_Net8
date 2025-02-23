namespace ToolSubittleTextSrt
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
            btnSelectFile = new Button();
            listbxData = new ListBox();
            btnRun = new Button();
            btnReset = new Button();
            btnRemoveNumber = new Button();
            btnDeleteMutilveFile = new Button();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.Location = new Point(563, 48);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(152, 23);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // listbxData
            // 
            listbxData.AllowDrop = true;
            listbxData.FormattingEnabled = true;
            listbxData.ItemHeight = 15;
            listbxData.Location = new Point(50, 48);
            listbxData.Name = "listbxData";
            listbxData.Size = new Size(461, 379);
            listbxData.TabIndex = 1;
            listbxData.DragDrop += listbxData_DragDrop;
            listbxData.DragEnter += listbxData_DragEnter;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(563, 103);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(152, 23);
            btnRun.TabIndex = 2;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(563, 219);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(152, 23);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnRemoveNumber
            // 
            btnRemoveNumber.Location = new Point(563, 162);
            btnRemoveNumber.Name = "btnRemoveNumber";
            btnRemoveNumber.Size = new Size(152, 23);
            btnRemoveNumber.TabIndex = 4;
            btnRemoveNumber.Text = "Remove Number";
            btnRemoveNumber.UseVisualStyleBackColor = true;
            btnRemoveNumber.Click += button1_Click;
            // 
            // btnDeleteMutilveFile
            // 
            btnDeleteMutilveFile.Location = new Point(563, 276);
            btnDeleteMutilveFile.Name = "btnDeleteMutilveFile";
            btnDeleteMutilveFile.Size = new Size(152, 23);
            btnDeleteMutilveFile.TabIndex = 5;
            btnDeleteMutilveFile.Text = "Delete File";
            btnDeleteMutilveFile.UseVisualStyleBackColor = true;
            btnDeleteMutilveFile.Click += btnDeleteMutilveFile_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteMutilveFile);
            Controls.Add(btnRemoveNumber);
            Controls.Add(btnReset);
            Controls.Add(btnRun);
            Controls.Add(listbxData);
            Controls.Add(btnSelectFile);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectFile;
        private ListBox listbxData;
        private Button btnRun;
        private Button btnReset;
        private Button btnRemoveNumber;
        private Button btnDeleteMutilveFile;
    }
}
