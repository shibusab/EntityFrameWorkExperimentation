using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public class TimeInterval
    {
        private DateTime slotStartTime = DateTime.MinValue;
        private DateTime slotEndTime = DateTime.MinValue;

        /// <summary>
        /// Constructor with Start Time and End Time
        /// </summary>
        /// <param name="slotStartTime"></param>
        /// <param name="slotEndTime"></param>
        public TimeInterval(string slotStartTime, string slotEndTime)
        {
            DateTime.TryParse(slotStartTime, out this.slotStartTime);
            DateTime.TryParse(slotEndTime, out this.slotEndTime);
        }
        public DateTime StartTimeSlot { get { return slotStartTime; } set { slotStartTime = value; } }
        public DateTime EndTimeSlot { get { return slotEndTime; } set { slotEndTime = value; } }

        /// <summary>
        /// Overide To String to show time
        /// If time is on same date, show MM/dd/yyyy HH:mm tt - HH:mm tt
        /// When on different dates, shows MM/dd/yyyy HH:mm tt - MM/dd/yyyy HH:mm tt 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var retVal = string.Empty;
            var dateFormat = "MM/dd/yyyy HH:mm tt";
            var sameDateFormat = "HH:mm tt";
            //if time is on same date
            if (slotStartTime.ToString("yyyyMMdd").Equals(slotEndTime.ToString("yyyyMMdd")))
            {
                retVal = string.Format("{0} -{1}", slotStartTime.ToString(dateFormat), slotEndTime.ToString(sameDateFormat));
            }
            else
            {
                retVal = string.Format("{0} -{1}", slotStartTime.ToString(dateFormat), slotEndTime.ToString(dateFormat));
            }
            return retVal;
        }
    }
}
