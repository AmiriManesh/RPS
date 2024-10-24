using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHand : Hand
{
    private string name;
    public string GetName()
    {
        return name;
    }

    public int InvertResult(int result)
    {
        return result == 0 ? 0 : result == 1 ? -1 : 1;
    }
}
