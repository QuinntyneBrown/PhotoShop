using System;

namespace PhotoShop.Core.DomainEvents
{
    public class GalleryNameChanged: DomainEvent
    {
        public GalleryNameChanged(Guid galleryNameChangedId, string name)
        {
            GalleryNameChangedId = galleryNameChangedId;
            Name = name;
        }

		public Guid GalleryNameChangedId { get; set; }
        public string Name { get; set; }
    }
}
