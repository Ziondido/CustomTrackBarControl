# 🎛️ CustomTrackBarControl

Welcome to **CustomTrackBarControl** – a cutting-edge, modern WinForms custom track bar control! This control boasts dual thumbs, dynamic range highlighting, and a brand-new feature for creating and interacting with events on the timeline. Perfect for developers looking to add a sleek and functional UI element to their applications.

## 🌟 Features

- **Dual Thumbs**: Independently control two thumb positions for enhanced functionality.
- **Range Highlighting**: Highlight the range between the thumbs with customizable colors.
- **Timeline Events**: Create and manage events directly on the track bar timeline. Click events to interact.
- **Customizable Appearance**: Tailor the control's look to fit your application's theme.
- **Interactive Events**: Respond to user interactions with a variety of events, including event clicks.

## 🚀 Getting Started

### Prerequisites

- .NET Framework 4.7.2 or later
- Visual Studio 2019 or later

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/CustomTrackBarControl.git
   ```

2. Open the solution file in Visual Studio.

3. Build the solution.

## 📋 Usage

### Basic Example

```csharp
using System;
using System.Windows.Forms;
using WinFormsApp1;
using ThisIsAirSync.Models; // Make sure to include your namespace

namespace ExampleApp
{
    public class MainForm : Form
    {
        private CustomTrackBarControl customTrackBar;
        private Button addButton;
        private CheckBox highlightCheckBox;
        private int eventCounter;

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            customTrackBar = new CustomTrackBarControl
            {
                Minimum = 0,
                Maximum = 100,
                Value1 = 25,
                Value2 = 75,
                HighlightRange = true,
                RangeColor = Color.Blue,
                Dock = DockStyle.Top
            };
            customTrackBar.EventClicked += CustomTrackBar_EventClicked;

            addButton = new Button
            {
                Text = "Add Event",
                Dock = DockStyle.Top
            };
            addButton.Click += AddButton_Click;

            highlightCheckBox = new CheckBox
            {
                Text = "Highlight Enabled",
                Dock = DockStyle.Top,
                Checked = true
            };
            highlightCheckBox.CheckedChanged += HighlightCheckBox_CheckedChanged;

            Controls.Add(customTrackBar);
            Controls.Add(addButton);
            Controls.Add(highlightCheckBox);
        }

        private void CustomTrackBar_EventClicked(object sender, Event e)
        {
            MessageBox.Show($"Event clicked: {e.Description}");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int eventValue = (eventCounter++ * 10) % customTrackBar.Maximum;
            customTrackBar.AddEvent(eventValue, $"Event {eventCounter}");
        }

        private void HighlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customTrackBar.HighlightRange = highlightCheckBox.Checked;
        }
    }

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
```

### Properties

- **Value1**: Gets or sets the value of the first thumb.
- **Value2**: Gets or sets the value of the second thumb.
- **Minimum**: Gets or sets the minimum value of the track bar.
- **Maximum**: Gets or sets the maximum value of the track bar.
- **HighlightRange**: Determines whether the range between the thumbs is highlighted.
- **RangeColor**: The color used to highlight the range between the thumbs.

### New Feature: Timeline Events

- **AddEvent(int value, string description)**: Adds an event at the specified value with a description.
- **EventClicked**: Occurs when an event on the timeline is clicked.

### Events

- **Value1Changed**: Occurs when the first thumb's value changes.
- **Value2Changed**: Occurs when the second thumb's value changes.
- **Thumb1Pressed**: Occurs when the first thumb is pressed.
- **Thumb2Pressed**: Occurs when the second thumb is pressed.
- **Thumb1Released**: Occurs when the first thumb is released.
- **Thumb2Released**: Occurs when the second thumb is released.
- **EventClicked**: Occurs when a new event is created on the timeline.

## 🌐 Contributing

Join us in making **CustomTrackBarControl** even better! Contributions are welcome and appreciated. Here’s how you can contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a pull request.

## 📜 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 📧 Contact

Have questions or feedback? Open an issue or reach out at [your-email@example.com](mailto:your-email@example.com).

