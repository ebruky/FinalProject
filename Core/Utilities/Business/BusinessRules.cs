using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) {   //params yazıldığında istenildiği kadar verilen tipte parametre gönderilebilir 
            //logics : iş kuralı

            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        
        }
    }
}
