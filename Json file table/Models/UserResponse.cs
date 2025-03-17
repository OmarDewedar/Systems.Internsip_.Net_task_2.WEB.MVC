using Newtonsoft.Json;

namespace Systems.Internship_.Net_task_2.WEB.MVC.Models
{
    public class UserResponse
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        internal static void Add(User user)
        {
            throw new NotImplementedException();
        }
    }
}
