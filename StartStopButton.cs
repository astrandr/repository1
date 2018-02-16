using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsExtended
{
    public class StartStopButton : Button
    {
        public enum ButtonState
        {
            Started = 0,
            Stopped = 1
        }


        private ButtonState state = ButtonState.Stopped;
        private string text = "";
        private Color stoppedColor;

        public StartStopButton() : base()
        {
            this.Click += new EventHandler(MyButtonClickHandler);
            State = ButtonState.Stopped;
            stoppedColor = this.BackColor;
        }

        [Browsable(false)]
        public ButtonState State
        {
            get { return this.state; }
            set { this.state = value; UpdateViewPerState(); }
        }

        public void FlipState()
        {
            this.State = state == ButtonState.Started ? ButtonState.Stopped : ButtonState.Started;
        }

        private void UpdateViewPerState()
        {
            this.text = state == ButtonState.Stopped ? "Start" : "Stop";
            this.BackColor = state == ButtonState.Stopped ? stoppedColor : Color.Red;
            this.ForeColor = state == ButtonState.Stopped ? Color.Black : Color.White;
        }

        private void MyButtonClickHandler(object sender, EventArgs args)
        {
            FlipState();
        }

        public override string Text
        {
            set
            {
            }

            get
            {
                return text;
            }
        }
    }
}
