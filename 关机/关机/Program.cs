using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Xml.Linq;

namespace 关机
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Main());
        }
    }

    static class Transform
    {
        public static string intTostr(int hours, int minutes, int seconds)
        {
            const string timeFormat = "{0:00}：{1:00}：{2:00}";
            string strResult = string.Empty;

            strResult = string.Format(timeFormat, hours, minutes, seconds);
            return strResult;
        }
        public static string intTostr(int num)
        {
            const string timeFormat = "{0:00}：{1:00}：{2:00}";
            string strResult = string.Empty;
            int hours = num / 3600;
            int minutes = (num - hours * 3600) / 60;
            int seconds = (num - hours * 3600 - minutes * 60) / 60;

            strResult = string.Format(timeFormat, hours, minutes, seconds);
            return strResult;
        }
        public static int strToint(string str)
        {
            const int HOUR = 3600;
            const int MIN = 60;

            int intResult;
            int hour = 0;
            int min = 0;
            int sec = 0;
            hour = Convert.ToInt32(str.Substring(0, 2));
            min = Convert.ToInt32(str.Substring(3, 2));
            sec = Convert.ToInt32(str.Substring(6, 2));
            if (min >= 60 || sec >= 60)
            {
                MessageBox.Show("时间格式错误，请重新输入！", "提示");
                return 0;
            }
            intResult = hour * HOUR + min * MIN + sec;
            return intResult;
        }
        public static string strFormat(string str)
        {
            string hour, min, sec;
            int len = str.Length;
            if (len == 8)
            {
                return str;
            }
            hour = str.Substring(0, 2);
            min = str.Substring(2, 2);
            sec = str.Substring(4, 2);
            return hour + "：" + min + "：" + sec;
        }
        public static String milliesToTime(int currentMillies)
        {
            int hours, minutes, seconds;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddHours(8);
            dt = dt.AddSeconds(currentMillies);
            hours = dt.Hour;
            minutes = dt.Minute;
            seconds = dt.Second;
            return Transform.intTostr(hours, minutes, seconds);
        }
        public static String calTime(int endTime, bool trans)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            if (trans)
            {
                int spanTime = calSpanTime(endTime);
                if (spanTime > 0)
                {
                    hours = spanTime / 3600;
                    minutes = (spanTime - hours * 3600) / 60;
                    seconds = (spanTime - hours * 3600 - minutes * 60);
                }
            }
            else
            {
                hours = endTime / 3600;
                minutes = (endTime - hours * 3600) / 60;
                seconds = (endTime - hours * 3600 - minutes * 60);
            }
            return intTostr(hours, minutes, seconds);

        }
        public static int calSpanTime(int endTime)
        {
            return (int)(endTime - NetworkManager.getCurrentMillis("double"));
        }

        public static int parseExploreId(int exploreId)
        {
            int chapter = exploreId / 10000;
            int site = exploreId % 10000;
            return (chapter - 1) * 4 + site - 1;
        }
    }

    class Remind
    {
        public void expeditionRemind()
        {
            SoundPlayer voice = new SoundPlayer("1112_my_room.wav");
            voice.Play();
        }
    }

    static class Encryption
    {
        public static String getMD5(String response)
        {
            byte[] md5Buffer = Encoding.Default.GetBytes(response);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Hash = md5.ComputeHash(md5Buffer);
            //if (full)
            {
                return BitConverter.ToString(md5Hash).Replace("-", "");
            }
            /*else
            {
                return BitConverter.ToString(md5Hash).Replace("-", "").Substring(0, 16);
            }*/
        }

        public static String getBase64(String response)
        {
            byte[] base64Buffer = Encoding.Default.GetBytes(response);
            return Convert.ToBase64String(base64Buffer);
        }
    }

    static class NetworkManager
    {
        private static String url_passport_hm = "http://login.jr.moefantasy.com/index/passportLogin/";
        //private static String url_login = "http://s8.jr.moefantasy.com/index/login/";
        private static String url_init = "http://s8.jr.moefantasy.com/api/initGame";
        private static String market = "&gz=1&market=2&channel=100011&version=3.7.0";
        private static String username = "";
        private static String password = "";
        private static int serverID = 0;


        public static HttpWebResponse CreatePostHttpResponse(string url, CookieCollection cookies = null, Boolean coding = false, Dictionary<string, string> parameters = null)
        {
            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            if (coding)
            {
                request.Headers.Add("Accept-Encoding", "gzip");
            }

            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                buffer.AppendFormat("{0}={1}", "username", parameters["username"]);
                buffer.Append("&");
                buffer.AppendFormat("{0}={1}", "pwd", parameters["password"]);
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }

        public static HttpWebResponse CreateGetHttpResponse(string url, string cookie)
        {
            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Headers.Set("cookie", cookie);
            request.Headers.Add("Accept-Encoding", "gzip");
            return request.GetResponse() as HttpWebResponse;
        }

        public static JsonParse openConnection()
        {
            //Dictionary<string, string> cookie = new Dictionary<string, string>();
            List<string> cookie = new List<string>();
            string sCookie = "";
            //从xml文件中读取用户的账户名和密码并进行base64编码
            readUserInfo();
            Dictionary<string, string> loginMessage = new Dictionary<string, string>();
            loginMessage.Add("username", username.ToString());
            loginMessage.Add("password", password.ToString());
            String finalURL = buildUrl(username, password);
            HttpWebResponse webResponse = CreatePostHttpResponse(finalURL, null, false, loginMessage);
            Stream inf = new InflaterInputStream(webResponse.GetResponseStream());
            StreamReader readStr = new StreamReader(inf, Encoding.GetEncoding("UTF-8"));
            sCookie = webResponse.Headers.Get("Set-Cookie");
            sCookie = parseCookie(sCookie, cookie);
            //UID = getUID(readStr.ReadToEnd());

            url_init = "http://s" + (serverID + 2) + ".jr.moefantasy.com/api/initGame";
            String urlString = url_init + "?&crazy=1&t=" + getCurrentMillis() + 1;
            urlString += "&e=" + Encryption.getMD5(urlString) + market;
            finalURL = urlString;
            //webQuest.Headers.Add(HttpRequestHeader.UserAgent, "Dalvik/2.1.0 (Linux; U; Android 7.0; KNT-AL20 Build/HUAWEIKNT-AL20)");
            webResponse = CreateGetHttpResponse(finalURL, sCookie);
            inf = new InflaterInputStream(webResponse.GetResponseStream());
            readStr = new StreamReader(inf, Encoding.GetEncoding("UTF-8"));
            String response = readStr.ReadToEnd();
            //MessageBox.Show(response);
            webResponse.Close();
            return parseExplore(response);
        }

        public static String buildUrl(String username, String password)
        {
            String urlStringFin = url_passport_hm + "&t=" + getCurrentMillis() + 1;
            String urlString = url_passport_hm + username + "/" + password + "/&t=" + getCurrentMillis() + 1;
            String urlMD5 = Encryption.getMD5(urlString);
            urlStringFin += "&e=" + urlMD5 + market;

            return urlStringFin;
        }

        public static String getCurrentMillis()
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = DateTime.Now;
            TimeSpan span = d2.Subtract(d1);
            span -= TimeSpan.FromHours(8);
            return span.TotalMilliseconds.ToString().Substring(0, 12);
        }

        public static double getCurrentMillis(String mod)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = DateTime.Now;
            TimeSpan span = d2.Subtract(d1);
            span -= TimeSpan.FromHours(8);
            return span.TotalSeconds;
        }

        public static String getUID(String response)
        {
            User user = new User();
            User user2 = JsonConvert.DeserializeObject<User>(response);
            return user2.userID;
        }
        public static JsonParse parseExplore(String response)
        {
            JsonParse jsonParse = JsonConvert.DeserializeObject<JsonParse>(response);
            return jsonParse;
        }

        public class User
        {
            public String userID;
            public User()
            {
                userID = "0";
            }
        }

        public class JsonParse
        {
            public UserVo userVo { get; set; }
            public PveExploreVo pveExploreVo { get; set; }
        }

        public class PveExploreVo
        {
            public List<Levels> levels { get; set; }
        }

        public class UserVo
        {
            public int level { get; set; }
        }

        public class Levels
        {
            public String exploreId { get; set; }
            public String fleetId { get; set; }
            public int startTime { get; set; }
            public int endTime { get; set; }
        }

        public static void readUserInfo()
        {
            XDocument xmlFile = XDocument.Load("UserData.xml");
            XElement root = xmlFile.Root;
            XElement xele = root.Element("userInfo");
            XElement name = xele.Element("username");
            XElement passW = xele.Element("password");
            XElement serverN = xele.Element("server");
            username = Encryption.getBase64(name.Value);
            password = Encryption.getBase64(passW.Value);
            serverID = Convert.ToInt32(serverN.Value);
        }

        public static string parseCookie(string sCookie, List<string> cookie)
        {
            string resCookie = "";
            cookie.Add(sCookie.Split(';')[0]);  //hf_skey
            sCookie = sCookie.Substring(cookie[0].Length + 1, sCookie.Length - (cookie[0].Length + 1));
            cookie.Add(sCookie.Split(',')[0]);  //path
            cookie.Add(sCookie.Split(',')[1]);  //QCLOUD

            resCookie = cookie[0] + ";" + cookie[1] + ";" + cookie[2];
            return resCookie;
        }
    }

    class LodingManager
    {
        private string username = "";
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        private string password = "";
        public string PassWord
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        private int serverID = 0;
        public int ServerID
        {
            get
            {
                return serverID;
            }
            set
            {
                serverID = value;
            }
        }

        public void readUserInfo()
        {
            //string workDir = System.IO.Directory.GetCurrentDirectory();
            //if (!File.Exists(workDir + "/UserData.xml"))
            {
                //File.Create(workDir + "UserData.xml");
            }
            XDocument xmlFile = XDocument.Load(System.IO.Directory.GetCurrentDirectory() + "/UserData.xml");
            XElement root = xmlFile.Root;
            XElement xele = root.Element("userInfo");
            XElement name = xele.Element("username");
            XElement passW = xele.Element("password");
            XElement serverN = xele.Element("server");
            //username = Encryption.getBase64(name.Value);
            username = name.Value;
            //password = Encryption.getBase64(passW.Value);
            password = passW.Value;
            serverID = Convert.ToInt32(serverN.Value);
        }
    }
}
