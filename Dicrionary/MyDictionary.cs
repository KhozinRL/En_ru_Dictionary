using System;
using System.Collections.Generic;
using System.Text;

public class MyDictionary
{
    private Dictionary<string, HashSet<string>> dictionaryList = new Dictionary<string, HashSet<string>>();


	public MyDictionary()
	{
        Add("car", new HashSet<string> { "машина" });
        Add("verbose", new HashSet<string> { "подробный", "многословный" });
        Add("waiter", new HashSet<string> { "официант", "поднос", "подавальщик" });
        Add("радуга", new HashSet<string> { "rainbow" });
    }

    public void Add(string word, HashSet<string> translations)
    {
        word = word.ToLower().Trim();
        if (word == "")
            return;

        string s;
        HashSet<string> lowerHashSet = new HashSet<string>();

        foreach (string str in translations) { 
            s = str.ToLower().Trim();
            if (s == "") continue;

            lowerHashSet.Add(s);
            addTranslation(s, word);
        }

        if (lowerHashSet.Count != 0)
            addTranslations(word, lowerHashSet);
    }

    //Добавляет набор переводов
    private void addTranslations(string word, HashSet<string> translations) {
        if (dictionaryList.ContainsKey(word))
        {
            dictionaryList[word].UnionWith(translations);
        }
        else {
            dictionaryList.Add(word, translations);
        }
    }

    //Добавляет единственный перевод
    private void addTranslation(string word, string translation) {
        if (dictionaryList.ContainsKey(word))
        {
            dictionaryList[word].Add(translation);
        }
        else {
            dictionaryList.Add(word, new HashSet<string> { translation });
        }
    }

    public HashSet<string> GetTranslation(string word) {
        HashSet<string> result;
        return dictionaryList.TryGetValue(word, out result) ? result : new HashSet<string>();
    }

    override
    public string ToString() {
        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<string, HashSet<string>> kvp in dictionaryList){
            sb.Append(kvp.Key).Append(" : ");
            foreach (string str in kvp.Value) {
                sb.Append(str).Append(", ");
            }
            sb.Remove(sb.Length - 2, 2).Append('\n'); ;
        }
        return sb.ToString();
    }
}
