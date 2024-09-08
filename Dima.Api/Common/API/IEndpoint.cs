namespace Dima.Api.Common.API;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
