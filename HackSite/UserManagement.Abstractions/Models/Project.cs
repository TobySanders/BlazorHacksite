using System;

namespace UserManagement.Abstractions.Models
{
    public class Project
    {
        /// <summary>
        /// The Id of the project
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title / name of the project
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The repository URL that contains the source of the project
        /// </summary>
        public string RepositoryUrl { get; set; }

        /// <summary>
        /// Project image in base64 format
        /// </summary>
        public string ProjectImage { get; set; }

        /// <summary>
        /// Short code of the project which is used for "quick join" functionality"
        /// </summary>
        public string ShortCode { get; set; } //For sharing

        /// <summary>
        /// Specifies if the project is an active or completed project
        /// </summary>
        public bool IsActive { get; set; }
    }
}
