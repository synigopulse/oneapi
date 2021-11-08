using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Synigo.OpenEducationApi.Model.Containers
{
    public class PagedContainer<T>
    {
        /// <summary>
        /// Get or set The number of items per page
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int PageSize { get; set; }
        /// <summary>
        /// Get or set The pageNumber
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        /// <summary>
        /// Get or set a list of paged items
        /// </summary>
        [Required]
        public List<T> Items { get; set; }
    }
}
