namespace MediatorPattern
{
    public interface IAirTrafficControl
    {
        void ReceiveAircraftLocation(Aircraft location);
        void RegisterAircraftUnderGuidance(Aircraft aircraft);
        void ShowAircraftsPositions();
    }
}