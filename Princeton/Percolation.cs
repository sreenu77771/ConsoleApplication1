using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Princeton
{
    public class Percolation
    {
        private WeightedQuickUnionPathCompressionUF uf = null;
        private int n;
        private bool[][] openMatrix;
        private int top;
        private int last;
        private int openSiteCout = 0;

        private int[][] directions = new int[][] { new int[] {-1,0}, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } } ;
        public Percolation(int n)
        {
            this.n = n;
            this.openMatrix = new bool[n][];
            uf= new WeightedQuickUnionPathCompressionUF(n*n + 2);
            this.top = n * n;
            this.last = n * n + 1;

            for (int i = 1; i <= n; i++)
            {
                uf.Union(this.top, this.toOneDimension(1, i));
                uf.Union(this.last, this.toOneDimension(n, i));
            }
        }// create n-by-n grid, with all sites blocked

        public void open(int row, int col)
        {
            if (!isOpen(row, col))
            {
                setMatrixCell(row, col);
            }

            foreach (int[] direction in directions)
            {
                int i = row + direction[0];
                int j = col + direction[1];

                if (isValid(i, j))
                {
                    if (isOpen(i, j))
                    {
                        setMatrixCell(row, col);
                        uf.Union(this.toOneDimension(row, col), this.toOneDimension(i, j));
                    }
                }
            }
        }// open site (row, col) if it is not open already

        public bool isOpen(int row, int col)
        {
            return checkMatrix(row, col);
        }// is site (row, col) open?

        public bool isFull(int row, int col)
        {
            return checkMatrix(row, col) && uf.Connected(this.toOneDimension(row, col), this.top);
        }// is site (row, col) full?

        public int numberOfOpenSites()
        {
            return openSiteCout;
        }// number of open sites

        public bool percolates()
        {
            return isFull(this.top, this.last);
        }// does the system percolate?

        private int toOneDimension(int row, int col)
        {
            return (row - 1) * this.n + (col - 1);
        }
        
        private bool checkMatrix(int row, int col)
        {
            if (!isValid(row, col))
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.openMatrix[--row][--col];
        }

        private void setMatrixCell(int row, int col)
        {
            if (!isValid(row, col))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.openMatrix[--row][--col] = true;
            openSiteCout++;
        }

        private bool isValid(int row, int col)
        {
            row = row - 1;
            col = col - 1;
            return ((row >= 0) && (row < n) && (col >= 0) && (col < n));
        }

        public static void Main(string[] args)
        {
            Percolation percolation = new Percolation(3);
            percolation.open(3, 3);
            percolation.open(3, 2);
            percolation.open(2, 2);
            percolation.open(2, 3);
            percolation.open(1, 3);
            Console.WriteLine(percolation.percolates());
            //percolation.uf.
        }// test client (optional)
    }
}
