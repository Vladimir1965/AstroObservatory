namespace AstroSharedClasses.Records
{
    public class GeoRecord
    {
        public GeoRecord(char givenGeoType, int givenDay, int givenMonth, int givenYear, string givenDescription) {
            this.GeoType = givenGeoType;
            this.JulianDate = Calendars.Julian.JulianDay(givenDay, givenMonth, givenYear);
            this.Description = givenDescription;
        }

        public char GeoType { get; set; }

        public int VEI { get; set; }
        public double Magnitude { get; set; }

        public double JulianDate { get; set; }

        public string Description { get; set; }

    }
}
