using UnityEngine;
using System.Collections;

public static class Axis
{
    private const string Hor = "Horizontal";
    private const string Ver = "Vertical";
    private const string Fire1 = "Fire1";
    private const string Fire2 = "Fire2";
    private const string Fire3 = "Fire3";

    public enum AxisType
    {
        Horizontal,
        Vertical,
        Fire1,
        Fire2,
        Fire3
    }

    public static string GetAxis(AxisType axis)
    {
        switch (axis)
        {
            case AxisType.Fire1:
                return Fire1;
            case AxisType.Fire2:
                return Fire2;
            case AxisType.Fire3:
                return Fire3;
            case AxisType.Horizontal:
                return Hor;
            case AxisType.Vertical:
                return Ver;
            default:
                return "";
        }
    }
}
