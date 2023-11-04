using FluentAssertions;
using PersonalHelpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace PersonalHelpers.Tests.Extensions;

public class EnumExtensionsTests
{
    private const string DESCRIPTION_TEXT = "Desc";
    private readonly ITestOutputHelper _output;

    public EnumExtensionsTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GetDescription_NullValue_Null()
    {
        Description? desc = null;

        var descVal = desc.GetDescription();

        descVal.Should()
            .BeNull();
    }

    [Fact]
    public void GetDescription_NoDescription_Null()
    {
        Descriptionless desc = Descriptionless.Field;

        var descVal = desc.GetDescription();

        descVal.Should()
            .BeNull();
    }

    [Fact]
    public void GetDescription_HasDescriptions_DescriptionValue()
    {
        Description desc = Description.Field;

        var descVal = desc.GetDescription();

        descVal.Should()
            .Be(DESCRIPTION_TEXT);
    }

    [Fact]
    public void GetDescriptionElseName_NullValue_Empty()
    {
        Description? desc = null;

        var descVal = desc.GetDescriptionElseName();

        descVal.Should()
            .BeEmpty();
    }

    [Fact]
    public void GetDescriptionElseName_NoDescription_Name()
    {
        Descriptionless desc = Descriptionless.Field;

        var descVal = desc.GetDescriptionElseName();

        descVal.Should()
            .Be(nameof(Descriptionless.Field));
    }

    [Fact]
    public void GetDescriptionElseName_HasDescriptions_DescriptionValue()
    {
        Description desc = Description.Field;

        var descVal = desc.GetDescriptionElseName();

        descVal.Should()
            .Be(DESCRIPTION_TEXT);
    }

    enum Descriptionless
    {
        Field
    }
    
    enum Description
    {
        [Description(DESCRIPTION_TEXT)]
        Field
    }
}
