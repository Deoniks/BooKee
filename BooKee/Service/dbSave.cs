using BooKee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooKee.Service
{
    class dbSave
    {
        private readonly string PATH;

        public dbSave(string path)
        {
            PATH = path;
        }
        public BindingList<TodoMod> LoadDate()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoMod>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoMod>>(fileText);
            }
        }

        public void SaveDate(object todoData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {

                string output = JsonConvert.SerializeObject(todoData);
                writer.Write(output);
            }
        }
    }
}
