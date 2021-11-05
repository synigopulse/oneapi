using System.Runtime.Serialization;

namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    ///   The mode of delivery of the component (ECTS-mode of delivery)
    /// - distance-learning: afstandsleren
    /// - on campus: op de campus
    /// - online: online
    /// - hybrid: hybride
    /// - situated: op locatie
    /// </summary>
    public enum ModesOfDelivery
    {
        [EnumMember(Value = "distance-learning")]
        DistanceLearning,
        [EnumMember(Value = "on campus")]
        OnCampus,
        [EnumMember(Value = "online")]
        Online,
        [EnumMember(Value = "hybrid")]
        Hybrid,
        [EnumMember(Value = "situated")]
        Situated
    }
}
