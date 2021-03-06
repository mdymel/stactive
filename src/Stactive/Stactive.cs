﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Stactive.Core;
using Stactive.Core.Models;

namespace Stactive
{
    public static class Stactive
    {
        public const string StactiveEventsKey = "StactiveEvents";

        public static void AddEvent(HttpContext context, StactiveEvent stactiveEvent)
        {
            if (!context.Items.ContainsKey(StactiveEventsKey))
            {
                context.Items[StactiveEventsKey] = new List<StactiveEvent>();
            }
            var list = context.Items[StactiveEventsKey] as List<StactiveEvent>;
            if (list is null) throw new StactiveException("Stactive events is not a List<StactiveEvent>");
            list.Add(stactiveEvent);
        }
    }
}