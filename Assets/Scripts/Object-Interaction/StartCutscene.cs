using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public GameObject cutSceneParent;
    public int cutSceneTime;
    public GameObject minimapParent;

    public GameObject moneyCollectorBeforeGlitch_1, moneyCollectorBeforeGlitch_2, moneyCollectorAfterGlitch_1;
    
    public void OnTriggerEnter() {
        switchMoneyCollectors();
        StartCoroutine(startCutScene());
    }

    IEnumerator startCutScene() {
        cutSceneParent.SetActive(true);
        yield return new WaitForSeconds(cutSceneTime);
        minimapParent.SetActive(false);
        cutSceneParent.SetActive(false);
    }

    public void switchMoneyCollectors() {
        
    }
}
