using System;
using ToyRobotSimulation.Tabletop.Interface;
using ToyRobotSimulation.ToyRobot.Interface;


namespace ToyRobotSimulation.ToyRobot
{
    public enum Orientation
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }

    class ToyRobot : IToyRobot
    {
        #region Properties
        // Coordonnées du robot
        public Coordinates Coordinates;
        // Orientation du robot
        public Orientation Orientation;
        // Permet de vérifier si le robot est bien sur le plateau
        private bool _IsPlaced;
        #endregion

        #region Getter
        public bool IsPlaced { get { return this._IsPlaced; } }
        #endregion

        #region Constructor(s)
        public ToyRobot()
        {
            this._IsPlaced = false;
        }
        #endregion

        #region Method(s)
        #region Public
        /// <summary>
        /// Place le robot sur le plateau à la positition X,Y et orienté vers un point cardinal
        /// </summary>
        /// <param name="coordinates">Initialisation des coordonées d'origine, Coordinates</param>
        /// <param name="orientation">Initialisation de l'orientation d'origine, Orientation</param>
        public void Place(Coordinates coordinates, Orientation orientation, ITabletop tabletop)
        {
            Coordinates firstCoordinates = new Coordinates(coordinates.X, coordinates.Y);
            if (!tabletop.IsOutOfBounds(firstCoordinates))
            {
                this.Coordinates = coordinates;
                this.Orientation = orientation;
                this._IsPlaced = true;
            }
        }

        /// <summary>
        /// Déplace le robot sur le plateau si les nouvelles coordonnées sont correctes
        /// </summary>
        /// <param name="tabletop">Instance du planteau sur lequel se situe le robot</param>
        public void Move(ITabletop tabletop)
        {
            if (this._IsPlaced)
            {
                Coordinates newCoordinates = new Coordinates(this.Coordinates.X, this.Coordinates.Y);
                if (this.Orientation == Orientation.NORTH)
                    newCoordinates.Y++;
                if (this.Orientation == Orientation.SOUTH)
                    newCoordinates.Y--;
                if (this.Orientation == Orientation.EAST)
                    newCoordinates.X++;
                if (this.Orientation == Orientation.WEST)
                    newCoordinates.X--;

                if (!tabletop.IsOutOfBounds(newCoordinates))
                    this.Coordinates = newCoordinates;
            }
        }

        /// <summary>
        /// Tourne le robot sur l'orientation suivante à gauche
        /// </summary>
        public void Left()
        {
            if (this._IsPlaced)
            {
                switch (this.Orientation)
                {
                    case Orientation.NORTH:
                        this.Orientation = Orientation.WEST;
                        break;
                    case Orientation.SOUTH:
                        this.Orientation = Orientation.EAST;
                        break;
                    case Orientation.EAST:
                        this.Orientation = Orientation.NORTH;
                        break;
                    case Orientation.WEST:
                        this.Orientation = Orientation.SOUTH;
                        break;
                }
            }
        }

        /// <summary>
        /// Tourne le robot sur l'orientation suivante à droite
        /// </summary>
        public void Right()
        {
            if (this._IsPlaced)
            {
                switch (this.Orientation)
                {
                    case Orientation.NORTH:
                        this.Orientation = Orientation.EAST;
                        break;
                    case Orientation.SOUTH:
                        this.Orientation = Orientation.WEST;
                        break;
                    case Orientation.EAST:
                        this.Orientation = Orientation.SOUTH;
                        break;
                    case Orientation.WEST:
                        this.Orientation = Orientation.NORTH;
                        break;
                }
            }
        }

        /// <summary>
        /// Indique la position du robot et son orientation
        /// </summary>
        public void Report()
        {
            if (this._IsPlaced)
                Console.WriteLine("{0},{1},{2}", this.Coordinates.X, this.Coordinates.Y, this.Orientation.ToString());
        }
        #endregion
        #endregion
    }
}
