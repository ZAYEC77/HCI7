using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DPlayer
{
    class Artist : Titleable
    {
        public Outputable Albums { get; set; }

        public Artist()
        {
            this.Albums = new Outputable();
        }
        public Artist(XmlNode node)
        {
            this.Albums = new Outputable();
            Title = node.Attributes["title"].Value.ToString();
            foreach (XmlNode item in node.ChildNodes)
            {
                Albums.Add(new Album(item));
            }
        }
        public void WriteToNode(XmlNode node)
        {
            XmlDocument doc = node.OwnerDocument;
            XmlNode artist = doc.CreateElement("artist");
            XmlAttribute attr = doc.CreateAttribute("title");
            attr.Value = Title;
            artist.Attributes.InsertBefore(attr, null);
            foreach (Album item in Albums)
            {
                item.WriteToNode(artist);
            }
            node.AppendChild(artist);
        }
    }
}
