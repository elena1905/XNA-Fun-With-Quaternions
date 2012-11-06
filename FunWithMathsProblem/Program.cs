using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FunWithMathsProblem
{
    class Program
    {
        static float degToRad(float deg)
        {
            return (deg / 180.0f) * (float) Math.PI;
        }

        static Vector3 rotateVecByQuaternion(Vector3 a, Quaternion q)
        {
            // Rotate the vector
            Quaternion pureQ = new Quaternion(a, 0.0f);
            Quaternion invQ = Quaternion.Inverse(q);

            a = quaternionToLookVector(q * pureQ * invQ);

/*
            Quaternion temp = q * pureQ * invQ;

            a.X = temp.X;
            a.Y = temp.Y;
            a.Z = temp.Z;
 */

            return a;
        }

        static Vector3 rotateVecByQuaternion2(Vector3 a, Quaternion q)
        {
            // This time try using a matrix!!!
            Quaternion pureQ = new Quaternion(a, 0.0f);
            Quaternion invQ = Quaternion.Inverse(q);

            Matrix m = Matrix.CreateFromQuaternion(q);

            a = Vector3.Transform(a, m);

            return a;
        }

        static Vector3 quaternionToLookVector(Quaternion q)
        {
            // Convert the quaternion to a look vector
            Vector3 v = new Vector3();

            v.X = q.X;
            v.Y = q.Y;
            v.Z = q.Z;

            return v;
        }

        static Vector3 quaternionToLookVector2(Quaternion q)
        {
            // Use the matrix version
            Matrix m = Matrix.CreateFromQuaternion(q);

            Vector3 v = new Vector3();

            v.X = m.M11;
            v.Y = m.M22;
            v.Z = m.M33;

            return v;
        }

        static Quaternion lookVectorToQuaternion(Vector3 look)
        {
            Quaternion q = new Quaternion();

            q.X = look.X;
            q.Y = look.Y;
            q.Z = look.Z;
            q.W = 0.0f;

            return q;
        }

        static void Main(string[] args)
        {
            Vector3 original = new Vector3(3, 1, 0);
            Vector3 a = original;
            Quaternion q = new Quaternion() ;

            Console.WriteLine("Original A");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);
            a.Normalize();
            Console.WriteLine("Normalised A");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            q = lookVectorToQuaternion(a);

            a = quaternionToLookVector(q);
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            float theta;
            Vector3 axis;

            a = original;
            Console.WriteLine("Original A");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            q = Quaternion.Identity;

            a = rotateVecByQuaternion(a, q);
            Console.WriteLine("Rotate A by the identity quaternion");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            a = original;
            axis = new Vector3(1, 0, 0);
            theta = degToRad(90.0f);

            Matrix m;
            // MatrixRotationAxis(& m, & axis, theta);
            m = Matrix.CreateRotationX(theta);
            a = Vector3.Transform(a, m);

            Console.WriteLine("Rotate A 90 deg around the X axis using a matrix");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            a = original;
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            q = Quaternion.Identity;
            q = Quaternion.CreateFromAxisAngle(axis, theta);
            a = rotateVecByQuaternion(a, q);
            Console.WriteLine("Rotate A 90 deg around the X axis using quaternion vector arithmetic");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            a = original;
            a = rotateVecByQuaternion2(a, q);
            Console.WriteLine("Rotate A 90 deg around the X axis using quaternion matrix arithmetic");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            Console.ReadLine();
        }
    }
}
