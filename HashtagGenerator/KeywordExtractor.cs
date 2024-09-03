using System.Collections.Generic;
using System.Linq;

namespace HashtagGenerator;
public class KeywordExtractor
{
    public static List<string> ExtractKeywords(string[] tokens)
    {
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
        foreach (string token in tokens)
        {
            if (frequencyMap.ContainsKey(token))
            {
                frequencyMap[token]++;
            }
            else
            {
                frequencyMap[token] = 1;
            }
        }

        // Sort words by frequency and select top keywords
        List<string> keywords = frequencyMap
            .OrderByDescending(pair => pair.Value)
            .Select(pair => pair.Key)
            .Take(5) // You can adjust the number of keywords as needed
            .ToList();

        return keywords;
    }
}
