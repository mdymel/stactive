using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using Xunit;

namespace Stactive.Tests
{
    public class StactiveTests
    {
        private static HttpContext CreateHttpContext()
        {
            var context = new Mock<HttpContext>();
            var items = new Dictionary<object, object>();
            context.Setup(c => c.Items).Returns(items);
            return context.Object;
        }

        [Fact]
        public void AddEvent_creates_list_in_context()
        {
            var context = CreateHttpContext();
            Stactive.AddEvent(context, null);

            context.Items.ShouldContainKey(Stactive.StactiveEventsKey);
            context.Items[Stactive.StactiveEventsKey].ShouldNotBeNull();
            context.Items[Stactive.StactiveEventsKey].ShouldBeOfType<List<StactiveEvent>>();
        }

        [Fact]
        public void AddEvent_adds_event_to_the_list()
        {
            var stactiveEvent = new StactiveEvent("asd");
            var context = CreateHttpContext();
            Stactive.AddEvent(context, stactiveEvent);

            var eventsList = context.Items[Stactive.StactiveEventsKey] as List<StactiveEvent>;
            eventsList.ShouldContain(stactiveEvent);
        }

        [Fact]
        public void AddEvent_throws_if_items_is_not_a_list()
        {
            var context = CreateHttpContext();
            context.Items[Stactive.StactiveEventsKey] = "";
            var ex = Should.Throw<StactiveException>(() => Stactive.AddEvent(context, null));
            ex.Message.ShouldBe("Stactive events is not a List<StactiveEvent>");
        }
    }
}