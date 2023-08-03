using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class TransformSaveComponent : SaveComponentBase
    {
        public override string GetSerializedValue()
        {
            TransformData transformData = new TransformData(transform);
            return JsonConvert.SerializeObject(transformData);
        }

        public override void LoadData(string value)
        {
            TransformData transformData = JsonConvert.DeserializeObject<TransformData>(value);
            transform.position = transformData.Position;
            transform.rotation = transformData.Rotation;
            transform.localScale = transformData.Scale;
        }

        [Serializable]
        public class TransformData
        {
            public SerializableVector3 Position;
            public SerializableQuaternion Rotation;
            public SerializableVector3 Scale;
            
            public TransformData()
            {

            }
            
            public TransformData(Transform transform)
            {
                Position = transform.position;
                Rotation = transform.rotation;
                Scale = transform.localScale;
            }
        }

    }
}