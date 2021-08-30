using ToyRobotSimulation.ToyRobot;

namespace ToyRobotSimulation.Tabletop.Interface
{
    interface ITabletop
    {
        public bool IsOutOfBounds(Coordinates robotCoordinates);
    }
}
