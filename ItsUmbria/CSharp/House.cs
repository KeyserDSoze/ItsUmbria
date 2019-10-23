using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CSharp
{
    public class House
    {
        public int NumberOfDoors { get; set; }
        public int NumberOfWindows { get; set; }
        public int NumberOfSolarPanels { get; set; }
        private int NumberOfBathroom;
        private int NumberOfBedroom;
        public House(int numberOfDoors, int numberOfWindows, int numberOfBathroom, int numberOfBedroom, int numberOfSolarPanels)
        {
            this.NumberOfDoors = numberOfDoors;
            this.NumberOfWindows = numberOfWindows;
            this.NumberOfBathroom = numberOfBathroom;
            this.NumberOfBedroom = numberOfBedroom;
            this.NumberOfSolarPanels = numberOfSolarPanels;
        }
        public double ProduceEnergy()
        {
            Console.WriteLine($"Produce {(this.NumberOfSolarPanels * 20)} KW/H of electrical energy.");
            return this.NumberOfSolarPanels * 20;
        }
    }
    public class BuildAnHouse : ITest
    {
        public void Do()
        {
            House houseOfMine = new House(3, 4, 2, 2, 4);
            houseOfMine.ProduceEnergy();
            House houseOfMyFriend = new House(6, 6, 1, 3, 9);
            houseOfMyFriend.ProduceEnergy();
            House houseOfMyGrandfather = new House(numberOfBedroom: 3, numberOfBathroom: 4, numberOfDoors: 5, numberOfWindows: 9, numberOfSolarPanels: 5);
            houseOfMyGrandfather.ProduceEnergy();
        }
    }
}
