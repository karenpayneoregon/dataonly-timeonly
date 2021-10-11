# .NET 6 code sample for VS2019 C#

This repository demonstrates simple usage of [DateOnly Struct](https://docs.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-6.0) done with a prerelease product along with other methods e.g. MaxBy/MinBy.

![img](assets/CloneOrFork.png)

There is a [class project](https://github.com/karenpayneoregon/dataonly-timeonly/blob/master/FileLibrary/Classes/Operations.cs) which is responsible for reading a json file with type Person class into a list using [System.Text.Json. JsonSerializer.Deserialize](https://docs.microsoft.com/en-us/dotnet/api/system.text.json?view=net-5.0). In the unit test project this data is tested as instances of the Person class.

## Extension

To convert a DateOnly variable to a DateTime we use ToDateTime which requires a TimeOnly so to keep code light here is a lazy [extension](https://github.com/karenpayneoregon/dataonly-timeonly/blob/master/FileLibrary/LanguageExtensions/DateOnlyExtensions.cs) which default to mid-night or allows changing hours and/or minutes.

```charp
public static DateTime ToDateTime(this DateOnly sender, int hour = 0, int minutes = 0)
    => sender.ToDateTime(new TimeOnly(hour, minutes));

public static DateOnly ToDateOnly(this DateTime? sender) 
    => new (sender.Value.Year, sender.Value.Month, sender.Value.Day);
```

## Helpers

```csharp
public static IEnumerable<TSource> Prepend<TSource>(this List<TSource> sender, TSource item) 
    where TSource : new() => Enumerable.Prepend(sender, item);
```

```csharp
public static IEnumerable<Age> Ages(this List<Person> sender) => 
    sender.Select(person => person.BirthDateAsDateTime.Age(DateTime.Now));
```


## Remarks

- To use DateOnly and TimeOnly install [SDK 6x](https://dotnet.microsoft.com/download/dotnet/6.0?WT.mc_id=DT-MVP-5002866)
- If using `VS2019` for desktop projects
  - Set Use previews as shown in the image below
  - Set `TargetFramework` to `net6.0-windows`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
	  <LangVersion>9.0</LangVersion>
	  <TargetFramework>net6.0-windows</TargetFramework>
  </PropertyGroup>

</Project>
```

Or use this for the project file

```xml
<Project Sdk="Microsoft.NET.Sdk">
	<PropertyGroup>
          <EnablePreviewFeatures>true</EnablePreviewFeatures>
          <LangVersion>preview</LangVersion>
          <OutputType>Exe</OutputType>
          <TargetFramework>net6.0</TargetFramework>
	</PropertyGroup>

	<ItemGroup>
           <PackageReference Include="System.Runtime.Experimental" Version="6.0.0-preview.7.21377.19" />
	</ItemGroup>
</Project>
```


- Currently no code samples for [TimeOnly](https://docs.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-6.0) which will follow shortly.

## See also

- [Developers can benefit from enhanced Date and Time types and Timezone support](https://github.com/dotnet/runtime/issues/45318)
- NodaTime [ZonedDateTime](https://nodatime.org/2.4.x/api/NodaTime.ZonedDateTime.html)


![img](assets/figure1.png)