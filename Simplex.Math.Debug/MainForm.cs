using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simplex.Math.Core;
using Simplex.Math.Operands;
using Simplex.Math.Operations.Elementary;
using Simplex.Math.Operations.Special;

namespace Simplex.Math.Debug
{
    public partial class MainForm : Form
    {
        //Commonly used globals
        Variable x = Variable.x;
        Variable y = Variable.y;
        Variable z = Variable.z;
        ImaginaryUnit i = ImaginaryUnit.i;
        Constant C = Constant.C;
        Constant K = Constant.K;
        Constant Pi = Constant.pi;
        Constant e = Constant.e;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void PrintLine(string Input, Color TextColor)
        {
            TB.SelectionStart = TB.Text.Length;
            TB.SelectionColor = TextColor;
            TB.AppendText(Environment.NewLine + Input);
            TB.SelectionColor = Color.Black;
        }

        public void PrintLine(string Input)
        {
            PrintLine(Input, Color.Black);
        }

        public void PrintLine()
        {
            PrintLine("");
        }

        public void Print(string Input, Color TextColor)
        {
            TB.SelectionStart = TB.Text.Length;
            TB.SelectionColor = TextColor;
            TB.AppendText(Input);
            TB.SelectionColor = Color.Black;
        }

        public void Print(string Input)
        {
            Print(Input, Color.Black);
        }

        private void TB_TextChanged(object sender, EventArgs e)
        {
            TB.SelectionStart = TB.Text.Length;
            TB.ScrollToCaret();
        }

        private void operandInitializationTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   O P E R A N D   I N I T I A L I Z A T I O N   T E S T S");
            PrintLine("-----------------------------------------------------------------------------");
            try
            {
                PrintLine("x => " + x.ToString(), Color.Blue);
                PrintLine("y => " + y.ToString(), Color.Blue);
                PrintLine("z => " + z.ToString(), Color.Blue);
                PrintLine("i => " + i.ToString(), Color.Blue);
                PrintLine("C => " + C.ToString(), Color.Blue);
                PrintLine("K => " + K.ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void operationInitializationTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   O P E R A T I O N   I N I T I A L I Z A T I O N   T E S T S");
            PrintLine("---------------------------------------------------------------------------------");
            try
            {
                PrintLine("new Sum(x, y)              => " + new Sum(x, y).ToString(), Color.Blue);
                PrintLine("new Difference(x, y)       => " + new Difference(x, y).ToString(), Color.Blue);
                PrintLine("new Product(x, y)          => " + new Product(x, y).ToString(), Color.Blue);
                PrintLine("new Quotient(x, y)         => " + new Quotient(x, y).ToString(), Color.Blue);
                PrintLine("new CSO(x, y, z, 1, 2)     => " + new CollapsedSumOperation(x, y, z, 1, 2).ToString(), Color.Blue);
                PrintLine("CSO from (x + y) + (z + 2) => " + CollapsedSumOperation.Create((x + y) + (z + 2)).ToString(), Color.Blue);
                PrintLine("CSO from -(4 + x) - z      => " + CollapsedSumOperation.Create(-(4 + x) - z).ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void additionTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   A D D I T I O N   T E S T S");
            PrintLine("-------------------------------------------------");
            try
            {
                PrintLine("0 + 0 = " + ((Value)0 + 0).ToString(), Color.Blue);
                PrintLine("2 + 2 = " + ((Value)2 + 2).ToString(), Color.Blue);
                PrintLine("5 + 0 = " + ((Value)5 + 0).ToString(), Color.Blue);
                PrintLine("x + 2 = " + (x + 2).ToString(), Color.Blue);
                PrintLine("x + 0 = " + (x + 0).ToString(), Color.Blue);
                PrintLine("0 + x = " + (0 + x).ToString(), Color.Blue);
                PrintLine("x + x = " + (x + x).ToString(), Color.Blue);
                PrintLine("x + y = " + (x + y).ToString(), Color.Blue);
                PrintLine("x + i = " + (x + i).ToString(), Color.Blue);
                PrintLine("x + C = " + (x + C).ToString(), Color.Blue);
                PrintLine("x + Infinity = " + (x + Constant.Infinity).ToString(), Color.Blue);
                PrintLine("2 + 2 + 2 = " + ((Value)2 + 2 + 2).ToString(), Color.Blue);
                PrintLine("x + x + x = " + (x + x + x).ToString(), Color.Blue);
                PrintLine("3x + 4x = " + ((3 * x) + (4 * x)).ToString(), Color.Blue);
                PrintLine("x + 2 + 2 = " + (x + 2 + 2).ToString(), Color.Blue);
                PrintLine("x + y + 2 = " + (x + y + 2).ToString(), Color.Blue);
                PrintLine("x + C + 2 = " + (x + C + 2).ToString(), Color.Blue);
                PrintLine("(x + C) + (x + C) = " + ((x + C) + (x + C)).ToString(), Color.Blue);
                PrintLine("(x + C) + (x - 3) = " + ((x + C) + (x - 3)).ToString(), Color.Blue);
                PrintLine("(x + 4) + (x - 3) = " + ((x + 4) + (x - 3)).ToString(), Color.Blue);
                PrintLine("(x + 4) + (y - 3) = " + ((x + 4) + (y - 3)).ToString(), Color.Blue);
                PrintLine("-(x + 4) + (x - 3) = " + (-(x + 4) + (x - 3)).ToString(), Color.Blue);
                PrintLine("-(x + 4) + -(x - 3) = " + (-(x + 4) + -(x - 3)).ToString(), Color.Blue);
                PrintLine("-(3x + 4) + -(2x - 3) = " + (-((3* x) + 4) + -((2 * x) - 3)).ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void generalStringFormatTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   S T R I N G   F O R M A T   T E S T");
            PrintLine("---------------------------------------------------------");
            try
            {
                var U = new Variable();
                var V = new Variable("V", "0");
                var F1 = new Value(1.0 / 3.0);
                var F2 = new Value(2.0 / 5.0);

                PrintLine("DEFAULT:");
                PrintLine("1/3 => " + F1.ToString(), Color.Blue);
                PrintLine("2/5 => " + F2.ToString(), Color.Blue);
                PrintLine("x => " + x.ToString(), Color.Blue);
                PrintLine("U => " + U.ToString(), Color.Blue);
                PrintLine("V_0 => " + V.ToString(), Color.Blue);
                PrintLine("i => " + i.ToString(), Color.Blue);
                PrintLine("C => " + C.ToString(), Color.Blue);
                PrintLine("LATEX:");
                PrintLine("1/3 => " + F1.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("2/5 => " + F2.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("x => " + x.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("U => " + U.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("V_0 => " + V.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("i => " + i.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("C => " + C.ToString(ExpressionStringFormat.LaTeX), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void operandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   O P E R A N D   E Q U A L I T Y   T E S T S");
            PrintLine("-----------------------------------------------------------------");
            try
            {
                var x2 = Variable.x;
                var C2 = Constant.C;
                PrintLine("2 = 2 =>  " + ((Value)2 == 2).ToString(), Color.Blue);
                PrintLine("2 = -2 => " + ((Value)2 == -2).ToString(), Color.Blue);
                PrintLine("x = x =>  " + (x == x2).ToString(), Color.Blue);
                PrintLine("x = y =>  " + (x == y).ToString(), Color.Blue);
                PrintLine("x = C =>  " + (x == C).ToString(), Color.Blue);
                PrintLine("x = 2 =>  " + (x == 2).ToString(), Color.Blue);
                PrintLine("C = C =>  " + (C == C2).ToString(), Color.Blue);
                PrintLine("C = K =>  " + (C == K).ToString(), Color.Blue);
                PrintLine("Pi = [3.14...] => " + (Pi == System.Math.PI).ToString(), Color.Blue);
                PrintLine("[2.7...] = e =>   " + (System.Math.E == this.e).ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void binaryOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   B I N A R Y   O P E R A T I O N   E Q U A L I T Y   T E S T S");
            PrintLine("-----------------------------------------------------------------------------------");
            try
            {
                var s1 = new Sum(x, y);
                var s12 = new Sum(x, y);
                var s2 = new Sum(x, 2);
                var s3 = new Sum(y, x);

                var d1 = new Difference(x, y);
                var d12 = new Difference(x, y);
                var d2 = new Difference(x, 2);
                var d3 = new Difference(y, x);

                var p1 = new Product(x, y);
                var p12 = new Product(x, y);
                var p2 = new Product(x, 2);
                var p3 = new Product(y, x);

                var q1 = new Quotient(x, y);
                var q12 = new Quotient(x, y);
                var q2 = new Quotient(x, 2);
                var q3 = new Quotient(y, x);

                PrintLine("BASIC IDENTITY TESTS:");
                PrintLine("(x + y) = (x + y) => " + (s1 == s12).ToString(), Color.Blue);
                PrintLine("(x + y) = (y + x) => " + (s1 == s3).ToString(), Color.Blue);
                PrintLine("(x + y) = (x + 2) => " + (s1 == s2).ToString(), Color.Blue);
                PrintLine("(x - y) = (x - y) => " + (d1 == d12).ToString(), Color.Blue);
                PrintLine("(x - y) = (y - x) => " + (d1 == d3).ToString(), Color.Blue);
                PrintLine("(x - y) = (x - 2) => " + (d1 == d2).ToString(), Color.Blue);
                PrintLine("(x * y) = (x * y) => " + (p1 == p12).ToString(), Color.Blue);
                PrintLine("(x * y) = (y * x) => " + (p1 == p3).ToString(), Color.Blue);
                PrintLine("(x * y) = (x * 2) => " + (p1 == p2).ToString(), Color.Blue);
                PrintLine("(x / y) = (x / y) => " + (q1 == q12).ToString(), Color.Blue);
                PrintLine("(x / y) = (y / x) => " + (q1 == q3).ToString(), Color.Blue);
                PrintLine("(x / y) = (x / 2) => " + (q1 == q2).ToString(), Color.Blue);

                var sr1 = new Sum(s1, z);
                var sr12 = new Sum(s1, z);
                var sr2 = new Sum(z, s1);
                var sr21 = new Sum(new Sum(z, y), x);
                var szc = new Sum(z, C);
                var sr3 = new Sum(s1, szc);
                var sr32 = new Sum(s1, szc);
                var scz = new Sum(C, z);
                var sr4 = new Sum(scz, s1);

                var dr1 = new Difference(d1, z);
                var dr12 = new Difference(d1, z);
                var dr2 = new Difference(z, d1);
                var dr21 = new Difference(new Difference(z, y), x);
                var dzc = new Difference(z, C);
                var dr3 = new Difference(d1, dzc);
                var dr32 = new Difference(d1, dzc);
                var dcz = new Difference(C, z);
                var dr4 = new Difference(dcz, d1);

                var pr1 = new Product(p1, z);
                var pr12 = new Product(p1, z);
                var pr2 = new Product(z, p1);
                var pr21 = new Product(new Product(z, y), x);
                var pzc = new Product(z, C);
                var pr3 = new Product(p1, pzc);
                var pr32 = new Product(p1, pzc);
                var pcz = new Product(C, z);
                var pr4 = new Product(pcz, p1);

                var qr1 = new Quotient(q1, z);
                var qr12 = new Quotient(q1, z);
                var qr2 = new Quotient(z, q1);
                var qr21 = new Quotient(new Quotient(z, y), x);
                var qzc = new Quotient(z, C);
                var qr3 = new Quotient(q1, qzc);
                var qr32 = new Quotient(q1, qzc);
                var qcz = new Quotient(C, z);
                var qr4 = new Quotient(qcz, q1);


                PrintLine("RECURSIVE IDENTITY TESTS:");
                PrintLine("((x + y) + z) = ((x + y) + z) => " + (sr1 == sr12).ToString(), Color.Blue);
                PrintLine("((x + y) + z) = (x + (y + z)) => " + (sr1 == sr2).ToString(), Color.Blue);
                PrintLine("((x + y) + z) = ((z + y) + x) => " + (sr1 == sr21).ToString(), Color.Blue);
                PrintLine("((x + y) + (z + C)) = ((x + y) + (z + C)) => " + (sr3 == sr32).ToString(), Color.Blue);
                PrintLine("((x + y) + (z + C)) = ((C + z) + (x + y)) => " + (sr3 == sr4).ToString(), Color.Blue);
                PrintLine("((x - y) - z) = ((x - y) - z) => " + (dr1 == dr12).ToString(), Color.Blue);
                PrintLine("((x - y) - z) = (x - (y - z)) => " + (dr1 == dr2).ToString(), Color.Blue);
                PrintLine("((x - y) - z) = ((z - y) - x) => " + (dr1 == dr21).ToString(), Color.Blue);
                PrintLine("((x - y) - (z - C)) = ((x - y) - (z - C)) => " + (dr3 == dr32).ToString(), Color.Blue);
                PrintLine("((x - y) - (z - C)) = ((C - z) - (x - y)) => " + (dr3 == dr4).ToString(), Color.Blue);
                PrintLine("((x * y) * z) = ((x * y) * z) => " + (pr1 == pr12).ToString(), Color.Blue);
                PrintLine("((x * y) * z) = (x * (y * z)) => " + (pr1 == pr2).ToString(), Color.Blue);
                PrintLine("((x * y) * z) = ((z * y) * x) => " + (pr1 == pr21).ToString(), Color.Blue);
                PrintLine("((x * y) * (z * C)) = ((x * y) * (z * C)) => " + (pr3 == pr32).ToString(), Color.Blue);
                PrintLine("((x * y) * (z * C)) = ((C * z) * (x * y)) => " + (pr3 == pr4).ToString(), Color.Blue);
                PrintLine("((x / y) / z) = ((x / y) / z) => " + (qr1 == qr12).ToString(), Color.Blue);
                PrintLine("((x / y) / z) = (x / (y / z)) => " + (qr1 == qr2).ToString(), Color.Blue);
                PrintLine("((x / y) / z) = ((z / y) / x) => " + (qr1 == qr21).ToString(), Color.Blue);
                PrintLine("((x / y) / (z / C)) = ((x / y) / (z / C)) => " + (qr3 == qr32).ToString(), Color.Blue);
                PrintLine("((x / y) / (z / C)) = ((C / z) / (x / y)) => " + (qr3 == qr4).ToString(), Color.Blue);

                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void cSOEqualityTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   C S O   E Q U A L I T Y   T E S T S");
            PrintLine("---------------------------------------------------------");
            try
            {
                var CSO1 = new CollapsedSumOperation(x, y, z);
                var CSO2 = new CollapsedSumOperation(x, y, z);
                var CSO3 = new CollapsedSumOperation(x, z, y);
                var CSO4 = new CollapsedSumOperation(x, x, z);
                var CSO5 = new CollapsedSumOperation(x, y, z, z);
                var CSO6 = new CollapsedSumOperation(z, x, y);
                PrintLine("(x + y + z) = (x + y + z)     => " + (CollapsedSumOperation.TestEquality(CSO1, CSO2)).ToString(), Color.Blue);
                PrintLine("(x + y + z) = (x + z + y)     => " + (CollapsedSumOperation.TestEquality(CSO1, CSO3)).ToString(), Color.Blue);
                PrintLine("(x + y + z) = (z + x + y)     => " + (CollapsedSumOperation.TestEquality(CSO1, CSO6)).ToString(), Color.Blue);
                PrintLine("(x + y + z) = (x + x + z)     => " + (CollapsedSumOperation.TestEquality(CSO1, CSO4)).ToString(), Color.Blue);
                PrintLine("(x + y + z) = (x + y + z + z) => " + (CollapsedSumOperation.TestEquality(CSO1, CSO5)).ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void multiplicationTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   M U L T I P L I C A T I O N   T E S T S");
            PrintLine("-------------------------------------------------------------");
            try
            {
                PrintLine("0 * 0 = " + ((Value)0 * 0).ToString(), Color.Blue);
                PrintLine("2 * 2 = " + ((Value)2 * 2).ToString(), Color.Blue);
                PrintLine("5 * 0 = " + ((Value)5 * 0).ToString(), Color.Blue);
                PrintLine("x * 2 = " + (x * 2).ToString(), Color.Blue);
                PrintLine("x * 0 = " + (x * 0).ToString(), Color.Blue);
                PrintLine("0 * x = " + (0 * x).ToString(), Color.Blue);
                PrintLine("x * x = " + (x * x).ToString(), Color.Blue);
                PrintLine("x * y = " + (x * y).ToString(), Color.Blue);
                PrintLine("x * i = " + (x * i).ToString(), Color.Blue);
                PrintLine("x * C = " + (x * C).ToString(), Color.Blue);
                PrintLine("x * Infinity = " + (x * Constant.Infinity).ToString(), Color.Blue);
                PrintLine("2 * 2 * 2 = " + ((Value)2 * 2 * 2).ToString(), Color.Blue);
                PrintLine("x * x * x = " + (x * x * x).ToString(), Color.Blue);
                PrintLine("3x * 4x = " + ((3 * x) * (4 * x)).ToString(), Color.Blue);
                PrintLine("x * 2 * 2 = " + (x * 2 * 2).ToString(), Color.Blue);
                PrintLine("x * y * 2 = " + (x * y * 2).ToString(), Color.Blue);
                PrintLine("x * C * 2 = " + (x * C * 2).ToString(), Color.Blue);
                PrintLine("(x * C) * (x / 2) = " + ((x * C) * (x / 2)).ToString(), Color.Blue);
                PrintLine("(x * 4) * (x / 2) = " + ((x * 4) * (x / 2)).ToString(), Color.Blue);
                PrintLine("(x * 4) * (y / 2) = " + ((x * 4) * (y / 2)).ToString(), Color.Blue);
                PrintLine("-(x * 4) * (x / 2) = " + (-(x * 4) * (x / 2)).ToString(), Color.Blue);
                PrintLine("-(x * 4) * -(x / 2) = " + (-(x * 4) * -(x / 2)).ToString(), Color.Blue);
                PrintLine("-(3x * 4) * -(2x / 2) = " + (-((3 * x) * 4) * -((2 * x) / 2)).ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }

        private void subtractionTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLine("P E R F O R M I N G   S U B T R A C T I O N   T E S T S");
            PrintLine("-------------------------------------------------------");
            try
            {
                PrintLine("0 - 0 = " + ((Value)0 - 0).ToString(), Color.Blue);
                PrintLine("2 - 2 = " + ((Value)2 - 2).ToString(), Color.Blue);
                PrintLine("5 - 0 = " + ((Value)5 - 0).ToString(), Color.Blue);
                PrintLine("x - 2 = " + (x - 2).ToString(), Color.Blue);
                PrintLine("x - 0 = " + (x - 0).ToString(), Color.Blue);
                PrintLine("0 - x = " + (0 - x).ToString(), Color.Blue);
                PrintLine("x - x = " + (x - x).ToString(), Color.Blue);
                PrintLine("x - y = " + (x - y).ToString(), Color.Blue);
                PrintLine("x - i = " + (x - i).ToString(), Color.Blue);
                PrintLine("x - C = " + (x - C).ToString(), Color.Blue);
                PrintLine("x - Infinity = " + (x - Constant.Infinity).ToString(), Color.Blue);
                PrintLine("2 - 2 - 2 = " + ((Value)2 - 2 - 2).ToString(), Color.Blue);
                PrintLine("x - x - x = " + (x - x - x).ToString(), Color.Blue);
                PrintLine("3x - 4x = " + ((3 * x) - (4 * x)).ToString(), Color.Blue);
                PrintLine("x - 2 - 2 = " + (x - 2 - 2).ToString(), Color.Blue);
                PrintLine("x - y - 2 = " + (x - y - 2).ToString(), Color.Blue);
                PrintLine("x - C - 2 = " + (x - C - 2).ToString(), Color.Blue);
                PrintLine("(x - C) - (x - C) = " + ((x - C) - (x - C)).ToString(), Color.Blue);
                PrintLine("(x - C) - (x - 3) = " + ((x - C) - (x - 3)).ToString(), Color.Blue);
                PrintLine("(x - 4) - (x - 3) = " + ((x - 4) - (x - 3)).ToString(), Color.Blue);
                PrintLine("(x - 4) - (y - 3) = " + ((x - 4) - (y - 3)).ToString(), Color.Blue);
                PrintLine("-(x - 4) - (x - 3) = " + (-(x - 4) - (x - 3)).ToString(), Color.Blue);
                PrintLine("-(x - 4) - -(x - 3) = " + (-(x - 4) - -(x - 3)).ToString(), Color.Blue);
                PrintLine("-(3x - 4) - -(2x - 3) = " + (-((3 * x) - 4) - -((2 * x) - 3)).ToString(), Color.Blue);
                PrintLine("SUCCESS", Color.Green);
            }
            catch (Exception ex)
            {
                PrintLine(ex.Message, Color.Red);
            }
            PrintLine();
        }
    }
}
