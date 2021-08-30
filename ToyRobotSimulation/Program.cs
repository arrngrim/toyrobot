﻿using System;
using System.IO;
using System.Reflection;
using ToyRobotSimulation.Tabletop.Interface;
using ToyRobotSimulation.ToyRobot;
using ToyRobotSimulation.ToyRobot.Interface;

namespace ToyRobotSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merci d'indiquer le nom du fichier de test à utiliser sans extension. Ce fichier doit être placé dans le même dossier que l'application.");

            string filename = Console.ReadLine();
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), filename + ".txt");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Merci de fournir un fichier de test existant");
                return;
            }

            StreamReader file = new StreamReader(filePath);
            string line;

            #region Création du plateau et du robot
            ITabletop tabletop = new Tabletop.Tabletop(5, 5);
            IToyRobot toyRobot = new ToyRobot.ToyRobot();
            #endregion

            while ((line = file.ReadLine()) != null)
            {
                string[] command = line.Split(" ");
                // Le robot n'est pas encore placé sur le plateau
                if (!toyRobot.IsPlaced)
                {
                    // On verifie la validité de la line de commande
                    if (command.Length != 2 || command[0] != "PLACE")
                        Console.WriteLine("Commande invalide. Format : PLACE X,Y,POINT-CARDINAL - Ex : PLACE 0,1,NORTH");
                    else
                    {
                        string[] commandParam = command[1].Split(",");
                        if (commandParam.Length != 3)
                            Console.WriteLine("Commande invalide. Vérifier les paramètres de la commande PLACE. Format : PLACE X,Y,POINT-CARDINAL - Ex : PLACE 0,1,NORTH");
                        else
                        {
                            Orientation orientation;
                            if (!Enum.TryParse(commandParam[2], true, out orientation))
                                Console.WriteLine("Orientation invalide. Merci de choisir l'un des points cardinaux suivants : NORTH,SOUTH,EAST,WEST");
                            else
                            {
                                // On place le robot sur le plateau en concordance avec la commande PLACE qui est valide
                                Coordinates coordinates;
                                int x = Convert.ToInt32(commandParam[0]);
                                int y = Convert.ToInt32(commandParam[1]);
                                coordinates = new Coordinates(x, y);

                                toyRobot.Place(coordinates, orientation, tabletop);
                            }

                        }
                    }
                }
                // Le robot est placé sur le plateau
                else
                {
                    // Vérifie la validité de la ligne de commande
                    if (command.Length != 1 && (command[0] != "MOVE" || command[0] != "LEFT" || command[0] != "RIGHT" || command[0] != "REPORT"))
                        Console.WriteLine("Commande invalide. Utiliser une des commandes suivantes : MOVE, LEFT, RIGHT ou REPORT");
                    else
                    {
                        if (command[0] == "MOVE")
                            toyRobot.Move(tabletop);
                        if (command[0] == "LEFT")
                            toyRobot.Left();
                        if (command[0] == "RIGHT")
                            toyRobot.Right();
                        if (command[0] == "REPORT")
                            toyRobot.Report();
                    }
                }
            }

            file.Close();
            Console.WriteLine("Fin du simulateur.");
            Console.ReadLine();
        }
    }
}
