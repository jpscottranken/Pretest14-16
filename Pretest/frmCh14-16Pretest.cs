using EmployeeLibrary;
using System;
using System.Windows.Forms;

namespace Pretest
{
    public partial class Form1 : Form
    {
        //  Global Constants
        const int MINEMPNUMBER  = 1000;
        const int MAXEMPNUMBER  = 9999;
        const decimal MINHOURS  =    0.00m;
        const decimal MAXHOURS  =   84.00m;
        const decimal MINHRATE  =    0.00m;
        const decimal MAXHRATE  =   99.99m;
        const decimal MAXNONOT  =   40.00m;
        const decimal OTRATE    =    1.5m;
        const int MINPIECES     =    0;
        const int MAXPIECES     =  100;
        const decimal MINPPP    =    0.00m;
        const decimal MAXPPP    =    1.00m;

        //  Global Variable
        decimal grossPay        =    0.00m;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeTypeInfoInvisible();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //  Verify that either the HourlyEmployee or
            //  the PieceWorkerEmployee radio button is checked.
            bool success = IsARadioButtonChecked();

            if (!success)
            {
                return;
            }

            //  Either the HourlyEmployee or the
            //  PieceWorkerEmployee radio button was checked.
            //  Validate that the first name, last name,
            //  and employee number (common fields for
            //  any type of employee) meet the requirements.
            success = ValidateCommonFields();

            //  If there were validation errors found, return
            if (!success)
            {
                return;
            }

            //  No validation errors.
            //  Check to see whether:
            //  a) HourlyEmployee      radio button was checked. OR:
            //  b) PieceWorkerEmployee radio button was checked

            if (radHourlyEmployee.Checked)
            {
                success = ValidateHourlyEmployee();

                //  Error(s) found. Return
                if (!success)
                {
                    return;
                }

                //  Instantiate an hourly employee object
                InstantiateHourlyEmployee();
            }
            else if (radPieceworkerEmployee.Checked)
            {
                success = ValidatePieceWorkerEmployee();

                //  Error(s) found. Return
                if (!success)
                {
                    return;
                }

                //  Instantiate a piecework employee object
                InstantiatePieceWorkerEmployee();
            }
        }

        private bool IsARadioButtonChecked()
        {
            bool retVal = true;

            //  Make sure one of the radio buttons was checked
            if ((!radHourlyEmployee.Checked) &&
                (!radPieceworkerEmployee.Checked))
            {
                ShowMessage("You Must Choose An Employee Type Radio Button!",
                            "NEITHER RADIO BUTTON SELECTED");
                retVal = false;
            }

            return retVal;
        }

        private bool ValidateCommonFields()
        {
            bool success  = true;
            string errMsg = "";

            //  Make our validation checks, i.e.:
            //  1.  first name cannot be empty.
            errMsg += Validator.IsPresent(txtFirstName.Text, 
                                          txtFirstName.Tag.ToString());

            //  2.  last  name cannot be empty.
            errMsg += Validator.IsPresent(txtLastName.Text, 
                                          txtLastName.Tag.ToString());

            //  3.  employee number must be an integer.
            errMsg += Validator.IsInt32(txtEmployeeNumber.Text, 
                                        txtEmployeeNumber.Tag.ToString());

            //  4.  employee number must be an integer
            //      between 1000 and 9999.
            errMsg += Validator.IsWithinRange(txtEmployeeNumber.Text, 
                                              txtEmployeeNumber.Tag.ToString(),
                                              MINEMPNUMBER, MAXEMPNUMBER);

            //  Verify no errors were found.
            //  If error(s) found, show in MessageBox
            if (errMsg != "")
            {
                //  One or more validation errors were found.
                success = false;
                ShowMessage(errMsg, "THE FOLLOWING ERROR(S) HAVE BEEN FOUND");
            }

            return success;
        }

        private bool ValidateHourlyEmployee()
        {
            bool success  = true;
            string errMsg = "";

            //  Set the tag property for the hours 
            //  worked and hourly rate textboxes
            textBox5.Tag  = "hoursworked";
            textBox6.Tag  = "hourlyrate";

            //  Validate that hours worked:
            //  1.  Is a decimal value.
            //  2.  Is within range (0.00 - 84.00)
            //
            errMsg += Validator.IsDecimal(textBox5.Text,
                                          textBox5.Tag.ToString());

            errMsg += Validator.IsWithinRange(textBox5.Text,
                                              textBox5.Tag.ToString(),
                                              MINHOURS, MAXHOURS);

            //  Validate that hourly rate:
            //  1.  Is a decimal value.
            //  2.  Is within range (0.00 - 99.99).
            errMsg += Validator.IsDecimal(textBox6.Text,
                                          textBox6.Tag.ToString());

            errMsg += Validator.IsWithinRange(textBox6.Text,
                                              textBox6.Tag.ToString(),
                                              MINHRATE, MAXHRATE);

            //  Verify no errors were found.
            //  If error(s) found, show in MessageBox
            if (errMsg != "")
            {
                //  One or more validation errors were found.
                success = false;
                ShowMessage(errMsg, "THE FOLLOWING ERRORS HAVE BEEN FOUND");
            }

            return success;
        }
        private bool ValidatePieceWorkerEmployee()
        {
            bool success = true;
            string errMsg = "";

            //  Set the tag property for the hours 
            //  worked and hourly rate textboxes
            textBox5.Tag  = "pieces";
            textBox6.Tag  = "priceperpiece";

            //  Validate that pieces:
            //  1.  Is an integer value.
            //  2.  Is within range (0 - 100)
            //
            errMsg += Validator.IsInt32(textBox5.Text,
                                        textBox5.Tag.ToString());

            errMsg += Validator.IsWithinRange(textBox5.Text,
                                              textBox5.Tag.ToString(),
                                              MINPIECES, MAXPIECES);

            //  Validate that price per piece:
            //  1.  Is a decimal value.
            //  2.  Is within range (0.00 - 1.00).
            errMsg += Validator.IsDecimal(textBox6.Text,
                                          textBox6.Tag.ToString());

            errMsg += Validator.IsWithinRange(textBox6.Text,
                                              textBox6.Tag.ToString(),
                                              MINPPP, MAXPPP);

            //  Verify no errors were found.
            //  If error(s) found, show in MessageBox
            if (errMsg != "")
            {
                //  One or more validation errors were found.
                success = false;
                ShowMessage(errMsg, "THE FOLLOWING ERRORS HAVE BEEN FOUND");
            }

            return success;
        }

        private void InstantiateHourlyEmployee()
        {
            //  Create local variables representing the:
            //  employee number, hours worked, and
            //  hourly rate
            int empNum    = Convert.ToInt32(txtEmployeeNumber.Text);
            decimal hours = Convert.ToDecimal(textBox5.Text);
            decimal rate  = Convert.ToDecimal(textBox6.Text);

            //  Instantiate an HourlyEmployee object
            HourlyEmployee he = new HourlyEmployee(
                                                    txtFirstName.Text,
                                                    txtLastName.Text,
                                                    empNum, hours, rate);

            //  Did employee work overtime (hours > 40) or not
            if (hours <= MAXNONOT)
            {
                //  Employee worked <= 40 hours. No OT coming.
                grossPay = hours * rate;
            }
            else
            {
                //  Employee worked > 40 hours. Has OT coming.
                grossPay = (MAXNONOT * rate)  +
                          ((hours - MAXNONOT) * rate * OTRATE);
            }

            txtResults.Text = "HOURLY EMPLOYEE STATS:" +
                              "\r\n" + he.displayText() +
                              "\r\nUnion Status: " + chkUnionMember.Checked +
                              "\r\n" + "Gross Pay: " +
                              grossPay.ToString("c");
        }

        private void InstantiatePieceWorkerEmployee()
        {
            //  Create variables representing the:
            //  employee number, hours worked, and
            //  hourly rate
            int empNum  = Convert.ToInt32(txtEmployeeNumber.Text);
            int pieces  = Convert.ToInt32(textBox5.Text);
            decimal ppp = Convert.ToDecimal(textBox6.Text);

            //  Instantiate an PieceWorker object
            PieceWorkerEmployee pwe = new PieceWorkerEmployee(
                                                    txtFirstName.Text,
                                                    txtLastName.Text,
                                                    empNum, pieces, ppp);

            //  Calculate gross pay as follows:
            //  pieces * pricePerPiece * 40
            grossPay = pieces * ppp * MAXNONOT;

            txtResults.Text = "PIECEWORKER EMPLOYEE STATS:" +
                              "\r\n" + pwe.displayText() +
                              "\r\nUnion Status: " + chkUnionMember.Checked +
                              "\r\n" + "Gross Pay: " +
                              grossPay.ToString("c");
        }


        private void radHourlyEmployee_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Tag = "hoursworked";
            textBox6.Tag = "hourlyrate";
            label5.Text = "Hours Worked:";
            label6.Text = "Hourly Rate:";
            makeTypeInfoVisible();
        }

        private void radPieceworkerEmployee_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Tag = "pieces";
            textBox6.Tag = "priceperpiece";
            label5.Text = "# Pieces Made:";
            label6.Text = "Price/Piece:";
            makeTypeInfoVisible();
        }

        private void makeTypeInfoVisible()
        {
            label5.Visible   = true;
            label6.Visible   = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAndSetFocus();
        }

        private void ClearAndSetFocus()
        {
            ClearCommonInfo();
            MakeTypeInfoInvisible();
            txtFirstName.Focus();
        }

        private void ClearCommonInfo()
        {
            txtFirstName.Text               = "";
            txtLastName.Text                = "";
            chkUnionMember.Checked          = false;
            txtEmployeeNumber.Text          = "";
            txtResults.Text                 = "";
            radHourlyEmployee.Checked       = false;
            radPieceworkerEmployee.Checked  = false;
        }

        private void MakeTypeInfoInvisible()
        {
            textBox5.Text       = "";
            textBox6.Text       = "";
            textBox5.Tag        = "";
            textBox6.Tag        = "";
            label5.Visible      = false;
            label6.Visible      = false;
            textBox5.Visible    = false;
            textBox6.Visible    = false;
        }

         private void btnExit_Click(object sender, EventArgs e)
        {
            exitProgramOrNot();
        }

        private void exitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show(
                "Do You Really Want To Exit The Program?",
                "EXIT NOW?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}

/*
 *              private void radHourlyEmployee_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Tag = "hourswored";
            textBox6.Tag = "hourlyrate";
            label5.Text = "Hours Worked:";
            label6.Text = "Hourly Rate:";
            makeTypeInfoVisible();
        }

        private void radPieceworkerEmployee_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Tag = "pieces";
            textBox6.Tag = "priceperpiece";
            label5.Text = "# Pieces Made:";
            label6.Text = "Price/Piece:";
            makeTypeInfoVisible();
        }

 */