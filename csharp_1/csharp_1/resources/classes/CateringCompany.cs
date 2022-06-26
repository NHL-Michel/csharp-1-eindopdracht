using System;
using System.Collections.Generic;

namespace csharp_1.resources.classes
{
    class CateringCompany
    {
        private String name;
        private List<Assignment> assigntments;

        public CateringCompany(String name)
        {
            this.name = name;
            this.assigntments = new List<Assignment>();
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

        public void addAssignment(Assignment assignment)
        {
            this.assigntments.Add(assignment);
        }
    }
}
