using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar_Management_System.Classes;
using Seminar_Management_System;
using System.Windows.Forms;

namespace Seminar_Management_System
{
    class InterfaceUnlocker
    {
        public void Watch()
        {
            DataInstance.LoggedInUserChanged += DataInstance_LoggedInUserChanged;
        }

        private TabPage Backup_UserList;
        private void DataInstance_LoggedInUserChanged(object sender, EventArgs e)
        {
            int priv = DataInstance.LoggedInUser.Privilege;

            if (priv >= Authentication.GetPrivilegeFromRoleName(Role.Names.Admin))
            {
                // Add user list page if its not there
                if (!DataInstance.mainInstance.tabControl.TabPages.Contains(DataInstance.mainInstance.tabPage2))
                    DataInstance.mainInstance.tabControl.TabPages.Add(DataInstance.mainInstance.tabPage2);
            }
            else
            {
                // Remove userlist page from interface
                if (DataInstance.mainInstance.tabControl.TabPages.Contains(DataInstance.mainInstance.tabPage2))
                    DataInstance.mainInstance.tabControl.TabPages.Remove(DataInstance.mainInstance.tabPage2);

            }
        }

        public void test()
        {
            DataInstance.mainInstance.tabControl.TabPages.Remove(DataInstance.mainInstance.tabPage2);

        }
    }
}
