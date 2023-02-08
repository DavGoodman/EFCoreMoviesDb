using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMovies.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }

            set
            {   // tOm hOLLand => Tom Holland
                _name = string.Join(' ',
                    value.Split(' ')
                        .Select(n => n[0].ToString().ToUpper() + n.Substring(1).ToLower()).ToArray());
            }
        }
        public string Biography { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime? DateOfBirth { get; set; }
        public List<MovieActor> MoviesActors { get; set; }

    }
}
