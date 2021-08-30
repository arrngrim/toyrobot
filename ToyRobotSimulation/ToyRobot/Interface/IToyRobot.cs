
using ToyRobotSimulation.Tabletop.Interface;

namespace ToyRobotSimulation.ToyRobot.Interface
{
    interface IToyRobot
    {
        bool IsPlaced { get; }
        public void Place(Coordinates coordinates, Orientation orientation, ITabletop tabletop);
        void Move(ITabletop tabletop);
        public void Turn(string command);
        public void Report();
    }
}
