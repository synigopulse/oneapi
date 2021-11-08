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
        public ModeOfStudy ModeOfStudy { get; set; }

        /// <summary>
        /// The <see cref="Program"/> for this offering
        /// </summary>
        public Program Program { get; set; }

        /// <summary>
        /// The organization who offers this offering
        /// </summary>
        public Organization Organization { get; set; }

    }
}
