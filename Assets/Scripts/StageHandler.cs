using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler
{
    private StageHandler instance = null;
    

    public StageHandler stageHandelr

    {
        get
        {
            if (instance == null)
            {
                instance = new StageHandler();
            }
            return instance;
        }
    }

    private int currentStageID;

    private StageHandler()
    {
    }

    class Stage
    {
        public int ID{
            get;
        }

        public string Description{
            get;
        }

        public string Hint{
            get;
        }
    }

}
