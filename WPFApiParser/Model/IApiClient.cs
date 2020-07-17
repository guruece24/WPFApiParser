using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WPFApiParser.Model
{
    public interface IApiClient
    {
        ObservableCollection<UserPost> LoadUserPosts();
        ObservableCollection<User> LoadUsers();
    }
}
