using System;
using System.Text.RegularExpressions;

namespace HashtagGenerator;
public class TextProcessor
{
    public static string CleanText(string input)
    {
        // Convert to lowercase
        string cleanedText = input.ToLower();

        // Remove URLs
        cleanedText = Regex.Replace(cleanedText, @"http[^\s]+", "");

        // Remove special characters and numbers
        cleanedText = Regex.Replace(cleanedText, @"[^a-zA-Z\s]", "");

        // Replace multiple whitespaces with a single space
        cleanedText = Regex.Replace(cleanedText, @"\s+", " ");

        // Trim leading and trailing whitespaces
        cleanedText = cleanedText.Trim();

        return cleanedText;
    }

    public static string[] TokenizeText(string cleanedText)
    {
        // Split text into words based on spaces
        string[] tokens = cleanedText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return tokens;
    }
}