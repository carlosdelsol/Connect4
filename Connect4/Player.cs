using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Player
    {
        public string Name { get; set; }
        public Grid.Colors colour { get; set; }

        public Player(string name, Grid.Colors colour) {
            this.Name = name;
            this.colour = colour;
        }
    }
}
