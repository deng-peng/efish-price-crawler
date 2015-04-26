namespace PriceCrawler
{
    partial class PriceCrawlerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dpStart = new System.Windows.Forms.DateTimePicker();
            this.dpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnFolder1 = new System.Windows.Forms.Button();
            this.infobox1 = new System.Windows.Forms.RichTextBox();
            this.btnStart1 = new System.Windows.Forms.Button();
            this.savePath1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnFolder2 = new System.Windows.Forms.Button();
            this.infobox2 = new System.Windows.Forms.RichTextBox();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.savePath2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbProxy = new System.Windows.Forms.CheckBox();
            this.tbProxy = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpStart
            // 
            this.dpStart.Location = new System.Drawing.Point(69, 39);
            this.dpStart.Name = "dpStart";
            this.dpStart.Size = new System.Drawing.Size(171, 20);
            this.dpStart.TabIndex = 0;
            this.dpStart.Value = new System.DateTime(2015, 4, 24, 8, 47, 18, 0);
            // 
            // dpEnd
            // 
            this.dpEnd.Location = new System.Drawing.Point(324, 39);
            this.dpEnd.Name = "dpEnd";
            this.dpEnd.Size = new System.Drawing.Size(171, 20);
            this.dpEnd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "开始";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "结束";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 81);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(525, 398);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnFolder1);
            this.tabPage1.Controls.Add(this.infobox1);
            this.tabPage1.Controls.Add(this.btnStart1);
            this.tabPage1.Controls.Add(this.savePath1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(517, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "中国渔市";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnFolder1
            // 
            this.btnFolder1.Location = new System.Drawing.Point(415, 20);
            this.btnFolder1.Name = "btnFolder1";
            this.btnFolder1.Size = new System.Drawing.Size(80, 23);
            this.btnFolder1.TabIndex = 4;
            this.btnFolder1.Text = "转到文件夹";
            this.btnFolder1.UseVisualStyleBackColor = true;
            this.btnFolder1.Click += new System.EventHandler(this.btnFolder1_Click);
            // 
            // infobox1
            // 
            this.infobox1.Location = new System.Drawing.Point(21, 62);
            this.infobox1.Name = "infobox1";
            this.infobox1.Size = new System.Drawing.Size(474, 284);
            this.infobox1.TabIndex = 3;
            this.infobox1.Text = "";
            // 
            // btnStart1
            // 
            this.btnStart1.Location = new System.Drawing.Point(337, 20);
            this.btnStart1.Name = "btnStart1";
            this.btnStart1.Size = new System.Drawing.Size(72, 23);
            this.btnStart1.TabIndex = 2;
            this.btnStart1.Text = "开始获取";
            this.btnStart1.UseVisualStyleBackColor = true;
            this.btnStart1.Click += new System.EventHandler(this.btnStart1_Click);
            // 
            // savePath1
            // 
            this.savePath1.Location = new System.Drawing.Point(79, 21);
            this.savePath1.Name = "savePath1";
            this.savePath1.Size = new System.Drawing.Size(252, 20);
            this.savePath1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "保存位置";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbProxy);
            this.tabPage2.Controls.Add(this.ckbProxy);
            this.tabPage2.Controls.Add(this.btnFolder2);
            this.tabPage2.Controls.Add(this.infobox2);
            this.tabPage2.Controls.Add(this.btnStart2);
            this.tabPage2.Controls.Add(this.savePath2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(517, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "渔产品全球资讯网";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnFolder2
            // 
            this.btnFolder2.Location = new System.Drawing.Point(414, 14);
            this.btnFolder2.Name = "btnFolder2";
            this.btnFolder2.Size = new System.Drawing.Size(80, 23);
            this.btnFolder2.TabIndex = 4;
            this.btnFolder2.Text = "转到文件夹";
            this.btnFolder2.UseVisualStyleBackColor = true;
            this.btnFolder2.Click += new System.EventHandler(this.btnFolder2_Click);
            // 
            // infobox2
            // 
            this.infobox2.Location = new System.Drawing.Point(23, 79);
            this.infobox2.Name = "infobox2";
            this.infobox2.Size = new System.Drawing.Size(473, 269);
            this.infobox2.TabIndex = 6;
            this.infobox2.Text = "";
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(340, 14);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(70, 23);
            this.btnStart2.TabIndex = 5;
            this.btnStart2.Text = "开始获取";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart2_Click);
            // 
            // savePath2
            // 
            this.savePath2.Location = new System.Drawing.Point(79, 16);
            this.savePath2.Name = "savePath2";
            this.savePath2.Size = new System.Drawing.Size(257, 20);
            this.savePath2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "保存位置";
            // 
            // ckbProxy
            // 
            this.ckbProxy.AutoSize = true;
            this.ckbProxy.Location = new System.Drawing.Point(23, 47);
            this.ckbProxy.Name = "ckbProxy";
            this.ckbProxy.Size = new System.Drawing.Size(74, 17);
            this.ckbProxy.TabIndex = 7;
            this.ckbProxy.Text = "使用代理";
            this.ckbProxy.UseVisualStyleBackColor = true;
            // 
            // tbProxy
            // 
            this.tbProxy.Location = new System.Drawing.Point(98, 45);
            this.tbProxy.Name = "tbProxy";
            this.tbProxy.Size = new System.Drawing.Size(179, 20);
            this.tbProxy.TabIndex = 8;
            this.tbProxy.Text = "http://127.0.0.1:8118";
            // 
            // PriceCrawlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 491);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpEnd);
            this.Controls.Add(this.dpStart);
            this.Name = "PriceCrawlerForm";
            this.Text = "水产品价格";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpStart;
        private System.Windows.Forms.DateTimePicker dpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox savePath1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox infobox1;
        private System.Windows.Forms.Button btnStart1;
        private System.Windows.Forms.RichTextBox infobox2;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.TextBox savePath2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFolder1;
        private System.Windows.Forms.Button btnFolder2;
        private System.Windows.Forms.TextBox tbProxy;
        private System.Windows.Forms.CheckBox ckbProxy;
    }
}

