using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Dialogue
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public List<Choice> Choices { get; private set; }
    }
}
