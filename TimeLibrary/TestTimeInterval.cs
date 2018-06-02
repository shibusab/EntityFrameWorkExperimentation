using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TestTimeInterval
    {
        private const string newLine = "\n";   //"<br/>";

        public void Check()
        {
            var results = new StringBuilder("TimeIntervalTest ").Append(newLine);
            var timeRange = new TimeRange("05/28/2018 07:00AM", "05/28/2018 08:00AM");
            timeRange.AddTimeSlot(new TimeInterval("05/28/2018 07:05AM", "05/28/2018 07:10AM"));
            timeRange.AddTimeSlot(new TimeInterval("05/28/2018 07:11AM", "05/28/2018 07:20AM"));
            timeRange.AddTimeSlot(new TimeInterval("05/28/2018 07:21AM", "05/28/2018 07:30AM"));
            timeRange.AddTimeSlot(new TimeInterval("05/28/2018 07:31AM", "05/28/2018 07:40AM"));

            foreach (var t in timeRange.TimeSlots)
            {
                results.Append(t.ToString()).Append(newLine);
            }

            var outSideTimeRange = new TimeInterval("05/28/2018 09:01AM", "05/28/2018 09:10AM");
            results.Append(PrintCollection("OutsideTimeRange " + outSideTimeRange.ToString(), timeRange.GetOverlappingTimeSlots(outSideTimeRange)));

            var overlapCase1 = new TimeInterval("05/28/2018 07:00AM", "05/28/2018 07:10AM");
            results.Append(PrintCollection("Overlapping--InRange - Start Time " + overlapCase1.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase1)));

            var overlapCase11 = new TimeInterval("05/28/2018 07:00AM", "05/28/2018 07:05AM");
            results.Append(PrintCollection("IsOverlapping--InRange - At End Time" + overlapCase11.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase11)));

            var overlapCase12 = new TimeInterval("05/28/2018 07:05AM", "05/28/2018 07:08AM");
            results.Append(PrintCollection("IsOverlapping--InRange - At Start Time " + overlapCase12.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase12)));


            var overlapCase3 = new TimeInterval("05/28/2018 07:05AM", "05/28/2018 07:15AM");
            results.Append(PrintCollection("IsOverlapping--Between Time " + overlapCase3.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase3)));

            var overlapCase31 = new TimeInterval("05/28/2018 07:06AM", "05/28/2018 07:15AM");
            results.Append(PrintCollection("IsOverlapping--Between Time " + overlapCase31.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase31)));


            var overlapCase2 = new TimeInterval("05/28/2018 07:35AM", "05/28/2018 07:45AM");
            results.Append(PrintCollection("IsOverlapping--Between Time " + overlapCase2.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase2)));

            var overlapCase4 = new TimeInterval("05/28/2018 07:40AM", "05/28/2018 07:43AM");
            results.Append(PrintCollection("IsOverlapping--Not Overlap " + overlapCase4.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase4)));

            var overlapCase6 = new TimeInterval("05/28/2018 07:00AM", "05/28/2018 07:43AM");
            results.Append(PrintCollection("IsOverlapping--Not Overlap Case 6 " + overlapCase6.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase6)));


            var overlapCase7 = new TimeInterval("05/28/2018 07:00AM", "05/28/2018 07:06AM");
            results.Append(PrintCollection("IsOverlapping--Not Overlap Case 7 " + overlapCase7.ToString(), timeRange.GetOverlappingTimeSlots(overlapCase7)));


            var notOverlapCase1 = new TimeInterval("05/28/2018 07:41AM", "05/28/2018 07:43AM");
            results.Append(PrintCollection("IsOverlapping--Not Overlap " + notOverlapCase1.ToString(), timeRange.GetOverlappingTimeSlots(notOverlapCase1)));

            TestResults = results.ToString();
        }


        public string TestResults
        {
            get; set;
        }

        private string PrintCollection(string testCase, List<TimeInterval> items)
        {
            var retVal = testCase + "Returned " + items.Count + newLine;
            foreach (var item in items)
            {
                retVal += item.ToString() + newLine;
            }
            return retVal;
        }
    }
}
