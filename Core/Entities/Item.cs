using System;

namespace Core.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public string Description { get; set; }
    }
}