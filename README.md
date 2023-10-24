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
## Contributing
If you want to contribute to this project or report issues, please check the GitHub repository.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
