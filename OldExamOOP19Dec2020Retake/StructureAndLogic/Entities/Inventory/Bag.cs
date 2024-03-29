﻿using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
                throw new InvalidOperationException("Bag is full!");

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
                throw new InvalidOperationException("Bag is empty!");

            Item gotItem = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (gotItem == null)
                throw new ArgumentException($"No item with name {name} in bag!");

            return gotItem;
        }
    }
}
