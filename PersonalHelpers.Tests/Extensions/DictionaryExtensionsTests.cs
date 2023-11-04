using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PersonalHelpers.Enums;
using Xunit.Abstractions;

namespace PersonalHelpers.Tests.Extensions;

public class DictionaryExtensionsTests
{
    private readonly ITestOutputHelper _output;

    public DictionaryExtensionsTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Foreach_ActionParams_NotThrow()
    {
        Dictionary<int, string> dict = new()
        {
            { 1, "Hello" },
            { 2, "World" },
        };
        var action = () => dict.ForEach((key, value) => _output.WriteLine(value));
        action.Should()
            .NotThrow();
    }

    [Fact]
    public void Foreach_ActionKeyValue_NotThrow()
    {
        Dictionary<int, string> dict = new()
        {
            { 1, "Hello" },
            { 2, "World" },
        };
        var action = () => dict.ForEach(kv => _output.WriteLine(kv.value));
        action.Should()
            .NotThrow();
    }

    // To be aware of, is this correct behaviour?
    [Fact]
    public void Foreach_ActionChangeValue_ShouldChangeIfRef()
    {
        var text = "OtherText";
        Dictionary<int, Stuff> dict = new()
        {
            { 1, new Stuff() { Property = "Hello" } },
            { 2, new Stuff() { Property = "World" } },
        };

        dict.ForEach((key, value) => value.Property = text);

        dict[1].Property
            .Should()
            .Be(text);
        dict[2].Property
            .Should()
            .Be(text);
    }
    private class Stuff
    {
        public string? Property { get; set; }
    }

    [Fact]
    public void Foreach_ActionsParams_NotThrow()
    {
        Dictionary<int, string> dict = new()
        {
            { 1, "Hello" },
            { 2, "World" },
        };

        var action = () => dict.ForEach(k => _output.WriteLine(k.ToString()), v => _output.WriteLine(v));
        action.Should()
            .NotThrow();
    }

    [Fact]
    public void Foreach_ActionsNullSecondParam_NotThrow()
    {
        Dictionary<int, string> dict = new()
        {
            { 1, "Hello" },
            { 2, "World" },
        };

        var action = () => dict.ForEach(k => _output.WriteLine(k.ToString()), null);
        action.Should()
            .NotThrow();
    }

    [Fact]
    public void Foreach_ActionsNullFirstParam_NotThrow()
    {
        Dictionary<int, string> dict = new()
        {
            { 1, "Hello" },
            { 2, "World" },
        };

        var action = () => dict.ForEach(null, k => _output.WriteLine(k.ToString()));
        action.Should()
            .NotThrow();
    }
}
