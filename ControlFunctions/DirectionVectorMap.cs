using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DirectionVectorMap
{
    struct Cardnials{
        public Func<bool> up, right, down, left;

        public Cardnials(Func<bool> up, Func<bool> right, Func<bool> down, Func<bool> left){
            this.up = up;
            this.right = right;
            this.down = down;
            this.left = left;
        }
    }
    private static Func<bool, sbyte> boolToInt = (bool x) => x ? (sbyte)1 : (sbyte)0;

    private static Func<Cardnials, Func<Vector2>> vectorFromCardinal = (Cardnials cardnials) => () => {
        Vector2 returnVector; 
        returnVector = new Vector2(
            boolToInt(cardnials.right()) - boolToInt(cardnials.left()), 
            boolToInt(cardnials.up()) - boolToInt(cardnials.down())
        );
        returnVector.Normalize();
        return returnVector;
    };

    public static Func<Func<bool>, Func<bool>, Func<bool>, Func<bool>, Func<Vector2>> KeyMap = (
        Func<bool> upKey,
        Func<bool> rightKey,
        Func<bool> downKey,
        Func<bool> leftKey
    ) => vectorFromCardinal(new Cardnials(upKey, rightKey, downKey, leftKey));
}
