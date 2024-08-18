open System
open System.IO
open System.Data.Common
open System.Threading.Tasks
open System.Text.Json.Serialization

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.HttpLogging
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection


[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddHttpLogging(fun logger -> logger.LoggingFields <- HttpLoggingFields.All)
    |> ignore

    let app = builder.Build()

    app.MapGet("/v1/systems/ping", Func<IResult>(fun () -> Results.Ok("pong")))
    |> ignore

    let blogsGroup = app.MapGroup("/v1/blogs")

    blogsGroup.MapGet(
        "",
        Func<HttpRequest, IResult>(fun req ->
            let blogs =
                [| {| Id = 1
                      Title = "First blog"
                      Content = "This is the first blog"
                      CreatedAt = DateTime.Now |}
                   {| Id = 2
                      Title = "Second blog"
                      Content = "This is the second blog"
                      CreatedAt = DateTime.Now |} |]

            Results.Ok(blogs))
    )
    |> ignore

    app.Run()

    0
