using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Stactive
{
    public static class Stactive
    {
        const string StactiveEventsKey = "StactiveEvents";

        public static void AddEvent(HttpContext context, StactiveEvent stactiveEvent)
        {
            if (!context.Items.ContainsKey(StactiveEventsKey))
            {
                context.Items[StactiveEventsKey] = new List<StactiveEvent>();
            }
        }
    }
}