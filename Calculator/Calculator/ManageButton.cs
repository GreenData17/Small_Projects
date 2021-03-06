﻿using Calculator.Engine;
using System;

namespace Calculator
{
    public class ManageButton
    {
        public bool CalcUpdated;

        public string number1 = "0";
        public string number2 = "0";
        public string result = "0";

        public enum math{
            none,
            add,
            sub,
            mul,
            div
        };

        public math newMath = new math();

        public ManageButton()
        {
            number1 = "0";
            number2 = "0";
            result = "0";
            newMath = math.none;
        }

        public void SetMath(char mathchar) //Sets the operation to calculate
        {
            switch (mathchar)
            {
                case '+':
                    newMath = math.add;
                    break;
                case '-':
                    newMath = math.sub;
                    break;
                case '*':
                    newMath = math.mul;
                    break;
                case '/':
                    newMath = math.div;
                    break;
            }
            CalcUpdated = true;
        }

        public void SetCalc(char numchar) //Set the first and secound number to calculate
        {
            if (numchar == '.')
            {
                if(newMath == math.none)
                {
                    if (!number1.ToString().Contains("."))
                    {
                        if (result != "0") { result = "0"; number1 = "0"; number2 = "0"; }
                        number1 = number1 + numchar;
                    }
                }
                else
                {
                    if (!number2.ToString().Contains("."))
                    {
                        if (result != "0") { number1 = result; result = "0"; number2 = "0"; }
                        number2 = number2 + numchar;
                    }
                }
            }
            else
            {
                

                if (newMath == math.none)
                {
                    if (result != "0") { result = "0"; number1 = "0"; number2 = "0"; }
                    if (number1 == "0") number1 = "";
                    if (newMath != math.none && number2 == "0") number2 = "";

                    number1 = number1 + numchar;
                }
                else
                {
                    if (result != "0") { number1 = result; result = "0"; number2 = "0"; }
                    if (number1 == "0") number1 = "";
                    if (newMath != math.none && number2 == "0") number2 = "";

                    number2 = number2 + numchar;
                }
            }
            CalcUpdated = true;

            if (number1 == "") { number1 = "0"; }

            Debug.LogInfo($"current Calculation: {number1} || {number2} = {result}");
        }

        public void Calculate() //Does the math
        {
            switch (newMath)
            {
                case math.add:

                    Double i = Double.Parse(number1) + Double.Parse(number2);
                    result = i.ToString();

                    break;
                case math.sub:

                    Double j = Double.Parse(number1) - Double.Parse(number2);
                    result = j.ToString();

                    break;
                case math.mul:

                    Double k = Double.Parse(number1) * Double.Parse(number2);
                    result = k.ToString();

                    break;
                case math.div:

                    if (double.Parse(number1) == 0 && double.Parse(number2) == 0)
                    { Debug.LogError("Can't Prozess this. (O_O;)"); break; }

                    Double o = Double.Parse(number1) / Double.Parse(number2);
                    result = o.ToString();

                    break;
            }

            Debug.LogInfo($"current Calculation: {number1} || {number2} = {result}");

            newMath = math.none;
            CalcUpdated = true;
        }

        //returns the info inside the first and secound number and the result
        public string GetNumber1() { if (CalcUpdated) { CalcUpdated = false; return number1.ToString();  } else { return "-E-"; } }
        public string GetNumber2() { if (CalcUpdated) { CalcUpdated = false; return number2.ToString();  } else { return "-E-"; } }
        public string GetResult() { if (CalcUpdated) { CalcUpdated = false; return result.ToString();  } else { return "-E-"; } }
    }
}
