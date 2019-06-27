using System;
using System.ComponentModel.DataAnnotations;

namespace Beamity.Core.Models
{
    public class Content:EntityBase
    {
        [Required(ErrorMessage ="Name Required")]
        [MaxLength(47)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [MaxLength(65)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Main Image Required")]
        [Display(Name = "Main Image")]
        public string MainImageURL { get; set; }

        [Display(Name = "Slide Image")]
        public string SlideImageURL { get; set; }

        [Display(Name = "Video")]
        public string VideoURL { get; set; }

        [Display(Name = "Audio")]
        public string AudioURL { get; set; }

        public string Text { get; set; }

        [Display(Name = "Is HomePage Content")]
        public bool IsHomePage { get; set; }

        
    }
}