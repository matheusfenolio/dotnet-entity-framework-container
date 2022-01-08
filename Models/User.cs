namespace dotnet_six.Models {
    public class User {
        public string id { get;set; } = Guid.NewGuid().ToString();
        public string name { get;set; } = default!;
        public string email { get;set; } = default!;
    }
}