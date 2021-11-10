using System;
using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// Type of relation between person and In Case of Emergency contact
    /// </summary>
    public enum ICERelationType
    {

        [EnumMember(Value = "partner")]
        Partner,
        [EnumMember(Value = "parent")]
        Parent,
        [EnumMember(Value = "other")]
        Other
    }
}
