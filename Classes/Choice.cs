namespace Classes
{
    public class Choice
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        private Dialogue leadsToDialogue;

        public Choice(Dialogue leadsToDialogue, int id, string text)
        {
            this.leadsToDialogue = leadsToDialogue;
            Id = id;
            Text = text;
        }
    }
}
