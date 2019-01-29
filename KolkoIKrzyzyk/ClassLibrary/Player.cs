using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Player
    {
        string name;

        public Player(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
    }
    public class PlayerX : Player
    {
        public PlayerX(string name = "X") : base(name)
        {
        }
    }
    public class PlayerO : Player
    {
        public PlayerO(string name = "O") : base(name)
        {
        }
    }
}
