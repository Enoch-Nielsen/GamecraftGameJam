using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // 0 : Nothing, 1 : Straight, Upright : 2, UpLeft : 3, RightUp: 4, DownRight : 5.
    [Tooltip("0 : Nothing, 1 : Straight, Upright : 2, UpLeft : 3, RightUp: 4, DownRight : 5")]
    private int pipeId;
}
