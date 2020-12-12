using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeChuyenGia_GiaiLuongGiac.CongThuc
{
    class CongThuc
    {
        //cong thuc 1  : dinh ly sin
        /*
            a / sin(A) = 2 * R
            b / sin(B) =  2 * R
            c / sin(C) =  2 * R
 
         * */
        public double CT1(double a, double A)
        {
            double R;
            A = A * 3.14 / 180; //doi tu do sang radian
            R= a/(2*Math.Sin(A));

            return R;
        }

        //Cong thuc 2  : dinh ly cosin
        /*
        a * a = b * b + c * c - 2 * b * c * Cos(A)
        b * b = a * a + c * c - 2 * a * c * cos(B)
        c * c = a * a + b * b - 2 * a * b * cos(C)

         */
        public double CT2(double a, double b, double C)
        {
            double c;
            C = C * 3.14 / 180; //doi tu do sang radian
            c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(C));

            return c;
        }

        //cong thuc 3: dinh ly duong trung tuyen
        /*

            ma * ma = ( b * b + c * c ) / 2 - a * a / 4
            mb * mb = ( a * a + c * c ) / 2 -  b * b / 4
            mc * mc = ( a * a  + b * b ) / 2 - c * c / 4

         */
        public double CT3(double a, double b, double c)
        {
            double ma;
            ma = Math.Sqrt((a * a + b * b) / 2 - (c * c) / 4);

            return ma;
        }

        //các hàm tính diện tích
        //ct4
        /*
        S = ( a * ha ) / 2
        S = ( b * hb ) / 2
        S = ( c * hc ) / 2

        */
        public double CT4(double a, double ha)
        {
            double S;
            S = (a * ha) / 2;
            return S;
        }

        // ham tinh canh
        /*
        a = 2 * S / ha
        b = 2 * S / hb
        c = 2 * S / hc

        */
        public double CT5(double S, double ha)
        {
            double a;
            a = (2 * S) / ha;
            return a;
        }

        //tinh duong cao
        /*
        ha = 2 * S / a
        hb = 2 * S / b
        hc = 2 * S / c


        */
        public double CT6(double S, double a)
        {
            double ha;
            ha = (2 * S) / a;
            return ha;
        }

        // dien tich
        /*
        S = a * b * sin(C)
        S = a * c * sin(B)
        S = b * c * sin(A)

        */
        public double CT7(double a, double b, double C)
        {
            double S;
            C = C * 3.14 / 180; //doi tu do sang radian
            S = a * b * Math.Sin(C);
            return S;
        }

        // ///
        /*
        S = ( a * b * c ) / 4 * R


        */
        public double CT8(double a, double b, double c, double R)
        {
            double S;
            S = (a * b * c) / (4 * R);
            return S;
        
        }
        // //
        /*
        S = p * r

        */
        public double CT9(double p, double r)
        {
            double S;
            S = p * r;
            return S;
        }

        // ///
        /*
        p = S / r
        r = S / p

         */

        public double CT10(double S, double r)
        {
            double p;
            p = S / r;
            return p;
        }
        // ////
        /*
        S = sqrt ( p * ( p - a ) * ( p - b ) * ( p - c ) )

        */
        public double CT11(double p, double a, double b, double c)
        {
            double S;
            S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        
        }

        // /////
        /*
        P = a + b + c

        */
        public double CT12(double a, double b, double c)
        {
            double P = a + b + c;
            return P;
        }
        // ////
        /*
         a = P - b - c
        b = P - a - c
        c =   P - a - b
                
        */
        public double CT13(double P, double b, double c)
        {
            double a;
            a = P - b - c;
            return a;
        
        }
        // /////
        /*
        cos(A) = ( b * b + c * c - a * a ) / 2 * c * b
        cos(B) = ( a * a + c * c - b * b ) /  2 * a * c
        cos(C) = ( a * a + b * b - c * c ) / 2 * a * b
        
        */
        public double CT14(double a, double b, double c)
        {
            double A;
            A = Math.Acos((b * b + c * c - a * a) / (2 * c * b));
            return A * 180 / 3.14; //doi tu radian sang do
        }



    }
}
