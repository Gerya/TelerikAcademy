﻿using System.Runtime.Serialization;

namespace StudentSystem.Model
{
    [DataContract (Name="mark")]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "value")]
        public float Value { get; set; }
    }
}
