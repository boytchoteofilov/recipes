namespace MoiteRecepti.Services.Data
{
    using MoiteRecepti.Services.Data.DTOs;
    using MoiteRecepti.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        // 1. Use View Model (need to refer the project containing them)
        ServiceViewModel GetCounts();

        // 2. Use DTO (no need to refer the view model project)
        CountsDTO GetCountsFromDTO();
    }
}
