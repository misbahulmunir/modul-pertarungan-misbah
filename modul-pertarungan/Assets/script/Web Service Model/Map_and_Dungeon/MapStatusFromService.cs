using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
    public class MapStatusFromService
    {
        [XmlElement("MapStatus")]
        public List<MapStatus> mapList = new List<MapStatus>();
    }
}
