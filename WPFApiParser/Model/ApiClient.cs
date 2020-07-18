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
using System.Configuration;
using Newtonsoft.Json;

namespace WPFApiParser.Model
{
    public class ApiClient : IApiClient
    {
        public ObservableCollection<UserPost> LoadUserPosts()
        {
            using (var client = new HttpClient())
            {
                var userPosts = new ObservableCollection<UserPost>();

                client.BaseAddress = new Uri("" + ConfigurationManager.AppSettings["ApiURLUserPosts"].ToString() + "");
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
                        userPosts.Add(new UserPost
                        {
                            UserId  = Convert.ToInt32(jsonData[i].SelectToken("userId").ToString().RemoveQuotes()),
                            Id      = Convert.ToInt32(jsonData[i].SelectToken("id").ToString().RemoveQuotes()),
                            Title   = Convert.ToString(jsonData[i].SelectToken("title").ToString().RemoveQuotes()),
                            Body    = Convert.ToString(jsonData[i].SelectToken("body").ToString().RemoveQuotes())
                        });
                    }
                }

                return userPosts;
            }
        }

        public ObservableCollection<User> LoadUsers()
        {
            using (var client = new HttpClient())
            {
                var users = new ObservableCollection<User>();

                client.BaseAddress = new Uri("" + ConfigurationManager.AppSettings["ApiURLUsers"].ToString() + "");
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
                        users.Add(new User
                        {
                            Name         = Convert.ToString(jsonData[i].SelectToken("name").ToString().RemoveQuotes()),
                            Id           = Convert.ToInt32(jsonData[i].SelectToken("id").ToString().RemoveQuotes()),
                            UserName     = Convert.ToString(jsonData[i].SelectToken("username").ToString().RemoveQuotes()),
                            Email        = Convert.ToString(jsonData[i].SelectToken("email").ToString().RemoveQuotes()),
                            Street       = Convert.ToString(jsonData[i].SelectToken("address").SelectToken("street").ToString().RemoveQuotes()),
                            Suite        = Convert.ToString(jsonData[i].SelectToken("address").SelectToken("suite").ToString().RemoveQuotes()),
                            City         = Convert.ToString(jsonData[i].SelectToken("address").SelectToken("city").ToString().RemoveQuotes()),
                            ZipCode      = Convert.ToString(jsonData[i].SelectToken("address").SelectToken("zipcode").ToString().RemoveQuotes()),
                            Geo_Lat      = Convert.ToString(jsonData[i].SelectToken("address").SelectToken("geo").SelectToken("lat").ToString().RemoveQuotes()),
                            Geo_Lang     = Convert.ToString(jsonData[i].SelectToken("address").SelectToken("geo").SelectToken("lng").ToString().RemoveQuotes()),
                            Phone        = Convert.ToString(jsonData[i].SelectToken("phone").ToString().RemoveQuotes()),
                            Website      = Convert.ToString(jsonData[i].SelectToken("website").ToString().RemoveQuotes()),
                            CompanyName  = Convert.ToString(jsonData[i].SelectToken("company").SelectToken("name").ToString().RemoveQuotes()),
                            CompanyPhrase = Convert.ToString(jsonData[i].SelectToken("company").SelectToken("catchPhrase").ToString().RemoveQuotes()),
                            CompanyBs    = Convert.ToString(jsonData[i].SelectToken("company").SelectToken("bs").ToString().RemoveQuotes())
                        });
                    }
                }
                return users;
            }
        }
    }
}
