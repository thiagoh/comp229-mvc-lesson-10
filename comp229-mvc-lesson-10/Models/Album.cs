namespace comp229_mvc_lesson_10.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Album")]
    public partial class Album {

        public Album() {
        }

        public Album(string title) {
            this.Title = title;
        }

        public int AlbumId { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Album Title")]
        public string Title { get; set; }Albums

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [StringLength(1024)]
        [Display(Name = "Album Art URL")]
        [ScaffoldColumn(false)]
        public string AlbumArtUrl { get; set; }
    }
}
