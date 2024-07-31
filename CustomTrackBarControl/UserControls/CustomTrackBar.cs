using CustomTrackBarControl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CustomTrackBarControl.Models;

namespace CustomTrackBarControl.UserControls
{
    public partial class CustomTrackBar : UserControl
    {
        #region Fields

        private int _value1;
        private int _value2;
        private int _minimum;
        private int _maximum;
        private bool _hoveringThumb1;
        private bool _hoveringThumb2;
        private bool _draggingThumb1;
        private bool _draggingThumb2;
        private bool _highlightRange = true;
        private Color _rangeColor;
        private List<Event> _events = new List<Event>();

        #endregion

        #region Events

        [Category("Behavior")]
        [Description("Occurs when the first thumb's value changes.")]
        public event EventHandler Value1Changed;

        [Category("Behavior")]
        [Description("Occurs when the second thumb's value changes.")]
        public event EventHandler Value2Changed;

        [Category("Behavior")]
        [Description("Occurs when the first thumb is pressed.")]
        public event EventHandler Thumb1Pressed;

        [Category("Behavior")]
        [Description("Occurs when the second thumb is pressed.")]
        public event EventHandler Thumb2Pressed;

        [Category("Behavior")]
        [Description("Occurs when the first thumb is released.")]
        public event EventHandler Thumb1Released;

        [Category("Behavior")]
        [Description("Occurs when the second thumb is released.")]
        public event EventHandler Thumb2Released;

        [Category("Behavior")]
        [Description("Occurs when an event on the timeline is clicked.")]
        public event EventHandler<Event> EventClicked;

        #endregion

        #region Properties

        [Category("Appearance")]
        [Description("Determines whether the range between the thumbs is highlighted.")]
        public bool HighlightRange
        {
            get => _highlightRange;
            set
            {
                if (_highlightRange != value)
                {
                    _highlightRange = value;
                    Invalidate();
                }
            }
        }

        [Category("Appearance")]
        [Description("The color used to highlight the range between the thumbs.")]
        public Color RangeColor
        {
            get => _rangeColor;
            set
            {
                if (_rangeColor != value)
                {
                    _rangeColor = value;
                    Invalidate();
                }
            }
        }

        public int Value1
        {
            get => _value1;
            set
            {
                if (_value1 != value)
                {
                    _value1 = Math.Max(_minimum, Math.Min(_maximum, value));
                    Invalidate();
                    OnValue1Changed(EventArgs.Empty);
                }
            }
        }

        public int Value2
        {
            get => _value2;
            set
            {
                if (_value2 != value)
                {
                    _value2 = Math.Max(_minimum, Math.Min(_maximum, value));
                    Invalidate();
                    OnValue2Changed(EventArgs.Empty);
                }
            }
        }

        public int Minimum
        {
            get => _minimum;
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    if (_minimum > _maximum) _maximum = _minimum;
                    if (_value1 < _minimum) _value1 = _minimum;
                    if (_value2 < _minimum) _value2 = _minimum;
                    Invalidate();
                }
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    if (_maximum < _minimum) _minimum = _maximum;
                    if (_value1 > _maximum) _value1 = _maximum;
                    if (_value2 > _maximum) _value2 = _maximum;
                    Invalidate();
                }
            }
        }

        #endregion

        #region Constructor

        public CustomTrackBar()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Resize += (s, e) => Invalidate();
        }

        #endregion

        #region Methods

        public void AddEvent(int value, string description)
        {
            // Ensure the value is within the range
            value = Math.Max(Minimum, Math.Min(Maximum, value));

            var ev = new Event
            {
                TimeStamp = value.ToString(),
                Description = description
            };

            _events.Add(ev);
            Invalidate();
        }

        public void ClearEvents()
        {
            _events.Clear();
            Invalidate();
        }

        #endregion

        #region Override Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawChannel(e.Graphics);
            DrawEvents(e.Graphics);
            if (_highlightRange)
            {
                DrawHighlightedRange(e.Graphics);
            }
            DrawThumbs(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Check if an event is clicked
            foreach (var ev in _events)
            {
                var value = int.Parse(ev.TimeStamp);
                if (GetTickRectangle(value).Contains(e.Location))
                {
                    OnEventClicked(ev);
                    return; // Exit if an event was clicked
                }
            }

            if (GetThumbRectangle(Value1).Contains(e.Location))
            {
                Capture = true;
                _draggingThumb1 = true;
                OnThumb1Pressed(EventArgs.Empty);
                Invalidate();
            }
            else if (GetThumbRectangle(Value2).Contains(e.Location))
            {
                Capture = true;
                _draggingThumb2 = true;
                OnThumb2Pressed(EventArgs.Empty);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Capture = false;

            if (_draggingThumb1)
            {
                _draggingThumb1 = false;
                OnThumb1Released(EventArgs.Empty);
                Invalidate();
            }

            if (_draggingThumb2)
            {
                _draggingThumb2 = false;
                OnThumb2Released(EventArgs.Empty);
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            bool wasHoveringThumb1 = _hoveringThumb1;
            bool wasHoveringThumb2 = _hoveringThumb2;
            bool hoveringEvent = false;

            foreach (var ev in _events)
            {
                var value = int.Parse(ev.TimeStamp);
                if (GetTickRectangle(value).Contains(e.Location))
                {
                    hoveringEvent = true;
                    Cursor = Cursors.Hand;
                    break;
                }
            }

            if (!hoveringEvent)
            {
                Cursor = Cursors.Default;
            }

            _hoveringThumb1 = !_draggingThumb2 && GetThumbRectangle(Value1).Contains(e.Location);
            _hoveringThumb2 = !_draggingThumb1 && GetThumbRectangle(Value2).Contains(e.Location);

            if (_hoveringThumb1 != wasHoveringThumb1 || _hoveringThumb2 != wasHoveringThumb2)
            {
                Invalidate(); // Repaint if hover state changes
            }

            if (_draggingThumb1)
            {
                Value1 = Math.Max(Minimum, Math.Min(Minimum + (e.X - 10) * (Maximum - Minimum) / (Width - 20), Maximum));
            }
            else if (_draggingThumb2)
            {
                Value2 = Math.Max(Minimum, Math.Min(Minimum + (e.X - 10) * (Maximum - Minimum) / (Width - 20), Maximum));
            }
        }

        #endregion

        #region Helper Methods

        private void DrawChannel(Graphics graphics)
        {
            if (TrackBarRenderer.IsSupported)
            {
                var channelRect = new Rectangle(10, Height / 2 - 2, Width - 20, 4);
                TrackBarRenderer.DrawHorizontalTrack(graphics, channelRect);
            }
        }

        private void DrawHighlightedRange(Graphics graphics)
        {
            var thumb1Rect = GetThumbRectangle(Value1);
            var thumb2Rect = GetThumbRectangle(Value2);
            var lowerThumbRect = thumb1Rect.X < thumb2Rect.X ? thumb1Rect : thumb2Rect;
            var higherThumbRect = thumb1Rect.X < thumb2Rect.X ? thumb2Rect : thumb1Rect;

            var rangeRect = new Rectangle(
                lowerThumbRect.Right,
                Height / 2 - 2,
                higherThumbRect.Left - lowerThumbRect.Right,
                4);

            using (var brush = new SolidBrush(_rangeColor))
            {
                graphics.FillRectangle(brush, rangeRect);
            }
        }

        private void DrawThumbs(Graphics graphics)
        {
            var thumb1Rect = GetThumbRectangle(Value1);
            var thumb2Rect = GetThumbRectangle(Value2);

            TrackBarThumbState thumb1State = TrackBarThumbState.Normal;
            TrackBarThumbState thumb2State = TrackBarThumbState.Normal;

            if (_draggingThumb1)
            {
                thumb1State = TrackBarThumbState.Pressed;
                thumb2State = _hoveringThumb2 ? TrackBarThumbState.Hot : TrackBarThumbState.Normal;
            }
            else if (_draggingThumb2)
            {
                thumb2State = TrackBarThumbState.Pressed;
                thumb1State = _hoveringThumb1 ? TrackBarThumbState.Hot : TrackBarThumbState.Normal;
            }
            else
            {
                thumb1State = _hoveringThumb1 ? TrackBarThumbState.Hot : TrackBarThumbState.Normal;
                thumb2State = _hoveringThumb2 ? TrackBarThumbState.Hot : TrackBarThumbState.Normal;
            }

            TrackBarRenderer.DrawBottomPointingThumb(graphics, thumb1Rect, thumb1State);
            TrackBarRenderer.DrawBottomPointingThumb(graphics, thumb2Rect, thumb2State);
        }

        private void DrawEvents(Graphics graphics)
        {
            foreach (var ev in _events)
            {
                var value = int.Parse(ev.TimeStamp); // Ensure this is an int
                var tickRect = GetTickRectangle(value);
                using (var brush = new SolidBrush(Color.Black)) // Customize color if needed
                {
                    graphics.FillRectangle(brush, tickRect);
                }
            }
        }

        private Rectangle GetThumbRectangle(int value)
        {
            var thumbSize = TrackBarRenderer.GetBottomPointingThumbSize(Graphics.FromHwnd(Handle), TrackBarThumbState.Normal);
            var x = 10 + (value - Minimum) * (Width - 20 - thumbSize.Width) / (Maximum - Minimum);
            var y = (Height - thumbSize.Height) / 2;
            return new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
        }

        private Rectangle GetTickRectangle(int value)
        {
            var thumbSize = TrackBarRenderer.GetBottomPointingThumbSize(Graphics.FromHwnd(Handle), TrackBarThumbState.Normal);
            var x = 10 + (value - Minimum) * (Width - 20 - thumbSize.Width) / (Maximum - Minimum) + (thumbSize.Width / 2) - 1;
            return new Rectangle(x, Height / 2 - 10, 2, 20); // Adjust the size as needed
        }

        #endregion

        #region Event Invokers

        protected virtual void OnValue1Changed(EventArgs e) => Value1Changed?.Invoke(this, e);
        protected virtual void OnValue2Changed(EventArgs e) => Value2Changed?.Invoke(this, e);
        protected virtual void OnThumb1Pressed(EventArgs e) => Thumb1Pressed?.Invoke(this, e);
        protected virtual void OnThumb2Pressed(EventArgs e) => Thumb2Pressed?.Invoke(this, e);
        protected virtual void OnThumb1Released(EventArgs e) => Thumb1Released?.Invoke(this, e);
        protected virtual void OnThumb2Released(EventArgs e) => Thumb2Released?.Invoke(this, e);
        protected virtual void OnEventClicked(Event ev) => EventClicked?.Invoke(this, ev);

        #endregion
    }

}
