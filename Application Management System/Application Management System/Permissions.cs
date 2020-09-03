using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Management_System
{
    class Permissions
    {
        String approved, deluser, deldev, blkdev;

        public String getApproved()
        {
            return approved;
        }

        public void setApproved(String approved)
        {
            this.approved = approved;
        }

        public String getDeluser()
        {
            return deluser;
        }

        public void setDeluser(String deluser)
        {
            this.deluser = deluser;
        }

        public String getDeldev()
        {
            return deldev;
        }

        public void setDeldev(String deldev)
        {
            this.deldev = deldev;
        }

        public String getBlkdev()
        {
            return blkdev;
        }

        public void setBlkdev(String blkdev)
        {
            this.blkdev = blkdev;
        }

        ~Permissions()
        {

        }
    }
}
