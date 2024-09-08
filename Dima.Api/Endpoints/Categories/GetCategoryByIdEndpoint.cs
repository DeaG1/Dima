using Dima.Api.Common.API;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
              .WithName("Categories : Get By Id")
              .WithSummary("Recupera uma categoria")
              .WithDescription("Recupera uma categoria")
              .WithOrder(4)
              .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        [FromServices]ICategoryHandler handler,
        [FromBody]GetCategoryByIdRequest request,
        long id)
    {
        request.Id = id;

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess
            ? Results.Ok(result.Data)
            : Results.BadRequest(result.Data);
    }
}
