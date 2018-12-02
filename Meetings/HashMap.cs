using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meetings
{
    class HashMap
    {
        Dictionary<String, String> Pairs = new Dictionary<String, String>();

        public void Add(String key, String info)
        {
            
            if(Pairs.ContainsKey(key))
                MessageBox.Show(key+" is in use create a diffent one");
            else
                Pairs.Add(key, info);
            //Pairs.ContainsValue - for removing people from meetings
        }
       
        public void RemoveHashMapAstextfile()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                using (StreamWriter finished = new StreamWriter(@"C:\\Data.txt", false))
                {
                    int i = Pairs.Count;
                    for (int a = 0; a < i; a++)
                    {
                        String c = i.ToString();
                        if (Pairs[c].Contains("pref") || Pairs[c].Contains("exc"))
                        {

                        }
                        else
                        {
                            finished.WriteLine(Pairs[c]);
                        }
                    }
                    finished.Close();
                }
            }
            catch (Exception C)
            {
                MessageBox.Show("Exception: " + C.Message);
            }
        }
    }
}
