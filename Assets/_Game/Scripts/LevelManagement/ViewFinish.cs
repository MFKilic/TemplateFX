using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TemplateFx
{

    public class ViewFinish : MonoBehaviour
    {
        [SerializeField] GameObject winPanelObject;
        [SerializeField] GameObject losePanelObject;

        
        

        public void ManuelStart()
        {
            if(GameState.Instance.GetLevelStatus() == LevelFinishStatus.WIN)
            {
                winPanelObject.SetActive(true);
                losePanelObject.SetActive(false);
            }
            else
            {
                winPanelObject.SetActive(false);
                losePanelObject.SetActive(true);
            }
        }
        

        public void OnFinishButtonPressed()
        {
            GameState.Instance.OnPrepareNewGame();
        }
      
    }


}

