using System;
using System.Collections.Generic;

#nullable disable

namespace CharityApp.TestModels
{
    public partial class Action
    {
        public Action()
        {
            BranchesRefs = new HashSet<BranchesRef>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BranchesRef> BranchesRefs { get; set; }
    }
}
