namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open FsharpTodoApi.Domain

type IResult =
    | Ok of Blogs
    | Error of string

module GetBlogsHandler =
    let handler: Task<IResult> =
        async {
            let article =
              { id = ArticleId "blog_1"
                title = ArticleTitle "タイトル1"
                body = ArticleBody "本文1" }
            let author =
                { id = UserId "user_1"
                  name = UserName "ユーザー1" }

            let blog = Blog (article, author)

            return Ok (Blogs [blog])
        }
        |> Async.StartAsTask
