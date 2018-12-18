using Advanced_Combat_Tracker;
using Buttplug.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

[assembly: AssemblyTitle("ButtplACT")]
[assembly: AssemblyDescription("Plugin interfacing with buttplug.io to make stuff vibrate when things happen")]
[assembly: AssemblyVersion("0.1.2")]

namespace ButtplACT
{
    public class PluginSample : UserControl, IActPluginV1
    {

        #region Designer Created Code (Avoid editing)
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScanButton = new System.Windows.Forms.Button();
            this.deviceListBox = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.EventDataGrid = new System.Windows.Forms.DataGridView();
            this.ActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attacker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Victim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SaveConfigButton = new System.Windows.Forms.Button();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BaseVibrationIntensity = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.EventDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(679, 293);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(109, 23);
            this.ScanButton.TabIndex = 6;
            this.ScanButton.Text = "Scan for devices";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.Button1_ClickAsync);
            // 
            // deviceListBox
            // 
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.Location = new System.Drawing.Point(679, 15);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(227, 259);
            this.deviceListBox.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(808, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ready!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // EventDataGrid
            // 
            this.EventDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActionName,
            this.Attacker,
            this.Victim,
            this.Intensity,
            this.Duration,
            this.EnabledCheckbox});
            this.EventDataGrid.Location = new System.Drawing.Point(8, 15);
            this.EventDataGrid.Name = "EventDataGrid";
            this.EventDataGrid.Size = new System.Drawing.Size(644, 272);
            this.EventDataGrid.TabIndex = 11;
            // 
            // ActionName
            // 
            this.ActionName.HeaderText = "Action name";
            this.ActionName.Name = "ActionName";
            // 
            // Attacker
            // 
            this.Attacker.HeaderText = "Attacker";
            this.Attacker.Name = "Attacker";
            // 
            // Victim
            // 
            this.Victim.HeaderText = "Victim";
            this.Victim.Name = "Victim";
            // 
            // Intensity
            // 
            this.Intensity.HeaderText = "Intensity";
            this.Intensity.Name = "Intensity";
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // EnabledCheckbox
            // 
            this.EnabledCheckbox.FalseValue = "false";
            this.EnabledCheckbox.HeaderText = "Enabled";
            this.EnabledCheckbox.Name = "EnabledCheckbox";
            this.EnabledCheckbox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EnabledCheckbox.TrueValue = "true";
            // 
            // SaveConfigButton
            // 
            this.SaveConfigButton.Location = new System.Drawing.Point(452, 293);
            this.SaveConfigButton.Name = "SaveConfigButton";
            this.SaveConfigButton.Size = new System.Drawing.Size(97, 24);
            this.SaveConfigButton.TabIndex = 14;
            this.SaveConfigButton.Text = "Save config";
            this.SaveConfigButton.UseVisualStyleBackColor = true;
            this.SaveConfigButton.Click += new System.EventHandler(this.SaveConfigButton_Click);
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Location = new System.Drawing.Point(555, 294);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(97, 23);
            this.LoadConfigButton.TabIndex = 15;
            this.LoadConfigButton.Text = "Load config";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Base vibration intensity";
            // 
            // BaseVibrationIntensity
            // 
            this.BaseVibrationIntensity.Location = new System.Drawing.Point(126, 294);
            this.BaseVibrationIntensity.Name = "BaseVibrationIntensity";
            this.BaseVibrationIntensity.Size = new System.Drawing.Size(43, 20);
            this.BaseVibrationIntensity.TabIndex = 17;
            this.BaseVibrationIntensity.Text = "0";
            this.BaseVibrationIntensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "bpc";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // PluginSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BaseVibrationIntensity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadConfigButton);
            this.Controls.Add(this.SaveConfigButton);
            this.Controls.Add(this.EventDataGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.deviceListBox);
            this.Controls.Add(this.ScanButton);
            this.Name = "PluginSample";
            this.Size = new System.Drawing.Size(914, 330);
            ((System.ComponentModel.ISupportInitialize)(this.EventDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Button button2;

        #endregion
        private Button ScanButton;
        private CheckedListBox deviceListBox;
        private DataGridView EventDataGrid;
        private Button SaveConfigButton;
        private Button LoadConfigButton;
        private DataGridViewTextBoxColumn ActionName;
        private DataGridViewTextBoxColumn Attacker;
        private DataGridViewTextBoxColumn Victim;
        private DataGridViewTextBoxColumn Intensity;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewCheckBoxColumn EnabledCheckbox;
        private Label label1;
        private TextBox BaseVibrationIntensity;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ButtplugClient bpcl;
        private ButtplugEmbeddedConnector bpsv;

        #endregion
        public PluginSample()
        {
            InitializeComponent();
            this.deviceListBox.ItemCheck += DeviceListBox_ItemCheck;
        }

        public class ButtplACTEvent : ICloneable
        {
            private double[] intensities;
            private uint duration;
            private string victim;
            private string attacker;
            private string actionName;
            private string targetDeviceName;
            private bool absolute;
            private DateTime startTime;

            public double[] Intensities { get => intensities; set => intensities = value; }
            public uint Duration { get => duration; set => duration = value; }
            public string Victim { get => victim; set => victim = value; }
            public string Attacker { get => attacker; set => attacker = value; }
            public string ActionName { get => actionName; set => actionName = value; }
            public string TargetDeviceName { get => targetDeviceName; set => targetDeviceName = value; }
            public DateTime StartTime { get => startTime; set => startTime = value; }
            public bool Absolute { get => absolute; set => absolute = value; }

            override public string ToString()
            {
                return "duration: " + Duration
                    + "\tactionname: " + ActionName
                    + "\tvictim: " + Victim
                    + "\tattacker: " + Attacker
                    + "\tintensities: " + Intensities[0];
            }

            public ButtplACTEvent(
                double[] intensities,
                uint duration,
                string victim,
                string attacker,
                string actionname,
                string targetdevicename,
                bool absolute)
            {
                double[] fallbackIntensities = new double[1];
                fallbackIntensities[0] = 1.0;
                Intensities = intensities ?? fallbackIntensities;
                Duration = duration;
                Victim = victim ?? "";
                Attacker = attacker ?? "";
                ActionName = actionname ?? "";
                TargetDeviceName = targetdevicename ?? "";
                Absolute = absolute;
            }

            public object Clone()
            {
                return MemberwiseClone();
            }
        }

        private BlockingCollection<ButtplACTEvent> bplevents;

        private BlockingCollection<ButtplACTEvent> PreparedButtplACTEvents { get => bplevents; set => bplevents = value; }
        private List<ButtplACTEvent> KnownButtplACTEvents = new List<ButtplACTEvent>();

        List<ButtplugClientDevice> enabledDevices = new List<ButtplugClientDevice>();

        private async void DeviceListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // XXX: also allow users to disable a device...
            await bpcl.Devices[e.Index].SendVibrateCmd(.5);
            await Task.Delay(300);
            await bpcl.Devices[e.Index].SendVibrateCmd(0);

            lock (enabledDevices)
            {
                enabledDevices.Add(bpcl.Devices[e.Index]);
            }
            vibeState.Devices = enabledDevices;
        }

        Label lblStatus;    // The status label that appears in ACT's Plugin tab

        private VibeState vibeState;

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(OFormActMain_AfterCombatAction);
            ActGlobals.oFormActMain.OnCombatStart += new CombatToggleEventDelegate(OFormActMain_OnCombatStartAsync);
            ActGlobals.oFormActMain.OnCombatEnd += new CombatToggleEventDelegate(OFormActMain_OnCombatEnd);

            this.bpsv = new ButtplugEmbeddedConnector("Embedded ACT Plugin Buttplug Server");
            this.bpcl = new ButtplugClient("Embedded ACT Plugin Buttplug Client", bpsv);

            // Do I *need* to do async stuff here? lmao
            bpcl.ConnectAsync();
            vibeState = new VibeState(false, 0.0, "ambient", new List<ButtplugClientDevice>());
            lblStatus.Text = "Plugin Started";
        }

        private class VibeState : ICloneable
        {
            public bool Running { get; set; }
            public double Intensity { get; set; }
            public string Cause { get; set; }
            public List<ButtplugClientDevice> Devices { get; set; }

            public VibeState(bool running, double intensity, string cause, List<ButtplugClientDevice> devices)
            {
                Running = running;
                Intensity = intensity;
                Cause = cause;
                Devices = devices;
            }

            public object Clone()
            {
                return MemberwiseClone();
            }

            override public string ToString()
            {
                return "dev: " + Devices[0].Name + " intensity: " + Intensity + " cause: " + Cause;
            }
        }

        private IEnumerable<VibeState> ConvertEventsToVibrations()
        {
            SortedList<long, VibeState> futureEvents = new SortedList<long, VibeState>();
            while (vibeState.Running)
            {
                if (PreparedButtplACTEvents.TryTake(out ButtplACTEvent ev))
                {
                    long evTruncTicks = ev.StartTime.Ticks;
                    evTruncTicks = evTruncTicks - (evTruncTicks % 1000000) + 1000000;

                    System.Diagnostics.Debug.WriteLine("at " + DateTime.Now.Ticks + " building " + evTruncTicks + " " + ev.ActionName + " " + ev.Intensities[0]);

                    if (!futureEvents.ContainsKey(evTruncTicks) || null == futureEvents[evTruncTicks])
                    {
                        futureEvents[evTruncTicks] = (VibeState)vibeState.Clone();
                    }

                    futureEvents[evTruncTicks].Cause += " +" + ev.ActionName;
                    if (ev.Absolute)
                    {
                        futureEvents[evTruncTicks].Intensity = ev.Intensities[0];
                    }
                    else
                    {
                        futureEvents[evTruncTicks].Intensity += ev.Intensities[0];
                        // XXX: is there sugar for this..?
                        futureEvents[evTruncTicks].Intensity =
                            futureEvents[evTruncTicks].Intensity > 1 ?
                                1 : futureEvents[evTruncTicks].Intensity;
                    }
                    if (ev.Duration >= 200)
                    {
                        VibeState state = futureEvents[evTruncTicks];
                        for (int i = 0; i < ev.Duration / 100; ++i)
                        {
                            long iterTicks = evTruncTicks + i * 1000000;
                            if (!futureEvents.ContainsKey(iterTicks) || null == futureEvents[iterTicks])
                            {
                                futureEvents[iterTicks] = (VibeState)vibeState.Clone();
                                futureEvents[iterTicks].Intensity = ev.Intensities[0];
                                futureEvents[iterTicks].Cause += ev.ActionName;
                            }
                            else
                            {
                                if (!ev.Absolute)
                                {
                                    futureEvents[iterTicks].Intensity -= ev.Intensities[0];
                                    futureEvents[iterTicks].Intensity =
                                        futureEvents[iterTicks].Intensity < 0 ?
                                        0 : futureEvents[iterTicks].Intensity;
                                }
                            }
                        }
                        long eventEndTicks = evTruncTicks + (ev.Duration - 100) * 10000;
                        futureEvents[eventEndTicks].Cause += " -" + ev.ActionName;
                    }
                }
                if (futureEvents.Keys.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine("at " + DateTime.Now.Ticks + " yielding: " + futureEvents[futureEvents.Keys[0]].ToString());
                    yield return futureEvents[futureEvents.Keys[0]];
                    futureEvents.Remove(futureEvents.Keys[0]);
                }
                else
                {
                    yield return (VibeState)vibeState.Clone();
                }
            }
        }

        private Timer VibrateTimer;
        private void DoVibrations()
        {
            async void DoVibrationsTimerCallback(Object vibeStateEnumerator)
            {
                VibeState curVibeState = ((IEnumerator<VibeState>)vibeStateEnumerator).Current;
                if (curVibeState == null)
                {
                    ((IEnumerator<VibeState>)vibeStateEnumerator).MoveNext();
                    return;
                }
                foreach (ButtplugClientDevice device in curVibeState.Devices)
                {
                    System.Diagnostics.Debug.WriteLine("at " + DateTime.Now.Ticks + " actually sending vibes: " + curVibeState.ToString());
                    await device.SendVibrateCmd(curVibeState.Intensity);
                }
                ((IEnumerator<VibeState>)vibeStateEnumerator).MoveNext();
            }
            IEnumerable<VibeState> states = ConvertEventsToVibrations();
            IEnumerator<VibeState> enumerator = states.GetEnumerator();
            long start = 0;
            long inter = 100;
            VibrateTimer = new Timer(new TimerCallback(DoVibrationsTimerCallback), enumerator, start, inter);
        }

        private void OFormActMain_OnCombatStartAsync(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            lock (vibeState)
            {
                // XXX: fix this
                double baseIntensity = Double.Parse(BaseVibrationIntensity.Text);
                baseIntensity = baseIntensity > 100 ? 100 : baseIntensity < 0 ? 0 : baseIntensity;
                baseIntensity /= 100;
                this.vibeState.Intensity = baseIntensity;
                this.vibeState.Running = true;
            }
            PreparedButtplACTEvents = new BlockingCollection<ButtplACTEvent>();

            DoVibrations();
            // producer for VibeStates 
            Task.Factory.StartNew(ConvertEventsToVibrations);
        }

        void OFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            // XXX: also find actionname and whatnot
            List<ButtplACTEvent> evs = KnownButtplACTEvents.FindAll(
                c => (c.Victim.Equals("") || c.Victim.Equals(actionInfo.victim))
                    && (c.Attacker.Equals("") || c.Attacker.Equals(actionInfo.attacker)
                    && (c.ActionName.Equals("") || c.ActionName.Equals(actionInfo.theAttackType))));
            System.Diagnostics.Debug.WriteLine("action name: " + actionInfo.theAttackType);
            foreach (ButtplACTEvent ev in evs)
            {
                ButtplACTEvent actualEvent = (ButtplACTEvent)ev.Clone();
                if (actualEvent.ActionName.Equals(""))
                {
                    actualEvent.ActionName = actionInfo.theAttackType;
                }
                actualEvent.StartTime = actionInfo.time;
                PreparedButtplACTEvents.Add(actualEvent);
            }
        }

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            lock (vibeState)
            {
                vibeState.Intensity = 0;
                vibeState.Running = false;
            }
            foreach (ButtplugClientDevice dev in enabledDevices)
            {
                dev.StopDeviceCmd();
            }
            VibrateTimer.Dispose();
        }

        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.AfterCombatAction -= OFormActMain_AfterCombatAction;
            ActGlobals.oFormActMain.OnCombatStart -= OFormActMain_OnCombatStartAsync;
            ActGlobals.oFormActMain.OnCombatEnd -= OFormActMain_OnCombatEnd;
            lock (vibeState)
            {
                vibeState.Running = false;
            }
            bpcl.DisconnectAsync();
            lblStatus.Text = "Plugin Exited";
        }
        #endregion

        private bool scanning = false;

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            async Task StartScanning()
            {
                void Bpcl_DeviceAdded(object senderdev, DeviceAddedEventArgs edev)
                {
                    // XXX: super fucky stuff here, please repair
                    deviceListBox.Items.Add(edev.Device.Name + "\t" + edev.Device.Index);
                }
                bpcl.DeviceAdded += Bpcl_DeviceAdded;
                await bpcl.StartScanningAsync();
            }

            if (scanning)
            {
                await bpcl.StopScanningAsync();
                scanning = !scanning;
                ScanButton.Text = "Scan for devices";
                vibeState.Running = true;
            }
            else
            {
                vibeState.Running = false;
                await Task.Delay(100);
                await StartScanning();
                scanning = !scanning;
                ScanButton.Text = "Stop scanning";
            }
        }

        private bool settingsLocked = false;

        private void Button2_Click(object sender, EventArgs e)
        {
            if (settingsLocked)
            {
                vibeState.Running = false;
                foreach (ButtplugClientDevice dev in enabledDevices)
                {
                    dev.SendVibrateCmd(0);
                }

                ScanButton.Enabled = true;
                deviceListBox.Enabled = true;
                button2.Text = "Ready!";
                EventDataGrid.Enabled = true;

                settingsLocked = false;
            }
            else
            {
                vibeState.Running = true;
                button2.Text = "Processing...";
                ScanButton.Enabled = false;
                deviceListBox.Enabled = false;
                EventDataGrid.Enabled = false;

                KnownButtplACTEvents.Clear();

                PopulateKnownButtplACTEvents();

                settingsLocked = true;
                button2.Text = "Stop!";
            }
        }

        private void PopulateKnownButtplACTEvents()
        {
            foreach (DataGridViewRow row in EventDataGrid.Rows)
            {
                // XXX: this is stupid and I hate it
                if (row.Equals(EventDataGrid.Rows[EventDataGrid.Rows.Count - 1]))
                {
                    break;
                }
                try
                {
                    double[] intensities = new double[1];
                    intensities[0] = Double.Parse(row.Cells["Intensity"].Value.ToString());
                    intensities[0] = intensities[0] < 0 ? 0 :
                        intensities[0] > 100 ? 100 : intensities[0];
                    intensities[0] /= 100;
                    uint duration = (uint)(Double.Parse((String)row.Cells["Duration"].Value) * 1000);
                    string attacker = (String)row.Cells["Attacker"].Value;
                    string victim = (String)row.Cells["Victim"].Value;
                    string actionname = (String)row.Cells["ActionName"].Value;
                    ButtplACTEvent thisEv = new ButtplACTEvent(intensities, duration, victim, attacker, actionname, "", true);
                    KnownButtplACTEvents.Add(thisEv);
                }
                catch (FormatException fe)
                {
                    // FIXME: do actual error handling lmao
                    throw fe;
                }
            }
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            var ConfirmResult = MessageBox.Show("Saving will only save the currently enabled events.\n\nProceed?",
                "Confirm saving", MessageBoxButtons.YesNo);
            if (ConfirmResult == DialogResult.Yes && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream;
                if ((stream = (FileStream)saveFileDialog.OpenFile()) != null)
                {
                    PopulateKnownButtplACTEvents();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine(String.Format("base: {0}", BaseVibrationIntensity.Text));
                    foreach (ButtplACTEvent ev in KnownButtplACTEvents)
                    {
                        stringBuilder.AppendLine(ev.ToString());
                    }
                    byte[] bArray = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                    stream.Write(bArray, 0, bArray.Length);
                }
            }
        }

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            var ConfirmResult = MessageBox.Show("Loading a config will delete the currently entered events.\n\nProceed?",
               "Confirm loading", MessageBoxButtons.YesNo);
            if (ConfirmResult == DialogResult.Yes)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EventDataGrid.Rows.Clear();
                    KnownButtplACTEvents.Clear();
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                    string line;
                    bool first = true;
                    while (null != (line = streamReader.ReadLine()))
                    {
                        if (first)
                        {
                            BaseVibrationIntensity.Text = line.Split(':')[1].Trim();
                            first = false;
                            continue;
                        }
                        uint duration = 0;
                        string actionname = "";
                        string victim = "";
                        string attacker = "";
                        double[] intensities = new double[1];
                        foreach (String elem in line.Split('\t'))
                        {
                            string[] cur = elem.Split(':');
                            switch (cur[0])
                            {
                                case "duration": duration = uint.Parse(cur[1]); break;
                                case "actionname": actionname = cur[1].Trim(); break;
                                case "victim": victim = cur[1].Trim(); break;
                                case "attacker": attacker = cur[1].Trim(); break;
                                case "intensities": intensities[0] = double.Parse(cur[1]); break;
                            }
                        }
                        KnownButtplACTEvents.Add(new ButtplACTEvent(intensities, duration, victim, attacker, actionname, "", true));
                    }

                    foreach (ButtplACTEvent ev in KnownButtplACTEvents)
                    {
                        DataGridViewRow row = EventDataGrid.Rows[EventDataGrid.Rows.Add()];
                        row.Cells["Duration"].Value = String.Format("{0:N1}", ev.Duration / 1000.0);
                        row.Cells["ActionName"].Value = ev.ActionName;
                        row.Cells["Victim"].Value = ev.Victim;
                        row.Cells["Intensity"].Value = ev.Intensities[0] * 100; // proooobably stop this eventually huh
                        row.Cells["Attacker"].Value = ev.Attacker;
                        row.Cells["EnabledCheckbox"].Value = true;
                    }
                }
            }
        }
    }
}
