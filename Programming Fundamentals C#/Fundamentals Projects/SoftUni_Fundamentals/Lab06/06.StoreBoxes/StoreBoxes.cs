using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class StoreBoxes
    {
        static void Main(string[] args)
        {
            string[] itemData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string end = "end";
            List<Box> items = new List<Box>();

            while (itemData[0] != end)
            {
                string serialNumber = itemData[0];
                string itemName = itemData[1];
                int itemQuantity = int.Parse(itemData[2]);
                double itemPrice = double.Parse(itemData[3]);

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;
                box.ItemQuantity = itemQuantity;
                box.BoxPrice = itemPrice * itemQuantity;

                items.Add(box);

                itemData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            items = items.OrderByDescending(boxPrice => boxPrice.BoxPrice).ToList();

            foreach (Box item in items)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item.Name} - ${item.Item.Price:f2}: {item.ItemQuantity}");
                Console.WriteLine($"-- ${item.BoxPrice:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double BoxPrice { get; set; }

    }
}
