using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace pp_lr_1
{
    public class Refactor
    {
        private Refactor()
        {
            _methodName = "";
            _selectedText = "";
            _fullProgramText = "";
            _newFullProgramText = "";
            _newMethod = "";
            _newMethodCall = "";
            _notToRefactor = "";
            _startPositionOfSelectedText = 0;
        }

        public Refactor(string MethodName, string SelectedText, string FullProgramText)
            : this()
        {
            _methodName = MethodName;
            _selectedText = SelectedText;
            _fullProgramText = FullProgramText;
            _startPositionOfSelectedText = FullProgramText.IndexOf(SelectedText);
            NewFullText();
        }


        private string _methodName;
        private string _selectedText;
        private string _fullProgramText;
        private string _newFullProgramText;
        private string _newMethod;
        private string _newMethodCall;
        private string _notToRefactor;
        private int _startPositionOfSelectedText;
        public string NewFullProgramText { get{ return _newFullProgramText; } }

        // ищет название переменной (без знаков присваивания и пробельных символов)
        private string _patternVariable = "(_*[a-zA-Z][0-9a-zA-Z]*)";
        // ищет название переменной только если она создана ранее
        private string _patternLeftPartSimple = "(\\s*[^.]_*[a-zA-Z][0-9a-zA-Z]*\\s(=|-=|\\+=|\\*=|/=|%=)\\s)";
        // ищет название объекта только если он создан ранее
        private string _patternLeftPartComplex = "(\\s*_*[a-z][a-zA-Z0-9]*\\.[a-zA-Z][a-zA-Z0-9]*(\\(_?[a-z][a-zA-Z0-9]*(,\\s_?[a-z][a-zA-Z0-9]*)*\\))?\\s(=|-=|\\+=|\\*=|/=|%=)\\s)";
        // ищет присваемую часть, а именно присваемое число, символ или строку
        private string _patternRightPartSimple = "(\\s(=|-=|\\+=|\\*=|/=|%=)\\s(-?[0-9]+(\\.[0-9]+)?(\\s(-|\\+|\\*|/|%)\\s[0-9]+(\\.[0-9]+)?)*|'(\\d|\\D)'|@?\"(\\d|\\D)*\"(\\s\\+\\s(\"(\\d|\\D)*\"|'(\\d|\\D)'))*);(\\s)*)";
        // ищет присваемую часть, а именно обьекты структур или классов (в скобках, если они есть, только переменные) или простые переменные
        private string _patternRightPartComplex = "(\\s(=|-=|\\+=|\\*=|/=|%=)\\s((_*[a-z][a-zA-Z0-9]*(\\.[a-zA-Z][a-zA-Z0-9]*(\\(_?[a-z][a-zA-Z0-9]*(,\\s_?[a-z][a-zA-Z0-9]*)*\\))?)*))(\\s(-|\\+|\\*|/|%)\\s((_*[a-z][a-zA-Z0-9]*(\\.[a-zA-Z][a-zA-Z0-9]*(\\(_?[a-z][a-zA-Z0-9]*(,\\s_?[a-z][a-zA-Z0-9]*)*\\))?)*)))*;(\\s)*)";
        // ищет обьявление переменных
        private string _patternLocalVariables = "(\\s*(((u|U)?(i|I)nt(|16|32|64))|((U)?(i|I)ntPtr)|((c|C)har)|((s|S)tring)|((f|F)loat)|((d|D)ouble)|((d|D)ecimal)|((b|B)ool)|((s|S)?(b|B)yte)|((u)?long)|((u)?short)|([A-Z][a-zA-Z]+(<[a-zA-Z][a-zA-Z0-9]*>)))\\s*_*[a-z][0-9a-zA-Z]*)";
        // ищет ветвления
        private string _patternSearchIfStatement = "(\\s*if\\s\\((!)?((_*[a-zA-Z][0-9a-zA-Z]*)|true|false|[0-9]+|'(\\d|\\D)'|@?\"(\\d|\\D)*\")(\\s?(==|!=|>=|<=|>|<)\\s?(!)?((_*[a-zA-Z][0-9a-zA-Z]*)|true|false|[0-9]+|'(\\d|\\D)'|@?\"(\\d|\\D)*\"))?\\)\\s*{?(\\d|\\D)*}?)";
        // ищет циклы
        private string _patternLoopSearch = "(\\s*for\\s?\\(\\s?((u)?int(|16|32|64)|float|double)?\\s?_*[a-zA-Z][0-9a-zA-Z]*\\s?=\\s?(_*[a-zA-Z][0-9a-zA-Z]*|[0-9]+(\\.[0-9]+)?)\\s?;\\s?(_*[a-zA-Z][0-9a-zA-Z]*|[0-9]+(\\.[0-9]+)?)\\s?(==|!=|>=|<=|>|<)\\s?(_*[a-zA-Z][0-9a-zA-Z]*|[0-9]+(\\.[0-9]+)?)\\s?;\\s?(\\+\\+)?(_*[a-zA-Z][0-9a-zA-Z]*)(\\+\\+)?(\\s?(\\+=|\\*=|/=|-=)\\s?((_*[a-zA-Z][0-9a-zA-Z]*)|[0-9]+))?\\s?\\)\\s*{?(\\d|\\D)*}?)";

        private void NewFullText()
        {
            ExtractLocalInitializationOfVariablesFromSelectedText();
            NewMethodCreation();
            NewMethodCallCreation();

            _newFullProgramText = (_fullProgramText.Replace(_notToRefactor, "")).Replace(_selectedText, _notToRefactor + "\n" + _newMethodCall);

            int countOpenBrace = 0, countCloseBrace = 0, startIndexForNewMethod = 0;
            int startIndex = _newFullProgramText.IndexOf(_newMethodCall);
            for (int i = startIndex; i < _newFullProgramText.Length; ++i)
            {
                if (_newFullProgramText[i] == '{')
                    countOpenBrace++;
                else if (_newFullProgramText[i] == '}')
                    countCloseBrace++;

                if (countCloseBrace - countOpenBrace == 1)
                {
                    startIndexForNewMethod = i;
                    break;
                }
            }

            string partBeforeNewMethod = "", partAfterNewMethod = "";
            partAfterNewMethod = _newFullProgramText.Remove(0, startIndexForNewMethod + 1);
            partBeforeNewMethod = _newFullProgramText.Remove(startIndexForNewMethod + 1);

            _newFullProgramText = partBeforeNewMethod + "\n\n" + _newMethod + "\n" + partAfterNewMethod;
        }

        private void NewMethodCreation()
        {
            _newMethod = "private void " + _methodName + "(" + GetMethodAttributes() + ")\n{\n\t"
                + _selectedText + "\n}\n";
        }

        private void NewMethodCallCreation()
        {
            _newMethodCall = _methodName + "(" + 
                ((" " + _newMethodCall).TrimEnd().Replace(" ", ", ").Replace("ref", "ref ")).TrimStart(',', ' ') + ");";
        }

        private void ExtractLocalInitializationOfVariablesFromSelectedText()
        {
            int startIndex = 0, endIndex = 0;
            string matchedString = "";
            Regex regex = new Regex(_patternLocalVariables);

            while (regex.IsMatch(_selectedText, startIndex))
            {
                matchedString = regex.Match(_selectedText, startIndex).ToString();
                startIndex = _selectedText.IndexOf(matchedString);
                endIndex = _selectedText.IndexOf(";", startIndex) + 1;
                matchedString = (_selectedText.Length - endIndex != 0) ?
                    _selectedText.Remove(0, startIndex).Remove(endIndex - startIndex) :
                    _selectedText.Remove(0, startIndex);
                _selectedText = _selectedText.Replace(matchedString, "");
                _fullProgramText = _fullProgramText.Replace(matchedString, "");
                _notToRefactor += matchedString;
                startIndex = endIndex = 0;
            }
        }

        private string GetMethodAttributes()
        {
            List<string> variablesLPList = GetVariablesLeftPart();
            List<string> variablesRPList = GetVariablesRightPart();
            List<string> variablesAndTypesList = VariablesTypeSearch(variablesLPList, variablesRPList);
            string methodAttributes = "";

            for (int i = 0; i < variablesAndTypesList.Count; ++i)
            {
                methodAttributes += "ref " + variablesAndTypesList[i];
                if (i + 1 != variablesAndTypesList.Count)
                    methodAttributes += ", ";
            }

            return methodAttributes;
        }

        private List<string> GetVariablesLeftPart()
        {
            int startIndex = 0, endIndex = 0;
            string matchedString = "";
            List<string> variablesLPList = new List<string>();
            Regex regexLPS = new Regex(_patternLeftPartSimple);
            Regex regexLPC = new Regex(_patternLeftPartComplex);
            Regex regexV = new Regex(_patternVariable);

            while (true)
            {
                if (regexLPS.IsMatch(_selectedText, startIndex) || regexLPC.IsMatch(_selectedText, startIndex))
                {
                    if (regexLPS.IsMatch(_selectedText, startIndex))
                    {
                        matchedString = regexLPS.Match(_selectedText, startIndex).ToString();
                        startIndex = _selectedText.IndexOf(matchedString);
                        endIndex = _selectedText.IndexOf(";", startIndex) + 1;
                        variablesLPList.Add(regexV.Match(matchedString).ToString());
                        startIndex = endIndex;
                        continue;
                    }
                    if (regexLPC.IsMatch(_selectedText, startIndex))
                    {
                        matchedString = regexLPC.Match(_selectedText, startIndex).ToString();
                        startIndex = _selectedText.IndexOf(matchedString);
                        endIndex = _selectedText.IndexOf(";", startIndex) + 1;
                        variablesLPList.Add(regexV.Match(matchedString).ToString());
                        startIndex = endIndex;
                        continue;
                    }
                }
                else
                {
                    for (int i = 0; i < variablesLPList.Count; ++i)
                    {
                        _newMethodCall += "ref" + variablesLPList[i] + " ";
                    }
                    
                    break;
                }
            }

            return variablesLPList;
        }

        private List<string> GetVariablesRightPart()
        {
            int startIndex = 0, endIndex = 0;
            string matchedString = "";
            List<string> variablesRPList = new List<string>();
            Regex regexRPS = new Regex(_patternRightPartSimple);
            Regex regexRPC = new Regex(_patternRightPartComplex);
            Regex regexV = new Regex(_patternVariable);

            while (true)
            {
                if (regexRPS.IsMatch(_selectedText, startIndex) || regexRPC.IsMatch(_selectedText, startIndex))
                {
                    if (regexRPC.IsMatch(_selectedText, startIndex))
                    {
                        matchedString = regexRPC.Match(_selectedText, startIndex).ToString();
                        startIndex = _selectedText.IndexOf(matchedString);
                        endIndex = _selectedText.IndexOf(";", startIndex) + 1;
                        variablesRPList.Add(regexV.Match(matchedString).ToString());
                        startIndex = endIndex;
                        continue;
                    }
                    if (regexRPS.IsMatch(_selectedText, startIndex))
                    {
                        for (int i = 0; i < variablesRPList.Count; ++i)
                        {
                            _newMethodCall += "ref" + variablesRPList[i] + " ";
                        }

                        break;
                    }
                }
                else
                {
                    for (int i = 0; i < variablesRPList.Count; ++i)
                    {
                        _newMethodCall += "ref" + variablesRPList[i] + " ";
                    }

                    break;
                }
            }

            return variablesRPList;
        }

        private List<string> VariablesTypeSearch(List<string> variablesLPList, List<string> variablesRPList)
        {
            Regex regexLV = new Regex(_patternLocalVariables);
            List<string> variablesAndTypesList = new List<string>();
            int startIndexOfSelectedText = _fullProgramText.IndexOf(_selectedText);
            string dataBeforeSelectedText = _fullProgramText.Remove(startIndexOfSelectedText);
            int startIndex = 0, endIndex = 0;
            string matchedString = "";
            
            for (int i = 0; i < variablesLPList.Count;)
            {
                // чтоб небыло зацикливания из-за вырезаных переменных (они еще не перемещены в основной код, но уже там ищутся)
                if (_notToRefactor.IndexOf(" " + variablesLPList[i]) != -1)
                {
                    int localStartIndex = 0, localEndIndex = 0;
                    matchedString = regexLV.Match(_notToRefactor, localStartIndex).ToString();
                    localStartIndex = _notToRefactor.IndexOf(matchedString);
                    localEndIndex = _notToRefactor.IndexOf(";", localStartIndex) + 1;
                    matchedString = matchedString.Replace("\n", "").Replace("\r", "").TrimStart();
                    variablesAndTypesList.Add(matchedString);
                    ++i;
                    continue;
                }
                matchedString = regexLV.Match(dataBeforeSelectedText, startIndex).ToString();
                startIndex = dataBeforeSelectedText.IndexOf(matchedString);
                endIndex = dataBeforeSelectedText.IndexOf(";", startIndex) + 1;
                if (matchedString.LastIndexOf(" " + variablesLPList[i]) != -1)
                {
                    matchedString = matchedString.Replace("\n", "").Replace("\r", "").TrimStart();
                    variablesAndTypesList.Add(matchedString);
                    ++i;
                }
                startIndex = endIndex;
            }

            startIndex = endIndex = 0;
            for (int i = 0; i < variablesRPList.Count;)
            {
                // чтоб небыло зацикливания из-за вырезаных переменных (они еще не перемещены в основной код, но уже там ищутся)
                if (_notToRefactor.IndexOf(" " + variablesRPList[i]) != -1)
                {
                    int localStartIndex = 0, localEndIndex = 0;
                    matchedString = regexLV.Match(_notToRefactor, localStartIndex).ToString();
                    localStartIndex = _notToRefactor.IndexOf(matchedString);
                    localEndIndex = _notToRefactor.IndexOf(";", localStartIndex) + 1;
                    matchedString = matchedString.Replace("\n", "").Replace("\r", "").TrimStart();
                    variablesAndTypesList.Add(matchedString);
                    ++i;
                    continue;
                }
                matchedString = regexLV.Match(dataBeforeSelectedText, startIndex).ToString();
                startIndex = dataBeforeSelectedText.IndexOf(matchedString);
                endIndex = dataBeforeSelectedText.IndexOf(";", startIndex) + 1;
                if (matchedString.LastIndexOf(" " + variablesRPList[i]) != -1)
                {
                    matchedString = matchedString.Replace("\n", "").Replace("\r", "").TrimStart();
                    variablesAndTypesList.Add(matchedString);
                    ++i;
                }
                startIndex = endIndex;
            }

            return variablesAndTypesList;
        }
    }
}
