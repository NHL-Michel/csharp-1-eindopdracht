using System;

namespace csharp_1.resources.classes
{
    class Assignment
    {
        private String name;
        private DateTime startDate;
        private DateTime endDate;

        public Assignment (String name, DateTime startDate, DateTime endDate)
        {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.name = value;
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set 
            {
                this.startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }
    }
}
