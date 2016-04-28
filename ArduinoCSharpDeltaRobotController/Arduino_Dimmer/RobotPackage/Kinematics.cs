using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneTestLib.RobotPackage
{
    public class Point3D
    {
        public float x;
        public float y;
        public float z;

        public Point3D()
        {
            x = y = z = 0;
        }

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public class Kinematics
    {
        static float r2(float input){
            return input * input;
        }

        public static Point3D rotate_xy(Point3D coord, float sin_theta, float cos_theta)
        {
            Point3D ret = new Point3D();
            ret.x = coord.x * cos_theta - coord.y * sin_theta;
            ret.y = coord.x * sin_theta + coord.y * cos_theta;
            ret.z = coord.z;
            return ret;
        }

        public static bool inv_kinematics(float[] result, Point3D target)
        {
            float dist, inv_dist, alpha;
            float angle;
            float x1, z1, x2, z2, h;
            float lower_radius;
            Point3D target_rot, trans;

            target_rot = new Point3D(target.x, target.y, target.z);
            trans = new Point3D();

            for (int i = 0; i < 3; i++)
            {
                // rotate coordinates
                if (i == 1)
                    target_rot = rotate_xy(target, Common.SIN_120, Common.COS_120);
                if (i == 2)
                    target_rot = rotate_xy(target, Common.SIN_240, Common.COS_240);

                // Add servo offset and hand offset
                trans.x = target_rot.x + Common.SERVO_XOFF + Common.HAND_XOFF;
                trans.y = target_rot.y;
                // Add servo offset and tool offset
                trans.z = target_rot.z + Common.SERVO_ZOFF;

                lower_radius = (float)Math.Sqrt(r2(Common.ARM_LOWER_LEN) - r2(trans.y));

                dist = (float)Math.Sqrt(r2(trans.x) + r2(trans.z));
                // Inverse square root!!!
                inv_dist = 1 / dist;

                // Bounds checking
                if (dist > (Common.ARM_UPPER_LEN + lower_radius) ||
                        dist < (lower_radius - Common.ARM_UPPER_LEN))
                {
                    //pc.printf("OH FFFFFFUUUUUUUU Inv Failure %.5f, %.5f, %.5f\r\n", dist, ARM_UPPER_LEN, lower_radius);
                    //led2 = 1;
                    return false;
                }

                alpha = (float)((r2(Common.ARM_UPPER_LEN) - r2(lower_radius) + r2(dist)) * 0.5 * inv_dist);

                x1 = (trans.x * alpha * inv_dist);
                z1 = (trans.z * alpha * inv_dist);

                h = (float)Math.Sqrt(r2(Common.ARM_UPPER_LEN) - r2(alpha));

                x2 = -trans.z * (h * inv_dist);
                z2 = trans.x * (h * inv_dist);

                angle = (float)Math.Atan2(z1 - z2, x1 - x2);

                result[i] = angle;
            }
            return true;
        }
    }
}
