namespace LinkDirection.Models;

public class LinkDefinitions
{
    public List<SlugInfo> Slugs { get; set; }
}

public class SlugInfo
{
    public string Slug { get; set; }
    public string DefaultUrl { get; set; }
    public Dictionary<string, string> RegionUrls { get; set; }
}
