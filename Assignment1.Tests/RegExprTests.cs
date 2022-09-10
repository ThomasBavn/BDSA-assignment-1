namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_Given_Stream_Of_Lines_Returns_Stream_Of_Words()
    {
        // Arrange
        var lines = new[] { "Hej", "med", "dig", "jeg hedder Bob!", "Jeg er 55 år." };

        var words = new[] { "Hej", "med", "dig", "jeg", "hedder", "Bob", "Jeg", "er", "55", "år" };

        // Act
        var actual = RegExpr.SplitLine(lines);

        // Assert
        Assert.Equal(words, actual);
    }

    [Fact]
    public void SplitLine_Given_Empty_Stream_Returns_Empty_Stream()
    {
        // Arrange
        var lines = Array.Empty<string>();

        var words = Array.Empty<string>();

        // Act
        var actual = RegExpr.SplitLine(lines);

        // Assert
        Assert.Equal(words, actual);
    }

    [Fact]
    public void Resolution_Given_String_Of_Resolutions_Returns_Stream_Of_Resolutions()
    {
        // Arrange
        var input = "1920x1080, 1024x768, 800x600, 640x480, 320x200, 320x240, 800x600, 1280x960";

        var expected = new[] { (1920, 1080), (1024, 768), (800, 600), (640, 480), (320, 200), (320, 240), (800, 600), (1280, 960) };

        // Act
        var actual = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Resolution_Given_Empty_String_Of_Resolutions_Returns_Empty_Stream_Of_Resolutions()
    {
        // Arrange
        var input = "";

        var expected = Array.Empty<(int width, int height)>();

        // Act
        var actual = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InnerText_Given_String_Of_Html_And_Tag_Returns_Strings_In_Tag()
    {
        // Arrange
        var input = @"<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p></div>";

        var expected = new [] { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" }; 

        // Act
        var actual = RegExpr.InnerText(input, "a");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InnerText_Given_String_Of_Html_And_Nested_Tag_Returns_String_In_Tag()
    {
        // Arrange
        var input = @"<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";

        var expected = new [] { "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to." };

        // Act
        var actual = RegExpr.InnerText(input, "p");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Urls_Given_String_Of_Html_Returns_Urls_And_Titles()
    {
        // Arrange
        var input = @"<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p></div>";

        var expected = new [] { (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"), (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"), (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"), (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"), (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)") };

        // Act
        var actual = RegExpr.Urls(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}