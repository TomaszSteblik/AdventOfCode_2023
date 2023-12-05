internal class Program
{

    static readonly Dictionary<string, int> numbersAsWordsDict = new Dictionary<string, int>()
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    private static async Task Main(string[] args)
    {
        string[] inputs = await File.ReadAllLinesAsync(args[0]);
        int solution = 0;
        foreach (string input in inputs)
        {
            var chars = input.ToCharArray();
            var digits = chars.Where(x=> (int)x >= 48 && (int)x <= 57);
            var digitOne = digits.First()-48;
            var digitTwo = digits.Last()-48;

            var indexOfFirstDigit = input.IndexOf(digits.First());
            var indexOfSecondDigit = input.Length - new string(input.Reverse().ToArray()).IndexOf(digits.Last()) -1;

            var firstSub = input.Substring(0, indexOfFirstDigit);
            var secondSub = input.Substring(indexOfSecondDigit, input.Length-indexOfSecondDigit);

            var numbersBefore = FindNumbersInString(firstSub);
            var numbersAfter = FindNumbersInString(secondSub);

            if(numbersBefore.Any()){
                digitOne = numbersBefore.First();
            }

            if(numbersAfter.Any()){
                digitTwo = numbersAfter.Last();
            }


            var number = $"{digitOne}{digitTwo}";
            solution += int.Parse(number);
            System.Console.WriteLine(number);
        }
        System.Console.WriteLine(solution);
    }

    private static List<int> FindNumbersInString(string input){
        var numbers = new List<int>();
        for(int i =0; i< input.Length; i++){
            foreach(var (key, value) in numbersAsWordsDict){
                if(i+key.Length > input.Length){
                    continue;
                }
                if(input.Substring(i, key.Length) == key){
                    numbers.Add(value);
                }
            }
        }
        return numbers;
    }
}