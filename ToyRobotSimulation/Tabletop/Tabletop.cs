
using ToyRobotSimulation.Tabletop.Interface;
using ToyRobotSimulation.ToyRobot;

namespace ToyRobotSimulation.Tabletop
{
    /// <summary>
    /// Classe Tabletop définissant le plateau sur lequel le robot peux se déplacer
    /// </summary>
    class Tabletop : ITabletop
    {
        // Position maximale sur l'axe des X
        public int MaxPositionX { get; set; }
        // Position maximale sur l'axe des Y
        public int MaxPositionY { get; set; }

        public Tabletop(int x, int y)
        {
            this.MaxPositionX = x;
            this.MaxPositionY = y;
        }

        /// <summary>
        /// Vérifie que les coordonées sont bien située sur le plateau
        /// en partant du principe que (0,0) est l'origine (coin sud ouest)
        /// </summary>
        /// <param name="robotCoordinates">Coordonées suivantes du robot</param>
        /// <returns>boolean, vrai si hors du plateau</returns>
        public bool IsOutOfBounds(Coordinates robotCoordinates)
        {
            if (robotCoordinates.X < this.MaxPositionX && robotCoordinates.Y < this.MaxPositionY
                && robotCoordinates.X >= 0 && robotCoordinates.Y >= 0)
            {
                return false;
            }
            return true;
        }
    }
}
