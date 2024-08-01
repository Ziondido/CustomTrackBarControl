using System;
using System.Windows.Forms;
using CustomTrackBarControl.UserControls;
using CustomTrackBarControl.Models;

namespace CustomTrackBarControl
{

    public partial class MainForm : Form
    {

        private CustomTrackBar customTrackBar;
        private Button addButton;
        private CheckBox highlightCheckBox;
        private NumericUpDown eventValueNumericUpDown;
        private NumericUpDown thumb1ValueNumericUpDown;
        private NumericUpDown thumb2ValueNumericUpDown;
        private Button setThumbValuesButton;
        private ListBox loggerListBox;
        private TableLayoutPanel mainTableLayoutPanel;
        private TableLayoutPanel controlsTableLayoutPanel;
        private GroupBox trackBarGroupBox;
        private GroupBox eventsGroupBox;
        private GroupBox thumbsGroupBox;
        private GroupBox loggerGroupBox;
        private int eventCounter;




        public MainForm()
        {

            InitializeComponent();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            int eventValue = (int)eventValueNumericUpDown.Value;
            string description = $"Event {++eventCounter}";
            customTrackBar.AddEvent(eventValue, description);
            loggerListBox.Items.Add($"Added event at {eventValue}: {description}");
        }

        private void highlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customTrackBar.HighlightRange = highlightCheckBox.Checked;
            loggerListBox.Items.Add($"Highlight range: {highlightCheckBox.Checked}");
        }

        private void setThumbValuesButton_Click(object sender, EventArgs e)
        {
            customTrackBar.Value1 = (int)thumb1ValueNumericUpDown.Value;
            customTrackBar.Value2 = (int)thumb2ValueNumericUpDown.Value;
            loggerListBox.Items.Add($"Set Thumb1 to {customTrackBar.Value1}, Thumb2 to {customTrackBar.Value2}");
        }

        private void customTrackBar_EventClicked(object sender, CustomTrackBarControl.Models.Event e)
        {
            MessageBox.Show($"Event clicked: {e.Description}");
            loggerListBox.Items.Add($"Event clicked: {e.Description}");
        }

        private void customTrackBar_ValueChanged(object sender, EventArgs e)
        {
            thumb1ValueNumericUpDown.Value = customTrackBar.Value1;
            thumb2ValueNumericUpDown.Value = customTrackBar.Value2;
            loggerListBox.Items.Add($"Thumb1: {customTrackBar.Value1}, Thumb2: {customTrackBar.Value2}");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (customTrackBar.Mode == CustomTrackBar.TrackBarMode.Edit)
            {
                customTrackBar.Mode = CustomTrackBar.TrackBarMode.Regular;
            }
            else
            {
                customTrackBar.Mode = CustomTrackBar.TrackBarMode.Edit;
            }
        }
    }
}
