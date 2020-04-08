using System;
using System.Collections.Generic;
using System.Text;

namespace DT_lab_3
{
    class HJAlgorithm
    {
        public delegate double HJFunction(SPoint point);

        int n; // размерность задачи
        double h; // шаг
        double d; // коэффициент уменьшеняи шага
        double m; // ускоряющий множитель
        double e; // точность поиска

        const int maxIterations = 200; // максимальное количество итераций

        SPoint basis; // базисная точка

        private HJFunction function; // функция минимизации

        public HJAlgorithm(HJFunction function, SPoint basis, double h, double d, double m, double e)
        {
            this.function = function;
            this.basis = basis;

            n = basis.coordinates.Length;

            this.h = h;
            this.d = d;
            this.m = m;
            this.e = e;
        }

        public HJAlgorithm(HJFunction function, SPoint basis)
        {
            this.function = function;
            this.basis = basis;

            n = basis.coordinates.Length;

            h = 0.2;
            d = 2;
            m = 0.5;
            e = 0.1;
        }

        public string minValue()
        {
            int i = 0;

            while (i++ < maxIterations)
            {
                SPoint newBasis = iteration();

                if (basis.Equals(newBasis))
                {
                    h /= d;
                }
                else
                {
                    SPoint exampleSearch = newBasis + m * (newBasis - basis);
                    exampleSearch.Value = function(exampleSearch);

                    if (exampleSearch.Value < newBasis.Value)
                    {
                        basis = exampleSearch;
                    }
                    else
                    {
                        basis = newBasis;
                    }

                    if (h <= e)
                    {
                        break;
                    }
                }
            }

            return basis.ToString();
        }

        private SPoint iteration()
        {
            SPoint newBasis = basis.copy();

            basis.Value = function(basis);

            for (int i = 0; i < n; i++)
            {
                newBasis.coordinates[i] += h;

                if (function(newBasis) < basis.Value)
                    continue;
                else
                {
                    newBasis.coordinates[i] -= 2 * h;

                    if (function(newBasis) < basis.Value)
                        continue;
                    else
                        newBasis.coordinates[i] += h;
                }
            }

            newBasis.Value = function(newBasis);

            return newBasis;
        }
    }
}
