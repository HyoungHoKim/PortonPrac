using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMgr : MonoBehaviour
{
    public GameObject ufo1, ufo2, ufo3;
    public Transform PlayerTr;

    void Start()
    {
        /*
        //UFO1 MoveTo
        iTween.MoveTo(ufo1, iTween.Hash("y", 10.0f
                                      , "time", 2.0f
                                      , "delay", 3.0f
                                      , "oncompletetarget", this.gameObject
                                      , "oncomplete", "MoveUfo2"
                                      , "easetype", iTween.EaseType.easeOutBounce));
        */

        Hashtable ht = new Hashtable();
        ht.Add("path", iTweenPath.GetPath("Path1"));
        ht.Add("time", 20.0f);
        ht.Add("easyType", iTween.EaseType.linear);
        //ht.Add("orienttopath", true);
        ht.Add("looktarget", PlayerTr.position);
        ht.Add("looktime", 0.2f);

        iTween.MoveTo(ufo1, ht);
    }

    void MoveUfo2()
    {
        Debug.Log("Enter MoveUfo2");
        //UFO2 MoveBy
        Hashtable ht = new Hashtable();
        ht.Add("y", 20.0f);
        ht.Add("time", 2.0f);
        ht.Add("easetype", iTween.EaseType.easeOutElastic);
        ht.Add("oncompletetarget", this.gameObject);
        ht.Add("oncomplete", "MoveUfo3");

        iTween.MoveBy(ufo2, ht);
    }

    void MoveUfo3()
    {
        Debug.Log("Enter MoveUfo3");
        //UFO3 MoveFrom
        Hashtable ht1 = new Hashtable();
        ht1.Add("y", 50.0f);
        ht1.Add("time", 2.0f);
        ht1.Add("easetype", iTween.EaseType.easeOutElastic);

        iTween.MoveFrom(ufo3, ht1);
    }

}