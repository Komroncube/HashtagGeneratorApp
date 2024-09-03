using HashtagGenerator;
using System;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

Console.Write("Input your post: ");
string inputText = Console.ReadLine();
string userPost = "Excited to start my new adventure in Spain! Check out my blog at http://example.com #travel";

userPost = string.IsNullOrEmpty(inputText) ? userPost : inputText;

string cleanedText = TextProcessor.CleanText(userPost);
string[] tokens = TextProcessor.TokenizeText(cleanedText);
List<string> keywords = KeywordExtractor.ExtractKeywords(tokens);

foreach (string keyword in keywords)
{
    HashtagRepository.AddOrUpdateHashtag(keyword, true); // Assuming all keywords initially have frequency 1 and are trending
}

List<string> topHashtags = HashtagRepository.GetTopHashtags(3);
Console.WriteLine("Top Hashtags:");
foreach (var hashtag in topHashtags)
{
    Console.WriteLine(hashtag);
}