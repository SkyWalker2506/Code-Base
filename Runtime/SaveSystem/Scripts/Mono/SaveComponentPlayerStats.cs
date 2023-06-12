using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class SaveComponentPlayerStats : SaveComponentBase
{
    [SerializeField] ScriptablePlayerStats playerStats;
    public override string GetSerializedValue()
    {
        Stat stat = new Stat
        {
            PlayerHealthLevel = playerStats.PlayerHealthLevel,
            PlayerDamageLevel = playerStats.PlayerDamageLevel,
            PlayerSpeedLevel = playerStats.PlayerSpeedLevel,
            PlayerLeadershipLevel = playerStats.PlayerLeadershipLevel,
            ArmyDamage = playerStats.ArmyDamage,
            ArmyHealth = playerStats.ArmyHealth,
            PlayerLevel = DataManager.Instance.CurrentLevel,
            PlayerExp = DataManager.Instance.CurrentExprience,
            PlayerGold = DataManager.Instance.CoinAmount
        };
        return JsonConvert.SerializeObject(stat);
    }

    public override void LoadData(string value)
    {
        Stat stat = JsonConvert.DeserializeObject<Stat>(value);

        playerStats.PlayerHealthLevel = stat.PlayerHealthLevel;
        playerStats.PlayerDamageLevel = stat.PlayerDamageLevel;
        playerStats.PlayerSpeedLevel = stat.PlayerSpeedLevel;
        playerStats.PlayerLeadershipLevel = stat.PlayerLeadershipLevel;
        playerStats.ArmyDamage = stat.ArmyDamage;
        playerStats.ArmyHealth = stat.ArmyHealth;

        DataManager.Instance.CurrentLevel = stat.PlayerLevel;
        DataManager.Instance.CurrentExprience = stat.PlayerExp;
        DataManager.Instance.CoinAmount = stat.PlayerGold;
    }

    [Serializable]
    public class Stat
    {
        public int PlayerHealthLevel;
        public int PlayerDamageLevel;
        public int PlayerSpeedLevel;
        public int PlayerLeadershipLevel;
        public int ArmyDamage;
        public int ArmyHealth;

        public int PlayerLevel;
        public int PlayerExp;

        public int PlayerGold;
    }
}
