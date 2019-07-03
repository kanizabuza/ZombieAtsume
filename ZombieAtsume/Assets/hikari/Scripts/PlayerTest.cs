using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private bool isControl;

    void Update() {

    }

    public void ChangeControl(bool flag) {
        isControl = flag;
        this.GetComponent<MeshRenderer>().enabled = flag;
    }
}
