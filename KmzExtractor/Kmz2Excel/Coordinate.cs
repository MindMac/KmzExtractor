using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KmzExtractor
{
    class Coordinate
    {
        private String latitude;
        private String longitude;

        public Coordinate(String theLongitude, String theLatitude)
        {
            latitude = theLatitude;
            longitude = theLongitude;
        }

        public String getLatitude()
        {
            return latitude;
        }

        public String getLongitude()
        {
            return longitude;
        }
    }
}
