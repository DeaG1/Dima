using Dima.Api.Common.API;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Dima.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("{id}", HandleAsync)
              .WithName("Categories : Update")
              .WithSummary("Atualiza uma categoria")
              .WithDescription("Atualiza uma categoria")
              .WithOrder(2)
              .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(
        [FromServices]ICategoryHandler handler,
        [FromBody]UpdateCategoryRequest request,
        long id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
            ? Results.Ok(result.Data)
            : Results.BadRequest(result.Data);
    }
}
