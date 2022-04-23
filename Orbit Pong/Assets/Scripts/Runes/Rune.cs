using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : ScriptableObject
{
    public GameObject spawnable;

    // making it a coroutine so it can handle its own behaviour over time
    public virtual IEnumerator ActivateRoutine() {

        yield break;
    }
}
