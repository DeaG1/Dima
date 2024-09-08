using Dima.Api.Common.API;
using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    #region Public Function
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("", HandleAsync)
              .WithName("Categories : Create")
              .WithSummary("Cria uma nova categoria")
              .WithDescription("Cria uma nova categoria")
              .WithOrder(1);

    #endregion

    #region Private Function
    private static async Task<IResult> HandleAsync(
        [FromServices]ICategoryHandler handler,
        [FromBody]CreateCategoryRequest request)
    {
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"{result.Data?.Id}", result.Data)
            : TypedResults.BadRequest(result.Data);
    }

    #endregion
}
