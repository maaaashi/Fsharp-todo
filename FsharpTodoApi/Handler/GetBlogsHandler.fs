namespace FsharpTodoApi.Handler

open System.Threading.Tasks
open FsharpTodoApi.Domain

type BlogJson =
    { id: string
      title: string
      body: string }

type BlogsJson =
    { blogs: BlogJson list }


type GetBlogsHandlerResult =
    | Ok of BlogsJson
    | Error of string

module GetBlogsHandler =
    let private toResponseJson (blogs: Blogs) : BlogsJson =
        { blogs = [] }

    let handler: Task<GetBlogsHandlerResult> =
        async {
            let article: Article =
              { id = ArticleId "blog_1"
                title = ArticleTitle "タイトル1"
                body = ArticleBody "本文1" }
            let author: Author =
                { id = UserId "user_1"
                  name = UserName "ユーザー1" }

            return toResponseJson (Blogs [ Blog (article, author)]) |> Ok
        }
        |> Async.StartAsTask
