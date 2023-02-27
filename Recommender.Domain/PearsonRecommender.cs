using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommender.Domain
{
    public class PearsonRecommender : IRecommender
    {
        public double GetCorrelation(List<int> baseData, List<int> otherData)
        {
            if(baseData.Count>otherData.Count)
            {
                for(int i = otherData.Count; i < baseData.Count; i++)
                {
                    baseData[i]++;
                    otherData.Add(1);
                }
            }
            else if (baseData.Count < otherData.Count)
            {
                otherData.RemoveRange(baseData.Count, otherData.Count - baseData.Count);
            }
            else
            {
                for(int i=0;i<baseData.Count;i++)
                {
                    if (baseData[i] == 0 || otherData[i] == 0)
                    {
                        baseData[i]++;
                        otherData[i]++;
                    }
                }
            }
            double meanBase = baseData.Average();
            double meanOther = otherData.Average();
            double stdBase = Math.Sqrt(baseData.Select((i => (i - meanBase) * (i - meanBase))).Sum()/baseData.Count);
            double stdOther = Math.Sqrt(otherData.Select((i => (i - meanOther) * (i - meanOther))).Sum() / otherData.Count);
            double sumBaseOther=0;
            for(int i = 0; i < baseData.Count; i++)
            {
                sumBaseOther += (baseData[i]-meanBase)*(otherData[i]-meanOther);
            }
            double correlation=sumBaseOther/(baseData.Count*stdBase*stdOther);
            return correlation;
        }
    }
}
