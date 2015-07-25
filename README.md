# Cambridge.Talks

A .NET library for accessing talks.cam.ac.uk

## Usage

Add the library as a reference to your project and import the `Cambridge.Talks` namespace. To load upcoming talks in a feed, simply use the `Feed.Load` method with the unique ID of the feed. If the request is successful, the `Talks` property of the feed will contain all talks that have been loaded.

```C#
Feed feed = Feed.Load(6330);

foreach (Talk talk in feed.Talks)
{
    Console.WriteLine("[{0}] {1} ({2})", talk.StartTime, talk.Title, talk.Speaker);
}
```

The `Feed.Load` method supports some optional arguments which can be used to customise which talks are requested. For example, to load the 10 most recent talks in reverse order:

```C#
Feed feed = Feed.Load(6330, limit: 10, endTime: DateTime.Now, reverseOrder: true);
```

The arguments correspond to those documented on the [talks.cam](http://talks.cam.ac.uk/document/specification) website. XML documentation is also provided for all arguments.