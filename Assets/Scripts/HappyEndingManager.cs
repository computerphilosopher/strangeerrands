using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HappyEndingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text t = GameObject.Find("Text").GetComponent<Text>();
        t.text = StageHandler.Handler.CurrentStage.SuccessText;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            StageHandler.Handler.ChangeStage(2);
        }
    }
}
