using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlayer
{
    enum Style {rock = 1, pop = 2, alternative = 3, electronic = 4}
    class Track : Titleable
    {
        protected Album album;
        public Style Style { get; set; }
        public Album Album
        {
            get { return this.album; }
            set { this.album = value; }
        }
        public Artist Artist
        {
            get { return this.album.Artist; }
        }
        public Track(String title, Album album)
        {
            this.Title = title;
            this.album = album;
        }

        public Track()
        {
            
        }
    }
    

}
