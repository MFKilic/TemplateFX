using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TemplateFx
{
    public class EventManager : MonoBehaviour
    {
        public delegate void OnFirstInputDelegate();
        public event OnFirstInputDelegate OnFirstInputEvent;

        public void OnFirstInputIsPressed()
        {
            OnFirstInputEvent?.Invoke();
        }
       
    }
}

