using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;

[DataContract]
public class CarState
{
    [DataMember(Name = "")]
    public float velocity;
    [DataMember(Name = "")]
    public Vector3 point;
}
