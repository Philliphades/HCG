using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Triangle_Problem
{
    public class PresentSolution
    {
        FormMain mainForm;

        Caculate problemCaculate;
        

        const int num_arg = 11;

        
        public PresentSolution(FormMain form, Caculate _cal)
        {
            mainForm = form;
            problemCaculate = _cal;
            

        }

        public void SolveProblem()
        {
            presentProblem();

            if (mainForm.Rb_ForwardCharning.Checked)
                presentForwardCharningSolution();
            else
                presentBackCharningSolution();
        }

        //Present Problem
        private void presentProblem()
        {
            string _problemPresentation = "";
            _problemPresentation += "\t\t-------------------- BÀI TOÁN TAM GIÁC -------------------- \n\n\n"
                + "Giả thiết: \n";
            for (int i = 0; i < num_arg; i++)
            {
                if (mainForm.ListKnownInit[i] == 0)
                {
                    switch (i)
                    {
                        case 0:
                            _problemPresentation += "- Góc A: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 1:
                            _problemPresentation += "- Góc B: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 2:
                            _problemPresentation += "- Góc C: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 3:
                            _problemPresentation += "- Cạnh a: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 4:
                            _problemPresentation += "- Cạnh b: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 5:
                            _problemPresentation += "- Cạnh c: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 6:
                            _problemPresentation += "- Chiều cao ha: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 7:
                            _problemPresentation += "- Chiều cao hb: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 8:
                            _problemPresentation += "- Chiều cao hc: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 9:
                            _problemPresentation += "- Nửa chu vi p: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                        case 10:
                            _problemPresentation += "- Diện tích S: "
                                + problemCaculate.ListValue[i] + ".\n";
                            break;
                    }
                }
            }

            _problemPresentation += "\nKết luận:\n";
           
            switch (mainForm.IndexResult)
            {
                case 0:
                    _problemPresentation += "- Tính góc A ?\n";
                    break;
                case 1:
                    _problemPresentation += "- Tính góc B ?\n";
                    break;
                case 2:
                    _problemPresentation += "- Tính góc C ?\n";
                    break;
                case 3:
                    _problemPresentation += "- Tính độ dài cạnh a ?\n";
                    break;
                case 4:
                    _problemPresentation += "- Tính độ dài cạnh b ?\n";
                    break;
                case 5:
                    _problemPresentation += "- Tính độ dài cạnh c ?\n";
                    break;
                case 6:
                    _problemPresentation += "- Tính độ dài đường cao ha ?\n";
                    break;
                case 7:
                    _problemPresentation += "- Tính độ dài đường cao hb ?\n";
                    break;
                case 8:
                    _problemPresentation += "- Tính độ dài đường cao hc ?\n";
                    break;
                case 9:
                    _problemPresentation += "- Tính nửa chu vi tam giác p ?\n";
                    break;
                case 10:
                    _problemPresentation += "- Tính diện tích tam giác S ?\n";
                    break;
            }

            _problemPresentation += "\n\t Bài làm:\n\n";

            mainForm.RTB_Result.Text += _problemPresentation;
        }

        //Present Solution
        //Forward Charning
        private void presentForwardCharningSolution()
        {
            string _strForwardCharning = "";
            for (int i = 0; i < mainForm.ListRulesUsed.Count; i++)
            {
                if (mainForm.ListRulesUsed.Count > 1)
                    _strForwardCharning += "* Bước " + (i + 1) + ": ";
                else
                    _strForwardCharning += "* ";
                for (int j = 0; j < num_arg; j++)
                {
                    if (mainForm.ListRules[mainForm.ListRulesUsed[i]][j] == 1)
                    {
                        switch (j)
                        {
                            case 0:
                                _strForwardCharning += "Tính góc A\n"
                                    + "- Áp dụng công thức: A = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: A = " + problemCaculate.ListValue[0] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy giá trị của góc A cần tìm là "
                                                        + problemCaculate.ListValue[0] + " độ.\n";
                                break;
                            case 1:
                                _strForwardCharning += "Tính góc B\n"
                                    + "- Áp dụng công thức: B = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: B = " + problemCaculate.ListValue[1] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy giá trị của góc B cần tính là "
                                                        + problemCaculate.ListValue[1] + " độ.\n";
                                break;
                            case 2:
                                _strForwardCharning += "Tính góc C\n"
                                    + "- Áp dụng công thức: C = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: C = " + problemCaculate.ListValue[2] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy giá trị của góc C cần tính là "
                                                        + problemCaculate.ListValue[2] + " độ.\n";
                                break;
                            case 3:
                                _strForwardCharning += "Tính độ dài cạnh a\n"
                                    + "- Áp dụng công thức: a = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: a = " + problemCaculate.ListValue[3] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy độ dài của cạnh a cần tính là "
                                                        + problemCaculate.ListValue[3] + ".\n";
                                break;
                            case 4:
                                _strForwardCharning += "Tính độ dài cạnh b\n"
                                    + "- Áp dụng công thức: b = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: b = " + problemCaculate.ListValue[4] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy độ dài của cạnh b cần tính là "
                                                        + problemCaculate.ListValue[4] + ".\n";
                                break;
                            case 5:
                                _strForwardCharning += "Tính độ dài cạnh c\n"
                                    + "- Áp dụng công thức: c = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: c = " + problemCaculate.ListValue[5] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy độ dài của cạnh c cần tính là "
                                                        + problemCaculate.ListValue[5] + ".\n";
                                break;
                            case 6:
                                _strForwardCharning += "Tính độ dài đường cao ha\n"
                                    + "- Áp dụng công thức: ha = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: ha = " + problemCaculate.ListValue[6] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy độ dài của đường cao ha cần tính là "
                                                        + problemCaculate.ListValue[6] + ".\n";
                                break;
                            case 7:
                                _strForwardCharning += "Tính độ dài đường cao hb\n"
                                    + "- Áp dụng công thức: hb = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: hb = " + problemCaculate.ListValue[7] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy độ dài của đường cao hb cần tính là "
                                                        + problemCaculate.ListValue[7] + ".\n";
                                break;
                            case 8:
                                _strForwardCharning += "Tính độ dài đường cao hc\n"
                                    + "- Áp dụng công thức: hc = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: hc = " + problemCaculate.ListValue[8] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy độ dài của đường cao hc cần tính là "
                                                        + problemCaculate.ListValue[8] + ".\n";
                                break;
                            case 9:
                                _strForwardCharning += "Tính độ dài nửa chu vi p\n"
                                    + "- Áp dụng công thức: p = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: p = " + problemCaculate.ListValue[9] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy giá trị của nửa chu vi tam giác p cần tính là "
                                                        + problemCaculate.ListValue[9] + ".\n";
                                break;
                            case 10:
                                _strForwardCharning += "Tính diện tích S\n"
                                    + "- Áp dụng công thức: S = " + getFormula(mainForm.ListRulesUsed[i]) + "\n"
                                    + "   Ta tính được: S = " + problemCaculate.ListValue[10] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strForwardCharning += "\nKết luận: Vậy diện tích S của tam giác cần tính là "
                                                        + problemCaculate.ListValue[10] + ".\n";
                                break;
                        }

                        break;
                    }
                }
            }

            mainForm.RTB_Result.Text += _strForwardCharning;
        }

        //Back Charning
        private void presentBackCharningSolution()
        {
            string _strBackCharning = "";
            _strBackCharning += "* Quá trình suy diễn lùi: \n";
            for (int i = mainForm.ListRulesUsed.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < num_arg; j++)
                {
                    if (mainForm.ListRules[mainForm.ListRulesUsed[i]][j] == 1)
                        switch (j)
                        {
                            case 0:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(0, i) +
                                        ") ta cần đi tìm A: \n";

                                _strBackCharning += "   - Để tính được A, ta dùng công thức: \n\t"
                                                 + "A = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị A cần tìm" + 
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        "sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 1:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(1, i) +
                                        ") ta cần đi tìm B: \n";

                                _strBackCharning += "   - Để tính được B, ta dùng công thức: \n\t"
                                                 + "B = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị B cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 2:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(2, i) +
                                        ") ta cần đi tìm C: \n";

                                _strBackCharning += "   - Để tính được C, ta dùng công thức: \n\t"
                                                 + "C = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị C cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 3:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + (getIndexOfRuleContain(3, i)) +
                                        ") ta cần đi tìm a: \n";

                                _strBackCharning += "   - Để tính được a, ta dùng công thức: \n\t"
                                                 + "a = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị a cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 4:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(4, i) +
                                        ") ta cần đi tìm b: \n";

                                _strBackCharning += "   - Để tính được b, ta dùng công thức: \n\t"
                                                 + "b = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị b cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 5:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(5, i) +
                                        ") ta cần đi tìm c: \n";

                                _strBackCharning += "   - Để tính được c, ta dùng công thức: \n\t"
                                                 + "c = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị c cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 6:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(6, i) +
                                        ") ta cần đi tìm ha: \n";

                                _strBackCharning += "   - Để tính được ha, ta dùng công thức: \n\t"
                                                 + "ha = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị ha cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 7:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(7, i) +
                                        ") ta cần đi tìm hb: \n";

                                _strBackCharning += "   - Để tính được hb, ta dùng công thức: \n\t"
                                                 + "hb = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị hb cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 8:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(8, i) +
                                        ") ta cần đi tìm hc: \n";

                                _strBackCharning += "   - Để tính được hc, ta dùng công thức: \n\t"
                                                 + "hc = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị hc cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 9:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(9, i) +
                                        ") ta cần đi tìm p: \n";

                                _strBackCharning += "   - Để tính được p, ta dùng công thức: \n\t"
                                                 + "p = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị p cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                            case 10:
                                if (i < mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "+ Để suy ra được (" + getIndexOfRuleContain(10, i) +
                                        ") ta cần đi tìm S: \n";

                                _strBackCharning += "   - Để tính được S, ta dùng công thức: \n\t"
                                                 + "S = " + getFormula(mainForm.ListRulesUsed[i]) + "\t\t (" +
                                                 (mainForm.ListRulesUsed.Count - i) + ")\n\n";

                                if (i == 0)
                                    _strBackCharning += "--> Áp dụng (" + (mainForm.ListRulesUsed.Count - i) +
                                        ") ta tìm được giá trị S cần tìm" +
                                        ((mainForm.ListRulesUsed.Count > 1) ?
                                        " sau đó thay ngược trở lại để tìm được kết quả của bài toán. \n" : ". \n");
                                break;
                        }
                }
            }

            //caculate 
            for (int i = 0; i < mainForm.ListRulesUsed.Count; i++)
            {
                for (int j = 0; j < num_arg; j++)
                {
                    if (mainForm.ListRules[mainForm.ListRulesUsed[i]][j] == 1)
                    {
                        switch (j)
                        {
                            case 0:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tA = " + problemCaculate.ListValue[0] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy giá trị của góc A cần tìm là "
                                                        + problemCaculate.ListValue[0] + " độ.\n";
                                break;
                            case 1:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tB = " + problemCaculate.ListValue[1] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy giá trị của góc B cần tính là "
                                                        + problemCaculate.ListValue[1] + " độ.\n";
                                break;
                            case 2:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tC = " + problemCaculate.ListValue[2] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy giá trị của góc C cần tính là "
                                                        + problemCaculate.ListValue[2] + " độ.\n";
                                break;
                            case 3:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\ta = " + problemCaculate.ListValue[3] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy độ dài của cạnh a cần tính là "
                                                        + problemCaculate.ListValue[3] + ".\n";
                                break;
                            case 4:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tb = " + problemCaculate.ListValue[4] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy độ dài của cạnh b cần tính là "
                                                        + problemCaculate.ListValue[4] + ".\n";
                                break;
                            case 5:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tc = " + problemCaculate.ListValue[5] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy độ dài của cạnh c cần tính là "
                                                        + problemCaculate.ListValue[5] + ".\n";
                                break;
                            case 6:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tha = " + problemCaculate.ListValue[6] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy độ dài của đường cao ha cần tính là "
                                                        + problemCaculate.ListValue[6] + ".\n";
                                break;
                            case 7:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\thb = " + problemCaculate.ListValue[7] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy độ dài của đường cao hb cần tính là "
                                                        + problemCaculate.ListValue[7] + ".\n";
                                break;
                            case 8:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\thc = " + problemCaculate.ListValue[8] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy độ dài của đường cao hc cần tính là "
                                                        + problemCaculate.ListValue[8] + ".\n";
                                break;
                            case 9:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tp = " + problemCaculate.ListValue[9] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy giá trị của nửa chu vi tam giác p cần tính là "
                                                        + problemCaculate.ListValue[9] + ".\n";
                                break;
                            case 10:
                                _strBackCharning += "+ Từ (" + (mainForm.ListRulesUsed.Count - i) +
                                                        "):" +
                                                        "\tS = " + problemCaculate.ListValue[10] + "\n";
                                if (i == mainForm.ListRulesUsed.Count - 1)
                                    _strBackCharning += "\nKết luận: Vậy diện tích S của tam giác cần tính là "
                                                        + problemCaculate.ListValue[10] + ".\n";
                                break;
                        }
                    }
                }
            }

            mainForm.RTB_Result.Text += _strBackCharning;
        }

        //Get formula from file
        private string getFormula(int _indexExp)
        {
            string _temp_str = "";
            StreamReader sr = new StreamReader("Rules.txt");
            for (int i = 0; i < _indexExp + 1; i++)
                _temp_str = sr.ReadLine();
            sr.Close();
            sr.Dispose();

            _temp_str = _temp_str.Substring(_temp_str.IndexOf('.') + 1);

            return _temp_str;
        }

        //Get index of rule contain the argument
        private int getIndexOfRuleContain(int _indexArg, int _currentRule)
        {
            for (int i = mainForm.ListRulesUsed.Count - 1; i > _currentRule; i-- )
            {
                if (mainForm.ListRules[mainForm.ListRulesUsed[i]][_indexArg] == 0)
                    return mainForm.ListRulesUsed.Count - i;
            }
            return -1;
        }

    }
}
