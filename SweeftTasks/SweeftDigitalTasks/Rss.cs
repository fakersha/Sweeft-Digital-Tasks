using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SweeftDigitalTasks
{
	[XmlRoot(ElementName = "item")]
	public class Item
	{

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "link")]
		public string Link { get; set; }

		[XmlElement(ElementName = "description")]
		public string Description { get; set; }

		[XmlElement(ElementName = "pubDate")]
		public string PubDate { get; set; }

		[XmlElement(ElementName = "guid")]
		public string Guid { get; set; }
	}

	[XmlRoot(ElementName = "channel")]
	public class Channel
	{

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "link")]
		public string Link { get; set; }

		[XmlElement(ElementName = "description")]
		public string Description { get; set; }

		[XmlElement(ElementName = "language")]
		public string Language { get; set; }

		[XmlElement(ElementName = "copyright")]
		public string Copyright { get; set; }

        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }

        [XmlElement(ElementName = "lastBuildDate")]
		public string LastBuildDate { get; set; }

		[XmlElement(ElementName = "managingEditor")]
		public string ManagingEditor { get; set; }

		[XmlElement(ElementName = "webMaster")]
		public string WebMaster { get; set; }

		[XmlElement(ElementName = "item")]
		public Item Item { get; set; }
	}

	[XmlRoot(ElementName = "rss")]
	public class Rss
	{

		[XmlElement(ElementName = "channel")]
		public Channel Channel { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public double Version { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
