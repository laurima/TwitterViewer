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

namespace TwitterViewer
{
    class DBTwitterViewer
    {
        public static void SerializeCategory(string category)
        {
            /*var ctgrytmp = JsonConvert.SerializeObject(category);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(TwitterViewer.Properties.Settings.Default.CategoriesJSON, false))
            {
                    file.WriteLine(ctgrytmp);
            }*/
        }
        public static List<String> ReadCategoriesXML()
        {
            //next
            return null;
        }

        public static void AddCategoryToXML(string category)
        {

        }


        /*public static XElement ReadCategoriesXML()
        {
            XElement modelXML = new XElement("Category",
                new XElement("categories",
                    new XElement("users",
                        new XElement("user")
                        )
                    )
                );
            try
            {
                modelXML = XElement.Load(TwitterViewer.Properties.Settings.Default.CategoriesXML);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading XML from file: " + ex.Message);
            }
            return modelXML;
        }

        public static void AddCategoryToXML(string category)
        {
            XElement xe = ReadCategoriesXML();
            XElement newCategory = IncomingChildElement(category);
            xe.Add(newCategory);
            xe.Save(TwitterViewer.Properties.Settings.Default.CategoriesXML);
        }

        private static XElement IncomingChildElement(string categoryName)
        {
            {
                XElement category = new XElement("Category",
                        new XElement("categories",
                            new XElement(categoryName)
                        )
                );
                return category;
            }
        }*/

        public static List<Category> DeserializeCategories()
        {
            List<Category> desrializedcategories = new List<Category>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(TwitterViewer.Properties.Settings.Default.CategoriesJSON, false))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    desrializedcategories.Add(JsonConvert.DeserializeObject<Category>(line));
                }

            }
            return desrializedcategories;
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
