using System;
using System.Text.Json.Serialization;

namespace CourseTask.Src.Models
{
	public class CourseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<UserModel> Users { get; set; } 
    }
}

