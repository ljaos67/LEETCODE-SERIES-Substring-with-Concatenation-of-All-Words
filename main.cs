
public class Solution {

    private bool CheckSubstring(Dictionary<string, int> wordCount, string s, int wordLen) {
        Dictionary<string, int> seenWords = new Dictionary<string, int>(wordCount);
        for(int j = 0; j < s.Length; j += wordLen) {
            string w = s.Substring(j, wordLen);
            if(seenWords.ContainsKey(w)) {
                seenWords[w]--;
                if(seenWords[w] < 0) {
                    return false;
                }
            } else {
                return false;
            }
        }
        return true;
    }

    public IList<int> FindSubstring(string s, string[] words) {
        List<int> res = new List<int>();
        int wordLen = words[0].Length;
        int sLen = s.Length;
        int wordsWindow = words.Length * wordLen;
        
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach(var word in words) {
            if(wordCount.ContainsKey(word)) wordCount[word]++;
            else wordCount.Add(word, 1);
        }
        
        int i = 0;
        while(i + wordsWindow <= sLen) {
            if(CheckSubstring(new Dictionary<string, int>(wordCount), s.Substring(i, wordsWindow), wordLen)) {
                res.Add(i);
            }
            i++;
        }
        return res;
    }
}
