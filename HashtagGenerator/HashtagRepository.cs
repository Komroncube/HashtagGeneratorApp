using System.Collections.Generic;
using System.Linq;

namespace HashtagGenerator;
public class HashtagRepository
{
    private static readonly List<HashtagRelevance> hashtags = [];

    // Simulate adding a hashtag to the repository
    public static void AddOrUpdateHashtag(string hashtag, bool isTrending)
    {
        HashtagRelevance existingHashtag = hashtags.FirstOrDefault(h => h.Hashtag == hashtag);
        if (existingHashtag is not null)
        {
            existingHashtag.Frequency++;
            existingHashtag.IsTrending = isTrending;
            existingHashtag.CalculateRelevanceScore();
        }
        else
        {
            hashtags.Add(new HashtagRelevance(hashtag, 1, isTrending));
        }
    }

    // Simulate getting all hashtags from the repository
    public static List<HashtagRelevance> GetHashtags()
    {
        return new List<HashtagRelevance>(hashtags);
    }

    public static List<string> GetTopHashtags(int topN)
    {
        // Filter hashtags by relevance score and return the top N
        return hashtags.Where(h => h.RelevanceScore > 5) // Filter out low-scoring hashtags
                        .OrderByDescending(h => h.RelevanceScore)
                        .Select(h => h.Hashtag)
                        .Take(topN)
                        .ToList();
    }
}
