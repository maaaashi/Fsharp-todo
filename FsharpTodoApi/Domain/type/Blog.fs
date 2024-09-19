namespace FsharpTodoApi.Domain

type ArticleId = ArticleId of string
type ArticleTitle = ArticleTitle of string
type ArticleBody = ArticleBody of string

[<RequireQualifiedAccess>]
type Article =
    { id: ArticleId
      title: ArticleTitle
      body: ArticleBody }

type UserId = UserId of string
type UserName = UserName of string

[<RequireQualifiedAccess>]
type Author =
    { id: UserId
      name: UserName }

[<RequireQualifiedAccess>]
type Blog = Article * Author

[<RequireQualifiedAccess>]
type Blogs = Blogs of Blog list