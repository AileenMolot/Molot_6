using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Molot_lib;


namespace Molot_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matrix matrix1 = new Matrix(4, 4);

                for (int y = 0; y < matrix1.GetRowsCount(); y++)
                    for (int x = 0; x < matrix1.GetColumnsCount(); x++)
                        matrix1.SetData(y, x, x + y * 10);

                Matrix matrix2 = new Matrix(4, 4);

                for (int y = 0; y < matrix2.GetRowsCount(); y++)
                    for (int x = 0; x < matrix2.GetColumnsCount(); x++)
                        matrix2.SetData(y, x, x + y * 100);

                Matrix matrix3 = matrix1 + matrix2;

                Matrix matrix4 = matrix2 + matrix1;

                Matrix matrix5 = matrix1 - matrix2;

                Matrix matrix6 = matrix2 - matrix1;

                Matrix matrix7 = matrix1 * matrix2;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument exception: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}",ex.Message);
            }

        }
    }
}
