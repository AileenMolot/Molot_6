using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molot_lib
{
    public class Matrix
    {
        private int[,] _matrix;

        public Matrix (int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("Matrix can not exsist with zero or negative rows and columns.");

            this._matrix = new int[rows, columns];
        }

        public void SetData (int row, int column, int value)
        {
            this._matrix[row, column] = value;
        }

        public int GetData (int row, int column)
        {
            int value = this._matrix[row, column];
            return value;
        }

        public int GetRowsCount ()
        {
            int rowsCount = this._matrix.GetLength(0);
            return rowsCount;
        }

        public int GetColumnsCount ()
        {
            int columnsCount = this._matrix.GetLength(1);
            return columnsCount;
        }

        public static Matrix operator + (Matrix leftOperand, Matrix rightOperand)
        {
            if (leftOperand.GetRowsCount() != rightOperand.GetRowsCount() && leftOperand.GetColumnsCount() != rightOperand.GetColumnsCount())
                throw new ArgumentException("Matrixs should be equal sized for this operation.");

            Matrix result = new Matrix(leftOperand.GetRowsCount(), leftOperand.GetColumnsCount());

            for (int row = 0; row < result.GetRowsCount(); row++)
                for (int col = 0; col < result.GetColumnsCount(); col++)
                    result.SetData(row, col, leftOperand.GetData(row, col) + rightOperand.GetData(row, col));

            return result;
        }

        public static Matrix operator - (Matrix minuend, Matrix subtrahend)
        {
            if (minuend.GetRowsCount() != subtrahend.GetRowsCount() && minuend.GetColumnsCount() != subtrahend.GetColumnsCount())
                throw new ArgumentException("Matrixs should be equal sized for this operation.");

            Matrix result = new Matrix(minuend.GetRowsCount(), minuend.GetColumnsCount());

            for (int row = 0; row < result.GetRowsCount(); row++)
                for (int col = 0; col < result.GetColumnsCount(); col++)
                    result.SetData(row, col, minuend.GetData(row, col) - subtrahend.GetData(row, col));

            return result;
        }

        public static Matrix operator * (Matrix multiplier, Matrix factor)
        {
            if (multiplier.GetColumnsCount() != factor.GetRowsCount())
                throw new ArgumentException("Number of columns in multiplier should be equal to number of rows in factor.");

            Matrix result = new Matrix(multiplier.GetRowsCount(), factor.GetColumnsCount());

            for (int resultRow = 0; resultRow < result.GetRowsCount(); resultRow++)
                for (int resultCol = 0; resultCol < result.GetColumnsCount(); resultCol++)
                {
                    int sum = 0;

                    for (int i = 0; i<multiplier.GetColumnsCount(); i++)
                    {
                        sum = sum + (multiplier.GetData(resultRow, i) * factor.GetData(i, resultCol));
                    }

                    result.SetData(resultRow, resultCol, sum);
                }
            return result;
        }

    }
}
