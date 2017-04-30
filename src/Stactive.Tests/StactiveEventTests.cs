using System;
using Shouldly;
using Stactive.Core;
using Stactive.Core.Models;
using Xunit;
// ReSharper disable ObjectCreationAsStatement

namespace Stactive.Tests
{
    public class StactiveEventTests
    {
        [Fact]
        public void StactiveEvent_constructor_sets_id_to_guid()
        {
            var stactiveEvent = new StactiveEvent("asd");
            stactiveEvent.Id.ShouldNotBeNull();
            stactiveEvent.Id.ShouldNotBe(new Guid());
        }

        [Fact]
        public void StactiveEvent_constructor_sets_datetime()
        {
            var stactiveEvent = new StactiveEvent("asd");
            stactiveEvent.DateTime.ShouldNotBe(new DateTime());
            stactiveEvent.DateTime.Kind.ShouldBe(DateTimeKind.Utc);
        }

        [Fact]
        public void StactiveEvent_constructor_sets_name()
        {
            var stactiveEvent = new StactiveEvent("asd");
            stactiveEvent.Name.ShouldBe("asd");
        }

        [Fact]
        public void StactiveEvent_constructor_throws_if_name_is_null()
        {
            var ex = Should.Throw<StactiveException>(() => new StactiveEvent(null));
            ex.Message.ShouldBe("StactiveEvent Name can not be null or empty");
        }

        [Fact]
        public void StactiveEvent_constructor_throws_if_name_is_empty()
        {
            var ex = Should.Throw<StactiveException>(() => new StactiveEvent(string.Empty));
            ex.Message.ShouldBe("StactiveEvent Name can not be null or empty");
        }
    }
}