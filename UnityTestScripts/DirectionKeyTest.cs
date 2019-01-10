using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionKeyTest : MonoBehaviour {
    Func<Vector2> keyMap;
    Func<Vector2> newPosition;
    public Vector2 keyMapValue;
    private void Start(){
        keyMap = DirectionVectorMap.KeyMap(
            keyBind(KeyCode.W),
            keyBind(KeyCode.D),
            keyBind(KeyCode.S),
            keyBind(KeyCode.A)
        );
        newPosition = VectorFunctions.move(
            () => (Vector2) gameObject.transform.position,
            keyMap,
            VectorFunctions.scale(0.1f)
        );

    }

    private static Func<KeyCode, Func<bool>> keyBind = code => () => Input.GetKey(code);  
    

    private void Update(){
        keyMapValue = keyMap();
        transform.position = newPosition();
        //(this.position(), keyMap(), scale()) => newPostion
        

    }
}