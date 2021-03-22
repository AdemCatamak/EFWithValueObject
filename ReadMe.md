# Value Objects and Their Usage with Entity Framework

This project has been prepared to set an example for designing _Value Objects_ and using them with _Entity Framework_.

You can access the article referencing this project
on [Medium](https://medium.com/@ademcatamak/value-objects-and-their-usage-with-entity-framework-a434f1414103).

[Medium](https://medium.com/@ademcatamak/deger-objeleri-ve-entity-framework-ile-kullanimi-4e090b18d029) aracılığıyla bu
projeyi referans alan yazıma ulaşabilirsiniz.

## __RUN__

In order for the code to work, there must be a Sql Server that it can connect to with the following connection string.

`Server=localhost,1433;Database=ValueObjectSampleDb;User=sa;Password=Passw0rd;Trusted_Connection=False;`

If you have a Sql Server, you can test the code by putting its connection string in appsettings.json file. When code
connects to Sql Server, it generates required database tables and schemas.