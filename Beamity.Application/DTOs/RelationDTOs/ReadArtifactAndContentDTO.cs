using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.DTOs.RelationDTOs
{
    public class ReadArtifactAndContentDTO 
    {
        //Artifact
        public string ArtifactName { get; set; }
        //Content
        public string ContentName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainImageURL { get; set; }
        public string VideoURL { get; set; }
        public string SlideImageURL { get; set; }
        public string AudioURL { get; set; }
        public string Text { get; set; }
        public bool IsHomePage { get; set; }
        public bool IsCampaign { get; set; }
    }
}
