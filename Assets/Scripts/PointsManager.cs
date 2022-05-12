using System;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public ulong Points;

    public void AddPoints()
    {
        Points += CountPointsToAdd();
    }

    public ulong CountPointsToAdd()
    {
        ulong toAdd = 1;
        return toAdd;
    }

    public void SubtractPoints(ulong price)
    {
        Points -= price;
    }
}
