namespace ImageFiltersApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonLoad = new Button();
            buttonProcess = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBoxGray = new PictureBox();
            pictureBoxNegative = new PictureBox();
            pictureBoxThreshold = new PictureBox();
            pictureBoxMirror = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGray).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNegative).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMirror).BeginInit();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 213);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(150, 23);
            buttonLoad.TabIndex = 6;
            buttonLoad.Text = "Load Image";
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(12, 261);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(150, 23);
            buttonProcess.TabIndex = 5;
            buttonProcess.Text = "Apply Filters";
            buttonProcess.Click += buttonProcess_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxOriginal.Location = new Point(12, 12);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(150, 150);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 4;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxGray
            // 
            pictureBoxGray.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxGray.Location = new Point(202, 12);
            pictureBoxGray.Name = "pictureBoxGray";
            pictureBoxGray.Size = new Size(150, 150);
            pictureBoxGray.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxGray.TabIndex = 3;
            pictureBoxGray.TabStop = false;
            // 
            // pictureBoxNegative
            // 
            pictureBoxNegative.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxNegative.Location = new Point(202, 181);
            pictureBoxNegative.Name = "pictureBoxNegative";
            pictureBoxNegative.Size = new Size(150, 150);
            pictureBoxNegative.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxNegative.TabIndex = 2;
            pictureBoxNegative.TabStop = false;
            // 
            // pictureBoxThreshold
            // 
            pictureBoxThreshold.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxThreshold.Location = new Point(393, 12);
            pictureBoxThreshold.Name = "pictureBoxThreshold";
            pictureBoxThreshold.Size = new Size(150, 150);
            pictureBoxThreshold.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxThreshold.TabIndex = 1;
            pictureBoxThreshold.TabStop = false;
            // 
            // pictureBoxMirror
            // 
            pictureBoxMirror.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxMirror.Location = new Point(393, 181);
            pictureBoxMirror.Name = "pictureBoxMirror";
            pictureBoxMirror.Size = new Size(150, 150);
            pictureBoxMirror.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMirror.TabIndex = 0;
            pictureBoxMirror.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            // 
            // Form1
            // 
            ClientSize = new Size(567, 350);
            Controls.Add(pictureBoxMirror);
            Controls.Add(pictureBoxThreshold);
            Controls.Add(pictureBoxNegative);
            Controls.Add(pictureBoxGray);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(buttonProcess);
            Controls.Add(buttonLoad);
            Name = "Form1";
            Text = "Parallel Image Processor";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGray).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxNegative).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMirror).EndInit();
            ResumeLayout(false);
        }

        private Button buttonLoad;
        private Button buttonProcess;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxGray;
        private PictureBox pictureBoxNegative;
        private PictureBox pictureBoxThreshold;
        private PictureBox pictureBoxMirror;
        private OpenFileDialog openFileDialog1;
    }
}
