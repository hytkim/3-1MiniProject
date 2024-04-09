﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PlayerData //플레이어 데이터만을 저장하는 데이터 클래스
{
    public readonly string NAME;
    //public readonly string JOB;
    //public readonly Sprite PORTRAIT;
    public float max_Player_Hp;
    public float cur_Player_Hp;
    public float max_Player_Sn;
    public float cur_Player_Sn;
    public float max_Player_Mp;
    public float cur_Player_Mp;

    public int player_Gold;
    public int player_level;
    public float player_max_Exp;
    public float player_cur_Exp;
    
    public float atk_Speed;
    public float atk_Range;
    public float base_atk_Dmg;


    public PlayerData(string name)
    {
        this.NAME = name;
        max_Player_Hp = 10;
        cur_Player_Hp = max_Player_Hp;
        max_Player_Mp = 5;
        cur_Player_Mp = max_Player_Mp;
        max_Player_Sn = 50;
        cur_Player_Sn = max_Player_Sn;
        player_max_Exp = 10f;
        player_cur_Exp = 0f;
        player_Gold = 1500;
        atk_Speed = 1f;
        atk_Range = 1f;
        base_atk_Dmg = 1f;
        player_level = 1;
    }

    public string GetPlayerName()
    {
        return this.NAME;
    }

}
[System.Serializable]
public class SaveData
{
    public string playerName;

    public int p_level;
    public int p_gold;

    public int questId;
    public int questActionIndex;

    public float p_max_hp;
    public float p_cur_hp;
    public float p_max_sn;
    public float p_cur_sn;
    public float p_max_mp;
    public float p_cur_mp;
    public float p_atk_speed;
    public float p_atk_range;
    public float p_base_atk_Dmg;
    
    public float p_max_Exp;
    public float p_cur_Exp;

    //public List<Item> items;

    public SaveData(string name, int level, int gold, int qID, int qActID, float max_hp, float cur_hp, float max_sn, float cur_sn, float max_mp, float cur_mp, float a_spd, float a_range, float a_dmg, float max_exp, float cur_exp)
    {
        //this.pd = pd;
        this.playerName = name;
        this.p_level = level;
        this.p_gold = gold;

        this.questId = qID;
        this.questActionIndex = qActID;

        this.p_max_hp = max_hp;
        this.p_cur_hp = cur_hp;

        this.p_max_sn = max_sn;
        this.p_cur_sn = cur_sn;
        
        this.p_max_mp = max_mp;
        this.p_cur_mp = cur_mp;


        this.p_atk_speed = a_spd;
        this.p_atk_range = a_range;
        this.p_base_atk_Dmg = a_dmg;

        this.p_max_Exp = max_exp;
        this.p_cur_Exp = cur_exp;

    }

}

public static class SaveSystem
{
    private static string SavePath => Path.Combine(Application.persistentDataPath, "saves/");// 이렇게 하면 SavePath가 Unity에서 지정한 persistentDataPath에 saves 폴더를 생성합니다.
    public static void Save(SaveData saveData, string saveFileName)
    {
        if (!Directory.Exists(SavePath))// 디렉토리가 없다면 새 디렉토리를 생성하는 조건문
        {
            Directory.CreateDirectory(SavePath);
        }

        string saveJson = JsonUtility.ToJson(saveData);

        string saveFilePath = SavePath + saveFileName + ".json";
        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Success: " + saveFilePath);
    }
    public static SaveData Load(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("No such saveFile exists. Creating a new one...");
            SaveData noneSave = new SaveData("", 0,0,0,0, 0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f);
            Save(noneSave, saveFileName);  // Create a new save file
            return noneSave;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
    public static bool DataCheck(string saveFileName)
    {
        string saveFilePath = SavePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("No such saveFile exists.");
            return false;
        }

        return true;
    }

}