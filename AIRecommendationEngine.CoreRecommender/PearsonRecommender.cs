using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.CoreRecommender
{
    public 
        class PearsonRecommender : IRecommender
    {
        public double GetCorrelation(List<int> baseData, List<int> otherData)// follow business rules used in unit test folder pearson
        {
            double meanBase,meanOther,stdBase,stdOther;
            double meanBaseOther;
            if (baseData.Count > otherData.Count)
            {
                for(int i=otherData.Count;i<baseData.Count;i++)
                {
                    if (baseData[i]<10)
                        baseData[i]++;
                    otherData.Add(1);
                }
            }
            else if(baseData.Count < otherData.Count)
            {
                otherData.RemoveRange(baseData.Count,otherData.Count-baseData.Count);
            }
            for(int i=0;i<baseData.Count;i++)
            {
                if (baseData[i] == 0)
                {
                    baseData[i]++;
                    if (otherData[i]<10)
                        otherData[i]++;
                }
                if (otherData[i] == 0)
                {
                    otherData[i]++;
                    if (baseData[i] < 10)
                        baseData[i]++;
                }
                
            }
            int N=baseData.Count;
            int SumXY=0;
            int SumX=baseData.Sum();
            int SumY=otherData.Sum();
            for(int i=0;i<baseData.Count;++i)
            {
                SumXY += baseData[i]*otherData[i];
            }
            int SumXSquared=baseData.Select(x => x*x).Sum();
            int SumYSquared=otherData.Select(y => y*y).Sum();
            double PearsonCoefficient;
            double numerator=(N*SumXY)-(SumX*SumY);
            double denominator = Math.Sqrt(((N * SumXSquared) - (SumX * SumX)) * ((N * SumYSquared) - (SumY * SumY)));
            PearsonCoefficient= (numerator/denominator);
            return PearsonCoefficient;
        }
    }
}
