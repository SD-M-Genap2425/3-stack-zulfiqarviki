using Solution.BracketValidation;
using Solution.BrowserHistory;
using Solution.Palindrome;

namespace Solution;

internal class Program
{
    static void Main(string[] args)
    {
        // Browser history
        HistoryManager browser = new HistoryManager();

        browser.KunjungiHalaman("google.com");
        browser.KunjungiHalaman("example.com");
        browser.KunjungiHalaman("stackoverflow.com");
            
        browser.LihatHalamanSaatIni();
            
        browser.Kembali();
        browser.LihatHalamanSaatIni();
            
        browser.TampilkanHistory();
        
        
        
        // Bracket validator
        BracketValidator validator = new BracketValidator();
        string ekspresiValid = "[{}](){}";
        string ekspresiInvalid = "(]";

        Console.WriteLine($"Ekspresi '{ekspresiValid}' valid? {validator.ValidasiEkspresi(ekspresiValid)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid}' valid? {validator.ValidasiEkspresi(ekspresiInvalid)}");

        

        //Palindrome Checker
        string[] testCases = { "Kasur ini rusak", "Ibu Ratna antar ubi", "Linggang guli guli guli gwaca" };

        foreach (string testCase in testCases)
        {
            Console.WriteLine($"Input: \"{testCase}\" -> Output: {PalindromeChecker.CekPalindrom(testCase)}");
        }

        

    }
}
