using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class ActivityService
    {
        private readonly string URL = "http://localhost:5046/api/activities";

        public Dashboard GetDashboard()
        {
            using (HttpClient client = new HttpClient())
            {
                var dashboard = client.GetFromJsonAsync<Dashboard>($"{URL}/dashboard").Result;
                return dashboard;
            }
        }

        public List<Activity> GetActivities()
        {
            using (HttpClient client = new HttpClient())
            {
                var activities = client.GetFromJsonAsync<List<Activity>>(URL).Result;
                return activities;
            }
        }

        public bool CreateActivity(CreateActivity createActivity)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsJsonAsync(URL, createActivity).Result;
                return response.IsSuccessStatusCode;
            }

        }

    }
}
