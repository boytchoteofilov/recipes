namespace Yummy.Data.Models
{
    using Yummy.Data.Common.Models;

    public class Vote : BaseDeletableModel<int>
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
