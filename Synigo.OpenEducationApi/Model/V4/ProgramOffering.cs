namespace Synigo.OpenEducationApi.Model.V4
{
    /// <summary>
    /// The offering of a program
    /// </summary>
    public class ProgramOffering : Offering
    {
        /// <summary>
        /// The <see cref="ModeOfStudy"/> of this ProgramOffering
        /// </summary>
        ModeOfStudy ModeOfStudy { get; set; }

        /// <summary>
        /// The <see cref="Program"/> for this offering
        /// </summary>
        Program Program { get; set; }

        /// <summary>
        /// The organization who offers this offering
        /// </summary>
        Organization Organization { get; set; }

    }
}
