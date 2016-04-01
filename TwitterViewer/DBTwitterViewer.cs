using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterViewer
{
    class DBTwitterViewer
    {
        Categories categories = new Categories();
        categories.category = "test";
    }

    internal class Categories
    {
        List<Categories> categories;
        public Categories()
        {
            
        }
    }
}
