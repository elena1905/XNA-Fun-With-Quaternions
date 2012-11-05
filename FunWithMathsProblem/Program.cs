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
            return a;
        }

        static Vector3 rotateVecByQuaternion2(Vector3 a, Quaternion q)
        {
            // This time try using a matrix!!!
            return a;
        }

        static Vector3 quaternionToLookVector(Vector3 look, Quaternion q)
        {
            // Convert the quaternion to a look vector
        }

        static Vector3 quaternionToLookVector2(Vector3 look, Quaternion q)
        {
            // Use the matrix version
        }

        static Quaternion lookVectorToQuaternion(Quaternion q, Vector3 look)
        {

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

            lookVectorToQuaternion(q, a);

            quaternionToLookVector(a, q);
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            float theta;
            Vector3 axis;

            a = original;
            Console.WriteLine("Original A");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            q = Quaternion.Identity;

            rotateVecByQuaternion(a, q);
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
            rotateVecByQuaternion(a, q);
            Console.WriteLine("Rotate A 90 deg around the X axis using quaternion vector arithmetic");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);

            a = original;
            rotateVecByQuaternion2(a, q);
            Console.WriteLine("Rotate A 90 deg around the X axis using quaternion matrix arithmetic");
            Console.WriteLine(a.X + " " + a.Y + " " + a.Z);
        }
    }
}
