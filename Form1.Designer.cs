
namespace GmapTestings
{
    partial class QRCodeInsert
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.tbCoords = new System.Windows.Forms.TextBox();
            this.bCalculate = new System.Windows.Forms.Button();
            this.VNProvs = new System.Windows.Forms.ComboBox();
            this.MuiChieu = new System.Windows.Forms.ComboBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 106);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.ViewCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(776, 432);
            this.gmap.TabIndex = 1;
            this.gmap.Zoom = 0D;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbCoords
            // 
            this.tbCoords.Location = new System.Drawing.Point(12, 30);
            this.tbCoords.Name = "tbCoords";
            this.tbCoords.Size = new System.Drawing.Size(291, 26);
            this.tbCoords.TabIndex = 3;
            this.tbCoords.Text = "569415.64\t1259283.89";
            // 
            // bCalculate
            // 
            this.bCalculate.Location = new System.Drawing.Point(647, 21);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(141, 44);
            this.bCalculate.TabIndex = 4;
            this.bCalculate.Text = "Calculate";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.bCalculate_Click);
            // 
            // VNProvs
            // 
            this.VNProvs.FormattingEnabled = true;
            this.VNProvs.Location = new System.Drawing.Point(404, 28);
            this.VNProvs.Name = "VNProvs";
            this.VNProvs.Size = new System.Drawing.Size(229, 28);
            this.VNProvs.TabIndex = 5;
            // 
            // MuiChieu
            // 
            this.MuiChieu.FormattingEnabled = true;
            this.MuiChieu.Items.AddRange(new object[] {
            "3",
            "6"});
            this.MuiChieu.Location = new System.Drawing.Point(351, 28);
            this.MuiChieu.Name = "MuiChieu";
            this.MuiChieu.Size = new System.Drawing.Size(47, 28);
            this.MuiChieu.TabIndex = 6;
            this.MuiChieu.Text = "3";
            // 
            // cbSize
            // 
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "300x200",
            "320x240",
            "400x200",
            "400x300",
            "500x200",
            "500x250",
            "500x300",
            "640x480",
            "800x600",
            "200x300",
            "240x320",
            "200x400",
            "300x400",
            "200x500",
            "250x500",
            "300x500",
            "480x640",
            "600x800"});
            this.cbSize.Location = new System.Drawing.Point(12, 72);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(229, 28);
            this.cbSize.TabIndex = 7;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            // 
            // QRCodeInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.MuiChieu);
            this.Controls.Add(this.VNProvs);
            this.Controls.Add(this.bCalculate);
            this.Controls.Add(this.tbCoords);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gmap);
            this.Name = "QRCodeInsert";
            this.Text = "Tạo ảnh Gmap | Sơ họa mốc | AutoLISP Just Simple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbCoords;
        private System.Windows.Forms.Button bCalculate;
        private System.Windows.Forms.ComboBox VNProvs;
        private System.Windows.Forms.ComboBox MuiChieu;
        private System.Windows.Forms.ComboBox cbSize;
    }
}

