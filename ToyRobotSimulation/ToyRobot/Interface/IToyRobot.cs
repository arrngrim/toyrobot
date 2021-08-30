
using ToyRobotSimulation.Tabletop.Interface;

namespace ToyRobotSimulation.ToyRobot.Interface
{
    interface IToyRobot
    {
        bool IsPlaced { get; }
        public void Place(Coordinates coordinates, Orientation orientation, ITabletop tabletop);
        void Move(ITabletop tabletop);
        public void Left();
        public void Right();
        public void Report();
    }
}
