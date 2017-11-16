using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Choice
    {

        public int Id { get; private set; }
        public string Text { get; private set; }
        public Dialogue LeadsToDialogue { get; private set; }
        public Choice(int id, string text, Dialogue leadsToDialogue)
        {
            Id = id;
            Text = text;
            LeadsToDialogue = leadsToDialogue;
        }
        

       
    }
}
