using LearningTreatz.Core;
using LearningTreatz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LearningTreatz
{
    public class StateManager
    {
        public static List<Restaurant> RecentlyViewed
        {
            get
            {
                if (HttpContext.Current.Session[Constants.RecentlyViewed] == null)
                {
                    HttpContext.Current.Session[Constants.RecentlyViewed] = new List<Restaurant>();
                }
                return (List<Restaurant>)HttpContext.Current.Session[Constants.RecentlyViewed];
            }
        }




        public static string EmailAddress
        {
            get
            {
                if (HttpContext.Current.Session[Constants.EmailAddress] == null)
                {
                    HttpContext.Current.Session[Constants.EmailAddress] = Membership.GetUser().Email;
                }
                return (string)HttpContext.Current.Session[Constants.EmailAddress];
            }
        }





        public static string City
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[Constants.City] != null)
                {
                    return HttpContext.Current.Request.Cookies[Constants.City].Value;
                }
                return string.Empty;
            }
            set
            {
                HttpCookie cookie = new HttpCookie(Constants.City, value);
                cookie.Expires = DateTime.Now.AddYears(1);
                if (HttpContext.Current.Request.Cookies[Constants.City] != null)
                {
                    HttpContext.Current.Response.SetCookie(cookie);
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }

        public static IEnumerable<City> Cities()
        {
            var cityList = HttpContext.Current.Cache[Constants.CityList] as IEnumerable<City>;
            if (cityList == null)
            {
                CityService db = new CityService();
                cityList = db.Cities();
                HttpContext.Current.Cache[Constants.CityList] = cityList;
            }
            return cityList;
        }



    }
}