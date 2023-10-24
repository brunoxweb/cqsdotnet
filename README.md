# CQSDotnet Library
CQSDotnet is a Command Query Separation (CQS) framework for the .NET platform. It allows you to easily implement the CQS pattern in your .NET applications, providing a clean and organized way to manage commands and queries.

## Installation
To get started with CQSDotnet, you can install it via NuGet Package Manager:

`dotnet add package CQSDotnet`

## Usage
Using CQSDotnet is straightforward. You can create and execute queries and commands using the provided dispatcher.

## Query Execution
```
var query = new MyQuery();
var result = await dispatcher.ExecuteAsync<MyQuery, string>(query);
```
## Command Execution
```
var command = new MyCommand();
await dispatcher.ExecuteAsync(command);
```

## Example

```
private readonly IQueryDispatcher queryDispatcher;
private readonly ICommandDispatcher commandDispatcher;

public ExampleController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
{
    this.queryDispatcher = queryDispatcher;
    this.commandDispatcher = commandDispatcher;
}

[HttpGet]
public async Task<IHttpActionResult> GetAsync()
{
    var query = new MyQuery();
    var response = await this.queryDispatcher
        .ExecuteAsync<MyQuery, IEnumerable<MyDto>>(query, CancellationToken.None);
    return Ok(response);
}

[HttpPost]
public async Task<IHttpActionResult> PostAsync()
{
    var command = new MyCommand();
    await this.commandDispatcher.ExecuteAsync<MyCommand>(command, CancellationToken.None);
    return Ok();
}

// Implement your queries and commands
public class MyQuery : IQuery<IEnumerable<MyDto>> { }
public class MyQueryHandler : IQueryHandler<MyQuery, IEnumerable<MyDto>> { }
public class MyCommand : ICommand { }
public class MyCommandHandler : ICommandHandler<MyCommand> { }
```

## Usage with AutoFac

`dotnet add package CQSDotnet.Autofac`

More info: https://www.nuget.org/packages/CQSDotnet.Autofac/

## Usage with AspnetCore

`dotnet add package CQSDotnet.AspnetCore`

More info: https://www.nuget.org/packages/CQSDotnet.AspnetCore/

## Contributing
If you want to contribute to this project or report issues, please check the GitHub repository.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
