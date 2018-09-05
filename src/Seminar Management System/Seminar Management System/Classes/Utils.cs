using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_Management_System.Classes
{
    class Utils
    {
        static public IEnumerable<Control> GetControlsFromControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetControlsFromControl(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        internal static class ObjectCloner
        {
            // Serialize and deserialize objects
            public static object Clone(object obj)
            {
                using (MemoryStream buffer = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(buffer, obj);
                    buffer.Position = 0;
                    object temp = formatter.Deserialize(buffer);
                    return temp;
                }
            }
        }
    }
}
