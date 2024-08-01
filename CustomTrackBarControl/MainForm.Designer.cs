namespace CustomTrackBarControl
{
    partial class MainForm
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
            customTrackBar = new UserControls.CustomTrackBar();
            addButton = new Button();
            highlightCheckBox = new CheckBox();
            eventValueNumericUpDown = new NumericUpDown();
            thumb1ValueNumericUpDown = new NumericUpDown();
            thumb2ValueNumericUpDown = new NumericUpDown();
            setThumbValuesButton = new Button();
            loggerListBox = new ListBox();
            mainTableLayoutPanel = new TableLayoutPanel();
            trackBarGroupBox = new GroupBox();
            controlsTableLayoutPanel = new TableLayoutPanel();
            eventsGroupBox = new GroupBox();
            thumbsGroupBox = new GroupBox();
            checkBox1 = new CheckBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            loggerGroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)eventValueNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thumb1ValueNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thumb2ValueNumericUpDown).BeginInit();
            mainTableLayoutPanel.SuspendLayout();
            trackBarGroupBox.SuspendLayout();
            controlsTableLayoutPanel.SuspendLayout();
            eventsGroupBox.SuspendLayout();
            thumbsGroupBox.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            loggerGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // customTrackBar
            // 
            customTrackBar.Dock = DockStyle.Fill;
            customTrackBar.HighlightRange = false;
            customTrackBar.Location = new Point(3, 27);
            customTrackBar.Margin = new Padding(5, 6, 5, 6);
            customTrackBar.Maximum = 1000000;
            customTrackBar.Minimum = 0;
            customTrackBar.Mode = UserControls.CustomTrackBar.TrackBarMode.Regular;
            customTrackBar.Name = "customTrackBar";
            customTrackBar.RangeColor = Color.LightBlue;
            customTrackBar.Size = new Size(820, 84);
            customTrackBar.TabIndex = 0;
            customTrackBar.Value1 = 1;
            customTrackBar.Value2 = 2;
            customTrackBar.Value1Changed += customTrackBar_ValueChanged;
            customTrackBar.Value2Changed += customTrackBar_ValueChanged;
            customTrackBar.EventClicked += customTrackBar_EventClicked;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Bottom;
            addButton.Location = new Point(3, 99);
            addButton.Name = "addButton";
            addButton.Size = new Size(401, 36);
            addButton.TabIndex = 1;
            addButton.Text = "Add Event";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // highlightCheckBox
            // 
            highlightCheckBox.AutoSize = true;
            highlightCheckBox.Location = new Point(3, 64);
            highlightCheckBox.Name = "highlightCheckBox";
            highlightCheckBox.Size = new Size(179, 29);
            highlightCheckBox.TabIndex = 2;
            highlightCheckBox.Text = "Highlight Enabled";
            highlightCheckBox.UseVisualStyleBackColor = true;
            highlightCheckBox.CheckedChanged += highlightCheckBox_CheckedChanged;
            // 
            // eventValueNumericUpDown
            // 
            eventValueNumericUpDown.Dock = DockStyle.Top;
            eventValueNumericUpDown.Location = new Point(3, 27);
            eventValueNumericUpDown.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            eventValueNumericUpDown.Name = "eventValueNumericUpDown";
            eventValueNumericUpDown.Size = new Size(401, 31);
            eventValueNumericUpDown.TabIndex = 4;
            // 
            // thumb1ValueNumericUpDown
            // 
            thumb1ValueNumericUpDown.Dock = DockStyle.Fill;
            thumb1ValueNumericUpDown.Location = new Point(3, 3);
            thumb1ValueNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            thumb1ValueNumericUpDown.Name = "thumb1ValueNumericUpDown";
            thumb1ValueNumericUpDown.Size = new Size(194, 31);
            thumb1ValueNumericUpDown.TabIndex = 5;
            thumb1ValueNumericUpDown.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // thumb2ValueNumericUpDown
            // 
            thumb2ValueNumericUpDown.Dock = DockStyle.Fill;
            thumb2ValueNumericUpDown.Location = new Point(203, 3);
            thumb2ValueNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            thumb2ValueNumericUpDown.Name = "thumb2ValueNumericUpDown";
            thumb2ValueNumericUpDown.Size = new Size(195, 31);
            thumb2ValueNumericUpDown.TabIndex = 6;
            thumb2ValueNumericUpDown.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // setThumbValuesButton
            // 
            setThumbValuesButton.Dock = DockStyle.Bottom;
            setThumbValuesButton.Location = new Point(3, 102);
            setThumbValuesButton.Name = "setThumbValuesButton";
            setThumbValuesButton.Size = new Size(401, 33);
            setThumbValuesButton.TabIndex = 7;
            setThumbValuesButton.Text = "Set Thumb Values";
            setThumbValuesButton.UseVisualStyleBackColor = true;
            setThumbValuesButton.Click += setThumbValuesButton_Click;
            // 
            // loggerListBox
            // 
            loggerListBox.Dock = DockStyle.Fill;
            loggerListBox.FormattingEnabled = true;
            loggerListBox.ItemHeight = 25;
            loggerListBox.Location = new Point(3, 27);
            loggerListBox.Name = "loggerListBox";
            loggerListBox.Size = new Size(820, 344);
            loggerListBox.TabIndex = 8;
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 1;
            mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayoutPanel.Controls.Add(trackBarGroupBox, 0, 0);
            mainTableLayoutPanel.Controls.Add(controlsTableLayoutPanel, 0, 1);
            mainTableLayoutPanel.Controls.Add(loggerGroupBox, 0, 2);
            mainTableLayoutPanel.Dock = DockStyle.Fill;
            mainTableLayoutPanel.Location = new Point(0, 0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayoutPanel.Size = new Size(832, 650);
            mainTableLayoutPanel.TabIndex = 9;
            // 
            // trackBarGroupBox
            // 
            trackBarGroupBox.Controls.Add(customTrackBar);
            trackBarGroupBox.Dock = DockStyle.Fill;
            trackBarGroupBox.Location = new Point(3, 3);
            trackBarGroupBox.Name = "trackBarGroupBox";
            trackBarGroupBox.Size = new Size(826, 114);
            trackBarGroupBox.TabIndex = 11;
            trackBarGroupBox.TabStop = false;
            trackBarGroupBox.Text = "TrackBar Control";
            // 
            // controlsTableLayoutPanel
            // 
            controlsTableLayoutPanel.ColumnCount = 2;
            controlsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controlsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controlsTableLayoutPanel.Controls.Add(eventsGroupBox, 0, 0);
            controlsTableLayoutPanel.Controls.Add(thumbsGroupBox, 1, 0);
            controlsTableLayoutPanel.Dock = DockStyle.Fill;
            controlsTableLayoutPanel.Location = new Point(3, 123);
            controlsTableLayoutPanel.Name = "controlsTableLayoutPanel";
            controlsTableLayoutPanel.RowCount = 1;
            controlsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            controlsTableLayoutPanel.Size = new Size(826, 144);
            controlsTableLayoutPanel.TabIndex = 10;
            // 
            // eventsGroupBox
            // 
            eventsGroupBox.Controls.Add(eventValueNumericUpDown);
            eventsGroupBox.Controls.Add(addButton);
            eventsGroupBox.Controls.Add(highlightCheckBox);
            eventsGroupBox.Dock = DockStyle.Fill;
            eventsGroupBox.Location = new Point(3, 3);
            eventsGroupBox.Name = "eventsGroupBox";
            eventsGroupBox.Size = new Size(407, 138);
            eventsGroupBox.TabIndex = 12;
            eventsGroupBox.TabStop = false;
            eventsGroupBox.Text = "Add Events";
            // 
            // thumbsGroupBox
            // 
            thumbsGroupBox.Controls.Add(checkBox1);
            thumbsGroupBox.Controls.Add(tableLayoutPanel3);
            thumbsGroupBox.Controls.Add(setThumbValuesButton);
            thumbsGroupBox.Dock = DockStyle.Fill;
            thumbsGroupBox.Location = new Point(416, 3);
            thumbsGroupBox.Name = "thumbsGroupBox";
            thumbsGroupBox.Size = new Size(407, 138);
            thumbsGroupBox.TabIndex = 13;
            thumbsGroupBox.TabStop = false;
            thumbsGroupBox.Text = "Thumbs Control";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(26, 62);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(121, 29);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(thumb1ValueNumericUpDown, 0, 0);
            tableLayoutPanel3.Controls.Add(thumb2ValueNumericUpDown, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(3, 27);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(401, 34);
            tableLayoutPanel3.TabIndex = 8;
            // 
            // loggerGroupBox
            // 
            loggerGroupBox.Controls.Add(loggerListBox);
            loggerGroupBox.Dock = DockStyle.Fill;
            loggerGroupBox.Location = new Point(3, 273);
            loggerGroupBox.Name = "loggerGroupBox";
            loggerGroupBox.Size = new Size(826, 374);
            loggerGroupBox.TabIndex = 14;
            loggerGroupBox.TabStop = false;
            loggerGroupBox.Text = "Logger";
            // 
            // MainForm
            // 
            ClientSize = new Size(832, 650);
            Controls.Add(mainTableLayoutPanel);
            Name = "MainForm";
            Text = "Custom TrackBar Example";
            ((System.ComponentModel.ISupportInitialize)eventValueNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)thumb1ValueNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)thumb2ValueNumericUpDown).EndInit();
            mainTableLayoutPanel.ResumeLayout(false);
            trackBarGroupBox.ResumeLayout(false);
            controlsTableLayoutPanel.ResumeLayout(false);
            eventsGroupBox.ResumeLayout(false);
            eventsGroupBox.PerformLayout();
            thumbsGroupBox.ResumeLayout(false);
            thumbsGroupBox.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            loggerGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private ListBox listBox1;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel3;
        private CheckBox checkBox1;
    }
}