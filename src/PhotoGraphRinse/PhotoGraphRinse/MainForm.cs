using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotoGraphRinse
{
    public class MainForm : Form
    {
        private const int WS_EX_LAYERED = 0x00080000;
        private const int WS_EX_COMPOSITED = 0x02000000;
        private Boolean IsXpOr2003
        {
            get
            {
                return ((Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor != 0));
            }
        }

        public enum StepType : int
        {
            NULLPTR = 0,
            WELCOME,
            FILTER,
            LAYOUT,
            PAY,
            PHOTO,
            PREVIEW,
            DOWNLOAD,
        }

        private Dictionary<string, object> m_dataDict = new Dictionary<string, object>();

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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_LAYERED;  // Turn on WS_EX_LAYERED
                cp.ExStyle |= WS_EX_COMPOSITED; // Turn on WS_EX_COMPOSITED
                Opacity = 1;
                return cp;
            }
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ///////////////////////////////////////////////////////////
            this.SuspendLayout();

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 600);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

            ///////////////////////////////////////////////////////////
            for (StepType stepType = StepType.WELCOME; stepType <= StepType.DOWNLOAD; stepType++)
            {
                var panel = new Panel();
                panel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                panel.Location = new Point(0, 0);
                panel.Name = stepType.ToString();
                panel.Size = Size;
                panel.TabIndex = 0;
                panel.BackgroundImage = Properties.Resources.welcome;
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                Controls.Add(panel);
                panel.Hide();
            }
            ////////////////////////////////////////////////////////
            {

                var button = new Button();
                button.Text = "欢迎进入";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.WELCOME);
                };
                ((Panel)Controls[StepType.WELCOME.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
            {
                var button = new Button();
                button.Text = "滤镜选择";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.FILTER);
                };
                ((Panel)Controls[StepType.FILTER.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
            {
                var button = new Button();
                button.Text = "版式选择";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.LAYOUT);
                };
                ((Panel)Controls[StepType.LAYOUT.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
            {
                var button = new Button();
                button.Text = "用户支付";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.PAY);
                };
                ((Panel)Controls[StepType.PAY.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
            {
                var button = new Button();
                button.Text = "拍照";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.PHOTO);
                };
                ((Panel)Controls[StepType.PHOTO.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
            {
                var button = new Button();
                button.Text = "预览打印";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.PREVIEW);
                };
                ((Panel)Controls[StepType.PREVIEW.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
            {
                var button = new Button();
                button.Text = "下载";
                button.Click += (object sender, EventArgs e) =>
                {
                    NextStep(StepType.DOWNLOAD);
                };
                ((Panel)Controls[StepType.DOWNLOAD.ToString()]).Controls.Add(button);
            }
            ////////////////////////////////////////////////////////
        }

        #endregion

        private void NextStep(StepType stepType)
        {
            var nextStepType = stepType;
            if(stepType == StepType.NULLPTR || stepType == StepType.DOWNLOAD)
            {
                nextStepType = StepType.WELCOME;
            }
            else
            {
                nextStepType = (stepType + 1);
            }
            if (StepType.WELCOME <= nextStepType && nextStepType <= StepType.DOWNLOAD)
            {               
                foreach (var panel in Controls)
                {
                    ((Panel)panel).Hide();
                }
                ((Panel)Controls[nextStepType.ToString()]).Show();
            }
        }
        public MainForm()
        {
            InitializeComponent();
            NextStep(StepType.NULLPTR);
        }
    }
}
