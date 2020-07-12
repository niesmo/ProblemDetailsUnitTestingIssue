# ProblemDetailsUnitTestingIssue


### Running the project
```powershell
dotnet run --project ./WebApi/WebApi.csproj
```
Once the solution is running, open a browser to go to [http://localhost:5000/weatherforecast](http://localhost:5000/weatherforecast)  
To see the ProblemDetail response in action, go to [http://localhost:5000/weatherforecast?numberOfDays=-1](http://localhost:5000/weatherforecast?numberOfDays=-1)

### Running the test
```powershell
dotnet test
```

### Exception Detail
```
Message:
  System.NullReferenceException : Object reference not set to an instance of an object.
Stack Trace:
  ControllerBase.Problem(String detail, String instance, Nullable`1 statusCode, String title, String type)
  WeatherForecastController.GetWeatherForecast(Int32 numberOfDays) line 35
  WeatherForecastUnitTests.WeatherForecastHandlesExceptions() line 35
```




