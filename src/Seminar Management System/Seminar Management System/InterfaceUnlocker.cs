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
            this.userList(priv);
            this.addSeminar(priv);
            this.editSeminar(priv);
            
        }
        private void editSeminar(int priv)
        {
            // Hosts and above can edit seminars (not 100% sure about this)
            foreach (ViewSeminar sem in DataInstance.seminarInterfaceWindows)
            {
                sem.disableEditing();

                if (priv >= Authentication.GetPrivilegeFromRoleName(Role.Names.Host))
                {
                    // Might have to add more things here in the future
                    // Such as, should we return state? EG:
                        // Put the form back to defaults (call btnCancel)
                    // What if the user has clicked Edit mode, now there are multiple buttons on the screen related to editing
                        // Maybe these buttons should go into a panel and we toggle the pannel instead

                    // Another issue is how do we deal with Attendees editing their info
                    // IF we hide the Edit button, then they cant toggle the attendee field
                    // Maybe edit mode should respect the logged in priviledge and it decides what section to hide or show
                    sem.btnEdit.Visible = true;
                }
                else
                    sem.btnEdit.Visible = false;
            }
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
