using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Triangle_Problem
{
    public class Caculate
    {
        const int num_arg = 11;

        List<string> listOperator;
        List<int> listRulesUsed;
        List<double> listValue;
        public List<double> ListValue
        {
            get { return listValue; }
            set { listValue = value; }
        }
        List<List<int>> listRules;
        FormMain mainForm;


        public Caculate(FormMain form)
        {
            mainForm = form;

            listRulesUsed = form.ListRulesUsed;

            listRules = form.ListRules;

            listValue = new List<double>();

            listOperator = new List<string>();
        }

        public void ProcessCaculate()
        {
            //get value from user
            getValue();

            Stack<double> _stack_value = new Stack<double>();
            for (int i = 0; i < listRulesUsed.Count; i++)
            {
                string _postfixFomular = convertExpression(listRulesUsed[i]);

                int _pos = 0;
                for (int j = 0; j < _postfixFomular.Length; j++)
                {
                    string _temp_str = "";
                    double _temp1, _temp2;
                    if (_postfixFomular[j] == ' ')
                    {
                        _temp_str = _postfixFomular.Substring(_pos, j - _pos);
                        _pos = j + 1;

                        switch (_temp_str)
                        {
                            case "A":
                                _stack_value.Push(listValue[0]);
                                break;
                            case "B":
                                _stack_value.Push(listValue[1]);
                                break;
                            case "C":
                                _stack_value.Push(listValue[2]);
                                break;
                            case "a":
                                _stack_value.Push(listValue[3]);
                                break;
                            case "b":
                                _stack_value.Push(listValue[4]);
                                break;
                            case "c":
                                _stack_value.Push(listValue[5]);
                                break;
                            case "ha":
                                _stack_value.Push(listValue[6]);
                                break;
                            case "hb":
                                _stack_value.Push(listValue[7]);
                                break;
                            case "hc":
                                _stack_value.Push(listValue[8]);
                                break;
                            case "p":
                                _stack_value.Push(listValue[9]);
                                break;
                            case "S":
                                _stack_value.Push(listValue[10]);
                                break;
                            case "180":
                                _stack_value.Push(180);
                                break;
                            case "2":
                                _stack_value.Push(2);
                                break;
                            case "+":
                                _temp2 = _stack_value.Pop();
                                _temp1 = _stack_value.Pop();
                                _stack_value.Push(_temp1 + _temp2);
                                break;
                            case "-":
                                _temp2 = _stack_value.Pop();
                                _temp1 = _stack_value.Pop();
                                _stack_value.Push(_temp1 - _temp2);
                                break;
                            case "*":
                                _temp2 = _stack_value.Pop();
                                _temp1 = _stack_value.Pop();
                                _stack_value.Push(_temp1 * _temp2);
                                break;
                            case "/":
                                _temp2 = _stack_value.Pop();
                                _temp1 = _stack_value.Pop();
                                _stack_value.Push(_temp1 / _temp2);
                                break;
                            case "sqrt":
                                _temp2 = _stack_value.Pop();
                                _stack_value.Push(Math.Sqrt(_temp2));
                                break;
                            case "sin":
                                _temp2 = _stack_value.Pop();
                                //convert to radian
                                _temp2 = Math.PI * (_temp2/180);
                                _stack_value.Push(Math.Sin(_temp2));
                                break;
                            case "cos":
                                _temp2 = _stack_value.Pop();
                                //convert to radian
                                _temp2 = Math.PI * (_temp2/180);
                                _stack_value.Push(Math.Cos(_temp2));
                                break;
                            case "arcsin":
                                _temp2 = _stack_value.Pop();
                                _stack_value.Push(Math.Round((Math.Asin(_temp2) / Math.PI * 180), 2));
                                break;
                        }
                    }
                }

                for (int j = 0; j < num_arg; j++ )
                {
                    if (listRules[listRulesUsed[i]][j] == 1)
                    {
                        listValue[j] = Math.Round(_stack_value.Pop(), 2);
                        Console.WriteLine(listValue[j]);
                        break;
                    }
                }
            }
        }

        //convert expression from Infix to Postfix
        private string convertExpression(int _indexExp)
        {
            Stack<string> _stack_str = new Stack<string>();
            string _strPostfix = "";

            string _temp_str = "";
            StreamReader sr = new StreamReader("Rules.txt");
            for (int i = 0; i < _indexExp + 1; i++)
                _temp_str = sr.ReadLine();
            sr.Close();
            sr.Dispose();

            _temp_str = _temp_str.Substring(_temp_str.IndexOf('.') + 1);

            int _pos = 0;

            for (int i = 0; i < _temp_str.Length; i++)
            {
                if (_temp_str[i] == ' ' || i == _temp_str.Length - 1)
                {
                    //get operator and argument
                    string _strOp = "";
                    _strOp = (i != (_temp_str.Length - 1) ? _temp_str.Substring(_pos, i - _pos) : 
                            _temp_str.Substring(_pos, i - _pos + 1));
                    _pos = i + 1;

                    //MessageBox.Show("\'" + _strOp + "\'");
                    
                    switch (_strOp)
                    {
                        case "A":
                        case "B":
                        case "C":
                        case "a":
                        case "b":
                        case "c":
                        case "ha":
                        case "hb":
                        case "hc":
                        case "p":
                        case "S":
                        case "180":
                        case "2":
                            _strPostfix += _strOp + " ";
                            break;
                        case "+":
                        case "-":
                            while (_stack_str.Count != 0 && _stack_str.Peek() != "(")
                                _strPostfix += _stack_str.Pop() + " ";
                            _stack_str.Push(_strOp);
                            break;
                        case "*":
                        case "/":
                            while (_stack_str.Count != 0)
                                if (_stack_str.Peek() == "*" || _stack_str.Peek() == "/"
                                || _stack_str.Peek() == "sin" || _stack_str.Peek() == "cos"
                                || _stack_str.Peek() == "arcsin" || _stack_str.Peek() == "sqrt")
                                _strPostfix += _stack_str.Pop() + " ";
                            else
                                    break;
                            _stack_str.Push(_strOp);
                            break;
                        case "sin":
                        case "cos":
                        case "arcsin":
                        case "sqrt":
                            if (_stack_str.Count != 0)
                            while ( _stack_str.Peek() == "sin" || _stack_str.Peek() == "cos"
                                || _stack_str.Peek() == "arcsin" || _stack_str.Peek() == "sqrt")
                                _strPostfix += _stack_str.Pop() + " ";
                            _stack_str.Push(_strOp);
                            break;
                        case "(":
                            _stack_str.Push(_strOp);
                            break;
                        case ")":
                            if (_stack_str.Count != 0)
                            {
                                while (_stack_str.Peek() != "(")
                                    _strPostfix += _stack_str.Pop() + " ";
                                _stack_str.Pop();
                            }
                            break;
                    }
                }
            }
            while (_stack_str.Count != 0)
                _strPostfix += _stack_str.Pop() + " ";

            return _strPostfix;
        }

        //get value from user
        private void getValue()
        {
            listValue = new List<double>();
            for (int i = 0; i < num_arg; i++)
            {
                listValue.Add(-1);
            }


            if (mainForm.Tb_angle_a.Text != "")
            {
                listValue[0] = double.Parse(mainForm.Tb_angle_a.Text);
            }

            if (mainForm.Tb_angle_b.Text != "")
            {
                listValue[1] = double.Parse(mainForm.Tb_angle_b.Text);
            }

            if (mainForm.Tb_angle_c.Text != "")
            {
                listValue[2] = double.Parse(mainForm.Tb_angle_c.Text);
            }

            if (mainForm.Tb_edge_a.Text != "")
            {
                listValue[3] = double.Parse(mainForm.Tb_edge_a.Text);
            }

            if (mainForm.Tb_edge_b.Text != "")
            {
                listValue[4] = double.Parse(mainForm.Tb_edge_b.Text);
            }

            if (mainForm.Tb_edge_c.Text != "")
            {
                listValue[5] = double.Parse(mainForm.Tb_edge_c.Text);
            }

            if (mainForm.Tb_ha.Text != "")
            {
                listValue[6] = double.Parse(mainForm.Tb_ha.Text);
            }

            if (mainForm.Tb_hb.Text != "")
            {
                listValue[7] = double.Parse(mainForm.Tb_hb.Text);
            }

            if (mainForm.Tb_hc.Text != "")
            {
                listValue[8] = double.Parse(mainForm.Tb_hc.Text);
            }

            if (mainForm.Tb_p.Text != "")
            {
                listValue[9] = double.Parse(mainForm.Tb_p.Text);
            }

            if (mainForm.Tb_s.Text != "")
            {
                listValue[10] = double.Parse(mainForm.Tb_s.Text);
            }


        }


    }
}
