# About

Here there are two columns of type time(7) which map to TimeSpan. Currently these two columns can not be mapped in EF Core to TimeOnly. There are two readonly properties that convert the two TimeSpan columns to TimeOnly.

Looks like EF Core 6 will support TimeOnly.