using lhBasic;
using lhBasic.AutoCad;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GmapTestings
{
    public partial class QRCodeInsert : Form
    {
        private static string kpath = "Survey\\SHM\\QRC";

        public QRCodeInsert()
        {
            InitializeComponent();

            gmap.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            gmap.Position = new GMap.NET.PointLatLng(21.0227384, 105.8163642);  //Ha Noi
                                                                                //gmap.Position = new GMap.NET.PointLatLng(11.3804716974896, 108.88483701555);   //NINH THUAN
                                                                                //gmap.Position = new GMap.NET.PointLatLng(11.3865043650045, 108.887844395394);   //NINH THUAN
        }


        int deltaw = 1;
        int deltah = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            VNProvs.DataSource = VNProvinces.Datas;
            //gmap.SetPositionByKeywords("Ha noi, Viet Nam");

            tbCoords.Text = Interaction.GetSetting(typeof(QRCodeInsert).Namespace, "Settings", tbCoords.Name, "569415.64	1259283.89");
            VNProvs.Text = Interaction.GetSetting(typeof(QRCodeInsert).Namespace, "Settings", VNProvs.Name, VNProvinces.Datas.FirstOrDefault());
            cbSize.Text = Interaction.GetSetting(typeof(QRCodeInsert).Namespace, "Settings", cbSize.Name, "1000x500");

            gmap.Zoom = 18;

            deltaw = this.Width - gmap.Width;
            deltah = this.Height - gmap.Height;

            bCalculate_Click(null, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Interaction.SaveSetting(typeof(QRCodeInsert).Namespace, "Settings", tbCoords.Name, tbCoords.Text);
            Interaction.SaveSetting(typeof(QRCodeInsert).Namespace, "Settings", VNProvs.Name, VNProvs.Text);
            Interaction.SaveSetting(typeof(QRCodeInsert).Namespace, "Settings", cbSize.Name, cbSize.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Files.GetSavePath(kpath, "FileSave", "Save as", "", "Bitmap Image|*.bmp|PNG Image|*.png|JPeg Image|*.jpg|Gif Image|*.gif");
            ImageFormat imageFormat = null;
            switch (Path.GetExtension(path).Replace(".", "").ToUpper())
            {
                case "BMP":
                    imageFormat = ImageFormat.Bmp;
                    break;

                case "PNG":
                    imageFormat = ImageFormat.Png;
                    break;

                case "JPEG":
                    imageFormat = ImageFormat.Jpeg;
                    break;

                case "GIF":
                    imageFormat = ImageFormat.Gif;
                    break;

                default:
                    throw new NotSupportedException("File extension is not supported");
            }

            gmap.ToImage().Save(path, imageFormat);
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            string[] spls = new List<string>() { "\t", " ", "," }.ToArray();
            var strs = tbCoords.Text.Split(spls);

            if (strs.Length < 2) return;

            var x = strs[0].ToDouble();
            var y = strs[1].ToDouble();
            if (x > y)
            {
                /*
                var t = x;
                x = y;
                y = t;
                */
            }

            var mcs = VNProvs.Text.Split(spls);
            if (mcs.Length > 1 && mcs.LastOrDefault().ToDouble() > 0)
            {
                var naturallat = 0.0;             //D7
                var naturallong = mcs.LastOrDefault().ToDouble().ToRadian();    //D8

                var D7 = naturallat;
                var D8 = naturallong;

                var C10 = 500000.0;
                var C11 = 0.0;
                var scalefactor = MuiChieu.Text.Any("3") ? 0.9999 : 0.9996;
                var C12 = scalefactor;

                double a = 6378137;             //C15
                var C15 = a;
                double b = 6356752.31424496;
                double _1f = 298.25722356;      //C16
                var c16 = _1f;

                //UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO
                //UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO
                //UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO//UTM_GEO
                double e2 = 2 * (1 / _1f) - (1 / _1f) * (1 / _1f);      //C17
                var C17 = e2;
                double e22 = e2 / ((1 - (1 / _1f)) * (1 - (1 / _1f)));  //C18
                var C18 = e22;

                Debug.Print("e2=" + e2);
                Debug.Print("e22=" + e22);

                double e1 = (1 - Math.Sqrt(1 - e2)) / (1 + Math.Sqrt(1 - e2));
                Debug.Print("e1=" + e1);
                var C21 = e1;

                double i25 = C17 / 4.0;
                double i26 = 3.0 * C17 * C17 / 64.0;
                double i27 = 5 * C17 * C17 * C17 / 256.0;
                double i28 = 3.0 * C17 / 8.0;
                double i29 = 3.0 * C17 * C17 / 32.0;
                double i30 = 45 * C17 * C17 * C17 / 1024.0;
                double i31 = 15 * C17 * C17 / 256.0;
                double i32 = 45 * C17 * C17 * C17 / 1024.0;
                double i33 = 35 * C17 * C17 * C17 / 3072.0;

                Debug.Print("i25-33=" + i25 + "/" + i26 + "/" + i27 + "/" + i28 + "/" + i29 + "/" + i30 + "/" + i31 + "/" + i32 + "/" + i33);

                double M0 = a * ((1 - i25 - i26 - i27) * naturallat - (i28 + i29 + i30) * Math.Sin(2.0 * naturallat) + (i31 + i32) * Math.Sin(4.0 * naturallat) - i33 * Math.Sin(6.0 * D7));
                Debug.Print("M0=" + M0);
                var C22 = M0;

                var M1 = C22 + (y - C11) / C12;
                Debug.Print("M1=" + M1);
                var C23 = M1;

                var u1 = C23 / (C15 * (1.0 - (C17 / 4.0) - 3.0 * (C17 * C17 / 64.0) - 5.0 * (C17 * C17 * C17 / 256.0)));
                Debug.Print("u1=" + u1);
                var C24 = u1;

                var F1 = C24 + ((3.0 * C21 / 2.0) - 27.0 * C21 * C21 * C21 / 32.0) * Math.Sin(2.0 * C24)
                    + (21.0 * (C21 * C21) / 16.0 - 55.0 * (C21 * C21 * C21 * C21) / 32.0) * Math.Sin(4 * C24) + (151.0 * (C21 * C21 * C21) / 96.0) * Math.Sin(6.0 * C24)
                    + (1097.0 * (C21 * C21 * C21 * C21) / 512.0) * Math.Sin(8.0 * C24);
                Debug.Print("F1=" + F1);
                var C25 = F1;

                var T1 = Math.Tan(C25) * Math.Tan(C25);
                Debug.Print("C26=T1=" + T1);
                var C26 = T1;

                var v1 = C15 / Math.Sqrt(1 - C17 * (Math.Sin(C25) * Math.Sin(C25)));
                Debug.Print("C27=v1=" + v1);
                var C27 = v1;

                var p1 = C15 * (1.0 - C17) / Math.Pow((1.0 - C17 * (Math.Sin(C25) * Math.Sin(C25))), 1.5);
                Debug.Print("C28=p1=" + p1);
                var C28 = p1;

                var c1 = C18 * (Math.Cos(C25) * Math.Cos(C25));
                Debug.Print("C29=c1=" + c1);
                var C29 = c1;

                var D = (x - C10) / (C12 * C27);
                Debug.Print("C30=D=" + D);
                var C30 = D;

                double lat = C25 - (C27 * Math.Tan(C25) / C28) * (C30 * C30 / 2.0 - (5.0 + 3.0 * C26 + 10.0 * C29 - 4.0 * (C29 * C29) - 9.0 * C18)
                    * (C30 * C30 * C30 * C30) / 24.0 + (61.0 + 90.0 * C26 + 298.0 * C29 + 45.0 * (C26 * C26) - 252.0 * C18 - 3.0 * C29 * C29) * Math.Pow(C30, 6.0) / 720.0);
                //lat = C25;

                double lon = D8 + (C30 - (1.0 + 2.0 * C26 + C29) * (Math.Pow(C30, 3.0)) / 6.0 + (5.0 - 2.0 * C29 + 28.0 * C26 - 3.0 * (C29 * C29)
                    + 8.0 * C18 + 24.0 * C26 * C26) * (Math.Pow(C30, 5.0)) / 120.0) / Math.Cos(C25);
                //lon = C29 ;
                Debug.Print("lat=" + lat + "\nlong=" + lon + " D7=" + D7 + " D8=" + D8);

                //GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC
                //GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC
                //GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC//GEO_GEOCENTRIC

                double H = 0;
                var v = a / Math.Sqrt(1.0 - e2 * (Math.Sin(lat)) * (Math.Sin(lat)));
                Debug.Print("C17=v=" + v);

                var X = (H + v) * Math.Cos(lat) * Math.Cos(lon);
                Debug.Print("X=" + X);

                var Y = (H + v) * Math.Cos(lat) * Math.Sin(lon);
                Debug.Print("Y=" + Y);

                var Z = ((1.0 - e2) * v + H) * Math.Sin(lat);
                Debug.Print("Z=" + Z);

                double k = 1.0;
                var DELTA_X = -191.90441429 * k;
                var DELTA_Y = -39.30318279 * k;
                var DELTA_Z = -111.45032830 * k;
                var ROT_X = -0.00928836 * k;
                var ROT_Y = 0.01975479 * k;
                var ROT_Z = -0.00427372 * k;
                var BWSCALE = 0.000000252906277 * k / 1000000.0;

                var Xgeo = DELTA_X + ((1.0 + BWSCALE) * (X + Y * (ROT_Z / 3600.0).ToRadian() - Z * (ROT_Y / 3600.0).ToRadian()));
                Debug.Print("Xgeo trans=" + Xgeo);

                var Ygeo = DELTA_Y + ((1.0 + BWSCALE) * (-X * (ROT_Z / 3600.0).ToRadian() + Y + Z * (ROT_X / 3600.0).ToRadian()));
                Debug.Print("Ygeo trans=" + Ygeo);

                var Zgeo = DELTA_Z + ((1.0 + BWSCALE) * (X * (ROT_Y / 3600.0).ToRadian() - Y * (ROT_X / 3600.0).ToRadian() + Z));
                Debug.Print("Zgeo trans=" + Zgeo);

                //GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO
                //GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO
                //GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO//GEOCENTRIC_GEO
                var p = Math.Sqrt(Xgeo * Xgeo + Ygeo * Ygeo);
                var F = Math.Atan(Zgeo * a / (p * b));
                Debug.Print("v/p/F=" + v + "/" + p + "/" + F);

                var newlat = Math.Atan((Zgeo + e22 * b * Math.Pow(Math.Sin(F), 3.0)) / (p - e2 * a * Math.Pow(Math.Cos(F), 3.0))).ToDegree();
                var newlon = Math.Atan(Ygeo / Xgeo);
                var d27 = newlon > 0 ? -(180.0 - newlon.ToDegree()) : newlon.ToDegree();
                var d28 = newlon > 0 ? newlon.ToDegree() : (180.0 + newlon.ToDegree());
                var d29 = naturallong < 0 ? d27 : d28;

                newlon = d29;

                Debug.Print("newlat/newlon=" + newlat + "/" + newlon);

                gmap.Position = new GMap.NET.PointLatLng(newlat, newlon);
            }

            Debug.Print("x/y=" + x + "/" + y);
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = cbSize.SelectedItem.ToString();
            var ss = s.Split("x");
            if (ss.Length < 2) return;

            var w = ss[0].CDouble();
            var h = ss[1].CDouble();
            if (w < 1 || h < 1) return;

            bool keep_ratio = false;
            if (keep_ratio)
            {
                var sc = h / w;
                Debug.Print("sc=" + sc + " w/h=" + w + "/" + h);

                var newh = gmap.Width * sc;

                Debug.Print("newh=" + newh + " oldw/h=" + gmap.Width + "/" + gmap.Height);

                var delta = this.Height - gmap.Height;
                this.Height = delta + (int)newh;

                Debug.Print("newh=" + newh + " oldw/h=" + gmap.Width + "/" + gmap.Height);

                Debug.Print("After gmap w/h=" + gmap.Width + "/" + gmap.Height + " h/w=" + (double)gmap.Height / gmap.Width);
            }
            else
            {
                //if(this.Width < deltaw + (int)w + 1) this.Width = deltaw + (int)w;
                //if(this.Height < deltah + (int)h + 1) this.Height = deltah + (int)h;
                this.Width = deltaw + (int)w;
                this.Height = deltah + (int)h;

            }
        }
    }
}