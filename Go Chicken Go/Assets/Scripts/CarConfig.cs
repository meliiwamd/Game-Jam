using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarConfig", menuName = "GoChickenGoConfigs/CarConfig")]
public class CarConfig : ScriptableObject
{
    public float speed;
    public int direction;
}
