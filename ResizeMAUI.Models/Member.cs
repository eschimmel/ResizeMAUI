using System.Runtime.Serialization;

namespace ResizeMAUI.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte PageLayoutType { get; set; } = Constants.PageLayoutType.Minimal;
    }
}
