using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DPlayer
{
    class Album : Titleable
    {
        protected Artist artist;
        public Artist Artist
        {
            get { return this.Artist; }
            set { this.artist = value; }
        }
        public Outputable Tracks { get; set; }

        public Album()
        {
            
        }

        public Album(XmlNode node)
        {
            this.Tracks = new Outputable();
            Title = node.Attributes["title"].Value.ToString();
            foreach (XmlNode item in node.ChildNodes)
            {
                Tracks.Add(new Track(item));
            }
        }

        internal void WriteToNode(XmlNode node)
        {
            XmlDocument doc = node.OwnerDocument;
            XmlNode album = doc.CreateElement("album");
            XmlAttribute attr = doc.CreateAttribute("title");
            attr.Value = Title;
            album.Attributes.InsertBefore(attr, null);
            foreach (Track item in Tracks)
            {
                item.WriteToNode(album);
            }
            node.AppendChild(album);
        }
    }
}
