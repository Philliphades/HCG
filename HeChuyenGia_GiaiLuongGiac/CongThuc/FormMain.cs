using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Triangle_Problem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Init();
        }
        //caculate
        Caculate myCaculate;
        public Triangle_Problem.Caculate MyCaculate
        {
            get { return myCaculate; }
            set { myCaculate = value; }
        }
        //present the solution for this problem
        PresentSolution myPresent;
        public Triangle_Problem.PresentSolution MyPresent
        {
            get { return myPresent; }
            set { myPresent = value; }
        }

        //number argument
        const int num_arg = 11;

        //storage rules in list
        //in each rule, arguments is sorted in order: A, B, C, a, b, c, ha, hb, hc, p, S
        List<List<int>> list_rule;
        public List<List<int>> ListRules
        {
            get { return list_rule; }
            set { list_rule = value; }
        }

        //the hypothesis
        List<int> listKnownInit;
        public List<int> ListKnownInit
        {
            get { return listKnownInit; }
            set { listKnownInit = value; }
        }

        List<int> list_known;
        public List<int> ListKnown
        {
            get { return list_known; }
            set { list_known = value; }
        }
        //save used rules
        List<int> list_used_rule = new List<int>();

        public List<int> ListRulesUsed
        {
            get { return list_used_rule; }
        }

        //the result 
        int index_result;
        public int IndexResult
        {
            get { return index_result; }
            set { index_result = value; }
        }


        //button start click
        private void bt_start_Click(object sender, EventArgs e)
        {

            
            rTB_Result.Text = "";
            list_used_rule.Clear();

            bool _isSolve = true;

            if (CheckState())
            {
                list_known = new List<int>(ListKnownInit);

                if (cb_select.SelectedIndex != -1)
                {
                    if (rb_ForwardCharning.Checked == true)
                    {

                      
                         _isSolve = ForwardCharning();
                        


                    }
                    else
                        _isSolve = BackCharning();
                }

                if (_isSolve)
                {
                    myCaculate = new Caculate(this);
                    myCaculate.ProcessCaculate();

                    myPresent = new PresentSolution(this, this.MyCaculate);
                    myPresent.SolveProblem();
                }
            }
        }

        //initialize
        private void Init()
        {

            rb_ForwardCharning.Checked = true;

            list_rule = new List<List<int>>();

            LoadFile();

            listKnownInit = new List<int>();
        }


        //Load rules from file
        private void LoadFile()
        {
            StreamReader sr = new StreamReader("Rules.txt");
            string _line;
            //read each line
            while ((_line = sr.ReadLine()) != null)
            {
                addRule(_line);
            }
            sr.Dispose();
        }

        //read and add rules
        private void addRule(string _rule)
        {
            List<int> _list_rule = new List<int>(num_arg);
            
            //init list, set default is -1
            for (int i = 0; i < num_arg; i++)
                _list_rule.Add(-1);

            int _pos = 0, //position of current char
                _len_arg = 0; //length of argument

            int _mark_rule = 0;

            while (_rule[_pos==0 ? _pos : _pos - 1] != '.')
            {
                if (_rule[_pos] >= 'A' && _rule[_pos] <= 'z')
                    _len_arg++;
                else
                {
                    if(_pos > 1)
                        if (_rule[_pos - 1] == '-' && _rule[_pos] == '>')
                        {
                            _mark_rule = 1; //pass the "IF" clause and mark "THEN" clause is 1
                        }

                    if (_len_arg != 0)
                    {
                        string _temp_str_arg = _rule.Substring(_pos - _len_arg, _len_arg);
                        switch (_temp_str_arg)
                        {
                            case "A":
                                _list_rule[0] = _mark_rule;
                                break;
                            case "B":
                                _list_rule[1] = _mark_rule;
                                break;
                            case "C":
                                _list_rule[2] = _mark_rule;
                                break;
                            case "a":
                                _list_rule[3] = _mark_rule;
                                break;
                            case "b":
                                _list_rule[4] = _mark_rule;
                                break;
                            case "c":
                                _list_rule[5] = _mark_rule;
                                break;
                            case "ha":
                                _list_rule[6] = _mark_rule;
                                break;
                            case "hb":
                                _list_rule[7] = _mark_rule;
                                break;
                            case "hc":
                                _list_rule[8] = _mark_rule;
                                break;
                            case "p":
                                _list_rule[9] = _mark_rule;
                                break;
                            case "S":
                                _list_rule[10] = _mark_rule;
                                break;
                        }

                        _len_arg = 0; //set length of argument is 0
                    }
                }

                _pos++;
            }

            //Add to list rules
            list_rule.Add(_list_rule);
        }

        //check state of all textbox
        private bool CheckState()
        {
            ListKnownInit.Clear();

            for (int i = 0; i < num_arg; i++)
            {
                ListKnownInit.Add(-1);
            }

            if (tb_angle_a.Text != "")
            {
                ListKnownInit[0] = 0;
            }

            if (tb_angle_b.Text != "")
            {
                ListKnownInit[1] = 0;
            }

            if (tb_angle_c.Text != "")
            {
                ListKnownInit[2] = 0;
            }

            if (tb_edge_a.Text != "")
            {
                ListKnownInit[3] = 0;
            }

            if (tb_edge_b.Text != "")
            {
                ListKnownInit[4] = 0;
            }

            if (tb_edge_c.Text != "")
            {
                ListKnownInit[5] = 0;
            }

            if (tb_ha.Text != "")
            {
                ListKnownInit[6] = 0;
            }

            if (tb_hb.Text != "")
            {
                ListKnownInit[7] = 0;
            }

            if (tb_hc.Text != "")
            {
                ListKnownInit[8] = 0;
            }

            if (tb_p.Text != "")
            {
                ListKnownInit[9] = 0;
            }

            if (tb_s.Text != "")
            {
                ListKnownInit[10] = 0;
            }

            //check combobox
            if (cb_select.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn thông số cần tính!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else

                if (ListKnownInit[cb_select.SelectedIndex] == 0)
                {
                    MessageBox.Show("Thông số cần tính đã có trong giả thiết của bài toán.\n" +
                    "Bạn hãy chọn lại thông số khác!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                    index_result = cb_select.SelectedIndex;

            return true;
        }

        private bool ForwardCharning()
        {
            //Check state of all rules
            //Set default rule state is -1 
            List<int> _list_state_rule = new List<int>();

            

            for (int i = 0; i < list_rule.Count; i++)
            {
                _list_state_rule.Add(-1);
            }

            
            bool _isImplementRule = false;

            while (list_known[index_result] == -1)//trong khi chua biet ket luan
            {
                _isImplementRule = false;
                for (int i = 0; i < list_rule.Count; i++)
                {
                    if (_list_state_rule[i] == -1)
                    {
                        bool is_avail = true;
                        for (int j = 0; j < num_arg; j++)
                        {
                            //if argument in hypothesis not found in know
                            if ((list_rule[i][j] == 0 && list_known[j] != 0)
                                // if argument in conclude is in know
                                || (list_rule[i][j] == 1 && list_known[j] == 0)) 
                            {
                                is_avail = false;
                                break;
                            }
                        }

                        if (is_avail)
                        {
                            for (int j = 0; j < num_arg; j++)
                            {
                                if (list_rule[i][j] == 1)
                                {
                                    list_known[j] = 0;
                                    break;
                                }
                            }

                            list_used_rule.Add(i);
                            _isImplementRule = true;

                            //check if result is found
                            if(list_known[index_result] == 0)
                                break;

                            _list_state_rule[i] = 0;
                        }
                    }
                }

                if (!_isImplementRule)
                {
                    MessageBox.Show("Thiếu giả thiết. \n Hãy đưa thêm giả thiết cho bài toán!", 
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (_isImplementRule)
            {
                //list_used_rule = reduce_List(list_used_rule);//toi uu tap VET
                //for (int i = 0; i < list_used_rule.Count; i++)
                    //rTB_Result.Text += (getRule(list_used_rule[i] + 1) + "\n");
            }

            return true;
        }

        private bool BackCharning()


        {
            List<int> list_status = new List<int>();
            for (int i = 0; i < num_arg; i++)
                list_status.Add(-1);

                if (BackTracking(index_result, 0, list_status) == 0)
                {
                    MessageBox.Show("Không đủ điều kiện để giải bài toán, hãy đưa thêm giả thiết cho bài toán!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    //list_used_rule = reduce_List(list_used_rule);
                    //for (int i = 0; i < list_used_rule.Count; i++)
                        //rTB_Result.Text += (getRule(list_used_rule[i] + 1) + "\n");
                }

            return true;
        }



        //Back tracking
        //Return:
        //0 - Not found
        //1 - Found
        //2 - Wanted detect

        private int BackCharning_Backtracking(int _indexDest, int _levelBack, List<int> list_wanted)
        {
            list_wanted.Add(_indexDest);
            for (int i = 0; i < list_rule.Count; i++)
            {
                //Problem: A, B, c --> hc
                //check all rules if the conclude of a rule contain the dest
                if (list_rule[i][_indexDest] == 1)
                {
                    //check all arguments in hypothesis for if this argument isn't in known list
                    bool _isAble = true;

                    for (int j = 0; j < num_arg; j++)
                    {
                        //a(?), B -> hc
                        //...

                        if (list_rule[i][j] == 0 && list_known[j] != 0 && list_wanted.Contains(j))
                        {
                            _isAble = false;
                            break;
                        }

                        if (list_rule[i][j] == 0 && list_known[j] != 0 && !list_wanted.Contains(j))
                        {
                            if (_levelBack == 2)
                            {
                                int _numRule = generateAHypothesis();

                                if (_numRule == -1)
                                    return 0;

                                //find index of conclude
                                int _indexConclude = -1;
                                for (int k = 0; k < num_arg; k++)
                                    if(list_rule[_numRule][k] == 1)
                                        _indexConclude = k;

                                    //if the generated hypothesis is a wanted item
                                    if (list_wanted.Contains(_indexConclude))
                                        return 2;
                                else
                                {
                                    //break and try to generate hypothesis ultil the rule needed is sastify
                                    list_used_rule.Add(_numRule);
                                    i = 0;
                                    _isAble = false;
                                    break;
                                }
                            }
                            else
                            {
                                int _tempBackCharning = BackCharning_Backtracking(j, _levelBack + 1, list_wanted);
                                if (_tempBackCharning == 0)
                                {
                                    _isAble = false;
                                    break;
                                }
                                else
                                    if (_tempBackCharning == 2)
                                    {
                                        if (list_known[_indexDest] == 0)
                                            return 1;
                                        else
                                            return 2;
                                    }
                            }
                        }
                    }

                    if (_isAble)
                    {
                        list_used_rule.Add(i);
                        return 1;
                    }
                }
            }

            return 0;
        }


        //---------------------------------------
        //list Status:
        //0 : finding

        private int BackTracking(int _indexDest, int _levelBack, List<int> _listStatus)
        {
            //list rule contain dest
            List<int> _listRulesContainDest = new List<int>();

            for (int i = 0; i < list_rule.Count; i++)
                if (list_rule[i][_indexDest] == 1)
                    _listRulesContainDest.Add(i);

            //sort list rules contain dest by the number of hypothesis in known
            for (int i = 0; i < _listRulesContainDest.Count - 1; i++)
                for (int j = i + 1; j < _listRulesContainDest.Count; j++)
                    if(getNumberOfHypothesisInKnown(_listRulesContainDest[i])
                        < getNumberOfHypothesisInKnown(_listRulesContainDest[j]))
                    {
                        int _temp = _listRulesContainDest[i];
                        _listRulesContainDest[i] = _listRulesContainDest[j];
                        _listRulesContainDest[j] = _temp;
                    }


            for (int i = 0; i < _listRulesContainDest.Count; i++)
            {
                //Check whether a hypothesis of this rule is in list search
                // and satisfy this rule
                bool _isLoop = false;
                bool _isReady = true;
                for (int j = 0; j < num_arg; j++)
                {
                    if (list_rule[_listRulesContainDest[i]][j] == 0 && _listStatus[j] == 0)
                        _isLoop = true;
                    if (list_rule[_listRulesContainDest[i]][j] == 0 && list_known[j] != 0)
                        _isReady = false;
                }

                if (_isLoop)
                    continue;
                else
                {
                    if (_isReady)
                    {
                        list_known[_indexDest] = 0;
                        list_used_rule.Add(_listRulesContainDest[i]);
                        _listStatus[getIndexDestOfRule(_listRulesContainDest[i])] = -1;
                        return 1;
                    }
                    else
                    {
                        //if back level equal 3
                        if (_levelBack == 2)
                        {
                            //if it 's the last rule
                            if (i == _listRulesContainDest.Count - 1)
                            {
                                //generate a hypothesis
                                int _numRule = generateAHypothesis();
                                if (_numRule == -1)
                                    return 0;

                                for (int j = 0; j < num_arg; j++)
                                    if (list_rule[_numRule][j] == 1 && _listStatus[j] == 0)
                                        return 2;

                                list_used_rule.Add(_numRule);
                                _listStatus[getIndexDestOfRule(_numRule)] = -1;
                                i = 0;
                            }

                            continue;
                        }
                        else
                        {

                            bool _isAble = true;
                            for (int j = 0; j < num_arg; j++)
                            {
                                int _resultBackTracking = -1;
                                if (list_rule[_listRulesContainDest[i]][j] == 0
                                       && list_known[j] != 0)
                                {
                                    //update list status before back tracking
                                    _listStatus[j] = 0;
                                    _resultBackTracking = BackTracking(j, _levelBack + 1, _listStatus);

                                    if (_resultBackTracking == 0)
                                    {
                                        _isAble = false;
                                        break;
                                    }
                                    else
                                        if (_resultBackTracking == 1)
                                            continue;
                                        else
                                        //_resultBackTracking equal 2
                                        {
                                            if (list_known[_indexDest] == 0)
                                                return 1;
                                            else
                                                return 2;
                                        }
                                }
                            }

                            if (_isAble)
                            {
                                list_used_rule.Add(_listRulesContainDest[i]);
                                _listStatus[getIndexDestOfRule(_listRulesContainDest[i])] = -1;
                                return 1;
                            }
                        }

                    }
                }
            }

            return 0;
        }


        private string getRule(int _line_num)
        {
            string _line_text = "";
            int _endRule = 0;
            StreamReader sr = new StreamReader("Rules.txt");
            for (int i = 0; i < _line_num; i++)
                _line_text = sr.ReadLine();

            sr.Close();
            sr.Dispose();

            for (int i = 0; i < _line_text.Length; i++)
            {
                if (_line_text[i] == '.')
                {
                    _endRule = i;
                }
            }

            _line_text = _line_text.Substring(0, _endRule);
            return _line_text;
        }

       
        //genarate hypothesis base on known
        private int generateAHypothesis()
        {
            for (int i = 0; i < list_rule.Count; i++)
            {
                bool _isAble = true;
                for (int j = 0; j < num_arg; j++)
                    if ((list_rule[i][j] == 0 && list_known[j] != 0)
                        || (list_rule[i][j] == 1 && list_known[j] == 0))
                    {
                        _isAble = false;
                        break;
                    }

                //if being able to genarate a new hypothesis
                if (_isAble)
                {
                    for (int j = 0; j < num_arg; j++)
                        if (list_rule[i][j] == 1)
                        {
                            list_known[j] = 0;
                            return i;
                        }
                }
            }

            //if cannot genarate a hypothesis return -1
            return -1;
        }

        private int getNumberOfHypothesisInKnown(int _indexRule)
        {
            int numHypothesis = 0;
            for (int i = 0; i < num_arg; i++)
                //if a hypothesis in this rule is in known
                if (list_rule[_indexRule][i] == list_known[i])
                    numHypothesis++;
            return numHypothesis;
        }

        private int getIndexDestOfRule(int _numrule)
        {
            for (int i = 0; i < num_arg; i++)
                if(list_rule[_numrule][i] == 1)
                    return i;

            return -1;
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save As";
            sfd.Filter = "Text Documents|*.txt|All Files|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write(RTB_Result.Text);
                bw.Close();
                bw.Dispose();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frm_About()).ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tb_angle_a.Text = tb_angle_b.Text = tb_angle_c.Text = tb_edge_a.Text = tb_edge_b.Text = tb_edge_c.Text = tb_ha.Text = tb_hb.Text = tb_hc.Text = tb_p.Text = tb_s.Text = rTB_Result.Text = "";
            tb_angle_a.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ////loai bo cac luat du thua trong tap VET
        private List<int> reduce_List(List<int> _list_full)
        {
            List<int> _list_temp = new List<int>();

            //position of last rule in _list_full
            int _pos_last_rule = _list_full.Count - 1;

            _list_temp.Add(_list_full[_pos_last_rule]);

            for (int i = _list_full.Count - 2; i >= 0; i--)
            {
                //check whether the result of the rule before last is in the "IF" clause of last rule
                for (int j = 0; j < num_arg; j++)
                    if (list_rule[_list_full[i]][j] == 1)
                    {
                        //check whether a before rule contain this 
                        bool _isContain = false;
                        for (int k = i + 1; k < _list_full.Count; k++)
                            if (list_rule[_list_full[k]][j] == 0)
                            {
                                _isContain = true;
                                break;
                            }

                        if (_isContain)
                        {
                            _pos_last_rule = i;
                            _list_temp.Add(_list_full[_pos_last_rule]);
                            break;
                        }
                    }
            }

            _list_temp.Reverse();
            return _list_temp;
        }



    }
}
