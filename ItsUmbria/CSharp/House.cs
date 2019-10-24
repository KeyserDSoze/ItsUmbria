using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.CSharp
{
    public class House
    {
        public static int X = 20;
        public int Y = 20;
        public int NumberOfDoors { get; }
        public int NumberOfWindows { get; }
        public int NumberOfSolarPanels { get; set; }
        private int NumberOfBathrooms;
        private int NumberOfBedrooms;
        public House(int numberOfDoors, int numberOfWindows, int numberOfBathroom, int numberOfBedroom, int numberOfSolarPanels)
        {
            this.NumberOfDoors = numberOfDoors;
            this.NumberOfWindows = numberOfWindows;
            this.NumberOfBathrooms = numberOfBathroom;
            this.NumberOfBedrooms = numberOfBedroom;
            this.NumberOfSolarPanels = numberOfSolarPanels;
        }
        public double ProduceEnergy()
        {
            Console.WriteLine($"Produce {(this.NumberOfSolarPanels * 20)} KWH of electrical energy.");
            return this.NumberOfSolarPanels * X;
        }
        public EnergyClass EnergyClass
        {
            get
            {
                double producedEnergy = this.ProduceEnergy();
                if (producedEnergy >= 100)
                {
                    return EnergyClass.A;
                }
                else if (producedEnergy >= 50)
                {
                    return EnergyClass.B;
                }
                else
                {
                    return EnergyClass.C;
                }
            }
        }
    }
    public enum EnergyClass
    {
        A,
        B,
        C,
        D,
        E
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
