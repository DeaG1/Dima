using Dima.Api.Common.API;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("{id}", HandleAsync)
              .WithName("Categories : Delete")
              .WithSummary("Deletar uma categoria")
              .WithDescription("Deletar uma categoria")
              .WithOrder(3)
              .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        [FromServices]ICategoryHandler handler,
        [FromBody]DeleteCategoryRequest request,
        long id)
    {
        request.Id = id;

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
            ? Results.Ok(result.Data)
            : Results.BadRequest(result.Data);
    }
}
