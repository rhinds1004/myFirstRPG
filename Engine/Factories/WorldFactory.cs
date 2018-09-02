﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "FarmFields.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100); //type 2 is rat with 100 encounterrate


            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "Farmhouse.png");
            newWorld.AddLocation(0, -1, "Home", "This is your home", "Home.png");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Susan, the trader.",
                "Trader.png");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here.",
                "TownSquare.png");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "Locations/TownGate.png");

            newWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "SpiderForest.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100); //type 3 is spider 100% encounter rate

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "HerbalistsHut.png");

            newWorld.LocationAt(0, 1).QuestAvailableHere.Add(QuestFactory.GetQuestByID(1));// this makes it so you don't need a temp variable to hold the location

            newWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "HerbalistsGarden.png");
            newWorld.LocationAt(0, 2).AddMonster(1, 100); //type 1 is snake 100% encounter rate


            return newWorld;
        }
    }
}
