using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WPFApiParser.Model
{
    public class User
    {
        /// <summary>
        /// Id of user
        /// </summary>
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Name of user
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Username of User
        /// </summary>
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Email of user
        /// </summary>
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        /// <summary>
        /// Address Street Details
        /// </summary>
        /// 
        [JsonProperty("street")]
        private string street;
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        /// <summary>
        /// Address Suite
        /// </summary>
        private string suite;
        public string Suite
        {
            get { return suite; }
            set { suite = value; }
        }

        /// <summary>
        /// Address City
        /// </summary>
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// Address Zipcode
        /// </summary>
        private string zipcode;
        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        /// <summary>
        /// Latitude
        /// </summary>
        private string geo_lat;
        public string Geo_Lat
        {
            get { return geo_lat; }
            set { geo_lat = value; }
        }

        /// <summary>
        /// Longitude
        /// </summary>
        private string geo_lang;
        public string Geo_Lang
        {
            get { return geo_lang; }
            set { geo_lang = value; }
        }

        /// <summary>
        /// Phone
        /// </summary>
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// Website
        /// </summary>
        private string website;
        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        /// <summary>
        /// CompanyName
        /// </summary>
        private string companyname;
        public string CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }

        /// <summary>
        /// CompanyPhrase
        /// </summary>
        private string companyphrase;
        public string CompanyPhrase
        {
            get { return companyphrase; }
            set { companyphrase = value; }
        }

        /// <summary>
        /// Company BS
        /// </summary>
        private string companybs;
        public string CompanyBs
        {
            get { return companybs; }
            set { companybs = value; }
        }
    }
}
