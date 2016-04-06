using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TwitterViewer
{
    static class DBTwitterViewer
    {
        public static void SerializeCategory(string category)
        {
            /*var ctgrytmp = JsonConvert.SerializeObject(category);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(TwitterViewer.Properties.Settings.Default.CategoriesJSON, false))
            {
                    file.WriteLine(ctgrytmp);
            }*/
        }

        public static JObject ReadCategoriesJSON()
        {
            JObject o1;
            using (StreamReader file = System.IO.File.OpenText(TwitterViewer.Properties.Settings.Default.CategoriesJSON))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                o1 = o2;
            }

            return o1;
        }

        public static List<Category> DeserializeCategories()
        {
            List<Category> desrializedcategories = new List<Category>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(TwitterViewer.Properties.Settings.Default.CategoriesJSON))
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
