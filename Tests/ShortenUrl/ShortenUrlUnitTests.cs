using Uxl.Back.ShortenUrl;

namespace Uxl.Tests.ShortenUrl;

public class ShortenUrlUnitTests
{
    [Test]
    public void Should_shorten_url()
    {
        // Arrange
        const string target = "https://bytebytego.com";

        // Act
        var url = new ShortUrl(target);

        // Assert
        url.Id.Should().NotBeEmpty();
        url.Hash.Should().HaveLength(7);
        url.Target.Should().Be(target);
        url.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
    }

    [Test]
    public void Should_not_duplicate_hashes()
    {
        // Arrange
        const string target = "https://bytebytego.com";
        var hashes = new HashSet<string>();
        const int count = 1_000;

        // Act
        for (int i = 0; i < count; i++)
        {
            var url = new ShortUrl(target);
            hashes.Add(url.Hash);
        }

        // Assert
        hashes.Should().HaveCount(count);
    }
}
