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
            PrintLine("P E R F O R M I N G   O P E R A N D   I N I T I A L I Z A T I O N");
            PrintLine("-----------------------------------------------------------------");
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
            PrintLine("P E R F O R M I N G   O P E R A T I O N   I N I T I A L I Z A T I O N");
            PrintLine("---------------------------------------------------------------------");
            try
            {
                PrintLine("new Sum(x, y) => " + new Sum(x, y).ToString(), Color.Blue);
                PrintLine("new Difference(x, y) => " + new Difference(x, y).ToString(), Color.Blue);
                PrintLine("new Product(x, y) => " + new Product(x, y).ToString(), Color.Blue);
                PrintLine("new Quotient(x, y) => " + new Quotient(x, y).ToString(), Color.Blue);
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
                PrintLine("x + 2 + 2 = " + (x + 2 + 2).ToString(), Color.Blue);
                PrintLine("x + y + 2 = " + (x + y + 2).ToString(), Color.Blue);
                PrintLine("x + C + 2 = " + (x + C).ToString(), Color.Blue);
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
    }
}
