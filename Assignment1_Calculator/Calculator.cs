using System;
using System.Windows.Forms;


namespace Assignment1_Calculator
{
    public partial class Calculator : Form
    {
        private double? operand1;
        private double? operand2;
        private double? output = null;
        double?[] holder = new double?[20];
        double?[] holder2 = new double?[20];

        private int arrayCount2 = 0;
        
        private bool decOn = false; //part of decimal initiaion
        private bool decOnce = true; //makes it so use decimal only once
        private bool decOnce2 = true;
        private bool secondOperand = false;
        private string arthHolder = string.Empty;
        private bool multiOn = false;
        private bool addOn = false;
        private bool subOn = false;
        private bool divideOn = false;
        private bool equalClick = false;
        
        private bool powerOf = false;
        private bool firstDecBool = false;
        private bool firstDecBool2 = false;
        
        
        

        

        public Calculator()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
            button16.Enabled = false;


        }

        void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            var result = 0;
            textBox1.Text = result.ToString();

        }

        private void plusMinus_Click(object sender, EventArgs e)//changing plus and minus in front of the number
        {
            if (operand1 != null && operand2 == null && operand1 == 0) return;


            if (operand1 != null && operand2 == null && operand1 >= 0)
            {
                operand1 = operand1 * -1;
                textBox1.Text = operand1.ToString();


            }
            else if (operand1 <= 0)
            {
                operand1 = operand1 * -1;
                textBox1.Text = operand1.ToString();
            }

            if (secondOperand == true && operand1 != null && operand1 > 0)
            {
                operand2 = operand2 * -1;
                textBox1.Text = arthHolder + operand2.ToString();
            }
            else if (operand2 < 0)
            {
                operand2 = operand2 * -1;
                textBox1.Text = arthHolder + operand2.ToString();
            }
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        #region Number Inputs
        //one function for all number inputs.
        public void buttonPress(int x)//all the 0-9 button presses are stored here
        {
            if (equalClick == true)
            {
                clearNum();
            }
            if (decOn == false)
            {
                if (secondOperand == false)
                {
                    if (operand1 == null)
                    {
                        operand1 = x;

                        textBox1.Text = operand1.ToString();

                        return;
                    }
                    if (operand1 != null)
                    {

                        string operandHold;
                        operandHold = operand1.ToString();

                        operandHold = operandHold + x.ToString();
                        operand1 = Convert.ToDouble(operandHold);


                        textBox1.Text = operandHold;
                        return;
                    }
                }
                else
                {
                    button16.Enabled = true;
                    if (operand2 == null)
                    {
                        operand2 = x;

                        textBox1.Text = arthHolder + operand2.ToString();

                        return;
                    }
                    if (operand2 != null)
                    {
                        string txtholder_array;
                        string operandHold;
                        string append;

                        holder2[arrayCount2] = x;
                        txtholder_array = holder2[arrayCount2].ToString();
                        operandHold = operand2.ToString();

                        append = operandHold + txtholder_array;

                        operand2 = Convert.ToDouble(append);

                        textBox1.Text = arthHolder + operand2.ToString();

                        arrayCount2++;
                        return;
                    }
                }
            }
            else if (decOn == true)
            {
                if (secondOperand == false)
                {
                    if (firstDecBool == true)
                    {
                        string decHolder = "0.";


                        decHolder = decHolder + x.ToString();
                        operand1 = Convert.ToDouble(decHolder);

                        textBox1.Text = operand1.ToString();
                        firstDecBool = false;
                        decOn = false;
                        return;
                    }
                    else
                    {
                        string decHolder;

                        decHolder = operand1.ToString() + ".";
                        decHolder = decHolder + x.ToString();
                        operand1 = Convert.ToDouble(decHolder);

                        textBox1.Text = operand1.ToString();
                        decOn = false;
                    }
                }
                else if (secondOperand == true)
                {
                    if (firstDecBool2 == true)
                    {
                        string decHolder = "0.";


                        decHolder = decHolder + x.ToString();
                        operand2 = Convert.ToDouble(decHolder);

                        textBox1.Text = arthHolder + operand2.ToString();
                        firstDecBool2 = false;
                        decOn = false;
                        return;
                    }
                    else
                    {
                        string decHolder;

                        decHolder = operand2.ToString() + ".";
                        decHolder = decHolder + x.ToString();
                        operand2 = Convert.ToDouble(decHolder);

                        textBox1.Text = arthHolder + operand2.ToString();
                        decOn = false;
                        return;
                    }
                }
            }

        }

        private void two_Click(object sender, EventArgs e)
        {
            buttonPress(2);
        }

        private void four_Click(object sender, EventArgs e)
        {
            buttonPress(4);
        }

        private void one_Click(object sender, EventArgs e)
        {
            buttonPress(1);
        }

        private void three_Click(object sender, EventArgs e)
        {
            buttonPress(3);
        }


        private void five_Click(object sender, EventArgs e)
        {
            buttonPress(5);
        }

        private void seven_Click(object sender, EventArgs e)
        {
            buttonPress(7);
        }

        private void nine_Click(object sender, EventArgs e)
        {
            buttonPress(9);
        }
        private void zero_Click(object sender, EventArgs e)
        {
            buttonPress(0);
        }
        private void eight_Click(object sender, EventArgs e)
        {
            buttonPress(8);
        }

        private void six_Click(object sender, EventArgs e)
        {
            buttonPress(6);
        }
        #endregion
        #region Decimal Point
        private void decimalPoint_Click(object sender, EventArgs e)
        {
            if (decOnce == true)
            {
                if (operand1 == null)
                {
                    string decStartHold = "0.";
                    textBox1.Text = decStartHold;
                    decOn = true;
                    firstDecBool = true;
                }
                if (operand1 != null && secondOperand == false)
                {

                    textBox1.Text = operand1.ToString() + ".";
                    decOn = true;
                    firstDecBool = false;
                }
                decOnce = false;
                return;
            }
            if (decOnce2 == true && secondOperand == true)
            {
                if (operand2 == null)
                {
                    string decStartHold = "0.";
                    textBox1.Text = arthHolder + decStartHold;
                    decOn = true;
                    firstDecBool2 = true;
                }
                if (operand2 != null)
                {
                    textBox1.Text = arthHolder + operand2.ToString() + ".";
                    decOn = true;
                    firstDecBool2 = false;
                }
                decOnce2 = false;
            }
        }
        #endregion

        #region Arithmetic 
        private void multi_Click(object sender, EventArgs e)//clikc for multiplication
        {

            textBox1.Text = operand1.ToString() + " * ";
            arthHolder = operand1.ToString() + " * ";

            secondOperand = true;
            multiOn = true;

        }

        private void add_Click(object sender, EventArgs e)//click for addition
        {


            textBox1.Text = operand1.ToString() + " + ";
            arthHolder = operand1.ToString() + " + ";

            secondOperand = true;
            addOn = true;
        }

        private void sub_Click(object sender, EventArgs e)//click for subtraction
        {
            textBox1.Text = operand1.ToString() + " - ";
            arthHolder = operand1.ToString() + " - ";

            secondOperand = true;
            subOn = true;
        }

        private void divide_Click(object sender, EventArgs e)//click for division
        {
            textBox1.Text = operand1.ToString() + " / ";
            arthHolder = operand1.ToString() + " / ";

            secondOperand = true;
            divideOn = true;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            equalClick = true;

            if (multiOn == true)//math for X
            {

                output = operand1 * operand2;


                textBox1.Text = operand1.ToString() + " * " + operand2.ToString() + " = " + output.ToString();
                button16.Enabled = false;
            }
            if (addOn == true)//math for add
            {
                output = operand1 + operand2;
                textBox1.Text = operand1.ToString() + " + " + operand2.ToString() + " = " + output.ToString();
                button16.Enabled = false;
            }
            if (subOn == true)//math for subtraction
            {

                output = operand1 - operand2;

                textBox1.Text = operand1.ToString() + " - " + operand2.ToString() + " = " + output.ToString();
                button16.Enabled = false;
            }
            if (divideOn == true) //math for division
            {

                if (operand2 == 0)
                {
                    return;
                }
                else
                {
                    output = operand1 / operand2;

                    textBox1.Text = operand1.ToString() + " / " + operand2.ToString() + " = " + output.ToString();
                    button16.Enabled = false;
                }

            }
            if (powerOf == true)//math for power x ^ y
            {
                if (output == null)
                {
                    output = Math.Pow(operand1.Value, operand2.Value);
                    textBox1.Text = operand1.ToString() + " ^ " + operand2.ToString() + " = " + output.ToString();
                }
                else if (output != null)
                {
                    return;
                }

            }
        }


        #endregion
        #region Fun Arithmetic
        private void sqrt_Click(object sender, EventArgs e)//square root function
        {


            if (operand1 == null) return;

            if (operand1 != null && secondOperand == false)
            {

                double? sqrtHold = operand1;
                output = Math.Sqrt(sqrtHold.Value);
                textBox1.Text = "√" + operand1.ToString() + " = " + output.ToString();
                equalClick = true;

            }
            if (secondOperand == true && button16.Enabled == false)
            {
                double? sqrtHold = output;

                output = Math.Sqrt(sqrtHold.Value);
                textBox1.Text = "√ " + sqrtHold.ToString() + " = " + output.ToString();
                equalClick = true;

            }

        }

        private void pow2_Click(object sender, EventArgs e)// x ^ 2
        {
            if (operand1 == null) return;

            if (operand1 != null && secondOperand == false)
            {
                double? hold = operand1;
                operand1 = Math.Pow(operand1.Value, 2);
                textBox1.Text = hold.ToString() + "^2 =" + operand1.ToString();
                equalClick = true;
            }
            if (secondOperand == true && button16.Enabled == false)
            {
                double? hold = output;

                output = Math.Pow(output.Value, 2);
                textBox1.Text = hold.ToString() + "^2 =" + output.ToString();
                equalClick = true;
            }

        }
        private void powOf_Click(object sender, EventArgs e) //x ^ y
        {
            if (operand1 == null)
            {
                operand1 = 0;
            }
            arthHolder = operand1.ToString() + " ^ ";
            textBox1.Text = operand1.ToString() + " ^ ";
            secondOperand = true;
            powerOf = true;
        }



        private void oneDivide_Click(object sender, EventArgs e) //divide 1/x 
        {
            if (operand1 == null) return;
            if (operand1 == 0) return;
            if (output == 0) return;

            if (operand1 != null && secondOperand == false)
            {
                output = 1 / operand1;
                textBox1.Text = "1 / " + operand1.ToString() + " = " + output.ToString();
            }
            if (secondOperand == true && button16.Enabled == false)
            {
                double? hold = output;
                output = 1 / output;
                textBox1.Text = "1 / " + hold.ToString() + " = " + output.ToString();
            }
        }
        #endregion
        #region Deletion
        private void clearEntry_Click(object sender, EventArgs e) //clears the current entry
        {
            if (operand1 != null && operand2 == null)
            {
                operand1 = 0;
                textBox1.Text = operand1.ToString();

            }
            if (secondOperand == true)
            {
                operand2 = 0;
                textBox1.Text = arthHolder + operand2.ToString();
                if (button16.Enabled == false)
                {
                    clearNum();
                }
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            clearNum();
        }

        private void clearNum() //this clears everything
        {
            textBox1.Text = string.Empty;
            operand1 = null;
            operand2 = null;
            output = null;
            Array.Clear(holder, 0, 20);
            Array.Clear(holder2, 0, 20);
            equalClick = false;
            //button16.Enabled = true;
            secondOperand = false;
            multiOn = false;
            addOn = false;
            subOn = false;
            divideOn = false;
            powerOf = false;
            textBox1.Text = "0";
            decOnce = true;
            decOnce2 = true;
            arthHolder = string.Empty;


        }



        private void delete_Click(object sender, EventArgs e) //this deletes the number one digit at a time
        {
            if (operand1 == null) return;

            if (operand1 != null && operand2 == null && secondOperand == false)
            {
                if (operand1 > 9)
                {

                    string operand1Hold;


                    operand1Hold = operand1.ToString();

                    operand1Hold = operand1Hold.Remove(operand1Hold.Length - 1, 1);
                    operand1 = Convert.ToDouble(operand1Hold);

                    textBox1.Text = operand1Hold;
                }
                else
                {
                    clearNum();
                }

            }
            if (operand1 != null && operand2 != null)
            {
                if (operand2 > 9)
                {


                    string operand2Hold;

                    operand2Hold = operand2.ToString();

                    operand2Hold = operand2Hold.Remove(operand2Hold.Length - 1, 1);
                    operand2 = Convert.ToDouble(operand2Hold);

                    textBox1.Text = arthHolder + operand2.ToString();
                }
                else
                {
                    clearNum();
                }
            }
        }
        #endregion

    }
}     
            
              

               
            

