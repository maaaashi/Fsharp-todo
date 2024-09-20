open System

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.HttpLogging
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

open System.Threading.Tasks
open FsharpTodoApi.Handler

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddHttpLogging(fun logger -> logger.LoggingFields <- HttpLoggingFields.All)
    |> ignore

    let app = builder.Build()

    app.MapGet("/v1/systems/ping", Func<IResult>(fun () -> Results.Ok("pong")))
    |> ignore

    let blogsGroup = app.MapGroup("/v1/blogs")

    blogsGroup.MapGet("", Func<Task<GetBlogsHandlerResult>>(fun _ -> GetBlogsHandler.handler))
    |> ignore

    app.Run()

    0
