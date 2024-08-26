namespace FsharpTodoApi.Handler

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Http
// open FSharpPlus.Lens


module GetBlogsHandler =
    let handler: Task<IResult> =
        async {
            let blogs =
                [ { Id = 1
                    Title = "Blog 1"
                    Content = "Content 1" }
                  { Id = 2
                    Title = "Blog 2"
                    Content = "Content 2" }
                  { Id = 3
                    Title = "Blog 3"
                    Content = "Content 3" } ]

            return Ok blogs
        }
        |> Async.StartAsTask
