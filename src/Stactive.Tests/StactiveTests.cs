using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using Xunit;

namespace Stactive.Tests
{
    public class StactiveTests
    {
        const string StactiveEventsKey = "StactiveEvents";

        [Fact]
        public void AddEvent_creates_list_in_context()
        {
            var context = new Mock<HttpContext>();
            var items = new Dictionary<object, object>();
            context.Setup(c => c.Items).Returns(items);
            Stactive.AddEvent(context.Object, null);
            
            items.ShouldContainKey(StactiveEventsKey);
            items[StactiveEventsKey].ShouldNotBeNull();
            items[StactiveEventsKey].ShouldBeOfType<List<StactiveEvent>>();
        }
    }
}