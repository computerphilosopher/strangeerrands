using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuestSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    StageHandler stageHandler;
    void Start()
    {
        this.stageHandler = StageHandler.Handler;
        Stage currentStage = stageHandler.CurrentStage;

        Debug.Log(currentStage.Hint);

        Text description = GameObject.Find("Description").GetComponent<Text>();
        Text Hint = GameObject.Find("Hint").GetComponent<Text>();

        description.text = currentStage.Description;
        Hint.text = currentStage.Hint;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("shop");
        }
        
    }
}
