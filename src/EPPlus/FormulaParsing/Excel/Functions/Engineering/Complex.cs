﻿/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  05/25/2020         EPPlus Software AB       Implemented function
 *************************************************************************************************/
using OfficeOpenXml.FormulaParsing.Excel.Functions.Metadata;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering
{
    [FunctionMetadata(
        Category = ExcelFunctionCategory.Statistical,
        EPPlusVersion = "5.5",
        Description = "Converts user-supplied real and imaginary coefficients into a complex number")]
    internal class Complex : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 2);
            var real = ArgToDecimal(arguments, 0);
            var img = ArgToDecimal(arguments, 1);
            var suffix = "i";
            if(arguments.Count() > 2)
            {
                suffix = ArgToString(arguments, 2);
                if (suffix != "i" && suffix != "j") return CreateResult(eErrorType.Value);
            }
            var result = real.ToString();
            if(img > 0)
            {
                result += "+";
            }
            result += img.ToString() + suffix;
            return CreateResult(result, DataType.String);
        }
    }
}
