using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class StageHandler
{
    private static StageHandler instance = null;

    public Stage CurrentStage
    {
        get;
        set;
    }

    public static StageHandler Handler 

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


    private StageHandler()
    {
        CurrentStage = new Stage(1);
    }

    public Stage GetStage(int id)
    {
        return new Stage(id);
    }


}
public class Stage
{
    public int ID
    {
        get;
    }

    public string Description
    {
        get;
    }

    public string Hint
    {
        get;
    }

    public Sprite FailImage
    {
        get;
    }

    public string FailText
    {
        get;
    }

    public Sprite SuccessImage
    {
        get;
    }

    public string SuccessText
    {
        get;
    }


    public Stage(int id)
    {
        string conn = "URI=file:" + Application.dataPath + "/DB/" + "Question.db";

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Question WHERE ID =" + id.ToString();
        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();


        while (reader.Read())
        {
            ID = reader.GetInt32(0);
            Description = reader.GetString(1);
            Hint = reader.GetString(2);

            byte[] failJpg = (byte[])reader["FailImage"];
            Texture2D failTex = new Texture2D(500, 500);
            failTex.LoadImage(failJpg);
            FailImage = Sprite.Create(failTex, new Rect(0, 0, 400, 400), new Vector2(0.5f, 0.5f));

            FailText = reader.GetString(4);

            byte[] successJpg = (byte[])reader["SuccessImage"];
            Texture2D successTex = new Texture2D(500, 500);
            successTex.LoadImage(successJpg);
            SuccessImage = Sprite.Create(successTex, new Rect(0, 0, 150, 150), new Vector2(0.5f, 0.5f));

            SuccessText = reader.GetString(6);
        }
        dbconn.Close();
        reader.Dispose();
    }
}


