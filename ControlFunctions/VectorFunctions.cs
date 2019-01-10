using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorFunctions{
    public static Func<Func<Vector2>, Func<Vector2>, Func<float>, Func<Vector2>> move = ( 
        Func<Vector2> currentPosition,
        Func<Vector2> unitVector,
        Func<float> scaleValue
    ) => () => currentPosition() + (unitVector() * scaleValue());

    public static Func<float, Func<float>> scale = (float flatValue) => () => flatValue;
}