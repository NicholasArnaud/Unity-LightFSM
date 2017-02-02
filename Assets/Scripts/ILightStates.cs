using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILightStates {

    void UpdateState();
    void ToGreenLight();
    void ToYellowLight();
    void ToRedLight();

}