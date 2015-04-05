namespace DataAccess.Models
{
    public class Advertisment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Type { get; set; }
        public string ExtraFields { get; set; }

        public Advertisment(int Id, int UserId, string Title, string Description, string Picture, int Type, string ExtraFields)
        {
            this.UserId = UserId;
            this.Title = Title;
            this.Description = Description;
            this.Picture = Picture;
            this.Type = Type;
            this.ExtraFields = ExtraFields;
            this.Id = Id;
        }

        public Advertisment(int UserId, string Title, string Description, string Picture, int Type, string ExtraFields)
        {
            this.UserId = UserId;
            this.Title = Title;
            this.Description = Description;
            this.Picture = Picture;
            this.Type = Type;
            this.ExtraFields = ExtraFields;
        }

        public Advertisment()
        {
        }
    }
}
