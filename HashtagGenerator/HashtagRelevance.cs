namespace HashtagGenerator;
public class HashtagRelevance
{
    public string Hashtag { get; set; }
    public int Frequency { get; set; }
    public bool IsTrending { get; set; }
    public double RelevanceScore { get; set; }

    public HashtagRelevance(string hashtag, int frequency, bool isTrending)
    {
        Hashtag = hashtag;
        Frequency = frequency;
        IsTrending = isTrending;
        CalculateRelevanceScore();
    }

    public void CalculateRelevanceScore()
    {
        // Basic scoring logic: frequency score + trend bonus
        RelevanceScore = Frequency;
        if (IsTrending)
        {
            RelevanceScore += 10; // Add a bonus score if the hashtag is trending
        }
    }
}
