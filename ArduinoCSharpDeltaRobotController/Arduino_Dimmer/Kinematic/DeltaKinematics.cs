﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneTestLib.RobotPackage
{
    class DeltaKinematics
    {
        // robot geometry
        //const float e = 90.0f;      // side of end effector triangle 
        //const float f = 200.0f;     // side of fixed triangle
        //const float re = 200.0f;     // length of parallelogram joint 
        //const float rf = 75.0f;      // length of upper joint 

        static float e = 96.5445F;      // side of end effector triangle 
        static float f = 352.7841F;     // side of fixed triangle
        static float re = 306.0F;     // length of parallelogram joint 
        static float rf = 69.85F;      // length of upper joint 

        // trigonometric constants
        const float sqrt3 = 1.73205080757f;
        const float pi = 3.141592653f;    // PI
        const float sin120 = sqrt3 / 2.0f;
        const float cos120 = -0.5f;
        const float tan60 = sqrt3;
        const float sin30 = 0.5f;
        const float tan30 = 1 / sqrt3;

        // forward kinematics: (theta1, theta2, theta3) -> (x0, y0, z0)
        // returned status: 0=OK, -1=non-existing position
        public int delta_calcForward(float theta1, float theta2, float theta3, ref float x0, ref float y0, ref float z0)
        {
            float t = (f - e) * tan30 / 2;
            float dtr = pi / (float)180.0;

            theta1 *= dtr;
            theta2 *= dtr;
            theta3 *= dtr;

            float y1 = -(t + rf * (float)Math.Cos(theta1));
            float z1 = -rf * (float)Math.Sin(theta1);

            float y2 = (t + rf * (float)Math.Cos(theta2)) * sin30;
            float x2 = y2 * tan60;
            float z2 = -rf * (float)Math.Sin(theta2);

            float y3 = (t + rf * (float)Math.Cos(theta3)) * sin30;
            float x3 = -y3 * tan60;
            float z3 = -rf * (float)Math.Sin(theta3);

            float dnm = (y2 - y1) * x3 - (y3 - y1) * x2;

            float w1 = y1 * y1 + z1 * z1;
            float w2 = x2 * x2 + y2 * y2 + z2 * z2;
            float w3 = x3 * x3 + y3 * y3 + z3 * z3;

            // x = (a1*z + b1)/dnm
            float a1 = (z2 - z1) * (y3 - y1) - (z3 - z1) * (y2 - y1);
            float b1 = -((w2 - w1) * (y3 - y1) - (w3 - w1) * (y2 - y1)) / 2.0f;

            // y = (a2*z + b2)/dnm;
            float a2 = -(z2 - z1) * x3 + (z3 - z1) * x2;
            float b2 = ((w2 - w1) * x3 - (w3 - w1) * x2) / 2.0f;

            // a*z^2 + b*z + c = 0
            float a = a1 * a1 + a2 * a2 + dnm * dnm;
            float b = 2 * (a1 * b1 + a2 * (b2 - y1 * dnm) - z1 * dnm * dnm);
            float c = (b2 - y1 * dnm) * (b2 - y1 * dnm) + b1 * b1 + dnm * dnm * (z1 * z1 - re * re);

            // discriminant
            float d = b * b - (float)4.0 * a * c;
            if (d < 0) return -1; // non-existing point

            z0 = -(float)0.5 * (b + (float)Math.Sqrt(d)) / a;
            x0 = (a1 * z0 + b1) / dnm;
            y0 = (a2 * z0 + b2) / dnm;
            return 0;
        }

        // inverse kinematics
        // helper functions, calculates angle theta1 (for YZ-pane)
        public int delta_calcAngleYZ(float x0, float y0, float z0, ref float theta)
        {
            float y1 = -0.5f * 0.57735f * f; // f/2 * tg 30
            y0 -= 0.5f * 0.57735f * e;    // shift center to edge
            // z = a + b*y
            float a = (x0 * x0 + y0 * y0 + z0 * z0 + rf * rf - re * re - y1 * y1) / (2 * z0);
            float b = (y1 - y0) / z0;
            // discriminant
            float d = -(a + b * y1) * (a + b * y1) + rf * (b * b * rf + rf);
            if (d < 0) return -1; // non-existing point
            float yj = (y1 - a * b - (float)Math.Sqrt(d)) / (b * b + 1); // choosing outer point
            float zj = a + b * yj;
            theta = (float)(180.0 * Math.Atan(-zj / (y1 - yj)) / pi + ((yj > y1) ? 180.0 : 0.0));
            return 0;
        }

        // inverse kinematics: (x0, y0, z0) -> (theta1, theta2, theta3)
        // returned status: 0=OK, -1=non-existing position
        public int delta_calcInverse(float x0, float y0, float z0, ref float theta1, ref float theta2, ref float theta3)
        {
            theta1 = theta2 = theta3 = 0;
            int status = delta_calcAngleYZ(x0, y0, z0, ref theta1);
            if (status == 0) status = delta_calcAngleYZ(x0 * cos120 + y0 * sin120, y0 * cos120 - x0 * sin120, z0, ref theta2);  // rotate coords to +120 deg
            if (status == 0) status = delta_calcAngleYZ(x0 * cos120 - y0 * sin120, y0 * cos120 + x0 * sin120, z0, ref theta3);  // rotate coords to -120 deg
            return status;
        }


    }
}