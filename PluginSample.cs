using Advanced_Combat_Tracker;
using Buttplug.Client;
using Buttplug.Core;
using Buttplug.Core.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Timer = System.Threading.Timer;

[assembly: AssemblyTitle("ButtplACT")]
[assembly: AssemblyDescription("Minimalistic plugin interfacing with buttplug.io to make stuff vibrate when someone gets hit")]
[assembly: AssemblyVersion("0.0.1")]

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
            this.label1 = new System.Windows.Forms.Label();
            this.IncomingTargetTextBox = new System.Windows.Forms.TextBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.deviceListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baseIntensityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IncomingImpactIntensityTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.OutgoingTargetTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OutgoingImpactIntensityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incoming target";
            // 
            // IncomingTargetTextBox
            // 
            this.IncomingTargetTextBox.Location = new System.Drawing.Point(205, 15);
            this.IncomingTargetTextBox.Name = "IncomingTargetTextBox";
            this.IncomingTargetTextBox.Size = new System.Drawing.Size(227, 20);
            this.IncomingTargetTextBox.TabIndex = 1;
            this.IncomingTargetTextBox.Text = "YOU";
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(8, 179);
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
            this.deviceListBox.Location = new System.Drawing.Point(205, 166);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(227, 94);
            this.deviceListBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base intensity";
            // 
            // baseIntensityTextBox
            // 
            this.baseIntensityTextBox.Location = new System.Drawing.Point(205, 75);
            this.baseIntensityTextBox.Name = "baseIntensityTextBox";
            this.baseIntensityTextBox.Size = new System.Drawing.Size(227, 20);
            this.baseIntensityTextBox.TabIndex = 3;
            this.baseIntensityTextBox.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Incoming impact intensity";
            // 
            // IncomingImpactIntensityTextBox
            // 
            this.IncomingImpactIntensityTextBox.Location = new System.Drawing.Point(205, 102);
            this.IncomingImpactIntensityTextBox.Name = "IncomingImpactIntensityTextBox";
            this.IncomingImpactIntensityTextBox.Size = new System.Drawing.Size(227, 20);
            this.IncomingImpactIntensityTextBox.TabIndex = 4;
            this.IncomingImpactIntensityTextBox.Text = "80";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ready!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Outgoing target";
            // 
            // OutgoingTargetTextBox
            // 
            this.OutgoingTargetTextBox.Location = new System.Drawing.Point(205, 42);
            this.OutgoingTargetTextBox.Name = "OutgoingTargetTextBox";
            this.OutgoingTargetTextBox.Size = new System.Drawing.Size(227, 20);
            this.OutgoingTargetTextBox.TabIndex = 2;
            this.OutgoingTargetTextBox.Text = "YOU";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Outgoing impact intensity";
            // 
            // OutgoingImpactIntensityTextBox
            // 
            this.OutgoingImpactIntensityTextBox.Location = new System.Drawing.Point(205, 132);
            this.OutgoingImpactIntensityTextBox.Name = "OutgoingImpactIntensityTextBox";
            this.OutgoingImpactIntensityTextBox.Size = new System.Drawing.Size(227, 20);
            this.OutgoingImpactIntensityTextBox.TabIndex = 5;
            this.OutgoingImpactIntensityTextBox.Text = "45";
            // 
            // PluginSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OutgoingImpactIntensityTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutgoingTargetTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.IncomingImpactIntensityTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baseIntensityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deviceListBox);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.IncomingTargetTextBox);
            this.Controls.Add(this.label1);
            this.Name = "PluginSample";
            this.Size = new System.Drawing.Size(686, 384);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label2;
        private TextBox baseIntensityTextBox;
        private Label label3;
        private TextBox IncomingImpactIntensityTextBox;
        private Button button2;
        private Label label4;

        #endregion

        private TextBox IncomingTargetTextBox;
        private Button ScanButton;
        private System.Windows.Forms.Label label1;
        private CheckedListBox deviceListBox;
        private TextBox OutgoingTargetTextBox;
        private Label label5;
        private TextBox OutgoingImpactIntensityTextBox;
        private ButtplugClient bpcl;

        #endregion
        public PluginSample()
        {
            InitializeComponent();
            this.deviceListBox.ItemCheck += DeviceListBox_ItemCheck;
        }

        private class ButtplACTEvent : ICloneable
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
                return "dur: " + Duration + " actn: " + ActionName + " victim: " + Victim + " attacker: " + Attacker;
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
                Intensities = intensities;
                Duration = duration;
                Victim = victim;
                Attacker = attacker;
                ActionName = actionname;
                TargetDeviceName = targetdevicename;
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
            vibeState.Devices = enabledDevices.ToArray();
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

            this.bpcl = new ButtplugClient("Embedded ACT Plugin Buttplug Client", new ButtplugEmbeddedConnector("Embedded ACT Plugin Buttplug Server"));

            // Do I *need* to do async stuff here? lmao
            bpcl.ConnectAsync();
            vibeState = new VibeState(false, 0.0, "ambient", null);
            lblStatus.Text = "Plugin Started";
        }

        private class VibeState : ICloneable
        {
            public bool Running { get; set; }
            public double Intensity { get; set; }
            public string Cause { get; set; }
            public ButtplugClientDevice[] Devices { get; set; }

            public VibeState(bool running, double intensity, string cause, ButtplugClientDevice[] devices)
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
                    if (ev.Duration > 100)
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


        private double getBaseIntensity()
        {
            double baseIntensity;
            try
            {
                baseIntensity = double.Parse(baseIntensityTextBox.Text) / 100;
            }
            catch
            {
                baseIntensity = 0;
                baseIntensityTextBox.Text = "0";
            }
            return baseIntensity;
        }

        private double GetIncomingImpactIntensity()
        {
            double impactIntensity;
            try
            {
                impactIntensity = double.Parse(IncomingImpactIntensityTextBox.Text) / 100;
            }
            catch
            {
                impactIntensity = 1;
                IncomingImpactIntensityTextBox.Text = "1";
            }
            return impactIntensity;
        }

        private double GetOutgoingImpactIntensity()
        {
            double impactIntensity;
            try
            {
                impactIntensity = double.Parse(OutgoingImpactIntensityTextBox.Text) / 100;
            }
            catch
            {
                impactIntensity = 1;
                OutgoingImpactIntensityTextBox.Text = "1";
            }
            return impactIntensity;
        }

        private void OFormActMain_OnCombatStartAsync(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            lock (vibeState)
            {
                double baseIntensity = getBaseIntensity();
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
                deviceListBox.Items.Clear();
                void Bpcl_DeviceAdded(object senderdev, DeviceAddedEventArgs edev)
                {
                    deviceListBox.Items.Add(edev.Device.Name);
                }
                bpcl.DeviceAdded += Bpcl_DeviceAdded;
                await bpcl.StartScanningAsync();
            }
            async Task StopScanning()
            {
                await bpcl.StopScanningAsync();
            }

            if (scanning)
            {
                await StopScanning();
                scanning = !scanning;
                ScanButton.Text = "Scan for devices";
                vibeState.Running = true;
            }
            else
            {
                vibeState.Running = false;
                await Task.Delay(100);
                enabledDevices.Clear();
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

                OutgoingImpactIntensityTextBox.ReadOnly = false;
                OutgoingTargetTextBox.ReadOnly = false;
                IncomingImpactIntensityTextBox.ReadOnly = false;
                IncomingTargetTextBox.ReadOnly = false;
                baseIntensityTextBox.ReadOnly = false;
                ScanButton.Enabled = true;
                deviceListBox.Enabled = true;
                button2.Text = "Ready!";

                // XXX: probably don't want this later on?
                KnownButtplACTEvents.Clear();

                settingsLocked = false;
            }
            else
            {
                vibeState.Running = true;
                OutgoingImpactIntensityTextBox.ReadOnly = true;
                OutgoingTargetTextBox.ReadOnly = true;
                IncomingImpactIntensityTextBox.ReadOnly = true;
                IncomingTargetTextBox.ReadOnly = true;
                baseIntensityTextBox.ReadOnly = true;
                button2.Text = "Stop!";
                ScanButton.Enabled = false;
                deviceListBox.Enabled = false;

                double[] incIntensities = new double[1];
                incIntensities[0] = GetIncomingImpactIntensity();
                ButtplACTEvent inc = new ButtplACTEvent(incIntensities, 500, IncomingTargetTextBox.Text, "", "", "", true);
                KnownButtplACTEvents.Add(inc);
                double[] outIntensities = new double[1];
                outIntensities[0] = GetOutgoingImpactIntensity();
                ButtplACTEvent outg = new ButtplACTEvent(outIntensities, 200, "", OutgoingTargetTextBox.Text, "", "", true);
                KnownButtplACTEvents.Add(outg);
                double[] regenIntensities = new double[1];
                regenIntensities[0] = 0.5;
                ButtplACTEvent regen = new ButtplACTEvent(regenIntensities, 21000, "YOU", "YOU", "Regen", "", true);
                KnownButtplACTEvents.Add(regen);

                settingsLocked = true;
            }
        }
    }
}
