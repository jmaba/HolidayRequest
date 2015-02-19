namespace Domain.Entities
{
    public class HolidayRequest
    {
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public HolidayInterval Interval { get; set; }
        public HolidayState State { get; set; }

        //TODO Extract message subjects & body to somewhere else
        public NotificationMessage GetSubmittedMessage()
        {
            return new NotificationMessage(
                Employee.EmailAddress,
                Employee.Manager.EmailAddress,
                "Holiday request",
                string.Format("Please approve my holiday request for the period  {0} - {1}", Interval.StartDate,
                    Interval.EndDate));
        }

        public NotificationMessage GetRejectMessage()
        {
            return new NotificationMessage(
                    Employee.Manager.EmailAddress,
                    Employee.EmailAddress,
                    "Request has been rejected",
                    string.Format("Your holiday request for the period {0} - {1} has been rejected", Interval.StartDate, Interval.EndDate));
        }

        public NotificationMessage GetApprovedMessage()
        {
            return new NotificationMessage(
                    Employee.Manager.EmailAddress,
                    "Hr@hr.com",
                    "Request has been approved",
                    string.Format("Your holiday request for the period {0} - {1} has been approved", Interval.StartDate, Interval.EndDate)); ;
        }
    }
}