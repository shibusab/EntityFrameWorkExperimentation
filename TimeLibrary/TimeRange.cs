using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TimeRange
    {
        private DateTime jobStartTime = DateTime.MinValue;
        private DateTime jobEndTime = DateTime.MinValue;
        private List<TimeInterval> timeSlots = new List<TimeInterval>();
        private string message = string.Empty;

        /// <summary>
        /// Constructor with Job/Shift Start and End Time
        /// </summary>
        /// <param name="jobStartTime"></param>
        /// <param name="jobEndTime"></param>
        public TimeRange(string jobStartTime, string jobEndTime)
        {
            DateTime.TryParse(jobStartTime, out this.jobStartTime);
            DateTime.TryParse(jobEndTime, out this.jobEndTime);
        }

        public List<TimeInterval> TimeSlots { get { return timeSlots; } set { timeSlots = value; } }

        public void AddTimeSlot(TimeInterval timeslot)
        {
            timeSlots.Add(timeslot);
        }

        public bool IsTimeSlotOverlapping(TimeInterval timeSlot)
        {
            return GetOverlappingTimeSlots(timeSlot).Any();
        }


        public List<TimeInterval> GetOverlappingTimeSlots(TimeInterval timeSlot)
        {
            var retVal = new List<TimeInterval>();

            if (timeSlot.StartTimeSlot >= jobStartTime && timeSlot.EndTimeSlot <= jobEndTime)
            {
                // check same as start date and end date
                retVal.AddRange(timeSlots.Where(p => (p.StartTimeSlot >= timeSlot.StartTimeSlot && p.EndTimeSlot <= timeSlot.EndTimeSlot)).ToList());
                
                //  check start time slot between in the range
                retVal.AddRange(timeSlots.Where(p => (p.StartTimeSlot >= timeSlot.StartTimeSlot && p.StartTimeSlot <= timeSlot.EndTimeSlot)).ToList());

                //  check end time slot between in the range
                retVal.AddRange(timeSlots.Where(p => (p.EndTimeSlot >= timeSlot.StartTimeSlot && p.EndTimeSlot <= timeSlot.EndTimeSlot)).ToList());
            }
            else
            {
                // does not fall in Job/Shift Time
                message += "Does Not Fall in Time Range";
            }
            //groups, since each category may return overlapping times
            return retVal.GroupBy(x => x.ToString()).Select(y => y.FirstOrDefault()).ToList();
        }

    }
}
