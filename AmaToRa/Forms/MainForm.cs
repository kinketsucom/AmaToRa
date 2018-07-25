using AmaToRa.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AmaToRa.API.AmaToRaAPI;

namespace AmaToRa {
    public partial class MainForm : Form {
        AmaToRaAPI api = new AmaToRaAPI();
        List<AmaData> data_list = new List<AmaData>();//データ表示用

        
        public MainForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string html = api.getAmaHtml("https://www.amazon.co.jp/dp/B01M6BJNHP/ref=sxnav_sxwds-bovbp-p_l_1?pf_rd_m=AN1VRQENFRJN5&pf_rd_p=4852575518267808564&pd_rd_wg=N2lLT&pf_rd_r=JFN6TP3DH1JKY04DK25C&pf_rd_s=desktop-sx-nav&pf_rd_t=301&pd_rd_i=B01M6BJNHP&pd_rd_w=cZfAF&pf_rd_i=%E3%83%A2%E3%83%90%E3%82%A4%E3%83%AB%E3%83%90%E3%83%83%E3%83%86%E3%83%AA%E3%83%BC&pd_rd_r=e07f5711-a3fb-4c84-ab84-a86f741807a8&ie=UTF8&qid=1532503651&sr=1");
            data_list.Add(api.getAmaData(html));

            foreach (var dat in data_list) {
                Console.WriteLine(dat.title);
                Console.WriteLine(dat.price);
                Console.WriteLine(dat.pic_url[0]);
                Console.WriteLine(dat.pic_url[1]);
                Console.WriteLine(dat.pic_url[2]);
                Console.WriteLine(dat.pic_url[3]);
                Console.WriteLine(dat.detail);
            }
        }
    }
}
