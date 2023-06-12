using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class SaveComponentCastle : SaveComponentBase
{
    [SerializeField] CastleController controller;   
    public override string GetSerializedValue()
    {
        CastleData data = new CastleData
        {
            isOwns = controller.OwnsCastle
        };
        return JsonConvert.SerializeObject(data);
    }

    public override void LoadData(string value)
    {
        CastleData data = JsonConvert.DeserializeObject<CastleData>(value);

        controller.OwnsCastle = data.isOwns;
    }

    [Serializable]
    public class CastleData
    {
        public bool isOwns;
    }
}
