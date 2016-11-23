using System.Linq;

namespace Working.Models
{
    public static class WorkingExtendsions
    {
        public static void EnsureSeedData(this WorkingContext context) 
        {
            if(!context.Friends.Any())
            {
                context.Friends.AddRange(
                    new Friend {Name = "Emily"},
                    new Friend {Name = "Joanna"},
                    new Friend {Name = "Miles"},
                    new Friend {Name = "Derrida"}
                );

                context.SaveChanges();
            }
        }
    }
}