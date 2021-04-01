# Repro HotChocolate issue async/await and EF

https://stackoverflow.com/questions/66875998/hotchocolate-resolve-and-async

## Getting started

`cd Demo`
`dotnet watch run`

on `localhost:5001/graphql`

launch request :

```gql
query {
  user(id:1) {
    id
    notesOne {
      id
      note
    }
    notesTwo {
      id
      note
    }
  }
}
```

and experience `System.InvalidOperationException: A second operation was started on this context before a previous operation completed`


## Temporary workaround

Do not use async/await and force sync execution

```csharp
# in UserType.cs

//descriptor.Field("notesOne").UseDbContext<DemoContext>().Resolve(async _ => await GetNotes(_.Parent<User>())).Type(typeof(List<UserNote>));
descriptor.Field("notesOne").UseDbContext<DemoContext>().Resolve(_ => GetNotes(_.Parent<User>()).Result).Type(typeof(List<UserNote>));
```