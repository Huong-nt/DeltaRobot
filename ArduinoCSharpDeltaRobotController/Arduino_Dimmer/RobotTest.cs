using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneTestLib.RobotPackage;

namespace PhoneTest
{
    class RobotTest
    {
        public static void run()
        {
            float[] angles = new float[3];

            List<Point3D> dests = new List<Point3D>();
            dests.Add(new Point3D(1.0f, 1.0f, 11.0f));
            dests.Add(new Point3D(2.0f, 3.0f, 11.0f));
            dests.Add(new Point3D(4.0f, 5.0f, 12.0f));

            foreach (Point3D dest in dests)
            {
                Console.WriteLine("Location: {0} {1} {2}", dest.x, dest.y, dest.z);
                bool result = Kinematics.inv_kinematics(angles, dest);
                Console.WriteLine("Location: {0} {1} {2}", angles[0], angles[1], angles[2]);
            }
        }
    }
}
