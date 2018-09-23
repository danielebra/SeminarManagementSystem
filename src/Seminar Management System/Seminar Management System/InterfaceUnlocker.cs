using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seminar_Management_System.Classes;
using Seminar_Management_System;
using System.Windows.Forms;
using Seminar_Management_System.Forms;

namespace Seminar_Management_System
{
    // This is used to decide what interface components should be exposed
    // to the current logged in user
    class InterfaceUnlocker
    {
        public void Watch()
        {
            // Subscribe to changes to the logged in user
            DataInstance.LoggedInUserChanged += DataInstance_LoggedInUserChanged;
        }

        private TabPage Backup_UserList;
        private void DataInstance_LoggedInUserChanged(object sender, EventArgs e)
        {
            // Update the interface based on the new privilege of the logged in user
            int priv = DataInstance.LoggedInUser.Privilege;
            this.userList(priv);
            this.addSeminar(priv);
            this.editSeminar(priv);
            
        }
        private void editSeminar(int priv)
        {
            // We force every ViewSeminar to restore its state
            // The user then must re-enable Edit mode
            // This will cause a new validation check to execute that is located in:
                // ViewSeminar.cs private void btnEdit_Click(object sender, EventArgs e)
            // Based on this validation, the user will be able to edit all fields or only the attendee field
            foreach (ViewSeminar sem in DataInstance.seminarInterfaceWindows)
                sem.RestoreState();
        }

        private void addSeminar(int priv) 
        {
            // Organisers and above can create seminars (not 100% sure about this)

            DataInstance.mainInstance.btnAddSeminar.Visible = priv >= Authentication.GetPrivilegeFromRoleName(Role.Names.Organiser) ? true : false;
        }

        private void userList(int priv)
        {
            // Only Admins can see the UserList interface


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
