using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Runes {
    public class Rune : ScriptableObject {

        public Sprite icon;

        // making it an ienumerator so it can handle its own behaviour over time
        public virtual IEnumerator ActivateRoutine(ShieldPaddle paddle) {



            yield break;
        }
    }
}
