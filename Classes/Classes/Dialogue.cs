using System.Collections.Generic;

namespace Classes.Classes
{
    public class Dialogue
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        private List<Choice> choices;

        public Dialogue(int id, string text, List<Choice> choices)
        {
            Id = id;
            Text = text;
            this.choices = choices;
        }
    }
}
