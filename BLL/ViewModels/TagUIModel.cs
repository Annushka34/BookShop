using DAL.Entity;
using System.Collections.Generic;

namespace BLL.ViewModels
{
    public class TagUIModel
    {
        public TagUIModel(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
            Books = new List<BookUIModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookUIModel> Books { get; set; }
    }
}