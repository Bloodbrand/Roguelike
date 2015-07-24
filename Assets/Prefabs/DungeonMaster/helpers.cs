using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class helpers {

    public static float CalculateTotalProbabilityValue(List<Room> list)
    {
        float total = 0;
        for (int i = 0; i < list.Count; i++)
        {
            float prob = list[i].Probability;
            if (prob < 0) prob = 0;
            total += prob;
        }
        return total;
    }

    public static int CalculateTotalProbabilityValue(List<Prop> list)
    {
        double total = 0;
        for (int i = 0; i < list.Count; i++)
        {
            double prob = list[i].Probability;
            if (prob < 0) prob = 0;
            total += prob;
        }
        return (int)total + 1;
    }
}
