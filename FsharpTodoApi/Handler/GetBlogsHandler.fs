namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open Microsoft.AspNetCore.Http
open FsharpTodoApi.Domain

module GetBlogsHandler =
    let handler: Task<IResult> =
        async {
            let blogs =
                Blog [{
                  id = ""
                }]

            return Ok blogs
        }
        |> Async.StartAsTask
