using System;
using System.Collections.Generic;

namespace Lab3
{
    public class ConverterDataBase
    {
        public Dictionary<int, double> fromMetresTo = new Dictionary<int, double>(8);

        public ConverterDataBase()
        {
            fromMetresTo.Add(0, 1000); //mm
            fromMetresTo.Add(1, 100); //cm
            fromMetresTo.Add(2, 1); //m
            fromMetresTo.Add(3, 0.001d); //km
        }
    }
    public class ConverterDataBase2
    {
        public Dictionary<int, double> fromMetresTo = new Dictionary<int, double>(8);

        public ConverterDataBase2()
        {
            fromMetresTo.Add(0, Math.PI / 180.0); //grad
            fromMetresTo.Add(1, 1); //rad
        }
    }
}
