using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankInt
{
    public interface RankerInt
    {
        int AddScores(int[] scores);
        int ScoresAvg(int[] scores);
        string Rank(int avg);
    }
}
