using AmaToRa.API;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AmaToRa.API.AmaToRaAPI;

namespace AmaToRa {
    public partial class MainForm : Form {
        AmaToRaAPI api = new AmaToRaAPI();
        List<AmaData> data_list = new List<AmaData>();//データ表示用
        // UNIXエポックを表すDateTimeオブジェクトを取得
        private static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textBox1.Text)) return;
            string html = api.getAmaHtml(textBox1.Text);
            data_list.Add(api.getAmaData(html));
            data_list.Last().amazon_url = textBox1.Text;
            AmaData last = data_list.Last();
            try { 
                dataGridView1.Rows.Add(last.title, last.title_over_flag, last.detail, last.detail_over_flag, getImageFromUrl(last.pic_url[0]), last.price);
            }catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }







        private Bitmap getImageFromUrl(string img_url) {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(img_url);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
            myResponse.Close();
            bmp = ResizeImage(bmp, 100, 100);
            return bmp;
        }

        private string getImagePathFromUrl(string img_url,string img_num,string loop_num) {
            if (string.IsNullOrEmpty(img_url)) return "";
            if (img_url.Contains(".gif")) return "";
            try {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(img_url);
                myRequest.Method = "GET";
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                myResponse.Close();
                bmp = ResizeImage(bmp, 100, 100);
                string filename = "";
                // 現在日時を表すDateTimeオブジェクトを取得
                DateTime targetTime = DateTime.Now;
                long unixTime = GetUnixTime(targetTime);
                filename = unixTime.ToString();
                string dir = System.IO.Directory.GetCurrentDirectory();
                dir += "/img/" + filename + "_" + loop_num + "_" + img_num + ".jpeg";
                Console.WriteLine(dir);
                bmp.Save(dir, System.Drawing.Imaging.ImageFormat.Jpeg);
                return dir;
            } catch(Exception ex) {
                Console.WriteLine(ex);
                return "";
            }
        }

        public static long GetUnixTime(DateTime targetTime) {
            // UTC時間に変換
            targetTime = targetTime.ToUniversalTime();

            // UNIXエポックからの経過時間を取得
            TimeSpan elapsedTime = targetTime - UNIX_EPOCH;

            // 経過秒数に変換
            return (long)elapsedTime.TotalSeconds;
        }

        private static Bitmap ResizeImage(Bitmap image, double dw, double dh) {
            double hi;
            double imagew = image.Width;
            double imageh = image.Height;
            if ((dh / dw) <= (imageh / imagew)) {
                hi = dh / imageh;
            } else {
                hi = dw / imagew;
            }
            int w = (int)(imagew * hi);
            int h = (int)(imageh * hi);
            Bitmap result = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(result);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, result.Width, result.Height);
            return result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            DataGridView dgv = (DataGridView)sender;
            //"Button"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "DeleteButtonColumn") {
                Console.WriteLine(e.RowIndex);
                foreach(var val in data_list) {
                    Console.WriteLine(val.title);
                }
                data_list.RemoveAt(e.RowIndex);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                dataGridView1.Refresh();
            }
            
        }

        private async void button2_Click(object sender, EventArgs e) {

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "hogehoge.csv";
            sfd.Filter = "CSVファイル(*.csv)|*.csv";
            sfd.Title = "保存先のファイルを選択してください";
                        //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK) {
                string filename = sfd.FileName;
                bool res = await Task.Run(() => WriteToExcel(filename));
                //結果を表示
                if (res) MessageBox.Show("保存しました" + filename, "一括住所取得", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("保存に失敗しました", "一括住所取得", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool WriteToExcel(string filename) {
            using (var sw = new System.IO.StreamWriter(filename, false, System.Text.Encoding.GetEncoding("shift_jis"))) {
                sw.WriteLine("商品名, 商品の説明, 商品画像１,商品画像２,商品画像３,商品画像４,カテゴリ１,カテゴリ２,カテゴリ３,サイズ,ブランド,配送料の負担,配送の方法,商品の状態,発送元の地域,発送までの日数,販売価格,商品url");
                string title = "";
                string detail = "";
                int loop_count = 0;
                foreach (var val in data_list) {
                    title = val.title;
                    if (title.Length > 40) title = title.Remove(40);
                    detail = val.detail;
                    if (detail.Length > 1000) detail = detail.Remove(1000);

                    try {
                        for(int i = 0; i < 4; i++) {
                            if (!string.IsNullOrEmpty(val.pic_url[i])) val.pic_location[i]=getImagePathFromUrl(val.pic_url[i],i.ToString(),loop_count.ToString());
                        }
                        
                    }catch(Exception ex) {
                        Console.WriteLine(ex);
                    }


                    sw.WriteLine(title+","+detail+","+val.pic_location[0]+","+val.pic_location[1]+","+val.pic_location[2]+","+val.pic_location[3]
                        +","+ "スマホ/家電/カメラ" + ","+ "スマートフォン/携帯電話" + ","+ "スマートフォン本体"
                        + ","+""+","+""+","+ "送料込み(あなたが負担)"+","+"未定"+","+ "新品、未使用"+","+"大阪府"+","+ "1～2日で発送"+","+val.price.ToString()+","+val.amazon_url);

                    loop_count += 1;
                }



            }

                return true;
        }





    }
    
}
