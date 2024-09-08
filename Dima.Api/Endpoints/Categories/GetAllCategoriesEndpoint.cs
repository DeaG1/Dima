using Dima.Api.Common.API;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
              .WithName("Categories : Get ALl")
              .WithSummary("Recupera todas as categorias")
              .WithDescription("Recupera todas as categorias")
              .WithOrder(5)
              .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        [FromServices]ICategoryHandler handler,
        [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery]int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequests()
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
            ? Results.Ok(result.Data)
            : Results.BadRequest(result.Data);
    }
}
