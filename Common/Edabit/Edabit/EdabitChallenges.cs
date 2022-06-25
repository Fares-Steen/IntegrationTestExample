using System.Collections;

namespace Edabit;

public class EdabitChallenges
{
    public static int SockPairs(string socks)
    {
        //"CABBACCC"
        int count = 0;
        string pairs = "";
        for (int i = 0; i < socks.Length; i++)
        {
            if (pairs.Contains(socks[i]))
            {
                count++;
                int letterFound = pairs.IndexOf(socks[i]);
                pairs = pairs.Remove(letterFound, 1);
            }
            else
            {
                pairs += socks[i];
            }
        }

        return count;
    }

    public static int SockPairs2(string socks)
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();

        dictionary.Add(1, "Fadi");
        dictionary.Add(2, "Fares");
        dictionary.Add(3, "Marwan");

        dictionary.ContainsKey(2);
        Hashtable a = new Hashtable();

        a.Add(1, 2);
        a.Add("1", 33);
        a.Add("1", 344);

        var aa = a[1];
        var aaaa = a["1"];

        int[] aaaa1 = new int[] {1, 2};
        aaaa1.Where(a => a > 1);


        //"AABBCCC"
        int count = 0;
        var result = String.Concat(socks.OrderBy(s => s));
        for (int i = 0; i < result.Length; i++)
        {
            if (i == result.Length - 1)
            {
                break;
            }

            if (result[i] == result[i + 1])
            {
                count++;
                i++;
            }
        }

        return count;
    }

    public static void TestLambda()
    {
        int[] arr1 = new int[] {1, 2, 4, 4, 567, 11};

        Func<int, bool> funcy = a => a > 3;
        var result = arr1.Where(a => a > 3).ToArray();


        List<int> result2 = new List<int>();
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] > 3)
            {
                result2.Add(arr1[i]);
            }
        }
    }

    public static bool IsDisarium(int number)
    {
        var result = 0;
        var splitNumber = number;
        var count = (int) Math.Floor(Math.Log10(number)) + 1;

        while (splitNumber != 0)
        {
            var lastNumber = splitNumber % 10;
            splitNumber /= 10;
            result += (int) Math.Pow(lastNumber, count);
            count--;
        }

        return result == number;

    }

    public static int[] Primes(int number)
    {
        List<int> prims = new List<int>();
        for (int i = 2; i <= number; i++)
        {
            if (i == 2 || i == 3 || i == 5)
            {
                prims.Add(i);
                Console.WriteLine(i);
            }

            if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
            {
                prims.Add(i);
                Console.WriteLine(i);
            }
        }

        Console.WriteLine(prims.Count);
        return prims.ToArray();
    }

    public static string LongestPalindrome(string s)
    {
        var answer = "";

        for (var i = 0; i < s.Length; i++)
        {
            if (answer.Length == s.Length) return answer;
            var length = (s.Length - 1) - i + 1;
            if (length <= answer.Length) continue;
            for (var j = s.Length - 1; j >= i; j--)
            {
                var length2 = j - i + 1;
                if (length2 <= answer.Length) continue;
                if (!IsPalindrome(s, i, length2 - 1)) continue;
                var newWord = s.Substring(i, length2);
                answer = newWord;
                break;
            }
        }

        return answer;
    }

    private static bool IsPalindrome(string s1)
    {
        for (var i = 0; i < (s1.Length + 1) / 2; i++)
        {
            if (s1[i] != s1[^(1 + i)])
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsPalindrome(string s1, int left, int length)
    {
        var rightIndex = 0;
        for (var i = left; i < (length + 1) / 2; i++)
        {
            if (s1[i] != s1[length - rightIndex])
            {
                return false;
            }

            rightIndex++;
        }

        return true;
    }
    
    
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        candidates = candidates.OrderBy(x => x).ToArray();

        for (var index = 0; index < candidates.Length; index++)
        {
            var variant = candidates[index];
            if (variant > target)
            {
                return result;
            }

            var newCandidates = new List<int> {variant};
            
            if (variant == target)
            {
                result.Add(newCandidates);
                return result;
            }
            Recursive(result,target,candidates, newCandidates, index);
        }

        return result;
        
    }
    //2,3
    private static void Recursive (IList<IList<int>> result,int target,int[] ocandidates,IList<int> candidates,int index)
    {
        if (candidates.Sum() < target)
        {
            for (int i=index;i< ocandidates.Length;i++)
            {
                var newCan = new List<int>();
                    newCan.AddRange(candidates);
                    newCan.Add(ocandidates[i]);
                    if (newCan.Sum() == target)
                    {
                        result.Add(newCan);
                        break;
                    }

                    if (newCan.Sum() > target)
                    {
                       break;
                    }
                    Recursive(result,target,ocandidates, newCan, i);
            }
        }
    }

    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        //{2,3,5}; 9
        IList<IList<int>> expectedResult = new List<IList<int>>();
        candidates = candidates.OrderBy(x => x).ToArray();
        for (int i = 0; i < candidates.Length; i++)
        {
            if (candidates[i] > target)
            {
                return expectedResult;
            }

            List<int> newSolution = new List<int>();
            int addCount = 0;
            for (int j = i; j < candidates.Length; j++)
            {
                addCount++;
                newSolution.Add(candidates[j]);
                j--;

                if (newSolution.Sum() > target)
                {

                    var lastNumber = newSolution[^2];
                    newSolution.RemoveAt(newSolution.Count - 1);
                    addCount--;
                    if (newSolution.Count == 1)
                    {
                        break;
                    }

                    if (addCount >= 1)
                    {
                        newSolution.RemoveAt(newSolution.Count - 1);
                        addCount--;
                    }



                    if (j == candidates.Length - 2 && newSolution.Count == 1)
                    {
                        break;
                    }

                    if (addCount == 0 || (j == candidates.Length - 2 &&
                                          newSolution[0] == newSolution[newSolution.Count - 1]))
                    {
                        if (addCount == 0)
                        {
                            j = candidates.ToList().IndexOf(newSolution[newSolution.Count - 1]);
                            newSolution.RemoveAt(newSolution.Count - 1);
                        }
                        else
                        {
                            newSolution.RemoveAt(newSolution.Count - 1);
                            j = candidates.ToList().IndexOf(newSolution[0]);
                        }

                    }
                    else
                    {
                        j = candidates.ToList().IndexOf(lastNumber);
                    }

                }

                if (newSolution.Sum() == target)
                {
                    addCount = 0;
                    expectedResult.Add(newSolution.ToArray());
                    if (newSolution.Count == 2)
                    {
                        break;
                    }

                    if (newSolution.Count > 1)
                    {
                        var lastNumber = newSolution[^2];
                        newSolution.RemoveAt(newSolution.Count - 1);
                        newSolution.RemoveAt(newSolution.Count - 1);

                        j = candidates.ToList().IndexOf(lastNumber);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        return expectedResult;
    }

}
/*
2,2,2,2
remove last
2,2,2
add new
2,2,2,3
*/
