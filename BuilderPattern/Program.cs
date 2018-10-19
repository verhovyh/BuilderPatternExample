using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Builder
    {
        Product product = new Product();
        public Builder AddWheels(int size)  //method semantics, can take params
        {
            product.parts.Add(String.Format("Wheels size={0}", size));
            return this;
        }

        public Builder AddTransmission   // property semantics, can't take params
        {
            get
            {
                product.parts.Add(String.Format("Transmission"));
                return this;
            }
        }
        public Builder AddEngine
        {
            get
            {
                product.parts.Add("Engine");
                return this;
            }

        }
        public Product Build()
        {
            if ((product.parts.Count) < 2) { throw new Exception("Should contain at least two parts"); }   //Build() can check validity
            return product;
        }
        
    }

    class Product
    {
        public readonly List<string> parts = new List<string>();
        public override string ToString()
        {
            return String.Join(":::", parts);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder();
            var product1 = builder.AddEngine.AddWheels(21).AddTransmission.Build(); //fluent API
            Console.WriteLine(product1);
        }
    }
}

//http://blogs.tedneward.com/patterns/Builder-CSharp/