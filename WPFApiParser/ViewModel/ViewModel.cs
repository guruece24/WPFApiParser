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
            UserPosts = new ObservableCollection<UserPost>();
            Users     = new ObservableCollection<User>();

            SelectedUserPosts = new ObservableCollection<Model.UserPost>();
            UserData = new UserPost();
            User     = new User();

            LoadApiData();          
        }

        private void LoadApiData()
        {
            ApiClient apiClient = new ApiClient();
            UserPosts = apiClient.LoadUserPosts();
            Users    = apiClient.LoadUsers();
        }

        private ObservableCollection<UserPost> userposts;
        public ObservableCollection<UserPost> UserPosts
        {
            get { return userposts; }
            set { userposts = value; }
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private ObservableCollection<UserPost> selecteduserposts;

        public ObservableCollection<UserPost> SelectedUserPosts
        {
            get { return selecteduserposts; }
            set { selecteduserposts = value; }
        }        

        private UserPost userdata;
        public UserPost UserData
        {
            get { return userdata; }
            set { userdata = value; }
        }

        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        

        private User selecteditem;
        public User SelectedItem
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

        public void GetSelectedUserData()
        {
            UserPost userPost = UserPosts.AsEnumerable().Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
            SelectedUserPosts.Add(new UserPost() { Id = userPost.Id, UserId = userPost.UserId, Title = userPost.Title, Body = userPost.Body });
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
