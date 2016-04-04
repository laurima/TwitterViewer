using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace TwitterViewer
{
    static class DBTwitterViewer
    {
        public static void SerializeCategories(List<string> categories)
        {

        }

        public static void SerializeFollowedUsers(List<User> users)
        {
            List<string> serializedobjects = new List<string>();
            foreach (User user in users)
            {
                serializedobjects.Add(JsonConvert.SerializeObject(user));
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\H8543\TwitterViewer\Followedusers.json"))
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
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"D:\H8543\TwitterViewer\Followedusers.json"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {

                }

            }
            return deserializedobjects;
        }

    }
}
