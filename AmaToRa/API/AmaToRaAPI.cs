using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmaToRa.API {
    public class AmaToRaAPI {
        //private const string USER_AGENT = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_3 like Mac OS X) AppleWebKit/603.3.8 (KHTML, like Gecko) Mobile/14G60Rakuma/7.2.0";
        private string proxy;
        //private const string XAPPVERSION = "600";
        public CookieContainer cc = new CookieContainer();
        public MainForm main_form;
        public int progress_num;
        public int stop_num = 400;



        #region APIリクエストテンプレート
        //GET,POSTのRequestのResponse
        private class AmaToRaRawResponse {
            public bool error = false;
            public string response = "";
            public AmaToRaRawResponse() { }
            public AmaToRaRawResponse(string response, bool error = false) {
                this.response = response; this.error = error;
            }
        }

        public class AmaData {
            public string title;
            public string title_over_flag = "なし";
            public string[] pic_url = new string[4];
            public string[] pic_location = new string[4];
            public int price = 0;
            public string detail = "";
            public string detail_over_flag = "なし";
            public string amazon_url = "";

        }


        public string getAmaHtml(string url) {
            return getAmaToRaAPI(url).response;
        }
        public AmaData getAmaData(string html) {
            AmaData data = new AmaData();
            //HTMLを解析する
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            //タイトル
            string xpath = "//*[@id='productTitle']";
            var node = doc.DocumentNode.SelectSingleNode(xpath);
            data.title = node.InnerHtml.Replace("\n", "").Replace("  ", "");
            if (data.title.Length > 40) { data.title_over_flag = (data.title.Length - 40).ToString(); }
            //メイン画像
            xpath = "//*[@id='landingImage']";
            node = doc.DocumentNode.SelectSingleNode(xpath);
            data.pic_url[0] = node.Attributes["data-old-hires"].Value;
            //サブ画像
            xpath = "//*[@class='a-button a-button-thumbnail a-button-toggle']/span/span/img";
            var collection = doc.DocumentNode.SelectNodes(xpath);
            for (int i = 0; i < 3; i++) {
                if (collection.Count <= i) break;
                if (!string.IsNullOrEmpty(collection[i].Attributes["src"].Value)) {
                    data.pic_url[i + 1] = collection[i].Attributes["src"].Value.Replace("SS40", "SL1000");
                }
            }
            xpath = "//*[@id='priceblock_ourprice']";
            node = doc.DocumentNode.SelectSingleNode(xpath);
            if (node == null) {
                xpath = "//*[@id='priceblock_saleprice']";
                node = doc.DocumentNode.SelectSingleNode(xpath);
            }
            var price = node.InnerHtml.Replace("\n", "").Replace("￥", "").Replace(" ", "").Replace(",", "");
            data.price = int.Parse(price);
            //商品説明
            xpath = "//*[@id='feature-bullets']/ul/li";
            collection = doc.DocumentNode.SelectNodes(xpath);
            if (collection != null) {
                if (collection.Count >= 2) {
                    collection.RemoveAt(0);
                    collection.RemoveAt(0);

                    foreach (var val in collection) {
                        data.detail += val.InnerHtml.Replace("<span class=\"a-list-item\"> ", "").Replace("\n", "").Replace("\t", "").Replace("</span>","");
                    }
                    if (data.detail.Length > 1000) { data.detail_over_flag = (data.detail.Length - 1000).ToString(); }
                }
            }

            return data;
        }

        public void DataToExcel(List<AmaData> data_list ) {
            //商品名
            //商品の説明
            //商品画像１～４

            //カテゴリー１～３

            //サイズ（基本なしでいい）

            //ブランド（基本なしでいい）

            //配送料の負担
            //送料込み(あなたが負担)

            //配送の方法
            //未定

            //商品の状態
            //新品、未使用

            //発送元の地域
            //京都

            //発送までの日数
            //1〜2日で発送

        }



        //FrilAPIをGetでたたく
        //private AmaToRaRawResponse getAmaToRaAPI(string url, Dictionary<string, string> param, CookieContainer cc, bool webmode = false) {
        private AmaToRaRawResponse getAmaToRaAPI(string url, bool webmode = false) {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //ストップウォッチを開始する
            sw.Start();
            AmaToRaRawResponse res = new AmaToRaRawResponse();
            try {
                //HttpWebRequestの作成
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.CookieContainer = cc;
                //req.UserAgent = AmaToRaAPI.USER_AGENT;
                req.Method = "GET";
                //webモードのときはauth_tokenをヘッダにいれる
                //if (webmode && !string.IsNullOrEmpty(this.account.auth_token)) req.Headers.Add("Authorization", this.account.auth_token);
                //プロキシの設定
                if (string.IsNullOrEmpty(this.proxy) == false) {
                    System.Net.WebProxy proxy = new System.Net.WebProxy(this.proxy);
                    req.Proxy = proxy;
                }
                //結果取得
                string content = "";
                var task = Task.Factory.StartNew(() => executeGetRequest(req));
                task.Wait(10000);
                if (task.IsCompleted) {
                    res = task.Result;
                } else
                    throw new Exception("Timed out");
                if (res.error) throw new Exception("webrequest error");
                //Log.Logger.Info("RakumaGETリクエスト成功");
                return res;
            } catch (Exception e) {
                //Log.Logger.Error("RakumaGETリクエスト失敗:" + res.response);
                Console.WriteLine(e);
                return res;
            }
        }
        private AmaToRaRawResponse executeGetRequest(HttpWebRequest req) {
            try {
                HttpWebResponse webres = (HttpWebResponse)req.GetResponse();
                Stream s = webres.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                string content = sr.ReadToEnd();
                return new AmaToRaRawResponse(content, false);
            } catch (Exception ex) {
                Console.WriteLine(ex);
                return new AmaToRaRawResponse("", true);
            }
        }
      
        #endregion
    }
}
