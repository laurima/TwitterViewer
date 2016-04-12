using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace TwitterViewer
{
    class DBTwitterViewer
    {
        public static void AddCategoryToXML(string category)
        {
            List<char> list = new List<char>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[1].ChildNodes[0].ChildNodes)
            {
                list = xmlNode.Attributes["categoryname"].InnerText.ToList();
            }
        }

        public static List<char> ReadCategoriesFromXML()
        {
            List<char> list = new List<char>();
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(TwitterViewer.Properties.Settings.Default.CategoriesXML))
            {
                xmlDoc.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
                XmlNodeList xnList = xmlDoc.SelectNodes("/Categories");
                foreach (XmlNode xn in xnList)
                {
                    if (xn.Attributes["categoryname"] != null)
                    {
                        list = xn.Attributes["categoryname"].InnerText.ToList();
                    }
                }
            }
            else
            {
                createNewXML();
            }
            return list;
        }

        public static void createNewXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<categories><category categoryname='Test'><users></users></category></categories>");
            XmlTextWriter writer = new XmlTextWriter(TwitterViewer.Properties.Settings.Default.CategoriesXML, null);
            writer.Formatting = System.Xml.Formatting.Indented;
            doc.Save(writer);
        }

        public static void SerializeFollowedUsers(List<User> users)
        {
            List<string> serializedobjects = new List<string>();
            foreach (User user in users)
            {
                serializedobjects.Add(JsonConvert.SerializeObject(user));
            }


            using (System.IO.StreamWriter file = new System.IO.StreamWriter(TwitterViewer.Properties.Settings.Default.FollowedUsersJSON, false))
            {
                foreach (var obj in serializedobjects)
                {
                    file.WriteLine(obj);
                }
            }
        }

        public static List<User> DeserializeFollowedUsers()
        {
            List<User> deserializedobjects = new List<User>();

            using (System.IO.StreamReader file = new System.IO.StreamReader(TwitterViewer.Properties.Settings.Default.FollowedUsersJSON))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                   deserializedobjects.Add(JsonConvert.DeserializeObject<User>(line));
                }

            }
            return deserializedobjects;
        }
    }
}
