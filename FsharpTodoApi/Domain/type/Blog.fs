namespace FsharpTodoApi.Domain

type ArticleId = ArticleId of string
type ArticleTitle = ArticleTitle of string
type ArticleBody = ArticleBody of string

type Article =
    { id: ArticleId
      title: ArticleTitle
      body: ArticleBody }

type UserId = UserId of string
type UserName = UserName of string

type Author =
    { id: UserId
      name: UserName }

type Blog = Article * Author

type Blogs = Blogs of Blog list