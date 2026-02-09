using System.Linq;

public static class StringExtensions
{
    public static bool IsPalindrome(this string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return false;

        var cleaned = new string(
            s.Where(char.IsLetterOrDigit)
             .Select(char.ToLower)
             .ToArray()
        );

        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
