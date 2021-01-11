namespace Yummy.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class VoteInputModel
    {
        public int RecipeId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
