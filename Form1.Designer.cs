
namespace OculusTouchUI
{
    partial class Form1
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

        private void AssignInstance() => _instance = this;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AssignInstance();
            this.LTouchXLabel = new System.Windows.Forms.Label();
            this.LTouchYLabel = new System.Windows.Forms.Label();
            this.LTouchX = new System.Windows.Forms.TrackBar();
            this.LTouchY = new System.Windows.Forms.TrackBar();
            this.RTouchY = new System.Windows.Forms.TrackBar();
            this.RTouchYLabel = new System.Windows.Forms.Label();
            this.RTouchXLabel = new System.Windows.Forms.Label();
            this.RTouchX = new System.Windows.Forms.TrackBar();
            this.RHand = new System.Windows.Forms.TrackBar();
            this.RHandLabel = new System.Windows.Forms.Label();
            this.RTriggerLabel = new System.Windows.Forms.Label();
            this.RTrigger = new System.Windows.Forms.TrackBar();
            this.LHand = new System.Windows.Forms.TrackBar();
            this.LHandLabel = new System.Windows.Forms.Label();
            this.LTriggerLabel = new System.Windows.Forms.Label();
            this.LTrigger = new System.Windows.Forms.TrackBar();
            this.pressedLabel = new System.Windows.Forms.Label();
            this.touchesLabel = new System.Windows.Forms.Label();
            this.isInHeadset = new System.Windows.Forms.Label();
            this.ltRotLabel = new System.Windows.Forms.Label();
            this.rtRotLabel = new System.Windows.Forms.Label();
            this.rtPosLabel = new System.Windows.Forms.Label();
            this.ltPosLabel = new System.Windows.Forms.Label();
            this.ltYaw = new System.Windows.Forms.TrackBar();
            this.ltYawLabel = new System.Windows.Forms.Label();
            this.ltPitchLabel = new System.Windows.Forms.Label();
            this.ltPitch = new System.Windows.Forms.TrackBar();
            this.ltRollLabel = new System.Windows.Forms.Label();
            this.ltRoll = new System.Windows.Forms.TrackBar();
            this.rtRollLabel = new System.Windows.Forms.Label();
            this.rtRoll = new System.Windows.Forms.TrackBar();
            this.rtPitchLabel = new System.Windows.Forms.Label();
            this.rtPitch = new System.Windows.Forms.TrackBar();
            this.rtYawLabel = new System.Windows.Forms.Label();
            this.rtYaw = new System.Windows.Forms.TrackBar();
            this.rtZLabel = new System.Windows.Forms.Label();
            this.rtYLabel = new System.Windows.Forms.Label();
            this.rtXLabel = new System.Windows.Forms.Label();
            this.ltZLabel = new System.Windows.Forms.Label();
            this.ltYLabel = new System.Windows.Forms.Label();
            this.ltXLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LTouchX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LTouchY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTouchY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTouchX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtYaw)).BeginInit();
            this.SuspendLayout();
            // 
            // LTouchXLabel
            // 
            this.LTouchXLabel.AutoSize = true;
            this.LTouchXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.LTouchXLabel.Location = new System.Drawing.Point(29, 30);
            this.LTouchXLabel.Name = "LTouchXLabel";
            this.LTouchXLabel.Size = new System.Drawing.Size(230, 32);
            this.LTouchXLabel.TabIndex = 2;
            this.LTouchXLabel.Text = "LTouch X-Axis: 0";
            // 
            // LTouchYLabel
            // 
            this.LTouchYLabel.AutoSize = true;
            this.LTouchYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.LTouchYLabel.Location = new System.Drawing.Point(29, 118);
            this.LTouchYLabel.Name = "LTouchYLabel";
            this.LTouchYLabel.Size = new System.Drawing.Size(230, 32);
            this.LTouchYLabel.TabIndex = 3;
            this.LTouchYLabel.Text = "LTouch Y-Axis: 0";
            // 
            // LTouchX
            // 
            this.LTouchX.Location = new System.Drawing.Point(35, 65);
            this.LTouchX.Maximum = 255;
            this.LTouchX.Name = "LTouchX";
            this.LTouchX.Size = new System.Drawing.Size(191, 69);
            this.LTouchX.TabIndex = 0;
            this.LTouchX.Value = 128;
            // 
            // LTouchY
            // 
            this.LTouchY.Location = new System.Drawing.Point(35, 153);
            this.LTouchY.Maximum = 255;
            this.LTouchY.Name = "LTouchY";
            this.LTouchY.Size = new System.Drawing.Size(191, 69);
            this.LTouchY.TabIndex = 4;
            this.LTouchY.Value = 128;
            // 
            // RTouchY
            // 
            this.RTouchY.Location = new System.Drawing.Point(317, 153);
            this.RTouchY.Maximum = 255;
            this.RTouchY.Name = "RTouchY";
            this.RTouchY.Size = new System.Drawing.Size(191, 69);
            this.RTouchY.TabIndex = 9;
            this.RTouchY.Value = 128;
            // 
            // RTouchYLabel
            // 
            this.RTouchYLabel.AutoSize = true;
            this.RTouchYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.RTouchYLabel.Location = new System.Drawing.Point(311, 118);
            this.RTouchYLabel.Name = "RTouchYLabel";
            this.RTouchYLabel.Size = new System.Drawing.Size(234, 32);
            this.RTouchYLabel.TabIndex = 8;
            this.RTouchYLabel.Text = "RTouch Y-Axis: 0";
            // 
            // RTouchXLabel
            // 
            this.RTouchXLabel.AutoSize = true;
            this.RTouchXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.RTouchXLabel.Location = new System.Drawing.Point(311, 30);
            this.RTouchXLabel.Name = "RTouchXLabel";
            this.RTouchXLabel.Size = new System.Drawing.Size(234, 32);
            this.RTouchXLabel.TabIndex = 7;
            this.RTouchXLabel.Text = "RTouch X-Axis: 0";
            // 
            // RTouchX
            // 
            this.RTouchX.Location = new System.Drawing.Point(317, 65);
            this.RTouchX.Maximum = 255;
            this.RTouchX.Name = "RTouchX";
            this.RTouchX.Size = new System.Drawing.Size(191, 69);
            this.RTouchX.TabIndex = 6;
            this.RTouchX.Value = 128;
            // 
            // RHand
            // 
            this.RHand.Location = new System.Drawing.Point(317, 334);
            this.RHand.Maximum = 255;
            this.RHand.Name = "RHand";
            this.RHand.Size = new System.Drawing.Size(191, 69);
            this.RHand.TabIndex = 17;
            // 
            // RHandLabel
            // 
            this.RHandLabel.AutoSize = true;
            this.RHandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.RHandLabel.Location = new System.Drawing.Point(311, 299);
            this.RHandLabel.Name = "RHandLabel";
            this.RHandLabel.Size = new System.Drawing.Size(111, 32);
            this.RHandLabel.TabIndex = 16;
            this.RHandLabel.Text = "RHand:";
            // 
            // RTriggerLabel
            // 
            this.RTriggerLabel.AutoSize = true;
            this.RTriggerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.RTriggerLabel.Location = new System.Drawing.Point(311, 211);
            this.RTriggerLabel.Name = "RTriggerLabel";
            this.RTriggerLabel.Size = new System.Drawing.Size(156, 32);
            this.RTriggerLabel.TabIndex = 15;
            this.RTriggerLabel.Text = "RTrigger: 0";
            // 
            // RTrigger
            // 
            this.RTrigger.Location = new System.Drawing.Point(317, 246);
            this.RTrigger.Maximum = 255;
            this.RTrigger.Name = "RTrigger";
            this.RTrigger.Size = new System.Drawing.Size(191, 69);
            this.RTrigger.TabIndex = 14;
            // 
            // LHand
            // 
            this.LHand.Location = new System.Drawing.Point(35, 334);
            this.LHand.Maximum = 255;
            this.LHand.Name = "LHand";
            this.LHand.Size = new System.Drawing.Size(191, 69);
            this.LHand.TabIndex = 13;
            // 
            // LHandLabel
            // 
            this.LHandLabel.AutoSize = true;
            this.LHandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.LHandLabel.Location = new System.Drawing.Point(29, 299);
            this.LHandLabel.Name = "LHandLabel";
            this.LHandLabel.Size = new System.Drawing.Size(130, 32);
            this.LHandLabel.TabIndex = 12;
            this.LHandLabel.Text = "LHand: 0";
            // 
            // LTriggerLabel
            // 
            this.LTriggerLabel.AutoSize = true;
            this.LTriggerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.LTriggerLabel.Location = new System.Drawing.Point(29, 211);
            this.LTriggerLabel.Name = "LTriggerLabel";
            this.LTriggerLabel.Size = new System.Drawing.Size(152, 32);
            this.LTriggerLabel.TabIndex = 11;
            this.LTriggerLabel.Text = "LTrigger: 0";
            // 
            // LTrigger
            // 
            this.LTrigger.Location = new System.Drawing.Point(35, 246);
            this.LTrigger.Maximum = 255;
            this.LTrigger.Name = "LTrigger";
            this.LTrigger.Size = new System.Drawing.Size(191, 69);
            this.LTrigger.TabIndex = 10;
            // 
            // pressedLabel
            // 
            this.pressedLabel.AutoSize = true;
            this.pressedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.pressedLabel.Location = new System.Drawing.Point(29, 390);
            this.pressedLabel.Name = "pressedLabel";
            this.pressedLabel.Size = new System.Drawing.Size(120, 32);
            this.pressedLabel.TabIndex = 18;
            this.pressedLabel.Text = "Buttons:";
            // 
            // touchesLabel
            // 
            this.touchesLabel.AutoSize = true;
            this.touchesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.touchesLabel.Location = new System.Drawing.Point(29, 435);
            this.touchesLabel.Name = "touchesLabel";
            this.touchesLabel.Size = new System.Drawing.Size(132, 32);
            this.touchesLabel.TabIndex = 19;
            this.touchesLabel.Text = "Touches:";
            // 
            // isInHeadset
            // 
            this.isInHeadset.AutoSize = true;
            this.isInHeadset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.isInHeadset.Location = new System.Drawing.Point(29, 481);
            this.isInHeadset.Name = "isInHeadset";
            this.isInHeadset.Size = new System.Drawing.Size(264, 32);
            this.isInHeadset.TabIndex = 20;
            this.isInHeadset.Text = "Is in Headset: False";
            // 
            // ltRotLabel
            // 
            this.ltRotLabel.AutoSize = true;
            this.ltRotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltRotLabel.Location = new System.Drawing.Point(29, 534);
            this.ltRotLabel.Name = "ltRotLabel";
            this.ltRotLabel.Size = new System.Drawing.Size(252, 32);
            this.ltRotLabel.TabIndex = 21;
            this.ltRotLabel.Text = "Left Touch rotation";
            // 
            // rtRotLabel
            // 
            this.rtRotLabel.AutoSize = true;
            this.rtRotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtRotLabel.Location = new System.Drawing.Point(311, 534);
            this.rtRotLabel.Name = "rtRotLabel";
            this.rtRotLabel.Size = new System.Drawing.Size(271, 32);
            this.rtRotLabel.TabIndex = 22;
            this.rtRotLabel.Text = "Right Touch rotation";
            // 
            // rtPosLabel
            // 
            this.rtPosLabel.AutoSize = true;
            this.rtPosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtPosLabel.Location = new System.Drawing.Point(311, 875);
            this.rtPosLabel.Name = "rtPosLabel";
            this.rtPosLabel.Size = new System.Drawing.Size(275, 32);
            this.rtPosLabel.TabIndex = 24;
            this.rtPosLabel.Text = "Right Touch position";
            // 
            // ltPosLabel
            // 
            this.ltPosLabel.AutoSize = true;
            this.ltPosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltPosLabel.Location = new System.Drawing.Point(29, 875);
            this.ltPosLabel.Name = "ltPosLabel";
            this.ltPosLabel.Size = new System.Drawing.Size(256, 32);
            this.ltPosLabel.TabIndex = 23;
            this.ltPosLabel.Text = "Left Touch position";
            // 
            // ltYaw
            // 
            this.ltYaw.Location = new System.Drawing.Point(35, 620);
            this.ltYaw.Maximum = 100;
            this.ltYaw.Name = "ltYaw";
            this.ltYaw.Size = new System.Drawing.Size(191, 69);
            this.ltYaw.TabIndex = 25;
            this.ltYaw.Value = 50;
            // 
            // ltYawLabel
            // 
            this.ltYawLabel.AutoSize = true;
            this.ltYawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltYawLabel.Location = new System.Drawing.Point(29, 585);
            this.ltYawLabel.Name = "ltYawLabel";
            this.ltYawLabel.Size = new System.Drawing.Size(78, 32);
            this.ltYawLabel.TabIndex = 27;
            this.ltYawLabel.Text = "Yaw:";
            // 
            // ltPitchLabel
            // 
            this.ltPitchLabel.AutoSize = true;
            this.ltPitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltPitchLabel.Location = new System.Drawing.Point(29, 660);
            this.ltPitchLabel.Name = "ltPitchLabel";
            this.ltPitchLabel.Size = new System.Drawing.Size(87, 32);
            this.ltPitchLabel.TabIndex = 29;
            this.ltPitchLabel.Text = "Pitch:";
            // 
            // ltPitch
            // 
            this.ltPitch.Location = new System.Drawing.Point(35, 695);
            this.ltPitch.Maximum = 100;
            this.ltPitch.Name = "ltPitch";
            this.ltPitch.Size = new System.Drawing.Size(191, 69);
            this.ltPitch.TabIndex = 28;
            this.ltPitch.Value = 50;
            // 
            // ltRollLabel
            // 
            this.ltRollLabel.AutoSize = true;
            this.ltRollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltRollLabel.Location = new System.Drawing.Point(29, 724);
            this.ltRollLabel.Name = "ltRollLabel";
            this.ltRollLabel.Size = new System.Drawing.Size(73, 32);
            this.ltRollLabel.TabIndex = 31;
            this.ltRollLabel.Text = "Roll:";
            // 
            // ltRoll
            // 
            this.ltRoll.Location = new System.Drawing.Point(35, 759);
            this.ltRoll.Maximum = 100;
            this.ltRoll.Name = "ltRoll";
            this.ltRoll.Size = new System.Drawing.Size(191, 69);
            this.ltRoll.TabIndex = 30;
            this.ltRoll.Value = 50;
            // 
            // rtRollLabel
            // 
            this.rtRollLabel.AutoSize = true;
            this.rtRollLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtRollLabel.Location = new System.Drawing.Point(311, 724);
            this.rtRollLabel.Name = "rtRollLabel";
            this.rtRollLabel.Size = new System.Drawing.Size(73, 32);
            this.rtRollLabel.TabIndex = 37;
            this.rtRollLabel.Text = "Roll:";
            // 
            // rtRoll
            // 
            this.rtRoll.Location = new System.Drawing.Point(317, 759);
            this.rtRoll.Maximum = 100;
            this.rtRoll.Name = "rtRoll";
            this.rtRoll.Size = new System.Drawing.Size(191, 69);
            this.rtRoll.TabIndex = 36;
            this.rtRoll.Value = 50;
            // 
            // rtPitchLabel
            // 
            this.rtPitchLabel.AutoSize = true;
            this.rtPitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtPitchLabel.Location = new System.Drawing.Point(311, 660);
            this.rtPitchLabel.Name = "rtPitchLabel";
            this.rtPitchLabel.Size = new System.Drawing.Size(87, 32);
            this.rtPitchLabel.TabIndex = 35;
            this.rtPitchLabel.Text = "Pitch:";
            // 
            // rtPitch
            // 
            this.rtPitch.Location = new System.Drawing.Point(317, 695);
            this.rtPitch.Maximum = 100;
            this.rtPitch.Name = "rtPitch";
            this.rtPitch.Size = new System.Drawing.Size(191, 69);
            this.rtPitch.TabIndex = 34;
            this.rtPitch.Value = 50;
            // 
            // rtYawLabel
            // 
            this.rtYawLabel.AutoSize = true;
            this.rtYawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtYawLabel.Location = new System.Drawing.Point(311, 585);
            this.rtYawLabel.Name = "rtYawLabel";
            this.rtYawLabel.Size = new System.Drawing.Size(78, 32);
            this.rtYawLabel.TabIndex = 33;
            this.rtYawLabel.Text = "Yaw:";
            // 
            // rtYaw
            // 
            this.rtYaw.Location = new System.Drawing.Point(317, 620);
            this.rtYaw.Maximum = 100;
            this.rtYaw.Name = "rtYaw";
            this.rtYaw.Size = new System.Drawing.Size(191, 69);
            this.rtYaw.TabIndex = 32;
            this.rtYaw.Value = 50;
            // 
            // rtZLabel
            // 
            this.rtZLabel.AutoSize = true;
            this.rtZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtZLabel.Location = new System.Drawing.Point(311, 1065);
            this.rtZLabel.Name = "rtZLabel";
            this.rtZLabel.Size = new System.Drawing.Size(40, 32);
            this.rtZLabel.TabIndex = 49;
            this.rtZLabel.Text = "Z:";
            // 
            // rtYLabel
            // 
            this.rtYLabel.AutoSize = true;
            this.rtYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtYLabel.Location = new System.Drawing.Point(311, 1001);
            this.rtYLabel.Name = "rtYLabel";
            this.rtYLabel.Size = new System.Drawing.Size(42, 32);
            this.rtYLabel.TabIndex = 47;
            this.rtYLabel.Text = "Y:";
            // 
            // rtXLabel
            // 
            this.rtXLabel.AutoSize = true;
            this.rtXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.rtXLabel.Location = new System.Drawing.Point(311, 926);
            this.rtXLabel.Name = "rtXLabel";
            this.rtXLabel.Size = new System.Drawing.Size(42, 32);
            this.rtXLabel.TabIndex = 45;
            this.rtXLabel.Text = "X:";
            // 
            // ltZLabel
            // 
            this.ltZLabel.AutoSize = true;
            this.ltZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltZLabel.Location = new System.Drawing.Point(29, 1065);
            this.ltZLabel.Name = "ltZLabel";
            this.ltZLabel.Size = new System.Drawing.Size(40, 32);
            this.ltZLabel.TabIndex = 43;
            this.ltZLabel.Text = "Z:";
            // 
            // ltYLabel
            // 
            this.ltYLabel.AutoSize = true;
            this.ltYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltYLabel.Location = new System.Drawing.Point(29, 1001);
            this.ltYLabel.Name = "ltYLabel";
            this.ltYLabel.Size = new System.Drawing.Size(42, 32);
            this.ltYLabel.TabIndex = 41;
            this.ltYLabel.Text = "Y:";
            // 
            // ltXLabel
            // 
            this.ltXLabel.AutoSize = true;
            this.ltXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ltXLabel.Location = new System.Drawing.Point(29, 926);
            this.ltXLabel.Name = "ltXLabel";
            this.ltXLabel.Size = new System.Drawing.Size(42, 32);
            this.ltXLabel.TabIndex = 39;
            this.ltXLabel.Text = "X:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1264);
            this.Controls.Add(this.rtZLabel);
            this.Controls.Add(this.rtYLabel);
            this.Controls.Add(this.rtXLabel);
            this.Controls.Add(this.ltZLabel);
            this.Controls.Add(this.ltYLabel);
            this.Controls.Add(this.ltXLabel);
            this.Controls.Add(this.rtRollLabel);
            this.Controls.Add(this.rtRoll);
            this.Controls.Add(this.rtPitchLabel);
            this.Controls.Add(this.rtPitch);
            this.Controls.Add(this.rtYawLabel);
            this.Controls.Add(this.rtYaw);
            this.Controls.Add(this.ltRollLabel);
            this.Controls.Add(this.ltRoll);
            this.Controls.Add(this.ltPitchLabel);
            this.Controls.Add(this.ltPitch);
            this.Controls.Add(this.ltYawLabel);
            this.Controls.Add(this.ltYaw);
            this.Controls.Add(this.rtPosLabel);
            this.Controls.Add(this.ltPosLabel);
            this.Controls.Add(this.rtRotLabel);
            this.Controls.Add(this.ltRotLabel);
            this.Controls.Add(this.isInHeadset);
            this.Controls.Add(this.touchesLabel);
            this.Controls.Add(this.pressedLabel);
            this.Controls.Add(this.RHand);
            this.Controls.Add(this.RHandLabel);
            this.Controls.Add(this.RTriggerLabel);
            this.Controls.Add(this.RTrigger);
            this.Controls.Add(this.LHand);
            this.Controls.Add(this.LHandLabel);
            this.Controls.Add(this.LTriggerLabel);
            this.Controls.Add(this.LTrigger);
            this.Controls.Add(this.RTouchY);
            this.Controls.Add(this.RTouchYLabel);
            this.Controls.Add(this.RTouchXLabel);
            this.Controls.Add(this.RTouchX);
            this.Controls.Add(this.LTouchY);
            this.Controls.Add(this.LTouchYLabel);
            this.Controls.Add(this.LTouchXLabel);
            this.Controls.Add(this.LTouchX);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LTouchX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LTouchY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTouchY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTouchX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ltRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtYaw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public static Form1 _instance;

        public System.Windows.Forms.TrackBar LTouchX;
        public System.Windows.Forms.TrackBar LTouchY;
        private System.Windows.Forms.Label LTouchXLabel;
        private System.Windows.Forms.Label LTouchYLabel;
        public System.Windows.Forms.TrackBar RTouchY;
        private System.Windows.Forms.Label RTouchYLabel;
        private System.Windows.Forms.Label RTouchXLabel;
        public System.Windows.Forms.TrackBar RTouchX;
        public System.Windows.Forms.TrackBar RHand;
        private System.Windows.Forms.Label RHandLabel;
        private System.Windows.Forms.Label RTriggerLabel;
        public System.Windows.Forms.TrackBar RTrigger;
        public System.Windows.Forms.TrackBar LHand;
        private System.Windows.Forms.Label LHandLabel;
        private System.Windows.Forms.Label LTriggerLabel;
        public System.Windows.Forms.TrackBar LTrigger;
        private System.Windows.Forms.Label pressedLabel;
        private System.Windows.Forms.Label touchesLabel;
        private System.Windows.Forms.Label isInHeadset;
        private System.Windows.Forms.Label ltRotLabel;
        private System.Windows.Forms.Label rtRotLabel;
        private System.Windows.Forms.Label rtPosLabel;
        private System.Windows.Forms.Label ltPosLabel;
        public System.Windows.Forms.TrackBar ltYaw;
        private System.Windows.Forms.Label ltYawLabel;
        private System.Windows.Forms.Label ltPitchLabel;
        public System.Windows.Forms.TrackBar ltPitch;
        private System.Windows.Forms.Label ltRollLabel;
        public System.Windows.Forms.TrackBar ltRoll;
        private System.Windows.Forms.Label rtRollLabel;
        public System.Windows.Forms.TrackBar rtRoll;
        private System.Windows.Forms.Label rtPitchLabel;
        public System.Windows.Forms.TrackBar rtPitch;
        private System.Windows.Forms.Label rtYawLabel;
        public System.Windows.Forms.TrackBar rtYaw;
        private System.Windows.Forms.Label rtZLabel;
        private System.Windows.Forms.Label rtYLabel;
        private System.Windows.Forms.Label rtXLabel;
        private System.Windows.Forms.Label ltZLabel;
        private System.Windows.Forms.Label ltYLabel;
        private System.Windows.Forms.Label ltXLabel;
    }
}

