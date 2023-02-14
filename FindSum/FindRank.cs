using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RankInt;

namespace Ranker { 
public class FindRank:RankerInt
{
    public int AddScores(int[] scores)
    {
        int sum = 0;
        foreach (var score in scores)
        {
            sum += score;
        }
        return sum;
    }

    public string Rank(int avg)
    {
        if (avg >= 60)
            return "1st class";
        else if (avg >= 50)
            return "2nd class";
        else if (avg >= 35)
            return "pass";
        else
            return "fail";
    }

    public int ScoresAvg(int[] scores)
    {
        return (int)AddScores(scores)/scores.Length;
    }
}
}
