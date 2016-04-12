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
        public static void addCategoryToXML(string category)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
                XmlNode root = xmlDoc.SelectSingleNode("/categories");
                XmlElement elem = xmlDoc.CreateElement("category");
                elem.SetAttribute("categoryname", category);
                XmlElement users = xmlDoc.CreateElement("users");
                elem.AppendChild(users);
                root.AppendChild(elem);
                xmlDoc.Save(TwitterViewer.Properties.Settings.Default.CategoriesXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void deleteCategoryFromXML(string category)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
                XmlNode root = xmlDoc.SelectSingleNode("/categories");
                XmlNode delcategory = xmlDoc.SelectSingleNode(string.Format("/categories/category[@categoryname='{0}']", category));
                root.RemoveChild(delcategory);
                xmlDoc.Save(TwitterViewer.Properties.Settings.Default.CategoriesXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insertUserToCategory(string category, User user)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
                XmlNode root = xmlDoc.SelectSingleNode(string.Format("/categories/category[@categoryname='{0}']/users", category));
                XmlElement elem = xmlDoc.CreateElement("user");
                elem.InnerText = user.Screenname;
                root.AppendChild(elem);
                xmlDoc.Save(TwitterViewer.Properties.Settings.Default.CategoriesXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> ReadCategoriesFromXML()
        {
            List<string> categorynames = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                if (File.Exists(TwitterViewer.Properties.Settings.Default.CategoriesXML))
                {
                    xmlDoc.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
                    XmlNodeList categories = xmlDoc.SelectNodes("/categories/category");
                    foreach (XmlNode category in categories)
                    {
                        categorynames.Add(category.Attributes["categoryname"].Value);
                    }
                }
                else
                {
                    createNewXML();
                }
                return categorynames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
