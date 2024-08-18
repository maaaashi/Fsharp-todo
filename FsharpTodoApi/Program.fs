open System

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    let app = builder.Build()

    app.MapGet("/v1/systems/ping", Func<IResult>(fun () -> Results.Ok("pong")))
    |> ignore

    app.Run()

    0
