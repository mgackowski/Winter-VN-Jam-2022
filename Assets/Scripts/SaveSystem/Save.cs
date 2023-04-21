using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOs/Save")]
public class Save : ScriptableObject
{

    public string yarnNodeName;
    public List<ObjectPropertiesPair> savedObjects;

    [Serializable]
    public class ObjectPropertiesPair
    {
        [Serializable]
        public class SerializableTuple
        {
            public string key;
            public string value;
        }

        public string statefulObjectName;
        public string statefulComponentName;
        public List<SerializableTuple> properties;
    }


}