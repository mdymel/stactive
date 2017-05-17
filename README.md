# Stactive

|Branch             |Build status                                                  
|-------------------|-----------------------------------------------------
|master             |[![master branch build status](https://api.travis-ci.org/mdymel/stactive.svg?branch=master)](https://travis-ci.org/mdymel/stactive)

## Overview 

Library for ASP.NET Core project which saves user activity, request log and uses Kibana to present the data

**Stactive** is a library for ASP.NET Core, which allows to: 
 
 * keep a request log in a desired database (currently only MongoDb is supported, ElasticSearch and SQL Server are coming next)
 * keep a log of users activity during their sessions (not available yet)
 * create feature usage statistics 

It's very easy to integrate and is built with plugins, so you don't have to bring not needed dependencies. 

When ElasticSearch is implemented it will be very easy to create Dashboards and graphs using Kibana. 

## Installation

**Stactive** is available as nuget packages: 

 * [Stactive](https://www.nuget.org/packages/Stactive/) - main package
 * [Stactive.Persistence.MongoDb](https://www.nuget.org/packages/Stactive.Persistence.MongoDb/) - plugin allows persistance to MongoDb

## How to use

To use Stactive, you have to get the main package (link above) and desired persistance plugin. When it's done, add this code to `ConfigureServices` method of your `Startup` class: 

```csharp
services
    .AddStactive()
    .AddStactiveMongoPersistance(options => 
        options.WithConnectionString(Configuration.GetConnectionString("StactiveMongoDb")));
```

And following code to the `Configure` method: 

```csharp
app.UseStactive();
```

This is all you need to use **Stactive**

## What it does 
Currently, the only implemented functionality is writing a log of requests to MongoDb. This is an example representation of a single request: 

```
{
    "_id" : LUUID("7e701118-3807-a746-963a-7d7f725c1939"),
    "Url" : "/Account/Login",
    "ResponseStatus" : 200,
    "ResponseLength" : null,
    "ProcessingTime" : NumberLong(1017),
    "ContentType" : "text/html; charset=utf-8",
    "Authorized" : false,
    "UserId" : null
}
```
## What's coming 

The main feature of **Stactive** is going to be log of statistical data. You will be able to save events with additional data and then make dashboards or graphs using Kibana interface to ElasticSearch. 

---

Read more at my blog: [https://devblog.dymel.pl/tags/#stactive](https://devblog.dymel.pl/tags/#stactive)