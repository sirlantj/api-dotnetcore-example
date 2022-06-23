using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Mrv.Domain.Core.Events;

namespace Mrv.Application.EventSourcedNormalizers
{
    public static class LeadsHistory
    {
        public static IList<LeadsHistoryData> HistoryData { get; set; }

        public static IList<LeadsHistoryData> ToJavaScriptLeadsHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<LeadsHistoryData>();
            LeadsHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<LeadsHistoryData>();
            var last = new LeadsHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new LeadsHistoryData
                {
                    Id = change.Id,
                    Suburb = string.IsNullOrWhiteSpace(change.Suburb) || change.Suburb == last.Suburb
                        ? ""
                        : change.Suburb,
                    Price = change.Price,
                    Status = change.Status,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void LeadsHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<LeadsHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "LeadsRegisteredEvent":
                        historyData.Action = "Registered";
                        break;
                    case "LeadsUpdatedEvent":
                        historyData.Action = "Updated";
                        break;
                    case "LeadsRemovedEvent":
                        historyData.Action = "Removed";
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        break;

                }
                HistoryData.Add(historyData);
            }
        }
    }
}