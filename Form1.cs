using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormStates
{
    public partial class Form1 : Form
    {
        Dictionary<string, IEnumerable<Control>> controlsForState = new Dictionary<string, IEnumerable<Control>>();

        private void SetState(string name)
        {
            foreach (string stateName in controlsForState.Keys)
            {
                bool enabledState = stateName == name;
                foreach (Control control in controlsForState[stateName])
                {
                    control.Enabled = enabledState;
                }
            }
        }

        /// <summary>
        /// FindStatesByControlsName - in order name of the control to indicate state the name must be like <controlname>_S1_S2.
        ///                             For instance "button1_S1_S4"
        /// </controlname>
        /// </summary>
        private void FindStatesByControlsName()
        {
            List<string> stateNames = new List<string>();

            foreach (Control control in this.Controls)
            {
                string controlName = control.Tag != null ? control.Tag.ToString() : String.Empty;
                string[] tokens = controlName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries );
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (!stateNames.Contains(tokens[i]))
                    {
                        stateNames.Add(tokens[i]);
                    }
                }
            }

            foreach (string stateName in stateNames)
            {
                controlsForState.Add(stateName, Controls.OfType<Control>().Where<Control>(c => c.Tag != null && c.Tag.ToString().Contains(stateName)));
            }
        }


        public Form1()
        {
            InitializeComponent();

            FindStatesByControlsName();

            SetState("S1");
        }

        private void button1_S1_Click(object sender, EventArgs e)
        {
            SetState("S2");
        }

        private void button2_S2_Click(object sender, EventArgs e)
        {
            SetState("S3");
        }

        private void button3_S3_Click(object sender, EventArgs e)
        {
            SetState("S1");
        }
    }
}
