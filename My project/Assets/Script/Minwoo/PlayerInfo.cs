using System.Collections.Generic;
using BansheeGz.BGDatabase;
using UnityEditor.Analytics;
using UnityEngine;


public class PlayerInfo : ScriptableObject
{
    public int maxAnimaNum = 3;
    public List<AnimaDataSO> battleAnima = new List<AnimaDataSO>();
    public List<AnimaDataSO> haveAnima = new List<AnimaDataSO>();
    public AnimaDataSO animaData;
    public bool onBossStage = false;

    public void Initialize()
    {
        var database = BGRepo.I;
        var animaTable = database.GetMeta("Anima");
        

        for(int i = 0; i < 3 ; i++)
        {
            animaData = ScriptableObject.CreateInstance<AnimaDataSO>();
            animaData.Initialize(animaTable[Random.Range(0, 1)].Get<string>("name"));
            animaData.location = i;
            GetAnima(animaData);
            BattleSetting(haveAnima[i]);
        }

    }

    public void BattleSetting(AnimaDataSO animaData)
    {
        if (haveAnima.Contains(animaData) && battleAnima.Count < maxAnimaNum)
        {
            battleAnima.Add(animaData);
        }
    }
    
    public void GetAnima(AnimaDataSO animaData)
    {
        haveAnima.Add(animaData);
    }

}
