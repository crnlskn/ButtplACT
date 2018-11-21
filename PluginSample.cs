using Advanced_Combat_Tracker;
using Buttplug.Client;
using Buttplug.Core;
using Buttplug.Core.Messages;
using System;
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
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.deviceListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baseIntensityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ImpactIntensityTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target";
            // 
            // targetTextBox
            // 
            this.targetTextBox.Location = new System.Drawing.Point(206, 26);
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.Size = new System.Drawing.Size(227, 20);
            this.targetTextBox.TabIndex = 1;
            this.targetTextBox.Text = "Enter exact target name here";
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(9, 136);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(109, 23);
            this.ScanButton.TabIndex = 4;
            this.ScanButton.Text = "Scan for devices";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.Button1_ClickAsync);
            // 
            // deviceListBox
            // 
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.Location = new System.Drawing.Point(206, 123);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(227, 94);
            this.deviceListBox.TabIndex = 5;
            this.deviceListBox.ItemCheck += CheckedListBox1_ItemCheck;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base intensity";
            // 
            // baseIntensityTextBox
            // 
            this.baseIntensityTextBox.Location = new System.Drawing.Point(206, 56);
            this.baseIntensityTextBox.Name = "baseIntensityTextBox";
            this.baseIntensityTextBox.Size = new System.Drawing.Size(227, 20);
            this.baseIntensityTextBox.TabIndex = 2;
            this.baseIntensityTextBox.Text = "Enter base intensity (0 to 100)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Impact intensity";
            // 
            // ImpactIntensityTextBox
            // 
            this.ImpactIntensityTextBox.Location = new System.Drawing.Point(206, 86);
            this.ImpactIntensityTextBox.Name = "ImpactIntensityTextBox";
            this.ImpactIntensityTextBox.Size = new System.Drawing.Size(227, 20);
            this.ImpactIntensityTextBox.TabIndex = 3;
            this.ImpactIntensityTextBox.Text = "Enter impact intensity (0 to 100)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "Ready!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PluginSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ImpactIntensityTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baseIntensityTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deviceListBox);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.targetTextBox);
            this.Controls.Add(this.label1);
            this.Name = "PluginSample";
            this.Size = new System.Drawing.Size(686, 384);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label2;
        private TextBox baseIntensityTextBox;
        private Label label3;
        private TextBox ImpactIntensityTextBox;
        private Button button2;
        List<ButtplugClientDevice> enabledDevices = new List<ButtplugClientDevice>();

        private async void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            await bpcl.Devices[e.Index].SendVibrateCmd(.5);
            await Task.Delay(300);
            await bpcl.Devices[e.Index].SendVibrateCmd(0);

            lock (enabledDevices)
            {
                enabledDevices.Add(bpcl.Devices[e.Index]);
            }
        }

        #endregion

        private TextBox targetTextBox;
        private Button ScanButton;
        private System.Windows.Forms.Label label1;
        private CheckedListBox deviceListBox;
        private ButtplugClient bpcl;

        #endregion
        public PluginSample()
        {
            InitializeComponent();
        }

        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\PluginSample.config.xml");

        private VibeState vibeState;

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space

            // Create some sort of parsing event handler.  After the "+=" hit TAB twice and the code will be generated for you.
            ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(OFormActMain_AfterCombatAction);
            ActGlobals.oFormActMain.OnCombatStart += new CombatToggleEventDelegate(OFormActMain_OnCombatStart);
            ActGlobals.oFormActMain.OnCombatEnd += new CombatToggleEventDelegate(OFormActMain_OnCombatEnd);

            this.bpcl = new ButtplugClient("Embedded ACT Plugin Buttplug Client", new ButtplugEmbeddedConnector("Embedded ACT Plugin Buttplug Server"));

            // Do I *need* to do async stuff here? lmao
            bpcl.ConnectAsync();
            this.vibeState = new VibeState();
            lblStatus.Text = "Plugin Started";
        }

        private class VibeState
        {
            public bool Running { get; set; }
            public double Intensity { get; set; }
        }

        private Task DoAmbientVibrations()
        {
            return new Task(async (object obj) =>
            {
                VibeState state = (VibeState)obj;
                while (state.Running)
                {
                    foreach (ButtplugClientDevice dev in enabledDevices)
                    {
                        await dev.SendVibrateCmd(state.Intensity);
                        await Task.Delay(250);
                    }
                }
            }, this.vibeState);
        }

        private void OFormActMain_OnCombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            lock (vibeState)
            {
                this.vibeState.Intensity = 0;
            }
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

        private double getImpactIntensity()
        {
            double impactIntensity;
            try
            {
                impactIntensity = double.Parse(ImpactIntensityTextBox.Text) / 100;
            }
            catch
            {
                impactIntensity = 1;
                ImpactIntensityTextBox.Text = "1";
            }
            return impactIntensity;
        }

        private void OFormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            lock (vibeState)
            {
                double baseIntensity = getBaseIntensity();
                this.vibeState.Intensity = baseIntensity;
            }
        }

        public void DeInitPlugin()
        {
            // Unsubscribe from any events you listen to when exiting!
            ActGlobals.oFormActMain.AfterCombatAction -= OFormActMain_AfterCombatAction;
            ActGlobals.oFormActMain.OnCombatStart -= OFormActMain_OnCombatStart;
            ActGlobals.oFormActMain.OnCombatEnd -= OFormActMain_OnCombatEnd;
            lock (vibeState)
            {
                vibeState.Running = false;
            }
            bpcl.DisconnectAsync();
            Thread.Sleep(250);
            lblStatus.Text = "Plugin Exited";
        }
        #endregion

        void OFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {
            if (actionInfo.victim.Equals(targetTextBox.Text))
            {
                lock (this.vibeState)
                {
                    vibeState.Intensity = getImpactIntensity();
                }
                Thread.Sleep(480);
                lock (this.vibeState)
                {
                    vibeState.Intensity = getBaseIntensity();
                }
            }
        }

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
                await Task.Delay(260);
                enabledDevices.Clear();
                await StartScanning();
                scanning = !scanning;
                ScanButton.Text = "Stop scanning";
            }
        }

        private bool settingsLocked = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if(settingsLocked)
            {
                vibeState.Running = false;
                foreach (ButtplugClientDevice dev in enabledDevices)
                {
                    dev.SendVibrateCmd(0);
                }
                targetTextBox.ReadOnly = false;
                baseIntensityTextBox.ReadOnly = false;
                ImpactIntensityTextBox.ReadOnly = false;
                ScanButton.Enabled = true;
                deviceListBox.Enabled = true;
                button2.Text = "Ready!";
            }
            else
            {
                button2.Text = "Stop!";
                vibeState.Running = true;
                DoAmbientVibrations().Start();
                targetTextBox.ReadOnly = true;
                baseIntensityTextBox.ReadOnly = true;
                ImpactIntensityTextBox.ReadOnly = true;
                ScanButton.Enabled = false;
                deviceListBox.Enabled = false;
            }
        }
    }
}
