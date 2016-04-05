﻿using System;
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

<<<<<<< HEAD
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@TwitterViewer.Properties.Settings.Default.FollowedUsersJSON, false))
=======
<<<<<<< HEAD
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\H9142\TwitterViewer\Followedusers.json"))
=======
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(TwitterViewer.Properties.Settings.Default.FollowedUsersJSON, false))
>>>>>>> origin/master
>>>>>>> origin/master
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
<<<<<<< HEAD
            using (System.IO.StreamReader file = new System.IO.StreamReader(@TwitterViewer.Properties.Settings.Default.FollowedUsersJSON))
=======
<<<<<<< HEAD
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"D:\H9142\TwitterViewer\Followedusers.json"))
=======
            using (System.IO.StreamReader file = new System.IO.StreamReader(TwitterViewer.Properties.Settings.Default.FollowedUsersJSON))
>>>>>>> origin/master
>>>>>>> origin/master
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
