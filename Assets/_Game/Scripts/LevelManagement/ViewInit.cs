using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TemplateFx
{

    public class ViewInit : MonoBehaviour
    {
        // Start is called before the first frame update
        public void ViewInitStart()
        {
            UIManager.Instance.viewPlay.gameObject.SetActive(true);
            UIManager.Instance.viewPlay.ViewPlayStart();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

