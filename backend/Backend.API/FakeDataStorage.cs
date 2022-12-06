using Backend.Core.Modell.Entities;
using Backend.Core.Variables;
using Backend.Services.Common;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Backend.API
{
    public static class FakeDataStorage
    {
        private static List<Player> _data = null;

        public static List<Player> Data
        {
            get
            {
                return _data == null ?
                       FetchData("./data.json") :
                       _data;
            }
        }

        public static void AddNewPalyer(Player player)
        { 
            if(_data == null)
            {
                _data = FetchData("./data.json");
            }

            _data.Add(player);
        }

        public static async Task UpdatePalyer(Player player)
        {
            if (_data == null)
            {
                _data = FetchData("./data.json");
            }

            Player toUpdate = _data.Find(x => x.Id == player.Id);

            if (!string.IsNullOrEmpty(player.ImageLink))
            {
                await ImageUploadHandler.DeleteFile(toUpdate.ImageLink);
            }
            else
            {
                player.ImageLink = toUpdate.ImageLink;
            }

            int index = _data.IndexOf(toUpdate);
            _data.RemoveAt(index);
            _data.Insert(index, player);
        }

        public static async Task DeletePalyer(int id)
        {
            if (_data == null)
            {
                _data = FetchData("./data.json");
            }

            Player toDelete = _data.Find(x => x.Id == id);
            int index = _data.IndexOf(toDelete);
            _data.RemoveAt(index);

            if (!string.IsNullOrEmpty(toDelete.ImageLink))
            {
                await ImageUploadHandler.DeleteFile(toDelete.ImageLink);
            }
        }

        private static async Task<List<Player>> FetchData()
        {
            string url = "";

            List<Player> players = await url.GetJsonAsync<List<Player>>();

            return players;
        }

        private static List<Player> FetchData(string filePath)
        {
            List<Player> players = null;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
                {
                    string jsonString = r.ReadToEnd();
                    players = JsonConvert.DeserializeObject<List<Player>>(jsonString);
                }
            }

            return players;
        }

        public static void SaveData(string filePath = "./data.json")
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter r = new StreamWriter(fs, Encoding.UTF8))
                {
                    string players = JsonConvert.SerializeObject(_data);
                    r.Write(players);
                }
            }

            _data = FetchData("./data.json");
        }
    }
}
