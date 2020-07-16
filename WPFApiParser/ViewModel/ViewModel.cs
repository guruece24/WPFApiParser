using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFApiParser.Model;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApiParser.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPFApiParser.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            ListUserData = new ObservableCollection<UserData>();
            ListSelectedUserData = new ObservableCollection<Model.UserData>();
            UserData = new UserData();

            LoadAPI();
        }

        private ObservableCollection<UserData> listuserdata;
        public ObservableCollection<UserData> ListUserData
        {
            get { return listuserdata; }
            set { listuserdata = value; }
        }

        private ObservableCollection<UserData> listselecteduserdata;

        public ObservableCollection<UserData> ListSelectedUserData
        {
            get { return listselecteduserdata; }
            set { listselecteduserdata = value; }
        }        

        private UserData userdata;
        public UserData UserData
        {
            get { return userdata; }
            set { userdata = value; }
        }

        private UserData selecteditem;
        public UserData SelectedItem
        {
            get 
            { 
                return selecteditem; 
            }
            set 
            { 
                selecteditem = value; 
                NotifyUI("SelectedItem");
                GetSelectedUserData(); 
            }
        }      

        private void GetSelectedUserData()
        {
            ListSelectedUserData.Add(new UserData() { Id = SelectedItem.Id, UserId = SelectedItem.UserId, Title = SelectedItem.Title, Body = SelectedItem.Body });
        }        

        public void LoadAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    JArray jsonData = JArray.Parse(readTask.Result.ToString());

                    for (int i = 0; i < jsonData.Count; i++)
                    {
                        JObject jobj = JObject.Parse(jsonData[1].ToString());

                        ListUserData.Add(new UserData
                        {
                            UserId = Convert.ToInt32(jsonData[i].SelectToken("userId").ToString()),
                            Id = Convert.ToInt32(jsonData[i].SelectToken("id").ToString()),
                            Title = Convert.ToString(jsonData[i].SelectToken("title").ToString()),
                            Body = Convert.ToString(jsonData[i].SelectToken("body").ToString())
                        });
                    }                   
                }
            }
        }

        protected void NotifyUI(string param)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
